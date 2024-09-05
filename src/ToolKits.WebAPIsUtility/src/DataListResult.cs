//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：DataListResult.cs
// 项目名称：WebAPI接口辅助与应用工具集
// 创建时间：2024-09-05 10:04:53
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.WebAPIsUtility;

/// <summary>
/// 数据列表请求结果实体类
/// </summary>
/// <typeparam name="TDataModel">数据模型泛型</typeparam>
[Serializable]
public sealed class DataListResult<TDataModel> where TDataModel : class
{
    /// <summary>
    /// 响应状态码
    /// </summary>
    [JsonPropertyName("Code")]
    public int Code { get; set; }

    /// <summary>
    /// 响应数据
    /// </summary>
    [JsonPropertyName("Data")]
    public IEnumerable<TDataModel>? Data { get; set; }

    /// <summary>
    /// 描述信息
    /// </summary>
    [JsonPropertyName("Desc")]
    public string? Desc { get; set; }

    /// <summary>
    /// 数据分页信息
    /// </summary>
    [JsonPropertyName("MetaData")]
    public PaginationModel? MetaData { get; set; }
}