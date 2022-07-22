//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineParameters.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-07-22 11:19:13
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
/// TDengine执行参数类
/// </summary>
[Serializable]
public sealed class TDengineParameters
{
    /// <summary>
    /// TDengine执行参数
    /// </summary>
    /// <param name="sqlString">需要执行的SQL字符串</param>
    public TDengineParameters(string sqlString)
    {
        SqlString = sqlString;
    }

    /// <summary>
    /// 需要执行的SQL字符串
    /// </summary>
    public string SqlString { get; set; }

    /// <summary>
    /// 数据库名称（如果需要指定数据库执行时）
    /// </summary>
    /// <remarks>缺省值为 null</remarks>
    public string? DBName { get; set; } = null;

    /// <summary>
    /// 取消令牌
    /// </summary>
    /// <remarks>缺省值为 default</remarks>
    public CancellationToken Token { get; set; } = default;


    /// <summary>
    /// 实例化一个新的TDengine执行参数
    /// </summary>
    /// <param name="sqlString">需要执行的SQL字符串</param>
    /// <returns>TDengine执行参数</returns>
    public static TDengineParameters New(string sqlString) => new(sqlString);
}