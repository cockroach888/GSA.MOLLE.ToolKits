//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：EMQTelemetryDataModel.cs
// 项目名称：EMQX消息服务工具集
// 创建时间：2023-02-23 16:53:16
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
/// EMQX遥测数据实体类
/// </summary>
[Serializable]
public sealed class EMQTelemetryDataModel : ResponseResultAbstract
{
    /// <summary>
    /// EMQX 版本
    /// </summary>
    [JsonPropertyName("emqx_version")]
    public string? EMQXVersion { get; set; }

    /// <summary>
    /// 许可证
    /// </summary>
    [JsonPropertyName("license")]
    public EMQLicenseModel? License { get; set; }

    /// <summary>
    /// 操作系统名称
    /// </summary>
    [JsonPropertyName("os_name")]
    public string? OSName { get; set; }

    /// <summary>
    /// 操作系统版本
    /// </summary>
    [JsonPropertyName("os_version")]
    public string? OSVersion { get; set; }

    /// <summary>
    /// OTP 版本
    /// </summary>
    [JsonPropertyName("otp_version")]
    public string? OTPVersion { get; set; }

    /// <summary>
    /// 运行时间
    /// </summary>
    [JsonPropertyName("up_time")]
    public int UpTime { get; set; }

    /// <summary>
    /// 当前节点 UUID
    /// </summary>
    [JsonPropertyName("uuid")]
    public string? UUID { get; set; }

    /// <summary>
    /// 所有节点 UUID
    /// </summary>
    [JsonPropertyName("nodes_uuid")]
    public string[]? NodesUUID { get; set; }

    /// <summary>
    /// 激活的插件列表
    /// </summary>
    [JsonPropertyName("active_plugins")]
    public string[]? ActivePlugins { get; set; }

    /// <summary>
    /// 激活的模块列表
    /// </summary>
    [JsonPropertyName("active_modules")]
    public string[]? ActiveModules { get; set; }

    /// <summary>
    /// 客户端数量
    /// </summary>
    [JsonPropertyName("num_clients")]
    public int NumClients { get; set; }

    /// <summary>
    /// 接收到的消息数量
    /// </summary>
    [JsonPropertyName("messages_received")]
    public int MessagesReceived { get; set; }

    /// <summary>
    /// 发送的消息数量
    /// </summary>
    [JsonPropertyName("messages_sent")]
    public int MessagesSent { get; set; }
}