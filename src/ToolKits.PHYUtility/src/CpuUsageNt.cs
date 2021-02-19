//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：CpuUsageNt.cs
// 项目名称：物理操作实用工具集
// 创建时间：2014年2月25日11时8分
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.Runtime.InteropServices;

namespace GSA.ToolKits.PHYUtility
{
    /// <summary>
    /// 继承 CPUUsage 类并实现 Windows NT 系统的查询方法。
    /// </summary>
    /// <remarks>
    /// <p>此类在 Windows NT4，Windows 2000、 Windows XP、 Windows.NET 服务器上的工作和较高。</p>
    /// <p>不应直接在您的代码中使用此类。使用 CPUUsage.Create() 方法来实例化一个 CPUUsage 对象。</p>
    /// </remarks>
    internal sealed class CpuUsageNt : CpuUsage
    {
        /// <summary>
        /// 初始化一个新的 CpuUsageNt 实例。
        /// </summary>
        /// <exception cref="NotSupportedException">其中一个系统调用失败。</exception>
        public CpuUsageNt()
        {
            byte[] timeInfo = new byte[32];		// SYSTEM_TIME_INFORMATION structure
            byte[] perfInfo = new byte[312];	// SYSTEM_PERFORMANCE_INFORMATION structure
            byte[] baseInfo = new byte[44];		// SYSTEM_BASIC_INFORMATION structure
            int ret;
            //获取新的系统时间
            ret = NtQuerySystemInformation(SYSTEM_TIMEINFORMATION, timeInfo, timeInfo.Length, IntPtr.Zero);
            if (ret != NO_ERROR) throw new NotSupportedException();
            //获得新 CPU 空闲时间
            ret = NtQuerySystemInformation(SYSTEM_PERFORMANCEINFORMATION, perfInfo, perfInfo.Length, IntPtr.Zero);
            if (ret != NO_ERROR) throw new NotSupportedException();
            //处理器系统中获取数
            ret = NtQuerySystemInformation(SYSTEM_BASICINFORMATION, baseInfo, baseInfo.Length, IntPtr.Zero);
            if (ret != NO_ERROR) throw new NotSupportedException();
            //存储新 CPU 的空闲的处理器数量和系统时间
            oldIdleTime = BitConverter.ToInt64(perfInfo, 0); // SYSTEM_PERFORMANCE_INFORMATION.liIdleTime
            oldSystemTime = BitConverter.ToInt64(timeInfo, 8); // SYSTEM_TIME_INFORMATION.liKeSystemTime
            processorCount = baseInfo[40];
        }
        /// <summary>
        /// 确定当前的平均 CPU 负载。
        /// </summary>
        /// <returns>一个整数，持有的 CPU 负载百分比。</returns>
        /// <exception cref="NotSupportedException">其中一个系统调用失败。不能获得的 CPU 时间。</exception>
        public override int Query()
        {
            byte[] timeInfo = new byte[32];		// SYSTEM_TIME_INFORMATION structure
            byte[] perfInfo = new byte[312];	// SYSTEM_PERFORMANCE_INFORMATION structure
            double dbIdleTime, dbSystemTime;
            int ret;
            //获取新的系统时间
            ret = NtQuerySystemInformation(SYSTEM_TIMEINFORMATION, timeInfo, timeInfo.Length, IntPtr.Zero);
            if (ret != NO_ERROR) throw new NotSupportedException();
            //获得新 CPU 空闲时间
            ret = NtQuerySystemInformation(SYSTEM_PERFORMANCEINFORMATION, perfInfo, perfInfo.Length, IntPtr.Zero);
            if (ret != NO_ERROR) throw new NotSupportedException();
            // CurrentValue = NewValue - OldValue
            dbIdleTime = BitConverter.ToInt64(perfInfo, 0) - oldIdleTime;
            dbSystemTime = BitConverter.ToInt64(timeInfo, 8) - oldSystemTime;
            // CurrentCpuIdle = IdleTime / SystemTime
            if (dbSystemTime != 0) dbIdleTime = dbIdleTime / dbSystemTime;
            // CurrentCpuUsage% = 100 - (CurrentCpuIdle * 100) / NumberOfProcessors
            dbIdleTime = 100.0 - dbIdleTime * 100.0 / processorCount + 0.5;
            //存储新 CPU 的空闲和系统时间
            oldIdleTime = BitConverter.ToInt64(perfInfo, 0); // SYSTEM_PERFORMANCE_INFORMATION.liIdleTime
            oldSystemTime = BitConverter.ToInt64(timeInfo, 8); // SYSTEM_TIME_INFORMATION.liKeSystemTime
            return (int)dbIdleTime;
        }
        /// <summary>
        /// NtQuerySystemInformation 是一个内部的 Windows 函数，检索的各种系统信息。
        /// </summary>
        /// <param name="dwInfoType">SYSTEM_INFORMATION_CLASS，指示要检索的系统信息的种类中列举的值之一。</param>
        /// <param name="lpStructure">指向所请求的信息在哪里要返回的缓冲区。大小和结构的这一信息而异 SystemInformationClass 参数的值。</param>
        /// <param name="dwSize">请参见参数指向的缓冲区的长度。</param>
        /// <param name="returnLength">可选的指针，指向哪里该函数写入请求的信息的实际大小的位置。</param>
        /// <returns>返回一个成功如果成功的话，NTSTATUS 和 NTSTATUS 错误代码否则。</returns>
        [DllImport("ntdll", EntryPoint = "NtQuerySystemInformation")]
        private static extern int NtQuerySystemInformation(int dwInfoType, byte[] lpStructure, int dwSize, IntPtr returnLength);
        /// <summary>
        /// 返回在一个 SYSTEM_BASIC_INFORMATION 结构系统中的处理器数。
        /// </summary>
        private const int SYSTEM_BASICINFORMATION = 0;
        /// <summary>
        /// 返回一个不透明的 SYSTEM_PERFORMANCE_INFORMATION 结构。
        /// </summary>
        private const int SYSTEM_PERFORMANCEINFORMATION = 2;
        /// <summary>
        /// 返回一个不透明的 SYSTEM_TIMEOFDAY_INFORMATION 结构。
        /// </summary>
        private const int SYSTEM_TIMEINFORMATION = 3;
        /// <summary>
        /// 由 NtQuerySystemInformation 没有发生错误时返回的值。
        /// </summary>
        private const int NO_ERROR = 0;
        /// <summary>
        /// 保存的旧的空闲时间。
        /// </summary>
        private long oldIdleTime;
        /// <summary>
        /// 保存旧的系统时间。
        /// </summary>
        private long oldSystemTime;
        /// <summary>
        /// 在系统中保存处理器的数。
        /// </summary>
        private double processorCount;
    }
}
