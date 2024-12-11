//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MinIOOptions.cs
// 项目名称：MinIO对象存储辅助工具集
// 创建时间：2024-12-11 10:36:47
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.MinIOUtility;

/// <summary>
/// MinIO 对象存储选项参数类
/// </summary>
/// <param name="minioHost">MinIO 主机地址</param>
/// <param name="minioPort">MinIO 端口号</param>
/// <param name="minioAccessKey">MinIO Access Key</param>
/// <param name="minioSecretKey">MinIO Secret Key</param>
/// <param name="imageExpiryThreshold">MinIO 存储对象生成URL时的过期时间阈值</param>
[Serializable]
public sealed class MinIOOptions(string minioHost, int minioPort, string minioAccessKey, string minioSecretKey, TimeSpan? imageExpiryThreshold = null)
{
    /// <summary>
    /// MinIO 主机地址
    /// </summary>
    public string MinioHost { get; set; } = minioHost;

    /// <summary>
    /// MinIO 端口号
    /// </summary>
    public int MinioPort { get; set; } = minioPort;

    /// <summary>
    /// MinIO Access Key
    /// </summary>
    public string MinioAccessKey { get; set; } = minioAccessKey;

    /// <summary>
    /// MinIO Secret Key
    /// </summary>
    public string MinioSecretKey { get; set; } = minioSecretKey;

    /// <summary>
    /// MinIO 存储对象生成URL时的过期时间阈值
    /// </summary>
    /// <remarks>默认7天</remarks>
    public TimeSpan ImageExpiryThreshold { get; set; } = imageExpiryThreshold ?? TimeSpan.FromDays(7);
}