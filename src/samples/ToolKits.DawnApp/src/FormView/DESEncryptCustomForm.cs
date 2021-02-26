using System;
using System.Windows.Forms;
using GSA.ToolKits.DawnUtility;

namespace GSA.ToolKits.DawnApp.FormView
{
	/// <summary>
	/// 加解密示范窗体（定制版）
	/// </summary>
	public partial class DESEncryptCustomForm : Form
    {
		/// <summary>
		/// 加解密示范窗体（定制版）
		/// </summary>
		public DESEncryptCustomForm()
        {
            InitializeComponent();
        }

		/// <summary>
		/// 窗体加载时
		/// </summary>
		/// <param name="sender">传递对象</param>
		/// <param name="e">传递事件</param>
		private void DESEncryptCustomForm_Load(object sender, EventArgs e)
		{
			this.cboxKeyType.SelectedIndex = 0;
		}
		/// <summary>
		/// 自定义密钥加密
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEncrypt2_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txt_tempData2.Text) && !string.IsNullOrEmpty(txt_desKeys.Text))
			{
				txt_desData2.Clear();
				txt_desData2.Text = CryptoHelper.Encrypt(txt_tempData2.Text, txt_desKeys.Text);
			}
		}
		/// <summary>
		/// 自定义密钥解密
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDecrypt2_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txt_tempData2.Text) && !string.IsNullOrEmpty(txt_desKeys.Text))
			{
				txt_desData2.Clear();
				try
				{
					txt_desData2.Text = CryptoHelper.Decrypt(txt_tempData2.Text, txt_desKeys.Text);
				}
				catch
				{
					txt_desData2.Text = "错误的加密原数据！";
				}
			}
		}
		/// <summary>
		/// 内置密钥加密
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInsidEncrypt_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtInsidOrigin.Text))
			{
				txtInsidValue.Clear();
				txtInsidValue.Text = CryptoHelper.Encrypt(txtInsidOrigin.Text, byte.Parse(cboxKeyType.SelectedItem.ToString()));
			}
		}
		/// <summary>
		/// 内置密钥解密
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInsidDecrypt_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtInsidOrigin.Text))
			{
				txtInsidValue.Clear();
				try
				{
					txtInsidValue.Text = CryptoHelper.Decrypt(txtInsidOrigin.Text, byte.Parse(cboxKeyType.SelectedItem.ToString()));
				}
				catch
				{
					txtInsidValue.Text = "错误的加密原数据！";
				}
			}
		}
		/// <summary>
		/// 量子传输科研中心
		/// <para>长度计算</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtDoLengthText_TextChanged(object sender, EventArgs e)
		{
			lblDoLengthNum.Text = string.Format("长度：{0}", txtDoLengthText.Text.Trim().Length);
		}
	}
}
