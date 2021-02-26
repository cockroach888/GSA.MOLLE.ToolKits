
namespace GSA.ToolKits.DawnApp.FormView
{
    partial class BuildingForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuildingForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkToUpper = new System.Windows.Forms.CheckBox();
			this.label12 = new System.Windows.Forms.Label();
			this.btnBuildGUID = new System.Windows.Forms.Button();
			this.txtHashCode = new System.Windows.Forms.TextBox();
			this.txtGuidCode = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cboxFormat = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cboxFormat);
			this.groupBox1.Controls.Add(this.chkToUpper);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.btnBuildGUID);
			this.groupBox1.Controls.Add(this.txtHashCode);
			this.groupBox1.Controls.Add(this.txtGuidCode);
			this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(775, 155);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "全球唯一标识（GUID）生成处理";
			// 
			// chkToUpper
			// 
			this.chkToUpper.AutoSize = true;
			this.chkToUpper.Font = new System.Drawing.Font("微软雅黑", 12F);
			this.chkToUpper.Location = new System.Drawing.Point(272, 112);
			this.chkToUpper.Name = "chkToUpper";
			this.chkToUpper.Size = new System.Drawing.Size(93, 25);
			this.chkToUpper.TabIndex = 12;
			this.chkToUpper.Text = "大写形式";
			this.chkToUpper.UseVisualStyleBackColor = true;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label12.Location = new System.Drawing.Point(13, 79);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(112, 21);
			this.label12.TabIndex = 11;
			this.label12.Text = "GUID Code：";
			// 
			// btnBuildGUID
			// 
			this.btnBuildGUID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnBuildGUID.Location = new System.Drawing.Point(680, 36);
			this.btnBuildGUID.Name = "btnBuildGUID";
			this.btnBuildGUID.Size = new System.Drawing.Size(86, 68);
			this.btnBuildGUID.TabIndex = 10;
			this.btnBuildGUID.Text = "生成";
			this.btnBuildGUID.UseVisualStyleBackColor = true;
			this.btnBuildGUID.Click += new System.EventHandler(this.btnBuildGUID_Click);
			// 
			// txtHashCode
			// 
			this.txtHashCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtHashCode.Location = new System.Drawing.Point(128, 36);
			this.txtHashCode.Name = "txtHashCode";
			this.txtHashCode.ReadOnly = true;
			this.txtHashCode.Size = new System.Drawing.Size(541, 29);
			this.txtHashCode.TabIndex = 8;
			// 
			// txtGuidCode
			// 
			this.txtGuidCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtGuidCode.Location = new System.Drawing.Point(128, 75);
			this.txtGuidCode.Name = "txtGuidCode";
			this.txtGuidCode.ReadOnly = true;
			this.txtGuidCode.Size = new System.Drawing.Size(541, 29);
			this.txtGuidCode.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(13, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 21);
			this.label1.TabIndex = 11;
			this.label1.Text = "Hash Code：";
			// 
			// cboxFormat
			// 
			this.cboxFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboxFormat.FormattingEnabled = true;
			this.cboxFormat.Items.AddRange(new object[] {
			"N",
			"D",
			"B",
			"P",
			"X"});
			this.cboxFormat.Location = new System.Drawing.Point(178, 110);
			this.cboxFormat.Name = "cboxFormat";
			this.cboxFormat.Size = new System.Drawing.Size(60, 29);
			this.cboxFormat.TabIndex = 13;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(124, 114);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 21);
			this.label2.TabIndex = 14;
			this.label2.Text = "  格式";
			// 
			// BuildingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(799, 486);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BuildingForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "数据建造示范窗体";
			this.Load += new System.EventHandler(this.BuildingForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkToUpper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnBuildGUID;
        private System.Windows.Forms.TextBox txtHashCode;
        private System.Windows.Forms.TextBox txtGuidCode;
        private System.Windows.Forms.ComboBox cboxFormat;
        private System.Windows.Forms.Label label2;
    }
}