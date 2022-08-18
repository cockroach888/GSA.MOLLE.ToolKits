using GSA.ToolKits.CommonUtility;
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
            DtpDateTime.Value = DateTime.Now;
        }

        private void btnBuildGUID_Click(object sender, EventArgs e)
        {
            var _format = this.cboxFormat.SelectedItem.ToString();
            var result = Guid.NewGuid().ToString(_format);
            if (chkToUpper.Checked) result = result.ToUpper();
            this.txtHashCode.Text = result.GetHashCode().ToString();
            this.txtGuidCode.Text = result;
        }



        private TimestampType TimestampType
            => RdoTypeSeconds.Checked ? TimestampType.TotalSeconds : TimestampType.TotalMilliseconds;

        private void DtpDateTime_ValueChanged(object sender, EventArgs e)
        {
            TxtDateTime.Text = $"{DtpDateTime.Value:yyyy-MM-dd HH:mm:ss.ffff}";
        }

        private void BtnToTimestamp_Click(object sender, EventArgs e)
        {
            long value = DateTimeHelper.ConvertToTimestamp(DtpDateTime.Value, TimestampType);
            TxtTimestamp.Text = $"{value}";
        }

        private void BtnToDateTime_Click(object sender, EventArgs e)
        {
            if (long.TryParse(TxtTimestamp.Text.Trim(), out long value))
            {
                DtpDateTime.Value = DateTimeHelper.ConvertToDateTime(value, TimestampType);
            }
        }
    }
}