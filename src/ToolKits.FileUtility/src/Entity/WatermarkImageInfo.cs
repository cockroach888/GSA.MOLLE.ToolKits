//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：WatermarkImageInfo.cs
// 项目名称：文件操作实用工具集
// 创建时间：2023-05-28 11:40:47
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.FileUtility.Entity;

/// <summary>
/// 图片附加图片水印参数实体类
/// </summary>
public sealed class WatermarkImageInfo
{
    /// <summary>
    /// 源图片文件全路径
    /// </summary>
    public string? SourceFullPath { get; set; }

    /// <summary>
    /// 水印图片文件全路径
    /// </summary>
    public string? WaterFullPath { get; set; }

    /// <summary>
    /// 保存路径
    /// </summary>
    public string? SaveFilePath { get; set; }

    /// <summary>
    /// 保存文件名
    /// </summary>
    public string? SaveFileName { get; set; }

    /// <summary>
    /// 水印位置
    /// </summary>
    public WatermarkLocation Location { get; set; } = WatermarkLocation.RB;
}