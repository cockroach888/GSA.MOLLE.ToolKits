//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2025 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：LifecycleOpsHelper.cs
// 项目名称：MinIO对象存储辅助工具集
// 创建时间：2025-11-01 10:19:29
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
/// MinIO 生命周期辅助操作
/// </summary>
internal partial class MinIOHelper : ILifecycleOpsHelper
{
    /// <summary>
    /// 为存储桶设置生命周期规则
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <param name="lifecycleRule">生命周期规则定义</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async Task LifecycleSetAsync(string bucketName, LifecycleRuleModel lifecycleRule)
    {
        LifecycleRule rule = new()
        {
            ID = string.IsNullOrWhiteSpace(lifecycleRule.RuleId) ? Guid.NewGuid().ToString("N").ToLowerInvariant() : lifecycleRule.RuleId,
            Expiration = new Expiration()
            {
                Days = lifecycleRule.ExpirationDay <= 0 ? 30 : lifecycleRule.ExpirationDay
            },
            Status = lifecycleRule.IsEnabled is true ? LifecycleRule.LifecycleRuleStatusEnabled : LifecycleRule.LifecycleRuleStatusDisabled,
            Filter = string.IsNullOrWhiteSpace(lifecycleRule.FilterString) is true ? null : new RuleFilter()
            {
                Prefix = lifecycleRule.FilterString
            }
        };

        LifecycleConfiguration config = new([rule]);

        SetBucketLifecycleArgs args = new SetBucketLifecycleArgs()
                                          .WithBucket(bucketName)
                                          .WithLifecycleConfiguration(config);

        await _minioClient.SetBucketLifecycleAsync(args).ConfigureAwait(false);
    }

    /// <summary>
    /// 获取存储桶的生命周期规则配置信息
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <returns>生命周期配置信息</returns>
    public async Task<LifecycleConfiguration> LifecycleGetAsync(string bucketName)
    {
        var args = new GetBucketLifecycleArgs().WithBucket(bucketName);
        return await _minioClient.GetBucketLifecycleAsync(args).ConfigureAwait(false);
    }

    /// <summary>
    /// 移除存储桶的生命周期规则配置信息
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async Task LifecycleRemoveAsync(string bucketName)
    {
        var args = new RemoveBucketLifecycleArgs().WithBucket(bucketName);
        await _minioClient.RemoveBucketLifecycleAsync(args).ConfigureAwait(false);
    }
}