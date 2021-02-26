namespace GSA.ToolKits.DawnApp
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
            this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.btnNuclear = new System.Windows.Forms.Button();
			this.btnRSAHelper = new System.Windows.Forms.Button();
			this.btnMongoDB = new System.Windows.Forms.Button();
			this.btnBuilding = new System.Windows.Forms.Button();
			this.btnTest = new System.Windows.Forms.Button();
			this.btnDesencryptAll = new System.Windows.Forms.Button();
			this.btnDesencrypt = new System.Windows.Forms.Button();
			this.lblWeekInfo = new System.Windows.Forms.Label();
			this.lstWeekList = new System.Windows.Forms.ListBox();
			this.btnShowHideBox = new System.Windows.Forms.Button();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.LightSlateGray;
			this.toolStripContainer1.ContentPanel.Controls.Add(this.btnShowHideBox);
			this.toolStripContainer1.ContentPanel.Controls.Add(this.btnNuclear);
			this.toolStripContainer1.ContentPanel.Controls.Add(this.btnRSAHelper);
			this.toolStripContainer1.ContentPanel.Controls.Add(this.btnMongoDB);
			this.toolStripContainer1.ContentPanel.Controls.Add(this.btnBuilding);
			this.toolStripContainer1.ContentPanel.Controls.Add(this.btnTest);
			this.toolStripContainer1.ContentPanel.Controls.Add(this.btnDesencryptAll);
			this.toolStripContainer1.ContentPanel.Controls.Add(this.btnDesencrypt);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1018, 107);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.toolStripContainer1.LeftToolStripPanelVisible = false;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 544);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.RightToolStripPanelVisible = false;
			this.toolStripContainer1.Size = new System.Drawing.Size(1018, 107);
			this.toolStripContainer1.TabIndex = 1;
			this.toolStripContainer1.Text = "toolStripContainer1";
			this.toolStripContainer1.TopToolStripPanelVisible = false;
			// 
			// btnNuclear
			// 
			this.btnNuclear.BackColor = System.Drawing.Color.White;
			this.btnNuclear.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.btnNuclear.ForeColor = System.Drawing.Color.Black;
			this.btnNuclear.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.ico07;
			this.btnNuclear.Location = new System.Drawing.Point(672, 8);
			this.btnNuclear.Name = "btnNuclear";
			this.btnNuclear.Size = new System.Drawing.Size(94, 90);
			this.btnNuclear.TabIndex = 5;
			this.btnNuclear.Text = "原子式磁场";
			this.btnNuclear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnNuclear.UseVisualStyleBackColor = false;
			this.btnNuclear.Click += new System.EventHandler(this.btnNuclear_Click);
			// 
			// btnRSAHelper
			// 
			this.btnRSAHelper.BackColor = System.Drawing.Color.White;
			this.btnRSAHelper.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.btnRSAHelper.ForeColor = System.Drawing.Color.Black;
			this.btnRSAHelper.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.ico05;
			this.btnRSAHelper.Location = new System.Drawing.Point(452, 8);
			this.btnRSAHelper.Name = "btnRSAHelper";
			this.btnRSAHelper.Size = new System.Drawing.Size(94, 90);
			this.btnRSAHelper.TabIndex = 4;
			this.btnRSAHelper.Text = "非对称RSA";
			this.btnRSAHelper.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnRSAHelper.UseVisualStyleBackColor = false;
			this.btnRSAHelper.Click += new System.EventHandler(this.btnRSAHelper_Click);
			// 
			// btnMongoDB
			// 
			this.btnMongoDB.BackColor = System.Drawing.Color.White;
			this.btnMongoDB.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.btnMongoDB.ForeColor = System.Drawing.Color.Black;
			this.btnMongoDB.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.ico06;
			this.btnMongoDB.Location = new System.Drawing.Point(562, 8);
			this.btnMongoDB.Name = "btnMongoDB";
			this.btnMongoDB.Size = new System.Drawing.Size(94, 90);
			this.btnMongoDB.TabIndex = 3;
			this.btnMongoDB.Text = "MongoDB";
			this.btnMongoDB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnMongoDB.UseVisualStyleBackColor = false;
			this.btnMongoDB.Click += new System.EventHandler(this.btnMongoDB_Click);
			// 
			// btnBuilding
			// 
			this.btnBuilding.BackColor = System.Drawing.Color.White;
			this.btnBuilding.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.btnBuilding.ForeColor = System.Drawing.Color.Black;
			this.btnBuilding.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.ico04;
			this.btnBuilding.Location = new System.Drawing.Point(342, 8);
			this.btnBuilding.Name = "btnBuilding";
			this.btnBuilding.Size = new System.Drawing.Size(94, 90);
			this.btnBuilding.TabIndex = 3;
			this.btnBuilding.Text = "数据构建";
			this.btnBuilding.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnBuilding.UseVisualStyleBackColor = false;
			this.btnBuilding.Click += new System.EventHandler(this.btnBuilding_Click);
			// 
			// btnTest
			// 
			this.btnTest.BackColor = System.Drawing.Color.White;
			this.btnTest.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.btnTest.ForeColor = System.Drawing.Color.Black;
			this.btnTest.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.ico03;
			this.btnTest.Location = new System.Drawing.Point(232, 8);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(94, 90);
			this.btnTest.TabIndex = 2;
			this.btnTest.Text = "验证测试";
			this.btnTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnTest.UseVisualStyleBackColor = false;
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// btnDesencryptAll
			// 
			this.btnDesencryptAll.BackColor = System.Drawing.Color.White;
			this.btnDesencryptAll.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.btnDesencryptAll.ForeColor = System.Drawing.Color.Black;
			this.btnDesencryptAll.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.ico02;
			this.btnDesencryptAll.Location = new System.Drawing.Point(122, 8);
			this.btnDesencryptAll.Name = "btnDesencryptAll";
			this.btnDesencryptAll.Size = new System.Drawing.Size(94, 90);
			this.btnDesencryptAll.TabIndex = 1;
			this.btnDesencryptAll.Text = "加/解密[定]";
			this.btnDesencryptAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnDesencryptAll.UseVisualStyleBackColor = false;
			this.btnDesencryptAll.Click += new System.EventHandler(this.btnDesencryptAll_Click);
			// 
			// btnDesencrypt
			// 
			this.btnDesencrypt.BackColor = System.Drawing.Color.White;
			this.btnDesencrypt.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.btnDesencrypt.ForeColor = System.Drawing.Color.Black;
			this.btnDesencrypt.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.ico01;
			this.btnDesencrypt.Location = new System.Drawing.Point(12, 8);
			this.btnDesencrypt.Name = "btnDesencrypt";
			this.btnDesencrypt.Size = new System.Drawing.Size(94, 90);
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
			this.lblWeekInfo.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblWeekInfo.Location = new System.Drawing.Point(75, 515);
			this.lblWeekInfo.Name = "lblWeekInfo";
			this.lblWeekInfo.Size = new System.Drawing.Size(31, 26);
			this.lblWeekInfo.TabIndex = 3;
			this.lblWeekInfo.Text = "周";
			// 
			// lstWeekList
			// 
			this.lstWeekList.BackColor = System.Drawing.Color.Silver;
			this.lstWeekList.FormattingEnabled = true;
			this.lstWeekList.ItemHeight = 12;
			this.lstWeekList.Location = new System.Drawing.Point(80, 12);
			this.lstWeekList.Name = "lstWeekList";
			this.lstWeekList.Size = new System.Drawing.Size(581, 496);
			this.lstWeekList.TabIndex = 4;
			// 
			// btnShowHideBox
			// 
			this.btnShowHideBox.Location = new System.Drawing.Point(940, 81);
			this.btnShowHideBox.Name = "btnShowHideBox";
			this.btnShowHideBox.Size = new System.Drawing.Size(75, 23);
			this.btnShowHideBox.TabIndex = 6;
			this.btnShowHideBox.Text = "显示/隐藏";
			this.btnShowHideBox.UseVisualStyleBackColor = true;
			this.btnShowHideBox.Click += new System.EventHandler(this.btnShowHideBox_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(85)))), ((int)(((byte)(150)))));
			this.ClientSize = new System.Drawing.Size(1018, 651);
			this.Controls.Add(this.toolStripContainer1);
			this.Controls.Add(this.lstWeekList);
			this.Controls.Add(this.lblWeekInfo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
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
    }
}
