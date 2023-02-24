//=========================================================================
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
    /// <returns>遥测数据信息</returns>
    public static async Task<TelemetryDataModel?> GetTelemetryDataAsync(this IEMQXManagementHelper helper)
    {
        EMQXManagementHelper innerHelper = (EMQXManagementHelper)helper;

        RestRequest request = new("telemetry/data")
        {
            Method = Method.Get
        };

        return await innerHelper.Client.GetAsync<TelemetryDataModel>(request).ConfigureAwait(false);
    }
}