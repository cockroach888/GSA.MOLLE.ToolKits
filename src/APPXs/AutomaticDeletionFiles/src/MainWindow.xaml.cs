//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MainWindow.cs
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
using Microsoft.Extensions.Options;
using System.Windows.Input;

namespace GSA.ToolKits.AutomaticDeletionFiles;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly WebView2EnvConfigure _config;
    private IWebWindow<UIElement>? _webWindow;
    private readonly IWebWindowFactory _webWindowFactory;


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <param name="options">WebView2 环境配置选项</param>
    /// <param name="webFactory">浏览器窗口创建工厂</param>
    public MainWindow(IOptions<WebView2EnvConfigure> options, IWebWindowFactory webFactory)
    {
        _config = options.Value;
        _webWindowFactory = webFactory;

        Title = $"自动删除文件（F5 刷新、F12 开发者工具） - {DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
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

                    // 注入主窗体控制器到前端JS对象
                    MainWindowController controller = new(_webWindow.Browser, Dispatcher);
                    _webWindow.Browser.AddControllerToScript(controller);
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

    /// <summary>
    /// 按键弹出事件
    /// </summary>
    /// <param name="sender">传递对象</param>
    /// <param name="e">传递事件</param>
    private void Window_KeyUp(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.F5:
                _webWindow?.Browser?.Reload();
                break;
            case Key.F12:
                _webWindow?.Browser?.OpenDevToolsWindow();
                break;
        }
    }
}