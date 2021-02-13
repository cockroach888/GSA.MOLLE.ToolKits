//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：CodeTimer.cs
// 项目名称：物理操作实用工具集
// 创建时间：2014-03-21 17:18:07
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace ToolKits.PHYUtility
{
    /// <summary>
    /// 性能计数器（暂用于控制台应用程序）
    /// <para>打印出花费时间、消耗的CPU时钟周期、以及各代垃圾收集的回收次数</para>
    /// <para>使用方法：CodeTimer.Time("NormalString", 10, () => NormalString());</para>
    /// <para>执行步骤：</para>
    /// <para>1、保留当前控制台前景色，并使用黄色输出名称参数。</para>
    /// <para>2、强制GC进行收集，并记录目前各代已经收集的次数。</para>
    /// <para>3、执行代码，记录下消耗的时间及CPU时钟周期1。</para>
    /// <para>4、恢复控制台默认前景色，并打印出消耗时间及CPU时钟周期。</para>
    /// <para>5、打印执行过程中各代垃圾收集回收次数。</para>
    /// </summary>
    public static class CodeTimer
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialize()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            Time("", 1, () => { });
        }
        /// <summary>
        /// 时间
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="iteration">循环次数</param>
        /// <param name="action">需要执行的方法体</param>
#if (NET20 || NET35)
        public static void Time(string name, int iteration, ToolKits.PHYUtility.Action action)
#else
        public static void Time(string name, int iteration, System.Action action)
#endif
        {
            if (String.IsNullOrEmpty(name)) return;

            // 1.
            ConsoleColor currentForeColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(name);

            // 2.
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            int[] gcCounts = new int[GC.MaxGeneration + 1];
            for (int i = 0; i <= GC.MaxGeneration; i++)
            {
                gcCounts[i] = GC.CollectionCount(i);
            }

            // 3.
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ulong cycleCount = GetCycleCount();
            for (int i = 0; i < iteration; i++) action();
            ulong cpuCycles = GetCycleCount() - cycleCount;
            watch.Stop();

            // 4.
            Console.ForegroundColor = currentForeColor;
            Console.WriteLine("\tTime Elapsed:\t" + watch.ElapsedMilliseconds.ToString("N0") + "ms");
            Console.WriteLine("\tCPU Cycles:\t" + cpuCycles.ToString("N0"));

            // 5.
            for (int i = 0; i <= GC.MaxGeneration; i++)
            {
                int count = GC.CollectionCount(i) - gcCounts[i];
                Console.WriteLine("\tGen " + i + ": \t\t" + count);
            }

            Console.WriteLine();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static ulong GetCycleCount()
        {
            ulong cycleCount = 0;
            QueryThreadCycleTime(GetCurrentThread(), ref cycleCount);
            return cycleCount;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="threadHandle"></param>
        /// <param name="cycleTime"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool QueryThreadCycleTime(IntPtr threadHandle, ref ulong cycleTime);
        /// <summary>
        /// 获得当前线程
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentThread();
    }
}
