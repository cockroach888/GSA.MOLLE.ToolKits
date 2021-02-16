//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：ProcessRequest.cs
// 项目名称：安全校验实用工具集
// 创建时间：2014年2月21日15时9分
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
using System.Configuration;
using System.Globalization;
using System.Web;

namespace ToolKits.SafeUtility
{
    /// <summary>
    /// Web请求进程安全检测处理类
    /// </summary>
    public class ProcessRequest
    {
        /// <summary>
        /// SQL注入校对字符串
        /// </summary>
        private readonly string FInjectionString = ConfigurationManager.AppSettings["SafeInjectionString"] as string;
        /// <summary>
        /// 是否返回错误信息
        /// </summary>
        private readonly string FReturnParam = ConfigurationManager.AppSettings["SafeReturnParam"] as string;
        /// <summary>
        /// SQL注入错误跳转页面
        /// </summary>
        private readonly string FReturnPage = ConfigurationManager.AppSettings["SafeReturnPage"] as string;
        /// <summary>
        /// 用来识别是否是流的方式传输
        /// </summary>
        /// <param name="request">使 ASP.NET 能够读取客户端在 Web 请求期间发送的 HTTP 值。</param>
        /// <returns>比较结果</returns>
        bool IsUploadRequest(HttpRequest request)
        {
            return StringStartsWithAnotherIgnoreCase(request.ContentType, "multipart/form-data");
        }
        /// <summary>
        /// 比较内容类型
        /// </summary>
        /// <param name="s1">比较值一</param>
        /// <param name="s2">比较值二</param>
        /// <returns>比较结果</returns>
        private bool StringStartsWithAnotherIgnoreCase(string s1, string s2)
        {
            return (string.Compare(s1, 0, s2, 0, s2.Length, true, CultureInfo.InvariantCulture) == 0);
        }
        /// <summary>
        /// 处理用户提交的请求
        /// </summary>
        public void StartProcessRequest()
        {
            HttpRequest Request = System.Web.HttpContext.Current.Request;
            HttpResponse Response = System.Web.HttpContext.Current.Response;
            try
            {
                string getkeys = "";
                if (IsUploadRequest(Request)) return;  //如果是流传递就退出
                //字符串参数
                if (Request.QueryString != null)
                {
                    for (int i = 0; i < Request.QueryString.Count; i++)
                    {
                        getkeys = Request.QueryString.Keys[i];
                        if (!ProcessSqlStr(Request.QueryString[getkeys].ToLower()))
                        {
                            if (FReturnParam == "yes")
                            {
                                Response.Redirect(FReturnPage + "?msg=QueryString中含有非法字符串&result=true");
                            }
                            else
                            {
                                Response.Redirect(FReturnPage);
                            }
                            Response.End();
                        }
                    }
                }
                //form参数
                if (Request.Form != null)
                {
                    for (int i = 0; i < Request.Form.Count; i++)
                    {
                        getkeys = Request.Form.Keys[i];
                        if (!ProcessSqlStr(Request.Form[getkeys].ToLower()))
                        {
                            if (FReturnParam == "yes")
                            {
                                Response.Redirect(FReturnPage + "?msg=Form中含有非法字符串&result=true");
                            }
                            else
                            {
                                Response.Redirect(FReturnPage);
                            }
                            Response.End();
                        }
                    }
                }
                //cookie参数
                if (Request.Cookies != null)
                {
                    for (int i = 0; i < Request.Cookies.Count; i++)
                    {
                        getkeys = Request.Cookies.Keys[i];
                        if (!ProcessSqlStr(Request.Cookies[getkeys].Value.ToLower()))
                        {
                            if (FReturnParam == "yes")
                            {
                                Response.Redirect(FReturnPage + "?msg=Cookie中含有非法字符串&result=true");
                            }
                            else
                            {
                                Response.Redirect(FReturnPage);
                            }
                            Response.End();
                        }
                    }
                }
            }
            catch
            {
                // 错误处理: 处理用户提交信息!
                Response.Clear();
                Response.Write("CustomErrorPage配置错误");
                Response.End();
            }
        }
        /// <summary>
        /// 分析用户请求是否正常
        /// 传入用户提交数据
        /// 返回是否含有SQL注入式攻击代码
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        private bool ProcessSqlStr(string Str)
        {
            bool ReturnValue = true;
            try
            {
                if (Str != "")
                {
                    string[] anySqlStr = FInjectionString.Split('|');
                    foreach (string ss in anySqlStr)
                    {
                        if (Str.IndexOf(ss) >= 0)
                        {
                            ReturnValue = false;
                            break;
                        }
                    }
                }
            }
            catch
            {
                ReturnValue = false;
            }
            return ReturnValue;
        }
    }
}
#endif