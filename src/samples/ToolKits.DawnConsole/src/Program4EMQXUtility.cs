﻿//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：Program4EMQXUtility.cs
// 项目名称：功能调测控制台程序
// 创建时间：2023-03-19 21:20:38
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.EMQXUtility;
using GSA.ToolKits.EMQXUtility.Entity;
using System.Reflection;
using System.Text.Json;

namespace GSA.ToolKits.DawnConsole;

/// <summary>
/// EMQXUtility
/// </summary>
internal sealed class Program4EMQXUtility
{

    #region 单例模式

    private static readonly Lazy<Program4EMQXUtility> _lazyInstance = new(() => new Program4EMQXUtility());

    /// <summary>
    /// EMQXUtility
    /// </summary>
    internal static Program4EMQXUtility Default => _lazyInstance.Value;

    #endregion


    private readonly EMQXManagementOptions _options = new EMQXManagementOptions()
    {
        BasedHost = "http://127.0.0.1:10151/api/v5",
        APIKey = "9bb32c6faff83032",
        SecretKey = "Z0rs9AXYwzfEkh9B6QYWmyluBFZZAkQn69CbNUZklwPU6D"
    };


    #region EMQX服务节点状态

    /// <summary>
    /// 获取EMQX服务节点状态(健康检查)
    /// </summary>
    /// <remarks>返回文本格式</remarks>
    public async Task GetStatusToTextAsync()
    {
        using IStatusHelper _helper = StatusHelperProvider.Default.Create(_options);
        string? statusString = await _helper.GetStatusToTextAsync().ConfigureAwait(false);

        Console.WriteLine($"EMQX服务节点状态：{statusString}");
        Console.WriteLine();
        Console.WriteLine();
    }

    /// <summary>
    /// 获取EMQX服务节点状态(健康检查)
    /// </summary>
    /// <remarks>返回JSON格式</remarks>
    public async Task GetStatusToJsonAsync()
    {
        using IStatusHelper _helper = StatusHelperProvider.Default.Create(_options);
        EMQStatusModel? model = await _helper.GetStatusToJsonAsync().ConfigureAwait(false);

        Console.WriteLine($"EMQX服务节点状态：{JsonSerializer.Serialize(model)}");
        Console.WriteLine();
        Console.WriteLine();
    }

    #endregion


    #region 遥测状态

    /// <summary>
    /// 获取遥测状态
    /// </summary>
    public async Task GetTelemetryStatusAsync()
    {
        using ITelemetryHelper _helper = TelemetryHelperProvider.Default.Create(_options);
        EMQTelemetryStatusModel? model = await _helper.GetStatusAsync().ConfigureAwait(false);

        Console.WriteLine($"EMQX遥测状态：{JsonSerializer.Serialize(model)}");
        Console.WriteLine();
        Console.WriteLine();
    }

    /// <summary>
    /// 获取遥测数据
    /// </summary>
    public async Task GetTelemetryDataAsync()
    {
        using ITelemetryHelper _helper = TelemetryHelperProvider.Default.Create(_options);
        EMQTelemetryDataModel? model = await _helper.GetDataAsync().ConfigureAwait(false);

        Console.WriteLine($"EMQX遥测数据：{JsonSerializer.Serialize(model)}");
        Console.WriteLine();
        Console.WriteLine();
    }

    /// <summary>
    /// 更新遥测状态
    /// </summary>
    /// <param name="status">遥测状态</param>
    public async Task UpdateTelemetryStatusAsync(bool status)
    {
        using ITelemetryHelper _helper = TelemetryHelperProvider.Default.Create(_options);
        EMQTelemetryStatusModel info = new()
        {
            Enable = status
        };
        EMQTelemetryStatusModel? model = await _helper.UpdateStatusAsync(info).ConfigureAwait(false);

        Console.WriteLine($"EMQX遥测状态：{JsonSerializer.Serialize(model)}");
        Console.WriteLine();
        Console.WriteLine();
    }

    #endregion



    //password_based:built_in_database
    //scram:built_in_database

    /*
    // 创建超级用户
    AuthenticationUserCreateModel info = new()
    {
        AuthenticatorId = "password_based:built_in_database",
        UserName = "superuser",
        Password = "superuser123",
        IsSuperuser = true
    };
    AuthenticationUserCreateResult result = await _helper.CreateAuthenticationUser(info).ConfigureAwait(false);
    Console.WriteLine(JsonSerializer.Serialize(result));
    Console.WriteLine();

    // 创建普通用户
    info = new()
    {
        AuthenticatorId = "password_based:built_in_database",
        UserName = "normaluser",
        Password = "normaluser123",
        IsSuperuser = false
    };
    result = await _helper.CreateAuthenticationUser(info).ConfigureAwait(false);
    Console.WriteLine(JsonSerializer.Serialize(result));
    Console.WriteLine();
    */

    /*AuthenticationUserQueryParam param = new()
    {
        AuthenticatorId = "password_based:built_in_database",
        UserName = "superuser"
    };
    AuthenticationUserQueryResult queryResult = await _helper.QueryAuthenticationUser(param).ConfigureAwait(false);
    Console.WriteLine(JsonSerializer.Serialize(queryResult));
    Console.WriteLine();*/

}