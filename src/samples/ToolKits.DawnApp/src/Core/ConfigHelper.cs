//=========================================================================
//**   魂哥常用工具集（CRS.CommonUtility）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2021 -- Support 文雀
//=========================================================================
// 文件名称：ConfigHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2021-02-23 21:51:53
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using GSA.ToolKits.DawnUtility;
using System.Configuration;

namespace GSA.ToolKits.DawnApp.Core
{
    /// <summary>
    /// 配置信息助手
    /// </summary>
    public sealed class ConfigHelper
    {
        /// <summary>
        /// 应用名称
        /// </summary>
        public static string AppName
        {
            get
            {
                var name = ConfigurationManager.AppSettings["AppName"];
                return CryptoHelper.Decrypt(name);
            }
        }
        /// <summary>
        /// 版本号
        /// </summary>
        public static string AppVersion
        {
            get
            {
                var ver = ConfigurationManager.AppSettings["AppVersion"];
                return CryptoHelper.Decrypt(ver);
            }
        }
    }
}
