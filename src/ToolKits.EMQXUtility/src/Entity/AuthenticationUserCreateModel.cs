//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：AuthenticationUserCreateModel.cs
// 项目名称：EMQX消息服务工具集
// 创建时间：2023-02-24 14:41:02
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
/// 认证用户创建实体类
/// </summary>
[Serializable]
public sealed class AuthenticationUserCreateModel
{
    /// <summary>
    /// 认证器 ID
    /// </summary>
    [JsonIgnore]
    [JsonPropertyName("id")]
    public string AuthenticatorId { get; set; } = string.Empty;

    /// <summary>
    /// 用户名
    /// </summary>
    [JsonPropertyName("user_id")]
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// 密码
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// 是否为超级用户
    /// </summary>
    [JsonPropertyName("is_superuser")]
    public bool IsSuperuser { get; set; } = false;
}