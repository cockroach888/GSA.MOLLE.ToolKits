//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：DataHelperAbstract.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-09-16 15:22:07
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace TDengineEx.DataHelper;

/// <summary>
/// 数据访问助手抽象类
/// </summary>
internal abstract class DataHelperAbstract : IDataHelper
{
    private readonly ITDengineConnector _connector;


    /// <summary>
    /// 数据访问助手抽象
    /// </summary>
    /// <param name="connector">TDengine RESTful API 连接器</param>
    public DataHelperAbstract(ITDengineConnector connector)
    {
        _connector = connector;
    }


    /// <summary>
    /// TDengine RESTful API 连接器
    /// </summary>
    internal ITDengineConnector Connector => _connector;

    /// <summary>
    /// 数据库名称
    /// </summary>
    internal virtual string? DBName { get; } = "db_auto_station";

    /// <summary>
    /// 数据表格前缀
    /// </summary>
    /// <remarks>PS：超级表与子表的关联性，也可以是独立表名称。</remarks>
    internal virtual string? TablePrefix { get; }


    #region 接口实现[IDataHelper]

    /// <summary>
    /// 执行查询请求操作，并返回其数据模型枚举列表。
    /// </summary>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <typeparam name="TIgnoreAttribute">自定义属性泛型(忽略的)</typeparam>
    /// <param name="sqlString">需要执行的SQL字符串</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>数据模型枚举列表</returns>
    public virtual async ValueTask<IEnumerable<TModel>?> QueryDataModelAsync<TModel, TIgnoreAttribute>(string sqlString, CancellationToken cancellationToken = default)
        where TModel : class, new()
        where TIgnoreAttribute : Attribute
    {
        TDengineQueryParam param = new(sqlString)
        {
            DBName = DBName,
            Token = cancellationToken
        };

        return await _connector.ExecuteDataModelAsync<TModel, TIgnoreAttribute>(param).ConfigureAwait(false);
    }

    /// <summary>
    /// 执行查询请求操作，并返回其数据模型枚举列表。
    /// </summary>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <param name="sqlString">需要执行的SQL字符串</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>数据模型枚举列表</returns>
    public virtual async ValueTask<IEnumerable<TModel>?> QueryDataModelAsync<TModel>(string sqlString, CancellationToken cancellationToken = default)
        where TModel : class, new()
    {
        TDengineQueryParam param = new(sqlString)
        {
            DBName = DBName,
            Token = cancellationToken
        };

        return await _connector.ExecuteDataModelAsync<TModel>(param).ConfigureAwait(false);
    }


    /// <summary>
    /// 执行查询请求操作，并返回其数据模型信息。
    /// </summary>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <typeparam name="TIgnoreAttribute">自定义属性泛型(忽略的)</typeparam>
    /// <param name="sqlString">需要执行的SQL字符串</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>数据模型</returns>
    public virtual async ValueTask<TModel?> QuerySingleModelAsync<TModel, TIgnoreAttribute>(string sqlString, CancellationToken cancellationToken = default)
        where TModel : class, new()
        where TIgnoreAttribute : Attribute
    {
        TDengineQueryParam param = new(sqlString)
        {
            DBName = DBName,
            Token = cancellationToken
        };

        return await _connector.ExecuteSingleModelAsync<TModel, TIgnoreAttribute>(param).ConfigureAwait(false);
    }

    /// <summary>
    /// 执行查询请求操作，并返回其数据模型信息。
    /// </summary>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <param name="sqlString">需要执行的SQL字符串</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>数据模型</returns>
    public virtual async ValueTask<TModel?> QuerySingleModelAsync<TModel>(string sqlString, CancellationToken cancellationToken = default)
        where TModel : class, new()
    {
        TDengineQueryParam param = new(sqlString)
        {
            DBName = DBName,
            Token = cancellationToken
        };

        return await _connector.ExecuteSingleModelAsync<TModel>(param).ConfigureAwait(false);
    }

    #endregion

}