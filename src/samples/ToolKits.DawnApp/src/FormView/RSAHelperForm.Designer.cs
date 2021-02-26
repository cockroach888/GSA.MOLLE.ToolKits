
namespace GSA.ToolKits.DawnApp.FormView
{
    partial class RSAHelperForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RSAHelperForm));
			this.txtPublicString = new System.Windows.Forms.TextBox();
			this.btnBuildRSAStr = new System.Windows.Forms.Button();
			this.txtPrivateString = new System.Windows.Forms.TextBox();
			this.lblPublicString = new System.Windows.Forms.Label();
			this.lblPrivateString = new System.Windows.Forms.Label();
			this.btnPublicEncrypt = new System.Windows.Forms.Button();
			this.btnPrivateEncrypt = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEncryptString = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEncryptSecret = new System.Windows.Forms.TextBox();
			this.btnPublicDecrypt = new System.Windows.Forms.Button();
			this.btnPrivateDecrypt = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDecryptSecret = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDecryptString = new System.Windows.Forms.TextBox();
			this.btnEncrypt = new System.Windows.Forms.Button();
			this.btnDecrypt = new System.Windows.Forms.Button();
			this.txtEncryptResult = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDecryptResult = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtPublicString
			// 
			this.txtPublicString.Location = new System.Drawing.Point(58, 53);
			this.txtPublicString.Name = "txtPublicString";
			this.txtPublicString.ReadOnly = true;
			this.txtPublicString.Size = new System.Drawing.Size(649, 21);
			this.txtPublicString.TabIndex = 0;
			// 
			// btnBuildRSAStr
			// 
			this.btnBuildRSAStr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnBuildRSAStr.Location = new System.Drawing.Point(659, 12);
			this.btnBuildRSAStr.Name = "btnBuildRSAStr";
			this.btnBuildRSAStr.Size = new System.Drawing.Size(128, 30);
			this.btnBuildRSAStr.TabIndex = 21;
			this.btnBuildRSAStr.Text = "生成非对称密钥对";
			this.btnBuildRSAStr.UseVisualStyleBackColor = true;
			this.btnBuildRSAStr.Click += new System.EventHandler(this.btnBuildRSAStr_Click);
			// 
			// txtPrivateString
			// 
			this.txtPrivateString.Location = new System.Drawing.Point(58, 85);
			this.txtPrivateString.Name = "txtPrivateString";
			this.txtPrivateString.ReadOnly = true;
			this.txtPrivateString.Size = new System.Drawing.Size(649, 21);
			this.txtPrivateString.TabIndex = 22;
			// 
			// lblPublicString
			// 
			this.lblPublicString.AutoSize = true;
			this.lblPublicString.Location = new System.Drawing.Point(17, 56);
			this.lblPublicString.Name = "lblPublicString";
			this.lblPublicString.Size = new System.Drawing.Size(35, 12);
			this.lblPublicString.TabIndex = 23;
			this.lblPublicString.Text = "公 钥";
			// 
			// lblPrivateString
			// 
			this.lblPrivateString.AutoSize = true;
			this.lblPrivateString.Location = new System.Drawing.Point(17, 88);
			this.lblPrivateString.Name = "lblPrivateString";
			this.lblPrivateString.Size = new System.Drawing.Size(35, 12);
			this.lblPrivateString.TabIndex = 24;
			this.lblPrivateString.Text = "私 钥";
			// 
			// btnPublicEncrypt
			// 
			this.btnPublicEncrypt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnPublicEncrypt.Location = new System.Drawing.Point(712, 52);
			this.btnPublicEncrypt.Name = "btnPublicEncrypt";
			this.btnPublicEncrypt.Size = new System.Drawing.Size(37, 23);
			this.btnPublicEncrypt.TabIndex = 25;
			this.btnPublicEncrypt.Text = "↓加";
			this.btnPublicEncrypt.UseVisualStyleBackColor = true;
			this.btnPublicEncrypt.Click += new System.EventHandler(this.btnPublicEncrypt_Click);
			// 
			// btnPrivateEncrypt
			// 
			this.btnPrivateEncrypt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnPrivateEncrypt.Location = new System.Drawing.Point(712, 84);
			this.btnPrivateEncrypt.Name = "btnPrivateEncrypt";
			this.btnPrivateEncrypt.Size = new System.Drawing.Size(37, 23);
			this.btnPrivateEncrypt.TabIndex = 26;
			this.btnPrivateEncrypt.Text = "↓加";
			this.btnPrivateEncrypt.UseVisualStyleBackColor = true;
			this.btnPrivateEncrypt.Click += new System.EventHandler(this.btnPrivateEncrypt_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 157);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 12);
			this.label1.TabIndex = 28;
			this.label1.Text = "明 文";
			// 
			// txtEncryptString
			// 
			this.txtEncryptString.Location = new System.Drawing.Point(58, 157);
			this.txtEncryptString.Multiline = true;
			this.txtEncryptString.Name = "txtEncryptString";
			this.txtEncryptString.Size = new System.Drawing.Size(729, 45);
			this.txtEncryptString.TabIndex = 27;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 134);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 12);
			this.label2.TabIndex = 30;
			this.label2.Text = "密 钥";
			// 
			// txtEncryptSecret
			// 
			this.txtEncryptSecret.Location = new System.Drawing.Point(58, 130);
			this.txtEncryptSecret.Name = "txtEncryptSecret";
			this.txtEncryptSecret.Size = new System.Drawing.Size(729, 21);
			this.txtEncryptSecret.TabIndex = 29;
			// 
			// btnPublicDecrypt
			// 
			this.btnPublicDecrypt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnPublicDecrypt.Location = new System.Drawing.Point(750, 52);
			this.btnPublicDecrypt.Name = "btnPublicDecrypt";
			this.btnPublicDecrypt.Size = new System.Drawing.Size(37, 23);
			this.btnPublicDecrypt.TabIndex = 31;
			this.btnPublicDecrypt.Text = "↓解";
			this.btnPublicDecrypt.UseVisualStyleBackColor = true;
			this.btnPublicDecrypt.Click += new System.EventHandler(this.btnPublicDecrypt_Click);
			// 
			// btnPrivateDecrypt
			// 
			this.btnPrivateDecrypt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnPrivateDecrypt.Location = new System.Drawing.Point(750, 84);
			this.btnPrivateDecrypt.Name = "btnPrivateDecrypt";
			this.btnPrivateDecrypt.Size = new System.Drawing.Size(37, 23);
			this.btnPrivateDecrypt.TabIndex = 32;
			this.btnPrivateDecrypt.Text = "↓解";
			this.btnPrivateDecrypt.UseVisualStyleBackColor = true;
			this.btnPrivateDecrypt.Click += new System.EventHandler(this.btnPrivateDecrypt_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(17, 318);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 12);
			this.label3.TabIndex = 36;
			this.label3.Text = "密 钥";
			// 
			// txtDecryptSecret
			// 
			this.txtDecryptSecret.Location = new System.Drawing.Point(58, 314);
			this.txtDecryptSecret.Name = "txtDecryptSecret";
			this.txtDecryptSecret.Size = new System.Drawing.Size(729, 21);
			this.txtDecryptSecret.TabIndex = 35;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(17, 341);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 12);
			this.label4.TabIndex = 34;
			this.label4.Text = "密 文";
			// 
			// txtDecryptString
			// 
			this.txtDecryptString.Location = new System.Drawing.Point(58, 341);
			this.txtDecryptString.Multiline = true;
			this.txtDecryptString.Name = "txtDecryptString";
			this.txtDecryptString.Size = new System.Drawing.Size(729, 45);
			this.txtDecryptString.TabIndex = 33;
			// 
			// btnEncrypt
			// 
			this.btnEncrypt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnEncrypt.Location = new System.Drawing.Point(697, 259);
			this.btnEncrypt.Name = "btnEncrypt";
			this.btnEncrypt.Size = new System.Drawing.Size(90, 30);
			this.btnEncrypt.TabIndex = 37;
			this.btnEncrypt.Text = "加  密";
			this.btnEncrypt.UseVisualStyleBackColor = true;
			this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
			// 
			// btnDecrypt
			// 
			this.btnDecrypt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnDecrypt.Location = new System.Drawing.Point(697, 443);
			this.btnDecrypt.Name = "btnDecrypt";
			this.btnDecrypt.Size = new System.Drawing.Size(90, 30);
			this.btnDecrypt.TabIndex = 38;
			this.btnDecrypt.Text = "解  密";
			this.btnDecrypt.UseVisualStyleBackColor = true;
			this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
			// 
			// txtEncryptResult
			// 
			this.txtEncryptResult.Location = new System.Drawing.Point(58, 208);
			this.txtEncryptResult.Multiline = true;
			this.txtEncryptResult.Name = "txtEncryptResult";
			this.txtEncryptResult.ReadOnly = true;
			this.txtEncryptResult.Size = new System.Drawing.Size(729, 45);
			this.txtEncryptResult.TabIndex = 39;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(17, 208);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 12);
			this.label5.TabIndex = 40;
			this.label5.Text = "结 果";
			// 
			// txtDecryptResult
			// 
			this.txtDecryptResult.Location = new System.Drawing.Point(58, 392);
			this.txtDecryptResult.Multiline = true;
			this.txtDecryptResult.Name = "txtDecryptResult";
			this.txtDecryptResult.ReadOnly = true;
			this.txtDecryptResult.Size = new System.Drawing.Size(729, 45);
			this.txtDecryptResult.TabIndex = 41;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(17, 393);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(35, 12);
			this.label6.TabIndex = 42;
			this.label6.Text = "结 果";
			// 
			// RSAHelperForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(799, 486);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtDecryptResult);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtEncryptResult);
			this.Controls.Add(this.btnDecrypt);
			this.Controls.Add(this.btnEncrypt);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtDecryptSecret);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtDecryptString);
			this.Controls.Add(this.btnPrivateDecrypt);
			this.Controls.Add(this.btnPublicDecrypt);
			this.Controls.Add(this.txtEncryptSecret);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtEncryptString);
			this.Controls.Add(this.btnPrivateEncrypt);
			this.Controls.Add(this.btnPublicEncrypt);
			this.Controls.Add(this.lblPrivateString);
			this.Controls.Add(this.lblPublicString);
			this.Controls.Add(this.txtPrivateString);
			this.Controls.Add(this.btnBuildRSAStr);
			this.Controls.Add(this.txtPublicString);
			this.Controls.Add(this.label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RSAHelperForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "非对称(RSA)加解密示范窗体";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

        #endregion

        private System.Windows.Forms.TextBox txtPublicString;
        private System.Windows.Forms.Button btnBuildRSAStr;
        private System.Windows.Forms.TextBox txtPrivateString;
        private System.Windows.Forms.Label lblPublicString;
        private System.Windows.Forms.Label lblPrivateString;
        private System.Windows.Forms.Button btnPublicEncrypt;
        private System.Windows.Forms.Button btnPrivateEncrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEncryptString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEncryptSecret;
        private System.Windows.Forms.Button btnPublicDecrypt;
        private System.Windows.Forms.Button btnPrivateDecrypt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDecryptSecret;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDecryptString;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox txtEncryptResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDecryptResult;
        private System.Windows.Forms.Label label6;
    }
}