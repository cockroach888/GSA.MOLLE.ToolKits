using GSA.ToolKits.DawnUtility;
using GSA.ToolKits.FormUtility;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GSA.ToolKits.DawnApp
{
    /// <summary>
    /// 登录窗体
    /// </summary>
    public partial class LoginForm : Form
    {
        /// <summary>
        /// 关闭标识
        /// </summary>
        private bool _closeFlag = false;
        /// <summary>
        /// 验证码
        /// </summary>
        private string _checkCode = string.Empty;
        /// <summary>
        /// 登录窗体
        /// </summary>
        private static LoginForm _loginForm;

        /// <summary>
        /// 登录窗体
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitializeThis()
        {
            this._checkCode = CheckCodeHelper.GetChs(4);
            this.Text = Core.ConfigHelper.AppName;
            this.picCoder.Image = CheckCodeHelper.CreateToImage(this._checkCode, true, false);
        }

        #region 窗体事件

        /// <summary>
        /// 窗体加载时
        /// </summary>
        /// <param name="sender">传送对象</param>
        /// <param name="e">传送事件</param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            Text = Core.ConfigHelper.AppName;
            FEffects.ShowEff(this.Handle, 500, FEffects.AW_ACTIVATE | FEffects.AW_CENTER);
        }
        /// <summary>
        /// 窗体显示时
        /// </summary>
        /// <param name="sender">传送对象</param>
        /// <param name="e">传送事件</param>
        private void LoginForm_Shown(object sender, EventArgs e)
        {
            // do something.
        }
        /// <summary>
        /// 窗体关闭时
        /// </summary>
        /// <param name="sender">传送对象</param>
        /// <param name="e">传送事件</param>
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(string.Format("您确定要退出【{0}】吗？", Core.ConfigHelper.AppName), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this._closeFlag = true;
                e.Cancel = false;
                FEffects.ShowEff(this.Handle, 500, FEffects.AW_HIDE | FEffects.AW_BLEND);
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
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            if (this._closeFlag)
            {
                Application.ExitThread();
                Application.Exit();
            }
        }

        #endregion

        #region 登录窗体状态

        /// <summary>
        /// 登录开始
        /// </summary>
        /// <returns></returns>
        public static LoginForm Begin()
        {
            if (_loginForm == null)
            {
                _loginForm = new LoginForm();
            }
            Thread td = new Thread(_loginForm.ShowFormLogin);
            td.IsBackground = true;
            td.Start();
            return _loginForm;
        }
        /// <summary>
        /// 登录结束
        /// </summary>
        public static void End()
        {
            _loginForm.CloseFormLogin();
        }
        /// <summary>
        /// 显示登录窗体
        /// </summary>
        public void ShowFormLogin()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(ShowFormLogin));
                return;
            }
            this.Show();
            Application.Run(this);
        }
        /// <summary>
        /// 关闭登录窗体
        /// </summary>
        public void CloseFormLogin()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(CloseFormLogin));
                return;
            }
            this.Close();
        }

        #endregion

        /// <summary>
        /// 登录事件
        /// </summary>
        /// <param name="sender">传送对象</param>
        /// <param name="e">传送方法</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("系统生成的验证码：{0}", this._checkCode), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show(string.Format("您输入的验证码：{0}", this.txtCoder.Text), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("登录成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
