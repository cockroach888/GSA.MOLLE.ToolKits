﻿//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineConnectorProvider.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-06-22 22:24:25
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.DBUtility.TDengine.Internal;

namespace GSA.ToolKits.DBUtility.TDengine;

/// <summary>
/// TDengine RESTful API 连接器提供者类
/// </summary>
public sealed class TDengineConnectorProvider
{

    #region 单例模式

    private static readonly Lazy<TDengineConnectorProvider> _lazyInstance = new(() => new TDengineConnectorProvider());

    /// <summary>
    /// TDengine RESTful API 连接器提供者
    /// </summary>
    public static TDengineConnectorProvider Default { get; } = _lazyInstance.Value;

    #endregion


    /// <summary>
    /// 创建 TDengine RESTful API 连接器实例
    /// </summary>
    /// <param name="options">选项参数</param>
    /// <returns>TDengine RESTful API 连接器</returns>
    public ITDengineConnector Create(TDengineOptions options) => new TDengineConnector(options);
}