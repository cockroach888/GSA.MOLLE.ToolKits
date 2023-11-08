//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MainWindow.cs
// 项目名称：自动移动文件工具
// 创建时间：2023-11-07 15:35:09
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using CeriumX.WebEngine.Abstractions;
using Microsoft.Extensions.Options;
using System.Windows;

namespace GSA.ToolKits.AutomaticMoveFiles;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private IWebWindow<UIElement>? _webWindow;
    private readonly IWebWindowFactory _webWindowFactory;
    private readonly WebView2EnvConfigure _config;


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <param name="webFactory">浏览器窗口创建工厂</param>
    /// <param name="options">WebView2 环境配置选项</param>
    public MainWindow(IWebWindowFactory webFactory, IOptions<WebView2EnvConfigure> options)
    {
        _webWindowFactory = webFactory;
        _config = options.Value;

        InitializeComponent();
    }


    /// <summary>
    /// 初始化完成时事件
    /// </summary>
    /// <param name="e">传递事件</param>
    protected override async void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);

        try
        {
            WebOptions options = WebOptions.Create($"{_config.DomainURL}/index.html");
            _webWindow = await _webWindowFactory.CreateAsync<UIElement>(options).ConfigureAwait(false);
            MainContent.Child = _webWindow.BrowserControl;

            _webWindow.OnWebBrowserInitializationCompleted += (sender, e) =>
            {
                if (e.IsSuccess)
                {
                    _webWindow.Browser!.OnWebMessageReceived += Browser_OnWebMessageReceived;
                    _webWindow.Browser.AddVirtualHostNameToFolderMapping(_config.DomainName, _config.FullVirtualFolder, VirtualResourceAccessKind.DenyCors);
                    //_webWindow.Browser.AddControllerToScript(_controller);

                    // TODO: 仅当调试时打开开发者管理窗口
                    //_webWindow.Browser.OpenDevToolsWindow();
                }
            };
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "系统提示", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

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
}