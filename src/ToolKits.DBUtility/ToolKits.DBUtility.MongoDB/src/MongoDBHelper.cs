//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：MongoDBHelper.cs
// 项目名称：数据库操作实用工具集
// 创建时间：2014-12-09 22:30:09
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
/*using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace GSA.ToolKits.DBUtility
{
    /// <summary>
    /// The MongoDBHelper class is intended to encapsulate high performance, scalable best practices for 
    /// common uses of MongoDB.
    /// </summary>
    //public sealed class MongoDBHelper {
    public sealed class MongoDBHelper<T> where T : class
    {

        #region 数据添加

        /// <summary>
        /// 数据添加
        /// <para>单个添加</para>
        /// <remarks>数据库不存在创建数据库</remarks>
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="entity">实体对象</param>
        /// <returns>安全模式的结果</returns>
        public static SafeModeResult Insert<T>(string connectionString, string databaseName, T entity)
        {
            if (string.IsNullOrEmpty(connectionString)
                || string.IsNullOrEmpty(databaseName)
                || null == entity) return null;
            return Insert<T>(connectionString, databaseName, typeof(T).Name, entity);
        }
        /// <summary>
        /// 数据添加
        /// <para>单个添加</para>
        /// <remarks>数据库不存在创建数据库</remarks>
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="entity">实体对象</param>
        /// <returns>安全模式的结果</returns>
        public static SafeModeResult Insert<T>(string connectionString, string databaseName, string collectionName, T entity)
        {
            if (string.IsNullOrEmpty(connectionString)
                || string.IsNullOrEmpty(databaseName)
                || string.IsNullOrEmpty(collectionName)
                || null == entity) return null;
            SafeModeResult result;
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(databaseName);
            using (server.RequestStart(database))
            {
                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);
                result = myCollection.Insert(entity);
            }
            return result;
        }
        /// <summary>
        /// 数据添加
        /// <para>多个添加</para>
        /// <remarks>数据库不存在创建数据库</remarks>
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="entitys">实体对象集合</param>
        /// <returns>安全模式的结果集合</returns>
        public static IEnumerable<SafeModeResult> Insert<T>(string connectionString, string databaseName, string collectionName, IEnumerable<T> entitys)
        {
            if (string.IsNullOrEmpty(connectionString)
                || string.IsNullOrEmpty(databaseName)
                || string.IsNullOrEmpty(collectionName)
                || null == entitys) return null;
            IEnumerable<SafeModeResult> result;
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(databaseName);
            using (server.RequestStart(database))
            {
                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);
                result = myCollection.InsertBatch(entitys);
            }
            return result;
        }

        #endregion

        #region 数据更新

        /// <summary>
        /// 数据更新
        /// <para>实体更新</para>
        /// <remarks>数据库不存在创建数据库</remarks>
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="entity">实体对象</param>
        /// <returns>安全模式的结果</returns>
        public static SafeModeResult Update<T>(string connectionString, string databaseName, string collectionName, T entity)
        {
            if (string.IsNullOrEmpty(connectionString)
                || string.IsNullOrEmpty(databaseName)
                || string.IsNullOrEmpty(collectionName)
                || null == entity) return null;
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(databaseName);
            SafeModeResult result;
            using (server.RequestStart(database))
            {
                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);
                result = myCollection.Save(entity);
            }
            return result;
        }
        /// <summary>
        /// 数据更新
        /// <para>查询更新</para>
        /// <remarks>数据库不存在创建数据库</remarks>
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="query">
        /// 查询条件
        /// <para>调用示例：</para>
        /// <para>　　Query.Matches("Title", "感冒")</para>
        /// <para>　　Query.EQ("Title", "感冒")</para>
        /// <para>　　Query.And(Query.Matches("Title", "感冒"),Query.EQ("Author", "yanc"))</para>
        /// </param>
        /// <param name="update">
        /// 更新设置
        /// <para>调用示例：</para>
        /// <para>　　Update.Set("Title", "yanc")</para>
        /// <para>　　Update.Set("Title", "yanc").Set("Author", "yanc2")</para>
        /// </param>
        /// <returns>安全模式的结果集合</returns>
        public static SafeModeResult Update<T>(string connectionString, string databaseName, string collectionName, IMongoQuery query, IMongoUpdate update)
        {
            if (string.IsNullOrEmpty(connectionString)
                || string.IsNullOrEmpty(databaseName)
                || string.IsNullOrEmpty(collectionName)
                || null == query
                || null == update) return null;
            SafeModeResult result;
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(databaseName);
            using (server.RequestStart(database))
            {
                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);
                result = myCollection.Update(query, update, UpdateFlags.Multi);
            }
            return result;
        }

        #endregion

        #region 数据删除

        /// <summary>
        /// 数据删除
        /// <remarks>数据库不存在创建数据库</remarks>
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="_id">内置系统编号</param>
        /// <returns>安全模式的结果</returns>
        public static SafeModeResult Delete(string connectionString, string databaseName, string collectionName, string _id)
        {
            ObjectId id;
            if (!ObjectId.TryParse(_id, out id)) return null;
            SafeModeResult result;
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(databaseName);
            using (server.RequestStart(database))
            {
                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);
                result = myCollection.Remove(Query.EQ("_id", id));
            }
            return result;
        }
        /// <summary>
        /// 数据删除
        /// <remarks>数据库不存在创建数据库</remarks>
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="keyName">键名称</param>
        /// <param name="keyValue">键值</param>
        /// <returns>安全模式的结果</returns>
        public static SafeModeResult Delete(string connectionString, string databaseName, string collectionName, string keyName, string keyValue)
        {
            if (string.IsNullOrEmpty(keyName) || string.IsNullOrEmpty(keyValue)) return null;
            SafeModeResult result;
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(databaseName);
            using (server.RequestStart(database))
            {
                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);
                result = myCollection.Remove(Query.EQ(keyName, keyValue));
            }
            return result;
        }
        /// <summary>
        /// 数据删除
        /// <remarks>数据库不存在创建数据库</remarks>
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="query">
        /// 删除条件
        /// <para>调用示例：</para>
        /// <para>　　Query.Matches("Title", "感冒")</para>
        /// <para>　　Query.EQ("Title", "感冒")</para>
        /// <para>　　Query.And(Query.Matches("Title", "感冒"),Query.EQ("Author", "yanc"))</para>
        /// </param>
        /// <returns>安全模式的结果</returns>
        public static SafeModeResult DeleteAll(string connectionString, string databaseName, string collectionName, IMongoQuery query)
        {
            if (null == query) return null;
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(databaseName);
            SafeModeResult result;
            using (server.RequestStart(database))
            {
                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);
                if (null == query)
                {
                    result = myCollection.RemoveAll();
                }
                else
                {
                    result = myCollection.Remove(query);
                }
            }
            return result;
        }

        #endregion

        #region 单实体数据查询

        /// <summary>
        /// 单实体数据查询
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="_id">系统内置编号</param>
        /// <returns>泛型对象集合信息</returns>
        public static T Select<T>(string connectionString, string databaseName, string collectionName, string _id)
        {
            if (string.IsNullOrEmpty(connectionString)
                || string.IsNullOrEmpty(databaseName)
                || string.IsNullOrEmpty(collectionName)
                || string.IsNullOrEmpty(_id)) return default(T);
            T result = default(T);
            ObjectId id;
            if (!ObjectId.TryParse(_id, out id)) return default(T);
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(databaseName);
            using (server.RequestStart(database))
            {
                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);
                result = myCollection.FindOneAs<T>(Query.EQ("_id", id));
            }
            return result;
        }
        /// <summary>
        /// 单实体数据查询
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="keyName">键名称</param>
        /// <param name="keyValue">键值</param>
        /// <returns>泛型对象集合信息</returns>
        public static T Select<T>(string connectionString, string databaseName, string collectionName, string keyName, string keyValue)
        {
            if (string.IsNullOrEmpty(connectionString)
                || string.IsNullOrEmpty(databaseName)
                || string.IsNullOrEmpty(collectionName)
                || string.IsNullOrEmpty(keyName)
                || string.IsNullOrEmpty(keyValue)) return default(T);
            T result = default(T);
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(databaseName);
            using (server.RequestStart(database))
            {
                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);
                result = myCollection.FindOneAs<T>(Query.EQ(keyName, keyValue));
            }
            return result;
        }
        /// <summary>
        /// 单实体数据查询
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="query">
        /// 查询条件
        /// <para>调用示例：</para>
        /// <para>　　Query.Matches("Title", "感冒")</para>
        /// <para>　　Query.EQ("Title", "感冒")</para>
        /// <para>　　Query.And(Query.Matches("Title", "感冒"),Query.EQ("Author", "yanc"))</para>
        /// <para></para>
        /// </param>
        /// <returns>泛型对象集合信息</returns>
        public static T Select<T>(string connectionString, string databaseName, string collectionName, IMongoQuery query)
        {
            if (string.IsNullOrEmpty(connectionString)
                || string.IsNullOrEmpty(databaseName)
                || string.IsNullOrEmpty(collectionName)
                || null == query) return default(T);
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(databaseName);
            T result = default(T);
            using (server.RequestStart(database))
            {
                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);
                if (null == query)
                {
                    result = myCollection.FindOneAs<T>();
                }
                else
                {
                    result = myCollection.FindOneAs<T>(query);
                }
            }
            return result;
        }

        #endregion

        #region 实体集合数据查询

        /// <summary>
        /// 实体集合数据查询
        /// <para>如果集合为大数据时，请慎用。</para>
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns>泛型对象实体集合</returns>
        public static IList<T> Select<T>(string connectionString, string databaseName, string collectionName)
        {
            if (string.IsNullOrEmpty(connectionString)
                || string.IsNullOrEmpty(databaseName)
                || string.IsNullOrEmpty(collectionName)) return null;
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(databaseName);
            List<T> result = new List<T>();
            using (server.RequestStart(database))
            {
                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);
                foreach (T entity in myCollection.FindAllAs<T>())
                {
                    result.Add(entity);
                }
            }
            return result;
        }
        /// <summary>
        /// 实体集合数据查询
        /// <para>Skip模式分页查询</para>
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="pageIndex">分页索引</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="query">
        /// 查询条件
        /// <para>调用示例：</para>
        /// <para>　　Query.Matches("Title", "感冒")</para>
        /// <para>　　Query.EQ("Title", "感冒")</para>
        /// <para>　　Query.And(Query.Matches("Title", "感冒"),Query.EQ("Author", "yanc"))</para>
        /// </param>
        /// <param name="sortBy">
        /// 排序条件
        /// <para>调用示例：</para>
        /// <para>　　SortBy.Descending("Title")</para>
        /// <para>　　SortBy.Descending("Title").Ascending("Author")</para>
        /// </param>
        /// <param name="fields">
        /// 返回字段设置
        /// <para>调用示例：</para>
        /// <para>　　"Title"</para>
        /// <para>　　new string[] { "Title", "Author" }</para>
        /// </param>
        /// <returns>泛型对象实体集合</returns>
        public static List<T> Select<T>(string connectionString, string databaseName, string collectionName, int pageIndex, int pageSize, IMongoQuery query, IMongoSortBy sortBy, params string[] fields)
        {
            if (string.IsNullOrEmpty(connectionString)
                || string.IsNullOrEmpty(databaseName)
                || string.IsNullOrEmpty(collectionName)) return null;
            if (pageIndex <= 0) pageIndex = 1;
            if (pageSize <= 0) pageSize = 200;
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(databaseName);
            List<T> result = new List<T>();
            using (server.RequestStart(database))
            {
                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);
                MongoCursor<T> myCursor;
                if (null == query)
                {
                    myCursor = myCollection.FindAllAs<T>();
                }
                else
                {
                    myCursor = myCollection.FindAs<T>(query);
                }
                if (null != sortBy) myCursor.SetSortOrder(sortBy);
                if (null != fields) myCursor.SetFields(fields);
                foreach (T entity in myCursor.SetSkip((pageIndex - 1) * pageSize).SetLimit(pageSize))//.SetSkip(100).SetLimit(10)是指读取第一百条后的10条数据。
                {
                    result.Add(entity);
                }
            }
            return result;
        }

        #endregion

        #region 索引建立

        /// <summary>
        /// 索引建立
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="keyNames">需要建立索引的字段</param>
        public static void Index(string connectionString, string databaseName, string collectionName, params string[] keyNames)
        {
            if (string.IsNullOrEmpty(connectionString)
                || string.IsNullOrEmpty(databaseName)
                || string.IsNullOrEmpty(collectionName)
                || null == keyNames) return;
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(databaseName);
            using (server.RequestStart(database))
            {
                MongoCollection<BsonDocument> myCollection = database.GetCollection<BsonDocument>(collectionName);
                if (!myCollection.IndexExists(keyNames))
                {
                    myCollection.CreateIndex(keyNames);
                }
            }
        }

        #endregion

        #region 高效率数据分页查询

        /// <summary>
        /// 分页查询 指定索引最后项-PageSize模式 
        /// </summary>
        /// <typeparam name="T">所需查询的数据的实体类型</typeparam>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="query">查询的条件 没有可以为null</param>
        /// <param name="indexName">索引名称</param>
        /// <param name="lastKeyValue">最后索引的值</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="sortType">排序类型 1升序 -1降序 仅仅针对该索引</param>
        /// <param name="fields">字段设置</param>
        /// <returns>返回一个List列表数据</returns>
        public static List<T> Select<T>(string connectionString, string databaseName, string collectionName, IMongoQuery query, string indexName, object lastKeyValue, int pageSize, int sortType, params string[] fields)
        {
            if (string.IsNullOrEmpty(connectionString)
                || string.IsNullOrEmpty(databaseName)
                || string.IsNullOrEmpty(collectionName)
                || string.IsNullOrEmpty(indexName)) return null;
            if (pageSize <= 0) pageSize = 200;
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase(databaseName);
            List<T> result = new List<T>();
            using (server.RequestStart(database))
            {
                MongoCollection<T> mc = database.GetCollection<T>(collectionName);
                MongoCursor<T> myCursor = null;
                //当查询为空时 附加恒真的条件 类似SQL：1=1的语法
                if (null == query) query = Query.Exists("_id");
                if (null != fields) myCursor.SetFields(fields);
                //判断升降序后进行查询
                if (sortType > 0)
                { //升序					
                    if (lastKeyValue != null)
                    {
                        //有上一个主键的值传进来时才添加上一个主键的值的条件
                        query = Query.And(query, Query.GT(indexName, BsonValue.Create(lastKeyValue)));
                    }
                    //先按条件查询 再排序 再取数
                    myCursor = mc.Find(query).SetSortOrder(new SortByDocument(indexName, 1)).SetLimit(pageSize);
                }
                else
                { //降序					
                    if (lastKeyValue != null)
                    {
                        query = Query.And(query, Query.LT(indexName, BsonValue.Create(lastKeyValue)));
                    }
                    myCursor = mc.Find(query).SetSortOrder(new SortByDocument(indexName, -1)).SetLimit(pageSize);
                }
                result = myCursor.ToList<T>();
            }
            return result;
        }

        #endregion

    }
}*/
