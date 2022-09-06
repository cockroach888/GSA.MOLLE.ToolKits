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
using System.Text.Json;

namespace GSA.ToolKits.CommonUtility;

/// <summary>
/// 提供数据模型的字段名称与值的字符串拼接助手类
/// </summary>
public static class TDataModelHelper
{
    /// <summary>
    /// 从指定数据模型中，获取其成员表示数据字段的名称，并拼接成字符串。
    /// </summary>
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
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <returns>数据字段名称拼接字符串</returns>
    public static string GetColumnNameString<TModel>()
        where TModel : class, new()
        => GetColumnNameString<TModel, SpecialNullableTypeAttribute>();

    /// <summary>
    /// 从指定数据模型中，获取其成员的值，并拼接成字符串。
    /// </summary>
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
                    sbValue.Append($"'{value:yyyy-MM-dd HH:mm:ss.ffff}',");
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
                    sbValue.Append($"{(int)value},");
                    //sbValue.Append($"{nameof(value)},");
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
    /// 将JsonElement元素转换为指定数据模型泛型的枚举列表对象
    /// </summary>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <param name="jsonElement">sonElement元素</param>
    /// <param name="typeIgnoreAttr">忽略属性类型</param>
    /// <returns>数据模型枚举列表</returns>
    public static Task<IEnumerable<TModel>> ConverterAsync<TModel>(JsonElement jsonElement, Type? typeIgnoreAttr = null)
        where TModel : class, new()
    {
        return Task.Run(() =>
        {
            JsonElement.ArrayEnumerator source = jsonElement.EnumerateArray();

            if (!source.Any())
            {
                return Enumerable.Empty<TModel>();
            }

            Type type = typeof(TModel);
            IEnumerable<PropertyInfo> properties = type.GetProperties().Where(p => !p.CustomAttributes.Any(p => p.AttributeType == typeIgnoreAttr));

            IList<TModel> result = new List<TModel>();

            foreach (JsonElement item in source)
            {
                JsonElement.ArrayEnumerator line = item.EnumerateArray();

                if (line.Count() < properties.Count())
                {
                    continue;
                }

                TModel info = new();

                foreach (PropertyInfo property in properties)
                {
                    line.MoveNext();

                    switch (property.PropertyType)
                    {
                        case Type t when t == typeof(bool):
                            //if (bool.TryParse(line.Current.GetString(), out bool boolValue))
                            //{
                            //    property.SetValue(info, boolValue);
                            //}
                            property.SetValue(info, line.Current.GetBoolean());
                            break;
                        case Type t when t == typeof(byte):
                            property.SetValue(info, line.Current.GetByte());
                            break;
                        case Type t when t == typeof(short):
                            property.SetValue(info, line.Current.GetInt16());
                            break;
                        case Type t when t == typeof(int):
                            property.SetValue(info, line.Current.GetInt32());
                            break;
                        case Type t when t == typeof(long):
                            property.SetValue(info, line.Current.GetInt64());
                            break;
                        case Type t when t == typeof(float):
                            property.SetValue(info, line.Current.GetSingle());
                            break;
                        case Type t when t == typeof(double):
                            property.SetValue(info, line.Current.GetDouble());
                            break;
                        case Type t when t == typeof(string):
                            property.SetValue(info, line.Current.GetString());
                            break;
                        case Type t when t == typeof(DateTime):
                            if (DateTime.TryParse(line.Current.GetString(), out DateTime timeValue))
                            {
                                property.SetValue(info, timeValue);
                            }
                            break;
                        case Type t when t == typeof(Enum) || t.BaseType == typeof(Enum):
                            string strEnumValue = $"{line.Current.GetInt32()}";
                            if (Enum.TryParse(t, strEnumValue, out object? tmpEnumResult))
                            {
                                property.SetValue(info, tmpEnumResult);
                            }
                            break;
                        case Type t when t == typeof(int[]):
                            string[]? value = line.Current.GetString()?.Split(',', StringSplitOptions.RemoveEmptyEntries);
                            if (value != null)
                            {
                                int[] values = Array.ConvertAll(value, int.Parse);
                                property.SetValue(info, values);
                            }
                            break;
                        default:
                            throw new TypeAccessException($"当前泛型对象中存在暂不支持的数据类型({property.PropertyType.Name})，请联系相关人员处理。");
                    }
                }

                result.Add(info);
            }

            return result.AsEnumerable();
        });
    }

    /// <summary>
    /// 将Json字符串转换为指定数据模型泛型的枚举列表对象
    /// </summary>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <param name="jsonString">Json字符串</param>
    /// <param name="typeIgnoreAttr">忽略属性类型</param>
    /// <returns>数据模型枚举列表</returns>
    public static async Task<IEnumerable<TModel>> ConverterAsync<TModel>(string? jsonString, Type? typeIgnoreAttr = null)
        where TModel : class, new()
    {
        if (string.IsNullOrWhiteSpace(jsonString))
        {
            return Enumerable.Empty<TModel>();
        }

        JsonElement source = JsonSerializer.SerializeToElement(jsonString);
        return await ConverterAsync<TModel>(source, typeIgnoreAttr).ConfigureAwait(false);
    }
}