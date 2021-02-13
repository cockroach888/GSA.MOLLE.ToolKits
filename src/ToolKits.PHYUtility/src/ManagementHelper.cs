//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：ManagementHelper.cs
// 项目名称：物理操作实用工具集
// 创建时间：2014年2月25日11时26分
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

namespace ToolKits.PHYUtility
{
    /// <summary>
    /// 物理硬件相关操作辅助类
    /// </summary>
    public class ManagementHelper
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        public static ManagementHelper Instance()
        {
            if (FInstance == null) FInstance = new ManagementHelper();
            return FInstance;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        protected ManagementHelper()
        {
            CpuID = GetCpuID();
            MacAddress = GetMacAddress();
            DiskID = GetDiskID();
            DiskVolume = GetDiskVolumeSerialNumber();
            IpAddress = GetIPAddress();
            LoginUserName = GetUserName();
            SystemType = GetSystemType();
            TotalPhysicalMemory = GetTotalPhysicalMemory();
            ComputerName = GetComputerName();
        }        

        #region CPU序列号

        /// <summary>
        /// CPU序列号（ID）
        /// </summary>
        /// <returns>CPU序列号</returns>
        string GetCpuID()
        {
            try
            {
                //获取CPU序列号代码
                string cpuInfo = "";//cpu序列号
                using (ManagementClass mc = new ManagementClass("Win32_Processor"))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                        {
                            cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                        }
                        return cpuInfo;
                    }
                }
            }
            catch
            {
                return "Unknown";
            }
        }

        #endregion

        #region 网卡MAC地址

        /// <summary>
        /// 网卡MAC地址
        /// </summary>
        /// <returns>网卡MAC地址</returns>
        string GetMacAddress()
        {
            try
            {
                //获取网卡Mac地址
                string mac = "";
                using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                        {
                            if ((bool)mo["IPEnabled"] == true)
                            {
                                mac = mo["MacAddress"].ToString();
                                break;
                            }
                        }
                        return mac;
                    }
                }
            }
            catch
            {
                return "Unknown";
            }
        }

        #endregion

        #region 计算机IP地址

        /// <summary>
        /// 计算机IP地址
        /// </summary>
        /// <returns>计算机IP地址</returns>
        string GetIPAddress()
        {
            try
            {
                //获取IP地址
                string st = "";
                using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                        {
                            if ((bool)mo["IPEnabled"] == true)
                            {
                                //st=mo["IpAddress"].ToString();
                                System.Array ar;
                                ar = (System.Array)(mo.Properties["IpAddress"].Value);
                                st = ar.GetValue(0).ToString();
                                break;
                            }
                        }
                        return st;
                    }
                }
            }
            catch
            {
                return "Unknown";
            }
        }

        #endregion

        #region 硬盘序列号

        /// <summary>
        /// 硬盘序列号（ID）
        /// </summary>
        /// <returns>硬盘序列号</returns>
        string GetDiskID()
        {
            try
            {
                //获取硬盘ID
                String HDid = "";
                using (ManagementClass mc = new ManagementClass("Win32_DiskDrive"))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                        {
                            HDid = (string)mo.Properties["Model"].Value;
                        }
                        return HDid;
                    }
                }
            }
            catch
            {
                return "Unknown";
            }
        }        

        #endregion

        #region 硬盘卷标号

        /// <summary>
        /// 取得设备硬盘C盘的卷标号
        /// </summary>
        /// <returns>C盘卷标号</returns>
        string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        #endregion

        #region 登录用户名

        /// <summary>
        /// 操作系统的登录用户名
        /// </summary>
        /// <returns>登录用户名</returns>
        string GetUserName()
        {
            try
            {
                string st = "";
                using (ManagementClass mc = new ManagementClass("Win32_ComputerSystem"))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                        {
                            st = mo["UserName"].ToString();
                        }
                        return st;
                    }
                }
            }
            catch
            {
                return "Unknown";
            }
        }

        #endregion

        #region PC系统类型

        /// <summary>
        /// PC类型
        /// </summary>
        /// <returns>PC系统类型</returns>
        string GetSystemType()
        {
            try
            {
                string st = "";
                using (ManagementClass mc = new ManagementClass("Win32_ComputerSystem"))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                        {
                            st = mo["SystemType"].ToString();
                        }
                        return st;
                    }
                }
            }
            catch
            {
                return "Unknown";
            }
        }

        #endregion

        #region 物理内存

        /// <summary>
        /// 物理内存
        /// </summary>
        /// <returns>物理内存</returns>
        string GetTotalPhysicalMemory()
        {
            try
            {
                string st = "";
                using (ManagementClass mc = new ManagementClass("Win32_ComputerSystem"))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                        {
                            st = mo["TotalPhysicalMemory"].ToString();
                        }
                        return st;
                    }
                }
            }
            catch
            {
                return "Unknown";
            }
        }

        #endregion

        #region 计算机名称

        /// <summary>
        /// 计算机名称
        /// </summary>
        /// <returns>计算机名称</returns>
        string GetComputerName()
        {
            try
            {
                return System.Environment.GetEnvironmentVariable("ComputerName");
            }
            catch
            {
                return "Unknown";
            }
        }

        #endregion

        #region 成员属性

        /// <summary>
        /// CPU序列号（ID）
        /// </summary>
        public string CpuID { get; private set; }
        /// <summary>
        /// 网卡MAC地址
        /// </summary>
        public string MacAddress { get; private set; }
        /// <summary>
        /// 硬盘序列号（ID）
        /// </summary>
        public string DiskID { get; private set; }
        /// <summary>
        /// 硬盘卷标号（C盘）
        /// </summary>
        public string DiskVolume { get; private set; }
        /// <summary>
        /// 计算机IP地址
        /// </summary>
        public string IpAddress { get; private set; }
        /// <summary>
        /// 当前登录用户名名称
        /// </summary>
        public string LoginUserName { get; private set; }
        /// <summary>
        /// 计算机名称
        /// </summary>
        public string ComputerName { get; private set; }
        /// <summary>
        /// 系统型号（操作系统·版本号）
        /// </summary>
        public string SystemType { get; private set; }
        /// <summary>
        /// 总物理内存（单位：MB）
        /// </summary>
        public string TotalPhysicalMemory { get; private set; }
        /// <summary>
        /// 执行
        /// </summary>
        private static ManagementHelper FInstance { get; set; }

        #endregion

    }
}
