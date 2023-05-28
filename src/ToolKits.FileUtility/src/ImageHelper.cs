//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：ImageHelper.cs
// 项目名称：文件操作实用工具集
// 创建时间：2014-02-20 17:07:00
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.FileUtility.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace GSA.ToolKits.FileUtility;

/// <summary>
/// 图片辅助与操作助手类
/// </summary>
public static class ImageHelper
{
    /// <summary>
    /// 校验目标图片是否存在，不存在则返回默认图片。
    /// </summary>
    /// <param name="targetPath">目标图片</param>
    /// <param name="defaultPath">默认图片</param>
    /// <returns>要显示的图片</returns>
    public static string IsTargetImageOrDefault(string targetPath, string defaultPath)
    {
        if (string.IsNullOrEmpty(targetPath))
        {
            return defaultPath;
        }

        return File.Exists(targetPath) ? targetPath : defaultPath;
    }

    /// <summary>
    /// 判断图片的文件类型是否为Web所支持的格式
    /// </summary>
    /// <remarks>例如：image/pjpeg, image/jpeg, image/gif, image/bmp, image/png</remarks>
    /// <param name="contentType">图片类型</param>
    /// <returns>true 支持 / false 不支持</returns>
    public static bool IsWebImage(string contentType)
    {
        if (contentType == "image/pjpeg"
            || contentType == "image/jpeg"
            || contentType == "image/gif"
            || contentType == "image/bmp"
            || contentType == "image/png")
        {
            return true;
        }

        return false;
    }


    #region 普通缩略图生成模式

    /// <summary>
    /// 普通缩略图生成模式
    /// </summary>
    /// <param name="info">参数信息</param>
    public static void ThumbnailsUseGeneral(ThumbnailsGeneralInfo info)
    {
        using Image imgSource = Image.FromFile(info.SourceFullPath);

        int towidth = info.Width;
        int toheight = info.Height;
        int x = 0;
        int y = 0;
        int ow = imgSource.Width;
        int oh = imgSource.Height;

        switch (info.Mode)
        {
            case ThumbnailsMode.W:
                toheight = imgSource.Height * info.Width / imgSource.Width;
                break;
            case ThumbnailsMode.H:
                towidth = imgSource.Width * info.Height / imgSource.Height;
                break;
            case ThumbnailsMode.Cut:
                if (imgSource.Width / (double)imgSource.Height > towidth / (double)toheight)
                {
                    oh = imgSource.Height;
                    ow = imgSource.Height * towidth / toheight;
                    y = 0;
                    x = (imgSource.Width - ow) / 2;
                }
                else
                {
                    ow = imgSource.Width;
                    oh = imgSource.Width * info.Height / towidth;
                    x = 0;
                    y = (imgSource.Height - oh) / 2;
                }
                break;
            case ThumbnailsMode.HW:
            default:
                break;
        }

        // 新建一个bmp图片
        using Bitmap bitmap = new(towidth, toheight);

        // 新建一个画板
        using Graphics g = Graphics.FromImage(bitmap);

        // 设置合成图像的渲染质量
        g.CompositingQuality = CompositingQuality.HighQuality;

        // 设置高质量插值法
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;

        // 设置高质量,低速度呈现平滑程度
        g.SmoothingMode = SmoothingMode.HighQuality;

        // 清空画布并以透明背景色填充
        g.Clear(Color.Transparent);

        // 在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(imgSource, new Rectangle(0, 0, towidth, toheight), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);

        // 当目录不存在时则创建。
        if (!Directory.Exists(info.SaveFilePath))
        {
            Directory.CreateDirectory(info.SaveFilePath);
        }

        // 文件保存全路径
        string filePath = Path.Combine(info.SaveFilePath, info.SaveFileName);

        bitmap.Save(filePath, info.SaveFormat);
    }

    #endregion


    #region 正方型缩略图裁剪与缩放

