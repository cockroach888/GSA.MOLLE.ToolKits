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
}