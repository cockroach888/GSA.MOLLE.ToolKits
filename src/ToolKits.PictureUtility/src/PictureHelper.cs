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
using SixLabors.ImageSharp;

namespace GSA.ToolKits.PictureUtility;

/// <summary>
/// 图像辅助操作与处理助手类
/// </summary>
public static class PictureHelper
{
    /// <summary>
    /// 将包含前缀的Base64字符串转换为图像
    /// </summary>
    /// <remarks>例如：data:image/png;base64,</remarks>
    /// <param name="base64String">包含前缀的Base64字符串</param>
    /// <returns>图像对象 (外部使用完后必须释放)</returns>
    public static async Task<Image> ImageFromBase64Async(string base64String)
    {
        int index = base64String.IndexOf(',');

        if (index > 0)
        {
            base64String = base64String.Remove(0, index + 1);
        }

        return await ImageFromBase64WithoutPrefixAsync(base64String).ConfigureAwait(false);
    }

    /// <summary>
    /// 将不包含前缀的Base64字符串转换为图像
    /// </summary>
    /// <param name="base64String">不包含前缀的Base64字符串</param>
    /// <returns>图像对象 (外部使用完后必须释放)</returns>
    public static async Task<Image> ImageFromBase64WithoutPrefixAsync(string base64String)
    {
        byte[] buffer = Convert.FromBase64String(base64String);
        using MemoryStream ms = new(buffer);
        return await Image.LoadAsync(ms).ConfigureAwait(false);
    }


    /// <summary>
    /// 将包含前缀的Base64字符串转存储到指定路径下的图像文件
    /// </summary>
    /// <remarks>当存储目标文件存在时，将会在保存时自动覆盖。</remarks>
    /// <param name="base64String">包含前缀的Base64字符串</param>
    /// <param name="saveFullPath">保存图像的绝对路径</param>
    /// <param name="imageFormat">图像格式</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public static async Task SaveImageFromBase64Async(string base64String, string saveFullPath, PictureFormat imageFormat)
    {
        using Image image = await ImageFromBase64Async(base64String).ConfigureAwait(false);
        await SavePictureOfFormatType(image, saveFullPath, imageFormat).ConfigureAwait(false);
    }

    /// <summary>
    /// 将不包含前缀的Base64字符串存储到指定路径下的图像文件
    /// </summary>
    /// <remarks>当存储目标文件存在时，将会在保存时自动覆盖。</remarks>
    /// <param name="base64String">不包含前缀的Base64字符串</param>
    /// <param name="saveFullPath">保存图像的绝对路径</param>
    /// <param name="imageFormat">图像格式</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public static async Task SaveImageFromBase64WithoutPrefixAsync(string base64String, string saveFullPath, PictureFormat imageFormat)
    {
        using Image image = await ImageFromBase64WithoutPrefixAsync(base64String).ConfigureAwait(false);
        await SavePictureOfFormatType(image, saveFullPath, imageFormat).ConfigureAwait(false);
    }


    /// <summary>
    /// 将包含图像的数据流存储到指定路径下的图像文件
    /// </summary>
    /// <param name="imageStream">包含图像的数据流</param>
    /// <param name="saveFullPath">保存图像的绝对路径</param>
    /// <param name="imageFormat">图像格式</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public static async Task SaveImageFromStreamAsync(Stream imageStream, string saveFullPath, PictureFormat imageFormat)
    {
        using Image image = await Image.LoadAsync(imageStream).ConfigureAwait(false);
        await SavePictureOfFormatType(image, saveFullPath, imageFormat).ConfigureAwait(false);
    }


    /// <summary>
    /// 将图像对象以指定的格式存储到指定位置
    /// </summary>
    /// <param name="imageSource">图像源</param>
    /// <param name="saveFullPath">保存路径</param>
    /// <param name="imageFormat">图像格式</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    private static async Task SavePictureOfFormatType(Image imageSource, string saveFullPath, PictureFormat imageFormat)
    {
        switch (imageFormat)
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
}