    /// <summary>
    /// 正方型缩略图裁剪与缩放
    /// </summary>
    /// <remarks>以图片中心为轴心，截取正方型并进行等比缩放。</remarks>
    /// <param name="info">参数信息</param>
    public static void ThumbnailsUseSquare(ThumbnailsSquareInfo info)
    {
        Image imgSource = Image.FromFile(info.SourceFullPath);

        // 当目录不存在时则创建。
        if (!Directory.Exists(info.SaveFilePath))
        {
            Directory.CreateDirectory(info.SaveFilePath);
        }

        // 文件保存全路径
        string filePath = Path.Combine(info.SaveFilePath, info.SaveFileName);

        // 当原图的宽高均小于边长时，不用作处理直接保存。
        if (imgSource.Width <= info.SideValue &&
            imgSource.Height <= info.SideValue)
        {
            imgSource.Save(filePath, info.SaveFormat);
        }
        else
        {
            // 原始图片的宽度和高度
            int initWidth = imgSource.Width;
            int initHeight = imgSource.Height;

            // 非正方型先裁剪为正方型
            if (initWidth != initHeight)
            {
                Graphics pickedG;
                Image pickedImage;

                if (initWidth > initHeight) // 如果是宽度大于高度的横图
                {
                    // 对象实例化
                    pickedImage = new Bitmap(initHeight, initHeight);
                    pickedG = Graphics.FromImage(pickedImage);

                    // 设置质量
                    pickedG.CompositingQuality = CompositingQuality.HighQuality;
                    pickedG.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    pickedG.SmoothingMode = SmoothingMode.HighQuality;

                    // 定位
                    Rectangle fromR = new((initWidth - initHeight) / 2, 0, initHeight, initHeight);
                    Rectangle toR = new(0, 0, initHeight, initHeight);

                    // 画图
                    pickedG.DrawImage(imgSource, toR, fromR, GraphicsUnit.Pixel);

                    // 重置宽
                    initWidth = initHeight;
                }
                else // 如果是高度大于宽度的竖图
                {
                    // 对象实例化
                    pickedImage = new Bitmap(initWidth, initWidth);
                    pickedG = Graphics.FromImage(pickedImage);

                    // 设置质量
                    pickedG.CompositingQuality = CompositingQuality.HighQuality;
                    pickedG.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    pickedG.SmoothingMode = SmoothingMode.HighQuality;

                    // 定位
                    Rectangle fromR = new(0, (initHeight - initWidth) / 2, initWidth, initWidth);
                    Rectangle toR = new(0, 0, initWidth, initWidth);

                    // 画图
                    pickedG.DrawImage(imgSource, toR, fromR, GraphicsUnit.Pixel);

                    // 重置高
                    initHeight = initWidth;
                }

                // 将截图对象赋给原图
                imgSource = (Image)pickedImage.Clone();

                // 释放截图资源
                using (pickedG) { }
                using (pickedImage) { }
            }

            // 缩略图对象
            using var resultImage = new Bitmap(info.SideValue, info.SideValue);
            using var resultG = Graphics.FromImage(resultImage);

            // 设置质量
            resultG.CompositingQuality = CompositingQuality.HighQuality;
            resultG.InterpolationMode = InterpolationMode.HighQualityBicubic;
            resultG.SmoothingMode = SmoothingMode.HighQuality;

            // 用指定背景色清空画布
            resultG.Clear(Color.White);

            // 绘制缩略图
            resultG.DrawImage(imgSource, new Rectangle(0, 0, info.SideValue, info.SideValue), new Rectangle(0, 0, initWidth, initHeight), GraphicsUnit.Pixel);

            // 关键质量控制
            // 获取系统编码类型数组,包含了jpeg,bmp,png,gif,tiff
            ImageCodecInfo[] icis = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo ici = null;

            foreach (ImageCodecInfo i in icis)
            {
                if (i.MimeType == "image/jpeg" ||
                    i.MimeType == "image/bmp" ||
                    i.MimeType == "image/png" ||
                    i.MimeType == "image/gif")
                {
                    ici = i;
                }
            }

            using EncoderParameters ep = new(1);

            ep.Param[0] = new EncoderParameter(Encoder.Quality, info.QualityValue);

            // 保存缩略图
            resultImage.Save(filePath, ici, ep);
        }

        // 释放原始图片资源
        using (imgSource) { }
    }

    #endregion


    #region 自定义缩略图裁剪与缩放

