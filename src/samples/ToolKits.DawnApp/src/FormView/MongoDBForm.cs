using System;
using System.Windows.Forms;

namespace GSA.ToolKits.DawnApp.FormView
{
    /// <summary>
    /// MongoDB数据库示范窗体
    /// </summary>
    public partial class MongoDBForm : Template.TemplateForm
    {
        /// <summary>
        /// MongoDB数据库示范窗体
        /// </summary>
        public MongoDBForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadMongo_Click(object sender, EventArgs e)
        {
            //try
            //{
            //	var data = MongoDBHelper<Entity.CasePartTemplateInfo>.Select<Entity.CasePartTemplateInfo>(Core.ConnHelper.MongoConn, Core.ConnHelper.MongoName, "CasePartTemplate");
            //	this.dataGridView1.DataSource = data;
            //}
            //catch (Exception ex)
            //{
            //	MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
