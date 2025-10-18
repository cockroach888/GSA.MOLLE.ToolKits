//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：PictureHelper.cs
// 项目名称：图像辅助与应用工具集
// 创建时间：2023-12-10 15:41:55
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.PictureUtility.Internal;

namespace GSA.ToolKits.PictureUtility;

/// <summary>
/// 图像辅助操作与处理助手类
/// </summary>
public static class PictureHelper
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
        => await PictureCroppingHelper.GetImageThumbnailAsync(imageFileFullPath, thumbWidth, thumbHeight, imageFormat).ConfigureAwait(false);

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
        => await PictureCroppingHelper.GetImageThumbnailAsync(imageStream, thumbWidth, thumbHeight, imageFormat).ConfigureAwait(false);

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
        => await PictureCroppingHelper.GetImageThumbnailAsync(image, thumbWidth, thumbHeight, imageFormat).ConfigureAwait(false);



    /// <summary>
    /// 获取图像文件的宽度和高度
    /// </summary>
    /// <param name="imageFileFullPath">图片文件全路径</param>
    /// <returns>图像的宽度和高度</returns>
    public static async Task<Size> GetImageSizeByFileAsync(string imageFileFullPath)
        => await PictureCommonHelper.GetImageSizeByFileAsync(imageFileFullPath).ConfigureAwait(false);

    /// <summary>
    /// 获取图像流的宽度和高度
    /// </summary>
    /// <param name="imageStream">包含图像的数据流</param>
    /// <returns>图像的宽度和高度</returns>
    public static async Task<Size> GetImageSizeByStreamAsync(Stream imageStream)
        => await PictureCommonHelper.GetImageSizeByStreamAsync(imageStream).ConfigureAwait(false);

    /// <summary>
    /// 获取图像文件的宽度和高度
    /// </summary>
    /// <param name="imageFileFullPath">图片文件全路径</param>
    /// <returns>图像的宽度和高度</returns>
    public static async Task<(int width, int height)> GetImageSizeByFileToTupleAsync(string imageFileFullPath)
        => await PictureCommonHelper.GetImageSizeByFileToTupleAsync(imageFileFullPath).ConfigureAwait(false);

    /// <summary>
    /// 获取图像流的宽度和高度
    /// </summary>
    /// <param name="imageStream">包含图像的数据流</param>
    /// <returns>图像的宽度和高度</returns>
    public static async Task<(int width, int height)> GetImageSizeByStreamToTupleAsync(Stream imageStream)
        => await PictureCommonHelper.GetImageSizeByStreamToTupleAsync(imageStream).ConfigureAwait(false);

    /// <summary>
    /// 根据图片文件扩展名获取图像格式枚举
    /// </summary>
    /// <param name="fileExtension"></param>
    /// <returns>图像格式枚举</returns>
    public static PictureFormat GetPictureFormatWithExtension(string fileExtension)
        => PictureCommonHelper.GetPictureFormatWithExtension(fileExtension);

    /// <summary>
    /// 根据图片文件扩展名获取图像MimeType枚举
    /// </summary>
    /// <param name="fileExtension">图像文件扩展名</param>
    /// <returns>图像MimeType枚举</returns>
    public static string GetMimeTypeWithExtension(string fileExtension)
        => PictureCommonHelper.GetMimeTypeWithExtension(fileExtension);



    /// <summary>
    /// 将包含前缀的Base64字符串转换为图像
    /// </summary>
    /// <remarks>例如：data:image/png;base64,</remarks>
    /// <param name="base64String">包含前缀的Base64字符串</param>
    /// <returns>图像对象 (外部使用完后必须释放)</returns>
    public static async Task<Image> ImageFromBase64Async(string base64String)
        => await PictureBase64Helper.ImageFromBase64Async(base64String).ConfigureAwait(false);

    /// <summary>
    /// 将不包含前缀的Base64字符串转换为图像
    /// </summary>
    /// <param name="base64String">不包含前缀的Base64字符串</param>
    /// <returns>图像对象 (外部使用完后必须释放)</returns>
    public static async Task<Image> ImageFromBase64WithoutPrefixAsync(string base64String)
        => await PictureBase64Helper.ImageFromBase64WithoutPrefixAsync(base64String).ConfigureAwait(false);

    /// <summary>
    /// 将包含前缀的Base64字符串转换为内存流
    /// </summary>
    /// <param name="base64String">包含前缀的Base64字符串</param>
    /// <returns>图像内存流对象 (外部使用完后必须释放)</returns>
    public static async Task<Stream> StreamFromBase64Async(string base64String)
        => await PictureBase64Helper.StreamFromBase64Async(base64String).ConfigureAwait(false);

    /// <summary>
    /// 将不包含前缀的Base64字符串转换为内存流
    /// </summary>
    /// <param name="base64String">不包含前缀的Base64字符串</param>
    /// <returns>图像内存流对象 (外部使用完后必须释放)</returns>
    public static async Task<Stream> StreamFromBase64WithoutPrefixAsync(string base64String)
        => await PictureBase64Helper.StreamFromBase64WithoutPrefixAsync(base64String).ConfigureAwait(false);



    /// <summary>
    /// 将包含前缀的Base64字符串转存储到指定路径下的图像文件
    /// </summary>
    /// <para>当存储目标文件存在时，将会在保存时自动覆盖。</para>
    /// <para>当图像格式为空时，自动从保存路径的扩展名识别。</para>
    /// <param name="base64String">包含前缀的Base64字符串</param>
    /// <param name="saveFullPath">保存图像的绝对路径</param>
    /// <param name="imageFormat">图像格式</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public static async Task SaveImageFromBase64Async(string base64String, string saveFullPath, PictureFormat? imageFormat = null)
        => await PictureSaveHelper.SaveImageFromBase64Async(base64String, saveFullPath, imageFormat).ConfigureAwait(false);

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
        => await PictureSaveHelper.SaveImageFromBase64WithoutPrefixAsync(base64String, saveFullPath, imageFormat).ConfigureAwait(false);



    /// <summary>
    /// 将包含图像的数据流存储到指定路径下的图像文件
    /// </summary>
    /// <remarks>当图像格式为空时，自动从保存路径的扩展名识别。</remarks>
    /// <param name="imageStream">包含图像的数据流</param>
    /// <param name="saveFullPath">保存图像的绝对路径</param>
    /// <param name="imageFormat">图像格式</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public static async Task SaveImageFromStreamAsync(Stream imageStream, string saveFullPath, PictureFormat? imageFormat = null)
        => await PictureSaveHelper.SaveImageFromStreamAsync(imageStream, saveFullPath, imageFormat).ConfigureAwait(false);



    /// <summary>
    /// 将图像对象以指定的格式存储到指定位置
    /// </summary>
    /// <remarks>当图像格式为空时，自动从保存路径的扩展名识别。</remarks>
    /// <param name="imageSource">图像源</param>
    /// <param name="saveFullPath">保存路径</param>
    /// <param name="imageFormat">图像格式</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public static async Task SaveImageToFileFromImageAsync(Image imageSource, string saveFullPath, PictureFormat? imageFormat = null)
        => await PictureSaveHelper.SaveImageToFileFromImageAsync(imageSource, saveFullPath, imageFormat).ConfigureAwait(false);

    /// <summary>
    /// 将图像对象以指定的格式存储到指定图像流
    /// </summary>
    /// <remarks>默认为JPEG格式</remarks>
    /// <param name="imageSource">图像源</param>
    /// <param name="imageFormat">图像格式</param>
    /// <returns>图像流</returns>
    public static async Task<Stream> SaveImageToStreamFromImageAsync(Image imageSource, PictureFormat imageFormat = PictureFormat.JPEG)
        => await PictureSaveHelper.SaveImageToStreamFromImageAsync(imageSource, imageFormat).ConfigureAwait(false);
}