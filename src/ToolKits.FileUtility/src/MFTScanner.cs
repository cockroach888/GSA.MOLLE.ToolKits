//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：MFTScanner.cs
// 项目名称：文件操作实用工具集
// 创建时间：2015-07-28 13:58:40
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
#if (NET48 || NET472 || NET471 || NET47 || NET462 || NET461 || NET46 || NET452 || NET451 || NET45 || NET40)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Principal;

namespace GSA.ToolKits.FileUtility {
	/// <summary>
	/// 文件及目录遍历扫描处理器扩展类
	/// <para>DriveInfo</para>
	/// <para>例子及运行时间测量：</para>
	/// <para>var sw = System.Diagnostics.Stopwatch.StartNew();</para>
	/// <para>var files = (new DriveInfo(@"c:\")).EnumerateFiles().ToArray();</para>
	/// <para>var elapsed = sw.ElapsedMilliseconds.ToString();</para>
	/// <para>Console.WriteLine(string.Format("Found {0} files, elapsed {1} ms", files.Length, elapsed));</para>
	/// </summary>
	public static class DriveInfoExtension {
		/// <summary>
		/// 枚举并遍历所有文件
		/// </summary>
		/// <param name="drive">驱动信息对象</param>
		/// <returns>遍历结果集</returns>
		public static IEnumerable<String> EnumerateFiles(this DriveInfo drive) {
			return (new MFTScanner()).EnumerateFiles(drive.Name);
		}
	}
	/// <summary>
	/// 文件及目录遍历扫描处理器类
	/// <para>USN Journal</para>
	/// </summary>
	public class MFTScanner {

#region 成员常量定义

