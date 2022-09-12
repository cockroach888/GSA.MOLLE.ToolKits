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
namespace GSA.ToolKits.DBUtility.TDengine;

/// <summary>
/// TDengine RESTful API 连接器接口
/// </summary>
public interface ITDengineConnector
{
    /// <summary>
    /// TDengine 选项参数
    /// </summary>
    TDengineOptions Options { get; }


    /// <summary>
    /// 执行 RESTful API 请求，并返回请求结果的泛型对象。
    /// </summary>
    /// <typeparam name="TRequestResult">用于序列化请求结果的泛型</typeparam>
    /// <param name="param">通用查询参数</param>
    /// <returns>请求结果泛型对象</returns>
    ValueTask<TRequestResult?> ExecuteAsync<TRequestResult>(TDengineQueryParam param)
        where TRequestResult : class, new();

    /// <summary>
    /// 执行 RESTful API 请求，并返回请求结果的原始字符串。
    /// </summary>
    /// <remarks>返回原始的字符串请求结果</remarks>
    /// <param name="param">通用查询参数</param>
    /// <returns>请求结果原始字符串</returns>
    ValueTask<string?> ExecuteAsync(TDengineQueryParam param);
}