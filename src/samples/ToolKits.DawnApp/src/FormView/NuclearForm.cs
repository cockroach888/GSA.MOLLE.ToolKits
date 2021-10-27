using GSA.ToolKits.DawnUtility;
using GSA.ToolKits.FormUtility;
using GSA.ToolKits.NuclearUtility;
using GSA.ToolKits.VerifyUtility;
using System;
using System.IO;
using System.Windows.Forms;

namespace GSA.ToolKits.DawnApp.FormView
{
    /// <summary>
    /// 原子式磁场演示中心(FTP、Email...)
    /// </summary>
    public partial class NuclearForm : Form
    {
        private FTPHelper _ftpHelper;

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

        #region 成员电子邮件功能事件

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

        #endregion

        #region 成员 FTP 功能事件

        /// <summary>
        /// 获取基本列表
        /// </summary>
        /// <param name="sender">传递对象</param>
        /// <param name="e">传递事件</param>
        private void btnBaseList_Click(object sender, EventArgs e)
        {
            if (null == _ftpHelper)
            {
                MessageBox.Show("请先创建FTP服务！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblStatusInfo.Text = "等待...";

            string resultString = _ftpHelper.GetListDirectory(out string[] resultArray);
            lblStatusInfo.Text = $"{_ftpHelper.CurrentStatusCode} : {resultString}";

            lstDataBox.Items.Clear();
            foreach (string item in resultArray)
            {
                lstDataBox.Items.Add(item);
            }
        }

        /// <summary>
        /// 获取详细列表
        /// </summary>
        /// <param name="sender">传递对象</param>
        /// <param name="e">传递事件</param>
        private void btnDetailsList_Click(object sender, EventArgs e)
        {
            if (null == _ftpHelper)
            {
                MessageBox.Show("请先创建FTP服务！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblStatusInfo.Text = "等待...";

            string resultString = _ftpHelper.GetListDirectoryDetails(out string[] resultArray);
            lblStatusInfo.Text = $"{_ftpHelper.CurrentStatusCode} : {resultString}";

            lstDataBox.Items.Clear();
            foreach (string item in resultArray)
            {
                lstDataBox.Items.Add(item);
            }
        }

        /// <summary>
        /// 下载所选文件
        /// </summary>
        /// <param name="sender">传递对象</param>
        /// <param name="e">传递事件</param>
        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            if (null == _ftpHelper)
            {
                MessageBox.Show("请先创建FTP服务！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblStatusInfo.Text = "等待...";

            string saveFullPath = txtFileOrName.Text.Trim();

            if (string.IsNullOrEmpty(saveFullPath))
            {
                MessageBox.Show("对不起！请先选择好下载文件的保存位置，然后重试。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFileOrName.Focus();
                return;
            }

            string selectedFile = lstDataBox.SelectedItem as string;

            if (string.IsNullOrWhiteSpace(selectedFile))
            {
                MessageBox.Show("您暂未选中任何文件，或列表中没有文件可供选择，请先执行获取基本列表，并确认选中了文件后重试。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string resultString = _ftpHelper.Download(saveFullPath, selectedFile);
            lblStatusInfo.Text = $"{_ftpHelper.CurrentStatusCode} : {resultString}";
        }

        /// <summary>
        /// 删除所选文件
        /// </summary>
        /// <param name="sender">传递对象</param>
        /// <param name="e">传递事件</param>
        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (null == _ftpHelper)
            {
                MessageBox.Show("请先创建FTP服务！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblStatusInfo.Text = "等待...";

            string selectedFile = lstDataBox.SelectedItem as string;

            if (string.IsNullOrWhiteSpace(selectedFile))
            {
                MessageBox.Show("您暂未选中任何文件，或列表中没有文件可供选择，请先执行获取基本列表，并确认选中了文件后重试。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string resultString = _ftpHelper.Delete(selectedFile);
            lblStatusInfo.Text = $"{_ftpHelper.CurrentStatusCode} : {resultString}";
        }

        /// <summary>
        /// 删除所选目录
        /// </summary>
        /// <param name="sender">传递对象</param>
        /// <param name="e">传递事件</param>
        private void btnDeleteDir_Click(object sender, EventArgs e)
        {
            if (null == _ftpHelper)
            {
                MessageBox.Show("请先创建FTP服务！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblStatusInfo.Text = "等待...";

            string selectedFile = lstDataBox.SelectedItem as string;

            if (string.IsNullOrWhiteSpace(selectedFile))
            {
                MessageBox.Show("您暂未选中任何目录，或列表中没有目录可供选择，请先执行获取基本列表，并确认选中了目录后重试。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string resultString = _ftpHelper.DeleteDirectory(selectedFile);
            lblStatusInfo.Text = $"{_ftpHelper.CurrentStatusCode} : {resultString}";
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="sender">传递对象</param>
        /// <param name="e">传递事件</param>
        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            if (null == _ftpHelper)
            {
                MessageBox.Show("请先创建FTP服务！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblStatusInfo.Text = "等待...";

            string fileFullPath = txtFileOrName.Text.Trim();

            if (string.IsNullOrEmpty(fileFullPath) || !File.Exists(fileFullPath))
            {
                MessageBox.Show("对不起！请先选择好需要上传的文件，然后重试。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFileOrName.Focus();
                return;
            }

            string resultString = _ftpHelper.Upload(fileFullPath);
            lblStatusInfo.Text = $"{_ftpHelper.CurrentStatusCode} : {resultString}";
        }

        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="sender">传递对象</param>
        /// <param name="e">传递事件</param>
        private void btnRenameFile_Click(object sender, EventArgs e)
        {
            if (null == _ftpHelper)
            {
                MessageBox.Show("请先创建FTP服务！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblStatusInfo.Text = "等待...";

            string newFileName = txtFileOrName.Text.Trim();

            if (string.IsNullOrEmpty(newFileName))
            {
                MessageBox.Show("对不起！请先确定好新的文件名称，然后重试。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFileOrName.Focus();
                return;
            }

            string selectedFile = lstDataBox.SelectedItem as string;

            if (string.IsNullOrWhiteSpace(selectedFile))
            {
                MessageBox.Show("您暂未选中任何文件，或列表中没有文件可供选择，请先执行获取基本列表，并确认选中了文件后重试。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string resultString = _ftpHelper.Rename(selectedFile, newFileName);
            lblStatusInfo.Text = $"{_ftpHelper.CurrentStatusCode} : {resultString}";
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="sender">传递对象</param>
        /// <param name="e">传递事件</param>
        private void btnCreateDir_Click(object sender, EventArgs e)
        {
            if (null == _ftpHelper)
            {
                MessageBox.Show("请先创建FTP服务！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblStatusInfo.Text = "等待...";

            string dirName = txtFileOrName.Text.Trim();

            if (string.IsNullOrEmpty(dirName))
            {
                MessageBox.Show("您欲创建的目录名称不正确，请输入仅限目录名称的内容。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFileOrName.Focus();
                return;
            }

            string resultString = _ftpHelper.CreateDirectory(dirName);
            lblStatusInfo.Text = $"{_ftpHelper.CurrentStatusCode} : {resultString}";
        }

        /// <summary>
        /// 浏览
        /// </summary>
        /// <param name="sender">传递对象</param>
        /// <param name="e">传递事件</param>
        private void btnBrowserFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.CheckFileExists = false;
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择或填写需要使用的文件名称";

            DialogResult result = fileDialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                txtFileOrName.Text = fileDialog.FileName;
            }
        }

        /// <summary>
        /// 创建 FTP Helper 对象
        /// </summary>
        /// <param name="sender">传递对象</param>
        /// <param name="e">传递事件</param>
        private void btnCreateFTP_Click(object sender, EventArgs e)
        {
            int.TryParse(txtPort.Text.Trim(), out int port);

            FTPOption option = new()
            {
                Server = txtServer.Text.Trim(),
                Port = port,
                UserName = txtUserName.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                DefaultPath = txtDefaultPath.Text.Trim(),
                UseSSL = chkUseSSL.Checked,
                IsKeepAlive = chkIsKeepAlive.Checked
            };

            _ftpHelper = new FTPHelper(option);
        }

        #endregion

    }
}
