//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：PictureSizeHelper.cs
// 项目名称：PictureCommonHelper
// 创建时间：2024-12-10 16:30:34
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.PictureUtility.Internal;

/// <summary>
/// 图像工具助手类
/// </summary>
internal static class PictureCommonHelper
{
    /// <summary>
    /// 获取图像文件的宽度和高度
    /// </summary>
    /// <param name="imageFileFullPath">图片文件全路径</param>
    /// <returns>图像的宽度和高度</returns>
    public static async Task<Size> GetImageSizeByFileAsync(string imageFileFullPath)
    {
        using Image image = await Image.LoadAsync(imageFileFullPath).ConfigureAwait(false);
        return new Size(image.Width, image.Height);
    }

    /// <summary>
    /// 获取图像流的宽度和高度
    /// </summary>
    /// <param name="imageStream">包含图像的数据流</param>
    /// <returns>图像的宽度和高度</returns>
    public static async Task<Size> GetImageSizeByStreamAsync(Stream imageStream)
    {
        using Image image = await Image.LoadAsync(imageStream).ConfigureAwait(false);
        return new Size(image.Width, image.Height);
    }

    /// <summary>
    /// 根据图片文件扩展名获取图像格式枚举
    /// </summary>
    /// <param name="fileExtension"></param>
    /// <returns>图像格式枚举</returns>
    public static PictureFormat GetPictureFormatWithExtension(string fileExtension)
        => fileExtension.ToLower() switch
        {
            ".jpg" or ".jpeg" => PictureFormat.JPEG,
            ".bmp" => PictureFormat.BMP,
            ".png" => PictureFormat.PNG,
            ".gif" => PictureFormat.GIF,
            ".pbm" => PictureFormat.PBM,
            ".qoi" => PictureFormat.QOI,
            ".tga" => PictureFormat.TGA,
            ".tif" or ".tiff" => PictureFormat.TIFF,
            ".webp" => PictureFormat.WebP,
            _ => PictureFormat.JPEG
        };
}