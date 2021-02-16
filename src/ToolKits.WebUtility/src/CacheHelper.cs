//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：CacheHelper.cs
// 项目名称：网页网站实用工具集
// 创建时间：2014年2月21日15时53分
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
#if NETFRAMEWORK
using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace ToolKits.WebUtility
{
    /// <summary>
    /// 缓存操作辅助类
    /// </summary>
    public static class CacheHelper
    {
        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="keyName">引用该项的缓存键</param>
        /// <returns>缓存数据对象</returns>
        public static object Get(string keyName)
        {
            return HttpRuntime.Cache[keyName] != null ? HttpRuntime.Cache[keyName] : null;
        }

        #region 缓存添加

        /// <summary>
        /// 添加缓存对象
        /// <para>半小时不访问便移除</para>
        /// </summary>
        /// <param name="keyName">引用该项的缓存键</param>
        /// <param name="keyValue">要添加到缓存的项</param>
        /// <returns>缓存数据对象</returns>
        public static object AddHalf(string keyName, object keyValue)
        {
            return Add(keyName, keyValue, 30);
        }
        /// <summary>
        /// 添加缓存对象
        /// <para>一小时不访问便移除</para>
        /// </summary>
        /// <param name="keyName">引用该项的缓存键</param>
        /// <param name="keyValue">要添加到缓存的项</param>
        /// <returns>缓存数据对象</returns>
        public static object AddHour(string keyName, object keyValue)
        {
            return Add(keyName, keyValue, 60);
        }
        /// <summary>
        /// 添加缓存对象
        /// <para>定时不访问便移除</para>
        /// </summary>
        /// <param name="keyName">引用该项的缓存键</param>
        /// <param name="keyValue">要添加到缓存的项</param>
        /// <param name="times">缓存过期时间间隔[分钟]</param>
        /// <returns>缓存数据对象</returns>
        public static object Add(string keyName, object keyValue, double times)
        {
            return Add(keyName, keyValue, System.TimeSpan.FromMinutes(times), CacheItemPriority.Normal);
        }
        /// <summary>
        /// 添加缓存对象
        /// <para>永久不到期</para>
        /// </summary>
        /// <param name="keyName">引用该项的缓存键</param>
        /// <param name="keyValue">要添加到缓存的项</param>
        /// <param name="priority">具有较低成本的对象在具有较高成本的对象之前从缓存被移除</param>
        /// <returns>缓存数据对象</returns>
        public static object Add(string keyName, object keyValue, CacheItemPriority priority)
        {
            if (HttpRuntime.Cache[keyName] == null && keyValue != null)
            {
                return HttpRuntime.Cache.Add(keyName, keyValue, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, priority, null);
            }
            return null;
        }
        /// <summary>
        /// 添加缓存对象
        /// <para>定时不访问便移除</para>
        /// </summary>
        /// <param name="keyName">引用该项的缓存键</param>
        /// <param name="keyValue">要添加到缓存的项</param>
        /// <param name="slidingExpiration">缓存过期时间间隔[分钟]</param>
        /// <param name="priority">具有较低成本的对象在具有较高成本的对象之前从缓存被移除</param>
        /// <returns>缓存数据对象</returns>
        public static object Add(string keyName, object keyValue, TimeSpan slidingExpiration, CacheItemPriority priority)
        {
            if (HttpRuntime.Cache[keyName] == null && keyValue != null)
            {
                return HttpRuntime.Cache.Add(keyName, keyValue, null, Cache.NoAbsoluteExpiration, slidingExpiration, priority, null);
            }
            return null;
        }
        /// <summary>
        /// 添加缓存对象
        /// <para>在移除时执行指定事件</para>
        /// </summary>
        /// <param name="keyName">引用该项的缓存键</param>
        /// <param name="keyValue">要添加到缓存的项</param>
        /// <param name="absoluteExpiration">添加对象将到期并被从缓存中移除的时间</param>
        /// <param name="slidingExpiration">缓存过期时间间隔[分钟]</param>
        /// <param name="priority">具有较低成本的对象在具有较高成本的对象之前从缓存被移除</param>
        /// <param name="onRemovedCallback">移除对象时所调用的委托</param>
        /// <returns>缓存数据对象</returns>
        public static object Add(string keyName, object keyValue, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemovedCallback)
        {
            if (HttpRuntime.Cache[keyName] == null && keyValue != null)
            {
                return HttpRuntime.Cache.Add(keyName, keyValue, null, absoluteExpiration, slidingExpiration, priority, onRemovedCallback);
            }
            return null;
        }

        #endregion

        #region 缓存移除

        /// <summary>
        /// 移除缓存对象
        /// <para>移除指定键值名称</para>
        /// </summary>
        /// <param name="keyName">缓存键值名称</param>
        /// <returns>缓存数据对象</returns>
        public static object Remove(string keyName)
        {
            return HttpRuntime.Cache[keyName] != null ? HttpRuntime.Cache.Remove(keyName) : null;
        }
        /// <summary>
        /// 移除缓存对象
        /// <para>移除具有指定键值名称</para>
        /// </summary>
        /// <param name="keyName">缓存键值名称</param>
        public static void RemoveAt(string keyName)
        {
            IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                if (CacheEnum.Key.ToString().IndexOf(keyName) >= 0) HttpRuntime.Cache.Remove(CacheEnum.Key.ToString());
            }
        }
        /// <summary>
        /// 移除缓存对象
        /// <para>移除所有</para>
        /// </summary>
        public static void Remove()
        {
            IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                HttpRuntime.Cache.Remove(CacheEnum.Key.ToString());
            }
        }

        #endregion

    }
}
#endif
