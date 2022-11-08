//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：DateTimeHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-06-22 17:36:15
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.CommonUtility;

/// <summary>
/// 日期与时间助手类
/// </summary>
public static class DateTimeHelper
{
    private static readonly DateTime _utc1970 = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    private static readonly Dictionary<TimestampType, Func<DateTime, long>> _dictToTimestamp = new(2)
    {
        [TimestampType.TotalSeconds] = time => (long)time.Subtract(_utc1970).TotalSeconds,
        [TimestampType.TotalMilliseconds] = time => (long)time.Subtract(_utc1970).TotalMilliseconds
    };

    private static readonly Dictionary<TimestampType, Func<long, DateTime>> _dictToDateTime = new(2)
    {
        [TimestampType.TotalSeconds] = value => DateTimeOffset.FromUnixTimeSeconds(value).DateTime,
        [TimestampType.TotalMilliseconds] = value => DateTimeOffset.FromUnixTimeMilliseconds(value).DateTime
    };


    /// <summary>
    /// 获取当前系统日期与时间的时间戳（UTC）
    /// </summary>
    /// <remarks>缺省返回-1，表示获取失败。</remarks>
    /// <param name="type">时间戳类型</param>
    /// <returns>时间戳</returns>
    public static long GetTimestamp(TimestampType type = TimestampType.TotalMilliseconds)
        => type switch
        {
            TimestampType.TotalSeconds => DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            TimestampType.TotalMilliseconds => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
            _ => -1
        };

    /// <summary>
    /// 转换指定日期与时间为时间戳
    /// </summary>
    /// <param name="value">需要转换的日期与时间</param>
    /// <param name="type">时间戳类型</param>
    /// <returns>时间戳</returns>
    public static long ConvertToTimestamp(DateTime value, TimestampType type = TimestampType.TotalMilliseconds)
        => _dictToTimestamp[type](value.ToUniversalTime());

    /// <summary>
    /// 转换指定时间戳为日期与时间(请优先使用指定类型方法)
    /// </summary>
    /// <remarks>自动尝试使用“毫秒->秒”的顺序解析，如果均失败则返回最小时间。</remarks>
    /// <param name="value">需要转换的时间戳</param>
    /// <returns>日期与时间</returns>
    public static DateTime TryConvertToDateTime(long value)
    {
        try
        {
            return _dictToDateTime[TimestampType.TotalMilliseconds](value);
        }
        catch
        {
            try
            {
                return _dictToDateTime[TimestampType.TotalSeconds](value);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
    }

    /// <summary>
    /// 转换指定时间戳为日期与时间
    /// </summary>
    /// <param name="value">需要转换的时间戳</param>
    /// <param name="type">时间戳类型</param>
    /// <returns>日期与时间</returns>
    public static DateTime ConvertToDateTime(long value, TimestampType type = TimestampType.TotalMilliseconds)
        => _dictToDateTime[type](value);

    /// <summary>
    /// 转换指定时间戳为表示当前所在的本地的日期与时间
    /// </summary>
    /// <param name="value">需要转换的时间戳</param>
    /// <param name="type">时间戳类型</param>
    /// <returns>本地的日期与时间</returns>
    public static DateTime ConvertToLocalTime(long value, TimestampType type = TimestampType.TotalMilliseconds)
        => ConvertToDateTime(value, type).ToLocalTime();
}


/// <summary>
/// 时间戳类型
/// </summary>
public enum TimestampType
{
    /// <summary>
    /// 总毫秒数
    /// </summary>
    TotalMilliseconds,

    /// <summary>
    /// 总秒数
    /// </summary>
    TotalSeconds
}