    /// <summary>
    /// 自定义缩略图裁剪与缩放
    /// </summary>
    /// <remarks>按自定义宽度和高度的最大比例缩放裁剪图片</remarks>
    /// <param name="info">参数信息</param>
    public static void ThumbnailsUseCustom(ThumbnailsCustomInfo info)
    {
        using Image imgSource = Image.FromFile(info.SourceFullPath);

        // 当目录不存在时则创建。
        if (!Directory.Exists(info.SaveFilePath))
        {
            Directory.CreateDirectory(info.SaveFilePath);
        }

        // 文件保存全路径
        string filePath = Path.Combine(info.SaveFilePath, info.SaveFileName);

        // 当原图的宽高均小于自定义大小时，不用作处理直接保存。
        if (imgSource.Width <= info.MaxWidth &&
            imgSource.Height <= info.MaxHeight)
        {
            imgSource.Save(filePath, info.SaveFormat);
        }
        else
        {
            // 自定义的宽高比例
            double templateRate = (double)info.MaxWidth / info.MaxHeight;

            // 原图片的宽高比例
            double initRate = (double)imgSource.Width / imgSource.Height;

            if (templateRate == initRate) // 原图与自定义比例相等，直接缩放
            {
                // 按自定义大小生成最终图片
                using var templateImage = new Bitmap(info.MaxWidth, info.MaxHeight);
                using var templateG = Graphics.FromImage(templateImage);

                templateG.CompositingQuality = CompositingQuality.HighQuality;
                templateG.InterpolationMode = InterpolationMode.HighQualityBicubic;
                templateG.SmoothingMode = SmoothingMode.HighQuality;
                templateG.Clear(Color.White);
                templateG.DrawImage(imgSource, new Rectangle(0, 0, info.MaxWidth, info.MaxHeight), new Rectangle(0, 0, imgSource.Width, imgSource.Height), GraphicsUnit.Pixel);

                templateImage.Save(filePath, info.SaveFormat);
            }
            else // 原图与自定义比例不等，裁剪后缩放
            {
                // 定位
                Rectangle fromR = new(0, 0, 0, 0); // 原图裁剪定位
                Rectangle toR = new(0, 0, 0, 0); // 目标定位
                Graphics pickedG;
                Image pickedImage;

                if (templateRate > initRate) // 宽为标准进行裁剪
                {
                    // 裁剪对象实例化
                    pickedImage = new Bitmap(imgSource.Width, (int)Math.Floor(imgSource.Width / templateRate));
                    pickedG = Graphics.FromImage(pickedImage);

                    // 裁剪源定位
                    fromR.X = 0;
                    fromR.Y = (int)Math.Floor((imgSource.Height - imgSource.Width / templateRate) / 2);
                    fromR.Width = imgSource.Width;
                    fromR.Height = (int)Math.Floor(imgSource.Width / templateRate);

                    // 裁剪目标定位
                    toR.X = 0;
                    toR.Y = 0;
                    toR.Width = imgSource.Width;
                    toR.Height = (int)Math.Floor(imgSource.Width / templateRate);
                }
                else // 高为标准进行裁剪
                {
                    pickedImage = new Bitmap((int)Math.Floor(imgSource.Height * templateRate), imgSource.Height);
                    pickedG = Graphics.FromImage(pickedImage);

                    fromR.X = (int)Math.Floor((imgSource.Width - imgSource.Height * templateRate) / 2);
                    fromR.Y = 0;
                    fromR.Width = (int)Math.Floor(imgSource.Height * templateRate);
                    fromR.Height = imgSource.Height;

                    toR.X = 0;
                    toR.Y = 0;
                    toR.Width = (int)Math.Floor(imgSource.Height * templateRate);
                    toR.Height = imgSource.Height;
                }

                // 设置质量
                pickedG.CompositingQuality = CompositingQuality.HighQuality;
                pickedG.InterpolationMode = InterpolationMode.HighQualityBicubic;
                pickedG.SmoothingMode = SmoothingMode.HighQuality;

                // 裁剪
                pickedG.DrawImage(imgSource, toR, fromR, GraphicsUnit.Pixel);

                // 按自定义大小生成最终图片
                using var templateImage = new Bitmap(info.MaxWidth, info.MaxHeight);
                using var templateG = Graphics.FromImage(templateImage);

                templateG.CompositingQuality = CompositingQuality.HighQuality;
                templateG.InterpolationMode = InterpolationMode.High;
                templateG.SmoothingMode = SmoothingMode.HighQuality;
                templateG.Clear(Color.White);
                templateG.DrawImage(pickedImage, new Rectangle(0, 0, info.MaxWidth, info.MaxHeight), new Rectangle(0, 0, pickedImage.Width, pickedImage.Height), GraphicsUnit.Pixel);

                // 关键质量控制
                // 获取系统编码类型数组,包含了jpeg,bmp,png,gif,tiff
                ImageCodecInfo[] icis = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo ici = null;

                foreach (ImageCodecInfo i in icis)
                {
                    if (i.MimeType == "image/jpeg" ||
                        i.MimeType == "image/bmp" ||
                        i.MimeType == "image/png" ||
                        i.MimeType == "image/gif")
                    {
                        ici = i;
                    }
                }

                EncoderParameters ep = new(1);
                ep.Param[0] = new EncoderParameter(Encoder.Quality, info.QualityValue);

                // 保存缩略图
                templateImage.Save(filePath, ici, ep);

                // 释放截图资源
                using (pickedG) { }
                using (pickedImage) { }
            }
        }
    }

