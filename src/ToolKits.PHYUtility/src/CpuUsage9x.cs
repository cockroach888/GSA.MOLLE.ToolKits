//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：CpuUsage9x.cs
// 项目名称：物理操作实用工具集
// 创建时间：2014年2月25日11时3分
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
#if (NET20 || NET35)
using System;
using Microsoft.Win32;

namespace GSA.ToolKits.PHYUtility
{
    /// <summary>
    /// 继承 CPUUsage 类并实现 Windows 9x 系统的查询方法。
    /// </summary>
    /// <remarks>
    /// <p>此类工作在 Windows 98 和 Windows 的千年版。</p>
    /// <p>不应直接在您的代码中使用此类。使用 CPUUsage.Create() 方法来实例化一个 CPUUsage 对象。</p>
    /// </remarks>
    internal sealed class CpuUsage9x : CpuUsage
    {
        /// <summary>
        /// 初始化一个新的 CPUUsage9x 实例。
        /// </summary>
        /// <exception cref="NotSupportedException">其中一个系统调用失败。</exception>
        public CpuUsage9x()
        {
            try
            {
                //通过阅读 'StartStat' 键的值开始计数器
                RegistryKey startKey = Registry.DynData.OpenSubKey(@"PerfStats\StartStat", false);
                if (startKey == null) throw new NotSupportedException();
                startKey.GetValue(@"KERNEL\CPUUsage");
                startKey.Close();
                // open the counter's value key
                m_StatData = Registry.DynData.OpenSubKey(@"PerfStats\StatData", false);
                if (m_StatData == null) throw new NotSupportedException();
            }
            catch (NotSupportedException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new NotSupportedException("查询系统信息时出错。", e);
            }
        }
        /// <summary>
        /// 确定当前的平均 CPU 负载。
        /// </summary>
        /// <returns>一个整数，持有的 CPU 负载百分比。</returns>
        /// <exception cref="NotSupportedException">其中一个系统调用失败。不能获得的 CPU 时间。</exception>
        public override int Query()
        {
            try
            {
                return (int)m_StatData.GetValue(@"KERNEL\CPUUsage");
            }
            catch (Exception e)
            {
                throw new NotSupportedException("查询系统信息时出错。", e);
            }
        }
        /// <summary>
        /// 关闭已分配的资源。
        /// </summary>
        ~CpuUsage9x()
        {
            try
            {
                m_StatData.Close();
            }
            catch { }
            //停止计数器
            try
            {
                RegistryKey stopKey = Registry.DynData.OpenSubKey(@"PerfStats\StopStat", false);
                stopKey.GetValue(@"KERNEL\CPUUsage", false);
                stopKey.Close();
            }
            catch { }
        }
        /// <summary>
        /// 保存的注册表项用来读取 CPU 负载。
        /// </summary>
        private RegistryKey m_StatData;
    }
}
#endif
