//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：EMQXManagementOptions.cs
// 项目名称：魂哥常用工具集
// 创建时间：2023-02-23 14:53:13
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.EMQXUtility;

/// <summary>
/// EMQX 管理选项参数类
/// </summary>
[Serializable]
public sealed class EMQXManagementOptions
{
    /// <summary>
    /// EMQX 服务主机地址
    /// </summary>
    public string BasedHost { get; set; } = string.Empty;

    /// <summary>
    /// EMQX API Key
    /// </summary>
    public string APIKey { get; set; } = string.Empty;

    /// <summary>
    /// EMQX Secret Key
    /// </summary>
    public string SecretKey { get; set; } = string.Empty;
}