    #endregion


    #region 按等比生成缩略图与图片水印

    /// <summary>
    /// 按等比生成缩略图与图片水印
    /// </summary>
    /// <param name="info">参数信息</param>
    public static void ThumbnailsUseIsometric(ThumbnailsIsometricInfo info)
    {
        using Image imgSource = Image.FromFile(info.SourceFullPath);

        // 当目录不存在时则创建。
        if (!Directory.Exists(info.SaveFilePath))
        {
            Directory.CreateDirectory(info.SaveFilePath);
        }

        // 文件保存全路径
        string filePath = Path.Combine(info.SaveFilePath, info.SaveFileName);

        // 原图宽高均小于自定义，不作处理，直接保存
        if (imgSource.Width <= info.MaxWidth &&
            imgSource.Height <= info.MaxHeight)
        {
            // 文字水印
            if (!string.IsNullOrWhiteSpace(info.WatermarkText))
            {
                using Graphics gWater = Graphics.FromImage(imgSource);

                Font fontWater = new("黑体", 10);
                Brush brushWater = new SolidBrush(Color.White);

                gWater.DrawString(info.WatermarkText, fontWater, brushWater, 10, 10);
            }

            // 图片水印
            if (!string.IsNullOrWhiteSpace(info.WatermarkImage))
            {
                if (File.Exists(info.WatermarkImage))
                {
                    using Image imgWatermark = Image.FromFile(info.WatermarkImage);

                    // 水印绘制条件：原始图片宽高均大于或等于水印图片
                    if (imgSource.Width >= imgWatermark.Width &&
                        imgSource.Height >= imgWatermark.Height)
                    {
                        using Graphics gWater = Graphics.FromImage(imgSource);

                        // 透明属性
                        ImageAttributes imgAttributes = new();

                        ColorMap colorMap = new()
                        {
                            OldColor = Color.FromArgb(255, 0, 255, 0),
                            NewColor = Color.FromArgb(0, 0, 0, 0)
                        };

                        ColorMap[] remapTable = { colorMap };
                        imgAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

                        float[][] colorMatrixElements = {
                               new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                               new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                               new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                               new float[] {0.0f,  0.0f,  0.0f,  0.5f, 0.0f}, // 透明度:0.5
                               new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                            };

                        ColorMatrix wmColorMatrix = new(colorMatrixElements);
                        imgAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                        gWater.DrawImage(imgWatermark, new Rectangle(imgSource.Width - imgWatermark.Width, imgSource.Height - imgWatermark.Height, imgWatermark.Width, imgWatermark.Height), 0, 0, imgWatermark.Width, imgWatermark.Height, GraphicsUnit.Pixel, imgAttributes);
                    }
                }
            }

            imgSource.Save(filePath, info.SaveFormat);
        }
        else
        {
            // 缩略图宽、高计算
            double newWidth = imgSource.Width;
            double newHeight = imgSource.Height;

            // 宽大于高或宽等于高（横图或正方）
            if (imgSource.Width > imgSource.Height ||
                imgSource.Width == imgSource.Height)
            {
                // 如果宽大于自定义
                if (imgSource.Width > info.MaxWidth)
                {
                    // 宽按自定义，高按比例缩放
                    newWidth = info.MaxWidth;
                    newHeight = imgSource.Height * (info.MaxWidth / imgSource.Width);
                }
            }
            else // 高大于宽（竖图）
            {
                // 如果高大于自定义
                if (imgSource.Height > info.MaxHeight)
                {
                    // 高按自定义，宽按比例缩放
                    newHeight = info.MaxHeight;
                    newWidth = imgSource.Width * (info.MaxHeight / imgSource.Height);
                }
            }

            // 生成新图
            using var newImage = new Bitmap((int)newWidth, (int)newHeight);
            using var newG = Graphics.FromImage(newImage);

            // 设置质量
            newG.CompositingQuality = CompositingQuality.HighQuality;
            newG.InterpolationMode = InterpolationMode.HighQualityBicubic;
            newG.SmoothingMode = SmoothingMode.HighQuality;

            // 设置背景色
            newG.Clear(Color.White);

            // 画图
            newG.DrawImage(imgSource, new Rectangle(0, 0, newImage.Width, newImage.Height), new Rectangle(0, 0, imgSource.Width, imgSource.Height), GraphicsUnit.Pixel);

            // 文字水印
            if (!string.IsNullOrWhiteSpace(info.WatermarkText))
            {
                using Graphics gWater = Graphics.FromImage(newImage);

                Font fontWater = new("宋体", 10);
                Brush brushWater = new SolidBrush(Color.White);
                gWater.DrawString(info.WatermarkText, fontWater, brushWater, 10, 10);
            }

            // 透明图片水印
            if (!string.IsNullOrWhiteSpace(info.WatermarkImage))
            {
                if (File.Exists(info.WatermarkImage))
                {
                    // 获取水印图片
                    using Image imgWatermark = Image.FromFile(info.WatermarkImage);

                    // 水印绘制条件：原始图片宽高均大于或等于水印图片
                    if (newImage.Width >= imgWatermark.Width &&
                        newImage.Height >= imgWatermark.Height)
                    {
                        using Graphics gWater = Graphics.FromImage(newImage);

                        //透明属性
                        ImageAttributes imgAttributes = new();

                        ColorMap colorMap = new()
                        {
                            OldColor = Color.FromArgb(255, 0, 255, 0),
                            NewColor = Color.FromArgb(0, 0, 0, 0)
                        };

                        ColorMap[] remapTable = { colorMap };
                        imgAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

                        float[][] colorMatrixElements = {
                                       new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                       new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                       new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                       new float[] {0.0f,  0.0f,  0.0f,  0.5f, 0.0f}, // 透明度:0.5
                                       new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                    };

                        ColorMatrix wmColorMatrix = new(colorMatrixElements);
                        imgAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                        gWater.DrawImage(imgWatermark, new Rectangle(newImage.Width - imgWatermark.Width, newImage.Height - imgWatermark.Height, imgWatermark.Width, imgWatermark.Height), 0, 0, imgWatermark.Width, imgWatermark.Height, GraphicsUnit.Pixel, imgAttributes);
                    }
                }
            }

            // 保存缩略图
            newImage.Save(filePath, info.SaveFormat);
        }
    }

