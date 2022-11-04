//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineConnectorSearchModelExtensions.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-11-04 15:43:09
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
    /// 执行数据检索请求操作，并返回其数据模型枚举列表。
    /// </summary>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <typeparam name="TIgnoreAttribute">自定义属性泛型(忽略的)</typeparam>
    /// <param name="connector">TDengine RESTful API 连接器</param>
    /// <param name="searchParam">数据检索参数</param>
    /// <returns>数据模型枚举列表</returns>
    /// <exception cref="Exception">执行请求发生异常时，抛出的异常信息。</exception>
    public static async Task<IEnumerable<TModel>?> ExecuteSearchModelAsync<TModel, TIgnoreAttribute>(
        this ITDengineConnector connector,
        TDengineSearchParam searchParam)
        where TModel : class, new()
        where TIgnoreAttribute : Attribute
    {
        if (!string.IsNullOrWhiteSpace(searchParam.DBName) &&
            !searchParam.TableName.StartsWith(searchParam.DBName))
        {
            searchParam.TableName = $"{searchParam.DBName}.{searchParam.TableName}";
        }

        string sqlString = $"select {searchParam.FieldNames} from {searchParam.TableName}";
        sqlString = TDengineCommons.WhereStringValidateAndJoinToSqlString(sqlString, searchParam.WhereString);
        sqlString = TDengineCommons.OrderByJoinToSqlString(sqlString, searchParam.OrderByString);
        sqlString = TDengineCommons.PaginationJoinToSqlString(sqlString, searchParam.PageNumber, searchParam.PaginationSize);

        TDengineQueryParam param = new(sqlString)
        {
            DBName = searchParam.DBName,
            Token = searchParam.Token
        };

        TDengineResult? result = await connector.ExecuteRequestResultAsync(param).ConfigureAwait(false);

        if (result is null)
        {
            return Enumerable.Empty<TModel>();
        }

        if (!string.IsNullOrWhiteSpace(result.Desc) &&
            result.Desc is not null)
        {
            throw new Exception($"执行请求时出现错误。数据库名：{param.DBName}，SQL语句：{param.SqlString}，错误描述：{result.Desc}。");
        }

        return await result.ParseToTModelAsync<TModel, TIgnoreAttribute>().ConfigureAwait(false);
    }

    /// <summary>
    /// 执行数据检索请求操作，并返回其数据模型枚举列表。
    /// </summary>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <param name="connector">TDengine RESTful API 连接器</param>
    /// <param name="searchParam">数据检索参数</param>
    /// <returns>数据模型枚举列表</returns>
    /// <exception cref="Exception">执行请求发生异常时，抛出的异常信息。</exception>
    public static async Task<IEnumerable<TModel>?> ExecuteSearchModelAsync<TModel>(
        this ITDengineConnector connector,
        TDengineSearchParam searchParam)
        where TModel : class, new()
    {
        if (!string.IsNullOrWhiteSpace(searchParam.DBName) &&
            !searchParam.TableName.StartsWith(searchParam.DBName))
        {
            searchParam.TableName = $"{searchParam.DBName}.{searchParam.TableName}";
        }

        string sqlString = $"select {searchParam.FieldNames} from {searchParam.TableName}";
        sqlString = TDengineCommons.WhereStringValidateAndJoinToSqlString(sqlString, searchParam.WhereString);
        sqlString = TDengineCommons.OrderByJoinToSqlString(sqlString, searchParam.OrderByString);
        sqlString = TDengineCommons.PaginationJoinToSqlString(sqlString, searchParam.PageNumber, searchParam.PaginationSize);

        TDengineQueryParam param = new(sqlString)
        {
            DBName = searchParam.DBName,
            Token = searchParam.Token
        };

        TDengineResult? result = await connector.ExecuteRequestResultAsync(param).ConfigureAwait(false);

        if (result is null)
        {
            return Enumerable.Empty<TModel>();
        }

        if (!string.IsNullOrWhiteSpace(result.Desc) &&
            result.Desc is not null)
        {
            throw new Exception($"执行请求时出现错误。数据库名：{param.DBName}，SQL语句：{param.SqlString}，错误描述：{result.Desc}。");
        }

        return await result.ParseToTModelAsync<TModel>().ConfigureAwait(false);
    }
}