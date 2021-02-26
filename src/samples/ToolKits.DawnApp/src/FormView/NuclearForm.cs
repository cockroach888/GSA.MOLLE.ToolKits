using GSA.ToolKits.DawnUtility;
using GSA.ToolKits.FormUtility;
using GSA.ToolKits.NuclearUtility;
using GSA.ToolKits.VerifyUtility;
using System;
using System.Windows.Forms;

namespace GSA.ToolKits.DawnApp.FormView
{
    /// <summary>
    /// 原子式磁场演示中心(FTP、Email...)
    /// </summary>
    public partial class NuclearForm : Form
    {
        /// <summary>
        /// 原子式磁场演示中心(FTP、Email...)
        /// </summary>
        public NuclearForm()
        {
            InitializeComponent();
        }

        /// <summary>
		/// 窗体加载
		/// </summary>
		/// <param name="sender">传递对象</param>
		/// <param name="e">传递事件</param>
		private void NuclearForm_Load(object sender, EventArgs e)
        {
            lstRecipients.Items.Clear();
        }

        /// <summary>
        /// 增加收件人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecipients_Click(object sender, EventArgs e)
        {
            var _val = txtRecipients.Text.Trim();
            if (ValidHelper.IsEmailValid(_val))
            {
                lstRecipients.BeginUpdate();
                lstRecipients.Items.Add(_val);
                lstRecipients.EndUpdate();
                //MsgBox.Show($"对不起！收件人数量已达到最大设定值【{FMailMessage.MaxRecipientNum}】。");
            }
            else
            {
                MsgBox.Show(ValidError.IsEmailValid);
            }
        }
        /// <summary>
        /// 开启电子邮件发射之旅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMailSend_Click(object sender, EventArgs e)
        {
            if (lstRecipients.Items.Count <= 0)
            {
                MsgBox.Show("收件人信息不能为空。");
                return;
            }
            //SMTP 服务器信息
            var _server = txtSMTPServer.Text.Trim();
            var _port = TypeHelper.TypeToInt32(txtSMTPPort.Text.Trim(), 25);
            var _user = txtSMTPUser.Text.Trim();
            var _pwd = txtSMTPPwd.Text.Trim();
            //服务器信息
            EMailSrvInfo _srvInfo = new EMailSrvInfo();
            _srvInfo.SMTPServer = _server;
            _srvInfo.SMTPPort = _port;
            _srvInfo.UserName = _user;
            _srvInfo.Password = _pwd;
            _srvInfo.DisplayName = txtMailUser.Text.Trim();
            //电子邮件信息
            EMailInfo _mailInfo = new EMailInfo();
            foreach (string item in lstRecipients.Items)
            {
                _mailInfo.Recipient.Enqueue(item);
            }
            _mailInfo.Subject = txtMailSubject.Text.Trim();
            _mailInfo.IsHTML = chkMailHtml.Checked;
            _mailInfo.Body = txtMailBody.Text.Trim();
            EMailHelper _mailHelper = new EMailHelper(_srvInfo);
            _mailHelper.Send(_mailInfo);
            if (_mailHelper.IsSuccessful)
            {
                MsgBox.Show("电子邮件发送成功！");
            }
            else
            {
                MsgBox.Show($"电子邮件发送失败！【原因：{_mailHelper.LastErrorMessage}】");
            }
        }
    }
}
