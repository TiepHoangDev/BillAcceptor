namespace BillAcceptorSdk.UI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpConnection = new GroupBox();
            btnRefreshPorts = new Button();
            btnDisconnect = new Button();
            btnConnect = new Button();
            cmbComPorts = new ComboBox();
            lblComPort = new Label();
            grpStatus = new GroupBox();
            lblTotalValue = new Label();
            lblTotal = new Label();
            lblConnectionValue = new Label();
            lblConnection = new Label();
            grpActions = new GroupBox();
            btnResetTotal = new Button();
            btnClearLog = new Button();
            grpLog = new GroupBox();
            txtLog = new RichTextBox();
            grpInstructions = new GroupBox();
            lblInstructions = new Label();
            grpConnection.SuspendLayout();
            grpStatus.SuspendLayout();
            grpActions.SuspendLayout();
            grpLog.SuspendLayout();
            grpInstructions.SuspendLayout();
            SuspendLayout();
            // 
            // grpConnection
            // 
            grpConnection.Controls.Add(btnRefreshPorts);
            grpConnection.Controls.Add(btnDisconnect);
            grpConnection.Controls.Add(btnConnect);
            grpConnection.Controls.Add(cmbComPorts);
            grpConnection.Controls.Add(lblComPort);
            grpConnection.Location = new Point(10, 9);
            grpConnection.Margin = new Padding(3, 2, 3, 2);
            grpConnection.Name = "grpConnection";
            grpConnection.Padding = new Padding(3, 2, 3, 2);
            grpConnection.Size = new Size(332, 90);
            grpConnection.TabIndex = 0;
            grpConnection.TabStop = false;
            grpConnection.Text = "Connection";
            // 
            // btnRefreshPorts
            // 
            btnRefreshPorts.Location = new Point(245, 22);
            btnRefreshPorts.Margin = new Padding(3, 2, 3, 2);
            btnRefreshPorts.Name = "btnRefreshPorts";
            btnRefreshPorts.Size = new Size(70, 23);
            btnRefreshPorts.TabIndex = 4;
            btnRefreshPorts.Text = "Refresh";
            btnRefreshPorts.UseVisualStyleBackColor = true;
            btnRefreshPorts.Click += btnRefreshPorts_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Enabled = false;
            btnDisconnect.Location = new Point(175, 56);
            btnDisconnect.Margin = new Padding(3, 2, 3, 2);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(140, 26);
            btnDisconnect.TabIndex = 3;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(18, 56);
            btnConnect.Margin = new Padding(3, 2, 3, 2);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(140, 26);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // cmbComPorts
            // 
            cmbComPorts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbComPorts.FormattingEnabled = true;
            cmbComPorts.Location = new Point(79, 22);
            cmbComPorts.Margin = new Padding(3, 2, 3, 2);
            cmbComPorts.Name = "cmbComPorts";
            cmbComPorts.Size = new Size(158, 23);
            cmbComPorts.TabIndex = 1;
            // 
            // lblComPort
            // 
            lblComPort.AutoSize = true;
            lblComPort.Location = new Point(13, 26);
            lblComPort.Name = "lblComPort";
            lblComPort.Size = new Size(63, 15);
            lblComPort.TabIndex = 0;
            lblComPort.Text = "COM Port:";
            // 
            // grpStatus
            // 
            grpStatus.Controls.Add(lblTotalValue);
            grpStatus.Controls.Add(lblTotal);
            grpStatus.Controls.Add(lblConnectionValue);
            grpStatus.Controls.Add(lblConnection);
            grpStatus.Location = new Point(359, 9);
            grpStatus.Margin = new Padding(3, 2, 3, 2);
            grpStatus.Name = "grpStatus";
            grpStatus.Padding = new Padding(3, 2, 3, 2);
            grpStatus.Size = new Size(332, 90);
            grpStatus.TabIndex = 1;
            grpStatus.TabStop = false;
            grpStatus.Text = "Status";
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalValue.ForeColor = Color.Green;
            lblTotalValue.Location = new Point(131, 52);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(19, 21);
            lblTotalValue.TabIndex = 3;
            lblTotalValue.Text = "0";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(18, 56);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(75, 15);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total Money:";
            // 
            // lblConnectionValue
            // 
            lblConnectionValue.AutoSize = true;
            lblConnectionValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblConnectionValue.ForeColor = Color.Red;
            lblConnectionValue.Location = new Point(131, 24);
            lblConnectionValue.Name = "lblConnectionValue";
            lblConnectionValue.Size = new Size(98, 19);
            lblConnectionValue.TabIndex = 1;
            lblConnectionValue.Text = "Disconnected";
            // 
            // lblConnection
            // 
            lblConnection.AutoSize = true;
            lblConnection.Location = new Point(18, 26);
            lblConnection.Name = "lblConnection";
            lblConnection.Size = new Size(72, 15);
            lblConnection.TabIndex = 0;
            lblConnection.Text = "Connection:";
            // 
            // grpActions
            // 
            grpActions.Controls.Add(btnResetTotal);
            grpActions.Controls.Add(btnClearLog);
            grpActions.Location = new Point(10, 109);
            grpActions.Margin = new Padding(3, 2, 3, 2);
            grpActions.Name = "grpActions";
            grpActions.Padding = new Padding(3, 2, 3, 2);
            grpActions.Size = new Size(681, 52);
            grpActions.TabIndex = 2;
            grpActions.TabStop = false;
            grpActions.Text = "Actions";
            // 
            // btnResetTotal
            // 
            btnResetTotal.Location = new Point(18, 19);
            btnResetTotal.Margin = new Padding(3, 2, 3, 2);
            btnResetTotal.Name = "btnResetTotal";
            btnResetTotal.Size = new Size(140, 26);
            btnResetTotal.TabIndex = 1;
            btnResetTotal.Text = "Reset Total";
            btnResetTotal.UseVisualStyleBackColor = true;
            btnResetTotal.Click += btnResetTotal_Click;
            // 
            // btnClearLog
            // 
            btnClearLog.Location = new Point(175, 19);
            btnClearLog.Margin = new Padding(3, 2, 3, 2);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(140, 26);
            btnClearLog.TabIndex = 0;
            btnClearLog.Text = "Clear Log";
            btnClearLog.UseVisualStyleBackColor = true;
            btnClearLog.Click += btnClearLog_Click;
            // 
            // grpLog
            // 
            grpLog.Controls.Add(txtLog);
            grpLog.Location = new Point(10, 248);
            grpLog.Margin = new Padding(3, 2, 3, 2);
            grpLog.Name = "grpLog";
            grpLog.Padding = new Padding(3, 2, 3, 2);
            grpLog.Size = new Size(681, 225);
            grpLog.TabIndex = 3;
            grpLog.TabStop = false;
            grpLog.Text = "Event Log";
            // 
            // txtLog
            // 
            txtLog.BackColor = Color.Black;
            txtLog.Font = new Font("Consolas", 9F);
            txtLog.ForeColor = Color.Lime;
            txtLog.Location = new Point(9, 19);
            txtLog.Margin = new Padding(3, 2, 3, 2);
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtLog.Size = new Size(664, 200);
            txtLog.TabIndex = 0;
            txtLog.Text = "";
            // 
            // grpInstructions
            // 
            grpInstructions.Controls.Add(lblInstructions);
            grpInstructions.Location = new Point(10, 169);
            grpInstructions.Margin = new Padding(3, 2, 3, 2);
            grpInstructions.Name = "grpInstructions";
            grpInstructions.Padding = new Padding(3, 2, 3, 2);
            grpInstructions.Size = new Size(681, 71);
            grpInstructions.TabIndex = 4;
            grpInstructions.TabStop = false;
            grpInstructions.Text = "Instructions";
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Location = new Point(13, 19);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(307, 45);
            lblInstructions.TabIndex = 0;
            lblInstructions.Text = "1. Select COM port and click Connect\r\n2. Insert bills into TB74 Bill Acceptor\r\n3. Watch the log for bill events and total amount updates";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 482);
            Controls.Add(grpInstructions);
            Controls.Add(grpLog);
            Controls.Add(grpActions);
            Controls.Add(grpStatus);
            Controls.Add(grpConnection);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TB74 Bill Acceptor Test Application";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            grpConnection.ResumeLayout(false);
            grpConnection.PerformLayout();
            grpStatus.ResumeLayout(false);
            grpStatus.PerformLayout();
            grpActions.ResumeLayout(false);
            grpLog.ResumeLayout(false);
            grpInstructions.ResumeLayout(false);
            grpInstructions.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Button btnRefreshPorts;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cmbComPorts;
        private System.Windows.Forms.Label lblComPort;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblConnectionValue;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnResetTotal;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.GroupBox grpInstructions;
        private System.Windows.Forms.Label lblInstructions;
    }
}
