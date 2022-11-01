using GSA.ToolKits.CommonUtility;
using GSA.ToolKits.PagingUtility;
using System;

namespace GSA.ToolKits.DawnConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine();
            Console.WriteLine();


            string ip = NetworkHelper.GetIpAddress();
            string mac1 = NetworkHelper.GetMacAddress(ip);
            string mac2 = NetworkHelper.GetMacAddress(ip, isUseHorizontalBars: true);

            Console.WriteLine($"IP：{ip}  MAC：{mac1}  {mac2}");
            Console.WriteLine();
            Console.WriteLine();


            PagingOptions options = new()
            {
                //ExtraParameters = "'test',33,89,'over'",
                ExtraParameters = ",'{msg:MaydayMaydayMayday}'",
                PagingTagClass = "fs-2",
                PagingTagStyle = "color:red;",
                PagingItemClass = "fw-light",
                PagingItemStyle = "font-style:italic;",
                CurrentPage = 5,
                PaginationSize = 50,
                TotalRecords = 500,
                IsOutputCurrentPageRecords = true,
                IsUsePagingJump = true
            };
            options.CurrentPageRecords = 49;


            string MaydayMaydayMayday = PagingHelper.Builder(PagingUIType.Bootstrap_V5, options);

            Console.WriteLine($"PagingString: {MaydayMaydayMayday}");
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("按任意键继续...");
            Console.ReadKey();
        }
    }
}