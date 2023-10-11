//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDataModelHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-06-22 17:20:20
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.CommonUtility.Schema;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;

namespace GSA.ToolKits.CommonUtility;

/// <summary>
/// 数据模型属性字段名称与值字符串拼接助手类
/// </summary>
public static class TDataModelHelper
{
    /// <summary>
    /// 从指定数据模型中，获取其成员表示数据字段的名称，并拼接成字符串。
    /// </summary>
    /// <remarks>被获取的字段名称，来源于其成员自定义属性(ColumnAttribute)配置值（如：[Column("station_id")]）。</remarks>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <typeparam name="TIgnoreAttribute">自定义属性泛型(忽略的)</typeparam>
    /// <returns>数据字段名称拼接字符串</returns>
    public static string GetColumnNameString<TModel, TIgnoreAttribute>()
        where TModel : class, new()
        where TIgnoreAttribute : Attribute
    {
        Type type = typeof(TModel);
        PropertyInfo[] properties = type.GetProperties();
        StringBuilder sb = new();

        foreach (PropertyInfo property in properties)
        {
            if (property.Exists<TIgnoreAttribute>())
            {
                continue;
            }

            string? columnName = property.GetCustomAttributeValue<ColumnAttribute, string?>(x => x.Name);

            if (columnName is not null)
            {
                sb.Append($"{columnName},");
            }
        }

        if (sb.Length > 2)
        {
            sb.Remove(sb.Length - 1, 1);
        }

        return sb.ToString();
    }

    /// <summary>
    /// 从指定数据模型中，获取其成员表示数据字段的名称，并拼接成字符串。
    /// </summary>
    /// <remarks>被获取的字段名称，来源于其成员自定义属性(ColumnAttribute)配置值（如：[Column("station_id")]）。</remarks>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <returns>数据字段名称拼接字符串</returns>
    public static string GetColumnNameString<TModel>()
        where TModel : class, new()
        => GetColumnNameString<TModel, SpecialNullableTypeAttribute>();


    /// <summary>
    /// 从指定数据模型中，获取其成员的值，并拼接成字符串。
    /// </summary>
    /// <remarks>被获取的字段名称，来源于其成员自定义属性(ColumnAttribute)配置值（如：[Column("station_id")]）。</remarks>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <typeparam name="TIgnoreAttribute">自定义属性泛型(忽略的)</typeparam>
    /// <param name="model">数据模型实例</param>
    /// <param name="returnNameString">是否返回数据字段的名称字符串(缺省为返回)</param>
    /// <returns>数据库字段值拼接字符串</returns>
    /// <exception cref="TypeAccessException">暂不支持的数据类型异常</exception>
    public static (string NameString, string ValueString) GetColumnValueString<TModel, TIgnoreAttribute>(TModel model, bool returnNameString = true)
        where TModel : class, new()
        where TIgnoreAttribute : Attribute
    {
        Type type = model.GetType();
        PropertyInfo[] properties = type.GetProperties();
        StringBuilder sbName = new();
        StringBuilder sbValue = new();

        foreach (PropertyInfo property in properties)
        {
            if (property.Exists<TIgnoreAttribute>())
            {
                continue;
            }

            object? value = property.GetValue(model);

            if (value is null)
            {
                continue;
            }

            switch (property.PropertyType)
            {
                case Type tbool when tbool == typeof(bool):
                case Type tstring when tstring == typeof(string):
                    sbValue.Append($"'{value}',");
                    break;
                case Type ttime when ttime == typeof(DateTime):
                    sbValue.Append($"'{value:yyyy-MM-dd HH:mm:ss.fff}',");
                    break;
                case Type tsbyte when tsbyte == typeof(sbyte):
                case Type tbyte when tbyte == typeof(byte):
                case Type tshort when tshort == typeof(short):
                case Type tushort when tushort == typeof(ushort):
                case Type tint when tint == typeof(int):
                case Type tuint when tuint == typeof(uint):
                case Type tlong when tlong == typeof(long):
                case Type tulong when tulong == typeof(ulong):
                case Type tfloat when tfloat == typeof(float):
                case Type tdouble when tdouble == typeof(double):
                    sbValue.Append($"{value},");
                    break;
                case Type tenum when tenum == typeof(Enum) || tenum.BaseType == typeof(Enum):
                    if (property.Exists<JsonSerializerEnumToStringAttribute>())
                    {
                        sbValue.Append($"{value},");
                        break;
                    }

                    sbValue.Append($"{(int)value},");
                    break;
                default:
                    throw new TypeAccessException($"当前泛型对象中存在暂不支持的数据类型({property.PropertyType.Name})，请联系相关人员处理。（NameString: {sbName}  |  ValueString: {sbValue}。）");
            }

            // 数据字段拼接
            if (returnNameString)
            {
                string? columnName = property.GetCustomAttributeValue<ColumnAttribute, string?>(x => x.Name);

                if (columnName is not null)
                {
                    sbName.Append($"{columnName},");
                }
            }
        }

        if (sbName.Length > 2)
        {
            sbName.Remove(sbName.Length - 1, 1);
        }

        if (sbValue.Length > 2)
        {
            sbValue.Remove(sbValue.Length - 1, 1);
        }

        return (NameString: sbName.ToString(), ValueString: sbValue.ToString());
    }

    /// <summary>
    /// 从指定数据模型中，获取其成员的值，并拼接成字符串。
    /// </summary>
    /// <remarks>被获取的字段名称，来源于其成员自定义属性(ColumnAttribute)配置值（如：[Column("station_id")]）。</remarks>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <param name="model">数据模型实例</param>
    /// <param name="returnNameString">是否返回数据字段的名称字符串(缺省为返回)</param>
    /// <returns>数据库字段值拼接字符串</returns>
    /// <exception cref="TypeAccessException">暂不支持的数据类型异常</exception>
    public static (string NameString, string ValueString) GetColumnValueString<TModel>(TModel model, bool returnNameString = true)
        where TModel : class, new()
        => GetColumnValueString<TModel, SpecialNullableTypeAttribute>(model, returnNameString);
}