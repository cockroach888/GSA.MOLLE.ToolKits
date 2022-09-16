//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：AutoStationModel.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-09-16 11:12:39
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
/// 气象自动站信息实体类
/// </summary>
[Serializable]
public sealed class AutoStationModel
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
    [Column("station_id")]
    public string? StationId { get; set; }

    /// <summary>
    /// 自动站名称
    /// </summary>
    [Column("station_name")]
    public string? StationName { get; set; }

    /// <summary>
    /// 自动站纬度
    /// </summary>
    [Column("latitude")]
    public float Latitude { get; set; }

    /// <summary>
    /// 自动站经度
    /// </summary>
    [Column("longitude")]
    public float Longitude { get; set; }

    /// <summary>
    /// 自动站高度
    /// </summary>
    [Column("altitude")]
    public float Altitude { get; set; }

    /// <summary>
    /// 自动站级别
    /// </summary>
    [Column("level")]
    public short Level { get; set; }
}