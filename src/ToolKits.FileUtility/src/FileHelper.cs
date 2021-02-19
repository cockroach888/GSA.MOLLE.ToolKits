//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：FileHelper.cs
// 项目名称：文件操作实用工具集
// 创建时间：2014年2月20日17时39分
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.IO;

namespace GSA.ToolKits.FileUtility
{
    /// <summary>
    /// 文件操作辅助类
    /// </summary>
    public static class FileHelper
    {

        #region 应用程序路径

        /// <summary>
        /// 日志存放路径
        /// </summary>
        public static string LogPath
        {
            get { return Path.Combine(AppPath, "Logs"); }
        }
        /// <summary>
        /// 应用程序路径
        /// <para>基目录，由程序集冲突解决程序用来探测程序集</para>
        /// </summary>
        public static string AppPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }
        /// <summary>
        /// 应用程序路径
        /// <para>定义模块位置的完全限定路径</para>
        /// </summary>
        public static string AppPathOfFileName
        {
            get
            {
                return System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            }
        }
        /// <summary>
        /// 应用程序路径
        /// <para>包含目录路径的字符串</para>
        /// </summary>
        public static string AppPathOfCurrentDirectory
        {
            get
            {
                return Environment.CurrentDirectory;
            }
        }
        /// <summary>
        /// 应用程序路径
        /// <para>包含当前工作目录的路径的字符串</para>
        /// </summary>
        public static string AppPathOfGetCurrentDirectory
        {
            get
            {
                return Directory.GetCurrentDirectory();
            }
        }
        /// <summary>
        /// 应用程序路径
        /// <para>应用程序基目录的名称</para>
        /// </summary>
        public static string AppPathOfApplicationBase
        {
            get
            {
                return AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            }
        }

        #endregion

        #region 文件命名格式

        /// <summary>
        /// 获得文件名称
        /// 格式：年
        /// </summary>
        /// <returns>yyyyMMdd.log / yyyy-MM-dd.log</returns>
        public static string GetNameByYear()
        {
            return DateTime.Now.ToString("yyyy");
        }
        /// <summary>
        /// 获得文件名称
        /// 格式：年月
        /// </summary>
        /// <param name="isHorizontal">是否启用横杆分隔</param>
        /// <returns>yyyyMMdd.log / yyyy-MM-dd.log</returns>
        public static string GetNameByMonth(bool isHorizontal)
        {
            if (isHorizontal)
            {
                return DateTime.Now.ToString("yyyy-MM");
            }
            else
            {
                return DateTime.Now.ToString("yyyyMM");
            }
        }
        /// <summary>
        /// 获得文件名称
        /// 格式：年月日
        /// </summary>
        /// <param name="isHorizontal">是否启用横杆分隔</param>
        /// <returns>yyyyMMdd.log / yyyy-MM-dd.log</returns>
        public static string GetNameByDate(bool isHorizontal)
        {
            if (isHorizontal)
            {
                return DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                return DateTime.Now.ToString("yyyyMMdd");
            }
        }
        /// <summary>
        /// 获得文件名称
        /// 格式：年月日时
        /// </summary>
        /// <param name="isHorizontal">是否启用横杆分隔</param>
        /// <returns>yyyyMMdd.log / yyyy-MM-dd.log</returns>
        public static string GetNameByHour(bool isHorizontal)
        {
            if (isHorizontal)
            {
                return DateTime.Now.ToString("yyyy-MM-dd-HH");
            }
            else
            {
                return DateTime.Now.ToString("yyyyMMddHH");
            }
        }
        /// <summary>
        /// 获得文件名称
        /// 格式：年月日时分秒
        /// </summary>
        /// <param name="isHorizontal">是否启用横杆分隔</param>
        /// <returns>yyyyMMddHHmmss.log / yyyy-MM-dd-HHmmss.log</returns>
        public static string GetNameByDatetime(bool isHorizontal)
        {
            //获取系统时间
            DateTime _time = DateTime.Now;
            string _tempDT = null;
            if (isHorizontal)
            {
                _tempDT = _time.ToString("yyyy-MM-dd-");
            }
            else
            {
                _tempDT = _time.ToString("yyyyMMdd");
            }
            //时
            if (System.DateTime.Now.Hour < 10)
            {
                _tempDT += "0" + System.DateTime.Now.Hour.ToString();
            }
            else
            {
                _tempDT += System.DateTime.Now.Hour.ToString();
            }
            //分
            if (System.DateTime.Now.Minute < 10)
            {
                _tempDT += "0" + System.DateTime.Now.Minute.ToString();
            }
            else
            {
                _tempDT += System.DateTime.Now.Minute.ToString();
            }
            //秒
            if (System.DateTime.Now.Second < 10)
            {
                _tempDT += "0" + System.DateTime.Now.Second.ToString();
            }
            else
            {
                _tempDT += System.DateTime.Now.Second.ToString();
            }
            return _tempDT;
        }
        /// <summary>
        /// 获得文件名称
        /// 格式：年月日时分秒毫秒
        /// </summary>
        /// <param name="isHorizontal">是否启用横杆分隔</param>
        /// <returns>yyyyMMddHHmmssfff.log / yyyy-MM-dd-HHmmssfff.log</returns>
        public static string GetNameByALL(bool isHorizontal)
        {
            //获取系统时间
            DateTime _time = DateTime.Now;
            string _tempDT = null;
            if (isHorizontal)
            {
                _tempDT = _time.ToString("yyyy-MM-dd-");
            }
            else
            {
                _tempDT = _time.ToString("yyyyMMdd");
            }
            //时
            if (System.DateTime.Now.Hour < 10)
            {
                _tempDT += "0" + System.DateTime.Now.Hour.ToString();
            }
            else
            {
                _tempDT += System.DateTime.Now.Hour.ToString();
            }
            //分
            if (System.DateTime.Now.Minute < 10)
            {
                _tempDT += "0" + System.DateTime.Now.Minute.ToString();
            }
            else
            {
                _tempDT += System.DateTime.Now.Minute.ToString();
            }
            //秒
            if (System.DateTime.Now.Second < 10)
            {
                _tempDT += "0" + System.DateTime.Now.Second.ToString();
            }
            else
            {
                _tempDT += System.DateTime.Now.Second.ToString();
            }
            //毫秒
            if (System.DateTime.Now.Millisecond < 100)
            {
                _tempDT += "0" + DateTime.Now.Millisecond.ToString();
            }
            else if (System.DateTime.Now.Millisecond < 10)
            {
                _tempDT += "00" + DateTime.Now.Millisecond.ToString();
            }
            else
            {
                _tempDT += DateTime.Now.Millisecond.ToString();
            }
            return _tempDT;
        }

