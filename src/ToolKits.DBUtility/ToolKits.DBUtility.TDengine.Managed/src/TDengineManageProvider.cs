//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineManageProvider.cs
// 项目名称：TDengine 数据库管理
// 创建时间：2022-07-28 10:55:54
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.DBUtility.TDengine.Managed;

/// <summary>
/// TDengine 数据库管理提供者类
/// </summary>
public sealed class TDengineManageProvider
{

    #region 单例模式

    private static readonly Lazy<TDengineManageProvider> _lazyInstance = new(() => new TDengineManageProvider());

    /// <summary>
    /// 类功能说明
    /// </summary>
    internal static TDengineManageProvider Default { get; } = _lazyInstance.Value;

    #endregion


    /// <summary>
    /// 创建 TDengine 数据库管理实例
    /// </summary>
    /// <param name="connector">连接器</param>
    /// <returns>TDengine 数据库管理</returns>
    public ITDengineDBManage CreateDBManage(ITDengineConnector connector) => new TDengineDBManage(connector);

    /// <summary>
    /// 创建 TDengine 超级数据表管理实例
    /// </summary>
    /// <param name="connector">连接器</param>
    /// <returns>TDengine 超级数据表管理</returns>
    public ITDengineSTableManage CreateSTableManage(ITDengineConnector connector) => new TDengineSTableManage(connector);

    /// <summary>
    /// 创建 TDengine 数据表管理实例
    /// </summary>
    /// <param name="connector">连接器</param>
    /// <returns>TDengine 数据表管理</returns>
    public ITDengineTableManage CreateTableManage(ITDengineConnector connector) => new TDengineTableManage(connector);
}