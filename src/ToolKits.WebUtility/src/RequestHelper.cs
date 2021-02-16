//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：RequestHelper.cs
// 项目名称：文件操作实用工具集
// 创建时间：2014年2月24日14时32分
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
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace ToolKits.WebUtility
{
    /// <summary>
    /// 请求对象操作辅助类
    /// </summary>
    public static class RequestHelper
    {

        #region 成员字段

        /// <summary>
        /// 换行符
        /// </summary>
        private static Regex RegexBr = new Regex(@"(\r\n)", RegexOptions.IgnoreCase);
        /// <summary>
        /// 格式化字体HTML标记
        /// </summary>
        public static Regex RegexFont = new Regex(@"<font color=" + "\".*?\"" + @">([\s\S]+?)</font>", GetRegexCompiledOptions());
        /// <summary>
        /// 得到正则编译参数设置
        /// </summary>
        /// <returns></returns>
        public static RegexOptions GetRegexCompiledOptions()
        {
#if NET1
                return RegexOptions.Compiled;
#else
            return RegexOptions.None;
#endif
        }

        #endregion

        #region 成员方法

        #region IP 地址

        /// <summary>
        /// 判断字符串是否为正确的IP地址格式
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        internal static bool IsIPAddress(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
        /// <summary>
        /// 获取请求客户端IP地址
        /// </summary>
        /// <returns>客户端IP地址</returns>
        public static string GetIPAddress()
        {
            string result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (string.IsNullOrEmpty(result)) result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result)) result = HttpContext.Current.Request.UserHostAddress;
            if (string.IsNullOrEmpty(result) || !IsIPAddress(result)) return "1.1.1.1";
            return result;
        }
        /// <summary>
        /// 获取请求客户端IP地址
        /// <para>取得客户端真实IP</para>
        /// <para>如果有代理则取第一个非内网地址</para>
        /// </summary>
        /// <returns>客户端IP地址</returns>
        public static string GetIPAddressAt()
        {
            string result = String.Empty;
            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (result != null && result != String.Empty)
            {
                //可能有代理
                if (result.IndexOf(".") == -1)    //没有"."肯定是非IPv4格式
                    result = null;
                else
                {
                    if (result.IndexOf(",") != -1)
                    {
                        //有","，估计多个代理。取第一个不是内网的IP。
                        result = result.Replace(" ", "").Replace("\"", "");
                        string[] temparyip = result.Split(",;".ToCharArray());
                        for (int i = 0; i < temparyip.Length; i++)
                        {
                            if (IsIPAddress(temparyip[i])
                                && temparyip[i].Substring(0, 3) != "10."
                                && temparyip[i].Substring(0, 7) != "192.168"
                                && temparyip[i].Substring(0, 7) != "172.16.")
                            {
                                return temparyip[i];    //找到不是内网的地址
                            }
                        }
                    }
                    else if (IsIPAddress(result)) //代理即是IP格式
                    {
                        return result;
                    }
                    else
                    {
                        result = null;    //代理中的内容 非IP，取IP
                    }
                }
            }
            string IpAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != String.Empty) ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (null == result || result == String.Empty) result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (result == null || result == String.Empty) result = HttpContext.Current.Request.UserHostAddress;
            return result;
        }

        #endregion

        #region MAC 地址

        /// <summary>
        /// 获取请求客户端MAC地址
        /// </summary>
        /// <param name="strIP">客户端IP地址</param>
        /// <returns>客户端MAC地址</returns>
        public static string GetMacAddress(string strIP)
        {
            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName = "nbtstat";
                process.StartInfo.Arguments = "-a " + strIP;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                int index = output.LastIndexOf("MAC Address = ");
                if (index > 0)
                {
                    return output.Substring(index + 14, 17).ToLower().Replace("-", ":");
                }
                else
                {
                    return "";
                }
            }
        }

        #endregion

        #region URL 地址

        /// <summary>
        /// 返回上一个页面的URL地址
        /// </summary>
        /// <returns>页面的URL地址</returns>
        public static string GetUrlOfReferrer()
        {
            string retVal = null;
            try
            {
                retVal = HttpContext.Current.Request.UrlReferrer.ToString();
            }
            catch { }
            if (retVal == null) return string.Empty;
            return retVal;
        }
        /// <summary>
        /// 获取当前请求的原始URL地址
        /// <para>URL中域信息之后的部分,包括查询字符串(如果存在)</para>
        /// </summary>
        /// <returns>页面的原始URL地址</returns>
        public static string GetUrlOfRaw()
        {
            return HttpContext.Current.Request.RawUrl;
        }
        /// <summary>
        /// 返回URL中结尾的文件名
        /// </summary>
        /// <param name="strUrl">页面的URL地址</param>
        /// <returns>文件名</returns>
        public static string GetUrlByFilename(string strUrl)
        {
            if (string.IsNullOrEmpty(strUrl)) return null;
            string[] tmpStr = strUrl.Split(new char[] { '/' });
            return tmpStr[tmpStr.Length - 1].Split(new char[] { '?' })[0];
        }
        /// <summary>
        /// 获得当前完整Url地址
        /// </summary>
        /// <returns>页面的URL地址</returns>
        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }

        #endregion

        #region URL 参数

        #region Count

        /// <summary>
        /// 获取URL页面中的QueryString参数数量
        /// </summary>
        /// <returns>QueryString参数数量</returns>
        public static int GetParamCountOfQuery()
        {
            return HttpContext.Current.Request.QueryString.Count;
        }
        /// <summary>
        /// 获取URL页面中的Form参数数量
        /// </summary>
        /// <returns>Form参数数量</returns>
        public static int GetParamCountOfForm()
        {
            return HttpContext.Current.Request.Form.Count;
        }
        /// <summary>
        /// 获取URL页面中的参数总个数
        /// </summary>
        /// <returns>参数总个数</returns>
        public static int GetParamCount()
        {
            return GetParamCountOfQuery() + GetParamCountOfForm();
        }

        #endregion

        #region QueryString

        /// <summary>
        /// 获取页面中指定QueryString参数值
        /// <para>字符串类型</para>
        /// </summary>
        /// <param name="strName">参数名称</param>
        /// <returns>参数值</returns>
        public static string GetParamQueryOfString(string strName)
        {
            return HttpContext.Current.Request.QueryString[strName] == null ? string.Empty : HttpContext.Current.Request.QueryString[strName];
        }
        /// <summary>
        /// 获取页面中指定QueryString参数值
        /// <para>整数类型</para>
        /// </summary>
        /// <param name="strName">参数名称</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>参数值</returns>
        public static int GetParamQueryOfInt(string strName, int defValue)
        {
            string strValue = GetParamQueryOfString(strName);
            if (string.IsNullOrEmpty(strValue)) return defValue;
            int result = 0;
            int.TryParse(strValue, out result);
            return result;
        }
        /// <summary>
        /// 获取页面中指定QueryString参数值
        /// <para>浮点数类型</para>
        /// </summary>
        /// <param name="strName">参数名称</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>参数值</returns>
        public static float GetParamQueryOfFloat(string strName, float defValue)
        {
            string strValue = GetParamQueryOfString(strName);
            if (string.IsNullOrEmpty(strValue)) return defValue;
            float result = 0;
            float.TryParse(strValue, out result);
            return result;
        }

        #endregion

        #region Form

        /// <summary>
        /// 获取页面中指定Form参数值
        /// <para>字符串类型</para>
        /// </summary>
        /// <param name="strName">参数名称</param>
        /// <returns>参数值</returns>
        public static string GetParamFormOfString(string strName)
        {
            return HttpContext.Current.Request.Form[strName] == null ? string.Empty : HttpContext.Current.Request.Form[strName];
        }
        /// <summary>
        /// 获取页面中指定Form参数值
        /// <para>整数类型</para>
        /// </summary>
        /// <param name="strName">参数名称</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>参数值</returns>
        public static int GetParamFormOfInt(string strName, int defValue)
        {
            string strValue = GetParamFormOfString(strName);
            if (string.IsNullOrEmpty(strValue)) return defValue;
            int result = 0;
            int.TryParse(strValue, out result);
            return result;
        }
        /// <summary>
        /// 获取页面中指定Form参数值
        /// <para>浮点数类型</para>
        /// </summary>
        /// <param name="strName">参数名称</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>参数值</returns>
        public static float GetParamFormOfFloat(string strName, float defValue)
        {
            string strValue = GetParamFormOfString(strName);
            if (string.IsNullOrEmpty(strValue)) return defValue;
            float result = 0;
            float.TryParse(strValue, out result);
            return result;
        }

        #endregion

        #region QueryString & Form

        /// <summary>
        /// 获取页面中指定参数名称的值
        /// <para>字符串类型</para>
        /// <para>先判断QueryString参数，如果为空则取Form参数</para>
        /// </summary>
        /// <param name="strName">参数名称</param>
        /// <returns>参数值</returns>
        public static string GetParamOfString(string strName)
        {
            return "".Equals(GetParamQueryOfString(strName)) ? GetParamFormOfString(strName) : GetParamQueryOfString(strName);
        }
        /// <summary>
        /// 获取页面中指定参数名称的值
        /// <para>整数类型</para>
        /// <para>先判断QueryString参数，如果为空则取Form参数</para>
        /// </summary>
        /// <param name="strName">参数名称</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>参数值</returns>
        public static int GetParamOfInt(string strName, int defValue)
        {
            return GetParamQueryOfInt(strName, defValue) == defValue ? GetParamFormOfInt(strName, defValue) : GetParamQueryOfInt(strName, defValue);
        }
        /// <summary>
        /// 获取页面中指定参数名称的值
        /// <para>浮点数类型</para>
        /// <para>先判断QueryString参数，如果为空则取Form参数</para>
        /// </summary>
        /// <param name="strName">参数名称</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>参数值</returns>
        public static float GetParamOfFloat(string strName, float defValue)
        {
            return GetParamQueryOfFloat(strName, defValue) == defValue ? GetParamFormOfFloat(strName, defValue) : GetParamQueryOfFloat(strName, defValue);
        }

        #endregion

        #endregion

        #region URL & HTML 编码格式

        /// <summary>
        /// 返回 HTML 方式的编码结果
        /// </summary>
        /// <param name="strVal">需要编码的字符串</param>
        /// <returns>编码结果</returns>
        public static string EncodeOfHtml(string strVal)
        {
            return HttpUtility.HtmlEncode(strVal);
        }
        /// <summary>
        /// 返回 HTML 方式的解码结果
        /// </summary>
        /// <param name="strVal">需要编码的字符串</param>
        /// <returns>解码结果</returns>
        public static string DecodeOfHtml(string strVal)
        {
            return HttpUtility.HtmlDecode(strVal);
        }
        /// <summary>
        /// 返回 URL 方式的编码结果
        /// </summary>
        /// <param name="strVal">需要编码的字符串</param>
        /// <returns>编码结果</returns>
        public static string EncodeOfUrl(string strVal)
        {
            return HttpUtility.UrlEncode(strVal);
        }
        /// <summary>
        /// 返回 URL 方式的解码结果
        /// </summary>
        /// <param name="strVal">需要编码的字符串</param>
        /// <returns>解码结果</returns>
        public static string DecodeOfUrl(string strVal)
        {
            return HttpUtility.UrlDecode(strVal);
        }

        #endregion

        #region HTML 标记

        /// <summary>
        /// 生成指定数量的HTML空格转义字符
        /// <para>单空格模式</para>
        /// </summary>
        /// <param name="spacesCount">生成数量</param>
        /// <returns>HTML空格转义字符</returns>
        public static string MarkSpacesOfSingle(int spacesCount)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < spacesCount; i++)
            {
                sb.Append("&nbsp;");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 生成指定数量的HTML空格转义字符
        /// <para>双空格模式</para>
        /// </summary>
        /// <param name="spacesCount">生成数量</param>
        /// <returns>HTML空格转义字符</returns>
        public static string MarkSpacesOfDouble(int spacesCount)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < spacesCount; i++)
            {
                sb.Append("&nbsp;&nbsp;");
            }
            return sb.ToString();
        }

        #endregion

        #region Page 页面

        /// <summary>
        /// 判断当前页面是否接收到了Post请求
        /// </summary>
        /// <returns>是否接收到了Post请求</returns>
        public static bool RequestIsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }
        /// <summary>
        /// 判断当前页面是否接收到了Get请求
        /// </summary>
        /// <returns>是否接收到了Get请求</returns>
        public static bool RequestIsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }
        /// <summary>
        /// 获得当前页面的名称
        /// </summary>
        /// <returns>当前页面的名称</returns>
        public static string GetPageName()
        {
            string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return urlArr[urlArr.Length - 1].ToLower();
        }

        #endregion

        #region 服务器变量、主机头

        /// <summary>
        /// 返回指定的服务器变量信息
        /// </summary>
        /// <param name="strName">服务器变量名</param>
        /// <returns>服务器变量信息</returns>
        public static string GetServerString(string strName)
        {
            if (HttpContext.Current.Request.ServerVariables[strName] == null) return "";
            return HttpContext.Current.Request.ServerVariables[strName].ToString();
        }
        /// <summary>
        /// 得到当前完整主机头
        /// </summary>
        /// <returns>完整主机头</returns>
        public static string GetServerFullHost()
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;
            if (!request.Url.IsDefaultPort)
            {
                return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());
            }
            return request.Url.Host;
        }
        /// <summary>
        /// 得到主机头
        /// </summary>
        /// <returns>主机头</returns>
        public static string GetServerHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }

        #endregion

        #region 客户端信息

        /// <summary>
        /// 获取客户端浏览器的原始用户代理信息
        /// </summary>
        /// <returns>客户端浏览器的原始用户代理信息</returns>
        public static string GetClientOfUserAgent()
        {
            return HttpContext.Current.Request.UserAgent;
        }
        /// <summary>
        /// 获取远程客户端的IP主机地址
        /// </summary>
        /// <returns>远程客户端的IP主机地址</returns>
        public static string GetClientOfUserHostAddress()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }
        /// <summary>
        /// 获取远程客户端的DNS名称
        /// </summary>
        /// <returns>远程客户端的DNS名称</returns>
        public static string GetClientOfUserHostName()
        {
            return HttpContext.Current.Request.UserHostName;
        }
        /// <summary>
        /// 获取客户端语言首选项的排序字符串数组
        /// </summary>
        /// <returns>客户端语言首选项的排序字符串数组</returns>
        public static string[] GetClientOfUserLanguages()
        {
            return HttpContext.Current.Request.UserLanguages;
        }
        /// <summary>
        /// 获取客户端浏览器类型
        /// </summary>
        /// <returns>客户端浏览器类型</returns>
        public static string GetClientOfType()
        {
            return HttpContext.Current.Request.Browser.Type;
        }
        /// <summary>
        /// 获取客户端浏览器名称
        /// </summary>
        /// <returns>客户端浏览器名称</returns>
        public static string GetClientOfBrowser()
        {
            return HttpContext.Current.Request.Browser.Browser;
        }
        /// <summary>
        /// 获取客户端浏览器（主）版本号
        /// </summary>
        /// <returns>客户端浏览器完整（主）版本号</returns>
        public static string GetClientOfMajorVersion()
        {
            return HttpContext.Current.Request.Browser.MajorVersion.ToString();
        }
        /// <summary>
        /// 获取客户端浏览器完整版本号
        /// </summary>
        /// <returns>客户端浏览器完整版本号</returns>
        public static string GetClientOfVersion()
        {
            return HttpContext.Current.Request.Browser.Version;
        }
        /// <summary>
        /// 获取客户端使用平台名称
        /// </summary>
        /// <returns>客户端使用平台名称</returns>
        public static string GetClientOfPlatform()
        {
            return HttpContext.Current.Request.Browser.Platform;
        }
        /// <summary>
        /// 获取客户端浏览器是否为测试版本
        /// </summary>
        /// <returns>客户端浏览器是否为测试版本</returns>
        public static bool GetClientOfBeta()
        {
            return HttpContext.Current.Request.Browser.Beta;
        }
        /// <summary>
        /// 获取客户端是否为16位的环境
        /// </summary>
        /// <returns>客户端是否为16位的环境</returns>
        public static bool GetClientOfWin16()
        {
            return HttpContext.Current.Request.Browser.Win16;
        }
        /// <summary>
        /// 获取客户端是否为32位的环境
        /// </summary>
        /// <returns>客户端是否为32位的环境</returns>
        public static bool GetClientOfWin32()
        {
            return HttpContext.Current.Request.Browser.Win32;
        }
        /// <summary>
        /// 获取客户端是否支持框架（Frame）
        /// </summary>
        /// <returns>客户端是否支持框架（Frame）</returns>
        public static bool GetClientOfFrames()
        {
            return HttpContext.Current.Request.Browser.Frames;
        }
        /// <summary>
        /// 获取客户端是否支持表格（table）
        /// </summary>
        /// <returns>客户端是否支持表格（table）</returns>
        public static bool GetClientOfTables()
        {
            return HttpContext.Current.Request.Browser.Tables;
        }
        /// <summary>
        /// 获取客户端是否支持Cookie会话
        /// </summary>
        /// <returns>客户端是否支持Cookie会话</returns>
        public static bool GetClientOfCookies()
        {
            return HttpContext.Current.Request.Browser.Cookies;
        }
        /// <summary>
        /// 获取客户端是否支持VB Script脚本
        /// </summary>
        /// <returns>客户端是否支持VB Script脚本</returns>
        public static bool GetClientOfVBScript()
        {
            return HttpContext.Current.Request.Browser.VBScript;
        }
        /// <summary>
        /// 获取客户端是否支持Java Script脚本
        /// </summary>
        /// <returns>客户端是否支持Java Script脚本</returns>
        public static bool GetClientOfJavaScript()
        {
            return HttpContext.Current.Request.Browser.JavaScript;
        }
        /// <summary>
        /// 获取客户端是否支持Java Applets小应用程序
        /// </summary>
        /// <returns>客户端是否支持Java Applets小应用程序</returns>
        public static bool GetClientOfJavaApplets()
        {
            return HttpContext.Current.Request.Browser.JavaApplets;
        }
        /// <summary>
        /// 获取客户端是否支持Activex Controls控件
        /// <para>微软网络化多媒体对象技术</para>
        /// </summary>
        /// <returns>客户端是否支持Activex Controls控件</returns>
        public static bool GetClientOfActiveXControls()
        {
            return HttpContext.Current.Request.Browser.ActiveXControls;
        }

        #endregion

        #region 判断来路

        /// <summary>
        /// 判断当前访问是否来自浏览器软件
        /// <para>默认判断：IE、Chrome、Mozilla、Firefox、Opera、Safari、Netscape、Konqueror</para>
        /// <para>可扩展，传入参数即可，以“|”分隔</para>
        /// </summary>
        /// <param name="extBrowserName">扩展浏览器类型判断字符串</param>
        /// <returns>当前访问是否来自浏览器软件</returns>
        public static bool IsBrowserGet(string extBrowserName = null)
        {
            string[] BrowserName = { "ie", "InternetExplorer", "chrome", "mozilla", "firefox", "opera", "Safari", "netscape", "konqueror" };
            string curBrowser = HttpContext.Current.Request.Browser.Type.ToLower();
            for (int i = 0; i < BrowserName.Length; i++)
            {
                if (curBrowser.IndexOf(BrowserName[i]) >= 0) return true;
            }
            if (null != extBrowserName)
            {
                BrowserName = SplitString(extBrowserName, "|");
                for (int i = 0; i < BrowserName.Length; i++)
                {
                    if (curBrowser.IndexOf(BrowserName[i]) >= 0) return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 判断是否来自搜索引擎链接
        /// <para>默认判断：google、yahoo、msn、baidu、sogou、sohu、sina、163、lycos、tom、yisou、iask、soso、gougou、zhongsou</para>
        /// <para>可扩展，传入参数即可，以“|”分隔</para>
        /// </summary>
        /// <param name="extSearchName">扩展搜索引擎类型判断字符串</param>
        /// <returns>是否来自搜索引擎链接</returns>
        public static bool IsSearchEnginesGet(string extSearchName = null)
        {
            if (HttpContext.Current.Request.UrlReferrer == null) return false;
            string[] SearchEngine = { "google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom", "yisou", "iask", "soso", "gougou", "zhongsou" };
            string tmpReferrer = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
            for (int i = 0; i < SearchEngine.Length; i++)
            {
                if (tmpReferrer.IndexOf(SearchEngine[i]) >= 0) return true;
            }
            if (null != extSearchName)
            {
                SearchEngine = SplitString(extSearchName, "|");
                for (int i = 0; i < SearchEngine.Length; i++)
                {
                    if (tmpReferrer.IndexOf(SearchEngine[i]) >= 0) return true;
                }
            }
            return false;
        }

        #endregion

        #region 判断 Request 参数

        /// <summary>
        /// 判定接受参数是否为空
        /// </summary>
        /// <param name="httpRequest">request对象</param>
        /// <param name="validateparamaters">参数名数组</param>
        /// <returns>判断是否合法</returns>
        public static bool ValidateIsNull(HttpRequest httpRequest, string[] validateparamaters)
        {
            foreach (string paramaters in validateparamaters)
            {
                if (httpRequest[paramaters] == null) return false;
            }
            return true;
        }
        /// <summary>
        /// 判定接受参数长度是否正确
        /// </summary>
        /// <param name="httpRequest">request对象</param>
        /// <param name="validateparamaters">参数名数组</param>
        /// <returns>判断是否合法</returns>
        public static bool ValidateIsLength(HttpRequest httpRequest, string[] validateparamaters)
        {
            foreach (string paramaters in validateparamaters)
            {
                if (httpRequest[paramaters].Length == 0) return false;
            }
            return true;
        }

        #endregion

        #region File 相关

        /// <summary>
        /// 判断文件名是否为浏览器可以直接显示的图片文件名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>是否可以直接显示</returns>
        public static bool IsWebImage(string filename)
        {
            filename = filename.Trim();
            if (filename.EndsWith(".") || filename.IndexOf(".") == -1) return false;
            string extname = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
            return (extname == "jpg" || extname == "jpeg" || extname == "png" || extname == "bmp" || extname == "gif");
        }
        /// <summary>
        /// 返回指定目录下的非 UTF8 字符集文件
        /// 扩展名：htm
        /// </summary>
        /// <param name="dirPath">文件目录路径</param>
        /// <returns>文件名的字符串数组</returns>
        public static string[] FileFindNoUTF8FileHtm(string dirPath)
        {
            StringBuilder filelist = new StringBuilder();
            DirectoryInfo Folder = new DirectoryInfo(dirPath);
            FileInfo[] subFiles = Folder.GetFiles();
            for (int j = 0; j < subFiles.Length; j++)
            {
                if (subFiles[j].Extension.ToLower().Equals(".htm"))
                {
                    FileStream fs = new FileStream(subFiles[j].FullName, FileMode.Open, FileAccess.Read);
                    bool bUtf8 = IsUTF8(fs);
                    fs.Close();
                    if (!bUtf8)
                    {
                        filelist.Append(subFiles[j].FullName);
                        filelist.Append("\r\n");
                    }
                }
            }
            return SplitString(filelist.ToString(), "\r\n");
        }
        /// <summary>
        /// 返回指定目录下的非 UTF8 字符集文件
        /// 扩展名：html
        /// </summary>
        /// <param name="dirPath">文件目录路径</param>
        /// <returns>文件名的字符串数组</returns>
        public static string[] FileFindNoUTF8FileHtml(string dirPath)
        {
            StringBuilder filelist = new StringBuilder();
            DirectoryInfo Folder = new DirectoryInfo(dirPath);
            FileInfo[] subFiles = Folder.GetFiles();
            for (int j = 0; j < subFiles.Length; j++)
            {
                if (subFiles[j].Extension.ToLower().Equals(".html"))
                {
                    FileStream fs = new FileStream(subFiles[j].FullName, FileMode.Open, FileAccess.Read);
                    bool bUtf8 = IsUTF8(fs);
                    fs.Close();
                    if (!bUtf8)
                    {
                        filelist.Append(subFiles[j].FullName);
                        filelist.Append("\r\n");
                    }
                }
            }
            return SplitString(filelist.ToString(), "\r\n");
        }
        //0000 0000-0000 007F - 0xxxxxxx  (ascii converts to 1 octet!)
        //0000 0080-0000 07FF - 110xxxxx 10xxxxxx    ( 2 octet format)
        //0000 0800-0000 FFFF - 1110xxxx 10xxxxxx 10xxxxxx (3 octet format)
        /// <summary>
        /// 判断文件流是否为UTF8字符集
        /// </summary>
        /// <param name="sbInputStream">文件流</param>
        /// <returns>判断结果</returns>
        private static bool IsUTF8(FileStream sbInputStream)
        {
            int i;
            byte cOctets;  // octets to go in this UTF-8 encoded character
            byte chr;
            bool bAllAscii = true;
            long iLen = sbInputStream.Length;
            cOctets = 0;
            for (i = 0; i < iLen; i++)
            {
                chr = (byte)sbInputStream.ReadByte();
                if ((chr & 0x80) != 0) bAllAscii = false;
                if (cOctets == 0)
                {
                    if (chr >= 0x80)
                    {
                        do
                        {
                            chr <<= 1;
                            cOctets++;
                        }
                        while ((chr & 0x80) != 0);
                        cOctets--;
                        if (cOctets == 0) return false;
                    }
                }
                else
                {
                    if ((chr & 0xC0) != 0x80) return false;
                    cOctets--;
                }
            }
            if (cOctets > 0) return false;
            if (bAllAscii) return false;
            return true;
        }
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">要分割的字符串</param>
        /// <param name="strSplit">分割标识</param>
        /// <returns>字符串数组</returns>
        internal static string[] SplitString(string strContent, string strSplit)
        {
            if (!string.IsNullOrEmpty(strContent))
            {
                if (strContent.IndexOf(strSplit) < 0) return new string[] { strContent };
                return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
            }
            else
            {
                return new string[0] { };
            }
        }

        #endregion

        #region 清理字符串

        /// <summary>
        /// 替换回车换行符为html换行符
        /// </summary>
        public static string StrFormat(string str)
        {
            string str2;
            if (str == null)
            {
                str2 = "";
            }
            else
            {
                str = str.Replace("\r\n", "<br />");
                str = str.Replace("\n", "<br />");
                str2 = str;
            }
            return str2;
        }
        /// <summary>
        /// 替换html字符
        /// </summary>
        public static string EncodeHtml(string strHtml)
        {
            if (strHtml != "")
            {
                strHtml = strHtml.Replace(",", "&def");
                strHtml = strHtml.Replace("'", "&dot");
                strHtml = strHtml.Replace(";", "&dec");
                return strHtml;
            }
            return "";
        }
        /// <summary>
        /// 进行指定的替换(脏字过滤)
        /// </summary>
        public static string StrFilter(string str, string bantext)
        {
            string text1 = "", text2 = "";
            string[] textArray1 = SplitString(bantext, "\r\n");
            for (int num1 = 0; num1 < textArray1.Length; num1++)
            {
                text1 = textArray1[num1].Substring(0, textArray1[num1].IndexOf("="));
                text2 = textArray1[num1].Substring(textArray1[num1].IndexOf("=") + 1);
                str = str.Replace(text1, text2);
            }
            return str;
        }
        /// <summary>
        /// 清除所有HTML函数 
        /// </summary>
        public static string ClearAllHTML(string Htmlstring)
        {
            //删除脚本 
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML 
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim().Replace(" ", "");
            return Htmlstring;
        }
        /// <summary>
        /// 移除Html标记
        /// </summary>
        /// <param name="content">原内容</param>
        /// <returns></returns>
        public static string RemoveHtml(string content)
        {
            return Regex.Replace(content, @"<[^>]*>", string.Empty, RegexOptions.IgnoreCase);
        }
        /// <summary>
        /// 过滤HTML中的不安全标签
        /// </summary>
        /// <param name="content">原内容</param>
        /// <returns></returns>
        public static string RemoveUnsafeHtml(string content)
        {
            content = Regex.Replace(content, @"(\<|\s+)o([a-z]+\s?=)", "$1$2", RegexOptions.IgnoreCase);
            content = Regex.Replace(content, @"(script|frame|form|meta|behavior|style)([\s|:|>])+", "$1.$2", RegexOptions.IgnoreCase);
            return content;
        }
        /// <summary>
        /// 将用户组Title中的font标签去掉
        /// </summary>
        /// <param name="title">用户组Title</param>
        /// <returns></returns>
        public static string RemoveFontTag(string title)
        {
            Match m = RegexFont.Match(title);
            if (m.Success) return m.Groups[1].Value;
            return title;
        }
        /// <summary>
        /// 从HTML中获取文本,保留br,p,img
        /// </summary>
        /// <param name="HTML"></param>
        /// <returns></returns>
        public static string GetTextFromHTML(string HTML)
        {
            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(@"</?(?!br|/?p|img)[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return regEx.Replace(HTML, "");
        }
        /// <summary>
        /// 为脚本替换特殊字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceStrToScript(string str)
        {
            return str.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\"", "\\\"");
        }

        #endregion

        #region 路径相关

        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="absoluteUrl">URL地址</param>
        /// <param name="relativeUrl">相对路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string absoluteUrl, string relativeUrl)
        {
            Uri baseUri = new Uri(absoluteUrl);
            Uri uri = new Uri(baseUri, relativeUrl);
            return uri.AbsoluteUri;
        }
        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }
        /// <summary>
        /// 获取站点根目录URL
        /// </summary>
        /// <returns></returns>
        public static string GetRootUrl(string forumPath)
        {
            int port = HttpContext.Current.Request.Url.Port;
            return string.Format("{0}://{1}{2}{3}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host.ToString(), (port == 80 || port == 0) ? "" : ":" + port, forumPath);
        }

        #endregion

        #region 获取 URL 指定文件内容

        /// <summary>
        /// 根据Url获得源文件内容
        /// </summary>
        /// <param name="strUrl">合法的Url地址</param>
        /// <returns></returns>
        public static string GetSourceTextByUrl(string strUrl)
        {
            WebResponse response = null;
            try
            {
                WebRequest request = WebRequest.Create(strUrl);
                request.Timeout = 30000;//30秒超时
                response = request.GetResponse();
                using (Stream resStream = response.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream))
                {
                    return sr.ReadToEnd();
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (response != null) response.Close();
            }
        }
        /// <summary>
        /// HTTP POST 请求 URL
        /// </summary>
        /// <param name="strUrl">URL 地址</param>
        /// <returns></returns>
        public static string GetHttpWebResponse(string strUrl)
        {
            return GetHttpWebResponse(strUrl, string.Empty);
        }
        /// <summary>
        /// HTTP POST 请求 URL
        /// </summary>
        /// <param name="strUrl">URL 地址</param>
        /// <param name="postData">POST 请求内容</param>
        /// <returns></returns>
        public static string GetHttpWebResponse(string strUrl, string postData)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(strUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.Timeout = 20000;
            HttpWebResponse response = null;
            try
            {
                using (StreamWriter swRequestWriter = new StreamWriter(request.GetRequestStream()))
                {
                    swRequestWriter.Write(postData);
                    if (swRequestWriter != null) swRequestWriter.Close();
                    response = (HttpWebResponse)request.GetResponse();
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (response != null) response.Close();
            }
        }

        #endregion

        #region 判断请求中的成员参数是否安全
        /*
        /// <summary>
        /// 判断请求中的成员参数是否安全
        /// </summary>
        /// <param name="context">Http 请求</param>
        /// <returns>验证结果</returns>
        public static bool ValidateParamIsSafeOfRequest(HttpContext context)
        {
            string getkeys = string.Empty;
            // QueryString 参数
            if (context.Request.QueryString != null)
            {
                for (int i = 0; i < context.Request.QueryString.Count; i++)
                {
                    getkeys = context.Request.QueryString.Keys[i];
                    if (DawnValidator.IsSqlFilter(context.Request.QueryString[getkeys].ToLower())) return false;
                }
            }
            // Form 参数
            if (context.Request.Form != null)
            {
                for (int i = 0; i < context.Request.Form.Count; i++)
                {
                    getkeys = context.Request.Form.Keys[i];
                    if (DawnValidator.IsSqlFilter(context.Request.Form[getkeys].ToLower())) return false;
                }
            }
            // Cookies 参数
            if (context.Request.Cookies != null)
            {
                for (int i = 0; i < context.Request.Cookies.Count; i++)
                {
                    getkeys = context.Request.Cookies.Keys[i];
                    if (DawnValidator.IsSqlFilter(context.Request.Cookies[getkeys].Value.ToLower())) return false;
                }
            }
            return true;
        }
        */
        #endregion

        #region 组件检测场

        /// <summary>
        /// 组件检测场
        /// </summary>
        /// <param name="objName">要检测的组件名称</param>
        /// <returns>是否支持 true/false</returns>
        public static bool SubassemblyCheck(string objName)
        {
            bool tmpFlg = false;
            try
            {
                object obj = System.Web.HttpContext.Current.Server.CreateObject(objName);
                tmpFlg = true;
                obj = null;
            }
            catch
            {
                tmpFlg = false;
            }
            return tmpFlg;
        }
        /// <summary>
        /// 组件检测场
        /// </summary>
        /// <param name="objName">要检测的组件名称</param>
        /// <returns>是否支持 true/false</returns>
        public static string SubassemblyAssembly(string objName)
        {
            string tmpObjInfo = null;
            try
            {
                object obj = System.Web.HttpContext.Current.Server.CreateObject(objName);
                tmpObjInfo = obj.GetType().Assembly.ToString();
            }
            catch
            {
                tmpObjInfo = null;
            }
            return tmpObjInfo;
        }

        #endregion

        #endregion

    }
}
#endif
