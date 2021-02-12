//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：LogHelper.cs
// 项目名称：文件操作实用工具集
// 创建时间：2014年2月20日14时4分
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
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace DawnXZ.FileUtility {
	/// <summary>
	/// 日志操作辅助类
	/// </summary>
	public class LogHelper : IDisposable {

		#region 构造函数

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="dirType">目录类型：1 日志目录名称、2 日志存储路径</param>
		/// <param name="dirNameOrPath">目录名称或路径</param>
		/// <param name="logType">日志生产类型</param>
		private void Initialize(byte dirType, string dirNameOrPath, LogType logType) {
			if (this.FLogMessages == null) {
				switch (dirType) {
					case 0:
						LogPath = Path.Combine(FileHelper.AppPath, "Logs");
						break;
					case 1:
						LogPath = Path.Combine(FileHelper.AppPath, dirNameOrPath);
						break;
					case 2:
						LogPath = dirNameOrPath;
						break;
					default:
						LogPath = Path.Combine(FileHelper.AppPath, "Logs");
						break;
				}
				DirHelper.DirCreate(LogPath);
				FTimeSign = DateTime.Now.AddMinutes(60 - DateTime.Now.Minute);
				FWriterLock = new object();
				FLogMessages = new Queue<LogMessage>();
				FSemaphore = new Semaphore(0, int.MaxValue, "DawnXZ");
				//this.FSemaphore = new Semaphore(0, int.MaxValue, Constants.LogSemaphoreName);
				FState = true;
				FLogType = logType;
				LogTailTag = null;
				FErrorCounted = 0;
				var thread = new Thread(Work) { IsBackground = true };
				thread.Start();
			}
		}
		/// <summary>
		/// 日志文件生产类
		/// </summary>
		/// <param name="logType">日志生产类型</param>
		public LogHelper(LogType logType = LogType.Daily) {
			Initialize(0, null, logType);
		}
		/// <summary>
		/// 日志文件生产类
		/// </summary>
		/// <param name="dirNameOrPath">目录名称或路径</param>
		/// <param name="dirType">目录类型：1 日志目录名称、2 日志存储路径</param>
		/// <param name="logType">日志生产类型</param>
		public LogHelper(string dirNameOrPath, byte dirType = 1, LogType logType = LogType.Daily) {
			Initialize(dirType, dirNameOrPath, logType);
		}

		#endregion

		#region 成员字段

		/// <summary>
		/// 日志活动时间标志
		/// </summary>
		private DateTime FTimeSign;
		/// <summary>
		/// 文件操作锁定对象
		/// </summary>
		private object FWriterLock;
		/// <summary>
		/// 日志消息队列
		/// </summary>
		private Queue<LogMessage> FLogMessages;
		/// <summary> 
		/// 等待排队写日志消息信号量将释放
		/// </summary> 
		private Semaphore FSemaphore;
		/// <summary>
		/// 日志写入文件状态
		/// </summary>
		private bool FState;
		/// <summary>
		/// 错误发生次数
		/// </summary>
		private int FErrorCounted;

		#endregion

		#region 成员属性

		/// <summary>
		/// 日志存储路径
		/// </summary>
		public string LogPath { get; private set; }
		/// <summary>
		/// 文件写入操作流
		/// </summary>
		internal StreamWriter Writers { get; private set; }
		/// <summary> 
		/// 日志保存类型
		/// </summary> 
		public LogType FLogType { get; private set; }
		/// <summary>
		/// 日志文件尾部标记
		/// </summary>
		public string LogTailTag { get; set; }

		#endregion

		#region 成员方法

		#region 消息队列处理器

		/// <summary> 
		/// 写入日志文件的工作方法
		/// <para>确定日志队列有需要写的记录</para>
		/// </summary> 
		private void Work() {
			while (true) {
				if (this.FLogMessages.Count > 0) {
					WriteMessage();
				}
				else {
					if (WaitLogMessage()) break;
				}
			}
		}
		/// <summary> 
		/// 将消息写入到日志文件
		/// </summary> 
		private void WriteMessage() {
			LogMessage logMsg = null;
			lock (this.FWriterLock) {
				if (this.FLogMessages.Count > 0) logMsg = this.FLogMessages.Dequeue();
			}
			if (logMsg != null) {
				FileWrite(logMsg);
			}
		}
		/// <summary> 
		/// 线程等待一条日志消息
		/// <para>确定日志生活时间是 true 或 false</para>
		/// </summary> 
		/// <returns>是不是关闭的</returns> 
		private bool WaitLogMessage() {
			if (this.FState) {
				//WaitHandle.WaitAny(new WaitHandle[] { this.FSemaphore }, -1, false);
				WaitHandle.WaitAny(new WaitHandle[] { this.FSemaphore }, 1, false);
				return false;
			}
			FileClose();
			return true;
		}

		#endregion

		#region 私有方法

		/// <summary> 
		/// 获取文件的名称由日志生产类型
		/// </summary> 
		/// <returns>日志文件的名称</returns> 
		private string GetFilename() {
			string tmpFileName = "";
			switch (FLogType) {
				case LogType.Hour:
					tmpFileName = FileHelper.GetNameByHour(false);
					break;
				case LogType.Daily:
					tmpFileName = FileHelper.GetNameByDate(true);
					break;
				case LogType.Monthly:
					tmpFileName = FileHelper.GetNameByMonth(true);
					break;
				case LogType.Annually:
					tmpFileName = FileHelper.GetNameByYear();
					break;
			}
			if (!string.IsNullOrEmpty(LogTailTag)) {
				tmpFileName += LogTailTag;
			}
			return string.Format("{0}.log", tmpFileName);
		}
		/// <summary> 
		/// 写入日志文件消息
		/// <para>确定日志文件的时间标志</para>
		/// </summary> 
		/// <param name="msg">日志消息属性</param> 
		private void FileWrite(LogMessage msg) {
			if (this.FErrorCounted > 3) return;
			try {
				if (null == Writers) FileOpen();
				if (DateTime.Now >= this.FTimeSign) {
					FileClose();
					FileOpen();
					this.FTimeSign = DateTime.Now.AddHours(1);
				}
				Writers.WriteLine(string.Format(@"{0} [{1}]  {2}", msg.MsgDatetime.ToString("yyyy-MM-dd HH:mm:ss.fff"), msg.MsgType, msg.MsgText));
				Writers.Flush();
				System.Threading.Thread.Sleep(10);
			}
			catch {
				this.FErrorCounted++;
				//Console.Out.Write(e);
			}
		}
		/// <summary> 
		/// 打开日志文件写入日志消息
		/// </summary> 
		private void FileOpen() {
			var __dirPath = Path.Combine(LogPath, FileHelper.GetNameByDate(false));
			DirHelper.DirCreate(__dirPath);
			var __filePath = Path.Combine(__dirPath, GetFilename());
			Writers = new StreamWriter(__filePath, true, Encoding.UTF8);
		}
		/// <summary> 
		/// 关闭日志文件
		/// </summary> 
		private void FileClose() {
			if (Writers != null) {
				Writers.Flush();
				Writers.Close();
				Writers.Dispose();
				Writers = null;
			}
		}

		#endregion

		#region 公共方法

		/// <summary> 
		/// 新的日志消息进行排队和释放一个信号量
		/// </summary> 
		/// <param name="msg">日志消息属性</param> 
		public void Write(LogMessage msg) {
			if (msg != null) {
				lock (this.FWriterLock) {
					this.FLogMessages.Enqueue(msg);
					this.FSemaphore.Release();
				}
			}
		}
		/// <summary> 
		/// 写入消息的消息内容和类型
		/// </summary> 
		/// <param name="text">消息内容</param> 
		public void Write(string text) {
			Write(new LogMessage(text, MessageType.Information));
		}
		/// <summary> 
		/// 写入消息的消息内容和类型
		/// </summary> 
		/// <param name="text">消息内容</param> 
		/// <param name="type">消息类型</param> 
		public void Write(string text, MessageType type) {
			Write(new LogMessage(text, type));
		}
		/// <summary> 
		/// 写日志按日期时间和日志的内容和类型
		/// </summary> 
		/// <param name="dateTime">消息的日期时间</param> 
		/// <param name="text">消息内容</param> 
		/// <param name="type">消息类型</param> 
		public void Write(DateTime dateTime, string text, MessageType type) {
			Write(new LogMessage(dateTime, text, type));
		}
		/// <summary> 
		/// 写入消息尝试异常和消息类型
		/// </summary> 
		/// <param name="ex">异常信息</param> 
		public void Write(Exception ex) {
			Write(new LogMessage(ex.GetType().Name, MessageType.Error));
			Write(new LogMessage(ex.Message, MessageType.Error));
			Write(new LogMessage(ex.StackTrace, MessageType.Error));
			Write(new LogMessage(ex.Source, MessageType.Error));
		}
		/// <summary> 
		/// 写入消息尝试异常和消息类型
		/// </summary> 
		/// <param name="ex">异常信息</param> 
		/// <param name="type">消息类型</param> 
		public void Write(Exception ex, MessageType type) {
			Write(new LogMessage(ex.GetType().Name, type));
			Write(new LogMessage(ex.Message, type));
			Write(new LogMessage(ex.StackTrace, type));
			Write(new LogMessage(ex.Source, type));
		}
		/// <summary>
		/// 写入消息尝试Socket异常和消息类型
		/// </summary>
		/// <param name="ex">套接字错误消息</param>
		public void Write(SocketException ex) {
			Write(string.Format("{0}[{1}]", ex.SocketErrorCode, ex.ErrorCode), MessageType.Error);
			Write(ex.GetType().Name, MessageType.Error);
			Write(ex.Message, MessageType.Error);
			Write(ex.StackTrace, MessageType.Error);
			Write(ex.Source, MessageType.Error);
		}
		/// <summary>
		/// 写入消息尝试Socket异常和消息类型
		/// </summary>
		/// <param name="ex">套接字错误消息</param>
		/// <param name="msgType">消息类型</param>
		public void Write(SocketException ex, MessageType msgType) {
			Write(string.Format("{0}[{1}]", ex.SocketErrorCode, ex.ErrorCode), msgType);
			Write(ex.GetType().Name, msgType);
			Write(ex.Message, msgType);
			Write(ex.StackTrace, msgType);
			Write(ex.Source, msgType);
		}

		#endregion

		#region IDisposable member

		/// <summary> 
		/// 处理日志
		/// </summary> 
		public void Dispose() {
			if (Writers != null) FileClose();
			Writers = null;
			this.FState = false;
		}

		#endregion

		#endregion

	}
}
