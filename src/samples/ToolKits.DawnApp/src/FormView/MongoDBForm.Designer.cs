
namespace GSA.ToolKits.DawnApp.FormView
{
    partial class MongoDBForm
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btnLoadMongo = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 70);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(775, 404);
			this.dataGridView1.TabIndex = 0;
			// 
			// btnLoadMongo
			// 
			this.btnLoadMongo.Location = new System.Drawing.Point(672, 24);
			this.btnLoadMongo.Name = "btnLoadMongo";
			this.btnLoadMongo.Size = new System.Drawing.Size(115, 25);
			this.btnLoadMongo.TabIndex = 11;
			this.btnLoadMongo.Text = "加载MongoDB数据";
			this.btnLoadMongo.UseVisualStyleBackColor = true;
			this.btnLoadMongo.Click += new System.EventHandler(this.btnLoadMongo_Click);
			// 
			// MongoDBForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(799, 486);
			this.Controls.Add(this.btnLoadMongo);
			this.Controls.Add(this.dataGridView1);
			this.Name = "MongoDBForm";
			this.Text = "MongoDB数据库示范窗体";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
		}

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoadMongo;
    }
}