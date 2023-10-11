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
using System.Text;

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
        try
        {
            await DropDB().ConfigureAwait(false);
            await CreateDB().ConfigureAwait(false);

            await CreateAutoStation().ConfigureAwait(false);
            await CreateAutoStationData().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }

    #endregion

    #region 成员方法

    /// <summary>
    /// 日志
    /// </summary>
    /// <param name="msg">日志消息</param>
    private void Log(string? msg)
    {
        if (msg is null)
        {
            _logger.LogDebug("成功执行SQL脚本。");
        }
        else
        {
            _logger.LogDebug($"执行SQL脚本时出现异常：{msg}");
        }
    }

    #endregion

    #region 数据库

    /// <summary>
    /// 删除数据库
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    private async Task DropDB()
    {
        string sqlString = $"drop database if exists {DBNAME}";
        string? result = await _connector.ExecuteNonQueryAsync(sqlString).ConfigureAwait(false);
        Log(result);
    }

    /// <summary>
    /// 创建数据库
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    private async Task CreateDB()
    {
        // V2
        string sqlString = $"create database if not exists {DBNAME} keep 365 days 1 cache 32 blocks 8 update 0";

        // V3
        if (_connector.Options.VersionSelector is TDengineVersion.V3)
        {
            sqlString = $"create database if not exists {DBNAME} buffer 256 cachemodel 'last_row' cachesize 4 duration 1 keep 365 precision 'ms'";
        }

        string? result = await _connector.ExecuteNonQueryAsync(sqlString).ConfigureAwait(false);
        Log(result);
    }

    #endregion

    #region 自动站信息

    /// <summary>
    /// 创建自动站信息
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    private async Task CreateAutoStation()
    {
        StringBuilder sb = new();
        sb.Append("create table if not exists ")
          .Append($"{DBNAME}.{STABLENAME}_info")
          .Append(" (")
          .Append("tss timestamp,")
          .Append("station_id binary(32),")
          .Append("station_name nchar(64),")
          .Append("latitude float,")
          .Append("longitude float,")
          .Append("altitude float,")
          .Append("level smallint")
          .Append(')');

        string? result = await _connector.ExecuteNonQueryAsync(sb.ToString()).ConfigureAwait(false);
        Log(result);

        // 写入初始数据
        foreach (var (id, name, latitude, longitude, altitude, level) in Definition.Default.Ids)
        {
            sb.Clear();
            sb.Append("insert into ")
              .Append($"{DBNAME}.{STABLENAME}_info")
              .Append(" values ")
              .Append('(')
              .Append($"'{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}',")
              .Append($"'{id}',")
              .Append($"'{name}',")
              .Append($"{latitude},")
              .Append($"{longitude},")
              .Append($"{altitude},")
              .Append($"{level}")
              .Append(')');

            result = await _connector.ExecuteNonQueryAsync(sb.ToString()).ConfigureAwait(false);
            Log(result);
        }
    }

    #endregion

    #region 自动站数据

    /// <summary>
    /// 创建自动站数据
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    private async Task CreateAutoStationData()
    {
        await CreateDataSTable().ConfigureAwait(false);
        await CreateDataTable().ConfigureAwait(false);
        await CreateMockData().ConfigureAwait(false);
    }

    /// <summary>
    /// 创建超级数据表
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    private async Task CreateDataSTable()
    {
        StringBuilder sb = new();
        sb.Append("create stable if not exists ")
          .Append($"{DBNAME}.{STABLENAME}")
          .Append(" (")
          .Append("tss timestamp,")
          .Append("report_time timestamp,")
          .Append("temperature float,")
          .Append("air_pressure float,")
          .Append("relative_humidity float,")
          .Append("maximum_wind_speed float,")
          .Append("rainfall float")
          .Append(") tags (")
          .Append("station_id binary(32),")
          .Append("station_name nchar(64),")
          .Append("latitude float,")
          .Append("longitude float,")
          .Append("altitude float,")
          .Append("level smallint")
          .Append(')');

        string? result = await _connector.ExecuteNonQueryAsync(sb.ToString()).ConfigureAwait(false);
        Log(result);
    }

    /// <summary>
    /// 创建数据表
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    private async Task CreateDataTable()
    {
        foreach (var (id, name, latitude, longitude, altitude, level) in Definition.Default.Ids)
        {
            StringBuilder sb = new();
            sb.Append("create table if not exists ")
              .Append($"{DBNAME}.{STABLENAME}_{id}")
              .Append($" using ")
              .Append($"{DBNAME}.{STABLENAME}")
              .Append(" tags ")
              .Append('(')
              .Append($"'{id}',")
              .Append($"'{name}',")
              .Append($"{latitude},")
              .Append($"{longitude},")
              .Append($"{altitude},")
              .Append($"{level}")
              .Append(')');

            string? result = await _connector.ExecuteNonQueryAsync(sb.ToString()).ConfigureAwait(false);
            Log(result);
        }
    }

    /// <summary>
    /// 创建模拟数据
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    private async Task CreateMockData()
    {
        foreach (var (id, _, _, _, _, _) in Definition.Default.Ids)
        {
            for (int i = 0, iLen = Random.Shared.Next(1000, 5000); i < iLen; i++)
            {
                StringBuilder sb = new();
                sb.Append("insert into ")
                  .Append($"{DBNAME}.{STABLENAME}_{id}")
                  .Append(" values ")
                  .Append('(')
                  .Append($"'{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}',") // tss timestamp
                  .Append($"'{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}',") // report_time timestamp
                  .Append($"{Random.Shared.Next(-70, 70)},") // temperature float
                  .Append($"{Random.Shared.Next(0, 1500)},") // air_pressure float
                  .Append($"{Random.Shared.Next(0, 100)},") // relative_humidity float
                  .Append($"{Random.Shared.Next(0, 128)},") // maximum_wind_speed float
                  .Append($"{Random.Shared.Next(0, 250)}") // rainfall float
                  .Append(')');

                string? result = await _connector.ExecuteNonQueryAsync(sb.ToString()).ConfigureAwait(false);
                Log(result);
            }
        }
    }

    #endregion

}