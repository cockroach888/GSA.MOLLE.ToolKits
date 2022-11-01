//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：BootstrapV5UI.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-10-31 21:16:48
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Text;

namespace GSA.ToolKits.PagingUtility.Internal;

/// <summary>
/// 基于 Bootstrap V5 版本构建的数据分页
/// </summary>
internal static class BootstrapV5UI
{
    /// <summary>
    /// 创建数据分页
    /// </summary>
    /// <param name="options">数据分页选项(参数)</param>
    /// <returns>数据分页</returns>
    public static string Create(PagingOptions options)
    {
        PagingHelper.Validate(options);

        StringBuilder sb = new();

        sb.Append($"<nav aria-label=\"Page Paging navigation\"{options.PagingTagId}{options.PagingTagClass}{options.PagingTagStyle}>");
        sb.Append("<ul class=\"pagination m-auto\">");

        // 儒家圣人说了，顺序不可乱。
        GetPreviousPage(sb, options);
        GetFirstPage(sb, options);

        GetSeparator(sb, options, 1);
        GetDigitalPage(sb, options);
        GetSeparator(sb, options, 2);

        GetLastPage(sb, options);
        GetNextPage(sb, options);

        sb.Append($"</ul>");
        sb.Append($"</nav>");

        return sb.ToString();
    }

    /// <summary>
    /// 分隔符
    /// </summary>
    /// <param name="sb">可变的字符串生成器</param>
    /// <param name="options">数据分页选项(参数)</param>
    /// <param name="isFirstOrLast">属于首页还是末页分隔符。（1 首页 | 2 末页）</param>
    private static void GetSeparator(StringBuilder sb, PagingOptions options, byte isFirstOrLast)
    {
        if (options.TotalPages <= options.DigitalPageCount + 2)
        {
            return;
        }

        // 首页
        if (isFirstOrLast == 1 &&
            options.DigitalPageStart - 1 == 1)
        {
            return;
        }

        // 末页
        int count = options.DigitalPageCount + options.DigitalPageStart;
        if (isFirstOrLast == 2 &&
            (options.TotalPages - 1 == count ||
            options.TotalPages == count))
        {
            return;
        }

        sb.Append($"<li class=\"page-item{options.PagingItemClass}\"{options.PagingItemStyle}>");
        sb.Append($"<a class=\"page-link\" href=\"javascript:void(0)\">");
        sb.Append("<span aria-hidden=\"true\">&hellip;</span>");
        sb.Append("</a>");
        sb.Append("</li>");
    }

    /// <summary>
    /// 上一页
    /// </summary>
    /// <param name="sb">可变的字符串生成器</param>
    /// <param name="options">数据分页选项(参数)</param>
    private static void GetPreviousPage(StringBuilder sb, PagingOptions options)
    {
        string stateString = string.Empty;
        string onclickString = string.Empty;

        if (options.CurrentPage > 1)
        {
            onclickString = $" onclick=\"{options.PagingFunction}({options.PreviousPage}{options.ExtraParameters})\"";
        }
        else if (options.IsUseDisabledMode)
        {
            stateString = " disabled";
        }

        sb.Append($"<li class=\"page-item{options.PagingItemClass}{stateString}\"{options.PagingItemStyle}>");
        sb.Append($"<a class=\"page-link\" href=\"javascript:void(0)\" aria-label=\"Previous\"{onclickString}>");
        sb.Append("<span aria-hidden=\"true\">&laquo;</span>");
        sb.Append("</a>");
        sb.Append("</li>");
    }

    /// <summary>
    /// 首页
    /// </summary>
    /// <param name="sb">可变的字符串生成器</param>
    /// <param name="options">数据分页选项(参数)</param>
    private static void GetFirstPage(StringBuilder sb, PagingOptions options)
    {
        string stateString = string.Empty;
        string onclickString = string.Empty;
        string currentString = string.Empty;

        if (options.CurrentPage == 1)
        {
            currentString = " aria-current=\"page\"";
            stateString = " active";

            if (options.IsUseDisabledMode)
            {
                stateString = " disabled";
            }
        }
        else
        {
            onclickString = $" onclick=\"{options.PagingFunction}(1{options.ExtraParameters})\"";
        }

        sb.Append($"<li class=\"page-item{options.PagingItemClass}{stateString}\"{currentString}{options.PagingItemStyle}>");
        sb.Append($"<a class=\"page-link\" href=\"javascript:void(0)\"{onclickString}>1</a>");
        sb.Append("</li>");
    }

