//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：PagingHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-10-30 16:55:10
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.PagingUtility.Internal;

namespace GSA.ToolKits.PagingUtility;

/// <summary>
/// 数据分页助手类
/// </summary>
/// <remarks>JS函数首参数为当前页，次参数为分页大小。</remarks>
public static class PagingHelper
{
    /// <summary>
    /// 构建数据分页
    /// </summary>
    /// <remarks>JS函数首参数为当前页，次参数为分页大小。</remarks>
    /// <param name="uIType">数据分页UI类型</param>
    /// <param name="options">数据分页选项(参数)</param>
    /// <returns>数据分页</returns>
    public static string Builder(PagingUIType uIType, PagingOptions options)
        => uIType switch
        {
            PagingUIType.Bootstrap_V5 => BootstrapV5UI.Create(options),
            PagingUIType.Bootstrap_V4 => BootstrapV5UI.Create(options),
            PagingUIType.Bootstrap_V3 => BootstrapV5UI.Create(options),
            PagingUIType.CustomUI => BootstrapV5UI.Create(options),
            _ => string.Empty
        };

    /// <summary>
    /// 自动校验数据分页选项(参数)
    /// </summary>
    /// <param name="options">数据分页选项(参数)</param>
    internal static void Validate(PagingOptions options)
    {
        options.PaginationSizeRange ??= new int[4] { 25, 50, 75, 100 };
    }
}