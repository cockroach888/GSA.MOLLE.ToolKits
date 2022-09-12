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
using GSA.ToolKits.CommonUtility;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace GSA.ToolKits.DBUtility.TDengine;

/// <summary>
/// 请求结果实体类
/// </summary>
[Serializable]
public sealed class TDengineResult
{
    /// <summary>
    /// 请求状态
    /// </summary>
    /// <remarks>succ 表示请求成功</remarks>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TDengineStatus Status { get; set; }

    /// <summary>
    /// 请求结果编码
    /// </summary>
    /// <remarks>仅请求失败时有效，0 代表成功。</remarks>
    public int Code { get; set; }

    /// <summary>
    /// 包含列名称及元信息的JSON节点
    /// </summary>
    [JsonPropertyName("column_meta")]
    public JsonNode? ColumnMeta { get; set; }

    /// <summary>
    /// 包含请求数据结果的JSON节点
    /// </summary>    
    public JsonNode? Data { get; set; }

    /// <summary>
    /// 请求结果行数
    /// </summary>
    public long Rows { get; set; }

    /// <summary>
    /// 错误描述
    /// </summary>
    /// <remarks>
    /// 仅请求失败时有效
    /// <para>TDengine2.x - Status不等于succ</para>
    /// <para>TDengine3.x - Code不等于0</para>
    /// </remarks>
    public string? Desc { get; set; }


    /// <summary>
    /// 解析包含请求数据结果的JSON节点为相应的数据模型
    /// </summary>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <typeparam name="TIgnoreAttribute">自定义属性泛型(忽略的)</typeparam>
    /// <returns>数据模型枚举列表</returns>
    public async ValueTask<IEnumerable<TModel>?> ParseToTModelAsync<TModel, TIgnoreAttribute>()
        where TModel : class, new()
        where TIgnoreAttribute : Attribute
        => await JsonSerializerMappingHelper.DeserializeMappingAsync<TModel, TIgnoreAttribute>(ColumnMeta, Data, 0).ConfigureAwait(false);

    /// <summary>
    /// 解析包含请求数据结果的JSON节点为相应的数据模型
    /// </summary>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <returns>数据模型枚举列表</returns>
    public async ValueTask<IEnumerable<TModel>?> ParseToTModelAsync<TModel>()
        where TModel : class, new()
        => await JsonSerializerMappingHelper.DeserializeMappingAsync<TModel>(ColumnMeta, Data, 0).ConfigureAwait(false);

    /// <summary>
    /// 解析请求数据结果为数据记录统计
    /// </summary>
    /// <returns>数据记录数</returns>
    public long ParseToCount()
    {
        if (Data is null)
        {
            return 0;
        }

        string strValue = Regex.Replace(Data.ToString(), @"[^\d]*", "");
        _ = long.TryParse(strValue, out long value);
        return value;
    }
}