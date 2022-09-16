//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：AppHostBuilderExtensions.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-09-16 15:14:31
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace TDengineEx.DataHelper;

/// <summary>
/// 数据库操作通用主机扩展类
/// </summary>
public static class AppHostBuilderExtensions
{
    /// <summary>
    /// 集成所有的业务数据库
    /// </summary>
    /// <param name="hostBuilder">The <see cref="IHostBuilder"/> to configure.</param>
    /// <returns>实现链式编程的同一个 <see cref="IHostBuilder"/> 实例。</returns>
    public static IHostBuilder UseAllBusinessDB(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureServices((context, services) =>
        {
            services.TryAddSingleton<IAutoStationHelper, AutoStationHelper>();
            services.TryAddSingleton<IAutoStationDataHelper, AutoStationDataHelper>();
        });
    }
}