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
        // 人生大事，莫过于__________。
        PagingHelper.Validate(options);

        StringBuilder sb = new();

        sb.Append($"<nav aria-label=\"Page Paging Pagination navigation\"{options.PagingTagIdHtml}{options.PagingTagClassHtml}{options.PagingTagStyleHtml}>");
        sb.Append("<ul class=\"pagination m-auto\">");

        if (options.TotalRecords <= 0)
        {
            sb.Append($"<li class=\"page-item{options.PagingItemClassHtml}\"{options.PagingItemStyleHtml}>");
            sb.Append($"<span class=\"page-link\">{options.NoDataRecordedTips}</span>");
            sb.Append("</li>");
        }
        else
        {
            // 儒家圣人说了，顺序不可乱。
            GetPreviousPage(sb, options);
            GetFirstPage(sb, options);

            GetSeparator(sb, options, true);
            GetDigitalPage(sb, options);
            GetSeparator(sb, options, false);

            GetLastPage(sb, options);
            GetNextPage(sb, options);

            GetJumpToPage(sb, options);
            GetPagingInfo(sb, options);
        }

        sb.Append("</ul>");
        sb.Append("</nav>");

        return sb.ToString();
    }

    /// <summary>
    /// 分隔符
    /// </summary>
    /// <param name="sb">可变的字符串生成器</param>
    /// <param name="options">数据分页选项(参数)</param>
    /// <param name="isFirstOrLast">属于首页还是末页分隔符。（true 首页 | false 末页）</param>
    private static void GetSeparator(StringBuilder sb, PagingOptions options, bool isFirstOrLast)
    {
        // 首页 & 末页
        int count = options.DigitalPageStart + options.DigitalPageCount;

        if (isFirstOrLast &&
            options.DigitalPageStart - 1 == 1)
        {
            return;
        }

        if (!isFirstOrLast &&
            (options.TotalPages == count ||
            count > options.TotalPages))
        {
            return;
        }

        sb.Append($"<li class=\"page-item{options.PagingItemClassHtml}\"{options.PagingItemStyleHtml}>");
        sb.Append("<a class=\"page-link\" href=\"javascript:void(0)\">");
        sb.Append("<span aria-hidden=\"true\">&hellip;</span>");
        sb.Append("</a>");
        sb.Append("</li>");
    }

    /// <summary>
    /// 分页跳转
    /// </summary>
    /// <param name="sb">可变的字符串生成器</param>
    /// <param name="options">数据分页选项(参数)</param>
    private static void GetJumpToPage(StringBuilder sb, PagingOptions options)
    {
        if (options.IsUsePagingJump is false)
        {
            return;
        }

        sb.Append($"<li class=\"page-item{options.PagingItemClassHtml}\"{options.PagingItemStyleHtml}>");
        sb.Append($"<span class=\"page-link bg-transparent border-0\">共{options.TotalPages}页，到第</span>");
        sb.Append("</li>");

        sb.Append($"<li class=\"page-item{options.PagingItemClassHtml}\"{options.PagingItemStyleHtml}>");
        sb.Append($"<input class=\"form-control rounded-0\" style=\"width:{options.PagingJumpTextWidth}px;\" type=\"text\" placeholder=\"{options.CurrentPage}\" aria-label=\"跳转到第几页\" id=\"{options.PagingJumpTextId}\">");
        sb.Append("</li>");

        sb.Append($"<li class=\"page-item{options.PagingItemClassHtml}\"{options.PagingItemStyleHtml}>");
        sb.Append($"<a class=\"page-link\" href=\"javascript:void(0)\" onclick=\"{options.PagingJumpFunction}({options.PaginationSize})\">确定</a>");
        sb.Append("</li>");
    }

    /// <summary>
    /// 数据分页信息
    /// </summary>
    /// <param name="sb">可变的字符串生成器</param>
    /// <param name="options">数据分页选项(参数)</param>
    private static void GetPagingInfo(StringBuilder sb, PagingOptions options)
    {
        // 分页信息
        sb.Append($"<li class=\"page-item{options.PagingItemClassHtml}\"{options.PagingItemStyleHtml}>");
        sb.Append($"<span class=\"page-link bg-transparent border-0\">共{options.TotalRecords}条，每页</span>");
        sb.Append("</li>");

        // 分页大小 rounded-0
        sb.Append($"<li class=\"page-item{options.PagingItemClassHtml}\"{options.PagingItemStyleHtml}>");
        sb.Append("<div class=\"dropdown\">");
        sb.Append($"<a class=\"page-link btn btn-secondary btn-sm dropdown-toggle\" href=\"javascript:void(0)\" role=\"button\" data-bs-toggle=\"dropdown\" aria-expanded=\"false\">{options.PaginationSize}</a>");
        sb.Append("<ul class=\"dropdown-menu\">");

        foreach (int item in options.PaginationSizeRange)
        {
            if (item != options.PaginationSize)
            {
                sb.Append($"<li><a class=\"dropdown-item\" href=\"javascript:void(0)\" onclick=\"{options.PagingFunction}({options.CurrentPage},{item}{options.ExtraParameters})\">{item}</a></li>");
            }
            else
            {
                sb.Append($"<li><a class=\"dropdown-item disabled\" href=\"javascript:void(0)\">{item}</a></li>");
            }
        }

        /*
        <select class="form-select" aria-label="Pagination Size">
            <option value="25" selected>25</option>
            <option value="50">50</option>
            <option value="75">75</option>
            <option value="100">100</option>
        </select>
        */

        sb.Append("</ul>");
        sb.Append("</div>");
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
            onclickString = $" onclick=\"{options.PagingFunction}({options.PreviousPage},{options.PaginationSize}{options.ExtraParameters})\"";
        }
        else if (options.IsUseDisabledMode)
        {
            stateString = " disabled";
        }

        sb.Append($"<li class=\"page-item{options.PagingItemClassHtml}{stateString}\"{options.PagingItemStyleHtml}>");
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
            onclickString = $" onclick=\"{options.PagingFunction}(1,{options.PaginationSize}{options.ExtraParameters})\"";
        }

        sb.Append($"<li class=\"page-item{options.PagingItemClassHtml}{stateString}\"{currentString}{options.PagingItemStyleHtml}>");
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

        int iLen = options.DigitalPageStart + options.DigitalPageCount - 1;

        if (iLen >= options.TotalPages)
        {
            iLen = options.TotalPages - 1;
        }

        string stateString = string.Empty;
        string onclickString = string.Empty;
        string currentString = string.Empty;

        for (int i = options.DigitalPageStart; i <= iLen; i++)
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
                onclickString = $" onclick=\"{options.PagingFunction}({i},{options.PaginationSize}{options.ExtraParameters})\"";
            }

            sb.Append($"<li class=\"page-item{options.PagingItemClassHtml}{stateString}\"{currentString}{options.PagingItemStyleHtml}>");
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
            onclickString = $" onclick=\"{options.PagingFunction}({options.TotalPages},{options.PaginationSize}{options.ExtraParameters})\"";
        }

        sb.Append($"<li class=\"page-item{options.PagingItemClassHtml}{stateString}\"{currentString}{options.PagingItemStyleHtml}>");
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
            onclickString = $" onclick=\"{options.PagingFunction}({options.NextPage},{options.PaginationSize}{options.ExtraParameters})\"";
        }
        else if (options.IsUseDisabledMode)
        {
            stateString = " disabled";
        }

        sb.Append($"<li class=\"page-item{options.PagingItemClassHtml}{stateString}\"{options.PagingItemStyleHtml}>");
        sb.Append($"<a class=\"page-link rounded-end\" href=\"javascript:void(0)\" aria-label=\"Next\"{onclickString}>");
        sb.Append("<span aria-hidden=\"true\">&raquo;</span>");
        sb.Append("</a>");
        sb.Append("</li>");
    }
}