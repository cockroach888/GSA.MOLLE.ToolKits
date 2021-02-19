//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：LicenseHelper.cs
// 项目名称：窗体常用操作工具集
// 创建时间：2014-03-21 16:17:15
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.ComponentModel;
using System.IO;

namespace GSA.ToolKits.FormUtility
{
    /// <summary>
    /// 许可证管理辅助类
    /// <para>应用程序目录 License.lic 文件。</para>
    /// <para>使用方法：</para>
    /// <para>类文件头部加上：[LicenseProvider(typeof(LicenseHelper))] 标识</para>
    /// <para>构造函数中加上：LicenseManager.Validate(typeof(类名称), null);</para>
    /// </summary>    
    public class LicenseHelper : LicenseProvider
    {
        /// <summary>
        /// 许可证管理辅助类
        /// </summary>
        /// <param name="context">授权对象</param>
        /// <param name="type">类型</param>
        /// <param name="instance">实例对象</param>
        /// <param name="allowExceptions">允许异常</param>
        /// <returns>许可证实体</returns>
        public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
        {            
            //if (context.UsageMode == LicenseUsageMode.Designtime)
            //{
            //    return new LicenseMDL(this, "OK");
            //}
            //else
            //{
            //    string licenseFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DawnLicense.lic");
            //    if (File.Exists(licenseFile))
            //    {
            //        return new LicenseMDL(this, "OK");
            //    }
            //    else
            //    {
            //        throw new LicenseException(type);
            //    }
            //}
            string licenseFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "License.lic");
            if (File.Exists(licenseFile))
            {
                return new LicenseMDL(this, File.ReadAllText(licenseFile));
            }
            else
            {
                throw new LicenseException(type);
            }
        }
    }
    /// <summary>
    /// 许可证实体类
    /// </summary>
    internal class LicenseMDL : License
    {
        /// <summary>
        /// 许可证管理辅助类
        /// </summary>
        private LicenseHelper FLicenseProvider;
        /// <summary>
        /// 许可证密钥
        /// </summary>
        private string FLicenseKey;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="licenseProvider">许可证管理辅助类</param>
        /// <param name="licenseKey">许可证密钥</param>
        public LicenseMDL(LicenseHelper licenseProvider, string licenseKey)
        {
            this.FLicenseProvider = licenseProvider;
            this.FLicenseKey = licenseKey;
        }
        /// <summary>
        /// 许可证密钥
        /// </summary>
        public override string LicenseKey
        {
            get
            {
                return FLicenseKey;
            }
        }
        /// <summary>
        /// 资源释放
        /// </summary>
        public override void Dispose()
        {
            this.FLicenseProvider = null;
            this.FLicenseKey = null;
        }
    }
}
