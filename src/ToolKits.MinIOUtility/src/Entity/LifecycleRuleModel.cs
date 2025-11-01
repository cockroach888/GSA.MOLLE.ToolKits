//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2025 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：LifecycleRuleModel.cs
// 项目名称：MinIO对象存储辅助工具集
// 创建时间：2025-11-01 11:44:12
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.MinIOUtility.Entity;

/// <summary>
/// 生命周期规则定义实体类
/// </summary>
/// <param name="ruleId">生命周期规则唯一编号，默认UUID值。</param>
/// <param name="expirationDay">过期时间（天），默认30天。</param>
/// <param name="isEnabled">是否启用规则，默认启用。</param>
/// <param name="filterString">存储桶与对象路径的前缀过滤定义字符串，为空表示不过滤。</param>
[Serializable]
public sealed class LifecycleRuleModel(
    string ruleId,
    int expirationDay,
    bool isEnabled = true,
    string? filterString = null)
{
    /// <summary>
    /// 生命周期规则唯一编号，默认UUID值。
    /// </summary>
    public string RuleId { get; set; } = ruleId;

    /// <summary>
    /// 过期时间（天），默认30天。
    /// </summary>
    public int ExpirationDay { get; set; } = expirationDay;

    /// <summary>
    /// 是否启用规则，默认启用。
    /// </summary>
    public bool IsEnabled { get; set; } = isEnabled;

    /// <summary>
    /// 存储桶与对象路径的前缀过滤定义字符串，为空表示不过滤。
    /// </summary>
    /// <remarks>例如：“filtername/”等。</remarks>
    public string? FilterString { get; set; } = filterString;
}