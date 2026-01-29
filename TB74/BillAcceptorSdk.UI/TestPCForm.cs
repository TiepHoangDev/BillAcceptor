using BillAcceptorSdk;

namespace BillAcceptorSdk.UI;

public partial class TestPCForm : Form
{
    private CancellationTokenSource? _paymentCts;
    private long _currentTotal = 0;

    public TestPCForm()
    {
        InitializeComponent();
        Load += TestPCForm_Load;
    }

    private void TestPCForm_Load(object? sender, EventArgs e)
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        var ports = System.IO.Ports.SerialPort.GetPortNames().Distinct().ToArray();
        cmbBillComPort.Items.AddRange(ports);
        cmbPowerComPort.Items.AddRange(ports);
        
        if (cmbBillComPort.Items.Count > 0)
            cmbBillComPort.SelectedIndex = 0;
        
        if (cmbPowerComPort.Items.Count > 0)
            cmbPowerComPort.SelectedIndex = cmbPowerComPort.Items.Count > 1 ? 1 : 0;

        numTargetAmount.Value = 70000;

        ShowSettingsPanel();
    }

    private void ShowSettingsPanel()
    {
        panelSettings.Visible = true;
        panelPayment.Visible = false;
    }

    private void ShowPaymentPanel()
    {
        panelSettings.Visible = false;
        panelPayment.Visible = true;
        txtLog.Clear();
        _currentTotal = 0;
        UpdatePaymentStatus();
        btnCancel.Visible = true;
        btnBack.Visible = false;
    }

    private void UpdatePaymentStatus()
    {
        if (InvokeRequired)
        {
            BeginInvoke(UpdatePaymentStatus);
            return;
        }

        lblCurrentAmount.Text = $"Received: {_currentTotal:N0} VND";
        lblTargetAmount.Text = $"Target: {numTargetAmount.Value:N0} VND";

        var progress = _currentTotal * 100 / (long)numTargetAmount.Value;
        lblProgress.Text = $"Progress: {progress}%";
    }

    private void BtnStart_Click(object sender, EventArgs e)
    {
        StartPaymentAsync();
    }

    private async void StartPaymentAsync()
    {
        try
        {
            var targetAmount = (long)numTargetAmount.Value;
            var billComPort = cmbBillComPort.Text;
            var powerComPort = cmbPowerComPort.Text;

            if (string.IsNullOrEmpty(billComPort) || string.IsNullOrEmpty(powerComPort))
            {
                MessageBox.Show("Please select both COM ports!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ShowPaymentPanel();
            LogMessage($"=== STARTING PAYMENT SESSION ===");
            LogMessage($"Target: {targetAmount:N0} VND");
            LogMessage($"Bill COM Port: {billComPort}");
            LogMessage($"Power COM Port: {powerComPort}");

            _paymentCts = new CancellationTokenSource();

            var config = new BillAcceptorConfig
            {
                BillTranportCom = billComPort,
                PowerTranportCom = powerComPort,
                TotalAmount = targetAmount,
                Log = msg => LogMessage(msg)
            };

            var controller = new BillAcceptorController(config);
            controller.OnLog += (sender, msg) => LogMessage(msg);
            controller.OnAmountChange += (sender, amount) =>
            {
                _currentTotal = amount;
                UpdatePaymentStatus();
                LogMessage($"✅ Amount updated: {amount:N0} VND");
            };

            var result = await controller.WaitAmountAsync(_paymentCts.Token);

            LogMessage($"\n=== ✅ PAYMENT SUCCESS ===");
            LogMessage($"Target: {targetAmount:N0} VND");
            LogMessage($"Received: {result:N0} VND");
            LogMessage($"COM Port closed\n");

            MessageBox.Show($"Payment completed!\n\nTarget: {targetAmount:N0} VND\nReceived: {result:N0} VND",
                "Payment Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (OperationCanceledException)
        {
            LogMessage($"\n=== ⚠️ PAYMENT CANCELLED ===");
            LogMessage($"Total received: {_currentTotal:N0} VND\n");
            MessageBox.Show($"Payment cancelled\n\nTotal received: {_currentTotal:N0} VND",
                "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            LogMessage($"\n=== ❌ PAYMENT FAILED ===");
            LogMessage($"Error: {ex.Message}\n");
            MessageBox.Show($"Payment failed!\n\nError: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _paymentCts?.Dispose();
            _paymentCts = null;
            btnCancel.Visible = false;
            btnBack.Visible = true;
        }
    }

    private void BtnCancel_Click(object sender, EventArgs e)
    {
        if (_paymentCts != null)
        {
            _paymentCts.Cancel();
            LogMessage("⚠️ Cancelling payment...");
        }
    }

    private void BtnBack_Click(object sender, EventArgs e)
    {
        if (_paymentCts != null)
        {
            MessageBox.Show("Please stop the payment first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        ShowSettingsPanel();
    }

    private void BtnOpenFake_Click(object sender, EventArgs e)
    {
        new FakeBillAcceptorForm().Show();
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
}
