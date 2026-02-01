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
            this.panelSettings = new System.Windows.Forms.Panel();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.lblComPort = new System.Windows.Forms.Label();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.chkAutoReply = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.panelRunning = new System.Windows.Forms.Panel();
            this.grpManual = new System.Windows.Forms.GroupBox();
            this.btnSendReady = new System.Windows.Forms.Button();
            this.btnSendInsert = new System.Windows.Forms.Button();
            this.btnSendStacked = new System.Windows.Forms.Button();
            this.btnSendRejected = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panelSettings.SuspendLayout();
            this.grpSettings.SuspendLayout();
            this.panelRunning.SuspendLayout();
            this.grpManual.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.grpSettings);
            this.panelSettings.Controls.Add(this.btnStart);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettings.Location = new System.Drawing.Point(0, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(800, 520);
            this.panelSettings.TabIndex = 0;
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.lblComPort);
            this.grpSettings.Controls.Add(this.cmbComPort);
            this.grpSettings.Controls.Add(this.chkAutoReply);
            this.grpSettings.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpSettings.Location = new System.Drawing.Point(17, 17);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(771, 130);
            this.grpSettings.TabIndex = 0;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblComPort.Location = new System.Drawing.Point(17, 30);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(74, 19);
            this.lblComPort.TabIndex = 0;
            this.lblComPort.Text = "COM Port:";
            // 
            // cmbComPort
            // 
            this.cmbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComPort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(94, 28);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(129, 25);
            this.cmbComPort.TabIndex = 1;
            // 
            // chkAutoReply
            // 
            this.chkAutoReply.AutoSize = true;
            this.chkAutoReply.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkAutoReply.Location = new System.Drawing.Point(17, 78);
            this.chkAutoReply.Name = "chkAutoReply";
            this.chkAutoReply.Size = new System.Drawing.Size(207, 23);
            this.chkAutoReply.TabIndex = 2;
            this.chkAutoReply.Text = "Auto Reply to PC Commands";
            this.chkAutoReply.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(17, 165);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(771, 69);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "START FAKE DEVICE";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // panelRunning
            // 
            this.panelRunning.Controls.Add(this.grpManual);
            this.panelRunning.Controls.Add(this.txtLog);
            this.panelRunning.Controls.Add(this.btnStop);
            this.panelRunning.Controls.Add(this.btnBack);
            this.panelRunning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRunning.Location = new System.Drawing.Point(0, 0);
            this.panelRunning.Name = "panelRunning";
            this.panelRunning.Size = new System.Drawing.Size(800, 520);
            this.panelRunning.TabIndex = 1;
            this.panelRunning.Visible = false;
            // 
            // grpManual
            // 
            this.grpManual.Controls.Add(this.btnSendReady);
            this.grpManual.Controls.Add(this.btnSendInsert);
            this.grpManual.Controls.Add(this.btnSendStacked);
            this.grpManual.Controls.Add(this.btnSendRejected);
            this.grpManual.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpManual.Location = new System.Drawing.Point(17, 17);
            this.grpManual.Name = "grpManual";
            this.grpManual.Size = new System.Drawing.Size(771, 130);
            this.grpManual.TabIndex = 0;
            this.grpManual.TabStop = false;
            this.grpManual.Text = "Manual Commands";
            // 
            // btnSendReady
            // 
            this.btnSendReady.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendReady.Location = new System.Drawing.Point(17, 30);
            this.btnSendReady.Name = "btnSendReady";
            this.btnSendReady.Size = new System.Drawing.Size(147, 35);
            this.btnSendReady.TabIndex = 0;
            this.btnSendReady.Text = "PowerUp (0x80 0x8F)";
            this.btnSendReady.UseVisualStyleBackColor = true;
            this.btnSendReady.Click += new System.EventHandler(this.BtnSendReady_Click);
            // 
            // btnSendInsert
            // 
            this.btnSendInsert.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendInsert.Location = new System.Drawing.Point(170, 30);
            this.btnSendInsert.Name = "btnSendInsert";
            this.btnSendInsert.Size = new System.Drawing.Size(147, 35);
            this.btnSendInsert.TabIndex = 1;
            this.btnSendInsert.Text = "INSERT (0x81)";
            this.btnSendInsert.UseVisualStyleBackColor = true;
            this.btnSendInsert.Click += new System.EventHandler(this.BtnSendInsert_Click);
            // 
            // btnSendStacked
            // 
            this.btnSendStacked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSendStacked.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSendStacked.ForeColor = System.Drawing.Color.White;
            this.btnSendStacked.Location = new System.Drawing.Point(464, 30);
            this.btnSendStacked.Name = "btnSendStacked";
            this.btnSendStacked.Size = new System.Drawing.Size(147, 35);
            this.btnSendStacked.TabIndex = 9;
            this.btnSendStacked.Text = "STACKED (0x10)";
            this.btnSendStacked.UseVisualStyleBackColor = false;
            this.btnSendStacked.Click += new System.EventHandler(this.BtnSendStacked_Click);
            // 
            // btnSendRejected
            // 
            this.btnSendRejected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSendRejected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSendRejected.ForeColor = System.Drawing.Color.White;
            this.btnSendRejected.Location = new System.Drawing.Point(617, 30);
            this.btnSendRejected.Name = "btnSendRejected";
            this.btnSendRejected.Size = new System.Drawing.Size(147, 35);
            this.btnSendRejected.TabIndex = 10;
            this.btnSendRejected.Text = "REJECTED (0x11)";
            this.btnSendRejected.UseVisualStyleBackColor = false;
            this.btnSendRejected.Click += new System.EventHandler(this.BtnSendRejected_Click);
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtLog.Location = new System.Drawing.Point(17, 165);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(771, 278);
            this.txtLog.TabIndex = 1;
            this.txtLog.WordWrap = false;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(17, 459);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(317, 43);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "STOP DEVICE";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.Location = new System.Drawing.Point(471, 459);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(317, 43);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "BACK TO SETTINGS";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // FakeBillAcceptorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.panelRunning);
            this.Name = "FakeBillAcceptorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fake Bill Acceptor - tiephoang.dev@gmail.com - 0974.131.292";
            this.panelSettings.ResumeLayout(false);
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.panelRunning.ResumeLayout(false);
            this.panelRunning.PerformLayout();
            this.grpManual.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
