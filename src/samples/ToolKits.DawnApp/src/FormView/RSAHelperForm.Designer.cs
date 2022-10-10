
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
            this.txtKeySize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPublicString
            // 
            this.txtPublicString.Location = new System.Drawing.Point(68, 75);
            this.txtPublicString.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPublicString.Name = "txtPublicString";
            this.txtPublicString.ReadOnly = true;
            this.txtPublicString.Size = new System.Drawing.Size(756, 23);
            this.txtPublicString.TabIndex = 0;
            // 
            // btnBuildRSAStr
            // 
            this.btnBuildRSAStr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuildRSAStr.Location = new System.Drawing.Point(769, 17);
            this.btnBuildRSAStr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuildRSAStr.Name = "btnBuildRSAStr";
            this.btnBuildRSAStr.Size = new System.Drawing.Size(149, 42);
            this.btnBuildRSAStr.TabIndex = 21;
            this.btnBuildRSAStr.Text = "生成非对称密钥对";
            this.btnBuildRSAStr.UseVisualStyleBackColor = true;
            this.btnBuildRSAStr.Click += new System.EventHandler(this.btnBuildRSAStr_Click);
            // 
            // txtPrivateString
            // 
            this.txtPrivateString.Location = new System.Drawing.Point(68, 120);
            this.txtPrivateString.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrivateString.Name = "txtPrivateString";
            this.txtPrivateString.ReadOnly = true;
            this.txtPrivateString.Size = new System.Drawing.Size(756, 23);
            this.txtPrivateString.TabIndex = 22;
            // 
            // lblPublicString
            // 
            this.lblPublicString.AutoSize = true;
            this.lblPublicString.Location = new System.Drawing.Point(20, 79);
            this.lblPublicString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPublicString.Name = "lblPublicString";
            this.lblPublicString.Size = new System.Drawing.Size(36, 17);
            this.lblPublicString.TabIndex = 23;
            this.lblPublicString.Text = "公 钥";
            // 
            // lblPrivateString
            // 
            this.lblPrivateString.AutoSize = true;
            this.lblPrivateString.Location = new System.Drawing.Point(20, 125);
            this.lblPrivateString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrivateString.Name = "lblPrivateString";
            this.lblPrivateString.Size = new System.Drawing.Size(36, 17);
            this.lblPrivateString.TabIndex = 24;
            this.lblPrivateString.Text = "私 钥";
            // 
            // btnPublicEncrypt
            // 
            this.btnPublicEncrypt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPublicEncrypt.Location = new System.Drawing.Point(831, 74);
            this.btnPublicEncrypt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPublicEncrypt.Name = "btnPublicEncrypt";
            this.btnPublicEncrypt.Size = new System.Drawing.Size(43, 33);
            this.btnPublicEncrypt.TabIndex = 25;
            this.btnPublicEncrypt.Text = "↓加";
            this.btnPublicEncrypt.UseVisualStyleBackColor = true;
            this.btnPublicEncrypt.Click += new System.EventHandler(this.btnPublicEncrypt_Click);
            // 
            // btnPrivateEncrypt
            // 
            this.btnPrivateEncrypt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPrivateEncrypt.Location = new System.Drawing.Point(831, 119);
            this.btnPrivateEncrypt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrivateEncrypt.Name = "btnPrivateEncrypt";
            this.btnPrivateEncrypt.Size = new System.Drawing.Size(43, 33);
            this.btnPrivateEncrypt.TabIndex = 26;
            this.btnPrivateEncrypt.Text = "↓加";
            this.btnPrivateEncrypt.UseVisualStyleBackColor = true;
            this.btnPrivateEncrypt.Click += new System.EventHandler(this.btnPrivateEncrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 222);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "明 文";
            // 
            // txtEncryptString
            // 
            this.txtEncryptString.Location = new System.Drawing.Point(68, 222);
            this.txtEncryptString.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEncryptString.Multiline = true;
            this.txtEncryptString.Name = "txtEncryptString";
            this.txtEncryptString.Size = new System.Drawing.Size(850, 62);
            this.txtEncryptString.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 190);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "密 钥";
            // 
            // txtEncryptSecret
            // 
            this.txtEncryptSecret.Location = new System.Drawing.Point(68, 184);
            this.txtEncryptSecret.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEncryptSecret.Name = "txtEncryptSecret";
            this.txtEncryptSecret.Size = new System.Drawing.Size(850, 23);
            this.txtEncryptSecret.TabIndex = 29;
            // 
            // btnPublicDecrypt
            // 
            this.btnPublicDecrypt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPublicDecrypt.Location = new System.Drawing.Point(875, 74);
            this.btnPublicDecrypt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPublicDecrypt.Name = "btnPublicDecrypt";
            this.btnPublicDecrypt.Size = new System.Drawing.Size(43, 33);
            this.btnPublicDecrypt.TabIndex = 31;
            this.btnPublicDecrypt.Text = "↓解";
            this.btnPublicDecrypt.UseVisualStyleBackColor = true;
            this.btnPublicDecrypt.Click += new System.EventHandler(this.btnPublicDecrypt_Click);
            // 
            // btnPrivateDecrypt
            // 
            this.btnPrivateDecrypt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPrivateDecrypt.Location = new System.Drawing.Point(875, 119);
            this.btnPrivateDecrypt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrivateDecrypt.Name = "btnPrivateDecrypt";
            this.btnPrivateDecrypt.Size = new System.Drawing.Size(43, 33);
            this.btnPrivateDecrypt.TabIndex = 32;
            this.btnPrivateDecrypt.Text = "↓解";
            this.btnPrivateDecrypt.UseVisualStyleBackColor = true;
            this.btnPrivateDecrypt.Click += new System.EventHandler(this.btnPrivateDecrypt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 450);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 36;
            this.label3.Text = "密 钥";
            // 
            // txtDecryptSecret
            // 
            this.txtDecryptSecret.Location = new System.Drawing.Point(68, 445);
            this.txtDecryptSecret.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDecryptSecret.Name = "txtDecryptSecret";
            this.txtDecryptSecret.Size = new System.Drawing.Size(850, 23);
            this.txtDecryptSecret.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 483);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 34;
            this.label4.Text = "密 文";
            // 
            // txtDecryptString
            // 
            this.txtDecryptString.Location = new System.Drawing.Point(68, 483);
            this.txtDecryptString.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDecryptString.Multiline = true;
            this.txtDecryptString.Name = "txtDecryptString";
            this.txtDecryptString.Size = new System.Drawing.Size(850, 62);
            this.txtDecryptString.TabIndex = 33;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEncrypt.Location = new System.Drawing.Point(813, 367);
            this.btnEncrypt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(105, 42);
            this.btnEncrypt.TabIndex = 37;
            this.btnEncrypt.Text = "加  密";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDecrypt.Location = new System.Drawing.Point(813, 628);
            this.btnDecrypt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(105, 42);
            this.btnDecrypt.TabIndex = 38;
            this.btnDecrypt.Text = "解  密";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txtEncryptResult
            // 
            this.txtEncryptResult.Location = new System.Drawing.Point(68, 295);
            this.txtEncryptResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEncryptResult.Multiline = true;
            this.txtEncryptResult.Name = "txtEncryptResult";
            this.txtEncryptResult.ReadOnly = true;
            this.txtEncryptResult.Size = new System.Drawing.Size(850, 62);
            this.txtEncryptResult.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 295);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 40;
            this.label5.Text = "结 果";
            // 
            // txtDecryptResult
            // 
            this.txtDecryptResult.Location = new System.Drawing.Point(68, 555);
            this.txtDecryptResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDecryptResult.Multiline = true;
            this.txtDecryptResult.Name = "txtDecryptResult";
            this.txtDecryptResult.ReadOnly = true;
            this.txtDecryptResult.Size = new System.Drawing.Size(850, 62);
            this.txtDecryptResult.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 557);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 17);
            this.label6.TabIndex = 42;
            this.label6.Text = "结 果";
            // 
            // txtKeySize
            // 
            this.txtKeySize.Location = new System.Drawing.Point(632, 26);
            this.txtKeySize.Name = "txtKeySize";
            this.txtKeySize.Size = new System.Drawing.Size(100, 23);
            this.txtKeySize.TabIndex = 43;
            this.txtKeySize.Text = "1024";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(572, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 44;
            this.label7.Text = "密钥长度";
            // 
            // RSAHelperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 688);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtKeySize);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
		private System.Windows.Forms.TextBox txtKeySize;
		private System.Windows.Forms.Label label7;
	}
}