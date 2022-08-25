//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：ResetAutoStationDB.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-08-25 23:10:09
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace TDengineEx.Bootstrapper.ResetDB;

/// <summary>
/// 重置气象自动站数据库
/// </summary>
internal sealed class ResetAutoStationDB : IResetDB
{
    private readonly ILogger<ResetAutoStationDB> _logger;
    private readonly ITDengineConnector _connector;
    private const string DBNAME = "db_auto_station";
    private const string STABLENAME = "auto_station";


    /// <summary>
    /// 重置气象自动站数据库
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="connector">TDengine连接器</param>
    public ResetAutoStationDB(ILogger<ResetAutoStationDB> logger, ITDengineConnector connector)
    {
        _logger = logger;
        _connector = connector;
    }


    #region 接口实现[IResetDB]

    /// <summary>
    /// 执行
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async Task ExecuteAsync()
    {
        await DropDB().ConfigureAwait(false);
        await CreateDB().ConfigureAwait(false);
        await CreateSTable().ConfigureAwait(false);
        await CreateTable().ConfigureAwait(false);
    }

    #endregion

    #region 成员方法

    /// <summary>
    /// 日志
    /// </summary>
    /// <param name="msg">日志消息</param>
    /// <param name="script">SQL脚本</param>
    private void Log(string? msg, string script)
    {
        msg ??= $"成功执行SQL脚本：{script}";
        _logger.LogInformation(msg);
    }

    /// <summary>
    /// 删除数据库
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    private async Task DropDB()
    {
        string sqlString = $"drop database if exists {DBNAME};";
        string? result = await _connector.ExecutionSqlAsync(sqlString).ConfigureAwait(false);
        Log(result, sqlString);
    }

    /// <summary>
    /// 创建数据库
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    private async Task CreateDB()
    {
        // V2
        //string sqlString = $"create database if not exists {DBNAME} keep 30 days 1 cache 32 blocks 8 update 0;";

        // V3
        string sqlString = $"create database if not exists {DBNAME} buffer 256 cachemodel 'last_row' cachesize 4 duration 1 keep 30 precision 'ms';";

        string? result = await _connector.ExecutionSqlAsync(sqlString).ConfigureAwait(false);
        Log(result, sqlString);
    }

    /// <summary>
    /// 创建超级数据表
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    private async Task CreateSTable()
    {
        string sqlString = $"create stable if not exists {DBNAME}.{STABLENAME} (tss timestamp, report_time timestamp, temperature float, air_pressure float, relative_humidity float, maximum_wind_speed float, rainfall float) tags (station_id varchar(32), station_name nchar(64), longitude float, latitude float, altitude float, level smallint);";
        string? result = await _connector.ExecutionSqlAsync(sqlString).ConfigureAwait(false);
        Log(result, sqlString);
    }

    /// <summary>
    /// 创建数据表
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    private async Task CreateTable()
    {
        foreach (var ids in Definition.Default.Ids)
        {
            string sqlString = $"create table if not exists {DBNAME}.{STABLENAME}_{ids.id} using {DBNAME}.{STABLENAME} tags ('{ids.id}', '{ids.name}', {ids.longitude}, {ids.latitude}, {ids.altitude}, {ids.level});";
            string? result = await _connector.ExecutionSqlAsync(sqlString).ConfigureAwait(false);
            Log(result, sqlString);
        }
    }

    #endregion

}