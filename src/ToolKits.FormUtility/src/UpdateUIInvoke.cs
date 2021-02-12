//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：UpdateUIInvoke.cs
// 项目名称：窗体常用操作工具集
// 创建时间：2014年3月7日19时02分
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
using System.Windows.Forms;
using System.Collections.Generic;

namespace DawnXZ.FormUtility
{
    /// <summary>
    /// 线程调用项
    /// </summary>
    internal class InvokeItem
    {
        /// <summary>
        /// 功能
        /// </summary>
        public Delegate Functions { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public object[] Parameters { get; set; }
        /// <summary>
        /// 调用
        /// </summary>
        public void Invoke()
        {
            Functions.DynamicInvoke(Parameters);
        }
    }
    /// <summary>
    /// 线程调用更新界面UI数据
    /// </summary>
    public class UpdateUIInvoke
    {

        #region 委托定义

        /// <summary>
        /// 线程调用更新界面UI数据
        /// </summary>
        public delegate void UpdateUIInvokeEventHandler();
        /// <summary>
        /// 线程调用更新界面UI数据
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="t">泛型对象</param>
        public delegate void UpdateUIInvokeEventHandler<T>(T t);
        /// <summary>
        /// 线程调用更新界面UI数据
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <typeparam name="T1">泛型对象</typeparam>
        /// <param name="t">泛型对象</param>
        /// <param name="t1">泛型对象</param>
        public delegate void UpdateUIInvokeEventHandler<T, T1>(T t, T1 t1);
        /// <summary>
        /// 线程调用更新界面UI数据
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <typeparam name="T1">泛型对象</typeparam>
        /// <typeparam name="T2">泛型对象</typeparam>
        /// <param name="t">泛型对象</param>
        /// <param name="t1">泛型对象</param>
        /// <param name="t2">泛型对象</param>
        public delegate void UpdateUIInvokeEventHandler<T, T1, T2>(T t, T1 t1, T2 t2);
        /// <summary>
        /// 线程调用更新界面UI数据
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <typeparam name="T1">泛型对象</typeparam>
        /// <typeparam name="T2">泛型对象</typeparam>
        /// <typeparam name="T3">泛型对象</typeparam>
        /// <param name="t">泛型对象</param>
        /// <param name="t1">泛型对象</param>
        /// <param name="t2">泛型对象</param>
        /// <param name="t3">泛型对象</param>
        public delegate void UpdateUIInvokeEventHandler<T, T1, T2, T3>(T t, T1 t1, T2 t2, T3 t3);
        /// <summary>
        /// 线程调用更新界面UI数据
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <typeparam name="T1">泛型对象</typeparam>
        /// <typeparam name="T2">泛型对象</typeparam>
        /// <typeparam name="T3">泛型对象</typeparam>
        /// <typeparam name="T4">泛型对象</typeparam>
        /// <param name="t">泛型对象</param>
        /// <param name="t1">泛型对象</param>
        /// <param name="t2">泛型对象</param>
        /// <param name="t3">泛型对象</param>
        /// <param name="t4">泛型对象</param>
        public delegate void UpdateUIInvokeEventHandler<T, T1, T2, T3, T4>(T t, T1 t1, T2 t2, T3 t3, T4 t4);

        #endregion

        #region 成员字段

        /// <summary>
        /// 定时器
        /// </summary>
        private Timer FTimer;
        /// <summary>
        /// 线程调用项队列
        /// </summary>
        private Queue<InvokeItem> FItems;
        /// <summary>
        /// 工作线程调用项队列
        /// </summary>
        private Queue<InvokeItem> FWorkItems;

        #endregion

        #region 成员属性

