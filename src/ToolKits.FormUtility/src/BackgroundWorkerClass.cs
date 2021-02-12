//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：BackgroundWorkerClass.cs
// 项目名称：窗体常用操作工具集
// 创建时间：2014年3月7日19时12分
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;

namespace DawnXZ.FormUtility
{
    /// <summary>
    /// 单线程后台执行
    /// <remarks>
    /// <para>private BackgroundWorker _backgroundWorker;// 申明后台对象</para>
    /// <para></para>
    /// <para>_backgroundWorker = new BackgroundWorker(); // 实例化后台对象</para>
    /// <para>_backgroundWorker.WorkerReportsProgress = true; // 设置可以通告进度</para>
    /// <para>_backgroundWorker.WorkerSupportsCancellation = true; // 设置可以取消</para>
    /// <para>_backgroundWorker.DoWork += new DoWorkEventHandler(DoWork);</para>
    /// <para>_backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(UpdateProgress);</para>
    /// <para>_backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompletedWork);</para>
    /// <para>_backgroundWorker.RunWorkerAsync(this);</para>
    /// <para></para>
    /// <para>private void DoWork(object sender, DoWorkEventArgs e)</para>
    /// <para>{</para>
    /// <para>　　BackgroundWorker bw = sender as BackgroundWorker;</para>
    /// <para>　　MainWindow win = e.Argument as MainWindow;</para>
    /// <para>　　int i = 0;</para>
    /// <para>　　while (i 小于等于 100)</para>
    /// <para>　　{</para>
    /// <para>　　　　if (bw.CancellationPending)</para>
    /// <para>　　　　{</para>
    /// <para>　　　　　　e.Cancel = true;</para>
    /// <para>　　　　　　break;</para>
    /// <para>　　　　}</para>
    /// <para>　　　　bw.ReportProgress(i++);</para>
    /// <para>　　　　Thread.Sleep(1000);</para>
    /// <para>　　}</para>
    /// <para>}</para>
    /// <para></para>
    /// <para>private void UpdateProgress(object sender, ProgressChangedEventArgs e)</para>
    /// <para>{</para>
    /// <para>　　int progress = e.ProgressPercentage;</para>
    /// <para>　　label1.Content = string.Format("{0}", progress);</para>
    /// <para>}</para>
    /// <para></para>
    /// <para>private void CompletedWork(object sender, RunWorkerCompletedEventArgs e)</para>
    /// <para>{</para>
    /// <para>　　if (e.Error != null)</para>
    /// <para>　　{</para>
    /// <para>　　　　MessageBox.Show("Error");</para>
    /// <para>　　}</para>
    /// <para>　　else if (e.Cancelled)</para>
    /// <para>　　{</para>
    /// <para>　　　　MessageBox.Show("Canceled");</para>
    /// <para>　　}</para>
    /// <para>　　else</para>
    /// <para>　　{</para>
    /// <para>　　　　MessageBox.Show("Completed");</para>
    /// <para>　　}</para>
    /// <para>}</para>
    /// <para></para>
    /// <para>private void button1_Click(object sender, RoutedEventArgs e)</para>
    /// <para>{</para>
    /// <para>　　_backgroundWorker.CancelAsync();</para>
    /// <para>}</para>
    /// </remarks>
    /// </summary>
    public class BackgroundWorkerClass
    { }

    //public partial class MainWindow : Window
    //{

    //    private BackgroundWorker _backgroundWorker;// 申明后台对象

    //    public MainWindow()
    //    {
    //        InitializeComponent();

    //        _backgroundWorker = new BackgroundWorker(); // 实例化后台对象

    //        _backgroundWorker.WorkerReportsProgress = true; // 设置可以通告进度
    //        _backgroundWorker.WorkerSupportsCancellation = true; // 设置可以取消

    //        _backgroundWorker.DoWork += new DoWorkEventHandler(DoWork);
    //        _backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(UpdateProgress);
    //        _backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompletedWork);

    //        _backgroundWorker.RunWorkerAsync(this);
    //    }


    //    void DoWork(object sender, DoWorkEventArgs e)
    //    {
    //        BackgroundWorker bw = sender as BackgroundWorker;
    //        MainWindow win = e.Argument as MainWindow;

    //        int i = 0;
    //        while (i <= 100)
    //        {
    //            if (bw.CancellationPending)
    //            {
    //                e.Cancel = true;
    //                break;
    //            }

    //            bw.ReportProgress(i++);

    //            Thread.Sleep(1000);

    //        }
    //    }

    //    void UpdateProgress(object sender, ProgressChangedEventArgs e)
    //    {
    //        int progress = e.ProgressPercentage;

    //        label1.Content = string.Format("{0}", progress);
    //    }


    //    void CompletedWork(object sender, RunWorkerCompletedEventArgs e)
    //    {
    //        if (e.Error != null)
    //        {
    //            MessageBox.Show("Error");
    //        }
    //        else if (e.Cancelled)
    //        {
    //            MessageBox.Show("Canceled");
    //        }
    //        else
    //        {
    //            MessageBox.Show("Completed");
    //        }
    //    }


    //    private void button1_Click(object sender, RoutedEventArgs e)
    //    {
    //        _backgroundWorker.CancelAsync();
    //    }
    //}

}