    #endregion


    #region 为图片附加图片水印

    /// <summary>
    /// 为图片附加图片水印
    /// </summary>
    /// <param name="info">参数信息</param>
    public static void WatermarkUseImage(WatermarkImageInfo info)
    {
        // 当目录不存在时则创建。
        if (!Directory.Exists(info.SaveFilePath))
        {
            Directory.CreateDirectory(info.SaveFilePath);
        }

        // 文件保存全路径
        string filePath = Path.Combine(info.SaveFilePath, info.SaveFileName);

        using Image imgSource = Image.FromFile(info.SourceFullPath);
        using Image imgWatermark = Image.FromFile(info.WaterFullPath);
        using Graphics g = Graphics.FromImage(imgSource);

        // 设置合成图像的渲染质量
        g.CompositingQuality = CompositingQuality.HighQuality;

        // 设置高质量插值法
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;

        // 设置高质量,低速度呈现平滑程度
        g.SmoothingMode = SmoothingMode.HighQuality;

        (int x, int y) = GetLocation(info.Location, imgSource, imgWatermark);

        g.DrawImage(imgWatermark, new Rectangle(x, y, imgWatermark.Width, imgWatermark.Height));

        imgSource.Save(filePath);
    }

    /// <summary>
    /// 获取图片水印位置计算结果
    /// </summary>
    /// <param name="location">水印位置</param>
    /// <param name="imgSource">源图片</param>
    /// <param name="imgWatermark">水印图片</param>
    /// <returns>图片水印位置</returns>
    private static (int x, int y) GetLocation(WatermarkLocation location, Image imgSource, Image imgWatermark)
        => location switch
        {
            WatermarkLocation.LT => (x: 10, y: 10),
            WatermarkLocation.T => (x: imgSource.Width / 2 - imgWatermark.Width / 2, y: imgSource.Height - imgWatermark.Height),
            WatermarkLocation.RT => (x: imgSource.Width - imgWatermark.Width, y: 10),
            WatermarkLocation.LC => (x: 10, y: imgSource.Height / 2 - imgWatermark.Height / 2),
            WatermarkLocation.C => (x: imgSource.Width / 2 - imgWatermark.Width / 2, y: imgSource.Height / 2 - imgWatermark.Height / 2),
            WatermarkLocation.RC => (x: imgSource.Width - imgWatermark.Width, y: imgSource.Height / 2 - imgWatermark.Height / 2),
            WatermarkLocation.LB => (x: 10, y: imgSource.Height - imgWatermark.Height),
            WatermarkLocation.B => (x: imgSource.Width / 2 - imgWatermark.Width / 2, y: imgSource.Height - imgWatermark.Height),
            WatermarkLocation.RB => (x: imgSource.Width - imgWatermark.Width, y: imgSource.Height - imgWatermark.Height),
            _ => throw new ArgumentOutOfRangeException()
        };


