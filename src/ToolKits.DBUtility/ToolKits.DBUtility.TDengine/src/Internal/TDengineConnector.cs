//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineConnector.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-06-22 22:21:33
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using RestSharp;
using RestSharp.Authenticators;

namespace GSA.ToolKits.DBUtility.TDengine;

/// <summary>
/// TDengine RESTful API 连接器类
/// </summary>
internal sealed class TDengineConnector : ITDengineConnector, IDisposable
{
    private readonly RestClient _client;


    /// <summary>
    /// TDengine RESTful API 连接器
    /// </summary>
    /// <param name="options">TDengine选项参数</param>
    public TDengineConnector(TDengineOptions options)
    {
        _client = new(options.BaseUri)
        {
            Authenticator = new HttpBasicAuthenticator(options.UserName, options.Password)
        };
    }


    /// <summary>
    /// 连接器内部编号
    /// </summary>
    internal int Id { get; } = Guid.NewGuid().GetHashCode();


    #region 接口实现[ITDengineConnector]

    /// <summary>
    /// 执行指定SQL语句
    /// </summary>
    /// <typeparam name="T">用于返回结果使用的泛型定义</typeparam>
    /// <param name="param">通用查询参数</param>
    /// <returns>返回结果泛型对象</returns>
    public async Task<T?> ExecutionAsync<T>(TDengineQueryParam param)
        where T : class, new()
    {
        RestRequest request = new()
        {
            Method = Method.Post
        };

        if (!string.IsNullOrWhiteSpace(param.DBName))
        {
            request.Resource = param.DBName;
        }

        request.AddStringBody(param.SqlString, DataFormat.None);

        return await _client.PostAsync<T>(request, param.Token).ConfigureAwait(false);
    }

    /// <summary>
    /// 执行指定SQL语句
    /// </summary>
    /// <param name="param">通用查询参数</param>
    public async Task<string?> ExecutionAsync(TDengineQueryParam param)
    {
        RestRequest request = new()
        {
            Method = Method.Post
        };

        if (!string.IsNullOrWhiteSpace(param.DBName))
        {
            request.Resource = param.DBName;
        }

        request.AddStringBody(param.SqlString, DataFormat.None);

        RestResponse response = await _client.PostAsync(request, param.Token).ConfigureAwait(false);
        return response.Content;
    }

    #endregion

    /// <summary>
    /// 资源释放
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public void Dispose()
    {
        using (_client) { }
    }
}