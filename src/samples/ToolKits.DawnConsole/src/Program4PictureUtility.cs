//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：Program4PictureUtility.cs
// 项目名称：功能调测控制台程序
// 创建时间：2023-12-11 14:16:28
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.CommonUtility;
using GSA.ToolKits.PictureUtility;

namespace GSA.ToolKits.DawnConsole;

/// <summary>
/// PictureUtility
/// </summary>
internal static class Program4PictureUtility
{

    public static async void ImageOrBase64StringOperation()
    {
        string imagePath = "D:\\TemporaryFiles\\PictureSource.bmp";

        string base64String = ImageHelper.ImageToBase64(imagePath);
        await PictureHelper.SaveImageFromBase64Async(base64String, "D:\\TemporaryFiles\\base64String.png", PictureFormat.PNG).ConfigureAwait(false);

        SixLabors.ImageSharp.Image image = await PictureHelper.ImageFromBase64Async(base64String).ConfigureAwait(false);


        string base64StringPrefix = ImageHelper.ImageToBase64WithoutPrefix(imagePath);
        await PictureHelper.SaveImageFromBase64WithoutPrefixAsync(base64StringPrefix, "D:\\TemporaryFiles\\base64StringPrefix.jpg", PictureFormat.JPEG).ConfigureAwait(false);

        SixLabors.ImageSharp.Image imagePrefix = await PictureHelper.ImageFromBase64WithoutPrefixAsync(base64StringPrefix).ConfigureAwait(false);


        int count = 0;
    }
}