//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：DirectoryHelper.cs
// 项目名称：文件操作实用工具集
// 创建时间：2015-05-25 09:35:07
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;

namespace DawnXZ.FileUtility {
	/// <summary>
	/// 文件或目录遍历处理器
	/// <para>对 FileDirectoryEnumerator 类进行封装</para>
	/// <para>使用示例：</para>
	/// <para>FileDirectoryEnumerable fde1 = new FileDirectoryEnumerable();</para>
	/// <para>fde1.SearchPath = @"c:\windows\";</para>
	/// <para>fde1.ReturnStringType = false;</para>
	/// <para>fde1.SearchPattern = "*.*";</para>
	/// <para>foreach (object name in fde1) {</para>
	/// <para>　　var file = item as FileInfo;</para>
	/// <para>　　Console.WriteLine(name);</para>
	/// <para>}</para>
	/// <para>Console.ReadLine();</para>
	/// </summary>
	public class FileDirectoryEnumerable : IEnumerable {

		#region 成员变量

		/// <summary>
		/// 文件或目录遍历结果集合存储器
		/// </summary>
		private ArrayList FEnumerableList = new ArrayList();

		#endregion

		#region 成员属性

		/// <summary>
		/// 是否以字符串方式返回查询结果
		/// <para>若返回true则当前对象返回为字符串</para>
		/// <para>否则返回 FileInfo 或 DirectoryInfo 类型</para>
		/// </summary>
		private bool bolReturnStringType = true;
		/// <summary>
		/// 是否以字符串方式返回查询结果
		/// <para>若返回true则当前对象返回为字符串</para>
		/// <para>否则返回 FileInfo 或 DirectoryInfo 类型</para>
		/// </summary>
		public bool ReturnStringType {
			get { return bolReturnStringType; }
			set { bolReturnStringType = value; }
		}
		/// <summary>
		/// 文件或目录名的通配符
		/// </summary>
		private string strSearchPattern = "*";
		/// <summary>
		/// 文件或目录名的通配符
		/// </summary>
		public string SearchPattern {
			get { return strSearchPattern; }
			set { strSearchPattern = value; }
		}
		/// <summary>
		/// 搜索路径
		/// <para>必须为绝对路径</para>
		/// </summary>
		private string strSearchPath = null;
		/// <summary>
		/// 搜索路径
		/// <para>必须为绝对路径</para>
		/// </summary>
		public string SearchPath {
			get { return strSearchPath; }
			set { strSearchPath = value; }
		}
		/// <summary>
		/// 是否查找文件
		/// </summary>
		private bool bolSearchForFile = true;
		/// <summary>
		/// 是否查找文件
		/// </summary>
		public bool SearchForFile {
			get { return bolSearchForFile; }
			set { bolSearchForFile = value; }
		}
		/// <summary>
		/// 是否查找子目录
		/// <para>显示时是否包含子目录名称</para>
		/// </summary>
		private bool bolSearchForDirectory = false;
		/// <summary>
		/// 是否查找子目录
		/// <para>显示时是否包含子目录名称</para>
		/// </summary>
		public bool SearchForDirectory {
			get { return bolSearchForDirectory; }
			set { bolSearchForDirectory = value; }
		}
		/// <summary>
		/// 发生IO错误时是否抛出异常
		/// </summary>
		private bool bolThrowIOException = true;
		/// <summary>
		/// 发生IO错误时是否抛出异常
		/// </summary>
		public bool ThrowIOException {
			get { return this.bolThrowIOException; }
			set { this.bolThrowIOException = value; }
		}

		#endregion

		#region 成员方法

		/// <summary>
		/// 返回内置的文件和目录遍历器
		/// </summary>
		/// <returns>遍历器对象</returns>
		public IEnumerator GetEnumerator() {
			FileDirectoryEnumerator fde = new FileDirectoryEnumerator();
			fde.ReturnStringType = this.bolReturnStringType;
			fde.SearchForDirectory = this.bolSearchForDirectory;
			fde.SearchForFile = this.bolSearchForFile;
			fde.SearchPath = this.strSearchPath;
			fde.SearchPattern = this.strSearchPattern;
			fde.ThrowIOException = this.bolThrowIOException;
			FEnumerableList.Add(fde);
			return fde;
		}
		/// <summary>
		/// 关闭对象
		/// </summary>
		public void Close() {
			foreach (FileDirectoryEnumerator e in FEnumerableList) {
				e.Close();
			}
			FEnumerableList.Clear();
		}

