//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MinIOHelper.cs
// 项目名称：MinIO对象存储辅助工具集
// 创建时间：2024-12-11 10:21:12
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using Minio;

namespace GSA.ToolKits.MinIOUtility.Internal;

/// <summary>
/// MinIO 对象存储访问助手
/// </summary>
internal partial class MinIOHelper(MinIOOptions options) : IMinIOHelper
{
    internal readonly IMinioClient _minioClient = new MinioClient()
        .WithEndpoint(options.MinioHost, options.MinioPort)
        .WithCredentials(options.MinioAccessKey, options.MinioSecretKey)
        .Build();


    #region 接口实现[IMinIOHelper]

    /// <summary>
    /// MinIO 存储桶辅助操作
    /// </summary>
    public IBucketOpsHelper BucketOps => this;

    /// <summary>
    /// MinIO 存储对象辅助操作
    /// </summary>
    public IObjectOpsHelper ObjectOps => this;

    /// <summary>
    /// MinIO 存储预指定URL辅助操作
    /// </summary>
    public IPresignedOpsHelper PresignedOps => this;

    #endregion


    /// <summary>
    /// 资源释放
    /// </summary>
    public void Dispose()
    {
        using (_minioClient) { }
        GC.SuppressFinalize(this);
    }
}