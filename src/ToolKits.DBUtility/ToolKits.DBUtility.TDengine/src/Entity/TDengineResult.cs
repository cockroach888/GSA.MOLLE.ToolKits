//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineResult.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-06-22 22:16:34
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
using System.Text.RegularExpressions;
using GSA.ToolKits.CommonUtility;
using GSA.ToolKits.CommonUtility.Schema;
using GSA.ToolKits.DBUtility.TDengine.Converters;

namespace GSA.ToolKits.DBUtility.TDengine.Entity;

/// <summary>
/// 请求结果实体类
/// </summary>
[Serializable]
public sealed class TDengineResult
{
    /// <summary>
    /// 请求状态
    /// </summary>    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TDengineStatus Status { get; set; }

    /// <summary>
    /// 错误编码
    /// </summary>
    /// <remarks>仅请求失败时有效</remarks>
    public int Code { get; set; }

    /// <summary>
    /// 错误描述
    /// </summary>
    /// <remarks>仅请求失败时有效</remarks>
    public string? Desc { get; set; }

    /// <summary>
    /// 字段名称数组
    /// </summary>
    public string[]? Head { get; set; }

    /// <summary>
    /// 列名称及元信息枚举列表
    /// </summary>
    [JsonPropertyName("column_meta")]
    [JsonConverter(typeof(TDengineFieldDescConverter))]
    public IEnumerable<TDengineFieldDesc> ColumnMeta { get; set; } = Enumerable.Empty<TDengineFieldDesc>();

    /// <summary>
    /// 请求数据结果的 JsonElement 内容
    /// </summary>    
    public JsonElement Data { get; set; }

    /// <summary>
    /// 返回行数
    /// </summary>
    public long Rows { get; set; }


    /// <summary>
    /// 解析请求数据结果为泛型对象
    /// </summary>
    /// <remarks>注意：查询SQL语句须包含字段，并与泛型属性的顺序和数量保持一致。</remarks>
    /// <returns>解析后的泛型数据请求结果枚举列表</returns>
    public async Task<IEnumerable<TModel>> ParseDataToTModelAsync<TModel>()
        where TModel : class, new()
        => await TDataModelHelper.ConverterAsync<TModel>(Data, typeof(TaosSelectIgnoreAttribute)).ConfigureAwait(false);

    /// <summary>
    /// 解析请求数据结果为数据记录统计
    /// </summary>
    /// <returns>数据记录数</returns>
    public long ParseDataToCountAsync()
    {
        string strValue = Regex.Replace(Data.ToString(), @"[^\d]*", "");
        _ = long.TryParse(strValue, out long value);
        return value;
    }
}