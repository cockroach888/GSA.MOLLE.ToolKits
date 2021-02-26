using GSA.ToolKits.DawnUtility;
using System;
using System.Windows.Forms;

namespace GSA.ToolKits.DawnApp.FormView
{
	/// <summary>
	/// 非对称(RSA)加解密示范窗体
	/// </summary>
	public partial class RSAHelperForm : Form
    {
		/// <summary>
		/// 非对称(RSA)加解密示范窗体
		/// </summary>
		public RSAHelperForm()
        {
            InitializeComponent();
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnBuildRSAStr_Click(object sender, EventArgs e)
		{
			var _key = RSAHelper.GetRASKey();
			txtPublicString.Text = _key.PublicKey;
			txtPrivateString.Text = _key.PrivateKey;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPublicEncrypt_Click(object sender, EventArgs e)
		{
			var _val = txtPublicString.Text.Trim();
			if (string.IsNullOrEmpty(_val)) return;
			txtEncryptSecret.Text = _val;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPublicDecrypt_Click(object sender, EventArgs e)
		{
			var _val = txtPublicString.Text.Trim();
			if (string.IsNullOrEmpty(_val)) return;
			txtDecryptSecret.Text = _val;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPrivateEncrypt_Click(object sender, EventArgs e)
		{
			var _val = txtPrivateString.Text.Trim();
			if (string.IsNullOrEmpty(_val)) return;
			txtEncryptSecret.Text = _val;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPrivateDecrypt_Click(object sender, EventArgs e)
		{
			var _val = txtPrivateString.Text.Trim();
			if (string.IsNullOrEmpty(_val)) return;
			txtDecryptSecret.Text = _val;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEncrypt_Click(object sender, EventArgs e)
		{
			var _val = txtEncryptString.Text;
			var _key = txtEncryptSecret.Text;
			if (string.IsNullOrEmpty(_val) || string.IsNullOrEmpty(_key))
			{
				MessageBox.Show("需要加密的明文和加密密钥均不能为空，请重试。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				txtEncryptResult.Text = RSAHelper.EncryptString(_val, _key);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDecrypt_Click(object sender, EventArgs e)
		{
			var _val = txtDecryptString.Text;
			var _key = txtDecryptSecret.Text;
			if (string.IsNullOrEmpty(_val) || string.IsNullOrEmpty(_key))
			{
				MessageBox.Show("需要解密的密文和解密密钥均不能为空，请重试。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				txtDecryptResult.Text = RSAHelper.DecryptString(_val, _key);
			}
		}
	}
}