		#endregion

	}
	/// <summary>
	/// 文件和目录的遍历器
	/// <para>对 Win32API 函数的 FindFirstFile、FindNextFile、FindClose 进行封装</para>
	/// <para>使用示例：</para>
	/// <para>FileDirectoryEnumerator fde2 = new FileDirectoryEnumerator();</para>
	/// <para>fde2.SearchPath = @"c:\windows\";</para>
	/// <para>fde2.ReturnStringType = true;</para>
	/// <para>fde2.SearchPattern = "*.*";</para>
	/// <para>fde2.Reset();</para>
	/// <para>fde2.ReturnStringType = true;</para>
	/// <para>while (fde2.MoveNext()) {</para>
	/// <para>　　Console.WriteLine(string.Format("{0}   {1}  \t{2}", fde2.LastAccessTime.ToString("yyyy-MM-dd HH:mm:ss"), fde2.FileLength, fde2.Name));</para>
	/// <para>}</para>
	/// <para>Console.WriteLine(string.Format("总文件个数：{0}", fde2.SearchedCount));</para>
	/// <para>fde2.Close();</para>
	/// <para>Console.ReadLine();</para>
	/// </summary>
	public class FileDirectoryEnumerator : IEnumerator {

		#region 表示对象当前状态的数据和属性

		/// <summary>
		/// 当前对象
		/// </summary>
		private object objCurrentObject = null;
		/// <summary>
		/// 目录是否为空
		/// </summary>
		private bool bolIsEmpty = false;
		/// <summary>
		/// 目录是否为空
		/// </summary>
		public bool IsEmpty {
			get { return bolIsEmpty; }
		}
		/// <summary>
		/// 已找到的对象的个数
		/// </summary>
		private int intSearchedCount = 0;
		/// <summary>
		/// 已找到的对象的个数
		/// </summary>
		public int SearchedCount {
			get { return intSearchedCount; }
		}
		/// <summary>
		/// 当前对象是否为文件
		/// <para>若为true则当前对象为文件，否则为目录</para>
		/// </summary>
		private bool bolIsFile = true;
		/// <summary>
		/// 当前对象是否为文件
		/// <para>若为true则当前对象为文件，否则为目录</para>
		/// </summary>
		public bool IsFile {
			get { return bolIsFile; }
		}
		/// <summary>
		/// 最后一次操作的Win32错误代码
		/// </summary>
		private int intLastErrorCode = 0;
		/// <summary>
		/// 最后一次操作的Win32错误代码
		/// </summary>
		public int LastErrorCode {
			get { return intLastErrorCode; }
		}
		/// <summary>
		/// 当前对象的名称
		/// </summary>
		public string Name {
			get {
				if (this.objCurrentObject != null) {
					if (objCurrentObject is string)
						return (string)this.objCurrentObject;
					else
						return ((FileSystemInfo)this.objCurrentObject).Name;
				}
				return null;
			}
		}
		/// <summary>
		/// 当前对象属性
		/// </summary>
		public FileAttributes Attributes {
			get { return (FileAttributes)FFindData.dwFileAttributes; }
		}
		/// <summary>
		/// 当前对象创建时间
		/// </summary>
		public DateTime CreationTime {
			get {
				long time = ToLong(FFindData.ftCreationTime_dwHighDateTime, FFindData.ftCreationTime_dwLowDateTime);
				DateTime dtm = DateTime.FromFileTimeUtc(time);
				return dtm.ToLocalTime();
			}
		}
		/// <summary>
		/// 当前对象最后访问时间
		/// </summary>
		public DateTime LastAccessTime {
			get {
				long time = ToLong(FFindData.ftLastAccessTime_dwHighDateTime, FFindData.ftLastAccessTime_dwLowDateTime);
				DateTime dtm = DateTime.FromFileTimeUtc(time);
				return dtm.ToLocalTime();
			}
		}
		/// <summary>
		/// 当前对象最后保存时间
		/// </summary>
		public DateTime LastWriteTime {
			get {
				long time = ToLong(FFindData.ftLastWriteTime_dwHighDateTime, FFindData.ftLastWriteTime_dwLowDateTime);
				DateTime dtm = DateTime.FromFileTimeUtc(time);
				return dtm.ToLocalTime();
			}
		}
		/// <summary>
		/// 当前文件长度,若为当前对象为文件则返回文件长度,若当前对象为目录则返回0
		/// </summary>
		public long FileLength {
			get {
				if (this.bolIsFile)
					return ToLong(FFindData.nFileSizeHigh, FFindData.nFileSizeLow);
				else
					return 0;
			}
		}

