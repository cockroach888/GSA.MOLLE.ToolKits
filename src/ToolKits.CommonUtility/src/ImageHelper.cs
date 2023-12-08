//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：ImageHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2023-11-16 10:52:01
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;

namespace GSA.ToolKits.CommonUtility;

/// <summary>
/// 图像辅助操作与处理助手类
/// </summary>
public static class ImageHelper
{
    /// <summary>
    /// 将图像转换为包含前缀的Base64字符串
    /// </summary>
    /// <remarks>
    /// <para>例如: data:image/png;base64,</para>
    /// <para>暂支持PNG、JGP、JPG、JPEG四种格式的图像</para>
    /// <para>不支持的图像格式，将不返回前缀。</para>
    /// </remarks>
    /// <param name="imageFullPath">源图像文件绝对路径</param>
    /// <returns>Base64字符串</returns>
    public static string ImageToBase64(string imageFullPath)
    {
        string extString = Path.GetExtension(imageFullPath).Remove(0, 1);
        string prefixString = $"data:image/{extString};base64,";
        return $"{prefixString}{ImageToBase64WithoutPrefix(imageFullPath)}";
    }

    /// <summary>
    /// 将图像转换为不包含前缀的Base64字符串
    /// </summary>
    /// <param name="imageFullPath">源图像文件绝对路径</param>
    /// <returns>Base64字符串</returns>
    public static string ImageToBase64WithoutPrefix(string imageFullPath)
    {
        byte[] buffer = File.ReadAllBytes(imageFullPath);
        return Convert.ToBase64String(buffer);
    }


    /// <summary>
    /// 将包含前缀的Base64字符串转换为图像
    /// </summary>
    /// <remarks>例如：data:image/png;base64,</remarks>
    /// <param name="base64String">包含前缀的Base64字符串</param>
    /// <returns>图像对象 (外部使用完后必须释放)</returns>
    public static Bitmap ImageFromBase64(string base64String)
    {
        int index = base64String.IndexOf(',');

        if (index > 0)
        {
            base64String = base64String.Remove(0, index + 1);
        }

        return ImageFromBase64WithoutPrefix(base64String);
    }

    /// <summary>
    /// 将不包含前缀的Base64字符串转换为图像
    /// </summary>
    /// <param name="base64String">不包含前缀的Base64字符串</param>
    /// <returns>图像对象 (外部使用完后必须释放)</returns>
    public static Bitmap ImageFromBase64WithoutPrefix(string base64String)
    {
        byte[] buffer = Convert.FromBase64String(base64String);
        using MemoryStream ms = new(buffer);
        return new Bitmap(ms);
    }


    /// <summary>
    /// 将包含前缀的Base64字符串转存储到指定路径下的图像文件
    /// </summary>
    /// <remarks>当存储目标文件存在时，将会在保存时自动覆盖。</remarks>
    /// <param name="base64String">包含前缀的Base64字符串</param>
    /// <param name="saveFullPath">保存图像的绝对路径</param>
    /// <param name="imageFormat">图像格式化类型</param>
    public static void SaveImageFromBase64(string base64String, string saveFullPath, ImageFormatTypes imageFormat)
    {
        using Bitmap bmpTemp = ImageFromBase64(base64String);
        using Bitmap bmp = new(bmpTemp);
        bmp.Save(saveFullPath, ConvertImageFormatType(imageFormat));
    }

    /// <summary>
    /// 将不包含前缀的Base64字符串存储到指定路径下的图像文件
    /// </summary>
    /// <remarks>当存储目标文件存在时，将会在保存时自动覆盖。</remarks>
    /// <param name="base64String">不包含前缀的Base64字符串</param>
    /// <param name="saveFullPath">保存图像的绝对路径</param>
    /// <param name="imageFormat">图像格式化类型</param>
    public static void SaveImageFromBase64WithoutPrefix(string base64String, string saveFullPath, ImageFormatTypes imageFormat)
    {
        using Bitmap bmpTemp = ImageFromBase64WithoutPrefix(base64String);
        using Bitmap bmp = new(bmpTemp);
        bmp.Save(saveFullPath, ConvertImageFormatType(imageFormat));
    }


    /// <summary>
    /// 将包含图像的数据流存储到指定路径下的图像文件
    /// </summary>
    /// <param name="imageStream">包含图像的数据流</param>
    /// <param name="saveFullPath">保存图像的绝对路径</param>
    /// <param name="imageFormat">图像格式化类型</param>
    public static void SaveImageFromStream(Stream imageStream, string saveFullPath, ImageFormatTypes imageFormat)
    {
        using Bitmap bmpTemp = new(imageStream);
        using Bitmap bmp = new(bmpTemp);
        bmp.Save(saveFullPath, ConvertImageFormatType(imageFormat));
    }



    /// <summary>
    /// 将自定义图像格式化类型转换为内部使用的图像格式
    /// </summary>
    /// <param name="imageFormat">图像格式化类型</param>
    /// <returns>图像格式</returns>
    private static ImageFormat ConvertImageFormatType(ImageFormatTypes imageFormat)
        => imageFormat switch
        {
            ImageFormatTypes.BMP => ImageFormat.Bmp,
            ImageFormatTypes.EMF => ImageFormat.Emf,
            ImageFormatTypes.Exif => ImageFormat.Exif,

            ImageFormatTypes.GIF => ImageFormat.Gif,
#if NET
            ImageFormatTypes.HEIF => ImageFormat.Heif,
#endif
            ImageFormatTypes.Icon => ImageFormat.Icon,
            ImageFormatTypes.JPEG => ImageFormat.Jpeg,
            ImageFormatTypes.MemoryBmp => ImageFormat.MemoryBmp,
            ImageFormatTypes.PNG => ImageFormat.Png,
            ImageFormatTypes.TIFF => ImageFormat.Tiff,
#if NET
            ImageFormatTypes.WebP => ImageFormat.Webp,
#endif
            ImageFormatTypes.WMF => ImageFormat.Wmf,
            _ => ImageFormat.Jpeg,
        };
}


/// <summary>
/// 图像格式化类型枚举
/// </summary>
public enum ImageFormatTypes
{
    /// <summary>
    /// 位图（BMP）图像格式
    /// </summary>
    BMP,

    /// <summary>
    /// 增强元文件（EMF）图像格式
    /// </summary>
    EMF,

    /// <summary>
    /// 可交换图像文件（Exif）格式
    /// </summary>
    Exif,

    /// <summary>
    /// 图形交换格式 (GIF) 图像格式
    /// </summary>
    GIF,

#if NET
    /// <summary>
    /// 高效图像格式（HEIF）
    /// </summary>
    HEIF,
#endif

    /// <summary>
    /// Windows 图标图像格式
    /// </summary>
    Icon,

    /// <summary>
    /// 联合图像专家组（JPEG）图像格式
    /// </summary>
    JPEG,

    /// <summary>
    /// 内存中位图的格式
    /// </summary>
    MemoryBmp,

    /// <summary>
    /// W3C 便携式网络图形（PNG）图像格式
    /// </summary>
    PNG,

    /// <summary>
    /// 标记图像文件格式（TIFF）图像格式
    /// </summary>
    TIFF,

#if NET
    /// <summary>
    /// WebP 图像格式
    /// </summary>
    WebP,
#endif

    /// <summary>
    /// Windows 元文件 (WMF) 图像格式
    /// </summary>
    WMF
}