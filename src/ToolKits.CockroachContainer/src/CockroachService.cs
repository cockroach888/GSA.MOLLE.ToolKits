//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2021 -- Support 文雀
//=========================================================================
// 文件名称：CockroachService.cs
// 项目名称：魂哥自创的自定义服务(伪IOC)容器
// 创建时间：2021-02-28 20:05:47
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.Collections.Concurrent;

namespace GSA.ToolKits.CockroachContainer
{
    /// <summary>
    /// 魂哥自创的自定义服务(伪IOC)容器
    /// </summary>
    internal sealed class CockroachService : ICockroachService
    {
        /// <summary>
        /// 当前服务容器对象
        /// </summary>
        private ConcurrentDictionary<Type, ConcurrentDictionary<string, object>> _currentServices = new ConcurrentDictionary<Type, ConcurrentDictionary<string, object>>();

        #region 接口实现[ICockroachService]

        /// <summary>
        /// 注册指定泛型和名称的服务
        /// </summary>
        /// <typeparam name="T">泛型服务对象</typeparam>
        /// <param name="t">泛型服务对象</param>
        /// <param name="key">名称[别名]</param>
        public void Register<T>(T t, string key = "default") where T : class
        {
            var serviceType = typeof(T);
            if (!_currentServices.ContainsKey(serviceType))
            {
                _currentServices[serviceType] = new ConcurrentDictionary<string, object>();
            }
            _currentServices[serviceType][key] = t;
        }
        /// <summary>
        /// 反注册指定泛型和名称的服务
        /// </summary>
        /// <typeparam name="T">泛型服务对象</typeparam>
        /// <param name="key">名称[别名]</param>
        /// <returns>泛型服务对象</returns>
        public T UnRegister<T>(string key = "default") where T : class
        {
            T result = default;
            var serviceType = typeof(T);
            if (_currentServices.TryGetValue(serviceType, out ConcurrentDictionary<string, object> services))
            {
                if (services.TryRemove(key, out object value))
                {
                    result = value as T;
                }
                if (services.Count < 1)
                {
                    _currentServices.TryRemove(serviceType, out _);
                }
            }
            return result;
        }
        /// <summary>
        /// 获取指定泛型和名称的服务
        /// </summary>
        /// <typeparam name="T">泛型服务对象</typeparam>
        /// <param name="key">名称[别名]</param>
        /// <returns>泛型服务对象</returns>
        public T GetService<T>(string key = "default") where T : class
        {
            var serviceType = typeof(T);
            if (_currentServices.TryGetValue(serviceType, out ConcurrentDictionary<string, object> services))
            {
                if (services.TryGetValue(key, out object value))
                {
                    return value as T;
                }
            }
            return default;
        }

        #endregion

        /// <summary>
        /// 资源释放
        /// </summary>
        public void Dispose() => _currentServices.Clear();
    }
}
