using System;
using System.Windows.Forms;

namespace GSA.ToolKits.DawnApp.FormView
{
	/// <summary>
	/// 数据建造示范窗体
	/// </summary>
	public partial class BuildingForm : Form
    {
		/// <summary>
		/// 数据建造示范窗体
		/// </summary>
		public BuildingForm()
        {
            InitializeComponent();
        }

		/// <summary>
		/// 窗体加载
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BuildingForm_Load(object sender, EventArgs e)
		{
			this.cboxFormat.SelectedIndex = 0;
		}

		private void btnBuildGUID_Click(object sender, EventArgs e)
		{
			var _format = this.cboxFormat.SelectedItem.ToString();
			var result = Guid.NewGuid().ToString(_format);
			if (chkToUpper.Checked) result = result.ToUpper();
			this.txtHashCode.Text = result.GetHashCode().ToString();
			this.txtGuidCode.Text = result;
		}
	}
}
