//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineFieldDescConverter.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-06-22 22:14:36
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Text.Json;
using System.Text.Json.Serialization;
using ToolKits.DBUtility.TDengine.Entity;

namespace ToolKits.DBUtility.TDengine.Converters;

/// <summary>
/// Converts an object or value to or from JSON.
/// </summary>
/// <remarks>The type of object or value handled by the converter.</remarks>
internal sealed class TDengineFieldDescConverter : JsonConverter<IEnumerable<TDengineFieldDesc>>
{
    /// <summary>
    /// Reads and converts the JSON to type T.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="typeToConvert">The type to convert.</param>
    /// <param name="options">An object that specifies serialization options to use.</param>
    /// <returns>The converted value.</returns>
    public override IEnumerable<TDengineFieldDesc> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            return Enumerable.Empty<TDengineFieldDesc>();
        }

        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        JsonElement.ArrayEnumerator source = doc.RootElement.EnumerateArray();

        IList<TDengineFieldDesc> result = new List<TDengineFieldDesc>();

        foreach (JsonElement item in source)
        {
            JsonElement.ArrayEnumerator line = item.EnumerateArray();

            if (line.Count() < 3)
            {
                continue;
            }

            TDengineFieldDesc info = new();

            line.MoveNext();
            info.FieldName = line.Current.GetString();

            line.MoveNext();
            info.FieldType = Enum.Parse<TDengineDataType>($"{line.Current.GetInt16()}");

            line.MoveNext();
            info.FiledSize = line.Current.GetInt16();

            result.Add(info);
        }

        return result;
    }

    /// <summary>
    /// Writes a specified value as JSON.
    /// </summary>
    /// <param name="writer">The writer to write to.</param>
    /// <param name="value">The value to convert to JSON.</param>
    /// <param name="options">An object that specifies serialization options to use.</param>
    public override void Write(Utf8JsonWriter writer, IEnumerable<TDengineFieldDesc> value, JsonSerializerOptions options)
    {
        //writer.WriteStringValue($"[]");

        JsonSerializer.Serialize(writer, value, options);
    }
}