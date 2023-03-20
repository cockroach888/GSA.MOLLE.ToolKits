//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：Program4PagingUtility.cs
// 项目名称：功能调测控制台程序
// 创建时间：2023-03-19 21:14:03
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.PagingUtility;

namespace GSA.ToolKits.DawnConsole;

/// <summary>
/// PagingUtility
/// </summary>
internal sealed class Program4PagingUtility
{

    #region 单例模式

    private static readonly Lazy<Program4PagingUtility> _lazyInstance = new(() => new Program4PagingUtility());

    /// <summary>
    /// PagingUtility
    /// </summary>
    internal static Program4PagingUtility Default => _lazyInstance.Value;

    #endregion


    /// <summary>
    /// 小心手雷，洞中开火。
    /// </summary>
    /// <remarks>输出花式数据分页形态</remarks>
    public void FireInTheHole()
    {
        PagingOptions options = new()
        {
            //ExtraParameters = "'test',33,89,'over'",
            //ExtraParameters = "'{msg:MaydayMaydayMayday}'",
            //PagingTagClass = "fs-2",
            //PagingTagStyle = "color:red;",
            //PagingItemClass = "fw-light",
            //PagingItemStyle = "font-style:italic;",
            CurrentPage = 5,
            PaginationSize = 50,
            TotalRecords = 30000
        };

        string pageString;


        // Page 0
        options.TotalRecords = 0;
        options.CurrentPage = 5;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 0: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();        


        // Page 1
        options.TotalRecords = 50;
        options.CurrentPage = 5;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 1: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 2
        options.TotalRecords = 100;
        options.CurrentPage = 5;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 2: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 3
        options.TotalRecords = 150;
        options.CurrentPage = 2;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 3: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 4
        options.TotalRecords = 200;
        options.CurrentPage = 3;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 4: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 5
        options.TotalRecords = 250;
        options.CurrentPage = 4;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 5: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 6
        options.TotalRecords = 300;
        options.CurrentPage = 5;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 6: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 7
        options.TotalRecords = 350;
        options.CurrentPage = 5;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 7: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 8
        options.TotalRecords = 400;
        options.CurrentPage = 6;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 8: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 9
        options.TotalRecords = 450;
        options.CurrentPage = 7;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 9: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 10
        options.TotalRecords = 500;
        options.CurrentPage = 8;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 10: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 11
        options.TotalRecords = 550;
        options.CurrentPage = 9;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 11: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 12
        options.TotalRecords = 600;
        options.CurrentPage = 10;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 12: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 13
        options.TotalRecords = 650;
        options.CurrentPage = 10;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 13: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 14
        options.TotalRecords = 700;
        options.CurrentPage = 10;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 14: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 15
        options.TotalRecords = 750;
        options.CurrentPage = 8;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 15: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 16
        options.TotalRecords = 800;
        options.CurrentPage = 9;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 16: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 17
        options.TotalRecords = 850;
        options.CurrentPage = 15;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 17: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 18
        options.TotalRecords = 900;
        options.CurrentPage = 17;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 18: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 19
        options.TotalRecords = 950;
        options.CurrentPage = 15;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 19: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 20
        options.TotalRecords = 1000;
        options.CurrentPage = 13;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 20: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 50
        options.TotalRecords = 2500;
        options.CurrentPage = 35;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 50: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 100
        options.TotalRecords = 5000;
        options.CurrentPage = 55;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 100: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 300
        options.TotalRecords = 15000;
        options.CurrentPage = 200;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 300: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        // Page 1000
        options.TotalRecords = 50000;
        options.CurrentPage = 650;
        pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

        //Console.WriteLine($"Page 1000: {pageString}");
        //Console.WriteLine();
        Console.WriteLine($"{pageString}");
        Console.WriteLine();


        Console.WriteLine();
        Console.WriteLine();
    }
}