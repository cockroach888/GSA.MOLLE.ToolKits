//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineOptions.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-06-22 22:24:33
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Text.Json.Serialization;

namespace GSA.ToolKits.DBUtility.TDengine;

/// <summary>
/// TDengine选项参数类
/// </summary>
[Serializable]
public sealed class TDengineOptions
{
    /// <summary>
    /// 主机名或IP地址
    /// </summary>
    public string? Host { get; set; }

    /// <summary>
    /// 端口号（缺省 6041）
    /// </summary>
    public uint Port { get; set; } = 6041;

    /// <summary>
    /// 用户名（缺省 root）
    /// </summary>
    public string UserName { get; set; } = "root";

    /// <summary>
    /// 密码（缺省 taosdata）
    /// </summary>
    public string Password { get; set; } = "taosdata";

    /// <summary>
    /// 时区（缺省 Asia/Shanghai）
    /// </summary>
    /// <remarks>
    /// 注意：
    /// <para>1.时区参数只在 TDEngine 3.x 版本才支持；</para>
    /// <para>2.时区参数只有带数据库名称时方可有效。</para>
    /// </remarks>
    public string TimeZone { get; set; } = "Asia/Shanghai";

    /// <summary>
    /// 版本选择器
    /// </summary>
    /// <remarks>缺省为 TDengine2.x 版本</remarks>
    public TDengineVersion VersionSelector { get; set; } = TDengineVersion.V2;

    /// <summary>
    /// 数据库连接URI标识符
    /// </summary>
    [JsonIgnore]
    internal Uri BaseUri => new UriBuilder($"http://{Host}:{Port}/rest/sql").Uri;
}