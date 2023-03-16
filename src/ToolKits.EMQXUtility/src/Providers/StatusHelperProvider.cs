//=========================================================================
//**   请更改为当前模块名称或相关功能名称（CRS.ProjectName）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：StatusHelperProvider.cs
// 项目名称：请更改为当前模块名称或相关功能名称
// 创建时间：2023-03-16 23:19:16
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
/// 类功能说明
/// </summary>
public sealed class StatusHelperProvider
{

    #region 单例模式

    private static readonly Lazy<StatusHelperProvider> _lazyInstance = new(() => new StatusHelperProvider());

    /// <summary>
    /// 类功能说明
    /// </summary>
    internal static StatusHelperProvider Default => _lazyInstance.Value;

    #endregion



}