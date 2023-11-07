//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：App.cs
// 项目名称：自动删除文件工具
// 创建时间：2023-11-07 15:34:53
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using CeriumX.WebEngine.WebView2.GenericHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace GSA.ToolKits.AutomaticDeletionFiles;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IHost? _host;


    /// <summary>
    /// 启动事件
    /// </summary>
    /// <param name="e">传递事件</param>
    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);


        // WebView2 运行时环境检查
        IConfiguration cfgSettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
        WebView2EnvConfigure? envConfig = cfgSettings.GetRequiredSection(nameof(WebView2EnvConfigure)).Get<WebView2EnvConfigure>();

        if (envConfig is null ||
            string.IsNullOrWhiteSpace(envConfig.WebView2RuntimeFolder) ||
            !System.IO.Directory.Exists(envConfig.WebView2RuntimeFolder))
        {
            MessageBox.Show("对不起！请确认 WebView2 所需的运行时环境是否配置正确。", "系统提示", MessageBoxButton.OK, MessageBoxImage.Error);
            Current.Shutdown();
            return;
        }


        IHostBuilder builder = Host.CreateDefaultBuilder(e.Args)
            .ConfigureHostConfiguration(config =>
            {
                // 添加全局配置文件
                config.AddEnvironmentVariables()
                      .SetBasePath(AppContext.BaseDirectory)
                      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                      .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                      .AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true);
            })
            .ConfigureAppConfiguration((context, configurationBuilder) =>
            {
                // do something.
            })
            .ConfigureServices((context, services) =>
            {
                // 添加 WebView2 环境配置
                services.Configure<WebView2EnvConfigure>(context.Configuration.GetSection(nameof(WebView2EnvConfigure)));
            })
            .ConfigureServices((services) =>
            {
                // 注册控制器
                //services.TryAddSingleton<AlarmAnalysisController>();
            })
            .ConfigureServices((services) =>
            {
                // 注册用户控件
                //services.AddSingleton<ModuleControlAbstract, AlarmAnalysisControl>();
            })
            .ConfigureServices((services) =>
            {
                // 注册窗体
                services.AddSingleton<MainWindow>();
            })
            .ConfigureLogging((context, logging) =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });


        // 集成日志服务、数据服务
        _host = builder.UseWebEngine(envConfig.WebView2RuntimeFolder, envConfig.UserDataFolder)
                       //.UseNLog()
                       .Build();

        // 阻塞式运行
        //await _host.RunAsync().ConfigureAwait(false);
        await _host.StartAsync().ConfigureAwait(false);


        // 显示主窗体
        MainWindow? mainWindow = _host.Services.GetService<MainWindow>();
        mainWindow?.Show();
    }

    /// <summary>
    /// 退出事件
    /// </summary>
    /// <param name="e">传递事件</param>
    protected override async void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);

        if (_host is not null)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
            }
        }
    }
}