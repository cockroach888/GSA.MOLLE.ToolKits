﻿//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：GenericHostBuilderExtensions.cs
// 项目名称：EMQX消息服务工具集
// 创建时间：2023-02-23 23:09:09
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

namespace GSA.ToolKits.EMQXUtility;

/// <summary>
/// EMQX消息服务工具集通用主机(GenericHost)扩展类
/// </summary>
public static class GenericHostBuilderExtensions
{
    /// <summary>
    /// 集成EMQX消息服务工具集
    /// </summary>
    /// <remarks>
    /// <para><see cref="EMQXManagementOptions"/> 来自默认的配置文件中，如：appsettings.json 文件。</para>
    /// <para>注意：配置节名称必须与类名称相同，即：EMQXManagementOptions。</para>
    /// </remarks>
    /// <param name="hostBuilder">The <see cref="IHostBuilder"/> to configure.</param>
    /// <returns>实现链式编程的同一个 <see cref="IHostBuilder"/> 实例。</returns>
    public static IHostBuilder UseEMQXUtility(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureServices((context, services) =>
        {
            services.Configure<EMQXManagementOptions>(context.Configuration.GetSection(nameof(EMQXManagementOptions)));

            var config = context.Configuration.GetSection(nameof(EMQXManagementOptions));
            EMQXManagementOptions? opt = ConfigurationBinder.Get<EMQXManagementOptions>(config);

            if (opt is not null)
            {
                services.TryAddSingleton(sp => EMQXManagementHelperProvider.Default.Create(opt));
            }
        });
    }

    /// <summary>
    /// 集成EMQX消息服务工具集
    /// </summary>
    /// <param name="hostBuilder">The <see cref="IHostBuilder"/> to configure.</param>
    /// <param name="configure">选项参数</param>
    /// <returns>实现链式编程的同一个 <see cref="IHostBuilder"/> 实例。</returns>
    public static IHostBuilder UseEMQXUtility(this IHostBuilder hostBuilder, Action<EMQXManagementOptions> configure)
    {
        return hostBuilder.ConfigureServices((context, services) =>
        {
            services.Configure(configure);

            var config = context.Configuration.GetSection(nameof(EMQXManagementOptions));
            EMQXManagementOptions? opt = ConfigurationBinder.Get<EMQXManagementOptions>(config);

            if (opt is null)
            {
                throw new ArgumentNullException(nameof(EMQXManagementOptions));
            }

            services.TryAddSingleton(sp => EMQXManagementHelperProvider.Default.Create(opt));
        });
    }
}