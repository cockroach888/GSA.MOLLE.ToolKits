//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：JsonSerializerMappingHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-08-30 21:59:57
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
using GSA.ToolKits.CommonUtility.Schema;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace GSA.ToolKits.CommonUtility;

/// <summary>
/// JSON序列化数据映射助手类
/// </summary>
/// <remarks>提供处理键和值分离的JSON序列化应用。</remarks>
public static class JsonSerializerMappingHelper
{
    /// <summary>
    /// 反序列化键与值分离形态的JSON节点数据，并将其转换为相应的数据模型。
    /// </summary>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <typeparam name="TIgnoreAttribute">自定义属性泛型(忽略的)</typeparam>
    /// <param name="keyNode">存储键名称的JSON节点</param>
    /// <param name="valuesNode">存储所有数据的JSON节点</param>
    /// <param name="keyIndex">键名称为二维数组时，表示键的索引。（缺省-1，表示仅所有名称的数组。）</param>
    /// <returns>数据模型枚举列表</returns>
    public static async ValueTask<IEnumerable<TModel>?> DeserializeMappingAsync<TModel, TIgnoreAttribute>(JsonNode? keyNode, JsonNode? valuesNode, int keyIndex = -1)
        where TModel : class, new()
        where TIgnoreAttribute : Attribute
    {
        if (keyNode is null || valuesNode is null)
        {
            return default;
        }

        return await Task.Run(() =>
        {
            IList<JsonSerializerFieldMapping> mappings = new List<JsonSerializerFieldMapping>();

            Type type = typeof(TModel);
            PropertyInfo[] properties = type.GetProperties();

            int index = -1;
            JsonArray keyArray = keyNode.AsArray();
            foreach (JsonNode? node in keyArray)
            {
                index++;
                string? keyName;

                if (node is null)
                {
                    continue;
                }

                int count = node.AsArray().Count;
                if (keyIndex >= 0 && keyIndex < count)
                {
                    keyName = node[keyIndex]?.GetValue<string>().ToUpperInvariant();
                }
                else
                {
                    keyName = node.GetValue<string>().ToUpperInvariant();
                }

                if (keyName is null)
                {
                    continue;
                }

                PropertyInfo? property = properties.SingleOrDefault(p => p.Name.ToUpperInvariant() == keyName ||
                                                                    p.GetCustomAttributeValue<JsonPropertyNameAttribute, string>(x => x.Name)?.ToUpperInvariant() == keyName);

                if (property is null || property.Exists<TIgnoreAttribute>())
                {
                    continue;
                }

                mappings.Add(new JsonSerializerFieldMapping(property, index));
            }

            if (mappings.Count <= 0)
            {
                return default;
            }

            IList<TModel> result = new List<TModel>();
            JsonArray valuesArray = valuesNode.AsArray();

            foreach (JsonNode? node in valuesArray)
            {
                if (node is null)
                {
                    continue;
                }

                TModel info = new();

                foreach (JsonSerializerFieldMapping field in mappings)
                {
                    JsonNode? value = node[field.DataIndex];

                    if (value is null)
                    {
                        continue;
                    }
                    field.MappingValue(info, value);
                }

                result.Add(info);
            }

            return result;
        }).ConfigureAwait(false);
    }

    /// <summary>
    /// 反序列化键与值分离形态的JSON节点数据，并将其转换为相应的数据模型。
    /// </summary>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <param name="keyNode">存储键名称的JSON节点</param>
    /// <param name="valuesNode">存储所有数据的JSON节点</param>
    /// <param name="keyIndex">键名称为二维数组时，表示键的索引。（缺省-1，表示仅所有名称的数组。）</param>
    /// <returns>数据模型枚举列表</returns>
    public static async ValueTask<IEnumerable<TModel>?> DeserializeMappingAsync<TModel>(JsonNode? keyNode, JsonNode? valuesNode, int keyIndex = -1)
        where TModel : class, new()
        => await DeserializeMappingAsync<TModel, SpecialNullableTypeAttribute>(keyNode, valuesNode, keyIndex).ConfigureAwait(false);


    /// <summary>
    /// 反序列化键与值分离形态的JSON字符串数据，并将其转换为相应的数据模型。
    /// </summary>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <typeparam name="TIgnoreAttribute">自定义属性泛型(忽略的)</typeparam>
    /// <param name="jsonKeyString">存储键名称的JSON字符串</param>
    /// <param name="jsonValuesString">存储所有数据的JSON字符串</param>
    /// <param name="keyIndex">键名称为二维数组时，表示键的索引。（缺省-1，表示仅所有名称的数组。）</param>
    /// <returns>数据模型枚举列表</returns>
    public static async ValueTask<IEnumerable<TModel>?> DeserializeMappingAsync<TModel, TIgnoreAttribute>(string? jsonKeyString, string? jsonValuesString, int keyIndex = -1)
        where TModel : class, new()
        where TIgnoreAttribute : Attribute
    {
        if (jsonKeyString is null || jsonValuesString is null)
        {
            return default;
        }

        JsonNode? keyNode = JsonSerializer.SerializeToNode(jsonKeyString);
        JsonNode? valuesNode = JsonSerializer.SerializeToNode(jsonValuesString);

        return await DeserializeMappingAsync<TModel, TIgnoreAttribute>(keyNode, valuesNode, keyIndex).ConfigureAwait(false);
    }

