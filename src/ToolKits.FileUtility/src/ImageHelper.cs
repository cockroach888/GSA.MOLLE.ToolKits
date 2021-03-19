//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：ImageHelper.cs
// 项目名称：文件操作实用工具集
// 创建时间：2014年2月20日17时7分
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace GSA.ToolKits.FileUtility
{
    /// <summary>
    /// 图片操作辅助类
    /// <para>缩略图/水印</para>
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// 显示指定图片
        /// </summary>
        /// <param name="filePath">显示图片</param>
        /// <param name="defPath">默认图片</param>
        /// <returns>要显示的图片</returns>
        public static string ShowImage(string filePath, string defPath)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(defPath))
            {
                return string.Empty;
            }
            return File.Exists(filePath) ? filePath : defPath;
        }
        /// <summary>
        /// 判断文件类型是否为WEB格式图片
        /// (注：JPG,GIF,BMP,PNG)
        /// </summary>
        /// <param name="contentType">HttpPostedFile.ContentType</param>
        /// <returns></returns>
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
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">
        /// 生成缩略图的方式
        /// <para>"HW" 指定高宽缩放（可能变形）</para>
        /// <para>"W" 指定宽，高按比例</para>
        /// <para>"H" 指定高，宽按比例</para>
        /// <para>"Cut" 指定高宽裁减（不变形）</para>
        /// </param>
        public static void ThumbnailsOfGeneral(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            using (var originalImage = Image.FromFile(originalImagePath))
            {
                int towidth = width;
                int toheight = height;
                int x = 0;
                int y = 0;
                int ow = originalImage.Width;
                int oh = originalImage.Height;
                switch (mode)
                {
                    case "HW"://指定高宽缩放（可能变形）
                        break;
                    case "W"://指定宽，高按比例
                        toheight = originalImage.Height * width / originalImage.Width;
                        break;
                    case "H"://指定高，宽按比例
                        towidth = originalImage.Width * height / originalImage.Height;
                        break;
                    case "Cut"://指定高宽裁减（不变形）
                        if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                        {
                            oh = originalImage.Height;
                            ow = originalImage.Height * towidth / toheight;
                            y = 0;
                            x = (originalImage.Width - ow) / 2;
                        }
                        else
                        {
                            ow = originalImage.Width;
                            oh = originalImage.Width * height / towidth;
                            x = 0;
                            y = (originalImage.Height - oh) / 2;
                        }
                        break;
                    default:
                        break;
                }
                //新建一个bmp图片
                using (var bitmap = new Bitmap(towidth, toheight))
                //新建一个画板
                using (var g = Graphics.FromImage(bitmap))
                {
                    //设置合成图像的渲染质量
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    //设置高质量插值法
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    //设置高质量,低速度呈现平滑程度
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    //清空画布并以透明背景色填充
                    g.Clear(Color.Transparent);
                    //在指定位置并且按指定大小绘制原图片的指定部分
                    g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);

                    //以jpg格式保存缩略图
                    bitmap.Save(thumbnailPath, ImageFormat.Jpeg);
                }
            }
        }

        #endregion

        #region 正方型裁剪并缩放

        /// <summary>
        /// 正方型裁剪（可用于头像处理）
        /// <para>以图片中心为轴心，截取正方型，然后等比缩放</para>
        /// </summary>
        /// <param name="originImage">原图对象</param>
        /// <param name="saveDirectory">缩略图保存目录</param>
        /// <param name="saveFileName">缩略图保存名称</param>
        /// <param name="side">指定的边长（正方型）</param>
        /// <param name="quality">质量（范围0-100）</param>
        public static void ThumbnailsOfSquareCut(Image originImage, string saveDirectory, string saveFileName, int side, int quality)
        {
            // 创建目录
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }
            var filePath = Path.Combine(saveDirectory, saveFileName);

            //原图宽高均小于模版，不作处理，直接保存
            if (originImage.Width <= side && originImage.Height <= side)
            {
                originImage.Save(filePath, ImageFormat.Jpeg);
            }
            else
            {
                //原始图片的宽、高
                int initWidth = originImage.Width;
                int initHeight = originImage.Height;

                //非正方型先裁剪为正方型
                if (initWidth != initHeight)
                {
                    Graphics pickedG;
                    Image pickedImage;

                    //宽大于高的横图
                    if (initWidth > initHeight)
                    {
                        //对象实例化
                        pickedImage = new Bitmap(initHeight, initHeight);
                        pickedG = Graphics.FromImage(pickedImage);
                        //设置质量
                        pickedG.CompositingQuality = CompositingQuality.HighQuality;
                        pickedG.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        pickedG.SmoothingMode = SmoothingMode.HighQuality;
                        //定位
                        Rectangle fromR = new Rectangle((initWidth - initHeight) / 2, 0, initHeight, initHeight);
                        Rectangle toR = new Rectangle(0, 0, initHeight, initHeight);
                        //画图
                        pickedG.DrawImage(originImage, toR, fromR, GraphicsUnit.Pixel);
                        //重置宽
                        initWidth = initHeight;
                    }
                    //高大于宽的竖图
                    else
                    {
                        //对象实例化
                        pickedImage = new Bitmap(initWidth, initWidth);
                        pickedG = Graphics.FromImage(pickedImage);
                        //设置质量
                        pickedG.CompositingQuality = CompositingQuality.HighQuality;
                        pickedG.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        pickedG.SmoothingMode = SmoothingMode.HighQuality;
                        //定位
                        Rectangle fromR = new Rectangle(0, (initHeight - initWidth) / 2, initWidth, initWidth);
                        Rectangle toR = new Rectangle(0, 0, initWidth, initWidth);
                        //画图
                        pickedG.DrawImage(originImage, toR, fromR, GraphicsUnit.Pixel);
                        //重置高
                        initHeight = initWidth;
                    }
                    //将截图对象赋给原图
                    originImage = (Image)pickedImage.Clone();
                    //释放截图资源
                    pickedG.Dispose();
                    pickedImage.Dispose();
                }

                //缩略图对象
                using (var resultImage = new Bitmap(side, side))
                using (var resultG = Graphics.FromImage(resultImage))
                {
                    //设置质量
                    resultG.CompositingQuality = CompositingQuality.HighQuality;
                    resultG.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    resultG.SmoothingMode = SmoothingMode.HighQuality;
                    //用指定背景色清空画布
                    resultG.Clear(Color.White);
                    //绘制缩略图
                    resultG.DrawImage(originImage, new Rectangle(0, 0, side, side), new Rectangle(0, 0, initWidth, initHeight), GraphicsUnit.Pixel);
                    //关键质量控制
                    //获取系统编码类型数组,包含了jpeg,bmp,png,gif,tiff
                    ImageCodecInfo[] icis = ImageCodecInfo.GetImageEncoders();
                    ImageCodecInfo ici = null;
                    foreach (ImageCodecInfo i in icis)
                    {
                        if (i.MimeType == "image/jpeg" || i.MimeType == "image/bmp" || i.MimeType == "image/png" || i.MimeType == "image/gif")
                        {
                            ici = i;
                        }
                    }
                    EncoderParameters ep = new EncoderParameters(1);
                    ep.Param[0] = new EncoderParameter(Encoder.Quality, (long)quality);
                    //保存缩略图
                    resultImage.Save(filePath, ici, ep);
                    //释放关键质量控制所用资源
                    ep.Dispose();
                    //释放缩略图资源
                    resultG.Dispose();
                    resultImage.Dispose();
                    //释放原始图片资源
                    originImage.Dispose();
                }
            }
        }

        #endregion

        #region 固定模版裁剪并缩放

        /// <summary>
        /// 指定长宽裁剪
        /// <para>按模版比例最大范围的裁剪图片并缩放至模版尺寸</para>
        /// </summary>
        /// <param name="originImage">原图对象</param>
        /// <param name="saveDirectory">缩略图保存目录</param>
        /// <param name="saveFileName">缩略图保存名称</param>
        /// <param name="maxWidth">最大宽(单位:px)</param>
        /// <param name="maxHeight">最大高(单位:px)</param>
        /// <param name="quality">质量（范围0-100）</param>
        public static void ThumbnailsOfCustomSize(Image originImage, string saveDirectory, string saveFileName, int maxWidth, int maxHeight, int quality)
        {
            // 创建目录
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }
            var filePath = Path.Combine(saveDirectory, saveFileName);

            //原图宽高均小于模版，不作处理，直接保存
            if (originImage.Width <= maxWidth && originImage.Height <= maxHeight)
            {
                originImage.Save(filePath, ImageFormat.Jpeg);
            }
            else
            {
                //模版的宽高比例
                double templateRate = (double)maxWidth / maxHeight;
                //原图片的宽高比例
                double initRate = (double)originImage.Width / originImage.Height;
                //原图与模版比例相等，直接缩放
                if (templateRate == initRate)
                {
                    //按模版大小生成最终图片
                    using (var templateImage = new Bitmap(maxWidth, maxHeight))
                    using (var templateG = Graphics.FromImage(templateImage))
                    {
                        templateG.CompositingQuality = CompositingQuality.HighQuality;
                        templateG.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        templateG.SmoothingMode = SmoothingMode.HighQuality;
                        templateG.Clear(Color.White);
                        templateG.DrawImage(originImage, new Rectangle(0, 0, maxWidth, maxHeight), new Rectangle(0, 0, originImage.Width, originImage.Height), GraphicsUnit.Pixel);
                        templateImage.Save(filePath, ImageFormat.Jpeg);
                    }
                }
                //原图与模版比例不等，裁剪后缩放
                else
                {
                    //定位
                    Rectangle fromR = new Rectangle(0, 0, 0, 0);//原图裁剪定位
                    Rectangle toR = new Rectangle(0, 0, 0, 0);//目标定位
                    Graphics pickedG;
                    Image pickedImage;

                    //宽为标准进行裁剪
                    if (templateRate > initRate)
                    {
                        //裁剪对象实例化
                        pickedImage = new Bitmap(originImage.Width, (int)Math.Floor(originImage.Width / templateRate));
                        pickedG = Graphics.FromImage(pickedImage);
                        //裁剪源定位
                        fromR.X = 0;
                        fromR.Y = (int)Math.Floor((originImage.Height - originImage.Width / templateRate) / 2);
                        fromR.Width = originImage.Width;
                        fromR.Height = (int)Math.Floor(originImage.Width / templateRate);
                        //裁剪目标定位
                        toR.X = 0;
                        toR.Y = 0;
                        toR.Width = originImage.Width;
                        toR.Height = (int)Math.Floor(originImage.Width / templateRate);
                    }
                    //高为标准进行裁剪
                    else
                    {
                        pickedImage = new Bitmap((int)Math.Floor(originImage.Height * templateRate), originImage.Height);
                        pickedG = Graphics.FromImage(pickedImage);
                        fromR.X = (int)Math.Floor((originImage.Width - originImage.Height * templateRate) / 2);
                        fromR.Y = 0;
                        fromR.Width = (int)Math.Floor(originImage.Height * templateRate);
                        fromR.Height = originImage.Height;
                        toR.X = 0;
                        toR.Y = 0;
                        toR.Width = (int)Math.Floor(originImage.Height * templateRate);
                        toR.Height = originImage.Height;
                    }
                    //设置质量
                    pickedG.CompositingQuality = CompositingQuality.HighQuality;
                    pickedG.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    pickedG.SmoothingMode = SmoothingMode.HighQuality;
                    //裁剪
                    pickedG.DrawImage(originImage, toR, fromR, GraphicsUnit.Pixel);
                    //按模版大小生成最终图片
                    using (var templateImage = new Bitmap(maxWidth, maxHeight))
                    using (var templateG = Graphics.FromImage(templateImage))
                    {
                        templateG.CompositingQuality = CompositingQuality.HighQuality;
                        templateG.InterpolationMode = InterpolationMode.High;
                        templateG.SmoothingMode = SmoothingMode.HighQuality;
                        templateG.Clear(Color.White);
                        templateG.DrawImage(pickedImage, new Rectangle(0, 0, maxWidth, maxHeight), new Rectangle(0, 0, pickedImage.Width, pickedImage.Height), GraphicsUnit.Pixel);
                        //关键质量控制
                        //获取系统编码类型数组,包含了jpeg,bmp,png,gif,tiff
                        ImageCodecInfo[] icis = ImageCodecInfo.GetImageEncoders();
                        ImageCodecInfo ici = null;
                        foreach (ImageCodecInfo i in icis)
                        {
                            if (i.MimeType == "image/jpeg" || i.MimeType == "image/bmp" || i.MimeType == "image/png" || i.MimeType == "image/gif")
                            {
                                ici = i;
                            }
                        }
                        EncoderParameters ep = new EncoderParameters(1);
                        ep.Param[0] = new EncoderParameter(Encoder.Quality, quality);
                        //保存缩略图
                        templateImage.Save(filePath, ici, ep);
                        //templateImage.Save(fileSaveUrl, ImageFormat.Jpeg);
                        //释放资源
                        templateG.Dispose();
                        templateImage.Dispose();
                        pickedG.Dispose();
                        pickedImage.Dispose();
                    }
                }
            }
            //释放资源
            originImage.Dispose();
        }
        #endregion

        #region 图片按等比缩放生成缩略图

        /// <summary>
        /// 图片按等比缩放生成缩略图
        /// </summary>
        /// <param name="originImage">原图对象</param>
        /// <param name="saveDirectory">缩略图保存目录</param>
        /// <param name="saveFileName">缩略图保存名称</param>
        /// <param name="targetWidth">指定的最大宽度</param>
        /// <param name="targetHeight">指定的最大高度</param>
        /// <param name="watermarkText">水印文字(为空表示不使用水印)</param>
        /// <param name="watermarkImage">水印图片路径(为空表示不使用水印)</param>
        public static void ThumbnailsOfIsometricZoom(Image originImage, string saveDirectory, string saveFileName, double targetWidth, double targetHeight, string watermarkText, string watermarkImage)
        {
            // 创建目录
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }
            var filePath = Path.Combine(saveDirectory, saveFileName);

            //原图宽高均小于模版，不作处理，直接保存
            if (originImage.Width <= targetWidth && originImage.Height <= targetHeight)
            {
                //文字水印
                if (watermarkText != "")
                {
                    using (Graphics gWater = Graphics.FromImage(originImage))
                    {
                        Font fontWater = new Font("黑体", 10);
                        Brush brushWater = new SolidBrush(Color.White);
                        gWater.DrawString(watermarkText, fontWater, brushWater, 10, 10);
                        gWater.Dispose();
                    }
                }
                //透明图片水印
                if (watermarkImage != "")
                {
                    if (File.Exists(watermarkImage))
                    {
                        //获取水印图片
                        using (Image wrImage = Image.FromFile(watermarkImage))
                        {
                            //水印绘制条件：原始图片宽高均大于或等于水印图片
                            if (originImage.Width >= wrImage.Width && originImage.Height >= wrImage.Height)
                            {
                                using (var gWater = Graphics.FromImage(originImage))
                                {
                                    //透明属性
                                    ImageAttributes imgAttributes = new ImageAttributes();
                                    ColorMap colorMap = new ColorMap();
                                    colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
                                    colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
                                    ColorMap[] remapTable = { colorMap };
                                    imgAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);
                                    float[][] colorMatrixElements = {
                                   new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                   new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                   new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                   new float[] {0.0f,  0.0f,  0.0f,  0.5f, 0.0f},//透明度:0.5
                                   new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                };
                                    ColorMatrix wmColorMatrix = new ColorMatrix(colorMatrixElements);
                                    imgAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                                    gWater.DrawImage(wrImage, new Rectangle(originImage.Width - wrImage.Width, originImage.Height - wrImage.Height, wrImage.Width, wrImage.Height), 0, 0, wrImage.Width, wrImage.Height, GraphicsUnit.Pixel, imgAttributes);
                                    gWater.Dispose();
                                }
                            }
                            wrImage.Dispose();
                        }
                    }
                }
                //保存
                originImage.Save(filePath, ImageFormat.Jpeg);
            }
            else
            {
                //缩略图宽、高计算
                double newWidth = originImage.Width;
                double newHeight = originImage.Height;
                //宽大于高或宽等于高（横图或正方）
                if (originImage.Width > originImage.Height || originImage.Width == originImage.Height)
                {
                    //如果宽大于模版
                    if (originImage.Width > targetWidth)
                    {
                        //宽按模版，高按比例缩放
                        newWidth = targetWidth;
                        newHeight = originImage.Height * (targetWidth / originImage.Width);
                    }
                }
                //高大于宽（竖图）
                else
                {
                    //如果高大于模版
                    if (originImage.Height > targetHeight)
                    {
                        //高按模版，宽按比例缩放
                        newHeight = targetHeight;
                        newWidth = originImage.Width * (targetHeight / originImage.Height);
                    }
                }
                //生成新图
                using (var newImage = new Bitmap((int)newWidth, (int)newHeight))
                using (var newG = Graphics.FromImage(newImage))
                {
                    //设置质量
                    newG.CompositingQuality = CompositingQuality.HighQuality;
                    newG.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    newG.SmoothingMode = SmoothingMode.HighQuality;
                    //置背景色
                    newG.Clear(Color.White);
                    //画图
                    newG.DrawImage(originImage, new Rectangle(0, 0, newImage.Width, newImage.Height), new Rectangle(0, 0, originImage.Width, originImage.Height), GraphicsUnit.Pixel);
                    //文字水印
                    if (watermarkText != "")
                    {
                        using (Graphics gWater = Graphics.FromImage(newImage))
                        {
                            Font fontWater = new Font("宋体", 10);
                            Brush brushWater = new SolidBrush(Color.White);
                            gWater.DrawString(watermarkText, fontWater, brushWater, 10, 10);
                            gWater.Dispose();
                        }
                    }
                    //透明图片水印
                    if (watermarkImage != "")
                    {
                        if (File.Exists(watermarkImage))
                        {
                            //获取水印图片
                            using (Image wrImage = Image.FromFile(watermarkImage))
                            {
                                //水印绘制条件：原始图片宽高均大于或等于水印图片
                                if (newImage.Width >= wrImage.Width && newImage.Height >= wrImage.Height)
                                {
                                    using (var gWater = Graphics.FromImage(newImage))
                                    {
                                        //透明属性
                                        ImageAttributes imgAttributes = new ImageAttributes();
                                        ColorMap colorMap = new ColorMap();
                                        colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
                                        colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
                                        ColorMap[] remapTable = { colorMap };
                                        imgAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);
                                        float[][] colorMatrixElements = {
                                           new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                           new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                           new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                           new float[] {0.0f,  0.0f,  0.0f,  0.5f, 0.0f},//透明度:0.5
                                           new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                        };
                                        ColorMatrix wmColorMatrix = new ColorMatrix(colorMatrixElements);
                                        imgAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                                        gWater.DrawImage(wrImage, new Rectangle(newImage.Width - wrImage.Width, newImage.Height - wrImage.Height, wrImage.Width, wrImage.Height), 0, 0, wrImage.Width, wrImage.Height, GraphicsUnit.Pixel, imgAttributes);
                                        gWater.Dispose();
                                    }
                                }
                                wrImage.Dispose();
                            }
                        }
                    }
                    //保存缩略图
                    newImage.Save(filePath, ImageFormat.Jpeg);
                    //释放资源
                    newG.Dispose();
                    newImage.Dispose();
                    originImage.Dispose();
                }
            }
        }

        #endregion

        #region 图片附加水印处理·图片水印

        /// <summary>
        /// 图片附加水印处理
        /// <para>图片水印</para>
        /// </summary>
        /// <param name="filePath">需要加载水印的图片路径（绝对路径）</param>
        /// <param name="waterPath">水印图片（绝对路径）</param>
        /// <param name="location">
        /// 水印位置（传送正确的代码）
        /// <para>传值：LT / T / RT / LC / C / RC / LB / B</para>
        /// <para>释义：左上角/上居中/右上角/左居中/居中/右居中/左下角/下居中</para>
        /// </param>
        /// <returns>处理后的图片路径</returns>
        public static string ImageWatermark(string filePath, string waterPath, string location)
        {
            var extName = Path.GetExtension(filePath);
            if (extName == ".jpg" || extName == ".bmp" || extName == ".jpeg")
            {
                var time = DateTime.Now;
                var fileName = "" + time.Year.ToString() + time.Month.ToString() + time.Day.ToString() + time.Hour.ToString() + time.Minute.ToString() + time.Second.ToString() + time.Millisecond.ToString();
                using (var orgImg = Image.FromFile(filePath))
                using (var waterimg = Image.FromFile(waterPath))
                using (var g = Graphics.FromImage(orgImg))
                {
                    //设置合成图像的渲染质量
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    //设置高质量插值法
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    //设置高质量,低速度呈现平滑程度
                    g.SmoothingMode = SmoothingMode.HighQuality;

                    var loca = GetLocation(location, orgImg, waterimg);
                    g.DrawImage(waterimg, new Rectangle(int.Parse(loca[0].ToString()), int.Parse(loca[1].ToString()), waterimg.Width, waterimg.Height));
                    waterimg.Dispose();
                    g.Dispose();
                    string newpath = Path.GetDirectoryName(filePath) + fileName + extName;
                    orgImg.Save(newpath);
                    orgImg.Dispose();

                    File.Copy(newpath, filePath, true);
                    if (File.Exists(newpath))
                    {
                        File.Delete(newpath);
                    }
                }
            }
            return filePath;
        }
        /// <summary>
        /// 图片附加水印处理
        /// 图片水印
        /// </summary>
        /// <param name="location">水印位置</param>
        /// <param name="img">需要添加水印的图片</param>
        /// <param name="waterimg">水印图片</param>
        /// <returns>图片水印位置</returns>
        private static ArrayList GetLocation(string location, Image img, Image waterimg)
        {
            ArrayList loca = new ArrayList();
            int x = 0;
            int y = 0;

            if (location == "LT")
            {
                x = 10;
                y = 10;
            }
            else if (location == "T")
            {
                x = img.Width / 2 - waterimg.Width / 2;
                y = img.Height - waterimg.Height;
            }
            else if (location == "RT")
            {
                x = img.Width - waterimg.Width;
                y = 10;
            }
            else if (location == "LC")
            {
                x = 10;
                y = img.Height / 2 - waterimg.Height / 2;
            }
            else if (location == "C")
            {
                x = img.Width / 2 - waterimg.Width / 2;
                y = img.Height / 2 - waterimg.Height / 2;
            }
            else if (location == "RC")
            {
                x = img.Width - waterimg.Width;
                y = img.Height / 2 - waterimg.Height / 2;
            }
            else if (location == "LB")
            {
                x = 10;
                y = img.Height - waterimg.Height;
            }
            else if (location == "B")
            {
                x = img.Width / 2 - waterimg.Width / 2;
                y = img.Height - waterimg.Height;
            }
            else
            {
                x = img.Width - waterimg.Width;
                y = img.Height - waterimg.Height;
            }
            loca.Add(x);
            loca.Add(y);
            return loca;
        }

        #endregion

        #region 图片附加水印处理·文字水印

        /// <summary>
        /// 图片附加水印处理
        /// <para>文字水印</para>
        /// </summary>
        /// <param name="filePath">图片路径（绝对路径）</param>
        /// <param name="size">字体大小</param>
        /// <param name="letter">水印文字</param>
        /// <param name="color">颜色</param>
        /// <param name="location">
        /// 水印位置（传送正确的代码）
        /// <para>传值：LT / T / RT / LC / C / RC / LB / B</para>
        /// <para>释义：左上角/上居中/右上角/左居中/居中/右居中/左下角/下居中</para>
        /// </param>
        /// <returns>处理后的图片路径</returns>
        public static string ImageWatermark(string filePath, int size, string letter, Color color, string location)
        {
            string kz_name = Path.GetExtension(filePath);
            if (kz_name == ".jpg" || kz_name == ".bmp" || kz_name == ".jpeg")
            {
                DateTime time = DateTime.Now;
                string filename = "" + time.Year.ToString() + time.Month.ToString() + time.Day.ToString() + time.Hour.ToString() + time.Minute.ToString() + time.Second.ToString() + time.Millisecond.ToString();
                using (Image img = Bitmap.FromFile(filePath))
                using (Graphics g = Graphics.FromImage(img))
                {
                    //设置合成图像的渲染质量
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    //设置高质量插值法
                    g.InterpolationMode = InterpolationMode.High;
                    //设置高质量,低速度呈现平滑程度
                    g.SmoothingMode = SmoothingMode.HighQuality;

                    ArrayList loca = GetLocation(location, img, size, letter.Length);
                    Font font = new Font("宋体", size);
                    Brush br = new SolidBrush(color);
                    g.DrawString(letter, font, br, float.Parse(loca[0].ToString()), float.Parse(loca[1].ToString()));
                    g.Dispose();
                    string newpath = Path.GetDirectoryName(filePath) + filename + kz_name;
                    img.Save(newpath);
                    img.Dispose();
                    File.Copy(newpath, filePath, true);
                    if (File.Exists(newpath))
                    {
                        File.Delete(newpath);
                    }
                }
            }
            return filePath;
        }
        /// <summary>
        /// 图片附加水印处理
        /// <para>文字水印</para>
        /// </summary>
        /// <param name="location">位置代码</param>
        /// <param name="img">图片对象</param>
        /// <param name="width">宽(当水印类型为文字时,传过来的就是字体的大小)</param>
        /// <param name="height">高(当水印类型为文字时,传过来的就是字符的长度)</param>
        /// <returns>文字水印位置</returns>
        private static ArrayList GetLocation(string location, Image img, int width, int height)
        {
            ArrayList loca = new ArrayList();  //定义数组存储位置
            float x = 10;
            float y = 10;

            if (location == "LT")
            {
                loca.Add(x);
                loca.Add(y);
            }
            else if (location == "T")
            {
                x = img.Width / 2 - (width * height) / 2;
                loca.Add(x);
                loca.Add(y);
            }
            else if (location == "RT")
            {
                x = img.Width - width * height;
            }
            else if (location == "LC")
            {
                y = img.Height / 2;
            }
            else if (location == "C")
            {
                x = img.Width / 2 - (width * height) / 2;
                y = img.Height / 2;
            }
            else if (location == "RC")
            {
                x = img.Width - height;
                y = img.Height / 2;
            }
            else if (location == "LB")
            {
                y = img.Height - width - 5;
            }
            else if (location == "B")
            {
                x = img.Width / 2 - (width * height) / 2;
                y = img.Height - width - 5;
            }
            else
            {
                x = img.Width - width * height;
                y = img.Height - width - 5;
            }
            loca.Add(x);
            loca.Add(y);
            return loca;
        }

        #endregion

        #region 图片 & Base64 转换

        /// <summary>
        /// 将图片转换为 Base64 字符串（PNG、JGP、JPG、JPEG）
        /// <para>包含图片前缀信息</para>
        /// <para>如： data:image/png;base64,</para>
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <returns>Base64字符串</returns>
        public static string ImageToBase64IncludePrefix(string filePath)
        {
            var extValue = Path.GetExtension(filePath);
            var prefix = string.Empty;
            switch (extValue)
            {
                case ".png":
                    prefix = "data:image/png;base64,";
                    break;
                case ".jgp":
                    prefix = "data:image/jgp;base64,";
                    break;
                case ".jpg":
                    prefix = "data:image/jpg;base64,";
                    break;
                case ".jpeg":
                    prefix = "data:image/jpeg;base64,";
                    break;
                default:
                    break;
            }
            return $"{prefix}{ImageToBase64(filePath)}";
        }
        /// <summary>
        /// 将图片转换为 Base64 字符串（PNG、JGP、JPG、JPEG）
        /// <para>不包含图片前缀信息</para>
        /// <para>如： data:image/png;base64,</para>
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <returns>Base64字符串</returns>
        public static string ImageToBase64(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return string.Empty;
            }
            using (var bitmap = new Bitmap(filePath))
            {
                using (var memory = new MemoryStream())
                {
                    bitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bArray = new byte[memory.Length];
                    memory.Position = 0;
                    memory.Read(bArray, 0, (int)memory.Length);
                    memory.Close();
                    return Convert.ToBase64String(bArray);
                }
            }
        }
        /// <summary>
        /// 将 Base64 字符串转换为图片（PNG、JGP、JPG、JPEG）
        /// <para>包含图片前缀信息</para>
        /// <para>如： data:image/png;base64,</para>
        /// </summary>
        /// <param name="base64String">Base64 字符串</param>
        /// <returns>图片对象</returns>
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
        /// 将 Base64 字符串转换为图片（PNG、JGP、JPG、JPEG）
        /// <para>不包含图片前缀信息</para>
        /// <para>如： data:image/png;base64,</para>
        /// </summary>
        /// <param name="base64String">Base64 字符串</param>
        /// <returns>图片对象</returns>
        public static Bitmap ImageFromBase64(string base64String)
        {
            byte[] arr = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(arr))
            {
                var bmp = new Bitmap(ms);
                ms.Close();
                return bmp;
            }
        }

        #endregion

    }
}