		/// <summary>
		/// 
		/// </summary>
		private static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
		/// <summary>
		/// 
		/// </summary>
		private const uint GENERIC_READ = 0x80000000;
		/// <summary>
		/// 
		/// </summary>
		private const int FILE_SHARE_READ = 0x1;
		/// <summary>
		/// 
		/// </summary>
		private const int FILE_SHARE_WRITE = 0x2;
		/// <summary>
		/// 
		/// </summary>
		private const int OPEN_EXISTING = 3;
		/// <summary>
		/// 
		/// </summary>
		private const int FILE_READ_ATTRIBUTES = 0x80;
		/// <summary>
		/// 
		/// </summary>
		private const int FILE_NAME_IINFORMATION = 9;
		/// <summary>
		/// 
		/// </summary>
		private const int FILE_FLAG_BACKUP_SEMANTICS = 0x2000000;
		/// <summary>
		/// 
		/// </summary>
		private const int FILE_OPEN_FOR_BACKUP_INTENT = 0x4000;
		/// <summary>
		/// 
		/// </summary>
		private const int FILE_OPEN_BY_FILE_ID = 0x2000;
		/// <summary>
		/// 
		/// </summary>
		private const int FILE_OPEN = 0x1;
		/// <summary>
		/// 
		/// </summary>
		private const int OBJ_CASE_INSENSITIVE = 0x40;
		/// <summary>
		/// 
		/// </summary>
		private const int FSCTL_ENUM_USN_DATA = 0x900b3;

#endregion

#region 成员结构体定义

		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		private struct MFT_ENUM_DATA {
			/// <summary>
			/// 启动档案编号
			/// </summary>
			public long StartFileReferenceNumber;
			/// <summary>
			/// 最低USN
			/// </summary>
			public long LowUsn;
			/// <summary>
			/// 最高USN
			/// </summary>
			public long HighUsn;
		}
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		private struct USN_RECORD {
			/// <summary>
			/// 
			/// </summary>
			public int RecordLength;
			/// <summary>
			/// 
			/// </summary>
			public short MajorVersion;
			/// <summary>
			/// 
			/// </summary>
			public short MinorVersion;
			/// <summary>
			/// 
			/// </summary>
			public long FileReferenceNumber;
			/// <summary>
			/// 
			/// </summary>
			public long ParentFileReferenceNumber;
			/// <summary>
			/// 
			/// </summary>
			public long Usn;
			/// <summary>
			/// 
			/// </summary>
			public long TimeStamp;
			/// <summary>
			/// 
			/// </summary>
			public int Reason;
			/// <summary>
			/// 
			/// </summary>
			public int SourceInfo;
			/// <summary>
			/// 
			/// </summary>
			public int SecurityId;
			/// <summary>
			/// 
			/// </summary>
			public FileAttributes FileAttributes;
			/// <summary>
			/// 
			/// </summary>
			public short FileNameLength;
			/// <summary>
			/// 
			/// </summary>
			public short FileNameOffset;
		}
		/// <summary>
		/// IO状态阻塞
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		private struct IO_STATUS_BLOCK {
			/// <summary>
			/// 状态
			/// </summary>
			public int Status;
			/// <summary>
			/// 信息
			/// </summary>
			public int Information;
		}
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		private struct UNICODE_STRING {
			/// <summary>
			/// 
			/// </summary>
			public short Length;
			/// <summary>
			/// 
			/// </summary>
			public short MaximumLength;
			/// <summary>
			/// 
			/// </summary>
			public IntPtr Buffer;
		}
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		private struct OBJECT_ATTRIBUTES {
			/// <summary>
			/// 
			/// </summary>
			public int Length;
			/// <summary>
			/// 
			/// </summary>
			public IntPtr RootDirectory;
			/// <summary>
			/// 
			/// </summary>
			public IntPtr ObjectName;
			/// <summary>
			/// 
			/// </summary>
			public int Attributes;
			/// <summary>
			/// 
			/// </summary>
			public int SecurityDescriptor;
			/// <summary>
			/// 
			/// </summary>
			public int SecurityQualityOfService;
		}

#endregion

#region 系统API调用定义（MFT_ENUM_DATA）

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hDevice"></param>
		/// <param name="dwIoControlCode"></param>
		/// <param name="lpInBuffer"></param>
		/// <param name="nInBufferSize"></param>
		/// <param name="lpOutBuffer"></param>
		/// <param name="nOutBufferSize"></param>
		/// <param name="lpBytesReturned"></param>
		/// <param name="lpOverlapped"></param>
		/// <returns></returns>
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
		private static extern bool DeviceIoControl(IntPtr hDevice, int dwIoControlCode, ref MFT_ENUM_DATA lpInBuffer, int nInBufferSize, IntPtr lpOutBuffer, int nOutBufferSize, ref int lpBytesReturned, IntPtr lpOverlapped);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="lpFileName"></param>
		/// <param name="dwDesiredAccess"></param>
		/// <param name="dwShareMode"></param>
		/// <param name="lpSecurityAttributes"></param>
		/// <param name="dwCreationDisposition"></param>
		/// <param name="dwFlagsAndAttributes"></param>
		/// <param name="hTemplateFile"></param>
		/// <returns></returns>
		[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, int dwShareMode, IntPtr lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="lpObject"></param>
		/// <returns></returns>
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
		private static extern Int32 CloseHandle(IntPtr lpObject);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="FileHandle"></param>
		/// <param name="DesiredAccess"></param>
		/// <param name="ObjectAttributes"></param>
		/// <param name="IoStatusBlock"></param>
		/// <param name="AllocationSize"></param>
		/// <param name="FileAttribs"></param>
		/// <param name="SharedAccess"></param>
		/// <param name="CreationDisposition"></param>
		/// <param name="CreateOptions"></param>
		/// <param name="EaBuffer"></param>
		/// <param name="EaLength"></param>
		/// <returns></returns>
		[DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int NtCreateFile(ref IntPtr FileHandle, int DesiredAccess, ref OBJECT_ATTRIBUTES ObjectAttributes, ref IO_STATUS_BLOCK IoStatusBlock, int AllocationSize, int FileAttribs, int SharedAccess, int CreationDisposition, int CreateOptions, int EaBuffer, int EaLength);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="FileHandle"></param>
		/// <param name="IoStatusBlock"></param>
		/// <param name="FileInformation"></param>
		/// <param name="Length"></param>
		/// <param name="FileInformationClass"></param>
		/// <returns></returns>
		[DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int NtQueryInformationFile(IntPtr FileHandle, ref IO_STATUS_BLOCK IoStatusBlock, IntPtr FileInformation, int Length, int FileInformationClass);

#endregion

#region 成员变量

		/// <summary>
		/// 
		/// </summary>
		private IntPtr m_hCJ;
		/// <summary>
		/// 
		/// </summary>
		private IntPtr m_Buffer;
		/// <summary>
		/// 
		/// </summary>
		private int m_BufferSize;
		/// <summary>
		/// 
		/// </summary>
		private string m_DriveLetter;

#endregion

#region FSNode

		/// <summary>
		/// 
		/// </summary>
		private class FSNode {
			/// <summary>
			/// 
			/// </summary>
			public long FRN;
			/// <summary>
			/// 
			/// </summary>
			public long ParentFRN;
			/// <summary>
			/// 
			/// </summary>
			public string FileName;
			/// <summary>
			/// 
			/// </summary>
			public bool IsFile;
			/// <summary>
			/// 
			/// </summary>
			/// <param name="lFRN"></param>
			/// <param name="lParentFSN"></param>
			/// <param name="sFileName"></param>
			/// <param name="bIsFile"></param>
			public FSNode(long lFRN, long lParentFSN, string sFileName, bool bIsFile) {
				FRN = lFRN;
				ParentFRN = lParentFSN;
				FileName = sFileName;
				IsFile = bIsFile;
			}
		}

#endregion

#region 成员方法

		/// <summary>
		/// 
		/// </summary>
		/// <param name="szDriveLetter"></param>
		/// <returns></returns>
		private IntPtr OpenVolume(string szDriveLetter) {
			IntPtr hCJ = default(IntPtr);
			//// volume handle
			m_DriveLetter = szDriveLetter;
			hCJ = CreateFile("\\\\.\\" + szDriveLetter, GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
			return hCJ;
		}
		/// <summary>
		/// 
		/// </summary>
		private void Cleanup() {
			if (m_hCJ != IntPtr.Zero) {
				// Close the volume handle.
				CloseHandle(m_hCJ);
				m_hCJ = INVALID_HANDLE_VALUE;
			}
			if (m_Buffer != IntPtr.Zero) {
				// Free the allocated memory
				Marshal.FreeHGlobal(m_Buffer);
				m_Buffer = IntPtr.Zero;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="szDriveLetter"></param>
		/// <returns></returns>
		public IEnumerable<String> EnumerateFiles(string szDriveLetter) {
			try {
				var usnRecord = default(USN_RECORD);
				var mft = default(MFT_ENUM_DATA);
				var dwRetBytes = 0;
				var cb = 0;
				var dicFRNLookup = new Dictionary<long, FSNode>();
				var bIsFile = false;
				// This shouldn't be called more than once.
				if (m_Buffer.ToInt32() != 0) {
					throw new Exception("invalid buffer");
				}
				// Assign buffer size
				m_BufferSize = 65536;
				//64KB
				// Allocate a buffer to use for reading records.
				m_Buffer = Marshal.AllocHGlobal(m_BufferSize);
				// correct path
				szDriveLetter = szDriveLetter.TrimEnd('\\');
				// Open the volume handle 
				m_hCJ = OpenVolume(szDriveLetter);
				// Check if the volume handle is valid.
				//if (m_hCJ == INVALID_HANDLE_VALUE) {
				//	throw new Exception("Couldn't open handle to the volume.");
				//}
				// Check if the volume handle is valid.
				if (m_hCJ == INVALID_HANDLE_VALUE) {
					string errorMsg = "Couldn't open handle to the volume.";
					if (!IsAdministrator()) errorMsg += "Current user is not administrator";
					throw new Exception(errorMsg);
				}
				mft.StartFileReferenceNumber = 0;
				mft.LowUsn = 0;
				mft.HighUsn = long.MaxValue;
				do {
					if (DeviceIoControl(m_hCJ, FSCTL_ENUM_USN_DATA, ref mft, Marshal.SizeOf(mft), m_Buffer, m_BufferSize, ref dwRetBytes, IntPtr.Zero)) {
						cb = dwRetBytes;
						// Pointer to the first record
						IntPtr pUsnRecord = new IntPtr(m_Buffer.ToInt32() + 8);
						while ((dwRetBytes > 8)) {
							// Copy pointer to USN_RECORD structure.
							usnRecord = (USN_RECORD)Marshal.PtrToStructure(pUsnRecord, usnRecord.GetType());
							// The filename within the USN_RECORD.
							string FileName = Marshal.PtrToStringUni(new IntPtr(pUsnRecord.ToInt32() + usnRecord.FileNameOffset), usnRecord.FileNameLength / 2);
							bIsFile = !usnRecord.FileAttributes.HasFlag(FileAttributes.Directory);
							dicFRNLookup.Add(usnRecord.FileReferenceNumber, new FSNode(usnRecord.FileReferenceNumber, usnRecord.ParentFileReferenceNumber, FileName, bIsFile));
							// Pointer to the next record in the buffer.
							pUsnRecord = new IntPtr(pUsnRecord.ToInt32() + usnRecord.RecordLength);
							dwRetBytes -= usnRecord.RecordLength;
						}
						// The first 8 bytes is always the start of the next USN.
						mft.StartFileReferenceNumber = Marshal.ReadInt64(m_Buffer, 0);
					}
					else {
						break; // TODO: might not be correct. Was : Exit Do
					}

			} while (!(cb <= 8));
				// Resolve all paths for Files
				foreach (FSNode oFSNode in dicFRNLookup.Values.Where(o => o.IsFile)) {
					string sFullPath = oFSNode.FileName;
					FSNode oParentFSNode = oFSNode;
					while (dicFRNLookup.TryGetValue(oParentFSNode.ParentFRN, out oParentFSNode)) {
						sFullPath = string.Concat(oParentFSNode.FileName, "\\", sFullPath);
					}
					sFullPath = string.Concat(szDriveLetter, "\\", sFullPath);
					yield return sFullPath;
				}
			}
			finally {
				Cleanup();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static bool IsAdministrator() {
			WindowsIdentity identity = WindowsIdentity.GetCurrent();
			WindowsPrincipal principal = new WindowsPrincipal(identity);
			return principal.IsInRole(WindowsBuiltInRole.Administrator);
		}

#endregion

	}
}
#endif