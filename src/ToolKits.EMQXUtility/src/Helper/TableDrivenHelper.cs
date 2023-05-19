//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TableDrivenHelper.cs
// 项目名称：EMQX消息服务工具集
// 创建时间：2023-04-05 13:02:31
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.EMQXUtility.Helper;

/// <summary>
/// 表驱动应用助手类
/// </summary>
internal sealed class TableDrivenHelper
{
    private readonly Dictionary<AuthenticationType, string> _authType = new();
    private readonly Dictionary<DatabaseType, string> _databaseType = new();


    /// <summary>
    /// 表驱动应用助手
    /// </summary>
    public TableDrivenHelper()
    {
        // 全局认证类型
        _authType[AuthenticationType.PasswordBased] = "password_based";
        _authType[AuthenticationType.JWT] = "jwt";
        _authType[AuthenticationType.SCRAM] = "scram";


        // 数据库类型
        _databaseType[DatabaseType.BuiltInDatabase] = "built_in_database";
        _databaseType[DatabaseType.MySQL] = "mysql";
        _databaseType[DatabaseType.PostgreSQL] = "postgresql";
        _databaseType[DatabaseType.Redis] = "redis";
        _databaseType[DatabaseType.MongoDB] = "mongodb";
        _databaseType[DatabaseType.HTTPServer] = "http";
    }


    /// <summary>
    /// 获取数据库类型编码字符串
    /// </summary>
    /// <param name="type">数据库类型</param>
    /// <returns>数据库类型编码字符串</returns>
    public string GetBackend(DatabaseType type) => _databaseType[type];

    /// <summary>
    /// 获取全局认证类型编码字符串
    /// </summary>
    /// <param name="type">全局认证类型</param>
    /// <returns>全局认证类型编码字符串</returns>
    public string GetMechanism(AuthenticationType type) => _authType[type];
}