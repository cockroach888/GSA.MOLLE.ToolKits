//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：ThumbnailsSquareInfo.cs
// 项目名称：文件操作实用工具集
// 创建时间：2023-05-27 21:20:54
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Drawing.Imaging;

namespace GSA.ToolKits.FileUtility.Entity;

/// <summary>
/// 正方型缩略图裁剪与缩放参数实体类
/// </summary>
public sealed class ThumbnailsSquareInfo
{
    /// <summary>
    /// 需要生成缩略图的源图片文件全路径
    /// </summary>
    public string? SourceFullPath { get; set; }

    /// <summary>
    /// 缩略图保存路径
    /// </summary>
    public string? SaveFilePath { get; set; }

    /// <summary>
    /// 缩略图保存文件名
    /// </summary>
    public string? SaveFileName { get; set; }

    /// <summary>
    /// 正方形缩略图的边长
    /// </summary>
    public int SideValue { get; set; }

    /// <summary>
    /// 图片生成质量 (范围0-100)
    /// </summary>
    public byte QualityValue { get; set; }

    /// <summary>
    /// 文件保存类型
    /// </summary>
    public ImageFormat SaveFormat { get; set; } = ImageFormat.Jpeg;
}