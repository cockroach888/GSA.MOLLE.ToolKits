//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：ITDengineConnector.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-06-22 22:20:02
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.DBUtility.TDengine.Entity;

namespace GSA.ToolKits.DBUtility.TDengine;

/// <summary>
/// TDengine RESTful API 连接器接口
/// </summary>
/// <remarks>友情提示：请务必调整taosAdapter的默认日志级别，以避免高速入库时，因控制台日志过频导致影响效率。</remarks>
public interface ITDengineConnector
{
    /// <summary>
    /// 执行指定SQL语句
    /// </summary>
    /// <remarks>返回传递的泛型对象</remarks>
    /// <typeparam name="T">用于返回结果使用的泛型</typeparam>
    /// <param name="param">通用查询参数</param>
    /// <returns>泛型对象</returns>
    Task<T?> ExecutionAsync<T>(TDengineQueryParam param)
        where T : class, new();

    /// <summary>
    /// 执行指定SQL语句
    /// </summary>
    /// <remarks>返回原始的字符串请求结果</remarks>
    /// <param name="param">通用查询参数</param>
    /// <returns>字符串请求结果</returns>
    Task<string?> ExecutionAsync(TDengineQueryParam param);
}