    #endregion


    #region 为图片附加文本水印

    /// <summary>
    /// 为图片附加文本水印
    /// </summary>
    /// <param name="info">参数信息</param>
    public static void WatermarkUseText(WatermarkTextInfo info)
    {
        // 当目录不存在时则创建。
        if (!Directory.Exists(info.SaveFilePath))
        {
            Directory.CreateDirectory(info.SaveFilePath);
        }

        // 文件保存全路径
        string filePath = Path.Combine(info.SaveFilePath, info.SaveFileName);

        using Image imgSource = Image.FromFile(info.SourceFullPath);
        using Graphics g = Graphics.FromImage(imgSource);

        // 设置合成图像的渲染质量
        g.CompositingQuality = CompositingQuality.HighQuality;

        // 设置高质量插值法
        g.InterpolationMode = InterpolationMode.High;

        // 设置高质量,低速度呈现平滑程度
        g.SmoothingMode = SmoothingMode.HighQuality;

        (float x, float y) = GetLocation(info.Location, imgSource, info.FontSize, info.WatermarkText.Length);

        Font font = new(info.FamilyName, info.FontSize);
        Brush br = new SolidBrush(info.FontColor);

        g.DrawString(info.WatermarkText, font, br, x, y);

        imgSource.Save(filePath);

    }

