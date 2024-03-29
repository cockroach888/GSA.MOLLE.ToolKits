﻿//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：StatusHelperExtensions.cs
// 项目名称：EMQX消息服务工具集
// 创建时间：2023-03-16 23:19:43
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
/// 服务节点状态信息助手扩展
/// </summary>
public static class StatusHelperExtensions
{
    /// <summary>
    /// 获取EMQX服务节点状态(健康检查)
    /// </summary>
    /// <remarks>返回文本格式</remarks>
    /// <param name="helper">管理助手</param>
    /// <returns>EMQ状态</returns>
    public static async Task<string?> GetStatusToTextAsync(this IStatusHelper helper)
    {
        StatusHelper innerHelper = (StatusHelper)helper;

        RestRequest request = new("status", method: Method.Get);
        request.AddQueryParameter("format", "text");

        RestResponse response = await innerHelper.Client.GetAsync(request).ConfigureAwait(false);
        return response.Content;
    }

    /// <summary>
    /// 获取EMQX服务节点状态(健康检查)
    /// </summary>
    /// <remarks>返回JSON格式</remarks>
    /// <param name="helper">管理助手</param>
    /// <returns>EMQ状态</returns>
    public static async Task<EMQStatusModel?> GetStatusToJsonAsync(this IStatusHelper helper)
    {
        StatusHelper innerHelper = (StatusHelper)helper;

        RestRequest request = new("status", method: Method.Get);
        request.AddQueryParameter("format", "json");

        return await innerHelper.Client.GetAsync<EMQStatusModel>(request).ConfigureAwait(false);
    }
}