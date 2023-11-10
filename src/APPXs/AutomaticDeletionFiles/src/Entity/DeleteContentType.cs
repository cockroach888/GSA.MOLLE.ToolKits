﻿//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：DeleteContentType.cs
// 项目名称：自动删除文件工具
// 创建时间：2023-11-10 16:25:30
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.AutomaticDeletionFiles.Entity;

/// <summary>
/// 文件删除内容的类型枚举类
/// </summary>
public enum DeleteContentType
{
    /// <summary>
    /// 文件夹名称
    /// </summary>
    Folder,

    /// <summary>
    /// 文件名称
    /// </summary>
    FileName,

    /// <summary>
    /// 文件类型
    /// </summary>
    FileType
}