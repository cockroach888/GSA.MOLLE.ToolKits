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
}