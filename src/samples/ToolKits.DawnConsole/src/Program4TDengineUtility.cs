//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：Program4TDengineUtility.cs
// 项目名称：功能调测控制台程序
// 创建时间：2023-08-13 21:12:34
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.DBUtility.TDengine;

namespace GSA.ToolKits.DawnConsole;

/// <summary>
/// TDengineUtility
/// </summary>
internal sealed class Program4TDengineUtility
{

    #region 单例模式

    private static readonly Lazy<Program4TDengineUtility> _lazyInstance = new(() => new Program4TDengineUtility());

    /// <summary>
    /// TDengineUtility
    /// </summary>
    internal static Program4TDengineUtility Default => _lazyInstance.Value;

    #endregion

    /// <summary>
    /// 小心手雷，洞中开火。
    /// </summary>
    /// <remarks>TDengine 相关测试</remarks>
    public void FireInTheHole()
    {
        string originSqlString = "select * from db_detection.check_records where 1<>1";
        Console.WriteLine($"原始的SQL字符串：{originSqlString}");

        string sqlString = TDengineCommons.SlidingTimeWindowJoinToSqlString(originSqlString, "10m");
        Console.WriteLine($"仅时间阈值的SQL字符串：{sqlString}");

        sqlString = TDengineCommons.SlidingTimeWindowJoinToSqlString(originSqlString, "10m", strSliding: "5m");
        Console.WriteLine($"包含时间阈值和滑动时间的SQL字符串：{sqlString}");

        sqlString = TDengineCommons.SlidingTimeWindowJoinToSqlString(originSqlString, "10m", strOffset: "2m");
        Console.WriteLine($"包含时间阈值和偏移量的SQL字符串：{sqlString}");

        sqlString = TDengineCommons.SlidingTimeWindowJoinToSqlString(originSqlString, "10m", strSliding: "5m", strOffset: "1m");
        Console.WriteLine($"包含时间阈值、滑动时间、偏移量的SQL字符串：{sqlString}");

        sqlString = TDengineCommons.FlipTimeWindowJoinToSqlString(originSqlString, "30m");
        Console.WriteLine($"翻转时间窗口的SQL字符串：{sqlString}");
    }
}