//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：PictureSaveHelper.cs
// 项目名称：图像辅助与应用工具集
// 创建时间：2024-12-10 16:28:30
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
/// 图像保存助手类
/// </summary>
internal static class PictureSaveHelper
{
    /// <summary>
    /// 将包含前缀的Base64字符串转存储到指定路径下的图像文件
    /// </summary>
    /// <remarks>
    /// <para>当存储目标文件存在时，将会在保存时自动覆盖。</para>
    /// <para>当图像格式为空时，自动从保存路径的扩展名识别。</para>
    /// </remarks>
    /// <param name="base64String">包含前缀的Base64字符串</param>
    /// <param name="saveFullPath">保存图像的绝对路径</param>
    /// <param name="imageFormat">图像格式</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public static async Task SaveImageFromBase64Async(string base64String, string saveFullPath, PictureFormat? imageFormat = null)
    {
        PictureFormat format = imageFormat ?? PictureCommonHelper.GetPictureFormatWithExtension(Path.GetExtension(saveFullPath));
        using Image image = await PictureBase64Helper.ImageFromBase64Async(base64String).ConfigureAwait(false);
        await SaveImageToFileFromImageAsync(image, saveFullPath, format).ConfigureAwait(false);
    }

    /// <summary>
    /// 将不包含前缀的Base64字符串存储到指定路径下的图像文件
    /// </summary>
    /// <remarks>
    /// <para>当存储目标文件存在时，将会在保存时自动覆盖。</para>
    /// <para>当图像格式为空时，自动从保存路径的扩展名识别。</para>
    /// </remarks>
    /// <param name="base64String">不包含前缀的Base64字符串</param>
    /// <param name="saveFullPath">保存图像的绝对路径</param>
    /// <param name="imageFormat">图像格式</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public static async Task SaveImageFromBase64WithoutPrefixAsync(string base64String, string saveFullPath, PictureFormat? imageFormat = null)
    {
        PictureFormat format = imageFormat ?? PictureCommonHelper.GetPictureFormatWithExtension(Path.GetExtension(saveFullPath));
        using Image image = await PictureBase64Helper.ImageFromBase64WithoutPrefixAsync(base64String).ConfigureAwait(false);
        await SaveImageToFileFromImageAsync(image, saveFullPath, format).ConfigureAwait(false);
    }


    /// <summary>
    /// 将包含图像的数据流存储到指定路径下的图像文件
    /// </summary>
    /// <remarks>当图像格式为空时，自动从保存路径的扩展名识别。</remarks>
    /// <param name="imageStream">包含图像的数据流</param>
    /// <param name="saveFullPath">保存图像的绝对路径</param>
    /// <param name="imageFormat">图像格式</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public static async Task SaveImageFromStreamAsync(Stream imageStream, string saveFullPath, PictureFormat? imageFormat = null)
    {
        PictureFormat format = imageFormat ?? PictureCommonHelper.GetPictureFormatWithExtension(Path.GetExtension(saveFullPath));
        using Image image = await Image.LoadAsync(imageStream).ConfigureAwait(false);
        await SaveImageToFileFromImageAsync(image, saveFullPath, format).ConfigureAwait(false);
    }


    /// <summary>
    /// 将图像对象以指定的格式存储到指定位置
    /// </summary>
    /// <remarks>当图像格式为空时，自动从保存路径的扩展名识别。</remarks>
    /// <param name="imageSource">图像源</param>
    /// <param name="saveFullPath">保存路径</param>
    /// <param name="imageFormat">图像格式</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public static async Task SaveImageToFileFromImageAsync(Image imageSource, string saveFullPath, PictureFormat? imageFormat)
    {
        PictureFormat format = imageFormat ?? PictureCommonHelper.GetPictureFormatWithExtension(Path.GetExtension(saveFullPath));
        switch (format)
        {
            case PictureFormat.JPEG:
                await imageSource.SaveAsJpegAsync(saveFullPath).ConfigureAwait(false);
                break;
            case PictureFormat.BMP:
                await imageSource.SaveAsBmpAsync(saveFullPath).ConfigureAwait(false);
                break;
            case PictureFormat.PNG:
                await imageSource.SaveAsPngAsync(saveFullPath).ConfigureAwait(false);
                break;
            case PictureFormat.GIF:
                await imageSource.SaveAsGifAsync(saveFullPath).ConfigureAwait(false);
                break;
            case PictureFormat.PBM:
                await imageSource.SaveAsPbmAsync(saveFullPath).ConfigureAwait(false);
                break;
            case PictureFormat.QOI:
                await imageSource.SaveAsQoiAsync(saveFullPath).ConfigureAwait(false);
                break;
            case PictureFormat.TGA:
                await imageSource.SaveAsTgaAsync(saveFullPath).ConfigureAwait(false);
                break;
            case PictureFormat.TIFF:
                await imageSource.SaveAsTiffAsync(saveFullPath).ConfigureAwait(false);
                break;
            case PictureFormat.WebP:
                await imageSource.SaveAsWebpAsync(saveFullPath).ConfigureAwait(false);
                break;
            default:
                await imageSource.SaveAsJpegAsync(saveFullPath).ConfigureAwait(false);
                break;
        }
    }

    /// <summary>
    /// 将图像对象以指定的格式存储到指定图像流
    /// </summary>
    /// <remarks>默认为JPEG格式</remarks>
    /// <param name="imageSource">图像源</param>
    /// <param name="imageFormat">图像格式</param>
    /// <returns>图像流</returns>
    public static async Task<Stream> SaveImageToStreamFromImageAsync(Image imageSource, PictureFormat imageFormat = PictureFormat.JPEG)
    {
        MemoryStream imageStream = new();
        switch (imageFormat)
        {
            case PictureFormat.JPEG:
                await imageSource.SaveAsJpegAsync(imageStream).ConfigureAwait(false);
                break;
            case PictureFormat.BMP:
                await imageSource.SaveAsBmpAsync(imageStream).ConfigureAwait(false);
                break;
            case PictureFormat.PNG:
                await imageSource.SaveAsPngAsync(imageStream).ConfigureAwait(false);
                break;
            case PictureFormat.GIF:
                await imageSource.SaveAsGifAsync(imageStream).ConfigureAwait(false);
                break;
            case PictureFormat.PBM:
                await imageSource.SaveAsPbmAsync(imageStream).ConfigureAwait(false);
                break;
            case PictureFormat.QOI:
                await imageSource.SaveAsQoiAsync(imageStream).ConfigureAwait(false);
                break;
            case PictureFormat.TGA:
                await imageSource.SaveAsTgaAsync(imageStream).ConfigureAwait(false);
                break;
            case PictureFormat.TIFF:
                await imageSource.SaveAsTiffAsync(imageStream).ConfigureAwait(false);
                break;
            case PictureFormat.WebP:
                await imageSource.SaveAsWebpAsync(imageStream).ConfigureAwait(false);
                break;
            default:
                await imageSource.SaveAsJpegAsync(imageStream).ConfigureAwait(false);
                break;
        }
        imageStream.Position = 0;

        return imageStream;
    }
}