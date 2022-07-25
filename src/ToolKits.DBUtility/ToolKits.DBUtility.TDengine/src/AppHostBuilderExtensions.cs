//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：AppHostBuilderExtensions.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-06-22 22:20:19
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace GSA.ToolKits.DBUtility.TDengine;

/// <summary>
/// 涛思数据通用主机扩展类
/// </summary>
public static class AppHostBuilderExtensions
{
    /// <summary>
    /// 集成TDengine时序数据库
    /// </summary>
    /// <param name="hostBuilder">The <see cref="IHostBuilder"/> to configure.</param>
    /// <param name="configure">TDengine选项参数</param>
    /// <returns>实现链式编程的同一个 <see cref="IHostBuilder"/> 实例。</returns>
    public static IHostBuilder UseTDengineDB(this IHostBuilder hostBuilder, Action<TDengineOptions> configure)
    {
        return hostBuilder.ConfigureServices((context, services) =>
        {
            services.Configure(configure);

            var config = context.Configuration.GetSection(nameof(TDengineOptions));
            TDengineOptions opt = ConfigurationBinder.Get<TDengineOptions>(config);

            services.TryAddSingleton<ITDengineConnector>(sp => new TDengineConnector(opt));
            services.TryAddSingleton<ITDengineConnectorFactory, TDengineConnectorFactory>();
        });
    }

    /// <summary>
    /// 集成TDengine时序数据库
    /// </summary>
    /// <remarks>
    /// <para><see cref="TDengineOptions"/> 来自默认的配置文件中，如：appsettings.json 文件。</para>
    /// <para>注意：配置节名称必须与类名称相同，即：TDengineOptions。</para>
    /// </remarks>
    /// <param name="hostBuilder">The <see cref="IHostBuilder"/> to configure.</param>
    /// <returns>实现链式编程的同一个 <see cref="IHostBuilder"/> 实例。</returns>
    public static IHostBuilder UseTDengineDB(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureServices((context, services) =>
        {
            services.Configure<TDengineOptions>(context.Configuration.GetSection(nameof(TDengineOptions)));

            var config = context.Configuration.GetSection(nameof(TDengineOptions));
            TDengineOptions opt = ConfigurationBinder.Get<TDengineOptions>(config);

            services.TryAddSingleton<ITDengineConnector>(sp => new TDengineConnector(opt));
            services.TryAddSingleton<ITDengineConnectorFactory, TDengineConnectorFactory>();
        });
    }
}