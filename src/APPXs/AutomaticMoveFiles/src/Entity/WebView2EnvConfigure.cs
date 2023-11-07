//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：WebView2EnvConfigure.cs
// 项目名称：自动移动文件工具
// 创建时间：2023-11-07 16:50:43
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

namespace GSA.ToolKits.AutomaticMoveFiles.Entity;

/// <summary>
/// WebView2 环境配置
/// </summary>
[Serializable]
public sealed class WebView2EnvConfigure
{
    /// <summary>
    /// 虚拟主机域名
    /// </summary>
    /// <remarks>缺省：automaticdeletionfiles.ceriumx.vip</remarks>
    public string DomainName { get; set; } = "automaticdeletionfiles.ceriumx.vip";

    /// <summary>
    /// 虚拟主机目录
    /// </summary>
    /// <remarks>可以是相对或绝对路径（缺省为程序所在目录下的 wwwroot 目录）</remarks>
    public string VirtualHostFolder { get; set; } = "wwwroot";

    /// <summary>
    /// WebView2 运行时环境所在目录
    /// </summary>
    /// <remarks>缺省为程序所在目录下的 WebView2Fixed 目录</remarks>
    public string WebView2RuntimeFolder { get; set; } = "WebView2Runtime";

    /// <summary>
    /// WebView2 用户数据目录
    /// </summary>
    /// <remarks>如果为空则默认存储在运行时的 UserData 目录（缺省：UserCacheData）</remarks>
    public string UserDataFolder { get; set; } = "UserCacheData";


    /// <summary>
    /// 虚拟主机URL链接
    /// </summary>
    /// <remarks>NOTE：URL链接末尾不以“/”结尾，请拼接使用时自行附带。</remarks>
    [JsonIgnore]
    public string DomainURL => $"https://{DomainName}";

    /// <summary>
    /// 虚拟主机目录绝对路径
    /// </summary>
    [JsonIgnore]
    public string FullVirtualFolder => System.IO.Path.GetFullPath(VirtualHostFolder);
}