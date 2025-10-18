//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：PictureBase64Helper.cs
// 项目名称：图像辅助与应用工具集
// 创建时间：2024-12-10 16:28:44
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
/// 图像Base64编码助手类
/// </summary>
internal static class PictureBase64Helper
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
            base64String = base64String[(index + 1)..];
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
        using Stream stream = await StreamFromBase64WithoutPrefixAsync(base64String).ConfigureAwait(false);
        return await Image.LoadAsync(stream).ConfigureAwait(false);
    }



    /// <summary>
    /// 将包含前缀的Base64字符串转换为内存流
    /// </summary>
    /// <param name="base64String">包含前缀的Base64字符串</param>
    /// <returns>图像内存流对象 (外部使用完后必须释放)</returns>
    public static async Task<Stream> StreamFromBase64Async(string base64String)
    {
        int index = base64String.IndexOf(',');

        if (index > 0)
        {
            base64String = base64String[(index + 1)..];
        }

        return await StreamFromBase64WithoutPrefixAsync(base64String).ConfigureAwait(false);
    }

    /// <summary>
    /// 将不包含前缀的Base64字符串转换为内存流
    /// </summary>
    /// <param name="base64String">不包含前缀的Base64字符串</param>
    /// <returns>图像内存流对象 (外部使用完后必须释放)</returns>
    public static async Task<Stream> StreamFromBase64WithoutPrefixAsync(string base64String)
    {
        byte[] buffer = await DecodeBase64OptimizedAsync(base64String).ConfigureAwait(false);
        return new MemoryStream(buffer);
    }



    /// <summary>
    /// 解码检测图像Base64编码字符串
    /// </summary>
    /// <param name="base64String">检测图像Base64编码字符串</param>
    /// <returns>检测图像数据流</returns>
    private static async Task<byte[]> DecodeBase64OptimizedAsync(string base64String)
    {
        int bufferSize = GetBase64DecodeLength(base64String);
        var buffer = new byte[bufferSize];

        if (Convert.TryFromBase64String(base64String, buffer, out int bytesWritten))
        {
            return buffer.AsMemory(0, bytesWritten).ToArray();
        }

        return await Task.Run(() => Convert.FromBase64String(base64String)).ConfigureAwait(false);
    }

    /// <summary>
    /// 获取Base64字符串数据长度
    /// </summary>
    /// <param name="base64String">检测图像Base64编码字符串</param>
    /// <returns>检测图像Base64编码字符串长度</returns>
    private static int GetBase64DecodeLength(string base64String)
        => (base64String.Length * 3 / 4) - base64String.Count(c => c == '=');
}