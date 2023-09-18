//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：EMQStatusModel.cs
// 项目名称：EMQX消息服务工具集
// 创建时间：2023-09-17 21:18:35
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.EMQXUtility.Entity;

/// <summary>
/// EMQX状态实体类
/// </summary>
[Serializable]
public sealed class EMQStatusModel
{
    /// <summary>
    /// 发行版本
    /// </summary>
    [JsonPropertyName("rel_vsn")]
    public string? ReleaseVersion { get; set; }

    /// <summary>
    /// 节点名称
    /// </summary>
    [JsonPropertyName("node_name")]
    public string? NodeName { get; set; }

    /// <summary>
    /// 服务状态
    /// </summary>
    [JsonPropertyName("broker_status")]
    public string? BrokerStatus { get; set; }

    /// <summary>
    /// 应用状态
    /// </summary>
    [JsonPropertyName("app_status")]
    public string? AppStatus { get; set; }
}