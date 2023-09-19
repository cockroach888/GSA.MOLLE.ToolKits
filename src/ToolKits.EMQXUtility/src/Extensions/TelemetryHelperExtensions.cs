//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TelemetryHelperExtensions.cs
// 项目名称：EMQX消息服务工具集
// 创建时间：2023-03-16 23:11:53
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
/// 遥测管理助手扩展
/// </summary>
public static class TelemetryHelperExtensions
{
    /// <summary>
    /// 更新遥测状态
    /// </summary>
    /// <param name="helper">管理助手</param>
    /// <param name="info">遥测状态</param>
    /// <returns>遥测状态</returns>
    public static async Task<EMQTelemetryStatusModel?> UpdateStatusAsync(this ITelemetryHelper helper, EMQTelemetryStatusModel info)
    {
        TelemetryHelper innerHelper = (TelemetryHelper)helper;

        RestRequest request = new("telemetry/status", method: Method.Put);
        request.AddJsonBody(info);

        EMQTelemetryStatusModel? result = default;
        RestResponse response = await innerHelper.Client.ExecutePutAsync(request).ConfigureAwait(false);

        if (!string.IsNullOrWhiteSpace(response.Content))
        {
            result = JsonSerializer.Deserialize<EMQTelemetryStatusModel>(response.Content);
        }

        return result;
    }

    /// <summary>
    /// 获取遥测状态
    /// </summary>
    /// <param name="helper">管理助手</param>
    /// <returns>遥测状态</returns>
    public static async Task<EMQTelemetryStatusModel?> GetStatusAsync(this ITelemetryHelper helper)
    {
        TelemetryHelper innerHelper = (TelemetryHelper)helper;

        RestRequest request = new("telemetry/status", method: Method.Get);

        return await innerHelper.Client.GetAsync<EMQTelemetryStatusModel>(request).ConfigureAwait(false);
    }

    /// <summary>
    /// 获取遥测数据
    /// </summary>
    /// <param name="helper">管理助手</param>
    /// <returns>遥测数据</returns>
    public static async Task<EMQTelemetryDataModel?> GetDataAsync(this ITelemetryHelper helper)
    {
        TelemetryHelper innerHelper = (TelemetryHelper)helper;

        RestRequest request = new("telemetry/data", method: Method.Get);

        EMQTelemetryDataModel? result = await innerHelper.Client.GetAsync<EMQTelemetryDataModel>(request).ConfigureAwait(false);

        if (result is not null)
        {
            result.IsSuccessStatusCode = string.IsNullOrWhiteSpace(result.ErrorCode) ? true : false;
        }

        return result;
    }
}