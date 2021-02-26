
namespace GSA.ToolKits.DawnApp
{
    partial class LoginForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtPwd = new System.Windows.Forms.TextBox();
			this.txtCoder = new System.Windows.Forms.TextBox();
			this.btnLogin = new System.Windows.Forms.Button();
			this.picCoder = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picCoder)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(84, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "用户名：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(84, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "密  码：";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(84, 146);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "验证码：";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(160, 41);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(140, 21);
			this.txtName.TabIndex = 0;
			// 
			// txtPwd
			// 
			this.txtPwd.Location = new System.Drawing.Point(160, 94);
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.Size = new System.Drawing.Size(140, 21);
			this.txtPwd.TabIndex = 1;
			// 
			// txtCoder
			// 
			this.txtCoder.Location = new System.Drawing.Point(240, 144);
			this.txtCoder.MaxLength = 6;
			this.txtCoder.Name = "txtCoder";
			this.txtCoder.Size = new System.Drawing.Size(60, 21);
			this.txtCoder.TabIndex = 2;
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(225, 197);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(75, 25);
			this.btnLogin.TabIndex = 3;
			this.btnLogin.Text = "登  录";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// picCoder
			// 
			this.picCoder.Location = new System.Drawing.Point(160, 144);
			this.picCoder.Name = "picCoder";
			this.picCoder.Size = new System.Drawing.Size(75, 21);
			this.picCoder.TabIndex = 7;
			this.picCoder.TabStop = false;
			// 
			// LoginForm
			// 
			this.AcceptButton = this.btnLogin;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(85)))), ((int)(((byte)(150)))));
			this.ClientSize = new System.Drawing.Size(384, 262);
			this.Controls.Add(this.picCoder);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.txtCoder);
			this.Controls.Add(this.txtPwd);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LoginForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LoginForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
			this.Load += new System.EventHandler(this.LoginForm_Load);
			this.Shown += new System.EventHandler(this.LoginForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.picCoder)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtCoder;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox picCoder;
    }
}