//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：PerfCounter.cs
// 项目名称：物理操作实用工具集
// 创建时间：2014年2月25日10时47分
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
using System.Runtime.InteropServices;
using System.Threading;

namespace ToolKits.PHYUtility
{
    /// <summary>
    /// 性能计数器操作辅助类
    /// </summary>
    public class PerfCounter
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="startTimer">是否立即执行Start()方法</param>
        public PerfCounter(bool startTimer)
        {
            FStartTime = 0;
            FStopTime = 0;
            if (QueryPerformanceFrequency(out Freq) == false) throw new Win32Exception();//不支持高精度计时
            if (startTimer) Start();
        }

        #region 成员变量

        /// <summary>
        /// 性能计数
        /// </summary>
        private long Freq;
        /// <summary>
        /// 开始时间
        /// </summary>
        private long FStartTime;
        /// <summary>
        /// 停止时间
        /// </summary>
        private long FStopTime;

        #endregion

        #region 成员方法

        /// <summary>
        /// 查询性能频率
        /// </summary>
        /// <param name="lpFrequency">频率</param>
        /// <returns></returns>
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);
        /// <summary>
        /// 查询性能计数器
        /// </summary>
        /// <param name="lpPerformanceCount">性能计数</param>
        /// <returns></returns>
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
        /// <summary>
        /// 停止计数
        /// </summary>
        public void Stop()
        {
            QueryPerformanceCounter(out FStopTime);
        }
        /// <summary>
        /// 开始计时
        /// </summary>
        public void Start()
        {
            Thread.Sleep(0);
            QueryPerformanceCounter(out FStartTime);
        }

        #endregion

        #region 成员属性

        /// <summary>
        /// 返回运行时间，单位是秒
        /// </summary>
        /// <value>运行时间</value>
        public double Duration
        {
            get { return (double)(FStopTime - FStartTime) / (double)Freq; }
        }

        #endregion

    }
}
