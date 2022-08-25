//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：ResetDBBackgroundService.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-08-25 22:55:29
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace TDengineEx.Bootstrapper.Services;

/// <summary>
/// TDengine ResetDB 后台主机托管服务
/// </summary>
internal sealed class ResetDBBackgroundService : BackgroundService
{
    private readonly ILogger<ResetDBBackgroundService> _logger;
    private readonly IServiceProvider _serviceProvider;


    /// <summary>
    /// TDengine ResetDB 后台主机托管服务
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="serviceProvider">容器服务</param>
    public ResetDBBackgroundService(ILogger<ResetDBBackgroundService> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"启动 TDengine ResetDB 后台主机托管服务。");

        return base.StartAsync(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"停止 TDengine ResetDB 后台主机托管服务。");

        return base.StopAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation($"执行 TDengine ResetDB 后台主机托管服务。");

        IEnumerable<IResetDB> services = _serviceProvider.GetServices<IResetDB>();

        foreach (IResetDB reset in services)
        {
            await reset.ExecuteAsync().ConfigureAwait(false);
        }

        _logger.LogInformation($"完成 TDengine ResetDB 后台主机托管服务执行。");
    }
}