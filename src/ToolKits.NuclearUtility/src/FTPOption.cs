//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2026 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：FTPOption.cs
// 项目名称：原子能式的高深学问方法实用工具集
// 创建时间：2026-03-18 16:10:31
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.NuclearUtility;

/// <summary>
/// FTP选项参数类
/// </summary>
[Serializable]
public sealed class FTPOption
{
    /// <summary>
    /// 主机地址
    /// </summary>
    public string Host { get; set; } = string.Empty;

    /// <summary>
    /// 端口号（默认21）
    /// </summary>
    public int Port { get; set; } = 21;

    /// <summary>
    /// 用户名（默认匿名[anonymous]）
    /// </summary>
    public string UserName { get; set; } = "anonymous";

    /// <summary>
    /// 密码（默认无）
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// CancellationToken (default is default)
    /// </summary>
    public CancellationToken CancelToken { get; set; } = default;
}