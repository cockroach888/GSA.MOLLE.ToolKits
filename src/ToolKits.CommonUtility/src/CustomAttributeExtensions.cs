//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：CustomAttributeExtensions.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-09-01 14:36:01
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.CommonUtility;
using System.Reflection;

/// <summary>
/// 自定义属性扩展类
/// </summary>
public static class CustomAttributeExtensions
{
    /// <summary>
    /// 是否存指定泛型对象的自定义属性
    /// </summary>
    /// <typeparam name="TAttribute">自定义属性泛型</typeparam>
    /// <param name="member">表示成员的属性信息</param>
    /// <returns>true 存在 / false 不存在</returns>
    public static bool Exists<TAttribute>(this MemberInfo member)
        where TAttribute : Attribute
        => CustomAttributeHelper.Exists<TAttribute>(member);

    /// <summary>
    /// 是否存指定泛型对象的自定义属性
    /// </summary>
    /// <typeparam name="TAttribute">自定义属性泛型</typeparam>
    /// <param name="type">应用自定义属性的类型对象</param>
    /// <param name="memberName">成员元数据的名称</param>
    /// <returns>true 存在 / false 不存在</returns>
    public static bool Exists<TAttribute>(this Type type, string? memberName = null)
        where TAttribute : Attribute
        => CustomAttributeHelper.Exists<TAttribute>(type, memberName);

    /// <summary>
    /// 获取自定义属性中指定成员元数据的值
    /// </summary>
    /// <typeparam name="TAttribute">自定义属性泛型</typeparam>
    /// <typeparam name="TValue">数据类型泛型</typeparam>
    /// <param name="member">表示成员的属性信息</param>
    /// <param name="valueCallback">用于获取成员元数据的回调函数</param>
    /// <returns>成员元数据的值</returns>
    public static TValue? GetCustomAttributeValue<TAttribute, TValue>(this MemberInfo member, Func<TAttribute, TValue> valueCallback)
        where TAttribute : Attribute
        => CustomAttributeHelper.GetValue(member, valueCallback);

    /// <summary>
    /// 获取自定义属性中指定成员元数据的值
    /// </summary>
    /// <typeparam name="TAttribute">自定义属性泛型</typeparam>
    /// <typeparam name="TValue">数据类型泛型</typeparam>
    /// <param name="type">应用自定义属性的类型对象</param>
    /// <param name="valueCallback">用于获取成员元数据的回调函数</param>
    /// <param name="memberName">成员元数据的名称</param>
    /// <returns>成员元数据的值</returns>
    public static TValue? GetCustomAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueCallback, string? memberName = null)
        where TAttribute : Attribute
        => CustomAttributeHelper.GetValue(type, valueCallback, memberName);
}