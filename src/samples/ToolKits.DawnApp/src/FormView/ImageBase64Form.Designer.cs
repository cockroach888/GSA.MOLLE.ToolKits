
namespace GSA.ToolKits.DawnApp.FormView
{
    partial class ImageBase64Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageBase64Form));
            this.btnToBase64 = new System.Windows.Forms.Button();
            this.picFormBase64 = new System.Windows.Forms.PictureBox();
            this.btnFormBase64 = new System.Windows.Forms.Button();
            this.picToBase64 = new System.Windows.Forms.PictureBox();
            this.btnFileBrowser = new System.Windows.Forms.Button();
            this.txtFileSource = new System.Windows.Forms.TextBox();
            this.txtBase64String = new System.Windows.Forms.RichTextBox();
            this.lblBase64Length = new System.Windows.Forms.Label();
            this.btnClearBase64String = new System.Windows.Forms.Button();
            this.btnBase64StringLength = new System.Windows.Forms.Button();
            this.chkIsVarbinary = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picFormBase64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToBase64)).BeginInit();
            this.SuspendLayout();
            // 
            // btnToBase64
            // 
            this.btnToBase64.Location = new System.Drawing.Point(160, 636);
            this.btnToBase64.Name = "btnToBase64";
            this.btnToBase64.Size = new System.Drawing.Size(105, 42);
            this.btnToBase64.TabIndex = 0;
            this.btnToBase64.Text = "ToBase64";
            this.btnToBase64.UseVisualStyleBackColor = true;
            this.btnToBase64.Click += new System.EventHandler(this.btnToBase64_Click);
            // 
            // picFormBase64
            // 
            this.picFormBase64.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.QQ图片20200714134108;
            this.picFormBase64.Location = new System.Drawing.Point(382, 271);
            this.picFormBase64.Name = "picFormBase64";
            this.picFormBase64.Size = new System.Drawing.Size(540, 407);
            this.picFormBase64.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFormBase64.TabIndex = 2;
            this.picFormBase64.TabStop = false;
            // 
            // btnFormBase64
            // 
            this.btnFormBase64.Location = new System.Drawing.Point(271, 636);
            this.btnFormBase64.Name = "btnFormBase64";
            this.btnFormBase64.Size = new System.Drawing.Size(105, 42);
            this.btnFormBase64.TabIndex = 0;
            this.btnFormBase64.Text = "FromBase64";
            this.btnFormBase64.UseVisualStyleBackColor = true;
            this.btnFormBase64.Click += new System.EventHandler(this.btnFormBase64_Click);
            // 
            // picToBase64
            // 
            this.picToBase64.Image = global::GSA.ToolKits.DawnApp.Properties.Resources.QQ图片20200714134108;
            this.picToBase64.Location = new System.Drawing.Point(12, 271);
            this.picToBase64.Name = "picToBase64";
            this.picToBase64.Size = new System.Drawing.Size(364, 310);
            this.picToBase64.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picToBase64.TabIndex = 3;
            this.picToBase64.TabStop = false;
            // 
            // btnFileBrowser
            // 
            this.btnFileBrowser.Location = new System.Drawing.Point(301, 594);
            this.btnFileBrowser.Name = "btnFileBrowser";
            this.btnFileBrowser.Size = new System.Drawing.Size(75, 25);
            this.btnFileBrowser.TabIndex = 4;
            this.btnFileBrowser.Text = "浏览 (...)";
            this.btnFileBrowser.UseVisualStyleBackColor = true;
            this.btnFileBrowser.Click += new System.EventHandler(this.btnFileBrowser_Click);
            // 
            // txtFileSource
            // 
            this.txtFileSource.Location = new System.Drawing.Point(12, 595);
            this.txtFileSource.Name = "txtFileSource";
            this.txtFileSource.ReadOnly = true;
            this.txtFileSource.Size = new System.Drawing.Size(283, 23);
            this.txtFileSource.TabIndex = 5;
            // 
            // txtBase64String
            // 
            this.txtBase64String.Location = new System.Drawing.Point(12, 12);
            this.txtBase64String.Name = "txtBase64String";
            this.txtBase64String.Size = new System.Drawing.Size(910, 247);
            this.txtBase64String.TabIndex = 6;
            this.txtBase64String.Text = "";
            // 
            // lblBase64Length
            // 
            this.lblBase64Length.AutoSize = true;
            this.lblBase64Length.Location = new System.Drawing.Point(13, 649);
            this.lblBase64Length.Name = "lblBase64Length";
            this.lblBase64Length.Size = new System.Drawing.Size(110, 17);
            this.lblBase64Length.TabIndex = 7;
            this.lblBase64Length.Text = "Base64字符串长度";
            // 
            // btnClearBase64String
            // 
            this.btnClearBase64String.Location = new System.Drawing.Point(805, 20);
            this.btnClearBase64String.Name = "btnClearBase64String";
            this.btnClearBase64String.Size = new System.Drawing.Size(50, 25);
            this.btnClearBase64String.TabIndex = 8;
            this.btnClearBase64String.Text = " 清空";
            this.btnClearBase64String.UseVisualStyleBackColor = true;
            this.btnClearBase64String.Click += new System.EventHandler(this.btnClearBase64String_Click);
            // 
            // btnBase64StringLength
            // 
            this.btnBase64StringLength.Location = new System.Drawing.Point(861, 20);
            this.btnBase64StringLength.Name = "btnBase64StringLength";
            this.btnBase64StringLength.Size = new System.Drawing.Size(50, 25);
            this.btnBase64StringLength.TabIndex = 9;
            this.btnBase64StringLength.Text = " 长度";
            this.btnBase64StringLength.UseVisualStyleBackColor = true;
            this.btnBase64StringLength.Click += new System.EventHandler(this.btnBase64StringLength_Click);
            // 
            // chkIsVarbinary
            // 
            this.chkIsVarbinary.AutoSize = true;
            this.chkIsVarbinary.Location = new System.Drawing.Point(706, 22);
            this.chkIsVarbinary.Name = "chkIsVarbinary";
            this.chkIsVarbinary.Size = new System.Drawing.Size(93, 21);
            this.chkIsVarbinary.TabIndex = 10;
            this.chkIsVarbinary.Text = "IsVarbinary";
            this.chkIsVarbinary.UseVisualStyleBackColor = true;
            this.chkIsVarbinary.Visible = false;
            // 
            // ImageBase64Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 690);
            this.Controls.Add(this.chkIsVarbinary);
            this.Controls.Add(this.btnBase64StringLength);
            this.Controls.Add(this.btnClearBase64String);
            this.Controls.Add(this.lblBase64Length);
            this.Controls.Add(this.txtBase64String);
            this.Controls.Add(this.txtFileSource);
            this.Controls.Add(this.btnFileBrowser);
            this.Controls.Add(this.picToBase64);
            this.Controls.Add(this.picFormBase64);
            this.Controls.Add(this.btnFormBase64);
            this.Controls.Add(this.btnToBase64);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageBase64Form";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片 & Base64 相互转换";
            ((System.ComponentModel.ISupportInitialize)(this.picFormBase64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToBase64)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToBase64;
        private System.Windows.Forms.PictureBox picFormBase64;
        private System.Windows.Forms.Button btnFormBase64;
        private System.Windows.Forms.PictureBox picToBase64;
        private System.Windows.Forms.Button btnFileBrowser;
        private System.Windows.Forms.TextBox txtFileSource;
        private System.Windows.Forms.RichTextBox txtBase64String;
        private System.Windows.Forms.Label lblBase64Length;
        private System.Windows.Forms.Button btnClearBase64String;
        private System.Windows.Forms.Button btnBase64StringLength;
        private System.Windows.Forms.CheckBox chkIsVarbinary;
    }
}
