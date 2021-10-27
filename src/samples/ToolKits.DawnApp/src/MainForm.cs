using GSA.ToolKits.DawnUtility;
using GSA.ToolKits.FormUtility;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GSA.ToolKits.DawnApp
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// 闪屏窗体
        /// </summary>
        private SplashScreen _splash;
        /// <summary>
        /// 日志记录器
        /// </summary>
        //private LogHelper _logger;

        /// <summary>
        /// 主窗体
        /// </summary>
        public MainForm()
        {
            #region SplashScreen·Begin
            this.Hide();
            _splash = SplashScreen.Begin();
            _splash.MsgUpdate("主窗体加载中...");
            Thread.Sleep(100);
            #endregion
            InitializeComponent();
            InitializeThis();
            #region SplashScreen·End
            SplashScreen.End();
            _splash = null;
            this.Show();
            this.Activate();
            #endregion
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitializeThis()
        {
            _splash.MsgUpdate("初始化基础数据...");
            Thread.Sleep(200);
            this.Text = Core.ConfigHelper.AppName;
            //_splash.MsgUpdate("初始化日志记录器...");
            //Thread.Sleep(100);
            //_logger = new LogHelper();
            _splash.MsgUpdate("提示信息初始化...");
            Thread.Sleep(200);
            SetTips();
            _splash.MsgUpdate("模块加载中...");
            Thread.Sleep(200);
        }

        #region 窗体事件

        /// <summary>
        /// 窗体加载时
        /// </summary>
        /// <param name="sender">传送对象</param>
        /// <param name="e">传送事件</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            FEffects.ShowEff(this.Handle, 500, FEffects.AW_ACTIVATE | FEffects.AW_CENTER);
        }
        /// <summary>
        /// 窗体显示时
        /// </summary>
        /// <param name="sender">传送对象</param>
        /// <param name="e">传送事件</param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            //_logger.Write("程序启动。");
            var _now = DateTime.Now;
            var _week = DateHelper.WeekOfCurrent(_now, false);
            DateTime firstDate = DateTime.MinValue, endDate = DateTime.MaxValue;
            DateHelper.WeekOfDate(_now.Year, _week, false, out firstDate, out endDate);
            this.lblWeekInfo.Text = string.Format("{0}年第{1}周从{2}至{3}。", _now.Year, _week, firstDate, endDate);
            lstWeekList.DataSource = DateHelper.WeekOfList(_now.Year, false);
        }
        /// <summary>
        /// 窗体关闭时
        /// </summary>
        /// <param name="sender">传送对象</param>
        /// <param name="e">传送事件</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("您确定要退出本系统吗？", "【晨曦小竹·工具集】提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CloseAllForm();

                if (!IsDisposed)
                {
                    FEffects.ShowEff(this.Handle, 500, FEffects.AW_HIDE | FEffects.AW_BLEND);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 窗体结束时
        /// </summary>
        /// <param name="sender">传送对象</param>
        /// <param name="e">传送事件</param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //_logger.Write("程序关闭。");
        }

        /// <summary>
        /// 关闭所有已经打开的子窗体
        /// </summary>
        private void CloseAllForm()
        {
            if (this.MdiChildren.Length > 0)
            {
                foreach (Form myFrm in this.MdiChildren)
                {
                    myFrm.Close();
                    myFrm.Dispose();
                }
            }
        }
        //检查是否存在当前窗口，私有方法
        private bool CheckChildForm(string frmName)
        {
            foreach (Form childFrm in this.MdiChildren)
            {
                //用子窗体的名称进行判断，如果存在则将他激活
                if (childFrm.Name == frmName)
                {
                    if (childFrm.WindowState == FormWindowState.Minimized)
                    {
                        childFrm.WindowState = FormWindowState.Normal;
                    }
                    childFrm.Activate();
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region 成员方法

        /// <summary>
        /// 消息显示器
        /// </summary>
        /// <param name="msgInfo">消息文本</param>
        /// <param name="msgFlag">
        /// 消息标记
        /// <para>1信息</para>
        /// <para>2错误</para>
        /// <para>3问题</para>
        /// <para>4警告</para>
        /// </param>
        private void ShowMsg(string msgInfo, byte msgFlag = 1)
        {
            switch (msgFlag)
            {
                case 1:
                    MessageBox.Show(msgInfo, "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show(msgInfo, "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3:
                    MessageBox.Show(msgInfo, "消息", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    break;
                case 4:
                    MessageBox.Show(msgInfo, "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        #endregion

        #region 成员按钮事件

        #region 按钮提示事件

        /// <summary>
        /// 按钮提示信息设定
        /// </summary>
        private void SetTips()
        {
            //数据加/解密[通用版]
            var tips01 = new ToolTip();
            tips01.AutoPopDelay = 5000;
            tips01.InitialDelay = 1000;
            tips01.ReshowDelay = 500;
            tips01.ShowAlways = true;
            tips01.SetToolTip(this.btnDesencrypt, "数据加/解密[通用版]");
            //数据加/解密[通用版]
            var tips02 = new ToolTip();
            tips02.AutoPopDelay = 5000;
            tips02.InitialDelay = 1000;
            tips02.ReshowDelay = 500;
            tips02.ShowAlways = true;
            tips02.SetToolTip(this.btnDesencryptAll, "数据加/解密[定制版]");
            //数据验证测试
            var tips03 = new ToolTip();
            tips03.AutoPopDelay = 5000;
            tips03.InitialDelay = 1000;
            tips03.ReshowDelay = 500;
            tips03.ShowAlways = true;
            tips03.SetToolTip(this.btnTest, "数据验证测试");
            //特殊数据构建
            var tips04 = new ToolTip();
            tips04.AutoPopDelay = 5000;
            tips04.InitialDelay = 1000;
            tips04.ReshowDelay = 500;
            tips04.ShowAlways = true;
            tips04.SetToolTip(this.btnBuilding, "特殊数据构建");
            //非对称RSA数据加解密
            var tips05 = new ToolTip();
            tips05.AutoPopDelay = 5000;
            tips05.InitialDelay = 1000;
            tips05.ReshowDelay = 500;
            tips05.ShowAlways = true;
            tips05.SetToolTip(this.btnRSAHelper, "非对称RSA数据加解密");
            //MongoDB
            var tips06 = new ToolTip();
            tips06.AutoPopDelay = 5000;
            tips06.InitialDelay = 1000;
            tips06.ReshowDelay = 500;
            tips06.ShowAlways = true;
            tips06.SetToolTip(this.btnMongoDB, "MongoDB数据库演示中心");
            //原子式磁场
            var tips07 = new ToolTip();
            tips07.AutoPopDelay = 5000;
            tips07.InitialDelay = 1000;
            tips07.ReshowDelay = 500;
            tips07.ShowAlways = true;
            tips07.SetToolTip(this.btnNuclear, "原子式磁场演示中心(FTP、Email...)");
        }

        #endregion

        #region 按钮执行事件

        /// <summary>
        /// 加/解密[通用版]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesencrypt_Click(object sender, EventArgs e)
        {
            if (!CheckChildForm("DESEncryptForm"))
            {
                var tmpFrm = new FormView.DESEncryptForm();
                tmpFrm.MdiParent = this;
                tmpFrm.Show();
            }
        }
        /// <summary>
        /// 加/解密[定制版]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesencryptAll_Click(object sender, EventArgs e)
        {
            if (!CheckChildForm("DESEncryptCustomForm"))
            {
                var tmpFrm = new FormView.DESEncryptCustomForm();
                tmpFrm.MdiParent = this;
                tmpFrm.Show();
            }
        }
        /// <summary>
        /// 验证测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            if (!CheckChildForm("TestForm"))
            {
                var tmpFrm = new FormView.TestForm();
                tmpFrm.MdiParent = this;
                tmpFrm.Show();
            }
        }
        /// <summary>
        /// 数据构建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuilding_Click(object sender, EventArgs e)
        {
            if (!CheckChildForm("BuildingForm"))
            {
                var tmpFrm = new FormView.BuildingForm();
                tmpFrm.MdiParent = this;
                tmpFrm.Show();
            }
        }
        /// <summary>
        /// 非对称RSA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRSAHelper_Click(object sender, EventArgs e)
        {
            if (!CheckChildForm("RSAHelperForm"))
            {
                var tmpFrm = new FormView.RSAHelperForm();
                tmpFrm.MdiParent = this;
                tmpFrm.Show();
            }
        }
        /// <summary>
        /// MongoDB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMongoDB_Click(object sender, EventArgs e)
        {
            if (!CheckChildForm("MongoDBForm"))
            {
                var tmpFrm = new FormView.MongoDBForm();
                tmpFrm.MdiParent = this;
                tmpFrm.Show();
            }
        }
        /// <summary>
        /// 原子式磁场
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuclear_Click(object sender, EventArgs e)
        {
            if (!CheckChildForm("NuclearForm"))
            {
                var tmpFrm = new FormView.NuclearForm();
                tmpFrm.MdiParent = this;
                tmpFrm.Show();
            }
        }
        /// <summary>
        /// 图片Base64相互转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImageBase64_Click(object sender, EventArgs e)
        {
            if (!CheckChildForm("ImageBase64Form"))
            {
                var tmpFrm = new FormView.ImageBase64Form();
                tmpFrm.MdiParent = this;
                tmpFrm.Show();
            }
        }

        #endregion

        /// <summary>
        /// 显示/隐藏某框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowHideBox_Click(object sender, EventArgs e)
        {
            lstWeekList.Visible = !lstWeekList.Visible;
            lblWeekInfo.Visible = !lblWeekInfo.Visible;
        }

        #endregion

    }
}
