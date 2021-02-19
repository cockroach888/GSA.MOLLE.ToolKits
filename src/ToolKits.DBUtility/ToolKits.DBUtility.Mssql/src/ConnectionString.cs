//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：ConnectionString.cs
// 项目名称：数据库操作实用工具集
// 创建时间：2014年2月26日11时30分
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.Configuration;

namespace GSA.ToolKits.DBUtility
{
    /// <summary>
    /// 数据库连接字符串
    /// </summary>
    public sealed class MssqlConnectionString
    {
        /// <summary>
        /// 数据库连接字符串
        /// <para>默认名称：ConnectionString</para>
        /// </summary>
        /// <param name="KeyName">键值名称</param>
        /// <returns>数据库连接字符串</returns>
        public static string ConnectionString(string KeyName)
        {
            string result = null;
            if (!string.IsNullOrEmpty(KeyName))
            {
                result = ConfigurationManager.ConnectionStrings[KeyName].ConnectionString;
            }
            else
            {
                result = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
            return result;
        }
    }
}