        /// <summary>
        /// 容器
        /// </summary>
        private Container FContainer { get; set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="form">委托的界面对象</param>
        /// <param name="interval">运行时间阀[毫秒]</param>
        public UpdateUIInvoke(Form form, int interval)
        {
            FItems = new Queue<InvokeItem>(256);
            FWorkItems = new Queue<InvokeItem>(256);
            FContainer = new Container();
            FTimer = new Timer(FContainer);
            FTimer.Tick += FTimer_OnTick;
            form.Disposed += (o, d) =>
            {
                FTimer.Dispose();
                FContainer.Dispose();
            };
            FTimer.Interval = interval;
            FTimer.Enabled = true;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="timer">定时器</param>
        public UpdateUIInvoke(Timer timer)
        {
            FItems = new Queue<InvokeItem>(256);
            FWorkItems = new Queue<InvokeItem>(256);
            FTimer = timer;
            FTimer.Tick += FTimer_OnTick;
            FTimer.Enabled = true;
        }

        #endregion

        #region 定时器回调

        /// <summary>
        /// 定时器回调
        /// </summary>
        /// <param name="sender">执行对象</param>
        /// <param name="e">事件参数对象</param>
        private void FTimer_OnTick(object sender, EventArgs e)
        {
            if (FItems.Count > 0)
            {
                lock (FItems)
                {
                    while (FItems.Count > 0)
                    {
                        FWorkItems.Enqueue(FItems.Dequeue());
                    }
                }
                while (FWorkItems.Count > 0)
                {
                    FWorkItems.Dequeue().Invoke();
                }
            }
        }

        #endregion

        #region 成员方法

        /// <summary>
        /// 添加线程调用项对象
        /// </summary>
        /// <param name="item">线程调用项对象</param>
        private void Add(InvokeItem item)
        {
            lock (FItems)
            {
                FItems.Enqueue(item);
            }
        }

        #region 更新调用

        /// <summary>
        /// 更新调用
        /// </summary>
        /// <param name="eui">线程调用更新界面UI数据委托对象</param>
        public void Invoke(UpdateUIInvokeEventHandler eui)
        {
            InvokeItem item = new InvokeItem();
            item.Functions = eui;
            item.Parameters = new object[0];
            Add(item);
        }
        /// <summary>
        /// 更新调用
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="eui">线程调用更新界面UI数据委托对象</param>
        /// <param name="t">泛型对象</param>
        public void Invoke<T>(UpdateUIInvokeEventHandler<T> eui, T t)
        {
            InvokeItem item = new InvokeItem();
            item.Functions = eui;
            item.Parameters = new object[] { t };
            Add(item);
        }
        /// <summary>
        /// 更新调用
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <typeparam name="T1">泛型对象</typeparam>
        /// <param name="eui">线程调用更新界面UI数据委托对象</param>
        /// <param name="t">泛型对象</param>
        /// <param name="t1">泛型对象</param>
        public void Invoke<T, T1>(UpdateUIInvokeEventHandler<T, T1> eui, T t, T1 t1)
        {
            InvokeItem item = new InvokeItem();
            item.Functions = eui;
            item.Parameters = new object[] { t, t1 };
            Add(item);
        }
        /// <summary>
        /// 更新调用
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <typeparam name="T1">泛型对象</typeparam>
        /// <typeparam name="T2">泛型对象</typeparam>
        /// <param name="eui">线程调用更新界面UI数据委托对象</param>
        /// <param name="t">泛型对象</param>
        /// <param name="t1">泛型对象</param>
        /// <param name="t2">泛型对象</param>
        public void Invoke<T, T1, T2>(UpdateUIInvokeEventHandler<T, T1, T2> eui, T t, T1 t1, T2 t2)
        {
            InvokeItem item = new InvokeItem();
            item.Functions = eui;
            item.Parameters = new object[] { t, t1, t2 };
            Add(item);
        }
        /// <summary>
        /// 更新调用
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <typeparam name="T1">泛型对象</typeparam>
        /// <typeparam name="T2">泛型对象</typeparam>
        /// <typeparam name="T3">泛型对象</typeparam>
        /// <param name="eui">线程调用更新界面UI数据委托对象</param>
        /// <param name="t">泛型对象</param>
        /// <param name="t1">泛型对象</param>
        /// <param name="t2">泛型对象</param>
        /// <param name="t3">泛型对象</param>
        public void Invoke<T, T1, T2, T3>(UpdateUIInvokeEventHandler<T, T1, T2, T3> eui, T t, T1 t1, T2 t2, T3 t3)
        {
            InvokeItem item = new InvokeItem();
            item.Functions = eui;
            item.Parameters = new object[] { t, t1, t2, t3 };
            Add(item);
        }
        /// <summary>
        /// 更新调用
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <typeparam name="T1">泛型对象</typeparam>
        /// <typeparam name="T2">泛型对象</typeparam>
        /// <typeparam name="T3">泛型对象</typeparam>
        /// <typeparam name="T4">泛型对象</typeparam>
        /// <param name="eui">线程调用更新界面UI数据委托对象</param>
        /// <param name="t">泛型对象</param>
        /// <param name="t1">泛型对象</param>
        /// <param name="t2">泛型对象</param>
        /// <param name="t3">泛型对象</param>
        /// <param name="t4">泛型对象</param>
        public void Invoke<T, T1, T2, T3, T4>(UpdateUIInvokeEventHandler<T, T1, T2, T3, T4> eui, T t, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            InvokeItem item = new InvokeItem();
            item.Functions = eui;
            item.Parameters = new object[] { t, t1, t2, t3, t4 };
            Add(item);
        }

        #endregion

        #endregion

    }
}
