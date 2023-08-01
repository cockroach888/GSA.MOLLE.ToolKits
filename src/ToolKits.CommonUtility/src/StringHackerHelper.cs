//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：StringHackerHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2023-08-01 14:54:52
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.CommonUtility;

/// <summary>
/// 字符串相关操作与处理助手类
/// </summary>
public static class StringHackerHelper
{
    /// <summary>
    /// 将字符串转换为SQL所支持的单引号包裹格式
    /// </summary>
    /// <param name="originString">原始字符串</param>
    /// <param name="splitSeparator">分割符</param>
    /// <param name="joinSeparator">拼接符</param>
    /// <returns>转换后的关键字字符串</returns>
    public static string ToSQLFormatString(string originString, char splitSeparator, char joinSeparator)
    {
#if NETSTANDARD2_0
        return string.Join(joinSeparator.ToString(), ToSQLFormat(originString, splitSeparator));
#else
        return string.Join(joinSeparator, ToSQLFormat(originString, splitSeparator));
#endif
    }

    /// <summary>
    /// 将字符串转换为SQL所支持的单引号包裹格式
    /// </summary>
    /// <param name="keywords">需要转换的原始关键字枚举列表</param>
    /// <param name="separator">拼接符</param>
    /// <returns>转换后的关键字字符串</returns>
    public static string ToSQLFormatString(IEnumerable<string> keywords, char separator)
    {
#if NETSTANDARD2_0
        return string.Join(separator.ToString(), ToSQLFormat(keywords));
#else
        return string.Join(separator, ToSQLFormat(keywords));
#endif
    }


    /// <summary>
    /// 将字符串转换为SQL所支持的单引号包裹格式
    /// </summary>
    /// <param name="originString">原始字符串</param>
    /// <param name="separator">分割符</param>
    /// <returns>转换后的关键字枚举列表</returns>
    public static IEnumerable<string> ToSQLFormat(string originString, char separator)
    {
        IEnumerable<string> keywords = originString.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        return ToSQLFormat(keywords);
    }

    /// <summary>
    /// 将字符串转换为SQL所支持的单引号包裹格式
    /// </summary>
    /// <param name="keywords">需要转换的原始关键字枚举列表</param>
    /// <returns>转换后的关键字枚举列表</returns>
    public static IEnumerable<string> ToSQLFormat(IEnumerable<string> keywords)
    {
        foreach (string item in keywords)
        {
            yield return $"'{item}'";
        }
    }
}