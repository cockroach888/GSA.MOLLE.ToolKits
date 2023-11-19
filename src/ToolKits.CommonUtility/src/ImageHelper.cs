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
using System.Drawing;

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
    public static Image ImageFromBase64(string base64String)
    {
        int index = base64String.IndexOf(',');

        if (index > 0)
        {
            base64String = base64String.Remove(0, index);
        }

        return ImageFromBase64(base64String);
    }

    /// <summary>
    /// 将不包含前缀的Base64字符串转换为图像
    /// </summary>
    /// <param name="base64String">不包含前缀的Base64字符串</param>
    /// <returns>图像对象 (外部使用完后必须释放)</returns>
    public static Image ImageFromBase64WithoutPrefix(string base64String)
    {
        byte[] buffer = Convert.FromBase64String(base64String);
        using MemoryStream ms = new(buffer);
        return Image.FromStream(ms);
    }
}