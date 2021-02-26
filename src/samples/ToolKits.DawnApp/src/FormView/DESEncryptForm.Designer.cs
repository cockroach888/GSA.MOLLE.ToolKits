
namespace GSA.ToolKits.DawnApp.FormView
{
    partial class DESEncryptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DESEncryptForm));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnMD5 = new System.Windows.Forms.Button();
            this.txtMD5Value = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMD5Origin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDESValue = new System.Windows.Forms.TextBox();
            this.txtDESOrigin = new System.Windows.Forms.TextBox();
            this.btnDESValue = new System.Windows.Forms.Button();
            this.btnDESOrigin = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBase64Value = new System.Windows.Forms.TextBox();
            this.txtBase64Origin = new System.Windows.Forms.TextBox();
            this.btnToUnBase64 = new System.Windows.Forms.Button();
            this.btnToBase64 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnMD5);
            this.groupBox3.Controls.Add(this.txtMD5Value);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtMD5Origin);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 322);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(777, 146);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MD5数据生成";
            // 
            // btnMD5
            // 
            this.btnMD5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMD5.Location = new System.Drawing.Point(684, 102);
            this.btnMD5.Name = "btnMD5";
            this.btnMD5.Size = new System.Drawing.Size(80, 30);
            this.btnMD5.TabIndex = 20;
            this.btnMD5.Text = "生成MD5";
            this.btnMD5.UseVisualStyleBackColor = true;
            this.btnMD5.Click += new System.EventHandler(this.btnMD5_Click);
            // 
            // txtMD5Value
            // 
            this.txtMD5Value.Location = new System.Drawing.Point(118, 69);
            this.txtMD5Value.Name = "txtMD5Value";
            this.txtMD5Value.Size = new System.Drawing.Size(641, 21);
            this.txtMD5Value.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "生成后MD5数据：";
            // 
            // txtMD5Origin
            // 
            this.txtMD5Origin.Location = new System.Drawing.Point(118, 29);
            this.txtMD5Origin.Name = "txtMD5Origin";
            this.txtMD5Origin.Size = new System.Drawing.Size(641, 21);
            this.txtMD5Origin.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "待生成MD5数据：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDESValue);
            this.groupBox2.Controls.Add(this.txtDESOrigin);
            this.groupBox2.Controls.Add(this.btnDESValue);
            this.groupBox2.Controls.Add(this.btnDESOrigin);
            this.groupBox2.Location = new System.Drawing.Point(12, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(777, 136);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "通用密钥加/解密数据";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "加/解密后数据：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "待加/解密数据：";
            // 
            // txtDESValue
            // 
            this.txtDESValue.Location = new System.Drawing.Point(118, 62);
            this.txtDESValue.Name = "txtDESValue";
            this.txtDESValue.Size = new System.Drawing.Size(641, 21);
            this.txtDESValue.TabIndex = 21;
            // 
            // txtDESOrigin
            // 
            this.txtDESOrigin.Location = new System.Drawing.Point(118, 27);
            this.txtDESOrigin.Name = "txtDESOrigin";
            this.txtDESOrigin.Size = new System.Drawing.Size(641, 21);
            this.txtDESOrigin.TabIndex = 23;
            // 
            // btnDESValue
            // 
            this.btnDESValue.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDESValue.Location = new System.Drawing.Point(673, 94);
            this.btnDESValue.Name = "btnDESValue";
            this.btnDESValue.Size = new System.Drawing.Size(80, 30);
            this.btnDESValue.TabIndex = 19;
            this.btnDESValue.Text = "解密";
            this.btnDESValue.UseVisualStyleBackColor = true;
            this.btnDESValue.Click += new System.EventHandler(this.btnDESValue_Click);
            // 
            // btnDESOrigin
            // 
            this.btnDESOrigin.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDESOrigin.Location = new System.Drawing.Point(576, 94);
            this.btnDESOrigin.Name = "btnDESOrigin";
            this.btnDESOrigin.Size = new System.Drawing.Size(80, 30);
            this.btnDESOrigin.TabIndex = 20;
            this.btnDESOrigin.Text = "加密";
            this.btnDESOrigin.UseVisualStyleBackColor = true;
            this.btnDESOrigin.Click += new System.EventHandler(this.btnDESOrigin_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtBase64Value);
            this.groupBox1.Controls.Add(this.txtBase64Origin);
            this.groupBox1.Controls.Add(this.btnToUnBase64);
            this.groupBox1.Controls.Add(this.btnToBase64);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 136);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base 64 字符串处理";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "转换后数据：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "待转换数据：";
            // 
            // txtBase64Value
            // 
            this.txtBase64Value.Location = new System.Drawing.Point(100, 62);
            this.txtBase64Value.Name = "txtBase64Value";
            this.txtBase64Value.Size = new System.Drawing.Size(659, 21);
            this.txtBase64Value.TabIndex = 21;
            // 
            // txtBase64Origin
            // 
            this.txtBase64Origin.Location = new System.Drawing.Point(100, 27);
            this.txtBase64Origin.Name = "txtBase64Origin";
            this.txtBase64Origin.Size = new System.Drawing.Size(659, 21);
            this.txtBase64Origin.TabIndex = 23;
            // 
            // btnToUnBase64
            // 
            this.btnToUnBase64.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnToUnBase64.Location = new System.Drawing.Point(673, 94);
            this.btnToUnBase64.Name = "btnToUnBase64";
            this.btnToUnBase64.Size = new System.Drawing.Size(80, 30);
            this.btnToUnBase64.TabIndex = 19;
            this.btnToUnBase64.Text = "反转Base64";
            this.btnToUnBase64.UseVisualStyleBackColor = true;
            this.btnToUnBase64.Click += new System.EventHandler(this.btnToUnBase64_Click);
            // 
            // btnToBase64
            // 
            this.btnToBase64.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnToBase64.Location = new System.Drawing.Point(576, 94);
            this.btnToBase64.Name = "btnToBase64";
            this.btnToBase64.Size = new System.Drawing.Size(80, 30);
            this.btnToBase64.TabIndex = 20;
            this.btnToBase64.Text = "转Base64";
            this.btnToBase64.UseVisualStyleBackColor = true;
            this.btnToBase64.Click += new System.EventHandler(this.btnToBase64_Click);
            // 
            // DESEncryptForm
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
            this.Name = "DESEncryptForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "加解密示范窗体（通用版）";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnMD5;
        private System.Windows.Forms.TextBox txtMD5Value;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMD5Origin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDESValue;
        private System.Windows.Forms.TextBox txtDESOrigin;
        private System.Windows.Forms.Button btnDESValue;
        private System.Windows.Forms.Button btnDESOrigin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBase64Value;
        private System.Windows.Forms.TextBox txtBase64Origin;
        private System.Windows.Forms.Button btnToUnBase64;
        private System.Windows.Forms.Button btnToBase64;
    }
}