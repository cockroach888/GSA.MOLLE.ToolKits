//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineConnectorFactoryProvider.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2023-02-23 23:36:08
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.DBUtility.TDengine;

/// <summary>
/// TDengine RESTful API 连接器创建工厂提供者
/// </summary>
public sealed class TDengineConnectorFactoryProvider
{

    #region 单例模式

    private static readonly Lazy<TDengineConnectorFactoryProvider> _lazyInstance = new(() => new TDengineConnectorFactoryProvider());

    /// <summary>
    /// TDengine RESTful API 连接器创建工厂提供者
    /// </summary>
    public static TDengineConnectorFactoryProvider Default => _lazyInstance.Value;

    #endregion


    /// <summary>
    /// 创建 TDengine RESTful API 连接器创建工厂实例
    /// </summary>
    /// <param name="options">选项参数</param>
    /// <returns>TDengine RESTful API 连接器创建工厂</returns>
    public ITDengineConnectorFactory Create(TDengineOptions? options = default) => new TDengineConnectorFactory(options);
}