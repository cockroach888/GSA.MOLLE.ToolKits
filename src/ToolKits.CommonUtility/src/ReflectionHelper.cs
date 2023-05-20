//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：ReflectionHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2023-05-19 13:54:00
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
/// 反射特性应用助手类
/// </summary>
public static class ReflectionHelper
{
    /// <summary>
    /// 通过反射为指定名称的属性写入指定的值
    /// </summary>
    /// <remarks>注意：不支持只读属性赋值</remarks>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <param name="model">需要写入的对象</param>
    /// <param name="propertyName">需要写入的名称</param>
    /// <param name="propertyValue">需要写入的值</param>
    /// <param name="isIgnoreCase">是否忽略大小写，缺省不忽略。</param>
    public static void SetPropertyValue<TModel>(TModel model, string propertyName, object propertyValue, bool isIgnoreCase = false)
        where TModel : class
    {
        Type type = typeof(TModel);
        IEnumerable<PropertyInfo> properties = type.GetProperties().Where(p => p.CanWrite);
        PropertyInfo? property;

        if (isIgnoreCase)
        {
            property = properties.SingleOrDefault(p => p.Name.ToUpperInvariant() == propertyName.ToUpperInvariant());
        }
        else
        {
            property = properties.SingleOrDefault(p => p.Name == propertyName);
        }

        property?.SetValue(model, propertyValue, null);
    }

    /// <summary>
    /// 通过反射为指定名称的字段写入指定的值
    /// </summary>
    /// <remarks>注意：不支持只读字段赋值</remarks>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <param name="model">需要写入的对象</param>
    /// <param name="fieldName">需要写入的名称</param>
    /// <param name="fieldValue">需要写入的值</param>
    /// <param name="isIgnoreCase">是否忽略大小写，缺省不忽略。</param>
    public static void SetFieldValue<TModel>(TModel model, string fieldName, object fieldValue, bool isIgnoreCase = false)
        where TModel : class
    {
        Type type = typeof(TModel);
        IEnumerable<FieldInfo> fields = type.GetFields().Where(p => !p.IsInitOnly);
        FieldInfo? field;

        if (isIgnoreCase)
        {
            field = fields.SingleOrDefault(p => p.Name.ToUpperInvariant() == fieldName.ToUpperInvariant());
        }
        else
        {
            field = fields.SingleOrDefault(p => p.Name == fieldName);
        }

        field?.SetValue(model, fieldValue);
    }
}