//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：IBucketOpsHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2024-12-11 15:10:21
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
/// MinIO 存储桶辅助操作接口
/// </summary>
public interface IBucketOpsHelper
{
    /// <summary>
    /// 判断存储桶是否存在
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <returns>true 存在 / false 不存在</returns>
    Task<bool> BucketExistsAsync(string bucketName);

    /// <summary>
    /// 判断存储桶是否存在，不存在则创建。
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <returns>true 成功 / false 失败</returns>
    Task<bool> BucketExistsAndCreateAsync(string bucketName);

    /// <summary>
    /// 判断存储桶是否存在，存在则移除。
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <returns>true 成功 / false 失败</returns>
    Task<bool> BucketExistsAndRemoveAsync(string bucketName);
}