//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：Program4CommonUtility.cs
// 项目名称：功能调测控制台程序
// 创建时间：2023-03-19 21:07:06
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.CommonUtility;

namespace GSA.ToolKits.DawnConsole;

/// <summary>
/// CommonUtility
/// </summary>
internal sealed class Program4CommonUtility
{

    #region 单例模式

    private static readonly Lazy<Program4CommonUtility> _lazyInstance = new(() => new Program4CommonUtility());

    /// <summary>
    /// CommonUtility
    /// </summary>
    internal static Program4CommonUtility Default => _lazyInstance.Value;

    #endregion


    public void ImageToBase64String()
    {
        string imagePath = "D:\\TemporaryFiles\\PictureSource.bmp";

        string base64String = ImageHelper.ImageToBase64(imagePath);
        Console.WriteLine(base64String);
        Console.WriteLine();
        Console.WriteLine();

        string base64StringPrefix = ImageHelper.ImageToBase64WithoutPrefix(imagePath);
        Console.WriteLine(base64StringPrefix);
        Console.WriteLine();
        Console.WriteLine();
    }

    /// <summary>
    /// 小心手雷，洞中开火。
    /// </summary>
    /// <remarks>获取IP地址与MAC地址</remarks>
    public void FireInTheHole()
    {
        string ip = NetworkHelper.GetIpAddress();
        string mac1 = NetworkHelper.GetMacAddress(ip);
        string mac2 = NetworkHelper.GetMacAddress(ip, isUseHorizontalBars: true);

        Console.WriteLine($"IP：{ip}  MAC：{mac1}  {mac2}");


        Console.WriteLine();
        Console.WriteLine();
    }

    /// <summary>
    /// 收起你的武器
    /// </summary>
    /// <remarks>生成随机中文和时间等内容</remarks>
    public void HolsterThatWeapon()
    {
        Console.WriteLine(MockDataHelper.MockRandomChinese(10));
        Console.WriteLine();

        Console.WriteLine(MockDataHelper.MockRandomChinese(15));
        Console.WriteLine();

        Console.WriteLine(MockDataHelper.MockRandomChinese(35));
        Console.WriteLine();

        Console.WriteLine(MockDataHelper.MockRandomChinese(50));
        Console.WriteLine();

        Console.WriteLine(MockDataHelper.MockRandomChinese(100));
        Console.WriteLine();

        Console.WriteLine(MockDataHelper.MockRandomChinese(500));
        Console.WriteLine();


        Console.WriteLine(MockDataHelper.MockDateTimeString());
        Console.WriteLine();

        Console.WriteLine(MockDataHelper.MockDateTimeString(-1));
        Console.WriteLine();

        Console.WriteLine(MockDataHelper.MockDateTimeString(1));
        Console.WriteLine();

        Console.WriteLine(MockDataHelper.MockDateTimeString(-1, kind: DateTimeKind.Utc));
        Console.WriteLine();

        Console.WriteLine(MockDataHelper.MockDateTimeString(1, kind: DateTimeKind.Local));
        Console.WriteLine();

        Console.WriteLine(MockDataHelper.MockDateTimeString(1, kind: DateTimeKind.Unspecified));
        Console.WriteLine();

        Console.WriteLine(MockDataHelper.MockDateTimeString(-1, formatString: "yyyy-M-d HH:mm:ss"));
        Console.WriteLine();

        Console.WriteLine(MockDataHelper.MockDateTimeString(1, formatString: "yyyy-M-d HH:mm:ss"));


        Console.WriteLine();
        Console.WriteLine();
    }
}