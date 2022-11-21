//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：AutoStationHostedService.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-09-16 15:45:18
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Diagnostics;
using TDengineEx.DataHelper;

namespace TDengineEx.Bootstrapper.Services;

/// <summary>
/// 自动气象站主机托管服务
/// </summary>
internal sealed class AutoStationHostedService : IHostedService
{
    private readonly ILogger<AutoStationHostedService> _logger;
    private readonly IAutoStationHelper _stationHelper;
    private readonly IAutoStationDataHelper _stationDataHelper;


    /// <summary>
    /// 自动气象站主机托管服务
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="stationHelper">数据访问助手</param>
    /// <param name="stationDataHelper">数据访问助手</param>
    public AutoStationHostedService(
        ILogger<AutoStationHostedService> logger,
        IAutoStationHelper stationHelper,
        IAutoStationDataHelper stationDataHelper)
    {
        _logger = logger;
        _stationHelper = stationHelper;
        _stationDataHelper = stationDataHelper;
    }


    public async Task StartAsync(CancellationToken cancellationToken)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        var info = await _stationHelper.SelectAsync("nmcqx1025").ConfigureAwait(false);
        stopwatch.Stop();

        _logger.LogInformation($"查询到站点信息：编号({info?.StationId})、站名({info?.StationName})，耗时：{stopwatch.Elapsed}");


        stopwatch.Restart();
        var datas = await _stationDataHelper.SearchAsync("nmcqx1025").ConfigureAwait(false);
        stopwatch.Stop();

        _logger.LogInformation($"查询到站点数据：{datas?.Count()}条，耗时：{stopwatch.Elapsed}");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}