//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：GenericHostBuilderExtensions.cs
// 项目名称：MinIO对象存储辅助工具集
// 创建时间：2024-12-13 18:30:13
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

namespace GSA.ToolKits.MinIOUtility.GenericHost;

/// <summary>
/// MinIO对象存储辅助工具集通用主机(GenericHost)扩展类
/// </summary>
public static class GenericHostBuilderExtensions
{
    /// <summary>
    /// 集成 MinIO 对象存储辅助工具集
    /// </summary>
    /// <remarks>
    /// <para><see cref="MinIOOptions"/> 来自默认的配置文件中，如：appsettings.json 文件。</para>
    /// <para>注意：配置节名称必须与类名称相同，即：MinIOOptions。</para>
    /// </remarks>
    /// <param name="hostBuilder">The <see cref="IHostBuilder"/> to configure.</param>
    /// <returns>实现链式编程的同一个 <see cref="IHostBuilder"/> 实例。</returns>
    public static IHostBuilder UseMinIOUtility(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureServices((context, services) =>
        {
            services.Configure<MinIOOptions>(context.Configuration.GetSection(nameof(MinIOOptions)));

            var config = context.Configuration.GetSection(nameof(MinIOOptions));
            MinIOOptions? options = ConfigurationBinder.Get<MinIOOptions>(config);

            if (options is null)
            {
                throw new ArgumentNullException(nameof(MinIOOptions), "用于操作MinIO对象存储的配置信息不正确或为空，请确认后重试！");
            }

            services.TryAddSingleton(sp => MinIOHelperFactoryProvider.Default.New(options));
            services.TryAddSingleton(sp => MinIOHelperProvider.Default.New(options));
        });
    }

    /// <summary>
    /// 集成 MinIO 对象存储辅助工具集
    /// </summary>
    /// <param name="hostBuilder">The <see cref="IHostBuilder"/> to configure.</param>
    /// <param name="configure">TDengine选项参数</param>
    /// <returns>实现链式编程的同一个 <see cref="IHostBuilder"/> 实例。</returns>
    public static IHostBuilder UseMinIOUtility(this IHostBuilder hostBuilder, Action<MinIOOptions> configure)
    {
        return hostBuilder.ConfigureServices((context, services) =>
        {
            services.Configure(configure);

            var config = context.Configuration.GetSection(nameof(MinIOOptions));
            MinIOOptions? options = ConfigurationBinder.Get<MinIOOptions>(config);

            if (options is null)
            {
                throw new ArgumentNullException(nameof(MinIOOptions), "用于操作MinIO对象存储的配置信息不正确或为空，请确认后重试！");
            }

            services.TryAddSingleton(sp => MinIOHelperFactoryProvider.Default.New(options));
            services.TryAddSingleton(sp => MinIOHelperProvider.Default.New(options));
        });
    }
}