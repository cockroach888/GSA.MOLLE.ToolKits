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
namespace GSA.ToolKits.CommonUtility;

/// <summary>
/// 常见和通用的功能应用助手类
/// </summary>
public static class CommonHelper
{
    /// <summary>
    /// 获取一个新的GUID值
    /// </summary>
    /// <remarks>使用32位字符串，全大写形式。</remarks>
    /// <returns>GUID值</returns>
    public static string NewGUID() => Guid.NewGuid().ToString("N").ToUpperInvariant();

    /// <summary>
    /// 随机获取某枚举定义中的某个枚举值
    /// </summary>
    /// <typeparam name="T">枚举泛型</typeparam>
    /// <returns>枚举值</returns>
    public static T GetEnumOfRandom<T>() where T : Enum
    {
        T[] arrays = (T[])Enum.GetValues(typeof(T));
        return arrays[Random.Shared.Next(0, arrays.Length)];
    }
}