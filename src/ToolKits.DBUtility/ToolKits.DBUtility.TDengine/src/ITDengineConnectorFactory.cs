//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：ITDengineConnectorFactory.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-06-22 22:23:50
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.DBUtility.TDengine;

/// <summary>
/// TDengine RESTful API 连接器创建工厂接口
/// </summary>
public interface ITDengineConnectorFactory
{
    /// <summary>
    /// 创建 TDengine RESTful API 连接器实例
    /// </summary>
    /// <remarks>创建实例时使用的选项参数，将使用选项模式所匹配的配置。</remarks>
    /// <param name="oldConnector">旧的连接器实例，如果不存在可传null值。</param>
    /// <returns>TDengine RESTful API 连接器</returns>
    ITDengineConnector Create(ITDengineConnector? oldConnector = default);

    /// <summary>
    /// 创建 TDengine RESTful API 连接器实例
    /// </summary>
    /// <param name="options">选项参数</param>
    /// <param name="oldConnector">旧的连接器实例，如果不存在可传null值。</param>
    /// <returns>TDengine RESTful API 连接器</returns>
    ITDengineConnector Create(TDengineOptions options, ITDengineConnector? oldConnector = default);
}