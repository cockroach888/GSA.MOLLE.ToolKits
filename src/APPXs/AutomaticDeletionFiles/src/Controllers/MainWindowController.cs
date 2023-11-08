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
[ClassInterface(ClassInterfaceType.AutoDual)]
[ComVisible(true)]
public sealed class MainWindowController : IWebController
{
    private Dispatcher? _dispatcher;


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
        => _dispatcher = dispatcher;


    /// <summary>
    /// 无线电求救信号
    /// </summary>
    /// <remarks>船只或飞机遇险时用的</remarks>
    /// <param name="strMessage">求救内容</param>
    public void MaydayMaydayMayday(string strMessage)
    {
        _ = _dispatcher?.BeginInvoke((string msg) =>
        {
            MessageBox.Show(msg, "系统提示", MessageBoxButton.OK, MessageBoxImage.Information);
        }, strMessage);
    }
}