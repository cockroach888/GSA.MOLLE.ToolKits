
namespace GSA.ToolKits.DawnApp.FormView
{
    partial class NuclearForm
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
            this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuclearForm));
			this.gboxFTPTest = new System.Windows.Forms.GroupBox();
			this.gboxEMailTest = new System.Windows.Forms.GroupBox();
			this.chkMailHtml = new System.Windows.Forms.CheckBox();
			this.txtMailBody = new System.Windows.Forms.RichTextBox();
			this.lblMailBody = new System.Windows.Forms.Label();
			this.txtMailUser = new System.Windows.Forms.TextBox();
			this.lblMailUser = new System.Windows.Forms.Label();
			this.txtMailSubject = new System.Windows.Forms.TextBox();
			this.lblMailSubject = new System.Windows.Forms.Label();
			this.btnMailSend = new System.Windows.Forms.Button();
			this.txtSMTPPwd = new System.Windows.Forms.TextBox();
			this.lblSMTPPwd = new System.Windows.Forms.Label();
			this.txtSMTPUser = new System.Windows.Forms.TextBox();
			this.lblSMTPUser = new System.Windows.Forms.Label();
			this.txtSMTPPort = new System.Windows.Forms.TextBox();
			this.lblSMTPPort = new System.Windows.Forms.Label();
			this.txtSMTPServer = new System.Windows.Forms.TextBox();
			this.lblSMTPServer = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtRecipients = new System.Windows.Forms.TextBox();
			this.lblRecipients = new System.Windows.Forms.Label();
			this.btnRecipients = new System.Windows.Forms.Button();
			this.lstRecipients = new System.Windows.Forms.ListBox();
			this.gboxEMailTest.SuspendLayout();
			this.SuspendLayout();
			// 
			// gboxFTPTest
			// 
			this.gboxFTPTest.Location = new System.Drawing.Point(12, 12);
			this.gboxFTPTest.Name = "gboxFTPTest";
			this.gboxFTPTest.Size = new System.Drawing.Size(775, 147);
			this.gboxFTPTest.TabIndex = 0;
			this.gboxFTPTest.TabStop = false;
			this.gboxFTPTest.Text = "FTP";
			// 
			// gboxEMailTest
			// 
			this.gboxEMailTest.Controls.Add(this.chkMailHtml);
			this.gboxEMailTest.Controls.Add(this.txtMailBody);
			this.gboxEMailTest.Controls.Add(this.lblMailBody);
			this.gboxEMailTest.Controls.Add(this.txtMailUser);
			this.gboxEMailTest.Controls.Add(this.lblMailUser);
			this.gboxEMailTest.Controls.Add(this.txtMailSubject);
			this.gboxEMailTest.Controls.Add(this.lblMailSubject);
			this.gboxEMailTest.Controls.Add(this.btnMailSend);
			this.gboxEMailTest.Controls.Add(this.txtSMTPPwd);
			this.gboxEMailTest.Controls.Add(this.lblSMTPPwd);
			this.gboxEMailTest.Controls.Add(this.txtSMTPUser);
			this.gboxEMailTest.Controls.Add(this.lblSMTPUser);
			this.gboxEMailTest.Controls.Add(this.txtSMTPPort);
			this.gboxEMailTest.Controls.Add(this.lblSMTPPort);
			this.gboxEMailTest.Controls.Add(this.txtSMTPServer);
			this.gboxEMailTest.Controls.Add(this.lblSMTPServer);
			this.gboxEMailTest.Controls.Add(this.label2);
			this.gboxEMailTest.Controls.Add(this.txtRecipients);
			this.gboxEMailTest.Controls.Add(this.lblRecipients);
			this.gboxEMailTest.Controls.Add(this.btnRecipients);
			this.gboxEMailTest.Controls.Add(this.lstRecipients);
			this.gboxEMailTest.Location = new System.Drawing.Point(12, 174);
			this.gboxEMailTest.Name = "gboxEMailTest";
			this.gboxEMailTest.Size = new System.Drawing.Size(775, 300);
			this.gboxEMailTest.TabIndex = 1;
			this.gboxEMailTest.TabStop = false;
			this.gboxEMailTest.Text = "电子邮件";
			// 
			// chkMailHtml
			// 
			this.chkMailHtml.AutoSize = true;
			this.chkMailHtml.Checked = true;
			this.chkMailHtml.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkMailHtml.Location = new System.Drawing.Point(560, 83);
			this.chkMailHtml.Name = "chkMailHtml";
			this.chkMailHtml.Size = new System.Drawing.Size(78, 16);
			this.chkMailHtml.TabIndex = 21;
			this.chkMailHtml.Text = "HTML 格式";
			this.chkMailHtml.UseVisualStyleBackColor = true;
			// 
			// txtMailBody
			// 
			this.txtMailBody.Location = new System.Drawing.Point(221, 100);
			this.txtMailBody.Name = "txtMailBody";
			this.txtMailBody.Size = new System.Drawing.Size(540, 164);
			this.txtMailBody.TabIndex = 20;
			this.txtMailBody.Text = "<html><head></head><body><h1>你好！世界。</h1><br />Hello World!<h1></h1></body></html>" +
	"";
			// 
			// lblMailBody
			// 
			this.lblMailBody.AutoSize = true;
			this.lblMailBody.Location = new System.Drawing.Point(219, 87);
			this.lblMailBody.Name = "lblMailBody";
			this.lblMailBody.Size = new System.Drawing.Size(101, 12);
			this.lblMailBody.TabIndex = 18;
			this.lblMailBody.Text = "电子邮件正文区域";
			// 
			// txtMailUser
			// 
			this.txtMailUser.Location = new System.Drawing.Point(696, 57);
			this.txtMailUser.Name = "txtMailUser";
			this.txtMailUser.Size = new System.Drawing.Size(65, 21);
			this.txtMailUser.TabIndex = 17;
			this.txtMailUser.Text = "见过总裁";
			// 
			// lblMailUser
			// 
			this.lblMailUser.AutoSize = true;
			this.lblMailUser.Location = new System.Drawing.Point(643, 61);
			this.lblMailUser.Name = "lblMailUser";
			this.lblMailUser.Size = new System.Drawing.Size(53, 12);
			this.lblMailUser.TabIndex = 16;
			this.lblMailUser.Text = "发件人名";
			// 
			// txtMailSubject
			// 
			this.txtMailSubject.Location = new System.Drawing.Point(290, 57);
			this.txtMailSubject.Name = "txtMailSubject";
			this.txtMailSubject.Size = new System.Drawing.Size(348, 21);
			this.txtMailSubject.TabIndex = 15;
			this.txtMailSubject.Text = "这是一封见过总裁的重要来信，请注意查阅";
			// 
			// lblMailSubject
			// 
			this.lblMailSubject.AutoSize = true;
			this.lblMailSubject.Location = new System.Drawing.Point(219, 61);
			this.lblMailSubject.Name = "lblMailSubject";
			this.lblMailSubject.Size = new System.Drawing.Size(53, 12);
			this.lblMailSubject.TabIndex = 14;
			this.lblMailSubject.Text = "邮件主题";
			// 
			// btnMailSend
			// 
			this.btnMailSend.Location = new System.Drawing.Point(221, 270);
			this.btnMailSend.Name = "btnMailSend";
			this.btnMailSend.Size = new System.Drawing.Size(540, 23);
			this.btnMailSend.TabIndex = 13;
			this.btnMailSend.Text = "开 启 电 子 邮 件 发 射 之 旅";
			this.btnMailSend.UseVisualStyleBackColor = true;
			this.btnMailSend.Click += new System.EventHandler(this.btnMailSend_Click);
			// 
			// txtSMTPPwd
			// 
			this.txtSMTPPwd.Location = new System.Drawing.Point(696, 22);
			this.txtSMTPPwd.Name = "txtSMTPPwd";
			this.txtSMTPPwd.PasswordChar = '*';
			this.txtSMTPPwd.Size = new System.Drawing.Size(65, 21);
			this.txtSMTPPwd.TabIndex = 12;
			this.txtSMTPPwd.Text = "admin";
			// 
			// lblSMTPPwd
			// 
			this.lblSMTPPwd.AutoSize = true;
			this.lblSMTPPwd.Location = new System.Drawing.Point(643, 26);
			this.lblSMTPPwd.Name = "lblSMTPPwd";
			this.lblSMTPPwd.Size = new System.Drawing.Size(53, 12);
			this.lblSMTPPwd.TabIndex = 11;
			this.lblSMTPPwd.Text = "SMTP Pwd";
			// 
			// txtSMTPUser
			// 
			this.txtSMTPUser.Location = new System.Drawing.Point(538, 22);
			this.txtSMTPUser.Name = "txtSMTPUser";
			this.txtSMTPUser.Size = new System.Drawing.Size(100, 21);
			this.txtSMTPUser.TabIndex = 10;
			this.txtSMTPUser.Text = "services@163.com";
			// 
			// lblSMTPUser
			// 
			this.lblSMTPUser.AutoSize = true;
			this.lblSMTPUser.Location = new System.Drawing.Point(479, 26);
			this.lblSMTPUser.Name = "lblSMTPUser";
			this.lblSMTPUser.Size = new System.Drawing.Size(59, 12);
			this.lblSMTPUser.TabIndex = 9;
			this.lblSMTPUser.Text = "SMTP User";
			// 
			// txtSMTPPort
			// 
			this.txtSMTPPort.Location = new System.Drawing.Point(444, 22);
			this.txtSMTPPort.Name = "txtSMTPPort";
			this.txtSMTPPort.Size = new System.Drawing.Size(30, 21);
			this.txtSMTPPort.TabIndex = 8;
			this.txtSMTPPort.Text = "25";
			// 
			// lblSMTPPort
			// 
			this.lblSMTPPort.AutoSize = true;
			this.lblSMTPPort.Location = new System.Drawing.Point(385, 26);
			this.lblSMTPPort.Name = "lblSMTPPort";
			this.lblSMTPPort.Size = new System.Drawing.Size(59, 12);
			this.lblSMTPPort.TabIndex = 7;
			this.lblSMTPPort.Text = "SMTP Port";
			// 
			// txtSMTPServer
			// 
			this.txtSMTPServer.Location = new System.Drawing.Point(290, 22);
			this.txtSMTPServer.Name = "txtSMTPServer";
			this.txtSMTPServer.Size = new System.Drawing.Size(90, 21);
			this.txtSMTPServer.TabIndex = 6;
			this.txtSMTPServer.Text = "smtp.163.com";
			// 
			// lblSMTPServer
			// 
			this.lblSMTPServer.AutoSize = true;
			this.lblSMTPServer.Location = new System.Drawing.Point(219, 26);
			this.lblSMTPServer.Name = "lblSMTPServer";
			this.lblSMTPServer.Size = new System.Drawing.Size(71, 12);
			this.lblSMTPServer.TabIndex = 5;
			this.lblSMTPServer.Text = "SMTP Server";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "收件人列表";
			// 
			// txtRecipients
			// 
			this.txtRecipients.Location = new System.Drawing.Point(48, 22);
			this.txtRecipients.Name = "txtRecipients";
			this.txtRecipients.Size = new System.Drawing.Size(100, 21);
			this.txtRecipients.TabIndex = 3;
			this.txtRecipients.Text = "services@126.com";
			// 
			// lblRecipients
			// 
			this.lblRecipients.AutoSize = true;
			this.lblRecipients.Location = new System.Drawing.Point(7, 26);
			this.lblRecipients.Name = "lblRecipients";
			this.lblRecipients.Size = new System.Drawing.Size(41, 12);
			this.lblRecipients.TabIndex = 2;
			this.lblRecipients.Text = "收件人";
			// 
			// btnRecipients
			// 
			this.btnRecipients.Location = new System.Drawing.Point(148, 21);
			this.btnRecipients.Name = "btnRecipients";
			this.btnRecipients.Size = new System.Drawing.Size(45, 23);
			this.btnRecipients.TabIndex = 1;
			this.btnRecipients.Text = "增加";
			this.btnRecipients.UseVisualStyleBackColor = true;
			this.btnRecipients.Click += new System.EventHandler(this.btnRecipients_Click);
			// 
			// lstRecipients
			// 
			this.lstRecipients.FormattingEnabled = true;
			this.lstRecipients.ItemHeight = 12;
			this.lstRecipients.Location = new System.Drawing.Point(7, 74);
			this.lstRecipients.Name = "lstRecipients";
			this.lstRecipients.Size = new System.Drawing.Size(186, 220);
			this.lstRecipients.TabIndex = 0;
			// 
			// NuclearForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(799, 486);
			this.Controls.Add(this.gboxEMailTest);
			this.Controls.Add(this.gboxFTPTest);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NuclearForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "原子式磁场演示中心(FTP、Email...)";
			this.Load += new System.EventHandler(this.NuclearForm_Load);
			this.gboxEMailTest.ResumeLayout(false);
			this.gboxEMailTest.PerformLayout();
			this.ResumeLayout(false);
		}

        #endregion

        private System.Windows.Forms.GroupBox gboxFTPTest;
        private System.Windows.Forms.GroupBox gboxEMailTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRecipients;
        private System.Windows.Forms.Label lblRecipients;
        private System.Windows.Forms.Button btnRecipients;
        private System.Windows.Forms.ListBox lstRecipients;
        private System.Windows.Forms.TextBox txtSMTPPwd;
        private System.Windows.Forms.Label lblSMTPPwd;
        private System.Windows.Forms.TextBox txtSMTPUser;
        private System.Windows.Forms.Label lblSMTPUser;
        private System.Windows.Forms.TextBox txtSMTPPort;
        private System.Windows.Forms.Label lblSMTPPort;
        private System.Windows.Forms.TextBox txtSMTPServer;
        private System.Windows.Forms.Label lblSMTPServer;
        private System.Windows.Forms.Button btnMailSend;
        private System.Windows.Forms.RichTextBox txtMailBody;
        private System.Windows.Forms.Label lblMailBody;
        private System.Windows.Forms.TextBox txtMailUser;
        private System.Windows.Forms.Label lblMailUser;
        private System.Windows.Forms.TextBox txtMailSubject;
        private System.Windows.Forms.Label lblMailSubject;
        private System.Windows.Forms.CheckBox chkMailHtml;
    }
}