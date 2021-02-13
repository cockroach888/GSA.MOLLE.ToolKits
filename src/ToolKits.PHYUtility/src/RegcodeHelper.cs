//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：RegcodeHelper.cs
// 项目名称：物理操作实用工具集
// 创建时间：2014-03-21 16:00:57
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;

namespace ToolKits.PHYUtility
{
    /// <summary>
    /// 软件注册码辅助类
    /// </summary>
    public static class RegcodeHelper
    {
        /// <summary>
        /// 生成机器码
        /// </summary>
        /// <returns>机器码</returns>
        public static string GetMNum()
        {
            string strNum = ManagementHelper.Instance().CpuID + ManagementHelper.Instance().DiskVolume;//获得24位Cpu和硬盘序列号
            string strMNum = strNum.Substring(0, 24);//从生成的字符串中取出前24个字符做为机器码
            return strMNum;
        }
        /// <summary>
        /// 存储密钥
        /// </summary>
        public static int[] intCode = new int[127];
        /// <summary>
        /// 存机器码的Ascii值
        /// </summary>
        public static int[] intNumber = new int[25];
        /// <summary>
        /// 存储机器码字
        /// </summary>
        public static char[] Charcode = new char[25];
        /// <summary>
        /// 给数组赋值小于10的数
        /// </summary>
        public static void SetIntCode()
        {
            for (int i = 1; i < intCode.Length; i++)
            {
                intCode[i] = i % 9;
            }
        }
        /// <summary>
        /// 生成注册码
        /// </summary>
        /// <returns>注册码</returns>
        public static string GetRNum()
        {
            SetIntCode();//初始化127位数组
            for (int i = 1; i < Charcode.Length; i++)//把机器码存入数组中
            {
                Charcode[i] = Convert.ToChar(GetMNum().Substring(i - 1, 1));
            }
            for (int j = 1; j < intNumber.Length; j++)//把字符的ASCII值存入一个整数组中。
            {
                intNumber[j] = intCode[Convert.ToInt32(Charcode[j])] + Convert.ToInt32(Charcode[j]);
            }
            string strAsciiName = "";//用于存储注册码
            for (int j = 1; j < intNumber.Length; j++)
            {
                if (intNumber[j] >= 48 && intNumber[j] <= 57)//判断字符ASCII值是否0－9之间
                {
                    strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                }
                else if (intNumber[j] >= 65 && intNumber[j] <= 90)//判断字符ASCII值是否A－Z之间
                {
                    strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                }
                else if (intNumber[j] >= 97 && intNumber[j] <= 122)//判断字符ASCII值是否a－z之间
                {
                    strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                }
                else//判断字符ASCII值不在以上范围内
                {
                    if (intNumber[j] > 122)//判断字符ASCII值是否大于z
                    {
                        strAsciiName += Convert.ToChar(intNumber[j] - 10).ToString();
                    }
                    else
                    {
                        strAsciiName += Convert.ToChar(intNumber[j] - 9).ToString();
                    }
                }
            }
            return strAsciiName;
        }
    }
}
