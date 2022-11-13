//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：ICockroachService.cs
// 项目名称：魂哥常用工具集
// 创建时间：2021-02-28 20:05:33
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.CockroachContainer;

/// <summary>
/// 自定义服务(伪IOC)容器接口
/// </summary>
public interface ICockroachService : IDisposable
{
    /// <summary>
    /// 服务注册
    /// </summary>
    /// <remarks>当为同一泛型对象注册多个服务时，可通过关键字予以快速识别。</remarks>
    /// <typeparam name="TService">服务泛型</typeparam>
    /// <param name="service">需要注册的服务</param>
    /// <param name="keyword">关键字(缺省 default)</param>
    void Register<TService>(TService service, string keyword = "default")
        where TService : class;

    /// <summary>
    /// 服务反注册
    /// </summary>
    /// <typeparam name="TService">服务泛型</typeparam>
    /// <param name="keyword">关键字(缺省 default)</param>
    /// <returns>注册的服务</returns>
    TService? UnRegister<TService>(string keyword = "default")
        where TService : class;

    /// <summary>
    /// 服务获取
    /// </summary>
    /// <typeparam name="TService">服务泛型</typeparam>
    /// <param name="keyword">关键字(缺省 default)</param>
    /// <returns>获取的服务</returns>
    TService? GetService<TService>(string keyword = "default")
        where TService : class;
}