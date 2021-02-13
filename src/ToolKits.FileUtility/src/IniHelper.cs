//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：IniHelper.cs
// 项目名称：文件操作实用工具集
// 创建时间：2014年2月21日10时53分
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ToolKits.FileUtility
{
    /// <summary>
    /// 配置文件操作辅助类
    /// </summary>
    public static class IniHelper
    {
        /// <summary>
        /// 配置文件参数整形数据读取
        /// </summary>
        /// <param name="lpAppName">项目名称( 如：[TypeName] )</param>
        /// <param name="lpKeyName">参数名称</param>
        /// <param name="nDefault">默认值</param>
        /// <param name="lpFileName">配置文件绝对路径</param>
        /// <returns>参数整形数据</returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);
        /// <summary>
        /// 配置文件参数字符串数据读取
        /// </summary>
        /// <param name="lpAppName">项目名称( 如：[TypeName] )</param>
        /// <param name="lpKeyName">参数名称</param>
        /// <param name="lpDefault">默认值</param>
        /// <param name="lpReturnedString">数据接收对象</param>
        /// <param name="nSize">数据大小</param>
        /// <param name="lpFileName">配置文件绝对路径</param>
        /// <returns>参数字符串数据</returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        /// <summary>
        /// 配置文件参数数据写入
        /// </summary>
        /// <param name="lpAppName">项目名称( 如：[TypeName] )</param>
        /// <param name="lpKeyName">参数名称</param>
        /// <param name="lpString">参数设定值</param>
        /// <param name="lpFileName">配置文件绝对路径</param>
        /// <returns>写入是否成功</returns>
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
        /// <summary>
        /// 读取 int 型数据
        /// </summary>
        /// <param name="FFileName">配置文件绝对路径</param>
        /// <param name="section">项目名称( 如：[TypeName] )</param>
        /// <param name="key">参数名称</param>
        /// <param name="def">缺省值</param>
        /// <returns>int</returns>
        public static int ReadInt(string FFileName, string section, string key, int def)
        {
            return GetPrivateProfileInt(section, key, def, FFileName);
        }
        /// <summary>
        /// 读取 string 型数据
        /// </summary>
        /// <param name="FFileName">配置文件绝对路径</param>
        /// <param name="section">项目名称( 如：[TypeName] )</param>
        /// <param name="key">参数名称</param>
        /// <param name="def">缺省值</param>
        /// <returns>string</returns>
        public static string ReadString(string FFileName, string section, string key, string def)
        {
            StringBuilder temp = new StringBuilder(2048);
            GetPrivateProfileString(section, key, def, temp, 2048, FFileName);
            return temp.ToString();
        }
        /// <summary>
        /// 写入 int 型数据
        /// </summary>
        /// <param name="FFileName">配置文件绝对路径</param>
        /// <param name="section">项目名称( 如：[TypeName] )</param>
        /// <param name="key">参数名称</param>
        /// <param name="iVal">缺省值</param>
        public static void WriteInt(string FFileName, string section, string key, int iVal)
        {
            WritePrivateProfileString(section, key, iVal.ToString(), FFileName);
        }
        /// <summary>
        /// 写入 string 型数据
        /// </summary>
        /// <param name="FFileName">配置文件绝对路径</param>
        /// <param name="section">项目名称( 如：[TypeName] )</param>
        /// <param name="key">参数名称</param>
        /// <param name="strVal">缺省值</param>
        public static void WriteString(string FFileName, string section, string key, string strVal)
        {
            WritePrivateProfileString(section, key, strVal, FFileName);
        }
        /// <summary>
        /// 删除“键”
        /// </summary>
        /// <param name="FFileName">配置文件绝对路径</param>
        /// <param name="section">项目名称( 如：[TypeName] )</param>
        /// <param name="key">参数名称</param>
        public static void DelKey(string FFileName, string section, string key)
        {
            WritePrivateProfileString(section, key, null, FFileName);
        }
        /// <summary>
        /// 删除“项目”
        /// </summary>
        /// <param name="FFileName">配置文件绝对路径</param>
        /// <param name="section">项目名称( 如：[TypeName] )</param>
        public static void DelSection(string FFileName, string section)
        {
            WritePrivateProfileString(section, null, null, FFileName);
        }
    }
}
