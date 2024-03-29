﻿//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：CustomAttributeValueHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-09-01 13:48:12
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Reflection;

namespace GSA.ToolKits.CommonUtility;

/// <summary>
/// 自定义属性助手类
/// </summary>
/// <remarks>
/// <example>
/// DatabaseInfo.cs
/// <code>
/// [Table("TableTableTable")]
/// public sealed class DatabaseInfo
/// {
///     public string? Name { get; set; }
/// 
///     [JsonPropertyName("created_time")]
///     public DateTime CreatedTime { get; set; }
/// 
///     [JsonIgnore]
///     [JsonPropertyName("report_time")]
///     public DateTime ReportTime;
/// 
///     [Required]
///     public sbyte Update { get; set; }
/// 
///     public string? Status { get; set; }
/// }
/// </code>
/// Usage examples:
/// <code>
/// Type type = typeof(DatabaseInfo);
/// PropertyInfo[] properties = type.GetProperties();
/// MemberInfo member = properties[1];
/// 
/// bool bool01 = CustomAttributeHelper.Exists&lt;JsonIgnoreAttribute&gt;(member);
/// 
/// bool bool02 = CustomAttributeHelper.Exists&lt;TableAttribute&gt;(type);
/// bool bool03 = CustomAttributeHelper.Exists&lt;RequiredAttribute&gt;(type, "Update");
/// bool bool031 = CustomAttributeHelper.Exists&lt;JsonIgnoreAttribute&gt;(type, "ReportTime");
/// 
/// bool bool04 = CustomAttributeHelper.Exists&lt;DatabaseInfo, TableAttribute&gt;();
/// bool bool05 = CustomAttributeHelper.Exists&lt;DatabaseInfo, RequiredAttribute&gt;("Update");
/// bool bool06 = member.Exists&lt;JsonIgnoreAttribute&gt;();
/// 
/// bool bool07 = type.Exists&lt;TableAttribute&gt;();
/// bool bool08 = type.Exists&lt;RequiredAttribute&gt;("Update");
/// 
/// 
/// var value01 = CustomAttributeHelper.GetValue&lt;JsonPropertyNameAttribute, string&gt;(member, p =&gt; p.Name);
/// 
/// var value02 = CustomAttributeHelper.GetValue&lt;JsonPropertyNameAttribute, string&gt;(type, p =&gt; p.Name);
/// var value03 = CustomAttributeHelper.GetValue&lt;JsonPropertyNameAttribute, string&gt;(type, p =&gt; p.Name, "CreatedTime");
/// 
/// var value04 = CustomAttributeHelper.GetValue&lt;DatabaseInfo, TableAttribute, string&gt;(p =&gt; p.Name);
/// var value05 = CustomAttributeHelper.GetValue&lt;DatabaseInfo, JsonPropertyNameAttribute, string&gt;(p =&gt; p.Name, memberName: "CreatedTime");
/// 
/// var value06 = member.GetCustomAttributeValue&lt;JsonPropertyNameAttribute, string&gt;(p =&gt; p.Name);
/// 
/// var value07 = type.GetCustomAttributeValue&lt;JsonPropertyNameAttribute, string&gt;(p =&gt; p.Name);
/// var value08 = type.GetCustomAttributeValue&lt;JsonPropertyNameAttribute, string&gt;(p =&gt; p.Name, "CreatedTime");
/// </code>
/// </example>
/// </remarks>
public static class CustomAttributeHelper
{
    /// <summary>
    /// 是否存指定泛型对象的自定义属性
    /// </summary>
    /// <typeparam name="TAttribute">自定义属性泛型</typeparam>
    /// <param name="member">表示成员的属性信息</param>
    /// <returns>true 存在 / false 不存在</returns>
    public static bool Exists<TAttribute>(MemberInfo? member)
        where TAttribute : Attribute
    {
        if (member is null)
        {
            return false;
        }

        return member.GetCustomAttributes<TAttribute>(false).Any();
    }

