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
using System.Text;

namespace GSA.ToolKits.PagingUtility;

/// <summary>
/// 数据分页助手类
/// </summary>
public static class PagingHelper
{

    public static string Create(PagingOptions options)
    {
        StringBuilder sb = new();

        string id = string.Empty;
        if (!string.IsNullOrWhiteSpace(options.PagingTagId))
        {
            id = $" id=\"{options.PagingTagId}\"";
        }

        sb.Append($"<nav aria-label=\"Page Paging navigation\"{id}>");

        sb.Append($"<ul class=\"pagination m-auto\">");

        // 上一页
        if (options.CurrentPage > 1)
        {
            sb.Append($"");
        }
        else
        {
            sb.Append($"< li class=\"page-item disabled\">");
            sb.Append($"<a class=\"page-link\" href=\"javascript:void(0)\" aria-label=\"Previous\">");
            sb.Append($"<span aria-hidden=\"true\">&laquo;</span>");
            sb.Append($"</a>");
            sb.Append($"</li>");



            //< li class="page-item">
            //        <a class="page-link">
            //            
            //        </a>
            //    </li>
        }




        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");
        sb.Append($"");

        sb.Append($"</ul>");

        sb.Append($"</nav>");

        return sb.ToString();





        /*
         
            
                
                <li class="page-item"><a class="page-link" href="#">1</a></li>
                <li class="page-item active" aria-current="page"><a class="page-link" href="javascript:void(0)">2</a></li>
                <li class="page-item"><a class="page-link" href="#">3</a></li>
                <li class="page-item">
                    <a class="page-link" href="javascript:void(0)" aria-label="Next">
                        <span aria-hidden="true">&raquo;</span>
                    </a>
                </li>
            
           




    
    <li class="page-item"><a class="page-link" href="#">1</a></li>
    <li class="page-item active" aria-current="page">
      <a class="page-link" href="#">2</a>
    </li>
    <li class="page-item"><a class="page-link" href="#">3</a></li>
    <li class="page-item">
      <a class="page-link" href="#">Next</a>
    </li>



         */
    }
}