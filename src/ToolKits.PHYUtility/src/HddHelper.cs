//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：HddHelper.cs
// 项目名称：物理操作实用工具集
// 创建时间：2014年2月25日10时55分
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.Management;

namespace GSA.ToolKits.PHYUtility
{
    /// <summary>
    /// 硬盘相关操作辅助类
    /// </summary>
    public static class HddHelper
    {
        /// <summary>
        /// 获取硬盘相应分区的序列号
        /// </summary>
        /// <returns>序列号</returns>
        public static string GetSerialNumberAll()
        {
            string Dri = "";
            ManagementClass mo = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection mc = mo.GetInstances();
            foreach (ManagementObject m in mc)
            {
                if (Convert.ToString(m.Properties["DriveType"].Value) == "3")
                {
                    Dri = Dri + m.Properties["VolumeSerialNumber"].Value.ToString() + "\n";
                }
            }
            Dri = Dri.Substring(0, Dri.Length - 1);
            return Dri;
        }
        /// <summary>
        /// 获取硬盘相应分区的序列号
        /// </summary>
        /// <param name="Drive">盘符（如 C）</param> 
        /// <returns>序列号</returns>
        public static string GetSerialNumber(string Drive)
        {
            string Dri = "";
            ManagementClass mo = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection mc = mo.GetInstances();
            foreach (ManagementObject m in mc)
            {
                if (Convert.ToString(m.Properties["DriveType"].Value) == "3")
                {
                    if (m.Properties["Name"].Value.ToString().ToUpper().Trim().Substring(0, 1) == Drive.ToUpper().Trim())
                    {
                        Dri = Dri + m.Properties["VolumeSerialNumber"].Value.ToString();
                        break;
                    }
                }
            }
            return Dri;
        }
    }
}
