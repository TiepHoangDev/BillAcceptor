namespace BillAcceptorSdk.UI
{
    partial class TestPCForm
    {
        private System.ComponentModel.IContainer components = null;
        
        private Panel panelSettings;
        private Panel panelPayment;
        private GroupBox grpSettings;
        private ComboBox cmbBillComPort;
        private ComboBox cmbPowerComPort;
        private NumericUpDown numTargetAmount;
        private Button btnStart;
        private Button btnOpenFake;
        private Label lblBillComPort;
        private Label lblPowerComPort;
        private Label lblTargetAmountLabel;
        private TextBox txtLog;
        private Label lblCurrentAmount;
        private Label lblTargetAmount;
        private Label lblProgress;
        private Button btnCancel;
        private Button btnBack;

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
            panelPayment = new Panel();
            grpSettings = new GroupBox();
            cmbBillComPort = new ComboBox();
            cmbPowerComPort = new ComboBox();
            numTargetAmount = new NumericUpDown();
            btnStart = new Button();
            btnOpenFake = new Button();
            lblBillComPort = new Label();
            lblPowerComPort = new Label();
            lblTargetAmountLabel = new Label();
            txtLog = new TextBox();
            lblCurrentAmount = new Label();
            lblTargetAmount = new Label();
            lblProgress = new Label();
            btnCancel = new Button();
            btnBack = new Button();
            
            panelSettings.SuspendLayout();
            panelPayment.SuspendLayout();
            grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTargetAmount).BeginInit();
            SuspendLayout();
            
            // panelSettings
            panelSettings.Controls.Add(grpSettings);
            panelSettings.Controls.Add(btnStart);
            panelSettings.Controls.Add(btnOpenFake);
            panelSettings.Dock = DockStyle.Fill;
            panelSettings.Location = new Point(0, 0);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(800, 600);
            panelSettings.TabIndex = 0;
            
            // grpSettings
            grpSettings.Controls.Add(lblBillComPort);
            grpSettings.Controls.Add(cmbBillComPort);
            grpSettings.Controls.Add(lblPowerComPort);
            grpSettings.Controls.Add(cmbPowerComPort);
            grpSettings.Controls.Add(lblTargetAmountLabel);
            grpSettings.Controls.Add(numTargetAmount);
            grpSettings.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpSettings.Location = new Point(20, 20);
            grpSettings.Name = "grpSettings";
            grpSettings.Size = new Size(760, 220);
            grpSettings.TabIndex = 0;
            grpSettings.TabStop = false;
            grpSettings.Text = "Payment Settings";
            
            // lblBillComPort
            lblBillComPort.AutoSize = true;
            lblBillComPort.Font = new Font("Segoe UI", 11F);
            lblBillComPort.Location = new Point(20, 40);
            lblBillComPort.Name = "lblBillComPort";
            lblBillComPort.Size = new Size(120, 20);
            lblBillComPort.TabIndex = 0;
            lblBillComPort.Text = "Bill COM Port:";
            
            // cmbBillComPort
            cmbBillComPort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBillComPort.Font = new Font("Segoe UI", 11F);
            cmbBillComPort.FormattingEnabled = true;
            cmbBillComPort.Location = new Point(150, 37);
            cmbBillComPort.Name = "cmbBillComPort";
            cmbBillComPort.Size = new Size(200, 28);
            cmbBillComPort.TabIndex = 1;
            
            // lblPowerComPort
            lblPowerComPort.AutoSize = true;
            lblPowerComPort.Font = new Font("Segoe UI", 11F);
            lblPowerComPort.Location = new Point(20, 80);
            lblPowerComPort.Name = "lblPowerComPort";
            lblPowerComPort.Size = new Size(130, 20);
            lblPowerComPort.TabIndex = 2;
            lblPowerComPort.Text = "Power COM:";
            
            // cmbPowerComPort
            cmbPowerComPort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPowerComPort.Font = new Font("Segoe UI", 11F);
            cmbPowerComPort.FormattingEnabled = true;
            cmbPowerComPort.Location = new Point(150, 77);
            cmbPowerComPort.Name = "cmbPowerComPort";
            cmbPowerComPort.Size = new Size(200, 28);
            cmbPowerComPort.TabIndex = 3;
            
            // lblTargetAmountLabel
            lblTargetAmountLabel.AutoSize = true;
            lblTargetAmountLabel.Font = new Font("Segoe UI", 11F);
            lblTargetAmountLabel.Location = new Point(20, 120);
            lblTargetAmountLabel.Name = "lblTargetAmountLabel";
            lblTargetAmountLabel.Size = new Size(120, 20);
            lblTargetAmountLabel.TabIndex = 4;
            lblTargetAmountLabel.Text = "Target Amount:";
            
            // numTargetAmount
            numTargetAmount.Font = new Font("Segoe UI", 11F);
            numTargetAmount.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            numTargetAmount.Location = new Point(150, 117);
            numTargetAmount.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numTargetAmount.Minimum = new decimal(new int[] { 10000, 0, 0, 0 });
            numTargetAmount.Name = "numTargetAmount";
            numTargetAmount.Size = new Size(200, 27);
            numTargetAmount.TabIndex = 5;
            numTargetAmount.ThousandsSeparator = true;
            numTargetAmount.Value = new decimal(new int[] { 70000, 0, 0, 0 });
            
            // btnStart
            btnStart.BackColor = Color.FromArgb(0, 192, 0);
            btnStart.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(20, 260);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(760, 80);
            btnStart.TabIndex = 6;
            btnStart.Text = "START PAYMENT";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += BtnStart_Click;
            
            // btnOpenFake
            btnOpenFake.Font = new Font("Segoe UI", 10F);
            btnOpenFake.Location = new Point(20, 360);
            btnOpenFake.Name = "btnOpenFake";
            btnOpenFake.Size = new Size(200, 40);
            btnOpenFake.TabIndex = 7;
            btnOpenFake.Text = "Open Fake Bill Acceptor";
            btnOpenFake.UseVisualStyleBackColor = true;
            btnOpenFake.Click += BtnOpenFake_Click;
            
            // panelPayment
            panelPayment.Controls.Add(lblCurrentAmount);
            panelPayment.Controls.Add(lblTargetAmount);
            panelPayment.Controls.Add(lblProgress);
            panelPayment.Controls.Add(txtLog);
            panelPayment.Controls.Add(btnCancel);
            panelPayment.Controls.Add(btnBack);
            panelPayment.Dock = DockStyle.Fill;
            panelPayment.Location = new Point(0, 0);
            panelPayment.Name = "panelPayment";
            panelPayment.Size = new Size(800, 600);
            panelPayment.TabIndex = 1;
            panelPayment.Visible = false;
            
            // lblCurrentAmount
            lblCurrentAmount.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCurrentAmount.ForeColor = Color.Green;
            lblCurrentAmount.Location = new Point(20, 20);
            lblCurrentAmount.Name = "lblCurrentAmount";
            lblCurrentAmount.Size = new Size(760, 40);
            lblCurrentAmount.TabIndex = 0;
            lblCurrentAmount.Text = "Received: 0 VND";
            lblCurrentAmount.TextAlign = ContentAlignment.MiddleCenter;
            
            // lblTargetAmount
            lblTargetAmount.Font = new Font("Segoe UI", 14F);
            lblTargetAmount.Location = new Point(20, 65);
            lblTargetAmount.Name = "lblTargetAmount";
            lblTargetAmount.Size = new Size(760, 30);
            lblTargetAmount.TabIndex = 1;
            lblTargetAmount.Text = "Target: 70,000 VND";
            lblTargetAmount.TextAlign = ContentAlignment.MiddleCenter;
            
            // lblProgress
            lblProgress.Font = new Font("Segoe UI", 12F);
            lblProgress.Location = new Point(20, 100);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(760, 25);
            lblProgress.TabIndex = 2;
            lblProgress.Text = "Progress: 0%";
            lblProgress.TextAlign = ContentAlignment.MiddleCenter;
            
            // txtLog
            txtLog.Font = new Font("Consolas", 10F);
            txtLog.Location = new Point(20, 140);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Both;
            txtLog.Size = new Size(760, 370);
            txtLog.TabIndex = 3;
            txtLog.WordWrap = false;
            
            // btnCancel
            btnCancel.BackColor = Color.FromArgb(192, 0, 0);
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(20, 520);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(370, 50);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "CANCEL PAYMENT";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            
            // btnBack
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBack.Location = new Point(410, 520);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(370, 50);
            btnBack.TabIndex = 5;
            btnBack.Text = "BACK TO SETTINGS";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += BtnBack_Click;
            
            // TestPCForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(panelPayment);
            Controls.Add(panelSettings);
            Name = "TestPCForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bill Acceptor - PC Test";
            
            panelSettings.ResumeLayout(false);
            panelPayment.ResumeLayout(false);
            panelPayment.PerformLayout();
            grpSettings.ResumeLayout(false);
            grpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTargetAmount).EndInit();
            ResumeLayout(false);
        }
    }
}
