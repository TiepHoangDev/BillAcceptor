using System.IO.Ports;
using BillAcceptorSdk.Models;

namespace BillAcceptorSdk.UI
{
    public partial class Form1 : Form
    {
        private IBillAcceptorController? _billAcceptor;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComPorts();
            LogMessage("Application started", Color.Cyan);
            LogMessage("Ready to connect to TB74 Bill Acceptor", Color.White);
        }

        private void LoadComPorts()
        {
            cmbComPorts.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            
            if (ports.Length == 0)
            {
                LogMessage("No COM ports found", Color.Yellow);
                return;
            }

            foreach (string port in ports)
            {
                cmbComPorts.Items.Add(port);
            }

            if (cmbComPorts.Items.Count > 0)
            {
                cmbComPorts.SelectedIndex = 0;
            }

            LogMessage($"Found {ports.Length} COM port(s)", Color.Cyan);
        }

        private void btnRefreshPorts_Click(object sender, EventArgs e)
        {
            LoadComPorts();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (cmbComPorts.SelectedItem == null)
            {
                MessageBox.Show("Please select a COM port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string portName = cmbComPorts.SelectedItem.ToString()!;

            try
            {
                btnConnect.Enabled = false;
                LogMessage($"Connecting to {portName}...", Color.Yellow);

                _billAcceptor = new TB74BillAcceptor();
                _billAcceptor.BillReceived += BillAcceptor_BillReceived;
                _billAcceptor.ErrorOccurred += BillAcceptor_ErrorOccurred;

                await _billAcceptor.ConnectAsync(portName);

                UpdateConnectionStatus(true);
                LogMessage($"Connected to {portName} successfully", Color.Green);
                LogMessage("Waiting for bills...", Color.White);
            }
            catch (Exception ex)
            {
                LogMessage($"Connection failed: {ex.Message}", Color.Red);
                MessageBox.Show($"Failed to connect: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                if (_billAcceptor != null)
                {
                    _billAcceptor.BillReceived -= BillAcceptor_BillReceived;
                    _billAcceptor.ErrorOccurred -= BillAcceptor_ErrorOccurred;
                    _billAcceptor.Dispose();
                    _billAcceptor = null;
                }
                
                btnConnect.Enabled = true;
            }
        }

        private async void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (_billAcceptor == null)
            {
                return;
            }

            try
            {
                btnDisconnect.Enabled = false;
                LogMessage("Disconnecting...", Color.Yellow);

                _billAcceptor.BillReceived -= BillAcceptor_BillReceived;
                _billAcceptor.ErrorOccurred -= BillAcceptor_ErrorOccurred;

                await _billAcceptor.DisconnectAsync();
                _billAcceptor.Dispose();
                _billAcceptor = null;

                UpdateConnectionStatus(false);
                LogMessage("Disconnected successfully", Color.Orange);
            }
            catch (Exception ex)
            {
                LogMessage($"Disconnect error: {ex.Message}", Color.Red);
                MessageBox.Show($"Disconnect error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDisconnect.Enabled = true;
            }
        }

        private void btnResetTotal_Click(object sender, EventArgs e)
        {
            if (_billAcceptor == null)
            {
                MessageBox.Show("Not connected to device", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to reset the total amount to 0?", 
                "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _billAcceptor.ResetTotal();
                UpdateTotalAmount(0);
                LogMessage("Total amount reset to 0", Color.Cyan);
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            LogMessage("Log cleared", Color.Cyan);
        }

        private void BillAcceptor_BillReceived(object? sender, BillReceivedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => BillAcceptor_BillReceived(sender, e)));
                return;
            }

            string denominationText = e.Denomination switch
            {
                BillDenomination.VND_5000 => "5,000 VND",
                BillDenomination.VND_10000 => "10,000 VND",
                BillDenomination.VND_20000 => "20,000 VND",
                BillDenomination.VND_50000 => "50,000 VND",
                BillDenomination.VND_100000 => "100,000 VND",
                BillDenomination.VND_200000 => "200,000 VND",
                BillDenomination.VND_500000 => "500,000 VND",
                _ => "Unknown"
            };

            LogMessage($"[BILL RECEIVED] {denominationText} | Total: {e.TotalAmount:N0} VND", Color.Lime);
            UpdateTotalAmount(e.TotalAmount);
        }

        private void BillAcceptor_ErrorOccurred(object? sender, string e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => BillAcceptor_ErrorOccurred(sender, e)));
                return;
            }

            LogMessage($"[ERROR] {e}", Color.Red);
        }

        private void UpdateConnectionStatus(bool connected)
        {
            if (connected)
            {
                lblConnectionValue.Text = "Connected";
                lblConnectionValue.ForeColor = Color.Green;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                cmbComPorts.Enabled = false;
                btnRefreshPorts.Enabled = false;
            }
            else
            {
                lblConnectionValue.Text = "Disconnected";
                lblConnectionValue.ForeColor = Color.Red;
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                cmbComPorts.Enabled = true;
                btnRefreshPorts.Enabled = true;
            }
        }

        private void UpdateTotalAmount(int amount)
        {
            lblTotalValue.Text = $"{amount:N0} VND";
        }

        private void LogMessage(string message, Color color)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string logEntry = $"[{timestamp}] {message}";

            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() => LogMessage(message, color)));
                return;
            }

            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.SelectionLength = 0;
            txtLog.SelectionColor = color;
            txtLog.AppendText(logEntry + Environment.NewLine);
            txtLog.SelectionColor = txtLog.ForeColor;
            txtLog.ScrollToCaret();
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_billAcceptor != null && _billAcceptor.IsConnected)
            {
                try
                {
                    await _billAcceptor.DisconnectAsync();
                    _billAcceptor.Dispose();
                }
                catch
                {
                }
            }
        }
    }
}
