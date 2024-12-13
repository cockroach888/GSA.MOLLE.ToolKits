//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：PresignedOpsHelper.cs
// 项目名称：MinIO对象存储辅助工具集
// 创建时间：2024-12-11 15:13:38
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.MinIOUtility.Internal;

/// <summary>
/// MinIO 存储预指定URL辅助操作
/// </summary>
internal partial class MinIOHelper : IPresignedOpsHelper
{
    /// <summary>
    /// 获取用于某存储桶中某存储对象的预指定URL预览地址
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <param name="objectName">对象路径与名称</param>
    /// <param name="expiryThreshold">预指定URL的过期时间阈值 (为空时使用配置值)</param>
    /// <returns>预指定URL预览地址</returns>
    public async Task<string> PresignedObjectGetAsync(string bucketName, string objectName, TimeSpan? expiryThreshold)
    {
        var args = new PresignedGetObjectArgs().WithBucket(bucketName)
                                               .WithObject(objectName)
                                               .WithExpiry(GetTotalSeconds(expiryThreshold))
                                               .WithHeaders(new Dictionary<string, string>(StringComparer.Ordinal)
                                               {
                                                   { "response-content-type", "application/json" }
                                               });

        return await _minioClient.PresignedGetObjectAsync(args).ConfigureAwait(false);
    }

    /// <summary>
    /// 获取用于某存储桶推送存储对象的预指定URL地址
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <param name="objectName">对象路径与名称</param>
    /// <param name="expiryThreshold">预指定URL的过期时间阈值 (为空时使用配置值)</param>
    /// <returns>预指定URL推送地址</returns>
    public async Task<string> PresignedObjectPutAsync(string bucketName, string objectName, TimeSpan? expiryThreshold)
    {
        var args = new PresignedPutObjectArgs().WithBucket(bucketName)
                                               .WithObject(objectName)
                                               .WithExpiry(GetTotalSeconds(expiryThreshold));

        return await _minioClient.PresignedPutObjectAsync(args).ConfigureAwait(false);
    }

    /// <summary>
    /// 获取 TimeSpan 所表示的总秒数
    /// </summary>
    /// <param name="timeSpan">TimeSpan 时间间隔</param>
    /// <returns>总秒数</returns>
    private int GetTotalSeconds(TimeSpan? timeSpan)
    {
        if (timeSpan.HasValue is true && timeSpan > TimeSpan.Zero)
        {
            return (int)timeSpan.Value.TotalSeconds;
        }

        return (int)options.URLExpiryThreshold.TotalSeconds;
    }
}