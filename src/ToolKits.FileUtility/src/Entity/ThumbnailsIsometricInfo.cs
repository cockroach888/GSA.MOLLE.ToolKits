//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：ThumbnailsIsometricInfo.cs
// 项目名称：魂哥常用工具集
// 创建时间：2023-05-27 22:55:35
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
/// 按等比生成缩略图与图片水印参数实体类
/// </summary>
[Serializable]
public sealed class ThumbnailsIsometricInfo
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
    /// 缩略图最大宽度
    /// </summary>
    public int MaxWidth { get; set; }

    /// <summary>
    /// 缩略图最大高度
    /// </summary>
    public int MaxHeight { get; set; }

    /// <summary>
    /// 水印文字 (为空表示不使用水印)
    /// </summary>
    public string? WatermarkText { get; set; }

    /// <summary>
    /// 水印图片全路径 (为空表示不使用水印)
    /// </summary>
    public string? WatermarkImage { get; set; }

    /// <summary>
    /// 文件保存类型
    /// </summary>
    public ImageFormat SaveFormat { get; set; } = ImageFormat.Jpeg;
}