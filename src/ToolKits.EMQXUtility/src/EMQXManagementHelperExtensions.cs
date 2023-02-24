﻿//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：EMQXManagementHelperExtensions.cs
// 项目名称：EMQX消息服务工具集
// 创建时间：2023-02-23 16:48:36
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

namespace GSA.ToolKits.EMQXUtility;

/// <summary>
/// EMQX 管理助手扩展
/// </summary>
public static class EMQXManagementHelperExtensions
{
    /// <summary>
    /// 获取遥测数据信息
    /// </summary>
    /// <param name="helper">EMQX 管理助手</param>
    /// <returns>遥测数据信息</returns>
    public static async Task<TelemetryDataModel?> GetTelemetryDataAsync(this IEMQXManagementHelper helper)
    {
        EMQXManagementHelper innerHelper = (EMQXManagementHelper)helper;
        RestRequest request = new("telemetry/data", method: Method.Get);
        return await innerHelper.Client.GetAsync<TelemetryDataModel>(request).ConfigureAwait(false);
    }

    /// <summary>
    /// 为指定的认证器创建用户信息
    /// </summary>
    /// <param name="helper">EMQX 管理助手</param>
    /// <param name="info">认证用户信息</param>
    /// <returns>创建结果</returns>
    public static async Task<AuthenticationUserCreateResult?> CreateAuthenticationUser(this IEMQXManagementHelper helper, AuthenticationUserCreateModel info)
    {
        if (string.IsNullOrWhiteSpace(info.AuthenticatorId) ||
            string.IsNullOrWhiteSpace(info.UserName) ||
            string.IsNullOrWhiteSpace(info.Password))
        {
            throw new ArgumentNullException("对不起！认证器 ID、用户名和密码均不能为空。");
        }

        EMQXManagementHelper innerHelper = (EMQXManagementHelper)helper;

        string urlString = $"authentication/{info.AuthenticatorId}/users";
        RestRequest request = new(urlString, method: Method.Post); ;

        var uri = innerHelper.Client.BuildUri(request);

        request.AddJsonBody(info);
        //request.Parameters.AddParameter(new JsonParameter("user_id", info.UserName, contentType: "application/json"));
        //request.Parameters.AddParameter(new JsonParameter("password", info.Password, contentType: "application/json"));
        //request.Parameters.AddParameter(new JsonParameter("is_superuser", info.IsSuperuser, contentType: "application/json"));

        var result = await innerHelper.Client.PostAsync<AuthenticationUserCreateResult>(request).ConfigureAwait(false);
        return result;
    }
}