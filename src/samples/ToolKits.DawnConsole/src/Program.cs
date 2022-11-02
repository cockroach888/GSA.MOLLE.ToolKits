using GSA.ToolKits.CommonUtility;
using GSA.ToolKits.PagingUtility;
using System;

namespace GSA.ToolKits.DawnConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Console.WriteLine("Hello World!");
            Console.WriteLine();
            Console.WriteLine();


            string ip = NetworkHelper.GetIpAddress();
            string mac1 = NetworkHelper.GetMacAddress(ip);
            string mac2 = NetworkHelper.GetMacAddress(ip, isUseHorizontalBars: true);

            Console.WriteLine($"IP：{ip}  MAC：{mac1}  {mac2}");
            Console.WriteLine();
            Console.WriteLine();
            */

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
                TotalRecords = 30000,
                IsUsePagingJump = true
            };

            string pageString;
            
            // Page 1
            options.TotalRecords = 50;
            options.CurrentPage = 5;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 1: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 2
            options.TotalRecords = 100;
            options.CurrentPage = 5;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 2: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 3
            options.TotalRecords = 150;
            options.CurrentPage = 2;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 3: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 4
            options.TotalRecords = 200;
            options.CurrentPage = 3;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 4: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 5
            options.TotalRecords = 250;
            options.CurrentPage = 4;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 5: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 6
            options.TotalRecords = 300;
            options.CurrentPage = 5;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 6: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");
            

            // Page 7
            options.TotalRecords = 350;
            options.CurrentPage = 5;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 7: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 8
            options.TotalRecords = 400;
            options.CurrentPage = 6;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 8: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 9
            options.TotalRecords = 450;
            options.CurrentPage = 7;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 9: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 10
            options.TotalRecords = 500;
            options.CurrentPage = 8;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 10: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 11
            options.TotalRecords = 550;
            options.CurrentPage = 9;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 11: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 12
            options.TotalRecords = 600;
            options.CurrentPage = 10;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 12: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 13
            options.TotalRecords = 650;
            options.CurrentPage = 10;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 13: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 14
            options.TotalRecords = 700;
            options.CurrentPage = 10;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 14: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");

            
            // Page 15
            options.TotalRecords = 750;
            options.CurrentPage = 8;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 15: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 16
            options.TotalRecords = 800;
            options.CurrentPage = 9;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 16: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 17
            options.TotalRecords = 850;
            options.CurrentPage = 15;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 17: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 18
            options.TotalRecords = 900;
            options.CurrentPage = 17;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 18: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 19
            options.TotalRecords = 950;
            options.CurrentPage = 15;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 19: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 20
            options.TotalRecords = 1000;
            options.CurrentPage = 13;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 20: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 50
            options.TotalRecords = 2500;
            options.CurrentPage = 35;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 50: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 100
            options.TotalRecords = 5000;
            options.CurrentPage = 55;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 100: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");


            // Page 300
            options.TotalRecords = 15000;
            options.CurrentPage = 200;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 300: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");
            

            // Page 1000
            options.TotalRecords = 50000;
            options.CurrentPage = 650;
            pageString = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            //Console.WriteLine($"Page 1000: {pageString}");
            //Console.WriteLine();
            Console.WriteLine($"{pageString}");
            


            //Console.WriteLine("按任意键继续...");
            Console.ReadKey();
        }
    }
}