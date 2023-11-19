//=========================================================================
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
#pragma warning disable CS0618
[ClassInterface(ClassInterfaceType.AutoDual)]
#pragma warning restore CS0618
[ComVisible(true)]
public sealed class MainWindowController : IWebController
{
    private readonly IWebBrowser _browser;
    private readonly Dispatcher _dispatcher;
    private readonly MainWindowService _service;


    /// <summary>
    /// 主窗体控制器
    /// </summary>
    /// <param name="browser">浏览器</param>
    /// <param name="dispatcher">调度器</param>
    public MainWindowController(IWebBrowser browser, Dispatcher dispatcher)
    {
        _browser = browser;
        _dispatcher = dispatcher;

        _browser.OnWebMessageReceived += Browser_OnWebMessageReceived;
        _service = new(dispatcher);
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
    /// 消息接收处理事件
    /// </summary>
    /// <param name="sender">事件对象</param>
    /// <param name="e">事件参数</param>
    /// <exception cref="NotImplementedException">当不存在指定导航目标时发生的异常</exception>
    private void Browser_OnWebMessageReceived(object? sender, WebMessageReceivedWebArgs e)
    {
        // do something.
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
        => _service.IncludeAddin(keyword, value);

    /// <summary>
    /// 添加要排除的内容
    /// </summary>
    /// <param name="keyword">关键字</param>
    /// <param name="value">值</param>
    public void ExcludeAddin(string keyword, string value)
        => _service.ExcludeAddin(keyword, value);


    /// <summary>
    /// 移除要包含的内容
    /// </summary>
    /// <param name="value">值</param>
    public void IncludeRemove(string value)
    {
        string[] source = value.Split('-', StringSplitOptions.RemoveEmptyEntries);

        if (source.Length >= 2)
        {
            _service.IncludeRemove(source[0], source[1]);
        }
    }

    /// <summary>
    /// 移除要排除的内容
    /// </summary>
    /// <param name="value">值</param>
    public void ExcludeRemove(string value)
    {
        string[] source = value.Split('-', StringSplitOptions.RemoveEmptyEntries);

        if (source.Length >= 2)
        {
            _service.ExcludeRemove(source[0], source[1]);
        }
    }


    /// <summary>
    /// 启动
    /// </summary>
    /// <param name="paramString">参数字符串</param>
    public async Task<IEnumerable<string>> StartAsync(string paramString)
        => await _service.StartAsync(paramString).ConfigureAwait(false);

    /// <summary>
    /// 停止
    /// </summary>
    public async Task StopAsync()
        => await _service.StopAsync().ConfigureAwait(false);
}