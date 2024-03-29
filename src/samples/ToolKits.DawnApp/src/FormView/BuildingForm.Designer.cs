﻿
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuildingForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxFormat = new System.Windows.Forms.ComboBox();
            this.chkToUpper = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnBuildGUID = new System.Windows.Forms.Button();
            this.txtHashCode = new System.Windows.Forms.TextBox();
            this.txtGuidCode = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtDateTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnToDateTime = new System.Windows.Forms.Button();
            this.BtnToTimestamp = new System.Windows.Forms.Button();
            this.TxtTimestamp = new System.Windows.Forms.TextBox();
            this.RdoTypeMilliseconds = new System.Windows.Forms.RadioButton();
            this.RdoTypeSeconds = new System.Windows.Forms.RadioButton();
            this.DtpDateTime = new System.Windows.Forms.DateTimePicker();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(14, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(904, 220);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "全球唯一标识（GUID）生成处理";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(145, 162);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "  格式";
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
            this.cboxFormat.Location = new System.Drawing.Point(208, 156);
            this.cboxFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cboxFormat.Name = "cboxFormat";
            this.cboxFormat.Size = new System.Drawing.Size(69, 29);
            this.cboxFormat.TabIndex = 13;
            // 
            // chkToUpper
            // 
            this.chkToUpper.AutoSize = true;
            this.chkToUpper.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkToUpper.Location = new System.Drawing.Point(317, 159);
            this.chkToUpper.Margin = new System.Windows.Forms.Padding(4);
            this.chkToUpper.Name = "chkToUpper";
            this.chkToUpper.Size = new System.Drawing.Size(93, 25);
            this.chkToUpper.TabIndex = 12;
            this.chkToUpper.Text = "大写形式";
            this.chkToUpper.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(15, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Hash Code：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(15, 112);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 21);
            this.label12.TabIndex = 11;
            this.label12.Text = "GUID Code：";
            // 
            // btnBuildGUID
            // 
            this.btnBuildGUID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuildGUID.Location = new System.Drawing.Point(793, 51);
            this.btnBuildGUID.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuildGUID.Name = "btnBuildGUID";
            this.btnBuildGUID.Size = new System.Drawing.Size(100, 96);
            this.btnBuildGUID.TabIndex = 10;
            this.btnBuildGUID.Text = "生成";
            this.btnBuildGUID.UseVisualStyleBackColor = true;
            this.btnBuildGUID.Click += new System.EventHandler(this.btnBuildGUID_Click);
            // 
            // txtHashCode
            // 
            this.txtHashCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHashCode.Location = new System.Drawing.Point(149, 51);
            this.txtHashCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtHashCode.Name = "txtHashCode";
            this.txtHashCode.ReadOnly = true;
            this.txtHashCode.Size = new System.Drawing.Size(630, 29);
            this.txtHashCode.TabIndex = 8;
            // 
            // txtGuidCode
            // 
            this.txtGuidCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtGuidCode.Location = new System.Drawing.Point(149, 106);
            this.txtGuidCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtGuidCode.Name = "txtGuidCode";
            this.txtGuidCode.ReadOnly = true;
            this.txtGuidCode.Size = new System.Drawing.Size(630, 29);
            this.txtGuidCode.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtDateTime);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.BtnToDateTime);
            this.groupBox2.Controls.Add(this.BtnToTimestamp);
            this.groupBox2.Controls.Add(this.TxtTimestamp);
            this.groupBox2.Controls.Add(this.RdoTypeMilliseconds);
            this.groupBox2.Controls.Add(this.RdoTypeSeconds);
            this.groupBox2.Controls.Add(this.DtpDateTime);
            this.groupBox2.Location = new System.Drawing.Point(11, 244);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(907, 122);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "时间戳";
            // 
            // TxtDateTime
            // 
            this.TxtDateTime.Location = new System.Drawing.Point(298, 34);
            this.TxtDateTime.Name = "TxtDateTime";
            this.TxtDateTime.ReadOnly = true;
            this.TxtDateTime.Size = new System.Drawing.Size(175, 23);
            this.TxtDateTime.TabIndex = 6;
            this.TxtDateTime.Text = "1970-01-01 00:00:00.0000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "时间戳类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = " 时间戳";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "日期与时间";
            // 
            // BtnToDateTime
            // 
            this.BtnToDateTime.Location = new System.Drawing.Point(730, 71);
            this.BtnToDateTime.Name = "BtnToDateTime";
            this.BtnToDateTime.Size = new System.Drawing.Size(140, 35);
            this.BtnToDateTime.TabIndex = 4;
            this.BtnToDateTime.Text = "转换为日期与时间";
            this.BtnToDateTime.UseVisualStyleBackColor = true;
            this.BtnToDateTime.Click += new System.EventHandler(this.BtnToDateTime_Click);
            // 
            // BtnToTimestamp
            // 
            this.BtnToTimestamp.Location = new System.Drawing.Point(730, 23);
            this.BtnToTimestamp.Name = "BtnToTimestamp";
            this.BtnToTimestamp.Size = new System.Drawing.Size(140, 35);
            this.BtnToTimestamp.TabIndex = 4;
            this.BtnToTimestamp.Text = "转换为时间戳";
            this.BtnToTimestamp.UseVisualStyleBackColor = true;
            this.BtnToTimestamp.Click += new System.EventHandler(this.BtnToTimestamp_Click);
            // 
            // TxtTimestamp
            // 
            this.TxtTimestamp.Location = new System.Drawing.Point(394, 79);
            this.TxtTimestamp.Name = "TxtTimestamp";
            this.TxtTimestamp.Size = new System.Drawing.Size(175, 23);
            this.TxtTimestamp.TabIndex = 3;
            // 
            // RdoTypeMilliseconds
            // 
            this.RdoTypeMilliseconds.AutoSize = true;
            this.RdoTypeMilliseconds.Checked = true;
            this.RdoTypeMilliseconds.Location = new System.Drawing.Point(202, 80);
            this.RdoTypeMilliseconds.Name = "RdoTypeMilliseconds";
            this.RdoTypeMilliseconds.Size = new System.Drawing.Size(78, 21);
            this.RdoTypeMilliseconds.TabIndex = 2;
            this.RdoTypeMilliseconds.TabStop = true;
            this.RdoTypeMilliseconds.Text = " 总毫秒数";
            this.RdoTypeMilliseconds.UseVisualStyleBackColor = true;
            // 
            // RdoTypeSeconds
            // 
            this.RdoTypeSeconds.AutoSize = true;
            this.RdoTypeSeconds.Location = new System.Drawing.Point(117, 80);
            this.RdoTypeSeconds.Name = "RdoTypeSeconds";
            this.RdoTypeSeconds.Size = new System.Drawing.Size(66, 21);
            this.RdoTypeSeconds.TabIndex = 1;
            this.RdoTypeSeconds.Text = " 总秒数";
            this.RdoTypeSeconds.UseVisualStyleBackColor = true;
            // 
            // DtpDateTime
            // 
            this.DtpDateTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DtpDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDateTime.Location = new System.Drawing.Point(117, 34);
            this.DtpDateTime.Name = "DtpDateTime";
            this.DtpDateTime.Size = new System.Drawing.Size(175, 23);
            this.DtpDateTime.TabIndex = 0;
            this.DtpDateTime.ValueChanged += new System.EventHandler(this.DtpDateTime_ValueChanged);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // BuildingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 688);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuildingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据建造示范窗体";
            this.Load += new System.EventHandler(this.BuildingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
		private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnToDateTime;
        private System.Windows.Forms.Button BtnToTimestamp;
        private System.Windows.Forms.TextBox TxtTimestamp;
        private System.Windows.Forms.RadioButton RdoTypeMilliseconds;
        private System.Windows.Forms.RadioButton RdoTypeSeconds;
        private System.Windows.Forms.DateTimePicker DtpDateTime;
        private System.Windows.Forms.TextBox TxtDateTime;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}