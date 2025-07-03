//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2025 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：QueryResult.cs
// 项目名称：WebAPI接口辅助与应用工具集
// 创建时间：2025-07-03 16:17:54
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
/// 数据查询结果实体类
/// </summary>
/// <typeparam name="TData">响应数据泛型</typeparam>
[Serializable]
public class QueryResult<TData>
    where TData : class
{
    /// <summary>
    /// 响应状态码
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// 响应数据
    /// </summary>
    public TData? Data { get; set; }

    /// <summary>
    /// 响应描述
    /// </summary>
    public string? Desc { get; set; }
}


/// <summary>
/// 数据查询结果实体类
/// </summary>
/// <typeparam name="TData">响应数据泛型</typeparam>
/// <typeparam name="TMetadata">响应元数据泛型</typeparam>
[Serializable]
public class QueryResult<TData, TMetadata> : QueryResult<TData>
    where TData : class
    where TMetadata : class
{
    /// <summary>
    /// 响应元数据
    /// </summary>
    public TMetadata? Metadata { get; set; }
}