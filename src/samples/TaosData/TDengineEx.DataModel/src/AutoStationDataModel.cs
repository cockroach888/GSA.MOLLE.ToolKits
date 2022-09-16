//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：AutoStationDataModel.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-09-16 11:12:51
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace TDengineEx.DataModel;

/// <summary>
/// 气象自动站数据实体类
/// </summary>
[Serializable]
public sealed class AutoStationDataModel
{
    /// <summary>
    /// 时间戳
    /// </summary>
    /// <remarks>TDengine 数据库首列必须为时间戳</remarks>
    [JsonIgnore]
    [Column("tss")]
    public DateTime Tss { get; set; }

    /// <summary>
    /// 自动站编号
    /// </summary>
    [BuildInsertSqlStringIgnore]
    [Column("station_id")]
    public string? StationId { get; set; }

    /// <summary>
    /// 上报时间
    /// </summary>
    [Column("report_time")]
    public DateTime ReportTime { get; set; }

    /// <summary>
    /// 温度
    /// </summary>
    [Column("temperature")]
    public float Temperature { get; set; }

    /// <summary>
    /// 本站气压
    /// </summary>
    [Column("air_pressure")]
    public float AirPressure { get; set; }

    /// <summary>
    /// 相对湿度
    /// </summary>
    [Column("relative_humidity")]
    public float RelativeHumidity { get; set; }

    /// <summary>
    /// 最大风速
    /// </summary>
    [Column("maximum_wind_speed")]
    public float MaximumWindSpeed { get; set; }

    /// <summary>
    /// 降雨量
    /// </summary>
    [Column("rainfall")]
    public float Rainfall { get; set; }
}