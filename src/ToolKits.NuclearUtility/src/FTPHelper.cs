//==================================================================== 
//**   晨曦小竹常用工具集
//====================================================================
//**   Copyright © DawnXZ.com 2014 -- QQ：6808240 -- 请保留此注释
//====================================================================
// 文件名称：FTPHelper.cs
// 项目名称：原子能式的高深学问方法实用工具集
// 创建时间：2016-04-13 23:46:42
// 创建人员：宋杰军
// 负 责 人：宋杰军
// 参与人员：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace DawnXZ.NuclearUtility {
	/// <summary>
	/// FTP操作帮助类
	/// </summary>
	public class FTPHelper {
		/// <summary>
		/// FTP操作帮助类
		/// </summary>
		/// <param name="server">FTP连接地址</param>
		/// <param name="port">端口号</param>
		/// <param name="user">用户名</param>
		/// <param name="pass">密码</param>
		/// <param name="currentPath">指定FTP连接成功后的当前目录, 如果不指定即默认为根目录</param>
		public FTPHelper(string server, int port, string user, string pass, string currentPath = null) {
			FServer = string.Format("{0}:{1}", server, port);
			FUser = user;
			FPass = pass;
			FCurrentPath = currentPath;
			if (string.IsNullOrEmpty(currentPath)) {
				FCurrentURI = string.Format("ftp://{0}/", FServer);
			}
			else {
				FCurrentURI = string.Format("ftp://{0}/{1}/", FServer, FCurrentPath);
			}
		}

		#region 成员属性

		/// <summary>
		/// FTP连接地址
		/// </summary>
		public string FServer { get; private set; }
		/// <summary>
		/// 用户名
		/// </summary>
		public string FUser { get; private set; }
		/// <summary>
		/// 密码
		/// </summary>
		public string FPass { get; private set; }
		/// <summary>
		/// FTP当前目录
		/// </summary>
		public string FCurrentPath { get; private set; }
		/// <summary>
		/// FTP连接当前的完整路径
		/// </summary>
		public string FCurrentURI { get; private set; }

		#endregion

		#region 上传 / 下载

		/// <summary>
		/// 文件上传
		/// </summary>
		/// <param name="_fileName">需要上传的文件（绝对路径）</param>
		public void Upload(string _fileName) {
			if (!File.Exists(_fileName)) return;
			FileInfo _fileInfo = new FileInfo(_fileName);
			FtpWebRequest reqFTP;
			reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(string.Format("{0}{1}", FCurrentURI, _fileInfo.Name)));
			reqFTP.Credentials = new NetworkCredential(FUser, FPass);
			reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
			reqFTP.KeepAlive = false;
			reqFTP.UseBinary = true;
			reqFTP.ContentLength = _fileInfo.Length;
			int dataLength = 2048;
			byte[] _buffer = new byte[dataLength];
			int contentLen;
			FileStream fs = _fileInfo.OpenRead();
			try {
				Stream _stream = reqFTP.GetRequestStream();
				contentLen = fs.Read(_buffer, 0, dataLength);
				while (contentLen != 0) {
					_stream.Write(_buffer, 0, contentLen);
					contentLen = fs.Read(_buffer, 0, dataLength);
				}
				_stream.Close();
				_stream.Dispose();
				fs.Close();
				fs.Dispose();
			}
			catch (Exception ex) {
				throw new Exception(ex.Message, ex);
			}
		}
		/// <summary>
		/// 文件下载
		/// </summary>
		/// <param name="_filePath">文件下载后的存放路径</param>
		/// <param name="_fileName">需要下载的文件名称</param>
		public void Download(string _filePath, string _fileName) {
			try {
				FileStream outputStream = new FileStream(Path.Combine(_filePath, _fileName), FileMode.Create);
				FtpWebRequest reqFTP;
				reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(string.Format("{0}{1}", FCurrentURI, _fileName)));
				reqFTP.Credentials = new NetworkCredential(FUser, FPass);
				reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
				reqFTP.UseBinary = true;
				FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
				Stream ftpStream = response.GetResponseStream();
				long cl = response.ContentLength;
				int bufferSize = 2048;
				int readCount;
				byte[] buffer = new byte[bufferSize];
				readCount = ftpStream.Read(buffer, 0, bufferSize);
				while (readCount > 0) {
					outputStream.Write(buffer, 0, readCount);
					readCount = ftpStream.Read(buffer, 0, bufferSize);
				}
				ftpStream.Close();
				ftpStream.Dispose();
				outputStream.Close();
				outputStream.Dispose();
				response.Close();
			}
			catch (Exception ex) {
				throw new Exception(ex.Message, ex);
			}
		}

		#endregion

		#region 文件读取

		/// <summary>
		/// 获取当前目录下明细(包含文件和文件夹)
		/// </summary>
		/// <returns>当前目录下明细(包含文件和文件夹)</returns>
		public string[] GetFilesDetailList() {
			try {
				StringBuilder result = new StringBuilder();
				FtpWebRequest ftp;
				ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(FCurrentURI));
				ftp.Credentials = new NetworkCredential(FUser, FPass);
				ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
				WebResponse response = ftp.GetResponse();
				StreamReader reader = new StreamReader(response.GetResponseStream());
				string line = reader.ReadLine();
				line = reader.ReadLine();
				line = reader.ReadLine();
				while (line != null) {
					result.Append(line);
					result.Append("\n");
					line = reader.ReadLine();
				}
				result.Remove(result.ToString().LastIndexOf("\n"), 1);
				reader.Close();
				response.Close();
				return result.ToString().Split('\n');
			}
			catch (Exception ex) {
				throw new Exception(ex.Message, ex);
			}
		}
		/// <summary>
		/// 获取FTP文件列表(包括文件夹)
		/// </summary>
		/// <param name="ftpURI">FTP连接的完整路径</param>
		/// <returns>FTP文件列表(包括文件夹)</returns>
		private string[] GetAllList(string ftpURI) {
			List<string> list = new List<string>();
			FtpWebRequest req = (FtpWebRequest)WebRequest.Create(new Uri(ftpURI));
			req.Credentials = new NetworkCredential(FUser, FPass);
			req.Method = WebRequestMethods.Ftp.ListDirectory;
			req.UseBinary = true;
			req.UsePassive = true;
			try {
				using (FtpWebResponse res = (FtpWebResponse)req.GetResponse()) {
					using (StreamReader sr = new StreamReader(res.GetResponseStream())) {
						string s;
						while ((s = sr.ReadLine()) != null) {
							list.Add(s);
						}
					}
				}
			}
			catch (Exception ex) {
				throw new Exception(ex.Message, ex);
			}
			return list.ToArray();
		}
		/// <summary>
		/// 获取当前目录下文件列表(不包括文件夹)
		/// </summary>
		/// <param name="ftpURI">FTP连接的完整路径</param>
		/// <returns>当前目录下文件列表(不包括文件夹)</returns>
		public string[] GetFileList(string ftpURI) {
			StringBuilder result = new StringBuilder();
			FtpWebRequest reqFTP;
			try {
				reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
				reqFTP.UseBinary = true;
				reqFTP.Credentials = new NetworkCredential(FUser, FPass);
				reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
				WebResponse response = reqFTP.GetResponse();
				StreamReader reader = new StreamReader(response.GetResponseStream());
				string line = reader.ReadLine();
				while (line != null) {
					if (line.IndexOf("<DIR>") == -1) {
						result.Append(Regex.Match(line, @"[\S]+ [\S]+", RegexOptions.IgnoreCase).Value.Split(' ')[1]);
						result.Append("\n");
					}
					line = reader.ReadLine();
				}
				result.Remove(result.ToString().LastIndexOf('\n'), 1);
				reader.Close();
				response.Close();
			}
			catch (Exception ex) {
				throw new Exception(ex.Message, ex);
			}
			return result.ToString().Split('\n');
		}

		#endregion

		#region 文件操作

		/// <summary>
		/// 删除文件
		/// </summary>
		/// <param name="_fileName">需要删除的文件名称</param>
		public void Delete(string _fileName) {
			try {
				FtpWebRequest reqFTP;
				reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(string.Format("{0}{1}", FCurrentURI, _fileName)));
				reqFTP.Credentials = new NetworkCredential(FUser, FPass);
				reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
				reqFTP.KeepAlive = false;
				string result = String.Empty;
				FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
				long size = response.ContentLength;
				Stream datastream = response.GetResponseStream();
				StreamReader sr = new StreamReader(datastream);
				result = sr.ReadToEnd();
				sr.Close();
				datastream.Close();
				response.Close();
			}
			catch (Exception ex) {
				throw new Exception(ex.Message, ex);
			}
		}
		/// <summary>
		/// 判断当前目录下指定的文件是否存在
		/// </summary>
		/// <param name="remoteFileName">远程文件名称</param>
		/// <returns>判断结果</returns>
		public bool FileExist(string remoteFileName) {
			string[] fileList = GetFileList(FCurrentURI);
			if (null == fileList || fileList.Length <= 0) return false;
			foreach (string str in fileList) {
				if (str.Trim() == remoteFileName.Trim()) return true;
			}
			return false;
		}
		/// <summary>
		/// 判断当前目录下指定的目录是否存在
		/// </summary>
		/// <param name="dirName">文件夹名称</param>
		/// <returns>判断结果</returns>
		public bool DirExist(string dirName) {
			if (string.IsNullOrEmpty(dirName)) return false;
			try {
				string tmpURI = string.Format("{0}{1}", FCurrentURI, dirName);
				string[] result = GetAllList(tmpURI);
				return null != result && result.Length > 0 ? true : false;
			}
			catch {
				return false;
			}
		}
		/// <summary>
		/// 创建文件夹
		/// </summary>
		/// <param name="dirName">文件夹名称</param>
		public void MakeDir(string dirName) {
			FtpWebRequest reqFTP;
			try {
				reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(string.Format("{0}{1}", FCurrentURI, dirName)));
				reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
				reqFTP.UseBinary = true;
				reqFTP.Credentials = new NetworkCredential(FUser, FPass);
				FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
				Stream ftpStream = response.GetResponseStream();
				ftpStream.Close();
				response.Close();
			}
			catch (Exception ex) {
				throw new Exception(ex.Message, ex);
			}
		}
		/// <summary>
		/// 获取指定文件大小
		/// </summary>
		/// <param name="_filename">文件名称</param>
		/// <returns>文件大小</returns>
		public long GetFileSize(string _filename) {
			FtpWebRequest reqFTP;
			long fileSize = 0;
			try {
				reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(string.Format("{0}{1}", FCurrentURI, _filename)));
				reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
				reqFTP.UseBinary = true;
				reqFTP.Credentials = new NetworkCredential(FUser, FPass);
				FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
				Stream ftpStream = response.GetResponseStream();
				fileSize = response.ContentLength;
				ftpStream.Close();
				response.Close();
			}
			catch (Exception ex) {
				throw new Exception(ex.Message, ex);
			}
			return fileSize;
		}
		/// <summary>
		/// 更改文件名
		/// </summary>
		/// <param name="currentFilename">当前文件名</param>
		/// <param name="newFilename">更改后的文件名</param>
		public void RenName(string currentFilename, string newFilename) {
			FtpWebRequest reqFTP;
			try {
				reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(string.Format("{0}{1}", FCurrentURI, currentFilename)));
				reqFTP.Method = WebRequestMethods.Ftp.Rename;
				reqFTP.RenameTo = newFilename;
				reqFTP.UseBinary = true;
				reqFTP.Credentials = new NetworkCredential(FUser, FPass);
				FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
				Stream ftpStream = response.GetResponseStream();
				ftpStream.Close();
				response.Close();
			}
			catch (Exception ex) {
				throw new Exception(ex.Message, ex);
			}
		}
		/// <summary>
		/// 移动文件
		/// </summary>
		/// <param name="currentFilename">移动前</param>
		/// <param name="newDirectory">移动后</param>
		public void MovieFile(string currentFilename, string newDirectory) {
			RenName(currentFilename, newDirectory);
		}

		#endregion

		#region 成员方法

		/// <summary>
		/// 切换当前目录
		/// </summary>
		/// <param name="dirName">目录名称</param>
		/// <param name="isRoot">true:绝对路径 false:相对路径</param>
		public void GotoDirectory(string dirName, bool isRoot) {
			if (isRoot) {
				FCurrentPath = dirName;
			}
			else {
				FCurrentPath += dirName + "/";
			}
			FCurrentURI = string.Format(@"ftp://{0}/{1}/", FServer, FCurrentPath);
		}
		/// <summary>
		/// 切换至FTP根目录
		/// </summary>
		public void GotoRoot() {
			FCurrentURI = string.Format(@"ftp://{0}/", FServer);
		}

		#endregion

	}
}
