//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：IObjectOpsHelper.cs
// 项目名称：MinIO对象存储辅助工具集
// 创建时间：2024-12-11 15:11:47
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
/// MinIO 存储对象辅助操作接口
/// </summary>
public interface IObjectOpsHelper
{
    /// <summary>
    /// 判断存储桶中是否存在某存储对象
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <param name="objectName">对象路径与名称</param>
    /// <param name="versionId">版本编号</param>
    /// <returns>true 存在 / false 不存在</returns>
    Task<bool> ObjectExistsAsync(string bucketName, string objectName, string? versionId = null);

    /// <summary>
    /// 推送存储对象到存储桶中，当已存在时自动覆盖。
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <param name="objectName">对象路径与名称</param>
    /// <returns>true 成功 / false 失败</returns>
    Task<bool> ObjectPutAsync(string bucketName, string objectName);

    /// <summary>
    /// 判断存储桶中是否存在某存储对象，不存在则推送。
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <param name="objectName">对象路径与名称</param>
    /// <returns>true 成功 / false 失败</returns>
    Task<bool> ObjectExistsAndPutAsync(string bucketName, string objectName);

    /// <summary>
    /// 判断存储桶中是否存在某存储对象，存在则获取。
    /// </summary>
    /// <param name="bucketName"></param>
    /// <param name="objectName"></param>
    /// <returns></returns>
    Task<bool> ObjectExistsAndGetAsync(string bucketName, string objectName);

    /// <summary>
    /// 判断存储桶中是否存在某存储对象，存在则移除。
    /// </summary>
    /// <param name="bucketName">存储桶名称</param>
    /// <param name="objectName">对象路径与名称</param>
    /// <param name="versionId">版本编号</param>
    /// <returns>true 成功 / false 失败</returns>
    Task<bool> ObjectExistsAndRemoveAsync(string bucketName, string objectName, string? versionId = null);
}