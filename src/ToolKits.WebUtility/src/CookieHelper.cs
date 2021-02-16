//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：CookieHelper.cs
// 项目名称：网页网站实用工具集
// 创建时间：2014年2月24日12时29分
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
using System.Web;

namespace ToolKits.WebUtility
{
    /// <summary>
    /// Cookies操作辅助类
    /// </summary>
    public static class CookieHelper
    {

        #region Cookies 读取

        /// <summary>
        /// 获取 Cookies 对象
        /// </summary>
        /// <param name="cookieName">Cookies 名称</param>
        /// <returns>Cookies 数据对象</returns>
        public static string Get(string cookieName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                return HttpContext.Current.Request.Cookies[cookieName].Value;
            }
            return null;
        }
        /// <summary>
        /// 获取 Cookies 对象
        /// <para>支持 Cookies 跨域</para>
        /// </summary>
        /// <param name="cookieName">Cookies 名称</param>
        /// <param name="cookieKey">Cookies 键名</param>
        /// <returns>Cookies 数据对象</returns>
        public static string Get(string cookieName, string cookieKey)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[cookieName] != null && HttpContext.Current.Request.Cookies[cookieName][cookieKey] != null)
            {
                return HttpContext.Current.Request.Cookies[cookieName][cookieKey].ToString();
            }
            return null;
        }

        #endregion

        #region Cookies 写入

        /// <summary>
        /// 添加 Cookies 对象
        /// </summary>
        /// <param name="cookieName">Cookies 名称</param>
        /// <param name="cookieValue">Cookies 数值</param>
        public static void Add(string cookieName, string cookieValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null) cookie = new HttpCookie(cookieName);
            cookie.Value = cookieValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 添加 Cookies 对象
        /// </summary>
        /// <param name="cookieName">Cookies 名称</param>
        /// <param name="cookieKey">Cookies 键名</param>
        /// <param name="cookieValue">Cookies 数值</param>
        public static void Add(string cookieName, string cookieKey, string cookieValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null) cookie = new HttpCookie(cookieName);
            cookie[cookieKey] = cookieValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 添加 Cookies 对象
        /// </summary>
        /// <param name="cookieName">Cookies 名称</param>
        /// <param name="cookieValue">Cookies 数值</param>
        /// <param name="expires">过期时间(分钟)</param>
        public static void Add(string cookieName, string cookieValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null) cookie = new HttpCookie(cookieName);
            cookie.Value = cookieValue;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        #endregion

        #region Cookies 跨域写入

        /// <summary>
        /// 添加 Cookies 对象
        /// <para>支持 Cookies 跨域</para>
        /// </summary>
        /// <param name="cookieName">Cookies 名称</param>
        /// <param name="cookieValue">Cookies 数值</param>
        /// <param name="expires">过期时间(分钟)</param>
        /// <param name="strDomain">Cookies 跨域名称</param>
        public static void Add(string cookieName, string cookieValue, int expires, string strDomain)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null)
            {
                cookie = new HttpCookie(cookieName);
            }
            cookie.Domain = strDomain;
            cookie.Path = "/";
            cookie.Value = cookieValue;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 添加 Cookies 对象
        /// <para>支持 Cookies 跨域</para>
        /// </summary>
        /// <param name="cookieName">Cookies 名称</param>
        /// <param name="cookieKey">Cookies 键名</param>
        /// <param name="cookieValue">Cookies 数值</param>
        /// <param name="expires">过期时间(分钟)</param>
        /// <param name="strDomain">Cookies 跨域名称</param>
        public static void Add(string cookieName, string cookieKey, string cookieValue, int expires, string strDomain)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null)
            {
                cookie = new HttpCookie(cookieName);
                cookie.Domain = strDomain;
                cookie.Path = "/";
                cookie.Values.Add(cookieKey, cookieValue);
                cookie.Expires = DateTime.Now.AddMinutes(expires);
                HttpContext.Current.Response.AppendCookie(cookie);
            }
            else
            {
                if (HttpContext.Current.Request.Cookies[cookieName].Values[cookieKey] != null)
                {
                    cookie.Values.Set(cookieKey, cookieValue);
                    cookie.Expires = DateTime.Now.AddMinutes(expires);
                }
                else
                {
                    cookie.Domain = strDomain;
                    cookie.Path = "/";
                    cookie.Values.Add(cookieKey, cookieValue);
                    cookie.Expires = DateTime.Now.AddMinutes(expires);
                    HttpContext.Current.Response.AppendCookie(cookie);
                }
            }
        }

        #endregion

        #region Cookies 移除

        /// <summary>
        /// 移除 Cookies 对象
        /// <para>移除指定名称</para>
        /// </summary>
        /// <param name="cookieName">Cookies 名称</param>
        /// <returns>Cookies 数据对象</returns>
        public static void Remove(string cookieName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                HttpContext.Current.Request.Cookies.Remove(cookieName);
            }
        }
        /// <summary>
        /// 移除 Cookies 对象
        /// <para>移除具有指定名称</para>
        /// </summary>
        /// <param name="cookieName">Cookies 名称</param>
        public static void RemoveAt(string cookieName)
        {
            System.Collections.IEnumerator cookieEnum = HttpContext.Current.Request.Cookies.GetEnumerator();
            while (cookieEnum.MoveNext())
            {
                if (cookieEnum.Current.ToString().IndexOf(cookieName) >= 0) HttpContext.Current.Request.Cookies.Remove(cookieEnum.Current.ToString());
            }
        }
        /// <summary>
        /// 移除 Cookies 对象
        /// <para>移除所有</para>
        /// </summary>
        public static void Remove()
        {
            HttpContext.Current.Request.Cookies.Clear();
            //System.Collections.IEnumerator cookieEnum = HttpContext.Current.Request.Cookies.GetEnumerator();
            //while (cookieEnum.MoveNext())
            //{
            //    HttpContext.Current.Request.Cookies.Remove(cookieEnum.Current.ToString());                
            //}
        }

        #endregion

        #region Cookies 读取&Url自动解码

        /// <summary>
        /// 获取 Cookies 对象
        /// <para>UrlDecode UTF-8</para>
        /// </summary>
        /// <param name="cookieName">Cookies 名称</param>
        /// <returns>Cookies 数据对象</returns>
        public static string GetOf(string cookieName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                return HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[cookieName].Value, System.Text.Encoding.GetEncoding("utf-8"));
            }
            return null;
        }
        /// <summary>
        /// 获取 Cookies 对象
        /// <para>支持 Cookies 跨域</para>
        /// <para>UrlDecode UTF-8</para>
        /// </summary>
        /// <param name="cookieName">Cookies 名称</param>
        /// <param name="cookieKey">Cookies 键名</param>
        /// <returns>Cookies 数据对象</returns>
        public static string GetOf(string cookieName, string cookieKey)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[cookieName] != null && HttpContext.Current.Request.Cookies[cookieName][cookieKey] != null)
            {
                return HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[cookieName][cookieKey].ToString(), System.Text.Encoding.GetEncoding("utf-8"));
            }
            return null;
        }

        #endregion

        #region Cookies 写入&Url自动编码

        /// <summary>
        /// 添加 Cookies 对象
        /// <para>UrlEncode UTF-8</para>
        /// </summary>
        /// <param name="cookieName">Cookies 名称</param>
        /// <param name="cookieValue">Cookies 数值</param>
        public static void AddOf(string cookieName, string cookieValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null) cookie = new HttpCookie(cookieName);
            cookie.Value = System.Web.HttpUtility.UrlEncode(cookieValue, System.Text.Encoding.GetEncoding("utf-8"));
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 添加 Cookies 对象
        /// <para>UrlEncode UTF-8</para>
        /// </summary>
        /// <param name="cookieName">Cookies 名称</param>
        /// <param name="cookieKey">Cookies 键名</param>
        /// <param name="cookieValue">Cookies 数值</param>
        public static void AddOf(string cookieName, string cookieKey, string cookieValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null) cookie = new HttpCookie(cookieName);
            cookie[cookieKey] = System.Web.HttpUtility.UrlEncode(cookieValue, System.Text.Encoding.GetEncoding("utf-8"));
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 添加 Cookies 对象
        /// <para>UrlEncode UTF-8</para>
        /// </summary>
        /// <param name="cookieName">Cookies 名称</param>
        /// <param name="cookieValue">Cookies 数值</param>
        /// <param name="expires">过期时间(分钟)</param>
        public static void AddOf(string cookieName, string cookieValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null) cookie = new HttpCookie(cookieName);
            cookie.Value = System.Web.HttpUtility.UrlEncode(cookieValue, System.Text.Encoding.GetEncoding("utf-8"));
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        #endregion

        #region Cookies 跨域写入&Url自动编码

        /// <summary>
        /// 添加 Cookies 对象
        /// <para>支持 Cookies 跨域</para>
        /// <para>UrlEncode UTF-8</para>
        /// </summary>
        /// <param name="cookieName">Cookies 名称</param>
        /// <param name="cookieValue">Cookies 数值</param>
        /// <param name="expires">过期时间(分钟)</param>
        /// <param name="strDomain">Cookies 跨域名称</param>
        public static void AddOf(string cookieName, string cookieValue, int expires, string strDomain)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null)
            {
                cookie = new HttpCookie(cookieName);
            }
            cookie.Domain = strDomain;
            cookie.Path = "/";
            cookie.Value = System.Web.HttpUtility.UrlEncode(cookieValue, System.Text.Encoding.GetEncoding("utf-8"));
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 添加 Cookies 对象
        /// <para>支持 Cookies 跨域</para>
        /// <para>UrlEncode UTF-8</para>
        /// </summary>
        /// <param name="cookieName">Cookies 名称</param>
        /// <param name="cookieKey">Cookies 键名</param>
        /// <param name="cookieValue">Cookies 数值</param>
        /// <param name="expires">过期时间(分钟)</param>
        /// <param name="strDomain">Cookies 跨域名称</param>
        public static void AddOf(string cookieName, string cookieKey, string cookieValue, int expires, string strDomain)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null)
            {
                cookie = new HttpCookie(cookieName);
                cookie.Domain = strDomain;
                cookie.Path = "/";
                cookie.Values.Add(cookieKey, System.Web.HttpUtility.UrlEncode(cookieValue, System.Text.Encoding.GetEncoding("utf-8")));
                cookie.Expires = DateTime.Now.AddMinutes(expires);
                HttpContext.Current.Response.AppendCookie(cookie);
            }
            else
            {
                if (HttpContext.Current.Request.Cookies[cookieName].Values[cookieKey] != null)
                {
                    cookie.Values.Set(cookieKey, System.Web.HttpUtility.UrlEncode(cookieValue, System.Text.Encoding.GetEncoding("utf-8")));
                    cookie.Expires = DateTime.Now.AddMinutes(expires);
                }
                else
                {
                    cookie.Domain = strDomain;
                    cookie.Path = "/";
                    cookie.Values.Add(cookieKey, System.Web.HttpUtility.UrlEncode(cookieValue, System.Text.Encoding.GetEncoding("utf-8")));
                    cookie.Expires = DateTime.Now.AddMinutes(expires);
                    HttpContext.Current.Response.AppendCookie(cookie);
                }
            }
        }

        #endregion

    }
}
#endif