    /// <summary>
    /// 反序列化键与值分离形态的JSON字符串数据，并将其转换为相应的数据模型。
    /// </summary>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <param name="jsonKeyString">存储键名称的JSON字符串</param>
    /// <param name="jsonValuesString">存储所有数据的JSON字符串</param>
    /// <param name="keyIndex">键名称为二维数组时，表示键的索引。（缺省-1，表示仅所有名称的数组。）</param>
    /// <returns>数据模型枚举列表</returns>
    public static async ValueTask<IEnumerable<TModel>?> DeserializeMappingAsync<TModel>(string? jsonKeyString, string? jsonValuesString, int keyIndex = -1)
        where TModel : class, new()
        => await DeserializeMappingAsync<TModel, SpecialNullableTypeAttribute>(jsonKeyString, jsonValuesString, keyIndex).ConfigureAwait(false);


    /// <summary>
    /// 反序列化键与值分离形态的JSON元素数据，并将其转换为相应的数据模型。
    /// </summary>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <typeparam name="TIgnoreAttribute">自定义属性泛型(忽略的)</typeparam>
    /// <param name="keyElement">存储键名称的JSON元素</param>
    /// <param name="valuesElement">存储所有数据的JSON元素</param>
    /// <param name="keyIndex">键名称为二维数组时，表示键的索引。（缺省-1，表示仅所有名称的数组。）</param>
    /// <returns>数据模型枚举列表</returns>
    public static async ValueTask<IEnumerable<TModel>?> DeserializeMappingAsync<TModel, TIgnoreAttribute>(JsonElement? keyElement, JsonElement? valuesElement, int keyIndex = -1)
        where TModel : class, new()
        where TIgnoreAttribute : Attribute
    {
        if (keyElement is null || valuesElement is null)
        {
            return default;
        }

        return await Task.Run(() =>
        {
            IList<JsonSerializerFieldMapping> mappings = new List<JsonSerializerFieldMapping>();

            Type type = typeof(TModel);
            PropertyInfo[] properties = type.GetProperties();

            int keyLength = keyElement.Value.GetArrayLength();
            for (int index = 0; index < keyLength; index++)
            {
                JsonElement element = keyElement.Value[index];
                string? keyName;

                int count = element.GetArrayLength();
                if (keyIndex >= 0 && keyIndex < count)
                {
                    keyName = element[keyIndex].GetString()?.ToUpperInvariant();
                }
                else
                {
                    keyName = element.GetString()?.ToUpperInvariant();
                }

                if (keyName is null)
                {
                    continue;
                }

                PropertyInfo? property = properties.SingleOrDefault(p => p.Name.ToUpperInvariant() == keyName ||
                                                                    p.GetCustomAttributeValue<JsonPropertyNameAttribute, string>(x => x.Name)?.ToUpperInvariant() == keyName);

                if (property is null || property.Exists<TIgnoreAttribute>())
                {
                    continue;
                }

                mappings.Add(new JsonSerializerFieldMapping(property, index));
            }

            if (mappings.Count <= 0)
            {
                return default;
            }

            IList<TModel> result = new List<TModel>();
            int valLength = valuesElement.Value.GetArrayLength();

            for (int index = 0; index < valLength; index++)
            {
                TModel info = new();

                foreach (JsonSerializerFieldMapping field in mappings)
                {
                    JsonElement value = valuesElement.Value[index][field.DataIndex];
                    field.MappingValue(info, value);
                }

                result.Add(info);
            }

            return result;
        }).ConfigureAwait(false);
    }

    /// <summary>
    /// 反序列化键与值分离形态的JSON元素数据，并将其转换为相应的数据模型。
    /// </summary>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <param name="keyElement">存储键名称的JSON元素</param>
    /// <param name="valuesElement">存储所有数据的JSON元素</param>
    /// <param name="keyIndex">键名称为二维数组时，表示键的索引。（缺省-1，表示仅所有名称的数组。）</param>
    /// <returns>数据模型枚举列表</returns>
    public static async ValueTask<IEnumerable<TModel>?> DeserializeMappingAsync<TModel>(JsonElement? keyElement, JsonElement? valuesElement, int keyIndex = -1)
        where TModel : class, new()
        => await DeserializeMappingAsync<TModel, SpecialNullableTypeAttribute>(keyElement, valuesElement, keyIndex).ConfigureAwait(false);


    //public static Task SerializeMappingAsync<TValue>(TValue value)
    //{
    //    return Task.CompletedTask;
    //}
}