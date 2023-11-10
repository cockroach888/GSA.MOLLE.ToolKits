﻿//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MainWindowController.cs
// 项目名称：自动删除文件工具
// 创建时间：2023-11-08 15:54:04
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Windows.Threading;

namespace GSA.ToolKits.AutomaticDeletionFiles.Controllers;

/// <summary>
/// 主窗体控制器
/// </summary>
[ClassInterface(ClassInterfaceType.AutoDual)]
[ComVisible(true)]
public sealed class MainWindowController : IWebController
{
    private Dispatcher? _dispatcher;
    private MainWindowService? _service;


    /// <summary>
    /// 主窗体控制器
    /// </summary>
    public MainWindowController()
    {
        // do something.
    }


    #region 接口实现[IWebController]

    /// <summary>
    /// 将CSharp对象注册为JS对象的控制器名称
    /// </summary>
    public string ControllerName { get; } = "mainWindow";

    /// <summary>
    /// 资源释放
    /// </summary>
    public void Dispose()
    {
        // do something.
    }

    #endregion


    /// <summary>
    /// 传递调度器
    /// </summary>
    /// <param name="dispatcher">调度器</param>
    internal void TransmitDispatcher(Dispatcher dispatcher)
    {
        _dispatcher = dispatcher;
        _service = new(dispatcher);
    }


    /// <summary>
    /// 监视目录浏览
    /// </summary>
    /// <returns>需要监视的目录</returns>
    public async Task<string?> BrowserDirectories()
    {
        return await _dispatcher!.InvokeAsync(() =>
        {
            string folderPath = string.Empty;
            System.Windows.Forms.FolderBrowserDialog dialog = new();

            if (dialog.ShowDialog() is System.Windows.Forms.DialogResult.OK)
            {
                folderPath = dialog.SelectedPath;
            }

            return folderPath;
        });
    }

    /// <summary>
    /// 添加要包含的内容
    /// </summary>
    /// <param name="keyword">关键字</param>
    /// <param name="value">值</param>
    public void IncludeAddin(string keyword, string value)
        => _service?.IncludeAddin(keyword, value);

    /// <summary>
    /// 添加要排除的内容
    /// </summary>
    /// <param name="keyword">关键字</param>
    /// <param name="value">值</param>
    public void ExcludeAddin(string keyword, string value)
        => _service?.ExcludeAddin(keyword, value);

    /// <summary>
    /// 移除要包含的内容
    /// </summary>
    /// <param name="keyword">关键字</param>
    /// <param name="value">值</param>
    public void IncludeRemove(string keyword, string value)
        => _service?.IncludeRemove(keyword, value);

    /// <summary>
    /// 移除要排除的内容
    /// </summary>
    /// <param name="keyword">关键字</param>
    /// <param name="value">值</param>
    public void ExcludeRemove(string keyword, string value)
        => _service?.ExcludeRemove(keyword, value);


    /// <summary>
    /// 启动
    /// </summary>
    public void Start()
        => _service?.Start();

    /// <summary>
    /// 停止
    /// </summary>
    public void Stop()
        => _service?.Stop();
}