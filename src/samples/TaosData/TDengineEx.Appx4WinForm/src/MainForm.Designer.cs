namespace TDengineEx.Appx4WinForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConnection = new Button();
            txtMessage = new TextBox();
            btnQueryLog = new Button();
            SuspendLayout();
            // 
            // btnConnection
            // 
            btnConnection.Location = new Point(12, 17);
            btnConnection.Name = "btnConnection";
            btnConnection.Size = new Size(227, 32);
            btnConnection.TabIndex = 0;
            btnConnection.Text = "使用独立连接显示数据库信息";
            btnConnection.UseVisualStyleBackColor = true;
            btnConnection.Click += BtnConnection_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 67);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.ScrollBars = ScrollBars.Vertical;
            txtMessage.Size = new Size(760, 482);
            txtMessage.TabIndex = 1;
            // 
            // btnQueryLog
            // 
            btnQueryLog.Location = new Point(261, 17);
            btnQueryLog.Name = "btnQueryLog";
            btnQueryLog.Size = new Size(221, 32);
            btnQueryLog.TabIndex = 0;
            btnQueryLog.Text = "使用全局连接查询日志数据";
            btnQueryLog.UseVisualStyleBackColor = true;
            btnQueryLog.Click += BtnQueryLog_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(txtMessage);
            Controls.Add(btnQueryLog);
            Controls.Add(btnConnection);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConnection;
        private TextBox txtMessage;
        private Button btnQueryLog;
    }
}