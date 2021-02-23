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
// 创建时间：2014-12-09 22:43:18
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
    public sealed class MongoConnectionString
    {
        /// <summary>
        /// MongoDB连接字符串
        /// </summary>
        /// <param name="keyName">键值名称</param>
        /// <para>默认值：MongoConnectionString</para>
        /// <returns>数据库连接字符串</returns>
        public static string ConnectionString(string keyName)
        {
            string result = null;
            if (!string.IsNullOrEmpty(keyName))
            {
                result = ConfigurationManager.ConnectionStrings[keyName].ConnectionString;
            }
            else
            {
                result = ConfigurationManager.ConnectionStrings["MongoConnectionString"].ConnectionString;
            }
            return result;
        }
        /// <summary>
        /// MongoDB数据库名称
        /// <para>调用时请对此方法特别调用</para>
        /// <para>默认值：MongoDatabaseName</para>
        /// </summary>
        /// <param name="keyName">键值名称</param>
        /// <returns>数据库名称</returns>
        public static string DatabaseName(string keyName)
        {
            string result = null;
            if (!string.IsNullOrEmpty(keyName))
            {
                result = ConfigurationManager.AppSettings[keyName] as string;
            }
            else
            {
                result = ConfigurationManager.AppSettings["MongoDatabaseName"] as string;
            }
            return result;
        }
        /// <summary>
        /// 连接参数 One
        /// </summary>
        public readonly static string ParamOne = null;
        /// <summary>
        /// 连接参数 Two
        /// </summary>
        public readonly static string ParamTwo = null;
    }
}
