//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：JsonTimestampPlusConverter.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-10-20 14:03:16
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
/// 用于JSON序列化时，处理时间戳的自定义转换器增强版。
/// </summary>
/// <remarks>
/// <para>入参时为时间戳格式，并将其转换为DateTime格式。</para>
/// <para>出参时为DateTime格式，并将其转换为 yyyy-MM-dd HH:mm:ss.ffff 字符串。</para>
/// </remarks>
public sealed class JsonTimestampPlusConverter : JsonConverter<DateTime>
{
    /// <summary>
    /// 将时间戳转换为 DateTime 类型
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="typeToConvert">The type to convert.</param>
    /// <param name="options">An object that specifies serialization options to use.</param>
    /// <returns>The converted value.</returns>
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType is not JsonTokenType.Number or JsonTokenType.String)
        {
            return DateTime.MinValue;
        }

        long value = 0;

        switch (reader.TokenType)
        {
            case JsonTokenType.Number:
                reader.TryGetInt64(out value);
                break;
            case JsonTokenType.String:
                string? valueString = reader.GetString();
                value = InternalTypeHelper.TypeToInt64(valueString, 0);
                break;
            default: break;
        }

        return DateTimeHelper.TryConvertToLocalTime(value);
    }

    /// <summary>
    /// 将 DateTime 转换为表示日期时间的字符串
    /// </summary>
    /// <param name="writer">The writer to write to.</param>
    /// <param name="value">The value to convert to JSON.</param>
    /// <param name="options">An object that specifies serialization options to use.</param>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        => writer.WriteStringValue($"{value:yyyy-MM-dd HH:mm:ss.ffff}");
}