		#endregion

		#region 控制对象特性的一些属性

		/// <summary>
		/// 发生IO错误时是否抛出异常
		/// </summary>
		private bool bolThrowIOException = true;
		/// <summary>
		/// 发生IO错误时是否抛出异常
		/// </summary>
		public bool ThrowIOException {
			get { return this.bolThrowIOException; }
			set { this.bolThrowIOException = value; }
		}
		/// <summary>
		/// 是否以字符串方式返回查询结果,若返回true则当前对象返回为字符串,
		/// 否则返回 FileInfo或DirectoryInfo类型
		/// </summary>
		private bool bolReturnStringType = true;
		/// <summary>
		/// 是否以字符串方式返回查询结果,若返回true则当前对象返回为字符串,
		/// 否则返回 FileInfo或DirectoryInfo类型
		/// </summary>
		public bool ReturnStringType {
			get { return bolReturnStringType; }
			set { bolReturnStringType = value; }
		}
		/// <summary>
		/// 要匹配的文件或目录名,支持通配符
		/// </summary>
		private string strSearchPattern = "*";
		/// <summary>
		/// 要匹配的文件或目录名,支持通配符
		/// </summary>
		public string SearchPattern {
			get { return strSearchPattern; }
			set { strSearchPattern = value; }
		}
		/// <summary>
		/// 搜索的父目录,必须为绝对路径,不得有通配符,该目录必须存在
		/// </summary>
		private string strSearchPath = null;
		/// <summary>
		/// 搜索的父目录,必须为绝对路径,不得有通配符,该目录必须存在
		/// </summary>
		public string SearchPath {
			get { return strSearchPath; }
			set { strSearchPath = value; }
		}
		/// <summary>
		/// 是否查找文件
		/// </summary>
		private bool bolSearchForFile = true;
		/// <summary>
		/// 是否查找文件
		/// </summary>
		public bool SearchForFile {
			get { return bolSearchForFile; }
			set { bolSearchForFile = value; }
		}
		/// <summary>
		/// 是否查找子目录
		/// <para>显示时是否包含子目录名称</para>
		/// </summary>
		private bool bolSearchForDirectory = false;
		/// <summary>
		/// 是否查找子目录
		/// <para>显示时是否包含子目录名称</para>
		/// </summary>
		public bool SearchForDirectory {
			get { return bolSearchForDirectory; }
			set { bolSearchForDirectory = value; }
		}

		#endregion

		/// <summary>
		/// 关闭对象,停止搜索
		/// </summary>
		public void Close() {
			this.CloseHandler();
		}

		#region IEnumerator 成员

		/// <summary>
		/// 返回当前对象
		/// </summary>
		public object Current {
			get { return objCurrentObject; }
		}
		/// <summary>
		/// 找到下一个文件或目录
		/// </summary>
		/// <returns>操作是否成功</returns>
		public bool MoveNext() {
			bool success = false;
			while (true) {
				if (this.bolStartSearchFlag) {
					success = this.SearchNext();
				}
				else {
					success = this.StartSearch();
				}
				if (success) {
					if (this.UpdateCurrentObject()) return true;
				}
				else {
					this.objCurrentObject = null;
					return false;
				}
			}
		}
		/// <summary>
		/// 重新设置对象
		/// </summary>
		public void Reset() {
			if (this.strSearchPath == null) throw new ArgumentNullException("搜索路径不能为空。");
			if (this.strSearchPattern == null || this.strSearchPattern.Length == 0) this.strSearchPattern = "*";
			this.intSearchedCount = 0;
			this.objCurrentObject = null;
			this.CloseHandler();
			this.bolStartSearchFlag = false;
			this.bolIsEmpty = false;
			this.intLastErrorCode = 0;
		}