    /// <summary>
    /// 数字分页
    /// </summary>
    /// <param name="sb">可变的字符串生成器</param>
    /// <param name="options">数据分页选项(参数)</param>
    private static void GetDigitalPage(StringBuilder sb, PagingOptions options)
    {
        if (options.TotalPages < 3)
        {
            return;
        }

        int iLen = options.DigitalPageStart + options.DigitalPageCount;

        if (iLen > options.TotalPages)
        {
            iLen = options.TotalPages;
        }

        if (options.DigitalPageStart == iLen)
        {
            iLen++;
        }

        string stateString = string.Empty;
        string onclickString = string.Empty;
        string currentString = string.Empty;

        for (int i = options.DigitalPageStart; i < iLen; i++)
        {
            if (options.CurrentPage == i)
            {
                currentString = " aria-current=\"page\"";
                stateString = " active";

                if (options.IsUseDisabledMode)
                {
                    stateString = " disabled";
                }
            }
            else
            {
                onclickString = $" onclick=\"{options.PagingFunction}({i}{options.ExtraParameters})\"";
            }

            sb.Append($"<li class=\"page-item{options.PagingItemClass}{stateString}\"{currentString}{options.PagingItemStyle}>");
            sb.Append($"<a class=\"page-link\" href=\"javascript:void(0)\"{onclickString}>{i}</a>");
            sb.Append("</li>");

            stateString = string.Empty;
            onclickString = string.Empty;
            currentString = string.Empty;
        }
    }

    /// <summary>
    /// 末页
    /// </summary>
    /// <param name="sb">可变的字符串生成器</param>
    /// <param name="options">数据分页选项(参数)</param>
    private static void GetLastPage(StringBuilder sb, PagingOptions options)
    {
        if (options.TotalPages < 2)
        {
            return;
        }

        string stateString = string.Empty;
        string onclickString = string.Empty;
        string currentString = string.Empty;

        if (options.CurrentPage == options.TotalPages)
        {
            currentString = " aria-current=\"page\"";
            stateString = " active";

            if (options.IsUseDisabledMode)
            {
                stateString = " disabled";
            }
        }
        else
        {
            onclickString = $" onclick=\"{options.PagingFunction}({options.TotalPages}{options.ExtraParameters})\"";
        }

        sb.Append($"<li class=\"page-item{options.PagingItemClass}{stateString}\"{currentString}{options.PagingItemStyle}>");
        sb.Append($"<a class=\"page-link\" href=\"javascript:void(0)\"{onclickString}>{options.TotalPages}</a>");
        sb.Append("</li>");
    }

    /// <summary>
    /// 下一页
    /// </summary>
    /// <param name="sb">可变的字符串生成器</param>
    /// <param name="options">数据分页选项(参数)</param>
    private static void GetNextPage(StringBuilder sb, PagingOptions options)
    {
        string stateString = string.Empty;
        string onclickString = string.Empty;

        if (options.CurrentPage < options.TotalPages)
        {
            onclickString = $" onclick=\"{options.PagingFunction}({options.NextPage}{options.ExtraParameters})\"";
        }
        else if (options.IsUseDisabledMode)
        {
            stateString = " disabled";
        }

        sb.Append($"<li class=\"page-item{options.PagingItemClass}{stateString}\"{options.PagingItemStyle}>");
        sb.Append($"<a class=\"page-link\" href=\"javascript:void(0)\" aria-label=\"Next\"{onclickString}>");
        sb.Append("<span aria-hidden=\"true\">&raquo;</span>");
        sb.Append("</a>");
        sb.Append("</li>");
    }
}