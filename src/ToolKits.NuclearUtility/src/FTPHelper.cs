//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：FTPHelper.cs
// 项目名称：原子能式的高深学问方法实用工具集
// 创建时间：2016-04-13 23:46:42
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
using System.Net;

namespace GSA.ToolKits.NuclearUtility
{
    /// <summary>
    /// FTP 参数选项类
    /// </summary>
    [Serializable]
    public sealed class FTPOption
    {
        /// <summary>
        /// FTP连接地址
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// 端口号（默认21）
        /// </summary>
        public int Port { get; set; } = 21;

        /// <summary>
        /// 用户名（默认匿名[anonymous]）
        /// </summary>
        public string UserName { get; set; } = "anonymous";

        /// <summary>
        /// 密码（默认无）
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 指定FTP连接成功后的当前目录，如果不指定即默认为根目录。
        /// </summary>
        public string DefaultPath { get; set; } = string.Empty;

        /// <summary>
        /// 是否使用SSL安全连接模式（默认false不使用）
        /// </summary>
        public bool UseSSL { get; set; } = false;

        /// <summary>
        /// 在请求完成后是否关闭与FTP服务器的控制连接（默认false不关闭）
        /// </summary>
        public bool IsKeepAlive { get; set; } = false;
    }


    /// <summary>
    /// FTP 操作帮助类
    /// </summary>
    public sealed class FTPHelper : IDisposable
    {
        private FTPOption _option;
        private string _currentURI;
        private FtpWebRequest _ftpRequest;


        /// <summary>
        /// FTP 操作帮助类
        /// </summary>
        /// <param name="option">FTP 参数选项类</param>
        public FTPHelper(FTPOption option)
        {
            _option = option;
            _currentURI = $"ftp://{_option.Server}:{_option.Port}";

            if (!string.IsNullOrEmpty(_option.DefaultPath))
            {
                _currentURI = $"ftp://{_option.Server}:{_option.Port}/{ _option.DefaultPath}";
            }
        }


        /// <summary>
        /// 当前的 FTP 状态码
        /// </summary>
        public FtpStatusCode CurrentStatusCode { get; private set; }


        #region 成员方法

        /// <summary>
        /// 创建 FTP 服务
        /// </summary>
        private void CreateServer()
        {
            _ftpRequest = (FtpWebRequest)WebRequest.Create(_currentURI);
            _ftpRequest.Credentials = new NetworkCredential(_option.UserName, _option.Password);
            _ftpRequest.EnableSsl = _option.UseSSL;
            _ftpRequest.KeepAlive = _option.IsKeepAlive;

            CurrentStatusCode = FtpStatusCode.Undefined;
        }

        /// <summary>
        /// 切换到相对于当前目录下的指定目录（或层级目录）
        /// </summary>
        /// <remarks>当为层级目录时，格式必须为“dirA/dirB/dirC”。</remarks>
        /// <param name="directoryName">需要重定向的目录名称（或层级目录）</param>
        public void GotoDirectory(string directoryName) => _currentURI = $"{_currentURI}/{directoryName}";

        /// <summary>
        /// 将当前目录切换为 FTP 根目录
        /// </summary>
        public void GotoRoot() => _currentURI = $"ftp://{_option.Server}:{_option.Port}";

        /// <summary>
        /// 将当前目录切换为 FTP 默认指定的目录，当未指定时为根目录。
        /// </summary>
        public void GotoDefaut()
        {
            GotoRoot();

            if (!string.IsNullOrEmpty(_option.DefaultPath))
            {
                _currentURI = $"ftp://{_option.Server}:{_option.Port}/{ _option.DefaultPath}";
            }
        }

        #endregion

        #region 文件上传

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <remarks>
        /// 如果需要上传的文件不在当前目录，请先执行目录切换命令。
        /// </remarks>
        /// <param name="fileFullPath">需要上传的文件全路径</param>
        /// <returns>文件上传结果状态描述</returns>
        public string Upload(string fileFullPath)
        {
            if (string.IsNullOrEmpty(fileFullPath) || !File.Exists(fileFullPath))
            {
                throw new FileNotFoundException($"对不起！您欲上传的文件({fileFullPath})未找到，请确认后重试。");
            }

            string resultString = string.Empty;
            string tempCurrentURI = _currentURI;
            _currentURI = $"{_currentURI}/{Path.GetFileName(fileFullPath)}";

            CreateServer();
            _ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

            using (FileStream fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read))
            {
                _ftpRequest.ContentLength = fs.Length;
                using (Stream requestStream = _ftpRequest.GetRequestStream())
                {
                    int bufferSize = 2048;
                    byte[] buffer = new byte[bufferSize];
                    int readCount = fs.Read(buffer, 0, bufferSize);
                    while (readCount != 0)
                    {
                        requestStream.Write(buffer, 0, bufferSize);
                        readCount = fs.Read(buffer, 0, bufferSize);
                    }
                }
            }

            using (FtpWebResponse response = (FtpWebResponse)_ftpRequest.GetResponse())
            {
                resultString = response.StatusDescription;
                CurrentStatusCode = response.StatusCode;
            }

            _currentURI = tempCurrentURI;
            return resultString;
        }

        #endregion

        #region 文件下载

