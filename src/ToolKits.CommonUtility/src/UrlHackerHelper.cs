//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：UrlHackerHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-10-13 09:37:17
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Text.RegularExpressions;

namespace GSA.ToolKits.CommonUtility;

/// <summary>
/// Url相关操作与处理助手类
/// </summary>
public static class UrlHackerHelper
{
    /// <summary>
    /// 验证 Url 链接是否包含协议标识   
    /// </summary>
    /// <remarks>不包含 http:// 或 https:// 时， 链接将自动补全 http:// 标识。</remarks>
    /// <param name="urlString">需要验证的 Url 链接</param>
    /// <returns>验证后的 Url 链接</returns>
    public static string HackerToHttp(string urlString)
    {
        var pattern = new Regex(@"^\w+:(//)?");

        if (pattern.Match(urlString).Success)
        {
            return urlString;
        }

        if (urlString.EndsWith("/"))
        {
            urlString = urlString.Remove(urlString.Length - 1);
        }

        return $"http://{urlString}";
    }

    /// <summary>
    /// 验证 Url 链接是否包含协议标识
    /// </summary>
    /// <remarks>不包含 http:// 或 https:// 时， 链接将自动补全 https:// 标识。</remarks>
    /// <param name="urlString">需要验证的 Url 链接</param>
    /// <returns>验证后的 Url 链接</returns>
    public static string HackerToHttps(string urlString)
    {
        var pattern = new Regex(@"^\w+:(//)?");

        if (pattern.Match(urlString).Success)
        {
            return urlString;
        }

        if (urlString.EndsWith("/"))
        {
            urlString = urlString.Remove(urlString.Length - 1);
        }

        return $"https://{urlString}";
    }
}