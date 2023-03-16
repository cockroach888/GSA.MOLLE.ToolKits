//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TelemetryHelperExtensions.cs
// 项目名称：魂哥常用工具集
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
/// 类功能说明
/// </summary>
public static class TelemetryHelperExtensions
{
    /// <summary>
    /// 获取遥测数据信息
    /// </summary>
    /// <param name="helper">EMQX 管理助手</param>
    /// <returns>遥测数据信息</returns>
    public static async Task<TelemetryDataModel?> GetDataAsync(this ITelemetryHelper helper)
    {
        TelemetryHelper innerHelper = (TelemetryHelper)helper;
        RestRequest request = new("telemetry/data", method: Method.Get);
        return await innerHelper.Client.GetAsync<TelemetryDataModel>(request).ConfigureAwait(false);
    }
}