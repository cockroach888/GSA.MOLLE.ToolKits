//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：JsonValueTupleConverterFactory.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-09-18 13:07:37
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
public sealed class JsonValueTupleConverterFactory : JsonConverterFactory
{
    /// <summary>
    /// Determines whether the type can be converted.
    /// </summary>
    /// <param name="typeToConvert">The type is checked as to whether it can be converted.</param>
    /// <returns>True if the type can be converted, false otherwise.</returns>
    public override bool CanConvert(Type typeToConvert)
    {
        Type iTuple = typeToConvert.GetInterface("System.Runtime.CompilerServices.ITuple");
        return iTuple is not null;
    }

    /// <summary>
    /// Create a converter for the provided <see cref="Type"/>.
    /// </summary>
    /// <param name="typeToConvert">The <see cref="Type"/> being converted.</param>
    /// <param name="options">The <see cref="JsonSerializerOptions"/> being used.</param>
    /// <returns>
    /// An instance of a <see cref="JsonConverter{T}"/> where T is compatible with <paramref name="typeToConvert"/>.
    /// If <see langword="null"/> is returned, a <see cref="NotSupportedException"/> will be thrown.
    /// </returns>
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        Type[] genericArguments = typeToConvert.GetGenericArguments();

        Type converterType = genericArguments.Length switch
        {
            1 => typeof(JsonValueTupleConverter<>).MakeGenericType(genericArguments),
            2 => typeof(JsonValueTupleConverter<,>).MakeGenericType(genericArguments),
            3 => typeof(JsonValueTupleConverter<,,>).MakeGenericType(genericArguments),
            4 => typeof(JsonValueTupleConverter<,,,>).MakeGenericType(genericArguments),
            5 => typeof(JsonValueTupleConverter<,,,,>).MakeGenericType(genericArguments),
            6 => typeof(JsonValueTupleConverter<,,,,,>).MakeGenericType(genericArguments),
            // And add other cases as needed
            _ => throw new NotSupportedException(),
        };

        return (JsonConverter)Activator.CreateInstance(converterType);
    }
}