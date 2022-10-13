//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineConnectorFactory.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-06-22 22:22:18
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
using System.Collections.Concurrent;

namespace GSA.ToolKits.DBUtility.TDengine;

/// <summary>
/// TDengine RESTful API 连接器创建工厂类
/// </summary>
internal sealed class TDengineConnectorFactory : ITDengineConnectorFactory, IAsyncDisposable
{
    private readonly ConcurrentDictionary<int, TDengineConnector> _connectors = new();
    private readonly TDengineOptions _options;


    /// <summary>
    /// TDengine RESTful API 连接器创建工厂
    /// </summary>
    /// <param name="options">选项参数</param>
    public TDengineConnectorFactory(IOptions<TDengineOptions> options)
    {
        _options = options.Value;
    }


    #region 接口实现[ITDengineConnectorFactory]

    /// <summary>
    /// 创建 TDengine RESTful API 连接器实例
    /// </summary>
    /// <remarks>创建实例时使用的选项参数，将使用选项模式所匹配的配置。</remarks>
    /// <param name="oldConnector">旧的连接器实例，如果不存在可传null值。</param>
    /// <returns>TDengine RESTful API 连接器</returns>
    public ITDengineConnector Create(ITDengineConnector? oldConnector = default)
    {
        TryRemove(oldConnector);

        TDengineConnector connector = new(_options);
        _connectors[connector.Id] = connector;

        return connector;
    }

    /// <summary>
    /// 创建 TDengine RESTful API 连接器实例
    /// </summary>
    /// <param name="options">选项参数</param>
    /// <param name="oldConnector">旧的连接器实例，如果不存在可传null值。</param>
    /// <returns>TDengine RESTful API 连接器</returns>
    public ITDengineConnector Create(TDengineOptions options, ITDengineConnector? oldConnector = default)
    {
        TryRemove(oldConnector);

        TDengineConnector connector = new(options);
        _connectors[connector.Id] = connector;

        return connector;
    }

    #endregion


    /// <summary>
    /// 尝试移除所匹配的连接器实例
    /// </summary>
    /// <param name="connector">TDengine RESTful API 连接器</param>
    private void TryRemove(ITDengineConnector? connector)
    {
        if (connector is TDengineConnector conn)
        {
            if (_connectors.TryRemove(conn.Id, out _))
            {
                using (conn) { }
            }
        }
    }

    /// <summary>
    /// 资源释放
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async Task DisposeAsync()
    {
        await Task.Delay(0).ConfigureAwait(false);

        foreach (TDengineConnector connector in _connectors.Values)
        {
            using (connector) { }
        }

        _connectors.Clear();
    }
}