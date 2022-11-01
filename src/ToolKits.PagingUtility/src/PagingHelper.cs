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
public static class PagingHelper
{
    /// <summary>
    /// 构建数据分页
    /// </summary>
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
        // 判断额外的和自定义参数是否自带参数分隔符
        if (options.ExtraParameters is not null &&
            !string.IsNullOrWhiteSpace(options.ExtraParameters) &&
            !options.ExtraParameters.StartsWith(","))
        {
            options.ExtraParameters.Insert(0, ",");
        }

        // 数据分页标签Id
        if (!string.IsNullOrWhiteSpace(options.PagingTagId))
        {
            options.PagingTagId = $" id=\"{options.PagingTagId}\"";
        }

        // 数据分页标签Class
        if (!string.IsNullOrWhiteSpace(options.PagingTagClass))
        {
            options.PagingTagClass = $" class=\"{options.PagingTagClass}\"";
        }

        // 数据分页标签Style
        if (!string.IsNullOrWhiteSpace(options.PagingTagStyle))
        {
            options.PagingTagStyle = $" style=\"{options.PagingTagStyle}\"";
        }

        // 数据分页项Class
        if (!string.IsNullOrWhiteSpace(options.PagingItemClass))
        {
            options.PagingItemClass = $" {options.PagingItemClass}";
        }

        // 数据分页项Style
        if (!string.IsNullOrWhiteSpace(options.PagingItemStyle))
        {
            options.PagingItemStyle = $" style=\"{options.PagingItemStyle}\"";
        }
    }
}