//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：CommonHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-06-22 10:14:29
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.CommonUtility.Entity;
using System.Text;
using System.Text.RegularExpressions;

namespace GSA.ToolKits.CommonUtility;

/// <summary>
/// 常见和通用的功能应用助手类
/// </summary>
public static class CommonHelper
{
    /// <summary>
    /// 获取一个新的GUID值
    /// </summary>
    /// <param name="type">格式化类型，缺省"N"。</param>
    /// <param name="isUpper">是否为大写形式，缺省小写。</param>
    /// <returns>GUID值</returns>
    public static string NewGUID(GuidFormatType type = GuidFormatType.N, bool isUpper = false)
    {
        string typeString = Enum.GetName(typeof(GuidFormatType), type);
        string result = Guid.NewGuid().ToString(typeString);
        return isUpper ? result.ToUpperInvariant() : result.ToLowerInvariant();
    }

    /// <summary>
    /// 获取多个GUID值
    /// </summary>
    /// <param name="number">数量</param>
    /// <param name="type">格式化类型，缺省"N"。</param>
    /// <param name="isUpper">是否为大写形式，缺省小写。</param>
    /// <returns>GUID值枚举列表</returns>
    public static IEnumerable<string> NewGUID(int number, GuidFormatType type = GuidFormatType.N, bool isUpper = false)
    {
        for (int i = 0; i < number; i++)
        {
            yield return NewGUID(type, isUpper);
        }
    }

    /// <summary>
    /// 获取一个由新的GUID值转HashCode后的uint数值
    /// </summary>
    /// <remarks>理论上转换后的uint数值是唯一性的，建议使用时作再次比对。</remarks>
    /// <returns>非负数的 uint 数值</returns>
    public static uint NewGUIDtoUint()
    {
        Guid guid = Guid.NewGuid();
        byte[] bytes = guid.ToByteArray();

        uint hashCode = BitConverter.ToUInt32(bytes, 0);
        if (hashCode == uint.MinValue)
        {
            hashCode = uint.MaxValue;
        }

        // 避免哈希码重复
        HashSet<uint> hashSet = new();
        while (!hashSet.Add(hashCode))
        {
            guid = Guid.NewGuid();
            bytes = guid.ToByteArray();

            hashCode = BitConverter.ToUInt32(bytes, 0);
            if (hashCode == uint.MinValue)
            {
                hashCode = uint.MaxValue;
            }
        }

        return hashCode;
    }




    /// <summary>
    /// 随机获取某枚举定义中的某个枚举值
    /// </summary>
    /// <typeparam name="T">枚举泛型</typeparam>
    /// <returns>枚举值</returns>
    public static T GetEnumOfRandom<T>() where T : Enum
    {
        T[] arrays = (T[])Enum.GetValues(typeof(T));
#if NET6_0_OR_GREATER
        return arrays[Random.Shared.Next(0, arrays.Length)];
#else        
        return arrays[new Random().Next(0, arrays.Length)];
#endif
    }

    /// <summary>
    /// 使用正则表达式从源字符串中提取匹配成功的内容
    /// </summary>
    /// <param name="sourceString">源字符串</param>
    /// <param name="pattern">正则表达式，暂仅支持单一匹配形式。</param>
    /// <returns>提取的内容，无匹配项时返回空字符串。</returns>
    public static string UseRegularExtractingContent(string? sourceString, Regex? pattern)
    {
        if (string.IsNullOrWhiteSpace(sourceString) || pattern is null)
        {
            return string.Empty;
        }

        Match match = pattern.Match(sourceString);

        if (match.Success && match.Groups.Count >= 2)
        {
            return match.Groups[1].Value;
        }

        return string.Empty;
    }

    /// <summary>
    /// 使用多个正则表达式，从源字符串中按顺序提取首次匹配成功的内容。
    /// </summary>
    /// <param name="sourceString">源字符串</param>
    /// <param name="patterns">正则表达式数组，暂仅支持单一匹配形式。</param>
    /// <returns>提取的内容，无匹配项时返回空字符串。</returns>
    public static string UseRegularExtractingContent(string? sourceString, params Regex[]? patterns)
    {
        if (string.IsNullOrWhiteSpace(sourceString) || patterns is null)
        {
            return string.Empty;
        }

        string result = string.Empty;
        foreach (Regex pattern in patterns)
        {
            result = UseRegularExtractingContent(sourceString, pattern);

            if (!string.IsNullOrWhiteSpace(result))
            {
                break;
            }
        }

        return result;
    }


    /// <summary>
    /// 将源字符串转换为Base64编码的字符串 (使用UTF8编码)
    /// </summary>
    /// <param name="sourceString">源字符串</param>
    /// <param name="isPlusEscapes">是否使用加号(+)转义替换，默认true使用。 (将+号替换为%2B转义)</param>
    /// <returns>Base64编码字符串</returns>
    public static string ToBase64Encode(string sourceString, bool isPlusEscapes = true)
    {
        string base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes(sourceString));

        if (isPlusEscapes)
        {
            base64String = base64String.Replace("+", "%2B");
        }

        return base64String;
    }

    /// <summary>
    /// 将Base64编码的字符串转换为源字符串 (使用UTF8编码)
    /// </summary>
    /// <param name="base64String">Base64编码字符串</param>
    /// <param name="isPlusEscapes">是否使用加号(+)转义替换，默认true使用。 (将%2B转义替换为+号)</param>
    /// <returns>源字符串</returns>
    public static string FromBase64Decode(string base64String, bool isPlusEscapes = true)
    {
        if (isPlusEscapes)
        {
            base64String = base64String.Replace("%2B", "+");
        }

        return Encoding.UTF8.GetString(Convert.FromBase64String(base64String));
    }
}