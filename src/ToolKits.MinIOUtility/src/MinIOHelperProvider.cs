//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MinIOHelperProvider.cs
// 项目名称：MinIO对象存储辅助工具集
// 创建时间：2024-12-11 10:32:18
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.MinIOUtility.Internal;

namespace GSA.ToolKits.MinIOUtility;

/// <summary>
/// MinIO 对象存储访问助手提供者
/// </summary>
public sealed class MinIOHelperProvider
{

    #region 单例模式

    private static readonly Lazy<MinIOHelperProvider> _lazyInstance = new(() => new MinIOHelperProvider());

    /// <summary>
    /// MinIO 对象存储访问助手提供者
    /// </summary>
    public static MinIOHelperProvider Default => _lazyInstance.Value;

    #endregion


    /// <summary>
    /// 创建 MinIO 对象存储访问助手
    /// </summary>
    /// <param name="options">选项参数</param>
    /// <returns>MinIO对象存储访问助手</returns>
    public IMinIOHelper New(MinIOOptions options) => new MinIOHelper(options);
}