    /// <summary>
    /// 获取文本水印位置计算结果
    /// </summary>
    /// <param name="location">水印位置</param>
    /// <param name="imgSource">源图片</param>
    /// <param name="fontSize">字体大小 (宽度)</param>
    /// <param name="textLength">水印文本长度 (高度)</param>
    /// <returns>文本水印位置</returns>
    private static (float x, float y) GetLocation(WatermarkLocation location, Image imgSource, int fontSize, int textLength)
        => location switch
        {
            WatermarkLocation.LT => (x: 10, y: 10),
            WatermarkLocation.T => (x: imgSource.Width / 2 - (fontSize * textLength) / 2, y: 10),
            WatermarkLocation.RT => (x: imgSource.Width - fontSize * textLength, y: 10),
            WatermarkLocation.LC => (x: 10, y: imgSource.Height / 2),
            WatermarkLocation.C => (x: imgSource.Width / 2 - (fontSize * textLength) / 2, y: imgSource.Height / 2),
            WatermarkLocation.RC => (x: imgSource.Width - textLength, y: imgSource.Height / 2),
            WatermarkLocation.LB => (x: 10, y: imgSource.Height - fontSize - 5),
            WatermarkLocation.B => (x: imgSource.Width / 2 - (fontSize * textLength) / 2, y: imgSource.Height - fontSize - 5),
            WatermarkLocation.RB => (x: imgSource.Width - fontSize * textLength, y: imgSource.Height - fontSize - 5),
            _ => throw new ArgumentOutOfRangeException()
        };

    #endregion


    #region 将图片转换为Base64字符串(或包含前缀)

    /// <summary>
    /// 将图片转换为包含前缀的Base64字符串
    /// </summary>
    /// <remarks>
    /// <para>例如: data:image/png;base64,</para>
    /// <para>暂支持PNG、JGP、JPG、JPEG四种格式的图片</para>
    /// <para>不支持的图片格式，将不返回前缀。</para>
    /// </remarks>
    /// <param name="imageFullPath">源图片文件全路径</param>
    /// <param name="format">图像格式</param>
    /// <returns>Base64字符串</returns>
    public static string ImageToBase64IncludePrefix(string imageFullPath, ImageFormat format)
    {
        string extName = Path.GetExtension(imageFullPath);
        string prefix = extName switch
        {
            ".png" => "data:image/png;base64,",
            ".jgp" => "data:image/jgp;base64,",
            ".jpg" => "data:image/jpg;base64,",
            ".jpeg" => "data:image/jpeg;base64,",
            _ => string.Empty
        };

        return $"{prefix}{ImageToBase64(imageFullPath, format)}";
    }

    /// <summary>
    /// 将图片转换为Base64字符串
    /// </summary>
    /// <param name="imageFullPath">源图片文件全路径</param>
    /// <param name="format">图像格式</param>
    /// <returns>Base64字符串</returns>
    public static string ImageToBase64(string imageFullPath, ImageFormat format)
    {
        using Bitmap bitmap = new(imageFullPath);
        using MemoryStream ms = new();

        bitmap.Save(ms, format);

        byte[] bArray = new byte[ms.Length];
        ms.Position = 0;
        ms.Read(bArray, 0, (int)ms.Length);
        ms.Close();

        return Convert.ToBase64String(bArray);
    }

    #endregion


    #region 将由Base64字符串(或包含前缀)或由字节数组组成的数据转换为图片对象

    /// <summary>
    /// 将包含前缀的Base64字符串组成的数据转换为图片对象
    /// </summary>
    /// <remarks>例如：data:image/png;base64,</remarks>
    /// <param name="base64String">包含前缀的Base64字符串</param>
    /// <returns>图片对象 (外部使用完后必须释放)</returns>
    public static Bitmap ImageFromBase64IncludePrefix(string base64String)
    {
        var index = base64String.IndexOf(',');

        if (index > 0)
        {
            base64String = base64String.Remove(0, index);
        }

        return ImageFromBase64(base64String);
    }

    /// <summary>
    /// 将由Base64字符串组成的数据转换为图片对象
    /// </summary>
    /// <param name="base64String">Base64字符串</param>
    /// <returns>图片对象 (外部使用完后必须释放)</returns>
    public static Bitmap ImageFromBase64(string base64String)
    {
        byte[] buffer = Convert.FromBase64String(base64String);

        return ImageFromArray(buffer);
    }

    /// <summary>
    /// 将由字节数组组成的数据转换为图片对象
    /// </summary>
    /// <param name="buffer">字节数组</param>
    /// <returns>图片对象 (外部使用完后必须释放)</returns>
    public static Bitmap ImageFromArray(byte[] buffer)
    {
        using MemoryStream ms = new(buffer);

        return new Bitmap(ms);
    }

    #endregion

}