//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：PictureCroppingHelper.cs
// 项目名称：图像辅助与应用工具集
// 创建时间：2024-12-10 16:30:19
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using SixLabors.ImageSharp.Processing;

namespace GSA.ToolKits.PictureUtility.Internal;

/// <summary>
/// 图像裁剪助手类
/// </summary>
internal static class PictureCroppingHelper
{
    /// <summary>
    /// 获取图片文件指定宽高的等比缩略图
    /// </summary>
    /// <remarks>当图像格式为空时，自动从保存路径的扩展名识别。</remarks>
    /// <param name="imageFileFullPath">图片文件全路径</param>
    /// <param name="thumbWidth">缩略图宽度</param>
    /// <param name="thumbHeight">缩略图高度</param>
    /// <param name="imageFormat">图像格式</param>
    /// <returns>缩略图内存流</returns>
    public static async Task<Stream> GetImageThumbnailAsync(string imageFileFullPath, int thumbWidth, int thumbHeight, PictureFormat? imageFormat = null)
    {
        PictureFormat format = imageFormat ?? PictureCommonHelper.GetPictureFormatWithExtension(Path.GetExtension(imageFileFullPath));
        using Image image = await Image.LoadAsync(imageFileFullPath).ConfigureAwait(false);
        return await GetImageThumbnailAsync(image, thumbWidth, thumbHeight, format).ConfigureAwait(false);
    }

    /// <summary>
    /// 获取图像流指定宽高的等比缩略图
    /// </summary>
    /// <remarks>默认为JPEG格式</remarks>
    /// <param name="imageStream">图像流</param>
    /// <param name="thumbWidth">缩略图宽度</param>
    /// <param name="thumbHeight">缩略图高度</param>
    /// <param name="imageFormat">图像格式</param>
    /// <returns>缩略图内存流</returns>
    public static async Task<Stream> GetImageThumbnailAsync(Stream imageStream, int thumbWidth, int thumbHeight, PictureFormat imageFormat = PictureFormat.JPEG)
    {
        using Image image = await Image.LoadAsync(imageStream).ConfigureAwait(false);
        return await GetImageThumbnailAsync(image, thumbWidth, thumbHeight, imageFormat).ConfigureAwait(false);
    }

    /// <summary>
    /// 获取图像源指定宽高的等比缩略图
    /// </summary>
    /// <remarks>默认为JPEG格式</remarks>
    /// <param name="image">图像源</param>
    /// <param name="thumbWidth">缩略图宽度</param>
    /// <param name="thumbHeight">缩略图高度</param>
    /// <param name="imageFormat">图像格式</param>
    /// <returns>缩略图内存流</returns>
    public static async Task<Stream> GetImageThumbnailAsync(Image image, int thumbWidth, int thumbHeight, PictureFormat imageFormat = PictureFormat.JPEG)
    {
        image.Mutate(x => x.Resize(thumbWidth, thumbHeight));
        return await PictureSaveHelper.SaveImageToStreamFromImageAsync(image, imageFormat).ConfigureAwait(false);
    }
}