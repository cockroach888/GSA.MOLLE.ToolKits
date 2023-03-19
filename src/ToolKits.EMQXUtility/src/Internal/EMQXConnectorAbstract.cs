//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：EMQXConnectorAbstract.cs
// 项目名称：EMQX消息服务工具集
// 创建时间：2023-03-16 22:39:00
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.EMQXUtility;

/// <summary>
/// EMQX连接器基类
/// </summary>
internal abstract class EMQXConnectorAbstract : IDisposable
{
    private protected readonly RestClient _client;


    /// <summary>
    /// EMQX连接器基类
    /// </summary>
    private protected EMQXConnectorAbstract(EMQXManagementOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.BasedHost) ||
            string.IsNullOrWhiteSpace(options.APIKey) ||
            string.IsNullOrWhiteSpace(options.SecretKey))
        {
            throw new ArgumentNullException("对不起！EMQX 服务主机地址、API Key、Secret Key均不能为空。");
        }

        RestClientOptions clientOptions = new(options.BasedHost)
        {
            Authenticator = new HttpBasicAuthenticator(options.APIKey, options.SecretKey)
        };

        _client = new(clientOptions);
    }


    /// <summary>
    /// 内部编号
    /// </summary>
    protected internal string Id { get; } = Guid.NewGuid().ToString("N");

    /// <summary>
    /// EMQX RESTful API 客户端
    /// </summary>
    protected internal RestClient Client => _client;


    /// <summary>
    /// 资源释放
    /// </summary>
    public void Dispose()
    {
        using (_client) { }
    }
}