namespace BillAcceptorSdk.UI
{
    partial class FakeBillAcceptorForm
    {
        private System.ComponentModel.IContainer components = null;
        
        private Panel panelSettings;
        private Panel panelRunning;
        private GroupBox grpSettings;
        private ComboBox cmbComPort;
        private CheckBox chkAutoReply;
        private Label lblComPort;
        private Button btnStart;
        private TextBox txtLog;
        private Button btnStop;
        private Button btnBack;
        private Button btnSendReady;
        private Button btnSendInsert;
        private Button btnSendStacked;
        private Button btnSendRejected;
        private GroupBox grpManual;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelSettings = new Panel();
            grpSettings = new GroupBox();
            lblComPort = new Label();
            cmbComPort = new ComboBox();
            chkAutoReply = new CheckBox();
            btnStart = new Button();
            panelRunning = new Panel();
            grpManual = new GroupBox();
            btnSendReady = new Button();
            btnSendInsert = new Button();
            btnSendStacked = new Button();
            btnSendRejected = new Button();
            txtLog = new TextBox();
            btnStop = new Button();
            btnBack = new Button();
            panelSettings.SuspendLayout();
            grpSettings.SuspendLayout();
            panelRunning.SuspendLayout();
            grpManual.SuspendLayout();
            SuspendLayout();
            // 
            // panelSettings
            // 
            panelSettings.Controls.Add(grpSettings);
            panelSettings.Controls.Add(btnStart);
            panelSettings.Dock = DockStyle.Fill;
            panelSettings.Location = new Point(0, 0);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(800, 600);
            panelSettings.TabIndex = 0;
            // 
            // grpSettings
            // 
            grpSettings.Controls.Add(lblComPort);
            grpSettings.Controls.Add(cmbComPort);
            grpSettings.Controls.Add(chkAutoReply);
            grpSettings.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpSettings.Location = new Point(20, 20);
            grpSettings.Name = "grpSettings";
            grpSettings.Size = new Size(760, 150);
            grpSettings.TabIndex = 0;
            grpSettings.TabStop = false;
            grpSettings.Text = "Settings";
            // 
            // lblComPort
            // 
            lblComPort.AutoSize = true;
            lblComPort.Font = new Font("Segoe UI", 10F);
            lblComPort.Location = new Point(20, 35);
            lblComPort.Name = "lblComPort";
            lblComPort.Size = new Size(74, 19);
            lblComPort.TabIndex = 0;
            lblComPort.Text = "COM Port:";
            // 
            // cmbComPort
            // 
            cmbComPort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbComPort.Font = new Font("Segoe UI", 10F);
            cmbComPort.FormattingEnabled = true;
            cmbComPort.Location = new Point(110, 32);
            cmbComPort.Name = "cmbComPort";
            cmbComPort.Size = new Size(150, 25);
            cmbComPort.TabIndex = 1;
            // 
            // chkAutoReply
            // 
            chkAutoReply.AutoSize = true;
            chkAutoReply.Font = new Font("Segoe UI", 10F);
            chkAutoReply.Location = new Point(20, 90);
            chkAutoReply.Name = "chkAutoReply";
            chkAutoReply.Size = new Size(207, 23);
            chkAutoReply.TabIndex = 2;
            chkAutoReply.Text = "Auto Reply to PC Commands";
            chkAutoReply.UseVisualStyleBackColor = true;
            chkAutoReply.CheckedChanged += ChkAutoReply_CheckedChanged;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(0, 192, 0);
            btnStart.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(20, 190);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(760, 80);
            btnStart.TabIndex = 1;
            btnStart.Text = "START FAKE DEVICE";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += BtnStart_Click;
            // 
            // panelRunning
            // 
            panelRunning.Controls.Add(grpManual);
            panelRunning.Controls.Add(txtLog);
            panelRunning.Controls.Add(btnStop);
            panelRunning.Controls.Add(btnBack);
            panelRunning.Dock = DockStyle.Fill;
            panelRunning.Location = new Point(0, 0);
            panelRunning.Name = "panelRunning";
            panelRunning.Size = new Size(800, 600);
            panelRunning.TabIndex = 1;
            panelRunning.Visible = false;
            // 
            // grpManual
            // 
            grpManual.Controls.Add(btnSendReady);
            grpManual.Controls.Add(btnSendInsert);
            grpManual.Controls.Add(btnSendStacked);
            grpManual.Controls.Add(btnSendRejected);
            grpManual.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpManual.Location = new Point(20, 20);
            grpManual.Name = "grpManual";
            grpManual.Size = new Size(754, 150);
            grpManual.TabIndex = 0;
            grpManual.TabStop = false;
            grpManual.Text = "Manual Commands";
            // 
            // btnSendReady
            // 
            btnSendReady.Font = new Font("Segoe UI", 9F);
            btnSendReady.Location = new Point(20, 35);
            btnSendReady.Name = "btnSendReady";
            btnSendReady.Size = new Size(110, 40);
            btnSendReady.TabIndex = 0;
            btnSendReady.Text = "PowerUp\n(0x80 0x8F)";
            btnSendReady.UseVisualStyleBackColor = true;
            btnSendReady.Click += BtnSendReady_Click;
            // 
            // btnSendInsert
            // 
            btnSendInsert.Font = new Font("Segoe UI", 9F);
            btnSendInsert.Location = new Point(140, 35);
            btnSendInsert.Name = "btnSendInsert";
            btnSendInsert.Size = new Size(110, 40);
            btnSendInsert.TabIndex = 1;
            btnSendInsert.Text = "INSERT (0x81)";
            btnSendInsert.UseVisualStyleBackColor = true;
            btnSendInsert.Click += BtnSendInsert_Click;
            // 
            // btnSendStacked
            // 
            btnSendStacked.BackColor = Color.FromArgb(0, 192, 0);
            btnSendStacked.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSendStacked.ForeColor = Color.White;
            btnSendStacked.Location = new Point(380, 35);
            btnSendStacked.Name = "btnSendStacked";
            btnSendStacked.Size = new Size(110, 40);
            btnSendStacked.TabIndex = 9;
            btnSendStacked.Text = "STACKED\n(0x10)";
            btnSendStacked.UseVisualStyleBackColor = false;
            btnSendStacked.Click += BtnSendStacked_Click;
            // 
            // btnSendRejected
            // 
            btnSendRejected.BackColor = Color.FromArgb(192, 0, 0);
            btnSendRejected.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSendRejected.ForeColor = Color.White;
            btnSendRejected.Location = new Point(500, 35);
            btnSendRejected.Name = "btnSendRejected";
            btnSendRejected.Size = new Size(110, 40);
            btnSendRejected.TabIndex = 10;
            btnSendRejected.Text = "REJECTED\n(0x11)";
            btnSendRejected.UseVisualStyleBackColor = false;
            btnSendRejected.Click += BtnSendRejected_Click;
            // 
            // txtLog
            // 
            txtLog.Font = new Font("Consolas", 9F);
            txtLog.Location = new Point(20, 190);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Both;
            txtLog.Size = new Size(760, 320);
            txtLog.TabIndex = 1;
            txtLog.WordWrap = false;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.FromArgb(192, 0, 0);
            btnStop.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(20, 530);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(370, 50);
            btnStop.TabIndex = 2;
            btnStop.Text = "STOP DEVICE";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += BtnStop_Click;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBack.Location = new Point(410, 530);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(370, 50);
            btnBack.TabIndex = 3;
            btnBack.Text = "BACK TO SETTINGS";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += BtnBack_Click;
            // 
            // FakeBillAcceptorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(panelRunning);
            Controls.Add(panelSettings);
            Name = "FakeBillAcceptorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fake Bill Acceptor";
            panelSettings.ResumeLayout(false);
            grpSettings.ResumeLayout(false);
            grpSettings.PerformLayout();
            panelRunning.ResumeLayout(false);
            panelRunning.PerformLayout();
            grpManual.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
