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
using GSA.ToolKits.DBUtility.TDengine.Entity;

namespace GSA.ToolKits.DBUtility.TDengine;

/// <summary>
/// TDengine RESTful API 连接器扩展类
/// </summary>
public static class TDengineConnectorExtensions
{
    /// <summary>
    /// 执行指定SQL语句
    /// </summary>
    /// <remarks>返回请求结果实体</remarks>
    /// <param name="connector">TDengine RESTful API 连接器</param>
    /// <param name="dbName">数据库名称</param>
    /// <param name="sqlString">需要执行的SQL字符串</param>
    /// <param name="cancellationToken">取消令牌对象</param>
    /// <returns>请求结果</returns>
    public static Task<TDengineResult?> ExecutionToResultAsync(
        this ITDengineConnector connector,
        string dbName,
        string sqlString,
        CancellationToken cancellationToken = default)
        => connector.ExecutionAsync<TDengineResult>(dbName, sqlString, cancellationToken);

    /// <summary>
    /// 执行指定SQL语句
    /// </summary>
    /// <remarks>
    /// 返回数据模型枚举列表。
    /// <para>注意：查询SQL语句须包含字段，并与泛型属性的顺序和数量保持一致。</para>
    /// </remarks>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <param name="connector">TDengine RESTful API 连接器</param>
    /// <param name="dbName">数据库名称</param>
    /// <param name="sqlString">需要执行的SQL字符串</param>
    /// <param name="cancellationToken">取消令牌对象</param>
    /// <returns>数据模型枚举列表</returns>
    /// <exception cref="Exception">抛出的异常信息</exception>
    public static async Task<IEnumerable<TModel>?> ExecutionToModelAsync<TModel>(
        this ITDengineConnector connector,
        string dbName,
        string sqlString,
        CancellationToken cancellationToken = default)
        where TModel : class, new()
    {
        TDengineResult? result = await connector.ExecutionToResultAsync(dbName, sqlString, cancellationToken).ConfigureAwait(false);

        if (result == null)
        {
            return Enumerable.Empty<TModel>();
        }

        if (result.Status != TDengineStatus.Succ)
        {
            throw new Exception($"执行SQL语句时出现错误。数据库名：{dbName}，SQL语句：{sqlString}，返回结果：{result.Desc}。");
        }

        return await result.ParseDataToTModelAsync<TModel>().ConfigureAwait(false);
    }

    /// <summary>
    /// 执行数据记录统计操作
    /// </summary>
    /// <param name="connector">TDengine RESTful API 连接器</param>
    /// <param name="dbName">数据库名称</param>
    /// <param name="tbName">数据表名称</param>
    /// <param name="whereString">查询条件字符串</param>
    /// <param name="cancellationToken">取消令牌对象</param>
    /// <returns>数据记录数</returns>
    /// <exception cref="Exception">抛出的异常信息</exception>
    public static async Task<long> ExecutionToCountAsync(
        this ITDengineConnector connector,
        string dbName,
        string tbName,
        string? whereString = null,
        CancellationToken cancellationToken = default)
    {
        string sqlString = $"select count(*) from {tbName};";

        if (!string.IsNullOrWhiteSpace(whereString) &&
            whereString.StartsWith("where"))
        {
            whereString = whereString.Insert(0, " ");
            sqlString = sqlString.Insert(sqlString.Length - 1, whereString);
        }

        TDengineResult? result = await connector.ExecutionToResultAsync(dbName, sqlString, cancellationToken).ConfigureAwait(false);

        if (result == null)
        {
            return 0;
        }

        if (result.Status != TDengineStatus.Succ)
        {
            throw new Exception($"执行数据记录统计时出现错误。数据库名：{dbName}，SQL语句：{sqlString}，返回结果：{result.Desc}。");
        }

        return result.ParseDataToCountAsync();
    }
}