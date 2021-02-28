//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2021 -- Support 文雀
//=========================================================================
// 文件名称：XMLUtility.cs
// 项目名称：静止环境观测操作工具集
// 创建时间：2021-02-28 16:24:02
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using Newtonsoft.Json;
using System;
using System.IO;
#if (NET5_0 || NETCOREAPP || NETSTANDARD || NET48 || NET472 || NET471 || NET47 || NET462 || NET461 || NET46 || NET452 || NET451)
using System.Threading.Tasks;
#endif
using System.Xml;

namespace GSA.ToolKits.GoesUtility
{
    /// <summary>
    /// XML 文件处理BIUBIU工具集
    /// </summary>
    public static class XMLUtility
    {

        #region 加载指定XML文件并序列化为指定泛型对象

        /// <summary>
        /// 加载指定XML文件并序列化为指定泛型对象
        /// <para>异步的</para>
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="xmlFilePath">XML文件路径(绝对路径)</param>
        /// <returns>加载结果</returns>
        public static T LoadXMLTo<T>(string xmlFilePath)
        {
            if (!File.Exists(xmlFilePath))
            {
                throw new Exception("对不起！未能找到需要加载的XML文件；请确认文件是否存在，及路径是否正确。");
            }

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            var root = xmlDoc.DocumentElement;
            var tmpString = JsonConvert.SerializeXmlNode(root, Newtonsoft.Json.Formatting.None, true);
            return JsonConvert.DeserializeObject<T>(tmpString);
        }

        #endregion

        #region 加载指定XML文件并转换为JSON字符串

        /// <summary>
        /// 加载指定XML文件并转换为JSON字符串
        /// <para>异步的</para>
        /// </summary>
        /// <param name="xmlFilePath">XML文件路径(绝对路径)</param>
        /// <returns>JSON字符串</returns>
        public static string LoadXMLtoJSON(string xmlFilePath)
        {
            if (!File.Exists(xmlFilePath))
            {
                throw new Exception("对不起！未能找到需要加载的XML文件；请确认文件是否存在，及路径是否正确。");
            }

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            var root = xmlDoc.DocumentElement;
            return JsonConvert.SerializeXmlNode(root, Newtonsoft.Json.Formatting.None, true);
        }

        #endregion

        #region 将指定泛型数据对象保存为XML结构文件

        /// <summary>
        /// 将指定泛型数据对象保存为XML结构文件
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="dataInfo">需要保存的数据泛型对象</param>
        /// <param name="xmlSavePath">保存XML文件路径(绝对路径)</param>
        /// <param name="xmlRootName">XML根据节点名称</param>
        /// <returns>保存结果</returns>
        public static void SaveXML<T>(T dataInfo, string xmlSavePath, string xmlRootName = "root")
        {
            var jsonString = JsonConvert.SerializeObject(dataInfo);
            SaveXML(jsonString, xmlSavePath, xmlRootName);
        }

        #endregion

        #region 将指定JSON数据对象保存为XML结构文件

        /// <summary>
        /// 将指定JSON数据对象保存为XML结构文件
        /// <para>异步的</para>
        /// </summary>
        /// <param name="jsonString">JSON字符串</param>
        /// <param name="xmlSavePath">保存XML文件路径(绝对路径)</param>
        /// <param name="xmlRootName">XML根据节点名称</param>
        /// <returns>保存结果</returns>
        public static void SaveXML(string jsonString, string xmlSavePath, string xmlRootName = "root")
        {
            var xmlDoc = JsonConvert.DeserializeXmlNode(jsonString, xmlRootName, true);
            xmlDoc.Save(xmlSavePath);
        }

        #endregion

#if (NET5_0 || NETCOREAPP || NETSTANDARD || NET48 || NET472 || NET471 || NET47 || NET462 || NET461 || NET46 || NET452 || NET451)

        #region 加载指定XML文件并序列化为指定泛型对象

        /// <summary>
        /// 加载指定XML文件并序列化为指定泛型对象
        /// <para>异步的</para>
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="xmlFilePath">XML文件路径(绝对路径)</param>
        /// <returns>加载结果</returns>
        public static Task<T> LoadXMLToAsync<T>(string xmlFilePath)
        {
            var tcsResult = new TaskCompletionSource<T>();
            try
            {
                if (!File.Exists(xmlFilePath))
                {
                    var ex = new Exception("对不起！未能找到需要加载的XML文件；请确认文件是否存在，及路径是否正确。");
                    tcsResult.SetException(ex);
                }
                else
                {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlFilePath);
                    var root = xmlDoc.DocumentElement;
                    var tmpString = JsonConvert.SerializeXmlNode(root, Newtonsoft.Json.Formatting.None, true);
                    var result = JsonConvert.DeserializeObject<T>(tmpString);
                    tcsResult.SetResult(result);
                }
            }
            catch (Exception ex)
            {
                tcsResult.SetException(ex);
            }
            return tcsResult.Task;
        }

        #endregion

        #region 加载指定XML文件并转换为JSON字符串

        /// <summary>
        /// 加载指定XML文件并转换为JSON字符串
        /// <para>异步的</para>
        /// </summary>
        /// <param name="xmlFilePath">XML文件路径(绝对路径)</param>
        /// <returns>JSON字符串</returns>
        public static Task<string> LoadXMLtoJSONAsync(string xmlFilePath)
        {
            var tcsResult = new TaskCompletionSource<string>();
            try
            {
                if (!File.Exists(xmlFilePath))
                {
                    var ex = new Exception("对不起！未能找到需要加载的XML文件；请确认文件是否存在，及路径是否正确。");
                    tcsResult.SetException(ex);
                }
                else
                {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlFilePath);
                    var root = xmlDoc.DocumentElement;
                    var jsonString = JsonConvert.SerializeXmlNode(root, Newtonsoft.Json.Formatting.None, true);
                    tcsResult.SetResult(jsonString);
                }
            }
            catch (Exception ex)
            {
                tcsResult.SetException(ex);
            }
            return tcsResult.Task;
        }

        #endregion

        #region 将指定泛型数据对象保存为XML结构文件

        /// <summary>
        /// 将指定泛型数据对象保存为XML结构文件
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="dataInfo">需要保存的数据泛型对象</param>
        /// <param name="xmlSavePath">保存XML文件路径(绝对路径)</param>
        /// <param name="xmlRootName">XML根据节点名称</param>
        /// <returns>保存结果</returns>
        public static Task SaveXMLAsync<T>(T dataInfo, string xmlSavePath, string xmlRootName = "root")
        {
            var jsonString = JsonConvert.SerializeObject(dataInfo);
            return SaveXMLAsync(jsonString, xmlSavePath, xmlRootName);
        }

        #endregion

        #region 将指定JSON数据对象保存为XML结构文件

        /// <summary>
        /// 将指定JSON数据对象保存为XML结构文件
        /// <para>异步的</para>
        /// </summary>
        /// <param name="jsonString">JSON字符串</param>
        /// <param name="xmlSavePath">保存XML文件路径(绝对路径)</param>
        /// <param name="xmlRootName">XML根据节点名称</param>
        /// <returns>保存结果</returns>
        public static Task SaveXMLAsync(string jsonString, string xmlSavePath, string xmlRootName = "root")
        {
            var xmlDoc = JsonConvert.DeserializeXmlNode(jsonString, xmlRootName, true);
            xmlDoc.Save(xmlSavePath);
            return Task.CompletedTask;
        }

        #endregion

#endif

    }
}
