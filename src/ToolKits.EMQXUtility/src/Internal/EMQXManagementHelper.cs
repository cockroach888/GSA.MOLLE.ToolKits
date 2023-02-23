//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：EMQXManagementHelper.cs
// 项目名称：EMQX消息服务工具集
// 创建时间：2023-02-23 15:05:22
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

namespace GSA.ToolKits.EMQXUtility;

/// <summary>
/// EMQX 管理助手
/// </summary>
internal sealed class EMQXManagementHelper : IEMQXManagementHelper
{
    private readonly EMQXManagementOptions _options;
    private readonly RestClient _client;


    /// <summary>
    /// EMQX 管理助手
    /// </summary>
    /// <param name="options">选项参数</param>
    public EMQXManagementHelper(EMQXManagementOptions options)
    {
        _options = options;

        if (string.IsNullOrWhiteSpace(options.BasedHost) ||
            string.IsNullOrWhiteSpace(options.APIKey) ||
            string.IsNullOrWhiteSpace(options.SecretKey))
        {
            throw new ArgumentNullException("对不起！EMQX 服务主机地址、API Key、Secret Key均不能为空。");
        }

        _client = new(options.BasedHost)
        {
            Authenticator = new HttpBasicAuthenticator(options.APIKey, options.SecretKey)
        };
    }


    /// <summary>
    /// EMQX 管理助手内部编号
    /// </summary>
    internal string Id { get; } = Guid.NewGuid().ToString("N");


    #region 接口实现[IEMQXManagementHelper]

    /// <summary>
    /// 获取遥测数据信息
    /// </summary>
    /// <returns>遥测数据信息</returns>
    public async Task<TelemetryDataModel?> GetTelemetryDataAsync()
    {
        RestRequest request = new("/telemetry/data")
        {
            Method = Method.Get
        };

        return await _client.PostAsync<TelemetryDataModel>(request).ConfigureAwait(false);
    }

    #endregion


    /// <summary>
    /// 资源释放
    /// </summary>
    public void Dispose()
    {
        using (_client) { }
    }
}