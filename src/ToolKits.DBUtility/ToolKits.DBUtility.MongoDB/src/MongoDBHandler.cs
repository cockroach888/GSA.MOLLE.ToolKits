//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：MongoDBHandler.cs
// 项目名称：数据库操作实用工具集
// 创建时间：2014-12-21 23:00:47
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
/*using System;
using MongoDB.Driver;

namespace GSA.ToolKits.DBUtility
{
    /// <summary>
    /// MongoDB配置处理器
    /// </summary>
    public class MongoDBHandler
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="dbName">MongoDB 数据库名称</param>
        public MongoDBHandler(string connectionString, string dbName)
        {
            this.FClient = new MongoClient(connectionString);
            //this.MongoConnectionHost = host;
            //this.MongoConnectionPort = port;
            //this.MongoConnectionTimeout = timeout;
            this.MongoDatabaseName = dbName;
            this.FDatabase = this.FClient.GetServer().GetDatabase(dbName);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbName">MongoDB 数据库名称</param>
        /// <returns>MongoDatabase 实例对象</returns>
        public MongoDBHandler(string dbName)
        {
            this.MongoConnectionHost = "127.0.0.1";
            this.MongoConnectionPort = 27017;
            this.MongoConnectionTimeout = 30;
            this.MongoDatabaseName = dbName;
            MongoClientSettings mongoSetting = new MongoClientSettings();
            mongoSetting.ConnectTimeout = new TimeSpan(this.MongoConnectionTimeout * TimeSpan.TicksPerSecond);
            mongoSetting.Server = new MongoServerAddress(this.MongoConnectionHost, this.MongoConnectionPort);
            this.FClient = new MongoClient(mongoSetting);
            this.FDatabase = this.FClient.GetServer().GetDatabase(dbName);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="host">MongoDB 数据库连接主机地址</param>
        /// <param name="port">MongoDB 数据库连接端口号</param>
        /// <param name="timeout">MongoDB 数据库连接超时时间</param>
        /// <param name="dbName">MongoDB 数据库名称</param>
        /// <returns>MongoDatabase 实例对象</returns>
        public MongoDBHandler(string host, int port, int timeout, string dbName)
        {
            this.MongoConnectionHost = host;
            this.MongoConnectionPort = port;
            this.MongoConnectionTimeout = timeout;
            this.MongoDatabaseName = dbName;
            MongoClientSettings mongoSetting = new MongoClientSettings();
            mongoSetting.ConnectTimeout = new TimeSpan(this.MongoConnectionTimeout * TimeSpan.TicksPerSecond);
            mongoSetting.Server = new MongoServerAddress(this.MongoConnectionHost, this.MongoConnectionPort);
            this.FClient = new MongoClient(mongoSetting);
            this.FDatabase = FClient.GetServer().GetDatabase(dbName);
        }

        #region 成员对象

        /// <summary>
        /// MongoDB 客户端对象
        /// </summary>
        public MongoClient FClient { get; private set; }
        /// <summary>
        /// MongoDB 数据库对象
        /// </summary>
        public MongoDatabase FDatabase { get; private set; }

        #endregion

        #region 成员属性

        /// <summary>
        /// MongoDB 数据库连接主机地址
        /// </summary>
        public string MongoConnectionHost { get; private set; }
        /// <summary>
        /// MongoDB 数据库连接端口号
        /// </summary>
        public int MongoConnectionPort { get; private set; }
        /// <summary>
        /// MongoDB 数据库连接超时时间
        /// </summary>
        public int MongoConnectionTimeout { get; private set; }
        /// <summary>
        /// MongoDB 数据库名称
        /// </summary>
        public string MongoDatabaseName { get; private set; }

        #endregion

    }
}*/
