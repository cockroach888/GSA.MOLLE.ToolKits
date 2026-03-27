//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2026 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：UnixTimestampDateTimeOffset2LocalTimeConverter.cs
// 项目名称：魂哥常用工具集
// 创建时间：2026-03-27 11:06:15
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
/// 用于JSON序列化时，处理时间戳与DateTimeOffset转换的自定义转换器。
/// </summary>
/// <remarks>
/// <para>入参时为时间戳格式，并将其转换为DateTimeOffset的本地时间格式。</para>
/// <para>出参时为DateTimeOffset格式。</para>
/// </remarks>
public class UnixTimestampDateTimeOffset2LocalTimeConverter : JsonConverter<DateTimeOffset>
{
    /// <summary>
    /// 将时间戳转换为 DateTimeOffset 类型的本地时
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="typeToConvert">The type to convert.</param>
    /// <param name="options">An object that specifies serialization options to use.</param>
    /// <returns>The converted value.</returns>
    /// <exception cref="JsonException">Defines a custom exception object that is thrown when invalid JSON text is encountered, when the defined maximum depth is passed, or the JSON text is not compatible with the type of a property on an object.</exception>
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out long timestamp))
        {
            if (timestamp > 1000000000000)
                return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).ToLocalTime();
            else
                return DateTimeOffset.FromUnixTimeSeconds(timestamp).ToLocalTime();
        }
        throw new JsonException("Invalid timestamp format");
    }

    /// <summary>
    /// 将 DateTimeOffset 的本地时转换为时间戳格式
    /// </summary>
    /// <param name="writer">The writer to write to.</param>
    /// <param name="value">The value to convert to JSON.</param>
    /// <param name="options">An object that specifies serialization options to use.</param>
    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.ToUnixTimeSeconds());
    }
}