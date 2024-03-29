﻿//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：CockroachServiceFactory.cs
// 项目名称：魂哥常用工具集
// 创建时间：2021-02-28 20:06:22
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.CockroachContainer;

/// <summary>
/// 自定义服务(伪IOC)容器工厂
/// </summary>
public static class CockroachServiceFactory
{
    /// <summary>
    /// 新建自定义服务(伪IOC)容器
    /// </summary>
    /// <returns></returns>
    public static ICockroachService New() => new CockroachService();
}