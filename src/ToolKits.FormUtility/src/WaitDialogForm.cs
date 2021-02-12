using System;
using System.Windows.Forms;

namespace DawnXZ.FormUtility
{
    /// <summary>
    /// 加载提示窗口
    /// </summary>
    public partial class WaitDialogForm : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public WaitDialogForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tipsInfo">提示信息</param>
        public WaitDialogForm(string tipsInfo)
        {
            InitializeComponent();
            this.lblTipsInfo.Text = tipsInfo;
        }
    }
}
