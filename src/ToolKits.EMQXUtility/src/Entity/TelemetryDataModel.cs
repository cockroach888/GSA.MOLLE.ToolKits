//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TelemetryDataModel.cs
// 项目名称：魂哥常用工具集
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
/// 遥测数据信息实体类
/// </summary>
[Serializable]
public sealed class TelemetryDataModel
{
    /// <summary>
    /// 获取 emqx 版本
    /// </summary>
    [JsonPropertyName("emqx_version")]
    public string? EmqxVersion { get; set; }

    /// <summary>
    /// 获取 license 信息
    /// </summary>
    [JsonPropertyName("license")]
    public object? License { get; set; }

    /// <summary>
    /// 获取操作系统名称
    /// </summary>
    [JsonPropertyName("os_name")]
    public string? OSName { get; set; }

    /// <summary>
    /// 获取操作系统版本
    /// </summary>
    [JsonPropertyName("os_version")]
    public string? OSVersion { get; set; }

    /// <summary>
    /// 获取 OTP 版本
    /// </summary>
    [JsonPropertyName("otp_version")]
    public string? OTPVersion { get; set; }

    /// <summary>
    /// 获取运行时间
    /// </summary>
    [JsonPropertyName("up_time")]
    public int UpTime { get; set; }

    /// <summary>
    /// 获取 UUID
    /// </summary>
    [JsonPropertyName("uuid")]
    public string? UUID { get; set; }

    /// <summary>
    /// 获取节点 UUID
    /// </summary>
    [JsonPropertyName("nodes_uuid")]
    public string[]? NodesUUID { get; set; }

    /// <summary>
    /// 获取活跃插件
    /// </summary>
    [JsonPropertyName("active_plugins")]
    public string[]? ActivePlugins { get; set; }

    /// <summary>
    /// 获取活跃模块
    /// </summary>
    [JsonPropertyName("active_modules")]
    public string[]? ActiveModules { get; set; }

    /// <summary>
    /// 获取客户端数量
    /// </summary>
    [JsonPropertyName("num_clients")]
    public int NumClients { get; set; }

    /// <summary>
    /// 获取接收到的消息数量
    /// </summary>
    [JsonPropertyName("messages_received")]
    public int MessagesReceived { get; set; }

    /// <summary>
    /// 获取发送的消息数量
    /// </summary>
    [JsonPropertyName("messages_sent")]
    public int MessagesSent { get; set; }
}