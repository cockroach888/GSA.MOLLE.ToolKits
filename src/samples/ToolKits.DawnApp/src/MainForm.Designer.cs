﻿namespace GSA.ToolKits.DawnApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.palToolbar = new System.Windows.Forms.Panel();
            this.btnShowHideBox = new System.Windows.Forms.Button();
            this.btnImageBase64 = new System.Windows.Forms.Button();
            this.btnNuclear = new System.Windows.Forms.Button();
            this.btnRSAHelper = new System.Windows.Forms.Button();
            this.btnMongoDB = new System.Windows.Forms.Button();
            this.btnBuilding = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnDesencryptAll = new System.Windows.Forms.Button();
            this.btnDesencrypt = new System.Windows.Forms.Button();
            this.lblWeekInfo = new System.Windows.Forms.Label();
            this.lstWeekList = new System.Windows.Forms.ListBox();
            this.palToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // palToolbar
            // 
            this.palToolbar.BackColor = System.Drawing.Color.LightSlateGray;
            this.palToolbar.Controls.Add(this.btnShowHideBox);
            this.palToolbar.Controls.Add(this.btnImageBase64);
            this.palToolbar.Controls.Add(this.btnNuclear);
            this.palToolbar.Controls.Add(this.btnRSAHelper);
            this.palToolbar.Controls.Add(this.btnMongoDB);
            this.palToolbar.Controls.Add(this.btnBuilding);
            this.palToolbar.Controls.Add(this.btnTest);
            this.palToolbar.Controls.Add(this.btnDesencryptAll);
            this.palToolbar.Controls.Add(this.btnDesencrypt);
            this.palToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.palToolbar.Location = new System.Drawing.Point(0, 770);
            this.palToolbar.Name = "palToolbar";
            this.palToolbar.Size = new System.Drawing.Size(1188, 152);
            this.palToolbar.TabIndex = 1;
            // 
            // btnShowHideBox
            // 
            this.btnShowHideBox.Location = new System.Drawing.Point(1097, 115);
            this.btnShowHideBox.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowHideBox.Name = "btnShowHideBox";
            this.btnShowHideBox.Size = new System.Drawing.Size(88, 33);
            this.btnShowHideBox.TabIndex = 6;
            this.btnShowHideBox.Text = "显示/隐藏";
            this.btnShowHideBox.UseVisualStyleBackColor = true;
            this.btnShowHideBox.Click += new System.EventHandler(this.btnShowHideBox_Click);
            // 
            // btnImageBase64
            // 
            this.btnImageBase64.BackColor = System.Drawing.Color.White;
            this.btnImageBase64.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnImageBase64.ForeColor = System.Drawing.Color.Black;
            this.btnImageBase64.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.ico08;
            this.btnImageBase64.Location = new System.Drawing.Point(912, 11);
            this.btnImageBase64.Margin = new System.Windows.Forms.Padding(4);
            this.btnImageBase64.Name = "btnImageBase64";
            this.btnImageBase64.Size = new System.Drawing.Size(110, 128);
            this.btnImageBase64.TabIndex = 5;
            this.btnImageBase64.Text = "图片 Base64";
            this.btnImageBase64.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImageBase64.UseVisualStyleBackColor = false;
            this.btnImageBase64.Click += new System.EventHandler(this.btnImageBase64_Click);
            // 
            // btnNuclear
            // 
            this.btnNuclear.BackColor = System.Drawing.Color.White;
            this.btnNuclear.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNuclear.ForeColor = System.Drawing.Color.Black;
            this.btnNuclear.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.ico07;
            this.btnNuclear.Location = new System.Drawing.Point(784, 11);
            this.btnNuclear.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuclear.Name = "btnNuclear";
            this.btnNuclear.Size = new System.Drawing.Size(110, 128);
            this.btnNuclear.TabIndex = 5;
            this.btnNuclear.Text = "原子式磁场";
            this.btnNuclear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuclear.UseVisualStyleBackColor = false;
            this.btnNuclear.Click += new System.EventHandler(this.btnNuclear_Click);
            // 
            // btnRSAHelper
            // 
            this.btnRSAHelper.BackColor = System.Drawing.Color.White;
            this.btnRSAHelper.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRSAHelper.ForeColor = System.Drawing.Color.Black;
            this.btnRSAHelper.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.ico05;
            this.btnRSAHelper.Location = new System.Drawing.Point(527, 11);
            this.btnRSAHelper.Margin = new System.Windows.Forms.Padding(4);
            this.btnRSAHelper.Name = "btnRSAHelper";
            this.btnRSAHelper.Size = new System.Drawing.Size(110, 128);
            this.btnRSAHelper.TabIndex = 4;
            this.btnRSAHelper.Text = "非对称RSA";
            this.btnRSAHelper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRSAHelper.UseVisualStyleBackColor = false;
            this.btnRSAHelper.Click += new System.EventHandler(this.btnRSAHelper_Click);
            // 
            // btnMongoDB
            // 
            this.btnMongoDB.BackColor = System.Drawing.Color.White;
            this.btnMongoDB.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMongoDB.ForeColor = System.Drawing.Color.Black;
            this.btnMongoDB.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.ico06;
            this.btnMongoDB.Location = new System.Drawing.Point(656, 11);
            this.btnMongoDB.Margin = new System.Windows.Forms.Padding(4);
            this.btnMongoDB.Name = "btnMongoDB";
            this.btnMongoDB.Size = new System.Drawing.Size(110, 128);
            this.btnMongoDB.TabIndex = 3;
            this.btnMongoDB.Text = "MongoDB";
            this.btnMongoDB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMongoDB.UseVisualStyleBackColor = false;
            this.btnMongoDB.Click += new System.EventHandler(this.btnMongoDB_Click);
            // 
            // btnBuilding
            // 
            this.btnBuilding.BackColor = System.Drawing.Color.White;
            this.btnBuilding.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuilding.ForeColor = System.Drawing.Color.Black;
            this.btnBuilding.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.ico04;
            this.btnBuilding.Location = new System.Drawing.Point(399, 11);
            this.btnBuilding.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuilding.Name = "btnBuilding";
            this.btnBuilding.Size = new System.Drawing.Size(110, 128);
            this.btnBuilding.TabIndex = 3;
            this.btnBuilding.Text = "数据构建";
            this.btnBuilding.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuilding.UseVisualStyleBackColor = false;
            this.btnBuilding.Click += new System.EventHandler(this.btnBuilding_Click);
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.White;
            this.btnTest.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTest.ForeColor = System.Drawing.Color.Black;
            this.btnTest.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.ico03;
            this.btnTest.Location = new System.Drawing.Point(271, 11);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(110, 128);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "验证测试";
            this.btnTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnDesencryptAll
            // 
            this.btnDesencryptAll.BackColor = System.Drawing.Color.White;
            this.btnDesencryptAll.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDesencryptAll.ForeColor = System.Drawing.Color.Black;
            this.btnDesencryptAll.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.ico02;
            this.btnDesencryptAll.Location = new System.Drawing.Point(142, 11);
            this.btnDesencryptAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnDesencryptAll.Name = "btnDesencryptAll";
            this.btnDesencryptAll.Size = new System.Drawing.Size(110, 128);
            this.btnDesencryptAll.TabIndex = 1;
            this.btnDesencryptAll.Text = "加/解密[定]";
            this.btnDesencryptAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDesencryptAll.UseVisualStyleBackColor = false;
            this.btnDesencryptAll.Click += new System.EventHandler(this.btnDesencryptAll_Click);
            // 
            // btnDesencrypt
            // 
            this.btnDesencrypt.BackColor = System.Drawing.Color.White;
            this.btnDesencrypt.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDesencrypt.ForeColor = System.Drawing.Color.Black;
            this.btnDesencrypt.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.ico01;
            this.btnDesencrypt.Location = new System.Drawing.Point(14, 11);
            this.btnDesencrypt.Margin = new System.Windows.Forms.Padding(4);
            this.btnDesencrypt.Name = "btnDesencrypt";
            this.btnDesencrypt.Size = new System.Drawing.Size(110, 128);
            this.btnDesencrypt.TabIndex = 0;
            this.btnDesencrypt.Text = "加/解密[通]";
            this.btnDesencrypt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDesencrypt.UseVisualStyleBackColor = false;
            this.btnDesencrypt.Click += new System.EventHandler(this.btnDesencrypt_Click);
            // 
            // lblWeekInfo
            // 
            this.lblWeekInfo.AutoSize = true;
            this.lblWeekInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblWeekInfo.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWeekInfo.Location = new System.Drawing.Point(88, 730);
            this.lblWeekInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWeekInfo.Name = "lblWeekInfo";
            this.lblWeekInfo.Size = new System.Drawing.Size(31, 26);
            this.lblWeekInfo.TabIndex = 3;
            this.lblWeekInfo.Text = "周";
            // 
            // lstWeekList
            // 
            this.lstWeekList.BackColor = System.Drawing.Color.Silver;
            this.lstWeekList.FormattingEnabled = true;
            this.lstWeekList.ItemHeight = 17;
            this.lstWeekList.Location = new System.Drawing.Point(93, 17);
            this.lstWeekList.Margin = new System.Windows.Forms.Padding(4);
            this.lstWeekList.Name = "lstWeekList";
            this.lstWeekList.Size = new System.Drawing.Size(677, 701);
            this.lstWeekList.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(85)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(1188, 922);
            this.Controls.Add(this.palToolbar);
            this.Controls.Add(this.lstWeekList);
            this.Controls.Add(this.lblWeekInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.palToolbar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel palToolbar;
        private System.Windows.Forms.Button btnDesencrypt;
        private System.Windows.Forms.Button btnDesencryptAll;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnBuilding;
        private System.Windows.Forms.Button btnRSAHelper;
        private System.Windows.Forms.Button btnMongoDB;
        private System.Windows.Forms.Button btnNuclear;
        private System.Windows.Forms.Label lblWeekInfo;
        private System.Windows.Forms.ListBox lstWeekList;
        private System.Windows.Forms.Button btnShowHideBox;
        private System.Windows.Forms.Button btnImageBase64;
    }
}
