//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TelemetryHelperProvider.cs
// 项目名称：EMQX消息服务工具集
// 创建时间：2023-03-16 23:11:39
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
/// 遥测管理助手提供者
/// </summary>
public sealed class TelemetryHelperProvider
{

    #region 单例模式

    private static readonly Lazy<TelemetryHelperProvider> _lazyInstance = new(() => new TelemetryHelperProvider());

    /// <summary>
    /// 遥测管理助手提供者
    /// </summary>
    public static TelemetryHelperProvider Default => _lazyInstance.Value;

    #endregion


    /// <summary>
    /// 创建遥测管理助手提供者
    /// </summary>
    /// <param name="options">选项参数</param>
    /// <returns>遥测管理助手提供者</returns>
    public ITelemetryHelper Create(EMQXManagementOptions options) => new TelemetryHelper(options);
}