		#endregion

		#region 声明WIN32API函数以及结构

		/// <summary>
		/// WIN32数据查找结构体
		/// </summary>
		[Serializable, StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto), BestFitMapping(false)]
		private struct WIN32_FIND_DATA {
			/// <summary>
			/// 文件属性
			/// </summary>
			public int dwFileAttributes;
			/// <summary>
			/// 创建文件的时间
			/// <para>最低时间</para>
			/// </summary>
			public int ftCreationTime_dwLowDateTime;
			/// <summary>
			/// 创建文件的时间
			/// <para>最高时间</para>
			/// </summary>
			public int ftCreationTime_dwHighDateTime;
			/// <summary>
			/// 最后一次访问文件的时间
			/// <para>最低时间</para>
			/// </summary>
			public int ftLastAccessTime_dwLowDateTime;
			/// <summary>
			/// 最后一次访问文件的时间
			/// <para>最高时间</para>
			/// </summary>
			public int ftLastAccessTime_dwHighDateTime;
			/// <summary>
			/// 最后修改时间
			/// <para>最低时间</para>
			/// </summary>
			public int ftLastWriteTime_dwLowDateTime;
			/// <summary>
			/// 最后修改时间
			/// <para>最高时间</para>
			/// </summary>
			public int ftLastWriteTime_dwHighDateTime;
			/// <summary>
			/// 文件大小
			/// <para>最大值</para>
			/// </summary>
			public int nFileSizeHigh;
			/// <summary>
			/// 文件大小
			/// <para>最小值</para>
			/// </summary>
			public int nFileSizeLow;
			/// <summary>
			/// 保留的值
			/// <para>变量1</para>
			/// </summary>
			public int dwReserved0;
			/// <summary>
			/// 保留的值
			/// <para>变量2</para>
			/// </summary>
			public int dwReserved1;
			/// <summary>
			/// 文件名称
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string cFileName;
			/// <summary>
			/// 文件交替名称
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
			public string cAlternateFileName;
		}
		/// <summary>
		/// 查找第一个文件
		/// </summary>
		/// <param name="pFileName">文件名称</param>
		/// <param name="pFindFileData">文件查找数据信息</param>
		/// <returns>查找结果</returns>
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr FindFirstFile(string pFileName, ref WIN32_FIND_DATA pFindFileData);
		/// <summary>
		/// 查找下一个文件
		/// </summary>
		/// <param name="hndFindFile">文件查找句柄</param>
		/// <param name="lpFindFileData">文件查找数据信息</param>
		/// <returns>查找结果</returns>
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool FindNextFile(IntPtr hndFindFile, ref WIN32_FIND_DATA lpFindFileData);
		/// <summary>
		/// 关闭遍历操作
		/// </summary>
		/// <param name="hndFindFile">文件查找句柄</param>
		/// <returns>操作结果</returns>
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool FindClose(IntPtr hndFindFile);
		/// <summary>
		/// 长整型转换器
		/// </summary>
		/// <param name="height">最高数</param>
		/// <param name="low">最低数</param>
		/// <returns>转换结果</returns>
		private static long ToLong(int height, int low) {
			long v = (uint)height;
			v = v << 0x20;
			v = v | ((uint)low);
			return v;
		}
		/// <summary>
		/// IO错误异常信息
		/// </summary>
		/// <param name="errorCode">错误代码</param>
		/// <param name="str">错误信息</param>
		private static void WinIOError(int errorCode, string str) {
			switch (errorCode) {
				case 80:
					throw new IOException("IO_FileExists :" + str);
				case 0x57:
					throw new IOException("IOError:" + MakeHRFromErrorCode(errorCode));
				case 0xce:
					throw new PathTooLongException("PathTooLong:" + str);
				case 2:
					throw new FileNotFoundException("FileNotFound:" + str);
				case 3:
					throw new DirectoryNotFoundException("PathNotFound:" + str);
				case 5:
					throw new UnauthorizedAccessException("UnauthorizedAccess:" + str);
				case 0x20:
					throw new IOException("IO_SharingViolation:" + str);
			}
			throw new IOException("IOError:" + MakeHRFromErrorCode(errorCode));
		}
		/// <summary>
		/// 错误代码
		/// </summary>
		/// <param name="errorCode">错误代码</param>
		/// <returns>错误代码</returns>
		private static int MakeHRFromErrorCode(int errorCode) {
			return (-2147024896 | errorCode);
		}

