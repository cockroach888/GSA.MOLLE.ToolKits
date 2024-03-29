﻿//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineConnectorExtensions.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-06-22 22:24:16
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
/// TDengine RESTful API 连接器扩展类
/// </summary>
public static partial class TDengineConnectorExtensions
{
    /// <summary>
    /// 执行指定请求操作，并返回其请求结果。
    /// </summary>
    /// <remarks>请求结果为 RESTful API 返回结果的序列化对象。</remarks>
    /// <param name="connector">TDengine RESTful API 连接器</param>
    /// <param name="param">通用查询参数</param>
    /// <returns>请求结果</returns>
    public static async Task<TDengineResult?> ExecuteRequestResultAsync(
        this ITDengineConnector connector,
        TDengineQueryParam param)
        => await connector.ExecuteAsync<TDengineResult>(param).ConfigureAwait(false);


    /// <summary>
    /// 执行非查询请求操作，并返回其请求结果。
    /// </summary>
    /// <remarks>请求结果仅在执行时发生异常，才返回其异常信息，否则返回null值。</remarks>
    /// <param name="connector">TDengine RESTful API 连接器</param>
    /// <param name="sqlString">需要执行的SQL字符串</param>
    /// <param name="token">取消令牌</param>
    /// <returns>请求结果</returns>
    public static async Task<string?> ExecuteNonQueryAsync(
        this ITDengineConnector connector,
        string sqlString,
        CancellationToken token = default)
    {
        TDengineQueryParam param = new(sqlString)
        {
            Token = token
        };

        TDengineResult? result = await connector.ExecuteRequestResultAsync(param).ConfigureAwait(false);
        return result?.Desc;
    }


    /// <summary>
    /// 执行数据记录统计请求操作，并返回其统计结果。
    /// </summary>
    /// <param name="connector">TDengine RESTful API 连接器</param>
    /// <param name="condition">条件查询参数</param>
    /// <returns>数据记录数</returns>
    /// <exception cref="Exception">执行请求发生异常时，抛出的异常信息。</exception>
    public static async Task<long> ExecuteRecordNumAsync(
        this ITDengineConnector connector,
        TDengineWhereParam condition)
    {
        string sqlString = $"select count(*) from {condition.TableName}";
        sqlString = TDengineCommons.WhereStringValidateAndJoinToSqlString(sqlString, condition.WhereString);

        TDengineQueryParam param = new(sqlString)
        {
            DBName = condition.DBName,
            Token = condition.Token
        };

        TDengineResult? result = await connector.ExecuteRequestResultAsync(param).ConfigureAwait(false);

        if (result is null)
        {
            return 0;
        }

        if (!string.IsNullOrWhiteSpace(result.Desc) &&
            result.Desc is not null)
        {
            throw new Exception($"执行数据记录统计时出现错误。数据库名：{param.DBName}，SQL语句：{param.SqlString}，错误描述：{result.Desc}。");
        }

        return result.ParseToCount();
    }
}