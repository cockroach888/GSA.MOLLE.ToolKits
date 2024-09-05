﻿//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2024 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：PaginationQuery.cs
// 项目名称：WebAPI接口辅助与应用工具集
// 创建时间：2024-09-05 15:00:28
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.WebAPIsUtility;

/// <summary>
/// 数据分页查询参数实体类
/// </summary>
[Serializable]
public sealed class PaginationQuery
{
    /// <summary>
    /// 分页大小
    /// </summary>
    /// <remarks>表示每页显示的数据数量。</remarks>
    [JsonPropertyName("PageSize")]
    public int PageSize { get; set; }

    /// <summary>
    /// 页码
    /// </summary>
    /// <remarks>指定要显示的页码。</remarks>
    [JsonPropertyName("PageNumber")]
    public int PageNumber { get; set; }
}