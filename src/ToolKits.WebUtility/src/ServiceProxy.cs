//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：ServiceProxy.cs
// 项目名称：网页网站实用工具集
// 创建时间：2014年2月24日17时41分
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
#if NETFRAMEWORK
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Net;
using System.Web.Services.Description;

namespace ToolKits.WebUtility
{
    /// <summary>
    /// WebService代理操作辅助类
    /// </summary>
    public class ServiceProxy : MarshalByRefObject
    {
        private string url;
        private string methodName;
        private object[] args;
        private string username;
        private string password;
        private string domain;
        private bool needCredential;
        /// <summary>
        /// web服务的地址
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        /// <summary>
        /// web服务的方法名
        /// </summary>
        public string MethodName
        {
            get { return methodName; }
            set { methodName = value; }
        }
        /// <summary>
        /// web服务的方法参数
        /// </summary>
        public object[] Args
        {
            get { return args; }
            set { args = value; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        /// <summary>
        /// 域名
        /// </summary>
        public string Domain
        {
            get { return domain; }
            set { domain = value; }
        }
        /// <summary>
        /// 是否需要身份验证
        /// </summary>
        public bool NeedCredential
        {
            get { return needCredential; }
            set { needCredential = value; }
        }
        /// <summary>
        /// GetWsClassName
        /// </summary>
        /// <param name="wsUrl"></param>
        /// <returns></returns>
        private string GetWsClassName(string wsUrl)
        {
            string[] parts = wsUrl.Split('/');
            string[] pps = parts[parts.Length - 1].Split('.');

            return pps[0];
        }
        /// <summary>
        /// InvokeWebService
        /// </summary>
        /// <returns></returns>
        public object InvokeWebService()
        {
            string @namespace = "EnterpriseServerBase.WebService.DynamicWebCalling";
            string classname = this.GetWsClassName(this.url);
            try
            {
                NetworkCredential myCredential = new NetworkCredential(this.username, this.password, this.domain);
                //获取WSDL
                WebClient wc = new WebClient();
                if (this.needCredential)
                {
                    wc.Credentials = myCredential;
                }
                System.IO.Stream stream = wc.OpenRead(this.url + "?WSDL");
                ServiceDescription sd = ServiceDescription.Read(stream);
                ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, "", "");
                CodeNamespace cn = new CodeNamespace(@namespace);
                //生成客户端代理类代码
                CodeCompileUnit ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(cn);
                sdi.Import(cn, ccu);
                CodeDomProvider csc = CodeDomProvider.CreateProvider("C#");
                //设定编译参数
                CompilerParameters cplist = new CompilerParameters();
                cplist.GenerateExecutable = false;
                cplist.GenerateInMemory = true;
                cplist.ReferencedAssemblies.Add("System.dll");
                cplist.ReferencedAssemblies.Add("System.XML.dll");
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                cplist.ReferencedAssemblies.Add("System.Data.dll");
                //编译代理类
                CompilerResults cr = csc.CompileAssemblyFromDom(cplist, ccu);
                if (cr.Errors.HasErrors)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(System.Environment.NewLine);
                    }
                    throw new Exception(sb.ToString());
                }
                //生成代理实例，并调用方法
                System.Reflection.Assembly assembly = cr.CompiledAssembly;
                Type t = assembly.GetType(@namespace + "." + classname, true, true);
                object obj = Activator.CreateInstance(t);
                if (this.needCredential)
                {
                    System.Reflection.PropertyInfo pi = t.GetProperty("Credentials");
                    pi.SetValue(obj, myCredential, null);
                }
                System.Reflection.MethodInfo mi = t.GetMethod(this.methodName);
                return mi.Invoke(obj, args);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
            }
        }
    }
}
#endif
