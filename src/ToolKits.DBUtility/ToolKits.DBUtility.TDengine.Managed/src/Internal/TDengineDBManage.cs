//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineDBManage.cs
// 项目名称：TDengine 数据库管理
// 创建时间：2022-07-25 14:04:01
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using Microsoft.Extensions.Logging;
using System.Text;

namespace GSA.ToolKits.DBUtility.TDengine.Managed;

/// <summary>
/// TDengine 数据库管理类
/// </summary>
internal sealed class TDengineDBManage : ITDengineDBManage
{
    private readonly ILogger<TDengineDBManage> _logger;
    private readonly ITDengineConnector _connector;


    /// <summary>
    /// TDengine 数据库管理
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="connector">连接器</param>
    public TDengineDBManage(ILogger<TDengineDBManage> logger, ITDengineConnector connector)
    {
        _logger = logger;
        _connector = connector;
    }


    #region 接口实现[ITDengineDBManage]

    /// <summary>
    /// 创建数据库
    /// </summary>
    /// <param name="option">选项参数</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async Task CreateAsync(DatabaseCreateOption option)
    {
        StringBuilder sb = new();
        sb.Append($"create database");

        if (option.CheckIsExist)
        {
            sb.Append(" if not exists");
        }

        sb.Append($" {option.DBName.ToLower()}");
        sb.Append($" cache {option.Cache}");
        sb.Append($" blocks {option.Blocks}");
        sb.Append($" days {option.Days}");
        sb.Append($" keep {option.Keep}");

        if (option.MinRows is not null)
        {
            sb.Append($" minRows {option.MinRows.Value}");
        }

        if (option.MaxRows is not null)
        {
            sb.Append($" maxRows {option.MaxRows.Value}");
        }

        if (option.WalLevel is not null)
        {
            sb.Append($" wal {option.WalLevel.Value}");
        }

        if (option.FSync is not null)
        {
            sb.Append($" fsync {option.FSync}");
        }

        sb.Append($" update {option.Update}");

        if (option.CacheLast is not null)
        {
            sb.Append($" cacheLast {option.CacheLast.Value}");
        }

        if (option.Replica is not null)
        {
            sb.Append($" replica {option.Replica.Value}");
        }

        if (option.Quorum is not null)
        {
            sb.Append($" quorum {option.Quorum.Value}");
        }

        if (option.Comp is not null)
        {
            sb.Append($" comp {option.Comp.Value}");
        }

        if (!string.IsNullOrWhiteSpace(option.Precision))
        {
            sb.Append($" precision {option.Precision}");
        }

        sb.Append(';');

        TDengineQueryParam param = new(sb.ToString());
        _ = await _connector.ExecutionToResultAsync(param).ConfigureAwait(false);
    }

    /// <summary>
    /// 删除数据库
    /// </summary>
    /// <param name="dbName">数据库名称</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async Task DropAsync(string dbName)
    {
        _logger.LogInformation($"删除数据库“{dbName}”。");

        string sqlString = $"drop database if exists {dbName};";
        TDengineQueryParam param = new(sqlString);
        _ = await _connector.ExecutionToResultAsync(param).ConfigureAwait(false);
    }

    #endregion

}