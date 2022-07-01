//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：JsonTimestampConverter.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-06-22 17:38:06
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
/// Converts an object or value to or from JSON.
/// </summary>
/// <remarks>The type of object or value handled by the converter.</remarks>
public sealed class JsonTimestampConverter : JsonConverter<DateTime>
{
    /// <summary>
    /// Reads and converts the JSON to type T.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="typeToConvert">The type to convert.</param>
    /// <param name="options">An object that specifies serialization options to use.</param>
    /// <returns>The converted value.</returns>
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number)
        {
            return default;
        }

        DateTime result = DateTime.MinValue;

        if (reader.TryGetInt64(out long value))
        {
            result = DateTimeHelper.GetDateTimeAsync(value).GetAwaiter().GetResult();
        }

        return result;
    }

    /// <summary>
    /// Writes a specified value as JSON.
    /// </summary>
    /// <param name="writer">The writer to write to.</param>
    /// <param name="value">The value to convert to JSON.</param>
    /// <param name="options">An object that specifies serialization options to use.</param>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"{DateTimeHelper.GetTimestampAsync(value).GetAwaiter().GetResult()}");
    }
}