using GSA.ToolKits.CommonUtility;
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


            Console.WriteLine("按任意键继续...");
            Console.ReadKey();
        }
    }
}
