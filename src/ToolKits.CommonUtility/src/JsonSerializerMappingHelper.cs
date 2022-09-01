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
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace GSA.ToolKits.CommonUtility;

/// <summary>
/// JSON序列化数据映射助手类
/// </summary>
public static class JsonSerializerMappingHelper
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="keyNode"></param>
    /// <param name="valuesNode"></param>
    /// <param name="keyIndex"></param>
    /// <returns></returns>
    public static async ValueTask<IEnumerable<TModel>?> DeserializeMappingAsync<TModel>(JsonNode keyNode, JsonNode valuesNode, int keyIndex = -1)
        where TModel : class, new()
    {
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

                //if (keyIndex >= 0)
                //{
                //    int count = node.AsArray().Count;

                //    if (keyIndex >= count)
                //    {
                //        continue;
                //    }

                //    keyName = node[keyIndex]?.GetValue<string>().ToUpperInvariant();
                //}
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

                PropertyInfo? property = properties.SingleOrDefault(p => p.Name.ToUpperInvariant() == keyName);

                if (property is null)
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
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="keyElement"></param>
    /// <param name="valuesElement"></param>
    /// <param name="keyIndex"></param>
    /// <returns></returns>
    public static async ValueTask<IEnumerable<TModel>?> DeserializeMappingAsync<TModel>(JsonElement keyElement, JsonElement valuesElement, int keyIndex = -1)
        where TModel : class, new()
    {
        return await Task.Run(() =>
        {
            IList<JsonSerializerFieldMapping> mappings = new List<JsonSerializerFieldMapping>();

            Type type = typeof(TModel);
            PropertyInfo[] properties = type.GetProperties();

            int keyLength = keyElement.GetArrayLength();
            for (int index = 0; index < keyLength; index++)
            {
                JsonElement element = keyElement[index];
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

                PropertyInfo? property = properties.SingleOrDefault(p => p.Name.ToUpperInvariant() == keyName);

                if (property is null)
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
            int valLength = keyElement.GetArrayLength();

            for (int index = 0; index < valLength; index++)
            {
                TModel info = new();

                foreach (JsonSerializerFieldMapping field in mappings)
                {
                    JsonElement value = valuesElement[index][field.DataIndex];
                    field.MappingValue(info, value);
                }

                result.Add(info);
            }

            return result;
        }).ConfigureAwait(false);
    }

    //public static Task SerializeMappingAsync<TValue>(TValue value)
    //{
    //    return Task.CompletedTask;
    //}
}