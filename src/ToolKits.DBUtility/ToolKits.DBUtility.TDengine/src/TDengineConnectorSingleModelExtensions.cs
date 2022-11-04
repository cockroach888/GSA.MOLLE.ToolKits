//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineConnectorSingleModelExtensions.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-11-04 15:42:56
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
    /// 执行查询请求操作，并返回其数据模型信息。
    /// </summary>
    /// <remarks>ExecuteDataModelAsync的扩展方法，当存在多条数据时，将返回第一条数据。</remarks>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <typeparam name="TIgnoreAttribute">自定义属性泛型(忽略的)</typeparam>
    /// <param name="connector">TDengine RESTful API 连接器</param>
    /// <param name="param">通用查询参数</param>
    /// <returns>数据模型</returns>
    public static async Task<TModel?> ExecuteSingleModelAsync<TModel, TIgnoreAttribute>(
        this ITDengineConnector connector,
        TDengineQueryParam param)
        where TModel : class, new()
        where TIgnoreAttribute : Attribute
    {
        IEnumerable<TModel>? result = await connector.ExecuteDataModelAsync<TModel, TIgnoreAttribute>(param).ConfigureAwait(false);

        if (result is null)
        {
            return default;
        }

        return result.FirstOrDefault();
    }

    /// <summary>
    /// 执行查询请求操作，并返回其数据模型信息。
    /// </summary>
    /// <remarks>ExecuteDataModelAsync的扩展方法，当存在多条数据时，将返回第一条数据。</remarks>
    /// <typeparam name="TModel">数据模型泛型</typeparam>
    /// <param name="connector">TDengine RESTful API 连接器</param>
    /// <param name="param">通用查询参数</param>
    /// <returns>数据模型</returns>
    public static async Task<TModel?> ExecuteSingleModelAsync<TModel>(
        this ITDengineConnector connector,
        TDengineQueryParam param)
        where TModel : class, new()
    {
        IEnumerable<TModel>? result = await connector.ExecuteDataModelAsync<TModel>(param).ConfigureAwait(false);

        if (result is null)
        {
            return default;
        }

        return result.FirstOrDefault();
    }
}