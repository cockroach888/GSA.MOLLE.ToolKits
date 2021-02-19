//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：QueueThreadBase.cs
// 项目名称：窗体常用操作工具集
// 创建时间：2014-03-20 12:11:28
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
using System.Threading;

namespace GSA.ToolKits.FormUtility
{
    /// <summary>
    /// 下载线程队列举例
    /// </summary>
    public class DownLoadQueueThread : QueueThreadBase<int>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="list">下载的列表ID</param>
        public DownLoadQueueThread(IEnumerable<int> list)
            : base(list)
        { }
        /// <summary>
        /// 每次多线程都到这里来,处理多线程
        /// </summary>
        /// <param name="pendingID">列表ID></param>
        /// <returns></returns>
        protected override DoWorkResult DoWork(int pendingID)
        {
            try
            {
                //..........多线程处理....
                return DoWorkResult.ContinueThread;//没有异常让线程继续跑..

            }
            catch (Exception)
            {
                return DoWorkResult.AbortCurrentThread;//有异常,可以终止当前线程.当然.也可以继续,
                //return  DoWorkResult.AbortAllThread; //特殊情况下 ,有异常终止所有的线程...
            }
            //return base.DoWork(pendingValue);
        }
    }
    /// <summary>
    /// 队列多线程,T 代表处理的单个类型~
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class QueueThreadBase<T>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="collection">枚举集合</param>
        public QueueThreadBase(IEnumerable<T> collection)
        {
            FInnerQueue = new Queue<T>(collection);
            this.FQueueCount = FInnerQueue.Count;
        }

        #region 变量&属性

        /// <summary>
        /// 待处理结果
        /// </summary>
        private class PendingResult
        {
            /// <summary>
            /// 待处理值
            /// </summary>
            public T PendingValue { get; set; }
            /// <summary>
            /// 是否有值
            /// </summary>
            public bool IsHad { get; set; }
        }
        /// <summary>
        /// 线程数
        /// </summary>
        public int ThreadCount
        {
            get { return this.FThreadCount; }
            set { this.FThreadCount = value; }
        }
        /// <summary>
        /// 线程数量
        /// </summary>
        private int FThreadCount = 5;
        /// <summary>
        /// 取消=True
        /// </summary>
        public bool Cancel { get; set; }
        /// <summary>
        /// 线程列表
        /// </summary>
        List<Thread> FThreadList;
        /// <summary>
        /// 完成队列个数
        /// </summary>
        private volatile int FCompletedCount = 0;
        /// <summary>
        /// 队列总数
        /// </summary>
        private int FQueueCount = 0;
        /// <summary>
        /// 全部完成锁
        /// </summary>
        private object FAllCompletedLock = new object();
        /// <summary>
        /// 完成的线程数
        /// </summary>
        private int FCompetedCount = 0;
        /// <summary>
        /// 队列锁
        /// </summary>
        private object FPendingQueueLock = new object();
        /// <summary>
        /// 队列
        /// </summary>
        private Queue<T> FInnerQueue;

        #endregion

        #region 事件相关

        /// <summary>
        /// 全部完成事件
        /// </summary>
        public event Action<CompetedEventArgs> AllCompleted;
        /// <summary>
        /// 单个完成事件
        /// </summary>
        public event Action<T, CompetedEventArgs> OneCompleted;
        /// <summary>
        /// 引发全部完成事件
        /// </summary>
        /// <param name="args"></param>
        private void OnAllCompleted(CompetedEventArgs args)
        {
            if (AllCompleted != null)
            {
                try
                {
                    AllCompleted(args);//全部完成事件
                }
                catch { }
            }
        }
        /// <summary>
        /// 引发单个完成事件
        /// </summary>
        /// <param name="pendingValue"></param>
        /// <param name="args"></param>
        private void OnOneCompleted(T pendingValue, CompetedEventArgs args)
        {
            if (OneCompleted != null)
            {
                try
                {
                    OneCompleted(pendingValue, args);
                }
                catch { }
            }
        }

        #endregion

        #region 主体

        /// <summary>
        /// 初始化线程
        /// </summary>
        private void InitThread()
        {
            FThreadList = new List<Thread>();
            for (int i = 0; i < ThreadCount; i++)
            {
                Thread t = new Thread(new ThreadStart(InnerDoWork));
                FThreadList.Add(t);
                t.IsBackground = true;
                t.Start();
            }
        }
        /// <summary>
        /// 开始
        /// </summary>
        public void Start()
        {
            InitThread();
        }
        /// <summary>
        /// 线程工作
        /// </summary>
        private void InnerDoWork()
        {
            try
            {
                Exception doWorkEx = null;
                DoWorkResult doworkResult = DoWorkResult.ContinueThread;
                var t = CurrentPendingQueue;
                while (!this.Cancel && t.IsHad)
                {
                    try
                    {
                        doworkResult = DoWork(t.PendingValue);
                    }
                    catch (Exception ex)
                    {
                        doWorkEx = ex;
                    }
                    FCompletedCount++;
                    int precent = FCompletedCount * 100 / FQueueCount;
                    OnOneCompleted(t.PendingValue, new CompetedEventArgs() { CompetedPrecent = precent, InnerException = doWorkEx });
                    if (doworkResult == DoWorkResult.AbortAllThread)
                    {
                        this.Cancel = true;
                        break;
                    }
                    else if (doworkResult == DoWorkResult.AbortCurrentThread)
                    {
                        break;
                    }
                    t = CurrentPendingQueue;
                }
                lock (FAllCompletedLock)
                {
                    FCompetedCount++;
                    if (FCompetedCount == FThreadList.Count)
                    {
                        OnAllCompleted(new CompetedEventArgs() { CompetedPrecent = 100 });
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 子类重写
        /// </summary>
        /// <param name="pendingValue"></param>
        /// <returns></returns>
        protected virtual DoWorkResult DoWork(T pendingValue)
        {
            return DoWorkResult.ContinueThread;
        }
        /// <summary>
        /// 获取当前结果
        /// </summary>
        private PendingResult CurrentPendingQueue
        {
            get
            {
                lock (FPendingQueueLock)
                {
                    PendingResult t = new PendingResult();
                    if (FInnerQueue.Count != 0)
                    {
                        t.PendingValue = FInnerQueue.Dequeue();
                        t.IsHad = true;
                    }
                    else
                    {
                        t.PendingValue = default(T);
                        t.IsHad = false;
                    }
                    return t;
                }
            }
        }

        #endregion

        #region 相关类&枚举

        /// <summary>
        /// dowork结果枚举
        /// </summary>
        public enum DoWorkResult
        {
            /// <summary>
            /// 继续运行，默认
            /// </summary>
            ContinueThread = 0,
            /// <summary>
            /// 终止当前线程
            /// </summary>
            AbortCurrentThread = 1,
            /// <summary>
            /// 终止全部线程
            /// </summary>
            AbortAllThread = 2
        }
        /// <summary>
        /// 完成事件数据
        /// </summary>
        public class CompetedEventArgs : EventArgs
        {
            /// <summary>
            /// 构造函数
            /// </summary>
            public CompetedEventArgs()
            { }
            /// <summary>
            /// 完成百分率
            /// </summary>
            public int CompetedPrecent { get; set; }
            /// <summary>
            /// 异常信息
            /// </summary>
            public Exception InnerException { get; set; }
        }

        #endregion

    }
}
