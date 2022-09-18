//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：JsonValueTupleConverterOfT1.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-09-18 14:20:16
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

namespace GSA.ToolKits.CommonUtility.Converters;

/// <summary>
/// 用于JSON序列化时，处理元组的自定义转换器。
/// </summary>
/// <typeparam name="T1">数据泛型</typeparam>
public sealed class JsonValueTupleConverter<T1> : JsonConverter<ValueTuple<T1>>
{
    /// <summary>
    /// Read and convert the JSON to T.
    /// </summary>
    /// <remarks>
    /// A converter may throw any Exception, but should throw <cref>JsonException</cref> when the JSON is invalid.
    /// </remarks>
    /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
    /// <param name="typeToConvert">The <see cref="Type"/> being converted.</param>
    /// <param name="options">The <see cref="JsonSerializerOptions"/> being used.</param>
    /// <returns>The value that was converted.</returns>
    /// <remarks>Note that the value of "HandleNull" determines if the converter handles null JSON tokens.</remarks>
    public override ValueTuple<T1> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.Read() is false)
        {
            throw new JsonException();
        }

        ValueTuple<T1> result = default;

        while (reader.TokenType is not JsonTokenType.EndObject)
        {
            if (reader.ValueTextEquals("Item1") && reader.Read())
            {
#pragma warning disable CS8601 // 引用类型赋值可能为 null。
                result.Item1 = JsonSerializer.Deserialize<T1>(ref reader, options);
#pragma warning restore CS8601 // 引用类型赋值可能为 null。
            }
            else
            {
                throw new JsonException();
            }

            reader.Read();
        }

        return result;
    }

    /// <summary>
    /// Write the value as JSON.
    /// </summary>
    /// <remarks>
    /// A converter may throw any Exception, but should throw <cref>JsonException</cref> when the JSON
    /// cannot be created.
    /// </remarks>
    /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
    /// <param name="value">The value to convert. Note that the value of "HandleNull" determines if the converter handles <see langword="null" /> values.</param>
    /// <param name="options">The <see cref="JsonSerializerOptions"/> being used.</param>
    public override void Write(Utf8JsonWriter writer, ValueTuple<T1> value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WritePropertyName("Item1");
        JsonSerializer.Serialize(writer, value.Item1, options);

        writer.WriteEndObject();
    }
}