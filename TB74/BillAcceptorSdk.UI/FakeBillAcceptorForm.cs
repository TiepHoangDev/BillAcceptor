using System.IO.Ports;
using System.Threading.Tasks;

namespace BillAcceptorSdk.UI;

public partial class FakeBillAcceptorForm : Form
{
    private SerialPort? _serialPort;
    private bool _autoReply = true;
    private bool _isPowerUpDone = false;
    private bool _isEnabled = false;
    private bool _isInEscrow = false;
    private BillAcceptorProtocolConfig _protocolConfig = BillAcceptorProtocolConfig.Default;

    public FakeBillAcceptorForm()
    {
        InitializeComponent();
        Load += FakeBillAcceptorForm_Load;
    }

    private void FakeBillAcceptorForm_Load(object? sender, EventArgs e)
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        cmbComPort.Items.AddRange(SerialPort.GetPortNames());
        if (cmbComPort.Items.Count > 0)
            cmbComPort.SelectedIndex = 0;

        chkAutoReply.Checked = _autoReply;
        ShowSettingsPanel();
    }

    private void ShowSettingsPanel()
    {
        panelSettings.Visible = true;
        panelRunning.Visible = false;
    }

    private void ShowRunningPanel()
    {
        panelSettings.Visible = false;
        panelRunning.Visible = true;
        txtLog.Clear();
        btnStop.Visible = true;
        btnBack.Visible = false;
        GenerateDenominationButtons();
    }

    private void GenerateDenominationButtons()
    {
        var existingButtons = grpManual.Controls.OfType<Button>()
            .Where(b => b.Tag?.ToString() == "DenominationButton")
            .ToList();

        foreach (var btn in existingButtons)
        {
            grpManual.Controls.Remove(btn);
            btn.Dispose();
        }

        var sortedBills = _protocolConfig.BillTypeMapping.OrderBy(x => x.Value).ToList();
        int x = 20;
        int y = 90;
        int buttonWidth = 110;
        int buttonHeight = 40;
        int spacing = 10;

        for (int i = 0; i < sortedBills.Count; i++)
        {
            var billType = sortedBills[i].Key;
            var amount = sortedBills[i].Value;

            var btn = new Button
            {
                Font = new Font("Segoe UI", 9F),
                Location = new Point(x + (i * (buttonWidth + spacing)), y),
                Name = $"btnSend{amount}",
                Size = new Size(buttonWidth, buttonHeight),
                Text = $"{amount / 1000}k\n(0x81 0x{billType:X2})",
                UseVisualStyleBackColor = true,
                Tag = "DenominationButton"
            };

            btn.Click += async (s, e) =>
            {
                await SendByteAsync(_protocolConfig.EscrowStartByte);
                await Task.Delay(100);
                await SendByteAsync(_protocolConfig.EscrowSecondByte);
                await Task.Delay(100);
                await SendByteAsync(billType);
                _isInEscrow = true;
            };

            grpManual.Controls.Add(btn);
        }
    }

    private async void BtnStart_Click(object sender, EventArgs e)
    {
        await StartAsync();
    }

    private async Task StartAsync()
    {
        try
        {
            ShowRunningPanel();
            LogMessage("=== STARTING FAKE DEVICE ===");

            _serialPort = new SerialPort
            {
                PortName = cmbComPort.Text,
                BaudRate = 9600,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = Parity.Even,
                Handshake = Handshake.None
            };

            _serialPort.DataReceived += SerialPort_DataReceived;
            _serialPort.Open();

            await Task.Delay(500);

            _isPowerUpDone = false;
            _isEnabled = true;
            _isInEscrow = false;

            await SendByteAsync(_protocolConfig.PowerUpByte);
            await Task.Delay(100);
            await SendByteAsync(_protocolConfig.PowerUpResponseByte);

            LogMessage("✅ Connected and sent PowerUp (0x80 0x8F)");
        }
        catch (Exception ex)
        {
            LogMessage($"❌ Connection failed: {ex.Message}");
            MessageBox.Show($"Connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ShowSettingsPanel();
        }
    }

    private void BtnStop_Click(object sender, EventArgs e)
    {
        StopAsync();
    }

    private void StopAsync()
    {
        try
        {
            LogMessage("=== STOPPING ===");

            if (_serialPort?.IsOpen == true)
            {
                _serialPort.Close();
            }

            _serialPort?.Dispose();
            _serialPort = null;

            LogMessage("✅ Stopped");
            btnStop.Visible = false;
            btnBack.Visible = true;
        }
        catch (Exception ex)
        {
            LogMessage($"❌ Stop error: {ex.Message}");
        }
    }

    private void BtnBack_Click(object sender, EventArgs e)
    {
        if (_serialPort?.IsOpen == true)
        {
            MessageBox.Show("Please stop the device first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        ShowSettingsPanel();
    }

    private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        if (_serialPort == null || !_serialPort.IsOpen) return;

        try
        {
            while (_serialPort.BytesToRead > 0)
            {
                var receivedByte = (byte)_serialPort.ReadByte();
                LogMessage($"<< RX: 0x{receivedByte:X2} ({GetByteDescription(receivedByte)})");

                if (_autoReply)
                {
                    HandleAutoReply(receivedByte);
                }
            }
        }
        catch (Exception ex)
        {
            LogMessage($"❌ Read error: {ex.Message}");
        }
    }

    private async void HandleAutoReply(byte receivedByte)
    {
        try
        {
            if (!_isPowerUpDone)
            {
                if (receivedByte == _protocolConfig.AckByte)
                {
                    LogMessage($"✅ Auto: PowerUp ACK received (0x{_protocolConfig.AckByte:X2}) → Ready");
                    _isPowerUpDone = true;
                }
                return;
            }

            if (receivedByte == _protocolConfig.EnableByte)
            {
                LogMessage($"✅ Auto: Enable command (0x{_protocolConfig.EnableByte:X2}) → Starting bill simulation...");
                _isEnabled = true;
                return;
            }

            if (receivedByte == _protocolConfig.DisableByte)
            {
                LogMessage($"⏹️ Auto: Disable command (0x{_protocolConfig.DisableByte:X2})");
                _isEnabled = false;
                _isInEscrow = false;
                return;
            }

            if (_isInEscrow)
            {
                if (receivedByte == _protocolConfig.AckByte)
                {
                    LogMessage($"✅ Auto: Accept (0x{_protocolConfig.AckByte:X2}) → Sending Stacked (0x{_protocolConfig.StackedByte:X2})");
                    await Task.Delay(500);
                    await SendByteAsync(_protocolConfig.StackedByte);
                    _isInEscrow = false;
                }
                else if (receivedByte == _protocolConfig.RejectByte)
                {
                    LogMessage($"❌ Auto: Reject (0x{_protocolConfig.RejectByte:X2}) → Sending Rejected (0x{_protocolConfig.RejectedByte:X2})");
                    await Task.Delay(500);
                    await SendByteAsync(_protocolConfig.RejectedByte);
                    _isInEscrow = false;
                }
            }
        }
        catch (Exception ex)
        {
            LogMessage($"⚠️ Auto-reply error: {ex.Message}");
        }
    }

    private async Task SimulateBillInsert()
    {
        if (!_isEnabled) return;

        LogMessage("💵 Auto: Simulating bill insert...");
        await SendByteAsync(_protocolConfig.EscrowStartByte);
        await Task.Delay(100);

        var billTypes = _protocolConfig.BillTypeMapping.Keys.ToArray();
        var random = new Random();
        var billType = billTypes[random.Next(billTypes.Length)];

        await SendByteAsync(billType);
        _isInEscrow = true;

        var amount = _protocolConfig.BillTypeMapping[billType];
        LogMessage($"💵 Auto: Bill in escrow: {amount:N0} VND (0x{billType:X2})");
    }

    private void ChkAutoReply_CheckedChanged(object sender, EventArgs e)
    {
        _autoReply = chkAutoReply.Checked;
        LogMessage($"Auto-reply: {(_autoReply ? "ENABLED" : "DISABLED")}");
    }

    private async void BtnSendReady_Click(object sender, EventArgs e)
    {
        await SendByteAsync(_protocolConfig.PowerUpByte);
        await Task.Delay(100);
        await SendByteAsync(_protocolConfig.PowerUpResponseByte);
    }

    private async void BtnSendInsert_Click(object sender, EventArgs e)
    {
        await SendByteAsync(_protocolConfig.EscrowStartByte);
    }

    private async void BtnSendStacked_Click(object sender, EventArgs e)
    {
        await SendByteAsync(_protocolConfig.StackedByte);
    }

    private async void BtnSendRejected_Click(object sender, EventArgs e)
    {
        await SendByteAsync(_protocolConfig.RejectedByte);
    }

    private async Task SendByteAsync(byte data)
    {
        if (_serialPort?.IsOpen != true) return;

        await _serialPort.BaseStream.WriteAsync(new[] { data }, 0, 1);
        await _serialPort.BaseStream.FlushAsync();
        LogMessage($">> Send: 0x{data:X2} ({GetByteDescription(data)})");
    }

    private string GetByteDescription(byte data)
    {
        if (data == _protocolConfig.PowerUpByte) return $"PowerUp (0x{data:X2})";
        if (data == _protocolConfig.PowerUpResponseByte) return $"PowerUp Response (0x{data:X2})";
        if (data == _protocolConfig.AckByte) return $"ACK/Accept (0x{data:X2})";
        if (data == _protocolConfig.EnableByte) return $"Enable (0x{data:X2})";
        if (data == _protocolConfig.DisableByte) return $"Disable (0x{data:X2})";
        if (data == _protocolConfig.EscrowStartByte) return $"Escrow Start (0x{data:X2})";
        if (data == _protocolConfig.RejectByte) return $"Reject (0x{data:X2})";
        if (data == _protocolConfig.StackedByte) return $"Stacked (0x{data:X2})";
        if (data == _protocolConfig.RejectedByte) return $"Rejected (0x{data:X2})";
        if (data == _protocolConfig.ResetByte) return $"Reset (0x{data:X2})";

        if (_protocolConfig.BillTypeMapping.TryGetValue(data, out var amount))
            return $"Bill: {amount:N0} VND";

        return $"Unknown (0x{data:X2})";
    }

    private void LogMessage(string message)
    {
        var timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        var logLine = $"[{timestamp}] {message}";

        if (InvokeRequired)
        {
            BeginInvoke(() => txtLog.AppendText(logLine + Environment.NewLine));
        }
        else
        {
            txtLog.AppendText(logLine + Environment.NewLine);
        }
    }

    private void BtnClearLog_Click(object sender, EventArgs e)
    {
        txtLog.Clear();
    }
}