        #endregion

        /// <summary>
        /// 获取指定文件的扩展名
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <returns>扩展名</returns>
        public static string GetExtension(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || fileName.IndexOf('.') <= 0) return "";
            fileName = fileName.ToLower().Trim();
            return fileName.Substring(fileName.LastIndexOf('.'), fileName.Length - fileName.LastIndexOf('.'));
        }

        #region 文件备份与恢复

        /// <summary>
        /// 备份文件,当目标文件存在时覆盖
        /// </summary>
        /// <param name="sourceFileName">源文件名</param>
        /// <param name="destFileName">目标文件名</param>
        /// <returns>操作是否成功</returns>
        public static bool BackupFile(string sourceFileName, string destFileName)
        {
            return BackupFile(sourceFileName, destFileName, true);
        }
        /// <summary>
        /// 备份文件
        /// </summary>
        /// <param name="sourceFileName">源文件名</param>
        /// <param name="destFileName">目标文件名</param>
        /// <param name="overwrite">当目标文件存在时是否覆盖</param>
        /// <returns>操作是否成功</returns>
        public static bool BackupFile(string sourceFileName, string destFileName, bool overwrite)
        {
            if (!File.Exists(sourceFileName)) throw new FileNotFoundException(sourceFileName + "文件不存在！");

            if (!overwrite && File.Exists(destFileName)) return false;
            try
            {
                File.Copy(sourceFileName, destFileName, true);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 恢复文件
        /// </summary>
        /// <param name="backupFileName">备份文件名</param>
        /// <param name="targetFileName">要恢复的文件名</param>
        /// <returns>操作是否成功</returns>
        public static bool RestoreFile(string backupFileName, string targetFileName)
        {
            return RestoreFile(backupFileName, targetFileName, null);
        }
        /// <summary>
        /// 恢复文件
        /// </summary>
        /// <param name="backupFileName">备份文件名</param>
        /// <param name="targetFileName">要恢复的文件名</param>
        /// <param name="backupTargetFileName">要恢复文件再次备份的名称,如果为null,则不再备份恢复文件</param>
        /// <returns>操作是否成功</returns>
        public static bool RestoreFile(string backupFileName, string targetFileName, string backupTargetFileName)
        {
            try
            {
                if (!File.Exists(backupFileName)) throw new FileNotFoundException(backupFileName + "文件不存在！");
                if (backupTargetFileName != null)
                {
                    if (!File.Exists(targetFileName))
                    {
                        throw new FileNotFoundException(targetFileName + "文件不存在！无法备份此文件！");
                    }
                    else
                    {
                        File.Copy(targetFileName, backupTargetFileName, true);
                    }
                }
                File.Delete(targetFileName);
                File.Copy(backupFileName, targetFileName);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        #endregion

    }
}
