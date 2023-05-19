//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：DatabaseType.cs
// 项目名称：EMQX消息服务工具集
// 创建时间：2023-03-21 22:34:19
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.EMQXUtility.Entity;

/// <summary>
/// 数据库类型枚举
/// </summary>
public enum DatabaseType
{
    /// <summary>
    /// 内置数据库
    /// </summary>
    BuiltInDatabase,

    /// <summary>
    /// MySQL 数据库
    /// </summary>
    MySQL,

    /// <summary>
    /// PostgreSQL 数据库
    /// </summary>
    PostgreSQL,

    /// <summary>
    /// Redis 数据库
    /// </summary>
    Redis,

    /// <summary>
    /// MongoDB 数据库
    /// </summary>
    MongoDB,

    /// <summary>
    /// HTTP 服务
    /// </summary>
    HTTPServer,

    /// <summary>
    /// 无
    /// </summary>
    NONE
}