    /// <summary>
    /// 是否存指定泛型对象的自定义属性
    /// </summary>
    /// <typeparam name="TAttribute">自定义属性泛型</typeparam>
    /// <param name="type">应用自定义属性的类型对象</param>
    /// <param name="memberName">成员元数据的名称</param>
    /// <returns>true 存在 / false 不存在</returns>
    public static bool Exists<TAttribute>(Type type, string? memberName = null)
        where TAttribute : Attribute
    {
        if (memberName is null)
        {
            return type.GetCustomAttributes<TAttribute>(false).Any();
        }

        MemberInfo? member = type.GetMember(memberName).FirstOrDefault();
        return Exists<TAttribute>(member);
    }

    /// <summary>
    /// 是否存指定泛型对象的自定义属性
    /// </summary>
    /// <typeparam name="TType">应用自定义属性的泛型</typeparam>
    /// <typeparam name="TAttribute">自定义属性泛型</typeparam>
    /// <param name="memberName">成员元数据的名称</param>
    /// <returns>true 存在 / false 不存在</returns>
    public static bool Exists<TType, TAttribute>(string? memberName = null)
        where TType : class
        where TAttribute : Attribute
        => Exists<TAttribute>(typeof(TType), memberName);

    /// <summary>
    /// 获取自定义属性中指定成员元数据的值
    /// </summary>
    /// <typeparam name="TAttribute">自定义属性泛型</typeparam>
    /// <typeparam name="TValue">数据类型泛型</typeparam>
    /// <param name="member">表示成员的属性信息</param>
    /// <param name="valueCallback">用于获取成员元数据的回调函数</param>
    /// <returns>成员元数据的值</returns>
    public static TValue? GetValue<TAttribute, TValue>(MemberInfo? member, Func<TAttribute, TValue> valueCallback)
        where TAttribute : Attribute
    {
        if (member is null)
        {
            return default;
        }

        TAttribute? attr = member.GetCustomAttributes<TAttribute>(false).FirstOrDefault();
        return attr is null ? default : valueCallback(attr);
    }

    /// <summary>
    /// 获取自定义属性中指定成员元数据的值
    /// </summary>
    /// <typeparam name="TAttribute">自定义属性泛型</typeparam>
    /// <typeparam name="TValue">数据类型泛型</typeparam>
    /// <param name="type">应用自定义属性的类型对象</param>
    /// <param name="valueCallback">用于获取成员元数据的回调函数</param>
    /// <param name="memberName">成员元数据的名称</param>
    /// <returns>成员元数据的值</returns>
    public static TValue? GetValue<TAttribute, TValue>(Type type, Func<TAttribute, TValue> valueCallback, string? memberName = null)
        where TAttribute : Attribute
    {
        TAttribute? attr;

        if (memberName is null)
        {
            attr = type.GetCustomAttributes<TAttribute>(false).FirstOrDefault();
        }
        else
        {
            MemberInfo? member = type.GetMember(memberName).FirstOrDefault();
            attr = member?.GetCustomAttributes<TAttribute>(false).FirstOrDefault();
        }

        return attr is null ? default : valueCallback(attr);
    }

    /// <summary>
    /// 获取自定义属性中指定成员元数据的值
    /// </summary>
    /// <typeparam name="TType">应用自定义属性的泛型</typeparam>
    /// <typeparam name="TAttribute">自定义属性泛型</typeparam>
    /// <typeparam name="TValue">数据类型泛型</typeparam>
    /// <param name="valueCallback">用于获取成员元数据的回调函数</param>
    /// <param name="memberName">成员元数据的名称</param>
    /// <returns>成员元数据的值</returns>
    public static TValue? GetValue<TType, TAttribute, TValue>(Func<TAttribute, TValue> valueCallback, string? memberName = null)
        where TType : class
        where TAttribute : Attribute
        => GetValue(typeof(TType), valueCallback, memberName);
}