//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：JWTOptions.cs
// 项目名称：WebAPI接口辅助与应用工具集
// 创建时间：2024-09-05 23:26:02
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
/// JWT认证选项参数类
/// </summary>
[Serializable]
public class JWTOptions
{
    /// <summary>
    /// 发行者
    /// </summary>
    public string Issuer { get; set; } = "Cockroach Soulful";

    /// <summary>
    /// 受众者
    /// </summary>
    public string Audience { get; set; } = "Well Known";

    /// <summary>
    /// 安全密钥
    /// </summary>
    /// <remarks>缺省为新的UUID</remarks>
    public string SecurityKey { get; set; } = Guid.NewGuid().ToString("N");

    /// <summary>
    /// 过期时间
    /// </summary>
    /// <remarks>缺省为5分钟</remarks>
    public TimeSpan ExpiresIn { get; set; } = TimeSpan.FromMinutes(5);
}