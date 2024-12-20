﻿//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：IMinIOHelper.cs
// 项目名称：MinIO对象存储辅助工具集
// 创建时间：2024-12-11 10:20:11
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
/// MinIO 对象存储访问助手接口
/// </summary>
public interface IMinIOHelper : IDisposable
{
    /// <summary>
    /// MinIO 存储桶辅助操作
    /// </summary>
    IBucketOpsHelper BucketOps { get; }

    /// <summary>
    /// MinIO 存储对象辅助操作
    /// </summary>
    IObjectOpsHelper ObjectOps { get; }

    /// <summary>
    /// MinIO 存储预指定URL辅助操作
    /// </summary>
    IPresignedOpsHelper PresignedOps { get; }
}