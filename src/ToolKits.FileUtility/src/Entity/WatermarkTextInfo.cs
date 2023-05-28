//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：WatermarkTextInfo.cs
// 项目名称：文件操作实用工具集
// 创建时间：2023-05-28 12:52:30
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Drawing;

namespace GSA.ToolKits.FileUtility.Entity;

/// <summary>
/// 图片附加文本水印参数实体类
/// </summary>
[Serializable]
public sealed class WatermarkTextInfo
{
    /// <summary>
    /// 源图片文件全路径
    /// </summary>
    public string? SourceFullPath { get; set; }

    /// <summary>
    /// 字体名称
    /// </summary>
    public string? FamilyName { get; set; }

    /// <summary>
    /// 字体大小
    /// </summary>
    public int FontSize { get; set; }

    /// <summary>
    /// 字体颜色
    /// </summary>
    public Color FontColor { get; set; }

    /// <summary>
    /// 水印文本
    /// </summary>
    public string WatermarkText { get; set; } = string.Empty;

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