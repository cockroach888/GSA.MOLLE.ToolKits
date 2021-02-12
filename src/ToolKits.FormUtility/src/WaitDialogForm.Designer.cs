namespace DawnXZ.FormUtility
{
    partial class WaitDialogForm
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
            this.lblTipsInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTipsInfo
            // 
            this.lblTipsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTipsInfo.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTipsInfo.ForeColor = System.Drawing.Color.White;
            this.lblTipsInfo.Location = new System.Drawing.Point(0, 0);
            this.lblTipsInfo.Name = "lblTipsInfo";
            this.lblTipsInfo.Size = new System.Drawing.Size(450, 50);
            this.lblTipsInfo.TabIndex = 0;
            this.lblTipsInfo.Text = "提示信息...";
            this.lblTipsInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadingDlgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(85)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(450, 50);
            this.ControlBox = false;
            this.Controls.Add(this.lblTipsInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadingDlgForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTipsInfo;
    }
}