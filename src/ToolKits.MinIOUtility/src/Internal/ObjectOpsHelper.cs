//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：ObjectOpsHelper.cs
// 项目名称：MinIO对象存储辅助工具集
// 创建时间：2024-12-11 15:12:29
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using Minio.DataModel;

namespace GSA.ToolKits.MinIOUtility.Internal;

/// <summary>
/// MinIO 存储对象辅助操作
/// </summary>
internal partial class MinIOHelper : IObjectOpsHelper
{
    /// <summary>
    /// 判断存储桶中是否存在某存储对象
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <param name="objectName">对象路径与名称</param>
    /// <param name="versionId">版本编号</param>
    /// <returns>true 存在 / false 不存在</returns>
    public async Task<bool> ObjectExistsAsync(string bucketName, string objectName, string? versionId = null)
    {
        var args = new StatObjectArgs().WithBucket(bucketName).WithObject(objectName);
        if (string.IsNullOrWhiteSpace(versionId) is false)
        {
            args.WithVersionId(versionId);
        }

        bool result = false;
        try
        {
            ObjectStat stat = await _minioClient.StatObjectAsync(args).ConfigureAwait(false);
            result = stat.Size > 0;
        }
        catch { }
        return result;
    }

    /// <summary>
    /// 推送存储对象到存储桶中，当已存在时自动覆盖。
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <param name="objectName">对象路径与名称</param>
    /// <param name="stream">数据流</param>
    /// <param name="mimeType">MIME类型</param>
    /// <returns>true 成功 / false 失败</returns>
    public async Task<bool> ObjectPutAsync(string bucketName, string objectName, Stream stream, string mimeType)
    {
        var args = new PutObjectArgs().WithBucket(bucketName)
                                      .WithObject(objectName)
                                      .WithStreamData(stream)
                                      .WithObjectSize(stream.Length)
                                      .WithContentType(mimeType);

        _ = await _minioClient.PutObjectAsync(args).ConfigureAwait(false);

        return await ObjectExistsAsync(bucketName, objectName).ConfigureAwait(false);
    }

    /// <summary>
    /// 判断存储桶中是否存在某存储对象，不存在则推送。
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <param name="objectName">对象路径与名称</param>
    /// <param name="stream">数据流</param>
    /// <param name="mimeType">MIME类型</param>
    /// <returns>true 成功 / false 失败</returns>
    public async Task<bool> ObjectExistsAndPutAsync(string bucketName, string objectName, Stream stream, string mimeType)
    {
        if (await ObjectExistsAsync(bucketName, objectName).ConfigureAwait(false) is false)
        {
            return await ObjectPutAsync(bucketName, objectName, stream, mimeType).ConfigureAwait(false);
        }

        return true;
    }

    /// <summary>
    /// 判断存储桶中是否存在某存储对象，存在则获取。
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <param name="objectName">对象路径与名称</param>
    /// <param name="versionId">版本编号</param>
    /// <returns>包含存储对象的数据流</returns>
    public async Task<Stream?> ObjectExistsAndGetWithStreamAsync(string bucketName, string objectName, string? versionId = null)
    {
        Stream? result = null;

        if (await ObjectExistsAsync(bucketName, objectName, versionId).ConfigureAwait(false) is true)
        {
            var args = new GetObjectArgs().WithBucket(bucketName)
                                          .WithObject(objectName)
                                          .WithCallbackStream(async (stream) =>
                                          {
                                              MemoryStream ms = new();
                                              await stream.CopyToAsync(ms).ConfigureAwait(false);
                                              ms.Position = 0;
                                              result = ms;
                                              using (stream) { }
                                          });

            if (string.IsNullOrWhiteSpace(versionId) is false)
            {
                args.WithVersionId(versionId);
            }

            _ = await _minioClient.GetObjectAsync(args).ConfigureAwait(false);
        }

        return result;
    }

    /// <summary>
    /// 判断存储桶中是否存在某存储对象，存在则获取。
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <param name="objectName">对象路径与名称</param>
    /// <param name="fileSaveFullPath">用于保存存储对象到本地的全文件路径</param>
    /// <param name="versionId">版本编号</param>
    /// <returns>true 成功 / false 失败</returns>
    public async Task<bool> ObjectExistsAndGetWithFileAsync(string bucketName, string objectName, string fileSaveFullPath, string? versionId = null)
    {
        if (await ObjectExistsAsync(bucketName, objectName, versionId).ConfigureAwait(false) is true)
        {
            var args = new GetObjectArgs().WithBucket(bucketName)
                                          .WithObject(objectName)
                                          .WithFile(fileSaveFullPath);

            if (string.IsNullOrWhiteSpace(versionId) is false)
            {
                args.WithVersionId(versionId);
            }

            _ = await _minioClient.GetObjectAsync(args).ConfigureAwait(false);
        }

        return File.Exists(fileSaveFullPath);
    }

    /// <summary>
    /// 判断存储桶中是否存在某存储对象，存在则移除。
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <param name="objectName">对象路径与名称</param>
    /// <param name="versionId">版本编号</param>
    /// <returns>true 成功 / false 失败</returns>
    public async Task<bool> ObjectExistsAndRemoveAsync(string bucketName, string objectName, string? versionId = null)
    {
        if (await ObjectExistsAsync(bucketName, objectName, versionId).ConfigureAwait(false) is true)
        {
            var args = new RemoveObjectArgs().WithBucket(bucketName).WithObject(objectName);
            if (string.IsNullOrWhiteSpace(versionId) is false)
            {
                args.WithVersionId(versionId);
            }

            await _minioClient.RemoveObjectAsync(args).ConfigureAwait(false);
        }

        return !await ObjectExistsAsync(bucketName, objectName, versionId).ConfigureAwait(false);
    }
}