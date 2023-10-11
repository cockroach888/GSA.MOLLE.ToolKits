//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MockDataHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-11-11 14:35:38
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

namespace GSA.ToolKits.CommonUtility;

/// <summary>
/// 数据模拟助手类
/// </summary>
public static class MockDataHelper
{
    /// <summary>
    /// 获取指定偏移量与格式的日期时间字符串
    /// </summary>
    /// <param name="offsetDay">偏移量(缺省 0)</param>
    /// <param name="formatString">格式(缺省 yyyy-MM-dd HH:mm:ss.fff)</param>
    /// <param name="kind">日期时间特征(缺省 Local 本地时间)</param>
    /// <returns>表示日期与时间的字符串</returns>
    public static string MockDateTimeString(int offsetDay = 0, string formatString = "yyyy-MM-dd HH:mm:ss.fff", DateTimeKind kind = DateTimeKind.Local)
        => kind switch
        {
            DateTimeKind.Utc => $"{DateTime.UtcNow.AddDays(offsetDay).ToString(formatString)}",
            DateTimeKind.Local => $"{DateTime.Now.AddDays(offsetDay).ToString(formatString)}",
            _ => $"{DateTime.UtcNow.AddDays(offsetDay).ToUniversalTime().ToString(formatString)}"
        };

    /// <summary>
    /// 随机生成指定数量的汉字
    /// </summary>
    /// <param name="length">生成数量</param>
    /// <returns>生成结果</returns>
    public static string MockRandomChinese(int length)
    {
        // 获取GB2312编码表
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Encoding gbcoding = Encoding.GetEncoding("GB2312");

        object[] bytes = CreateRegionCode(length);
        StringBuilder sb = new();

        for (int i = 0; i < length; i++)
        {
            byte[] buffer = (byte[])Convert.ChangeType(bytes[i], typeof(byte[]));
            sb.Append(gbcoding.GetString(buffer));
        }

        return sb.ToString();
    }

    /// <summary>
    /// 创建指定数量表示汉字的区位码字符
    /// </summary>
    /// <remarks>
    /// <list type="number">
    /// <item>每循环一次产生一个含两个元素的十六进制字节数组，并将其放入bytes数组中；</item>
    /// <item>每个汉字有四个区位码组成；</item>
    /// <item>区位码第1位和区位码第2位作为字节数组第一个元素；</item>
    /// <item>区位码第3位和区位码第4位作为字节数组第二个元素。</item>
    /// </list>
    /// </remarks>
    /// <param name="length">生成数量</param>
    /// <returns>创建结果</returns>
    private static object[] CreateRegionCode(int length)
    {
        // 十六进制字符编码元素
        string[] character = new string[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };

        // 每获取1位区位码，更换一次随机数发生器种子，避免产生重复值。
        Random random = new();
        object[] buffer = new object[length];

        for (int i = 0; i < length; i++)
        {
            // 第1位区位码
            int place1st = random.Next(11, 14);
            string str1st = character[place1st].Trim();

            // 第2位区位码
            random = new Random(place1st * unchecked((int)DateTime.Now.Ticks) + i);
            int place2nd = place1st == 13 ? random.Next(0, 7) : random.Next(0, 16);
            string str2nd = character[place2nd].Trim();

            // 第3位区位码
            random = new Random(place2nd * unchecked((int)DateTime.Now.Ticks) + i);
            int place3rd = random.Next(10, 16);
            string str3rd = character[place3rd].Trim();

            // 第4位区位码
            random = new Random(place3rd * unchecked((int)DateTime.Now.Ticks) + i);

            int place4th = place3rd switch
            {
                10 => random.Next(1, 16),
                15 => random.Next(0, 15),
                _ => random.Next(0, 16)
            };

            string str4th = character[place4th].Trim();

            byte byte1 = Convert.ToByte($"{str1st}{str2nd}", 16);
            byte byte2 = Convert.ToByte($"{str3rd}{str4th}", 16);
            buffer.SetValue(new byte[] { byte1, byte2 }, i);
        }

        return buffer;
    }
}