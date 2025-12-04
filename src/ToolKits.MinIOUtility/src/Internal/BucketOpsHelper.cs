//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：BucketOpsHelper.cs
// 项目名称：MinIO对象存储辅助工具集
// 创建时间：2024-12-11 15:11:02
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using Minio.Exceptions;

namespace GSA.ToolKits.MinIOUtility.Internal;

/// <summary>
/// MinIO 存储桶辅助操作
/// </summary>
internal partial class MinIOHelper : IBucketOpsHelper
{
    /// <summary>
    /// 判断存储桶是否存在
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <returns>true 存在 / false 不存在</returns>
    public async Task<bool> BucketExistsAsync(string bucketName)
    {
        var args = new BucketExistsArgs().WithBucket(bucketName);
        return await _minioClient.BucketExistsAsync(args).ConfigureAwait(false);
    }

    /// <summary>
    /// 判断存储桶是否存在，不存在则创建。
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <returns>true 成功 / false 失败</returns>
    public async Task<bool> BucketExistsAndCreateAsync(string bucketName)
    {
        if (await BucketExistsAsync(bucketName).ConfigureAwait(false) is false)
        {
            try
            {
                var args = new MakeBucketArgs().WithBucket(bucketName);
                await _minioClient.MakeBucketAsync(args).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToLowerInvariant();
                if (message.Contains("bucketalready") is false ||
                    message.Contains("bucket already") is false)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        return await BucketExistsAsync(bucketName).ConfigureAwait(false);
    }

    /// <summary>
    /// 判断存储桶是否存在，存在则移除。
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <returns>true 成功 / false 失败</returns>
    public async Task<bool> BucketExistsAndRemoveAsync(string bucketName)
    {
        if (await BucketExistsAsync(bucketName).ConfigureAwait(false) is true)
        {
            var args = new RemoveBucketArgs().WithBucket(bucketName);
            await _minioClient.RemoveBucketAsync(args).ConfigureAwait(false);
        }

        return await BucketExistsAsync(bucketName).ConfigureAwait(false) is false;
    }
}