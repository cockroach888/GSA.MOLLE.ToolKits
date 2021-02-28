//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：DawnHelper.cs
// 项目名称：常用方法实用工具集
// 创建时间：2014-02-25 18:13
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using System.Security.Cryptography;
#if (!NET35 && !NET20)
using System.Linq;
#endif
using System.Runtime.Serialization;

namespace GSA.ToolKits.DawnUtility
{
    /// <summary>
    /// 魂哥常用操作辅助类
    /// </summary>
    public static class DawnHelper
    {

        #region 对象状态转换

        /// <summary>
        /// 转换目标对象状态表示形式
        /// 模式：true √、false ×
        /// </summary>
        public static string StatusConvertByObject(object stateFlag)
        {
            if (Convert.ToBoolean(stateFlag))
            {
                return "√";
            }
            else
            {
                return "×";
            }
        }

        #endregion

        #region 月份标识数组

        /// <summary>
        /// 根据阿拉伯数字返回月份的名称
        /// 英文
        /// </summary>	
        public static string[] GetMonthesByEnglish
        {
            get
            {
                return new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            }
        }
        /// <summary>
        /// 根据阿拉伯数字返回月份的名称
        /// 中文
        /// </summary>
        public static string[] GetMonthesByChinese
        {
            get
            {
                return new string[] { "一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月" };
            }
        }

        #endregion

        #region 进程、IIS 进程

        /// <summary>
        /// 检测应用程序是否已经启动
        /// </summary>
        /// <returns>是/否</returns>
        public static bool CheckProgramState()
        {
            int ProceedingCount = 0;
            Process[] ProceddingCon = Process.GetProcesses();
            foreach (Process IsProcedding in ProceddingCon)
            {
                if (IsProcedding.ProcessName == Process.GetCurrentProcess().ProcessName)
                {
                    ProceedingCount += 1;
                }
            }
            if (ProceedingCount > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region JSON 相关

        /// <summary>
        /// 将数据表转换成JSON类型串
        /// </summary>
        /// <param name="dt">要转换的数据表</param>
        /// <returns></returns>
        public static StringBuilder JsonFromDataTable(System.Data.DataTable dt)
        {
            return JsonFromDataTable(dt, true);
        }
        /// <summary>
        /// 将数据表转换成JSON类型串
        /// </summary>
        /// <param name="dt">要转换的数据表</param>
        /// <param name="dt_dispose">数据表转换结束后是否dispose掉</param>
        /// <returns></returns>
        public static StringBuilder JsonFromDataTable(System.Data.DataTable dt, bool dt_dispose)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[\r\n");
            //数据表字段名和类型数组
            string[] dt_field = new string[dt.Columns.Count];
            int i = 0;
            string formatStr = "{{";
            string fieldtype = "";
            foreach (System.Data.DataColumn dc in dt.Columns)
            {
                dt_field[i] = dc.Caption.ToLower().Trim();
                formatStr += "'" + dc.Caption.ToLower().Trim() + "':";
                fieldtype = dc.DataType.ToString().Trim().ToLower();
                if (fieldtype.IndexOf("int") > 0 || fieldtype.IndexOf("deci") > 0 ||
                    fieldtype.IndexOf("floa") > 0 || fieldtype.IndexOf("doub") > 0 ||
                    fieldtype.IndexOf("bool") > 0)
                {
                    formatStr += "{" + i + "}";
                }
                else
                {
                    formatStr += "'{" + i + "}'";
                }
                formatStr += ",";
                i++;
            }

            if (formatStr.EndsWith(",")) formatStr = formatStr.Substring(0, formatStr.Length - 1);//去掉尾部","号
            formatStr += "}},";
            i = 0;
            object[] objectArray = new object[dt_field.Length];
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                foreach (string fieldname in dt_field)
                {   //对 \ , ' 符号进行转换 
                    objectArray[i] = dr[dt_field[i]].ToString().Trim().Replace("\\", "\\\\").Replace("'", "\\'");
                    switch (objectArray[i].ToString())
                    {
                        case "True":
                            {
                                objectArray[i] = "true"; break;
                            }
                        case "False":
                            {
                                objectArray[i] = "false"; break;
                            }
                        default: break;
                    }
                    i++;
                }
                i = 0;
                stringBuilder.Append(string.Format(formatStr, objectArray));
            }
            if (stringBuilder.ToString().EndsWith(",")) stringBuilder.Remove(stringBuilder.Length - 1, 1);//去掉尾部","号
            if (dt_dispose) dt.Dispose();
            return stringBuilder.Append("\r\n];");
        }
        /// <summary>
        /// Json特符字符过滤，参见http://www.json.org/
        /// </summary>
        /// <param name="sourceStr">要过滤的源字符串</param>
        /// <returns>返回过滤的字符串</returns>
        public static string JsonCharFilter(string sourceStr)
        {
            sourceStr = sourceStr.Replace("\\", "\\\\");
            sourceStr = sourceStr.Replace("\b", "\\\b");
            sourceStr = sourceStr.Replace("\t", "\\\t");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\f", "\\\f");
            sourceStr = sourceStr.Replace("\r", "\\\r");
            return sourceStr.Replace("\"", "\\\"");
        }

        #endregion

        #region 数据对象克隆

        /// <summary>
        /// 利用序列化与反序列化完成引用对象的克隆
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="objSource">源对象</param>
        /// <param name="useMode">
        /// 采用模式
        /// <para>1 BinaryFormatter</para>
        /// <para>2 XmlSerializer</para>
        /// </param>
        /// <returns>克隆对象</returns>
        public static T CloneTo<T>(T objSource, byte useMode = 1)
        {
            using (var ms = new MemoryStream())
            {
                if (1 == useMode)
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(ms, objSource);
                    ms.Seek(0, SeekOrigin.Begin);
                    return (T)formatter.Deserialize(ms);
                }
                else if (2 == useMode)
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(ms, objSource);
                    ms.Seek(0, SeekOrigin.Begin);
                    return (T)serializer.Deserialize(ms);
                }
                return default;
            }
        }

#if (!NET35 && !NET20)
        /// <summary>
        /// List克隆
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="listToClone">克隆对象</param>
        /// <returns>克隆后的对象</returns>
        public static List<T> CloneT<T>(this List<T> listToClone) where T : ICloneable {
			return listToClone.Select(item => (T)item.Clone()).ToList();
		}
#endif

        #endregion

        #region 文件哈希值比较

        /// <summary>
        /// 通过哈希值比较两个文件是否完全相等
        /// </summary>
        /// <param name="filePath1">文件1</param>
        /// <param name="filePath2">文件2</param>
        /// <returns>比较结果： true 相等，false 不相等。</returns>
        public static bool CompareFileHash(string filePath1, string filePath2)
        {

            using (var hash = HashAlgorithm.Create())
            {
                byte[] buffer1, buffer2;
                //计算第一个文件的哈希值
                using (var fs1 = new FileStream(filePath1, FileMode.Open, FileAccess.Read))
                {
                    buffer1 = hash.ComputeHash(fs1);
                    fs1.Close();
                }
                //计算第二个文件的哈希值
                using (var fs2 = new FileStream(filePath2, FileMode.Open, FileAccess.Read))
                {
                    buffer2 = hash.ComputeHash(fs2);
                    fs2.Close();
                }
                //比较两个哈希值
                return BitConverter.ToString(buffer1) == BitConverter.ToString(buffer2) ? true : false;
            }
        }

        #endregion

    }
}
