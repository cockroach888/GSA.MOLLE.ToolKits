
namespace GSA.ToolKits.DawnApp.FormView
{
    partial class DESEncryptCustomForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DESEncryptCustomForm));
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txt_desData2 = new System.Windows.Forms.TextBox();
			this.txt_desKeys = new System.Windows.Forms.TextBox();
			this.txt_tempData2 = new System.Windows.Forms.TextBox();
			this.btnDecrypt2 = new System.Windows.Forms.Button();
			this.btnEncrypt2 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cboxKeyType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtInsidValue = new System.Windows.Forms.TextBox();
			this.txtInsidOrigin = new System.Windows.Forms.TextBox();
			this.btnInsidDecrypt = new System.Windows.Forms.Button();
			this.btnInsidEncrypt = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lblDoLengthTitle = new System.Windows.Forms.Label();
			this.txtDoLengthText = new System.Windows.Forms.TextBox();
			this.lblDoLengthNum = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.txt_desData2);
			this.groupBox2.Controls.Add(this.txt_desKeys);
			this.groupBox2.Controls.Add(this.txt_tempData2);
			this.groupBox2.Controls.Add(this.btnDecrypt2);
			this.groupBox2.Controls.Add(this.btnEncrypt2);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(777, 136);
			this.groupBox2.TabIndex = 24;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "自定义密钥加密方式";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(17, 66);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(77, 12);
			this.label6.TabIndex = 25;
			this.label6.Text = "加密后数据：";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(17, 102);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(77, 12);
			this.label7.TabIndex = 28;
			this.label7.Text = "加密用密钥：";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(17, 31);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(77, 12);
			this.label5.TabIndex = 27;
			this.label5.Text = "待加密数据：";
			// 
			// txt_desData2
			// 
			this.txt_desData2.Location = new System.Drawing.Point(100, 62);
			this.txt_desData2.Name = "txt_desData2";
			this.txt_desData2.Size = new System.Drawing.Size(659, 21);
			this.txt_desData2.TabIndex = 21;
			// 
			// txt_desKeys
			// 
			this.txt_desKeys.Location = new System.Drawing.Point(100, 98);
			this.txt_desKeys.Name = "txt_desKeys";
			this.txt_desKeys.Size = new System.Drawing.Size(247, 21);
			this.txt_desKeys.TabIndex = 22;
			// 
			// txt_tempData2
			// 
			this.txt_tempData2.Location = new System.Drawing.Point(100, 27);
			this.txt_tempData2.Name = "txt_tempData2";
			this.txt_tempData2.Size = new System.Drawing.Size(659, 21);
			this.txt_tempData2.TabIndex = 23;
			// 
			// btnDecrypt2
			// 
			this.btnDecrypt2.Location = new System.Drawing.Point(673, 95);
			this.btnDecrypt2.Name = "btnDecrypt2";
			this.btnDecrypt2.Size = new System.Drawing.Size(80, 30);
			this.btnDecrypt2.TabIndex = 19;
			this.btnDecrypt2.Text = "解密";
			this.btnDecrypt2.UseVisualStyleBackColor = true;
			this.btnDecrypt2.Click += new System.EventHandler(this.btnDecrypt2_Click);
			// 
			// btnEncrypt2
			// 
			this.btnEncrypt2.Location = new System.Drawing.Point(576, 95);
			this.btnEncrypt2.Name = "btnEncrypt2";
			this.btnEncrypt2.Size = new System.Drawing.Size(80, 30);
			this.btnEncrypt2.TabIndex = 20;
			this.btnEncrypt2.Text = "加密";
			this.btnEncrypt2.UseVisualStyleBackColor = true;
			this.btnEncrypt2.Click += new System.EventHandler(this.btnEncrypt2_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cboxKeyType);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtInsidValue);
			this.groupBox1.Controls.Add(this.txtInsidOrigin);
			this.groupBox1.Controls.Add(this.btnInsidDecrypt);
			this.groupBox1.Controls.Add(this.btnInsidEncrypt);
			this.groupBox1.Location = new System.Drawing.Point(12, 154);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(777, 136);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "内置密钥加密方式";
			// 
			// cboxKeyType
			// 
			this.cboxKeyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboxKeyType.Items.AddRange(new object[] {
			"101",
			"102",
			"103",
			"104",
			"105",
			"106",
			"107",
			"108",
			"109"});
			this.cboxKeyType.Location = new System.Drawing.Point(100, 99);
			this.cboxKeyType.Name = "cboxKeyType";
			this.cboxKeyType.Size = new System.Drawing.Size(91, 20);
			this.cboxKeyType.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 66);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 12);
			this.label1.TabIndex = 25;
			this.label1.Text = "加密后数据：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 102);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 12);
			this.label2.TabIndex = 28;
			this.label2.Text = "内置的密钥：";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(17, 31);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 12);
			this.label3.TabIndex = 27;
			this.label3.Text = "待加密数据：";
			// 
			// txtInsidValue
			// 
			this.txtInsidValue.Location = new System.Drawing.Point(100, 62);
			this.txtInsidValue.Name = "txtInsidValue";
			this.txtInsidValue.Size = new System.Drawing.Size(659, 21);
			this.txtInsidValue.TabIndex = 21;
			// 
			// txtInsidOrigin
			// 
			this.txtInsidOrigin.Location = new System.Drawing.Point(100, 27);
			this.txtInsidOrigin.Name = "txtInsidOrigin";
			this.txtInsidOrigin.Size = new System.Drawing.Size(659, 21);
			this.txtInsidOrigin.TabIndex = 23;
			// 
			// btnInsidDecrypt
			// 
			this.btnInsidDecrypt.Location = new System.Drawing.Point(673, 95);
			this.btnInsidDecrypt.Name = "btnInsidDecrypt";
			this.btnInsidDecrypt.Size = new System.Drawing.Size(80, 30);
			this.btnInsidDecrypt.TabIndex = 19;
			this.btnInsidDecrypt.Text = "解密";
			this.btnInsidDecrypt.UseVisualStyleBackColor = true;
			this.btnInsidDecrypt.Click += new System.EventHandler(this.btnInsidDecrypt_Click);
			// 
			// btnInsidEncrypt
			// 
			this.btnInsidEncrypt.Location = new System.Drawing.Point(576, 95);
			this.btnInsidEncrypt.Name = "btnInsidEncrypt";
			this.btnInsidEncrypt.Size = new System.Drawing.Size(80, 30);
			this.btnInsidEncrypt.TabIndex = 20;
			this.btnInsidEncrypt.Text = "加密";
			this.btnInsidEncrypt.UseVisualStyleBackColor = true;
			this.btnInsidEncrypt.Click += new System.EventHandler(this.btnInsidEncrypt_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.lblDoLengthNum);
			this.groupBox3.Controls.Add(this.txtDoLengthText);
			this.groupBox3.Controls.Add(this.lblDoLengthTitle);
			this.groupBox3.Location = new System.Drawing.Point(12, 296);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(777, 179);
			this.groupBox3.TabIndex = 25;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "量子传输科研中心";
			// 
			// lblDoLengthTitle
			// 
			this.lblDoLengthTitle.AutoSize = true;
			this.lblDoLengthTitle.Location = new System.Drawing.Point(29, 35);
			this.lblDoLengthTitle.Name = "lblDoLengthTitle";
			this.lblDoLengthTitle.Size = new System.Drawing.Size(53, 12);
			this.lblDoLengthTitle.TabIndex = 0;
			this.lblDoLengthTitle.Text = "长度计算";
			// 
			// txtDoLengthText
			// 
			this.txtDoLengthText.Location = new System.Drawing.Point(90, 31);
			this.txtDoLengthText.Name = "txtDoLengthText";
			this.txtDoLengthText.Size = new System.Drawing.Size(570, 21);
			this.txtDoLengthText.TabIndex = 1;
			this.txtDoLengthText.TextChanged += new System.EventHandler(this.txtDoLengthText_TextChanged);
			// 
			// lblDoLengthNum
			// 
			this.lblDoLengthNum.AutoSize = true;
			this.lblDoLengthNum.Location = new System.Drawing.Point(668, 35);
			this.lblDoLengthNum.Name = "lblDoLengthNum";
			this.lblDoLengthNum.Size = new System.Drawing.Size(47, 12);
			this.lblDoLengthNum.TabIndex = 2;
			this.lblDoLengthNum.Text = "长度：0";
			// 
			// DESEncryptCustomForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(801, 487);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DESEncryptCustomForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "加解密示范窗体（定制版）";
			this.Load += new System.EventHandler(this.DESEncryptCustomForm_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
		}

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_desData2;
        private System.Windows.Forms.TextBox txt_desKeys;
        private System.Windows.Forms.TextBox txt_tempData2;
        private System.Windows.Forms.Button btnDecrypt2;
        private System.Windows.Forms.Button btnEncrypt2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboxKeyType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInsidValue;
        private System.Windows.Forms.TextBox txtInsidOrigin;
        private System.Windows.Forms.Button btnInsidDecrypt;
        private System.Windows.Forms.Button btnInsidEncrypt;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblDoLengthNum;
        private System.Windows.Forms.TextBox txtDoLengthText;
        private System.Windows.Forms.Label lblDoLengthTitle;
    }
}