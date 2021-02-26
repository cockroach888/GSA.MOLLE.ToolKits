using System;
using System.Windows.Forms;
using GSA.ToolKits.VerifyUtility;

namespace GSA.ToolKits.DawnApp.FormView
{
	/// <summary>
	/// 数据校验验证窗体
	/// </summary>
	public partial class TestForm : Form
    {
		/// <summary>
		/// 数据校验验证窗体
		/// </summary>
		public TestForm()
        {
            InitializeComponent();
        }

		/// <summary>
		/// 电话号码
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEnter_Click(object sender, EventArgs e)
		{
			string strValue = this.cboxPhone.SelectedItem as string;
			bool checkFlag = false;
			switch (strValue)
			{
				case "电话号码":
					checkFlag = ValidHelper.TelIsTelephone(this.txtMobile.Text);
					break;
				case "中国移动":
					checkFlag = ValidHelper.TelIsChinaMobile(this.txtMobile.Text);
					break;
				case "中国联通":
					checkFlag = ValidHelper.TelIsChinaUnicom(this.txtMobile.Text);
					break;
				case "中国电信":
					checkFlag = ValidHelper.TelIsChinaTelecom(this.txtMobile.Text);
					break;
				default:
					break;
			}
			this.lblResultPhone.Text = checkFlag.ToString();
		}
		/// <summary>
		/// 电子邮箱
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEmail_Click(object sender, EventArgs e)
		{
			this.lblResultEmail.Text = ValidHelper.IsEmail(this.txtEmail.Text).ToString();
		}
		/// <summary>
		/// 字符串验证
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnString_Click(object sender, EventArgs e)
		{
			string strValue = this.cboxString.SelectedItem as string;
			bool checkFlag = false;
			switch (strValue)
			{
				case "用户密码":
					checkFlag = ValidHelper.EngIsPassword(this.txtString.Text);
					break;
				case "用户密码2":
					checkFlag = ValidHelper.EngIsPasswords(this.txtString.Text);
					break;
				case "注册帐号":
					checkFlag = ValidHelper.EngIsRegister(this.txtString.Text);
					break;
				case "26个字母":
					checkFlag = ValidHelper.EngIsEnglish(this.txtString.Text);
					break;
				case "大写字母":
					checkFlag = ValidHelper.EngIsUppercase(this.txtString.Text);
					break;
				case "小写字母":
					checkFlag = ValidHelper.EngIsLowercase(this.txtString.Text);
					break;
				case "字母数字":
					checkFlag = ValidHelper.EngIsEngAndNum(this.txtString.Text);
					break;
				case "英头数字":
					checkFlag = ValidHelper.EngIsEngAndNums(this.txtString.Text);
					break;
				case "字数下线":
					checkFlag = ValidHelper.EngIsEngAndNumOrUnderline(this.txtString.Text);
					break;
				default:
					break;
			}
			this.lblResultString.Text = checkFlag.ToString();
		}
		/// <summary>
		/// 中文汉字
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnChinese_Click(object sender, EventArgs e)
		{
			string strValue = this.cboxChinese.SelectedItem as string;
			bool checkFlag = false;
			switch (strValue)
			{
				case "中文汉字":
					checkFlag = ValidHelper.ChsIsChinese(this.txtChinese.Text);
					break;
				case "中字母数":
					checkFlag = ValidHelper.ChsIsChineseOrEngOrNum(this.txtChinese.Text);
					break;
				case "真实姓名":
					checkFlag = ValidHelper.ChsIsTname(this.txtChinese.Text);
					break;
				case "半角转换":
					this.lblResultChinese.Text = string.Format("　{0}", ValidHelper.ChsToDBC(this.txtChinese.Text));
					break;
				default:
					break;
			}
			this.lblResultChinese.Text = checkFlag.ToString();
		}
		/// <summary>
		/// SQL注入
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSqlInjection_Click(object sender, EventArgs e)
		{
			string strValue = this.cboxSqlInjection.SelectedItem as string;
			bool checkFlag = false;
			switch (strValue)
			{
				case "四方法合一":
					checkFlag = ValidHelper.IsSqlFilter(this.txtSqlInjection.Text);
					break;
				case "SQL关键字":
					checkFlag = ValidHelper.IsSqlInjectionOfKey(this.txtSqlInjection.Text);
					break;
				case "SQL数据类型":
					checkFlag = ValidHelper.IsSqlInjectionOfType(this.txtSqlInjection.Text);
					break;
				case "SQL危险命令":
					checkFlag = ValidHelper.IsSqlInjectionOfURL(this.txtSqlInjection.Text);
					break;
				case "SQL危险字符":
					checkFlag = ValidHelper.IsSqlInjectionOfString(this.txtSqlInjection.Text);
					break;
				default:
					break;
			}
			this.lblResultSqlInjection.Text = checkFlag.ToString();
		}
		/// <summary>
		/// IP地址
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnIpAdress_Click(object sender, EventArgs e)
		{
			string strValue = this.cboxIpAdress.SelectedItem as string;
			bool checkFlag = false;
			switch (strValue)
			{
				case "常规IP地址":
					checkFlag = ValidHelper.IsIP(this.txtIpAdress.Text);
					break;
				case "IPSect":
					checkFlag = ValidHelper.IsIPSect(this.txtIpAdress.Text);
					break;
				default:
					break;
			}
			this.lblResultIpAdress.Text = checkFlag.ToString();
		}
		/// <summary>
		/// 数字校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnNumeral_Click(object sender, EventArgs e)
		{
			string strValue = this.cboxNumeral.SelectedItem as string;
			bool checkFlag = false;
			switch (strValue)
			{
				case "纯数字":
					checkFlag = ValidHelper.NumIsInteger(this.txtNumeral.Text);
					break;
				case "零和非零":
					checkFlag = ValidHelper.NumIsZeroOrNot(this.txtNumeral.Text);
					break;
				case "正数两位小数":
					checkFlag = ValidHelper.NumIsPlus2Point(this.txtNumeral.Text);
					break;
				case "正数一至三位":
					checkFlag = ValidHelper.NumIsPlus3Point(this.txtNumeral.Text);
					break;
				case "非零正整数":
					checkFlag = ValidHelper.NumIsIntegralBySignless(this.txtNumeral.Text);
					break;
				case "非零负整数":
					checkFlag = ValidHelper.NumIsIntegralByNegative(this.txtNumeral.Text);
					break;
				case "正浮点数":
					checkFlag = ValidHelper.NumIsFloatBySignless(this.txtNumeral.Text);
					break;
				case "负浮点数":
					checkFlag = ValidHelper.NumIsFloatByNegative(this.txtNumeral.Text);
					break;
				case "Int32类型":
					checkFlag = ValidHelper.NumIsNumeric(this.txtNumeral.Text);
					break;
				case "Double类型":
					checkFlag = ValidHelper.NumIsDouble(this.txtNumeral.Text);
					break;
				case "Int32类型逗号":
					checkFlag = ValidHelper.NumIsNumericList(this.txtNumeral.Text);
					break;
				default:
					break;
			}
			this.lblResultNumeral.Text = checkFlag.ToString();
		}
		/// <summary>
		/// 颜色校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnColor_Click(object sender, EventArgs e)
		{
			this.lblResultColor.Text = ValidHelper.IsColor(this.txtColor.Text).ToString();
		}
		/// <summary>
		/// 身份证号码
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnIDCard_Click(object sender, EventArgs e)
		{
			this.lblResultIDCard.Text = ValidHelper.IsIDCard(this.txtIDCard.Text).ToString();
		}
		/// <summary>
		/// 链接地址
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUrl_Click(object sender, EventArgs e)
		{
			this.lblResultUrl.Text = ValidHelper.IsURL(this.txtUrl.Text).ToString();
		}
		/// <summary>
		/// 邮政编码
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPost_Click(object sender, EventArgs e)
		{
			this.lblResultPost.Text = ValidHelper.IsPost(this.txtPost.Text).ToString();
		}
	}
}