        /// <summary>
        /// 文件下载
        /// </summary>
        /// <remarks>
        /// 如果需要下载的文件不在当前目录，请先执行目录切换命令。
        /// </remarks>
        /// <param name="saveFullPath">文件下载后的保存全路径</param>
        /// <param name="downlaodFileName">当前目录下需要下载的文件名称</param>
        /// <returns>文件下载结果状态描述</returns>
        public string Download(string saveFullPath, string downlaodFileName)
        {
            string tempCurrentURI = _currentURI;
            _currentURI = $"{_currentURI}/{downlaodFileName}";

            CreateServer();
            _ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;

            string resultString = string.Empty;
            using (FtpWebResponse response = (FtpWebResponse)_ftpRequest.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (FileStream fs = new FileStream(saveFullPath, FileMode.Create, FileAccess.Write))
                    {
                        int bufferSize = 2048;
                        byte[] buffer = new byte[bufferSize];
                        int readCount = responseStream.Read(buffer, 0, bufferSize);
                        while (readCount > 0)
                        {
                            fs.Write(buffer, 0, bufferSize);
                            readCount = responseStream.Read(buffer, 0, bufferSize);
                        }
                    }
                }

                resultString = response.StatusDescription;
                CurrentStatusCode = response.StatusCode;
            }

            _currentURI = tempCurrentURI;
            return resultString;
        }

        #endregion

        #region 删除文件

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="deleteFileName">当前目录下需要删除的文件名称</param>
        /// <returns>文件删除结果状态描述</returns>
        public string Delete(string deleteFileName)
        {
            string tempCurrentURI = _currentURI;
            _currentURI = $"{_currentURI}/{deleteFileName}";

            CreateServer();
            _ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;

            string resultString = string.Empty;
            using (FtpWebResponse response = (FtpWebResponse)_ftpRequest.GetResponse())
            {
                resultString = response.StatusDescription;
                CurrentStatusCode = response.StatusCode;
            }

            _currentURI = tempCurrentURI;
            return resultString;
        }

        #endregion

        #region 目录与文件浏览

        /// <summary>
        /// 获取当前目录下所有目录名和文件名的详细信息
        /// </summary>
        /// <param name="resultArray">包含目录名和文件名的详细信息结果</param>
        /// <returns>获取结果状态描述</returns>
        public string GetListDirectoryDetails(out string[] resultArray)
        {
            CreateServer();
            _ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            List<string> resultList = new List<string>();
            string resultString = string.Empty;

            using (FtpWebResponse response = (FtpWebResponse)_ftpRequest.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(responseStream))
                    {
                        string lineString = sr.ReadLine();
                        while (lineString != null)
                        {
                            resultList.Add(lineString);
                            lineString = sr.ReadLine();
                        }
                    }
                }

                resultString = response.StatusDescription;
                CurrentStatusCode = response.StatusCode;
            }

            resultArray = resultList.ToArray();
            return resultString;
        }

        /// <summary>
        /// 获取当前目录下所有目录名和文件名
        /// </summary>
        /// <param name="resultArray">包含目录名和文件名的结果</param>
        /// <returns>获取结果状态描述</returns>
        public string GetListDirectory(out string[] resultArray)
        {
            CreateServer();
            _ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;

            List<string> resultList = new List<string>();
            string resultString = string.Empty;

            using (FtpWebResponse response = (FtpWebResponse)_ftpRequest.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(responseStream))
                    {
                        string lineString = sr.ReadLine();
                        while (lineString != null)
                        {
                            resultList.Add(lineString);
                            lineString = sr.ReadLine();
                        }
                    }
                }

                resultString = response.StatusDescription;
                CurrentStatusCode = response.StatusCode;
            }

            resultArray = resultList.ToArray();
            return resultString;
        }

        #endregion

        #region 目录创建&删除

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="directoryName">当前目录下需要创建的目录名称</param>
        /// <returns>目录创建结果状态描述</returns>
        public string CreateDirectory(string directoryName)
        {
            string tempCurrentURI = _currentURI;
            _currentURI = $"{_currentURI}/{directoryName}";

            CreateServer();
            _ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;

            string resultString = string.Empty;
            using (FtpWebResponse response = (FtpWebResponse)_ftpRequest.GetResponse())
            {
                resultString = response.StatusDescription;
                CurrentStatusCode = response.StatusCode;
            }

            _currentURI = tempCurrentURI;
            return resultString;
        }

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="directoryName">当前目录下需要删除的目录名称</param>
        /// <returns>目录删除结果状态描述</returns>
        public string DeleteDirectory(string directoryName)
        {
            string tempCurrentURI = _currentURI;
            _currentURI = $"{_currentURI}/{directoryName}";

            CreateServer();
            _ftpRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;

            string resultString = string.Empty;
            using (FtpWebResponse response = (FtpWebResponse)_ftpRequest.GetResponse())
            {
                resultString = response.StatusDescription;
                CurrentStatusCode = response.StatusCode;
            }

            _currentURI = tempCurrentURI;
            return resultString;
        }

        #endregion

        #region 文件重命名

        /// <summary>
        /// 文件重命名
        /// </summary>
        /// <param name="oldFileName">当前目录下需要重命名的旧的文件名称</param>
        /// <param name="newFileName">新的文件名称</param>
        /// <returns>文件重命名结果状态描述</returns>
        public string Rename(string oldFileName, string newFileName)
        {
            string tempCurrentURI = _currentURI;
            _currentURI = $"{_currentURI}/{oldFileName}";

            CreateServer();
            _ftpRequest.Method = WebRequestMethods.Ftp.Rename;
            _ftpRequest.RenameTo = newFileName;

            string resultString = string.Empty;
            using (FtpWebResponse response = (FtpWebResponse)_ftpRequest.GetResponse())
            {
                resultString = response.StatusDescription;
                CurrentStatusCode = response.StatusCode;
            }

            _currentURI = tempCurrentURI;
            return resultString;
        }

        #endregion

        /// <summary>
        /// 资源释放
        /// </summary>
        public void Dispose()
        {
            _option = null;
            _currentURI = null;
            _ftpRequest = null;
        }
    }
}
