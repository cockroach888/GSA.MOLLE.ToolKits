using GSA.ToolKits.FormUtility;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GSA.ToolKits.DawnApp
{
    /// <summary>
    /// 闪屏界面
    /// </summary>
    public partial class SplashScreen : Form
    {
		/// <summary>
		/// 关闭标识
		/// </summary>
		private bool FCloseFlag = false;
		/// <summary>
		/// 闪屏窗体
		/// </summary>
		private static SplashScreen FSSC;

		/// <summary>
		/// 闪屏界面
		/// </summary>
		public SplashScreen()
        {
            InitializeComponent();
        }

		#region 窗体事件

		/// <summary>
		/// 窗体加载时
		/// </summary>
		/// <param name="sender">传送对象</param>
		/// <param name="e">传送事件</param>
		private void SplashScreen_Load(object sender, EventArgs e)
		{
			Text = Core.ConfigHelper.AppName;
			lblTitle.Text = this.Text;
			lblVer.Text = Core.ConfigHelper.AppVersion;
			FEffects.ShowEff(Handle, 500, FEffects.AW_ACTIVATE | FEffects.AW_CENTER);
		}
		/// <summary>
		/// 窗体显示时
		/// </summary>
		/// <param name="sender">传送对象</param>
		/// <param name="e">传送事件</param>
		private void SplashScreen_Shown(object sender, EventArgs e)
		{
			// do something.
		}
		/// <summary>
		/// 窗体关闭时
		/// </summary>
		/// <param name="sender">传送对象</param>
		/// <param name="e">传送事件</param>
		private void SplashScreen_FormClosing(object sender, FormClosingEventArgs e)
		{
			FEffects.ShowEff(Handle, 500, FEffects.AW_HIDE | FEffects.AW_BLEND);
			if (!FCloseFlag)
			{
				e.Cancel = true;
			}
		}
		/// <summary>
		/// 窗体结束时
		/// </summary>
		/// <param name="sender">传送对象</param>
		/// <param name="e">传送事件</param>
		private void SplashScreen_FormClosed(object sender, FormClosedEventArgs e)
		{
			Dispose();
		}

		#endregion

		#region 闪屏窗体状态

		/// <summary>
		/// 闪屏开始
		/// </summary>
		/// <returns></returns>
		public static SplashScreen Begin()
		{
			if (FSSC == null)
			{
				FSSC = new SplashScreen();
			}
			Thread td = new Thread(FSSC.ShowSplashScreen);
			td.IsBackground = true;
			td.Start();
			return FSSC;
		}
		/// <summary>
		/// 闪屏结束
		/// </summary>
		public static void End()
		{
			FSSC.CloseSplashScreen();
		}
		/// <summary>
		/// 显示闪屏窗体
		/// </summary>
		public void ShowSplashScreen()
		{
			if (InvokeRequired)
			{
				BeginInvoke(new Action(ShowSplashScreen));
				return;
			}
			Show();
			Application.Run(this);
		}
		/// <summary>
		/// 关闭闪屏窗体
		/// </summary>
		public void CloseSplashScreen()
		{
			if (InvokeRequired)
			{
				BeginInvoke(new Action(CloseSplashScreen));
				return;
			}
			FCloseFlag = true;
			Close();
		}

		#endregion

		#region 闪屏消息容器

		/// <summary>
		/// 显示指定消息内容
		/// </summary>
		/// <param name="strText">消息内容</param>
		public void MsgUpdate(string strText)
		{
			MsgUpdate(strText, MessageStatus.Success);
		}
		/// <summary>
		/// 显示指定消息内容
		/// </summary>
		/// <param name="strText">消息内容</param>
		/// <param name="msta">消息状态</param>
		public void MsgUpdate(string strText, MessageStatus msta)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new Action<string, MessageStatus>(MsgUpdate), new object[] { strText, msta });
				return;
			}
			switch (msta)
			{
				case MessageStatus.Error:
					lblInfo.ForeColor = Color.Red;
					break;
				case MessageStatus.Warning:
					lblInfo.ForeColor = Color.Yellow;
					break;
				case MessageStatus.Success:
					lblInfo.ForeColor = Color.White;
					break;
			}
			lblInfo.Text = strText;
		}

		#endregion

		#region 闪屏消息状态

		/// <summary>
		/// 消息状态
		/// </summary>
		public enum MessageStatus
		{
			/// <summary>
			/// 成功
			/// </summary>
			Success,
			/// <summary>
			/// 警告
			/// </summary>
			Warning,
			/// <summary>
			/// 错误
			/// </summary>
			Error,
		}

		#endregion

	}
}
