//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：ThumbnailsGeneralInfo.cs
// 项目名称：文件操作实用工具集
// 创建时间：2023-05-26 22:52:03
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
/// 普通缩略图生成模式参数实体类
/// </summary>
[Serializable]
public sealed class ThumbnailsGeneralInfo
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
    /// 缩略图宽度
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// 缩略图高度
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// 缩略图生成模式
    /// </summary>
    public ThumbnailsMode Mode { get; set; } = ThumbnailsMode.Cut;

    /// <summary>
    /// 文件保存类型
    /// </summary>
    public ImageFormat SaveFormat { get; set; } = ImageFormat.Jpeg;
}