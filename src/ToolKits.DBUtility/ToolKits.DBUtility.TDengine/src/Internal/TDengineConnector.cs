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
internal sealed class TDengineConnector : ITDengineConnector
{
    private readonly RestClient _client;


    /// <summary>
    /// TDengine RESTful API 连接器
    /// </summary>
    /// <param name="options">TDengine选项参数</param>
    public TDengineConnector(TDengineOptions? options)
    {
        Options = options ?? throw new ArgumentNullException(nameof(TDengineOptions));

        if (options.UserName is null ||
            options.Password is null ||
            string.IsNullOrWhiteSpace(options.UserName) ||
            string.IsNullOrWhiteSpace(options.Password))
        {
            throw new ArgumentNullException("用于访问数据库的用户名和密码不能为空。");
        }

        RestClientOptions clientOptions = new(options.BaseUri)
        {
            Authenticator = new HttpBasicAuthenticator(options.UserName, options.Password)
        };

        _client = new(clientOptions);
    }


    /// <summary>
    /// 连接器内部编号
    /// </summary>
    internal int Id { get; } = Guid.NewGuid().GetHashCode();


    #region 接口实现[ITDengineConnector]

    /// <summary>
    /// TDengine 选项参数
    /// </summary>
    public TDengineOptions Options { get; }


    /// <summary>
    /// 执行 RESTful API 请求，并返回请求结果的泛型对象。
    /// </summary>
    /// <typeparam name="TRequestResult">用于序列化请求结果的泛型</typeparam>
    /// <param name="param">通用查询参数</param>
    /// <returns>请求结果泛型对象</returns>
    public async Task<TRequestResult?> ExecuteAsync<TRequestResult>(TDengineQueryParam param)
        where TRequestResult : class, new()
    {
        RestRequest request = CreateRequest(param);
        return await _client.PostAsync<TRequestResult>(request, param.Token).ConfigureAwait(false);
    }

    /// <summary>
    /// 执行 RESTful API 请求，并返回请求结果的原始字符串。
    /// </summary>
    /// <remarks>返回原始的字符串请求结果</remarks>
    /// <param name="param">通用查询参数</param>
    /// <returns>请求结果原始字符串</returns>
    public async Task<string?> ExecuteAsync(TDengineQueryParam param)
    {
        RestRequest request = CreateRequest(param);
        RestResponse response = await _client.PostAsync(request, param.Token).ConfigureAwait(false);
        return response.Content;
    }

    #endregion


    /// <summary>
    /// 创建Rest所需要的请求对象
    /// </summary>
    /// <param name="param">通用查询参数</param>
    /// <returns>Rest请求对象</returns>
    private RestRequest CreateRequest(TDengineQueryParam param)
    {
        RestRequest request = new()
        {
            Method = Method.Post
        };

        // 数据库名称
        if (!string.IsNullOrWhiteSpace(param.DBName) &&
            param.DBName is not null)
        {
            request.Resource = param.DBName;

            // 时区参数，只有带数据库名称时方可有效。
            if (Options.VersionSelector is TDengineVersion.V3 &&
                !string.IsNullOrWhiteSpace(Options.TimeZone))
            {
                request.Resource = $"{param.DBName}?tz={Options.TimeZone}";
            }
        }

        // 自动补全SQL语句末尾结束符
        if (param.SqlString.EndsWith(";") is false)
        {
            param.SqlString += ";";
        }

        request.AddStringBody(param.SqlString, DataFormat.None);

        return request;
    }

    /// <summary>
    /// 资源释放
    /// </summary>
    public void Dispose()
    {
        using (_client) { }
    }
}