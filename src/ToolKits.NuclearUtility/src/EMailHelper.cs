//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：EMailHelper.cs
// 项目名称：原子能式的高深学问方法实用工具集
// 创建时间：2016-04-15 22:47:17
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DawnXZ.NuclearUtility
{
    /// <summary>
    /// 电子邮件操作帮助类
    /// </summary>
    public class EMailHelper
    {
        /// <summary>
        /// 电子邮件操作帮助类
        /// </summary>
        /// <param name="srvInfo">服务器信息实体对象</param>
        public EMailHelper(EMailSrvInfo srvInfo)
        {
            ServerInfo = srvInfo;
            Initialize();
        }
        /// <summary>
        /// 析构函数
        /// </summary>
        ~EMailHelper()
        {
            if (null != FSmtpClient)
            {
#if (!NET35 && !NET20)
				FSmtpClient.Dispose();
#endif
                FSmtpClient = null;
            }
            IsSuccessful = false;
            LastErrorMessage = string.Empty;
        }

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            IsSuccessful = false;
            LastErrorMessage = string.Empty;
            FSmtpClient = new SmtpClient();
            FSmtpClient.DeliveryMethod = ServerInfo.DeliveryType;
            FSmtpClient.EnableSsl = ServerInfo.IsSSL;
            FSmtpClient.Host = ServerInfo.SMTPServer;
            FSmtpClient.Port = ServerInfo.SMTPPort;
            FSmtpClient.UseDefaultCredentials = true;
            FSmtpClient.Credentials = new NetworkCredential(ServerInfo.UserName, ServerInfo.Password);
            FSmtpClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
        }

        #endregion

        #region 成员变量

        /// <summary>
        /// 电子邮件客户端对象
        /// </summary>
        private SmtpClient FSmtpClient;

        #endregion

        #region 成员属性

        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool IsSuccessful { get; private set; }
        /// <summary>
        /// 末次产生的错误信息
        /// </summary>
        public string LastErrorMessage { get; set; }
        /// <summary>
        /// 服务器信息实体对象
        /// </summary>
        public EMailSrvInfo ServerInfo { get; private set; }

        #endregion

        #region 成员方法

        /// <summary>
        /// 创建电子邮件信息对象
        /// </summary>
        /// <param name="mailInfo">邮件信息实体对象</param>
        /// <returns>电子邮件信息对象</returns>
        private MailMessage CreateMail(EMailInfo mailInfo)
        {
            Encoding _code = Encoding.GetEncoding(mailInfo.Charset);
            MailMessage _mm = new MailMessage();
            _mm.Priority = mailInfo.Priority;
            _mm.From = new MailAddress(ServerInfo.UserName, ServerInfo.DisplayName, _code);
#if (NET35 || NET20)
            _mm.To.Add(string.Join(",", mailInfo.Recipient.ToArray())); //收件人
#else
			_mm.To.Add(string.Join(",", mailInfo.Recipient)); //收件人
#endif
            if (null != mailInfo.Cc && mailInfo.Cc.Count > 0)
            {
#if (NET35 || NET20)
                _mm.CC.Add(string.Join(",", mailInfo.Cc.ToArray())); //抄送人
#else
                _mm.CC.Add(string.Join(",", mailInfo.Cc)); //抄送人
#endif
            }
            if (null != mailInfo.Bcc && mailInfo.Bcc.Count > 0)
            {
#if (NET35 || NET20)
                _mm.Bcc.Add(string.Join(",", mailInfo.Bcc.ToArray())); //密送人
#else
                _mm.Bcc.Add(string.Join(",", mailInfo.Bcc)); //密送人
#endif
            }
            _mm.SubjectEncoding = _code;
            _mm.Subject = mailInfo.Subject;
            _mm.IsBodyHtml = mailInfo.IsHTML;
            _mm.BodyEncoding = _code;
            _mm.Body = mailInfo.Body;
            if (null != mailInfo.Attachments && mailInfo.Attachments.Count > 0)
            {
                while (mailInfo.Attachments.Count > 0)
                {
                    _mm.Attachments.Add(mailInfo.Attachments.Dequeue());
                }
            }
            return _mm;
        }
        /// <summary>
        /// 验证检查事件处理
        /// </summary>
        /// <param name="mailInfo">邮件信息实体对象</param>
        /// <returns>验证检查结果</returns>
        private bool Checked(EMailInfo mailInfo)
        {
            IsSuccessful = false;
            LastErrorMessage = string.Empty; //重置末次错误信息
            if (null == FSmtpClient)
            {
                LastErrorMessage = "未能创建SMTP客户端对象，请检查服务器信息是否配置正确后重试。";
                return false;
            }
            if (null == mailInfo)
            {
                LastErrorMessage = "邮件信息为空或未配置正确，请检查后重试。";
                return false;
            }
            if (null == mailInfo.Recipient || mailInfo.Recipient.Count <= 0)
            {
                LastErrorMessage = "收件人信息不能为空或少于1个收件人。";
                return false;
            }
            return true;
        }

        #endregion

        #region 阻塞模式

        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="mailInfo">邮件信息实体对象</param>
        /// <returns>发送结果</returns>
        public void Send(EMailInfo mailInfo)
        {
            var _check = Checked(mailInfo);
            if (_check)
            {
                try
                {
                    MailMessage _mm = CreateMail(mailInfo);
                    FSmtpClient.Send(_mm);
                    IsSuccessful = true;
                }
                catch (Exception ex)
                {
                    IsSuccessful = false;
                    LastErrorMessage = ex.Message;
                }
            }
        }

        #endregion

        #region  非阻塞模式

        /// <summary>
        /// 电子邮件异步发送操作完成时
        /// </summary>
        /// <param name="sender">电子邮件客户端对象</param>
        /// <param name="e">异步发送执行事件对象</param>
        private void SendCompletedCallback(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            string token = e.UserState as string;
            if (token == "Successful")
            {
                IsSuccessful = true;
                LastErrorMessage = string.Empty;
            }
            else
            {
                IsSuccessful = false;
                LastErrorMessage = e.Error.Message;
            }
        }
        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="mailInfo">邮件信息实体对象</param>
        /// <returns>发送结果</returns>
        public void SendAsync(EMailInfo mailInfo)
        {
            var _check = Checked(mailInfo);
            if (_check)
            {
                try
                {
                    MailMessage _mm = CreateMail(mailInfo);
                    FSmtpClient.SendAsync(_mm, "Successful");
                    IsSuccessful = true;
                }
                catch (Exception ex)
                {
                    IsSuccessful = false;
                    LastErrorMessage = ex.Message;
                }
            }
        }
        /// <summary>
        /// 取消电子邮件异步发送事件
        /// </summary>
        public void SendAsyncCancel()
        {
            if (null != FSmtpClient) FSmtpClient.SendAsyncCancel();
        }

        #endregion

    }
    /// <summary>
    /// 服务器信息实体类
    /// </summary>
    [Serializable]
    public class EMailSrvInfo
    {
        /// <summary>
        /// 服务器信息实体类
        /// </summary>
        public EMailSrvInfo()
        {
            DeliveryType = SmtpDeliveryMethod.Network;
            IsSSL = true;
            SMTPServer = string.Empty;
            SMTPPort = 25;
            POPServer = string.Empty;
            POPPort = 110;
            DisplayName = "系统管理员";
            UserName = string.Empty;
            Password = string.Empty;
        }

        #region 成员属性

        /// <summary>
        /// 邮件服务器出站方式
        /// <para>默认Network</para>
        /// </summary>
        public SmtpDeliveryMethod DeliveryType { get; set; }
        /// <summary>
        /// 是否启用SSL加密
        /// <para>默认启用</para>
        /// <para>true为启用</para>
        /// <para>false为不启用</para>
        /// </summary>
        public bool IsSSL { get; set; }
        /// <summary>
        /// SMTP服务器地址
        /// <para>smtp.163.com</para>
        /// <para>smtp.126.com</para>
        /// <para>smtp.yeah.net</para>
        /// <para>smtp.qq.com</para>
        /// <para>smtp.sohu.com</para>
        /// <para>smtp.sina.com.cn</para>
        /// <para>smtp.hotmail.com</para>
        /// <para>smtp.aliyun.com</para>
        /// <para>smtp.outlook.com</para>
        /// <para>smtp.gmail.com</para>
        /// <para>smtp.10086.cn</para>
        /// <para>smtp.21cn.com</para>
        /// <para>smtp.sogou.com</para>
        /// <para>smtp.263.net</para>
        /// <para>smtp.wo.cn</para>
        /// <para>smtp.189.cn</para>
        /// </summary>
        public string SMTPServer { get; set; }
        /// <summary>
        /// SMTP服务器端口号
        /// <para>行规默认为25</para>
        /// </summary>
        public int SMTPPort { get; set; }
        /// <summary>
        /// POP服务器地址
        /// <para>pop.163.com</para>
        /// <para>pop.126.com</para>
        /// <para>pop.yeah.net</para>
        /// <para>pop.qq.com</para>
        /// <para>pop.sohu.com</para>
        /// <para>pop.sina.com.cn</para>
        /// <para>pop.hotmail.com</para>
        /// <para>pop.aliyun.com</para>
        /// <para>pop.outlook.com</para>
        /// <para>pop.gmail.com</para>
        /// <para>pop.10086.cn</para>
        /// <para>pop.21cn.com</para>
        /// <para>pop.sogou.com</para>
        /// <para>pop.263.net</para>
        /// <para>pop.wo.cn</para>
        /// <para>pop.189.cn</para>
        /// </summary>
        public string POPServer { get; set; }
        /// <summary>
        /// POP服务器端口号
        /// <para>行规默认为110</para>
        /// </summary>
        public int POPPort { get; set; }
        /// <summary>
        /// 发件人的显示名称
        /// <para>默认为系统管理员</para>
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 发件人的电子邮箱地址
        /// <para>如：services@126.com</para>
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 发件人的电子邮箱密码
        /// <para>如：********</para>
        /// </summary>
        public string Password { get; set; }

        #endregion

    }
    /// <summary>
    /// 邮件信息实体类
    /// </summary>
    [Serializable]
    public class EMailInfo
    {
        /// <summary>
        /// 电子邮件信息实体类
        /// </summary>
        public EMailInfo()
        {
            Charset = 936;
            Priority = MailPriority.Normal;
            Recipient = new Queue<string>();
            Cc = new Queue<string>();
            Bcc = new Queue<string>();
            Subject = null;
            IsHTML = false;
            Body = null;
            Attachments = new Queue<Attachment>();
        }

        #region 成员属性

        /// <summary>
        /// 邮件正文字符集
        /// <para>默认中文（936）</para>
        /// </summary>
        public int Charset { get; set; }
        /// <summary>
        /// 邮件优先级
        /// <para>默认Normal</para>
        /// </summary>
        public MailPriority Priority { get; set; }
        /// <summary>
        /// 邮件收件人信息
        /// </summary>
        public Queue<string> Recipient { get; set; }
        /// <summary>
        /// 邮件抄送人信息
        /// </summary>
        public Queue<string> Cc { get; set; }
        /// <summary>
        /// 邮件密送人信息
        /// </summary>
        public Queue<string> Bcc { get; set; }
        /// <summary>
        /// 邮件主题信息
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 邮件正文是否为HTML格式
        /// <para>默认为文本格式</para>
        /// <para>true为HTML格式</para>
        /// <para>false为文件格式</para>
        /// </summary>
        public bool IsHTML { get; set; }
        /// <summary>
        /// 邮件正文信息
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 邮件附件信息
        /// </summary>
        public Queue<Attachment> Attachments { get; set; }

        #endregion

    }
}