		#endregion

		#region WIN32API函数相关操作处理

		/// <summary>
		/// 无效的句柄值
		/// </summary>
		private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
		/// <summary>
		/// 查找处理的底层句柄
		/// </summary>
		private System.IntPtr intSearchHandler = INVALID_HANDLE_VALUE;
		/// <summary>
		/// WIN32数据查找结构体
		/// </summary>
		private WIN32_FIND_DATA FFindData = new WIN32_FIND_DATA();
		/// <summary>
		/// 开始搜索标志
		/// </summary>
		private bool bolStartSearchFlag = false;
		/// <summary>
		/// 关闭内部句柄
		/// </summary>
		private void CloseHandler() {
			if (this.intSearchHandler != INVALID_HANDLE_VALUE) {
				FindClose(this.intSearchHandler);
				this.intSearchHandler = INVALID_HANDLE_VALUE;
			}
		}
		/// <summary>
		/// 开始搜索
		/// </summary>
		/// <returns>操作是否成功</returns>
		private bool StartSearch() {
			bolStartSearchFlag = true;
			bolIsEmpty = false;
			objCurrentObject = null;
			intLastErrorCode = 0;
			string strPath = Path.Combine(strSearchPath, this.strSearchPattern);
			this.CloseHandler();
			intSearchHandler = FindFirstFile(strPath, ref FFindData);
			if (intSearchHandler == INVALID_HANDLE_VALUE) {
				intLastErrorCode = Marshal.GetLastWin32Error();
				if (intLastErrorCode == 2) {
					bolIsEmpty = true;
					return false;
				}
				if (this.bolThrowIOException) {
					WinIOError(intLastErrorCode, strSearchPath);
				}
				else {
					return false;
				}
			}
			return true;
		}
		/// <summary>
		/// 搜索下一个
		/// </summary>
		/// <returns>操作是否成功</returns>
		private bool SearchNext() {
			if (bolStartSearchFlag == false) return false;
			if (bolIsEmpty) return false;
			if (intSearchHandler == INVALID_HANDLE_VALUE) return false;
			intLastErrorCode = 0;
			if (FindNextFile(intSearchHandler, ref FFindData) == false) {
				intLastErrorCode = Marshal.GetLastWin32Error();
				this.CloseHandler();
				if (intLastErrorCode != 0 && intLastErrorCode != 0x12) {
					if (this.bolThrowIOException) {
						WinIOError(intLastErrorCode, strSearchPath);
					}
					else {
						return false;
					}
				}
				return false;
			}
			return true;
		}
		/// <summary>
		/// 更新当前对象
		/// </summary>
		/// <returns>操作是否成功</returns>
		private bool UpdateCurrentObject() {
			if (intSearchHandler == INVALID_HANDLE_VALUE) return false;
			bool Result = false;
			this.objCurrentObject = null;
			if ((FFindData.dwFileAttributes & 0x10) == 0) {
				this.bolIsFile = true; //当前对象为文件
				if (this.bolSearchForFile) Result = true;
			}
			else {
				this.bolIsFile = false; //当前对象为目录
				if (this.bolSearchForDirectory) {
					Result = true;
					if (FFindData.cFileName == "." || FFindData.cFileName == "..") {
						Result = false;
					}
				}
			}
			if (Result) {
				if (this.bolReturnStringType) {
					this.objCurrentObject = FFindData.cFileName;
				}
				else {
					string p = Path.Combine(this.strSearchPath, FFindData.cFileName);
					if (this.bolIsFile) {
						this.objCurrentObject = new FileInfo(p);
					}
					else {
						this.objCurrentObject = new DirectoryInfo(p);
					}
				}
				this.intSearchedCount++;
			}
			return Result;
		}

		#endregion

	}
}
