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
            this.panelSettings = new System.Windows.Forms.Panel();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.lblBillComPort = new System.Windows.Forms.Label();
            this.cmbBillComPort = new System.Windows.Forms.ComboBox();
            this.lblPowerComPort = new System.Windows.Forms.Label();
            this.cmbPowerComPort = new System.Windows.Forms.ComboBox();
            this.lblTargetAmountLabel = new System.Windows.Forms.Label();
            this.numTargetAmount = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnOpenFake = new System.Windows.Forms.Button();
            this.panelPayment = new System.Windows.Forms.Panel();
            this.lblCurrentAmount = new System.Windows.Forms.Label();
            this.lblTargetAmount = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panelSettings.SuspendLayout();
            this.grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetAmount)).BeginInit();
            this.panelPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.grpSettings);
            this.panelSettings.Controls.Add(this.btnStart);
            this.panelSettings.Controls.Add(this.btnOpenFake);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettings.Location = new System.Drawing.Point(0, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(686, 520);
            this.panelSettings.TabIndex = 0;
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.lblBillComPort);
            this.grpSettings.Controls.Add(this.cmbBillComPort);
            this.grpSettings.Controls.Add(this.lblPowerComPort);
            this.grpSettings.Controls.Add(this.cmbPowerComPort);
            this.grpSettings.Controls.Add(this.lblTargetAmountLabel);
            this.grpSettings.Controls.Add(this.numTargetAmount);
            this.grpSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpSettings.Location = new System.Drawing.Point(17, 17);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(651, 191);
            this.grpSettings.TabIndex = 0;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Payment Settings";
            // 
            // lblBillComPort
            // 
            this.lblBillComPort.AutoSize = true;
            this.lblBillComPort.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblBillComPort.Location = new System.Drawing.Point(17, 35);
            this.lblBillComPort.Name = "lblBillComPort";
            this.lblBillComPort.Size = new System.Drawing.Size(100, 20);
            this.lblBillComPort.TabIndex = 0;
            this.lblBillComPort.Text = "Bill COM Port:";
            // 
            // cmbBillComPort
            // 
            this.cmbBillComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBillComPort.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbBillComPort.FormattingEnabled = true;
            this.cmbBillComPort.Location = new System.Drawing.Point(129, 32);
            this.cmbBillComPort.Name = "cmbBillComPort";
            this.cmbBillComPort.Size = new System.Drawing.Size(172, 28);
            this.cmbBillComPort.TabIndex = 1;
            // 
            // lblPowerComPort
            // 
            this.lblPowerComPort.AutoSize = true;
            this.lblPowerComPort.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPowerComPort.Location = new System.Drawing.Point(17, 69);
            this.lblPowerComPort.Name = "lblPowerComPort";
            this.lblPowerComPort.Size = new System.Drawing.Size(89, 20);
            this.lblPowerComPort.TabIndex = 2;
            this.lblPowerComPort.Text = "Power COM:";
            // 
            // cmbPowerComPort
            // 
            this.cmbPowerComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPowerComPort.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbPowerComPort.FormattingEnabled = true;
            this.cmbPowerComPort.Location = new System.Drawing.Point(129, 67);
            this.cmbPowerComPort.Name = "cmbPowerComPort";
            this.cmbPowerComPort.Size = new System.Drawing.Size(172, 28);
            this.cmbPowerComPort.TabIndex = 3;
            // 
            // lblTargetAmountLabel
            // 
            this.lblTargetAmountLabel.AutoSize = true;
            this.lblTargetAmountLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTargetAmountLabel.Location = new System.Drawing.Point(17, 104);
            this.lblTargetAmountLabel.Name = "lblTargetAmountLabel";
            this.lblTargetAmountLabel.Size = new System.Drawing.Size(110, 20);
            this.lblTargetAmountLabel.TabIndex = 4;
            this.lblTargetAmountLabel.Text = "Target Amount:";
            // 
            // numTargetAmount
            // 
            this.numTargetAmount.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numTargetAmount.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTargetAmount.Location = new System.Drawing.Point(129, 101);
            this.numTargetAmount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numTargetAmount.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTargetAmount.Name = "numTargetAmount";
            this.numTargetAmount.Size = new System.Drawing.Size(171, 27);
            this.numTargetAmount.TabIndex = 5;
            this.numTargetAmount.ThousandsSeparator = true;
            this.numTargetAmount.Value = new decimal(new int[] {
            70000,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(17, 225);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(651, 69);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "START PAYMENT";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnOpenFake
            // 
            this.btnOpenFake.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnOpenFake.Location = new System.Drawing.Point(17, 312);
            this.btnOpenFake.Name = "btnOpenFake";
            this.btnOpenFake.Size = new System.Drawing.Size(171, 35);
            this.btnOpenFake.TabIndex = 7;
            this.btnOpenFake.Text = "Open Fake Bill Acceptor";
            this.btnOpenFake.UseVisualStyleBackColor = true;
            this.btnOpenFake.Click += new System.EventHandler(this.BtnOpenFake_Click);
            // 
            // panelPayment
            // 
            this.panelPayment.Controls.Add(this.lblCurrentAmount);
            this.panelPayment.Controls.Add(this.lblTargetAmount);
            this.panelPayment.Controls.Add(this.lblProgress);
            this.panelPayment.Controls.Add(this.txtLog);
            this.panelPayment.Controls.Add(this.btnCancel);
            this.panelPayment.Controls.Add(this.btnBack);
            this.panelPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPayment.Location = new System.Drawing.Point(0, 0);
            this.panelPayment.Name = "panelPayment";
            this.panelPayment.Size = new System.Drawing.Size(686, 520);
            this.panelPayment.TabIndex = 1;
            this.panelPayment.Visible = false;
            // 
            // lblCurrentAmount
            // 
            this.lblCurrentAmount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCurrentAmount.ForeColor = System.Drawing.Color.Green;
            this.lblCurrentAmount.Location = new System.Drawing.Point(17, 17);
            this.lblCurrentAmount.Name = "lblCurrentAmount";
            this.lblCurrentAmount.Size = new System.Drawing.Size(651, 35);
            this.lblCurrentAmount.TabIndex = 0;
            this.lblCurrentAmount.Text = "Received: 0 VND";
            this.lblCurrentAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetAmount
            // 
            this.lblTargetAmount.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTargetAmount.Location = new System.Drawing.Point(17, 56);
            this.lblTargetAmount.Name = "lblTargetAmount";
            this.lblTargetAmount.Size = new System.Drawing.Size(651, 26);
            this.lblTargetAmount.TabIndex = 1;
            this.lblTargetAmount.Text = "Target: 70,000 VND";
            this.lblTargetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProgress
            // 
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblProgress.Location = new System.Drawing.Point(17, 87);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(651, 22);
            this.lblProgress.TabIndex = 2;
            this.lblProgress.Text = "Progress: 0%";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtLog.Location = new System.Drawing.Point(17, 121);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(652, 321);
            this.txtLog.TabIndex = 3;
            this.txtLog.WordWrap = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(17, 451);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(317, 43);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "CANCEL PAYMENT";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.Location = new System.Drawing.Point(351, 451);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(317, 43);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "BACK TO SETTINGS";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // TestPCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 520);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.panelPayment);
            this.Name = "TestPCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill Acceptor - PC Test - tiephoang.dev@gmail.com - 0974.131.292";
            this.panelSettings.ResumeLayout(false);
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetAmount)).EndInit();
            this.panelPayment.ResumeLayout(false);
            this.panelPayment.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
