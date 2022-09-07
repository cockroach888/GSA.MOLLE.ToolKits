//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：JsonSerializerFieldMapping.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-08-30 22:26:44
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
using System.Text.Json;
using System.Text.Json.Nodes;

namespace GSA.ToolKits.CommonUtility.Entity;

/// <summary>
/// JSON序列化字段与数据映射实体类
/// </summary>
[Serializable]
public sealed class JsonSerializerFieldMapping
{
    /// <summary>
    /// JSON序列化字段与数据映射实体
    /// </summary>
    /// <param name="property">属性字段</param>
    /// <param name="dataIndex">数据索引</param>
    public JsonSerializerFieldMapping(PropertyInfo property, int dataIndex)
    {
        Property = property;
        DataIndex = dataIndex;
    }


    /// <summary>
    /// 属性字段
    /// </summary>
    /// <remarks>表示泛型对象中对应的属性字段</remarks>
    public PropertyInfo Property { get; set; }

    /// <summary>
    /// 数据索引
    /// </summary>
    /// <remarks>表示用于数据映射的数组的下标索引</remarks>
    public int DataIndex { get; set; }


    /// <summary>
    /// 将数值映射到泛型对象对应的属性
    /// </summary>
    /// <typeparam name="T">泛型对象</typeparam>
    /// <param name="info">数据实体对象</param>
    /// <param name="node">存储数值的JSON节点</param>
    /// <exception cref="TypeAccessException">当数据类型不支持时发生的异常</exception>
    public void MappingValue<T>(T info, JsonNode node)
        where T : class
    {
        switch (Property.PropertyType)
        {
            case Type t when t == typeof(bool):
                Property.SetValue(info, node.GetValue<bool>()); // bool
                break;
            case Type t when t == typeof(sbyte):
                Property.SetValue(info, node.GetValue<sbyte>()); // tinyint
                break;
            case Type t when t == typeof(byte):
                Property.SetValue(info, node.GetValue<byte>()); // tinyint unsigned
                break;
            case Type t when t == typeof(short):
                Property.SetValue(info, node.GetValue<short>()); // smallint
                break;
            case Type t when t == typeof(ushort):
                Property.SetValue(info, node.GetValue<ushort>()); // smallint unsigned
                break;
            case Type t when t == typeof(int):
                Property.SetValue(info, node.GetValue<int>()); // int
                break;
            case Type t when t == typeof(uint):
                Property.SetValue(info, node.GetValue<uint>()); // int unsigned
                break;
            case Type t when t == typeof(long):
                Property.SetValue(info, node.GetValue<long>()); // bigint
                break;
            case Type t when t == typeof(ulong):
                Property.SetValue(info, node.GetValue<ulong>()); // bigint unsigned
                break;
            case Type t when t == typeof(float):
                Property.SetValue(info, node.GetValue<float>()); // float
                break;
            case Type t when t == typeof(double):
                Property.SetValue(info, node.GetValue<double>()); // double
                break;
            case Type t when t == typeof(string):
                Property.SetValue(info, node.GetValue<string>()); // binary, varchar, nchar
                break;
            case Type t when t == typeof(DateTime):
                if (DateTime.TryParse($"{node}", out DateTime timeValue))
                {
                    Property.SetValue(info, timeValue); // timestamp
                }
                break;
            case Type t when t == typeof(Enum) || t.BaseType == typeof(Enum):
#if NET6_0_OR_GREATER
                if (Enum.TryParse(t, $"{node}", out object? result))
                {
                    Property.SetValue(info, result);
                }
#else
                //object result = Enum.Parse(t, $"{node}");
                object result = Convert.ChangeType($"{node}", t);
                Property.SetValue(info, result);
#endif
                break;
            default:
                throw new TypeAccessException($"当前泛型对象中存在暂不支持的数据类型({Property.Name}，{Property.PropertyType})，请联系相关人员处理。");
        }
    }

    /// <summary>
    /// 将数值映射到泛型对象对应的属性
    /// </summary>
    /// <typeparam name="T">泛型对象</typeparam>
    /// <param name="info">数据实体对象</param>
    /// <param name="element">存储数值的JSON元素</param>
    /// <exception cref="TypeAccessException">当数据类型不支持时发生的异常</exception>
    public void MappingValue<T>(T info, JsonElement element)
        where T : class
    {
        switch (Property.PropertyType)
        {
            case Type t when t == typeof(bool):
                Property.SetValue(info, element.GetBoolean()); // bool
                break;
            case Type t when t == typeof(sbyte):
                Property.SetValue(info, element.GetSByte()); // tinyint
                break;
            case Type t when t == typeof(byte):
                Property.SetValue(info, element.GetByte()); // tinyint unsigned
                break;
            case Type t when t == typeof(short):
                Property.SetValue(info, element.GetInt16()); // smallint
                break;
            case Type t when t == typeof(ushort):
                Property.SetValue(info, element.GetUInt16()); // smallint unsigned
                break;
            case Type t when t == typeof(int):
                Property.SetValue(info, element.GetInt32()); // int
                break;
            case Type t when t == typeof(uint):
                Property.SetValue(info, element.GetUInt32()); // int unsigned
                break;
            case Type t when t == typeof(long):
                Property.SetValue(info, element.GetInt64()); // bigint
                break;
            case Type t when t == typeof(ulong):
                Property.SetValue(info, element.GetUInt64()); // bigint unsigned
                break;
            case Type t when t == typeof(float):
                Property.SetValue(info, element.GetSingle()); // float
                break;
            case Type t when t == typeof(double):
                Property.SetValue(info, element.GetDouble()); // double
                break;
            case Type t when t == typeof(string):
                Property.SetValue(info, element.GetString()); // binary, varchar, nchar
                break;
            case Type t when t == typeof(DateTime):
                if (DateTime.TryParse($"{element}", out DateTime timeValue))
                {
                    Property.SetValue(info, timeValue); // timestamp
                }
                break;
            case Type t when t == typeof(Enum) || t.BaseType == typeof(Enum):
#if NET6_0_OR_GREATER
                if (Enum.TryParse(t, $"{element}", out object? result))
                {
                    Property.SetValue(info, result);
                }
#else
                //object result = Enum.Parse(t, $"{element}");
                object result = Convert.ChangeType($"{element}", t);
                Property.SetValue(info, result);
#endif
                break;
            default:
                throw new TypeAccessException($"当前泛型对象中存在暂不支持的数据类型({Property.Name}，{Property.PropertyType})，请联系相关人员处理。");
        }
    }
}