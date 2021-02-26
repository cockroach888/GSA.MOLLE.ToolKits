//=========================================================================
//**   魂哥常用工具集（CRS.CommonUtility）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2021 -- Support 文雀
//=========================================================================
// 文件名称：ConnectionHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2021-02-23 21:52:21
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.DawnUtility;
using GSA.ToolKits.DBUtility;

namespace GSA.ToolKits.DawnApp.Core
{
    /// <summary>
    /// 数据库连接字符串助手
    /// </summary>
    internal sealed class ConnectionHelper
    {
        /// <summary>
		/// MongoDB数据库连接字符串
		/// </summary>
		public static readonly string MongoConn = CryptoHelper.Decrypt(MongoConnectionString.ConnectionString("MongoConnectionString"));
        /// <summary>
        /// MongoDB数据库名称
        /// </summary>
        public static readonly string MongoName = CryptoHelper.Decrypt(MongoConnectionString.DatabaseName("MongoDatabaseName"));
    }
}
