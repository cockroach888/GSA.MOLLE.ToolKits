//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：FTPHelper.cs
// 项目名称：原子能式的高深学问方法实用工具集
// 创建时间：2016-04-13 23:46:42
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using FluentFTP;
using FluentFTP.Helpers;
using System.Net;
using System.Reflection;

namespace GSA.ToolKits.NuclearUtility;

/// <summary>
/// FTP日常操作助手类
/// </summary>
/// <param name="option">FTP选项参数类</param>
public sealed class FTPHelper(FTPOption option) : IDisposable
{
    /// <summary>
    /// 当前的 FTP 状态码
    /// </summary>
    public FtpStatusCode CurrentStatusCode { get; private set; }


    /// <summary>
    /// 获得FTP客户端
    /// </summary>
    /// <returns>AsyncFtpClient</returns>
    private AsyncFtpClient GetFtpClient()
    {
        CurrentStatusCode = FtpStatusCode.Undefined;

        return new()
        {
            Host = option.Host,
            Port = option.Port,
            Credentials = new NetworkCredential(option.UserName, option.Password)
        };
    }


    /// <summary>
    /// 文件上传
    /// </summary>
    /// <param name="model">status.IsFailure()</param>
    /// <returns>true 上传成功，false 上传失败。</returns>
    /// <exception cref="FileNotFoundException">文件未找到异常</exception>
    public async Task<bool> UploadFileAsync(FTPUploadFileModel model)
    {
        if (string.IsNullOrWhiteSpace(model.LocalFullPath) is true ||
            File.Exists(model.LocalFullPath) is false)
        {
            throw new FileNotFoundException($"对不起！未找到需要上传的文件“{model.LocalFullPath}”，请确认后重试。");
        }

        using AsyncFtpClient client = GetFtpClient();
        await client.Connect(option.CancelToken);

        FtpStatus status = await client.UploadFile(
            model.LocalFullPath,
            model.RemoteFullPath,
            existsMode: model.IsOverwrite ? FtpRemoteExists.Overwrite : FtpRemoteExists.Skip,
            createRemoteDir: model.AutoCreateDirectory,
            verifyOptions: model.AutoVerify ? FtpVerify.Retry : FtpVerify.None,
            token: model.CancelToken);

        return !status.IsFailure() && status.IsSuccess();
    }


    public async Task<bool> UploadDirectoryAsync(
        string localFullFolder,
        string remoteFullFolder,
        bool isUseMirror,
        CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(localFullFolder) is true ||
            Directory.Exists(localFullFolder) is false)
        {
            throw new FileNotFoundException($"对不起！未找到需要上传的目录“{localFullFolder}”，请确认后重试。");
        }

        using AsyncFtpClient client = GetFtpClient();
        await client.Connect(option.CancelToken);

        List<FtpResult> results = await client.UploadDirectory(
            localFullFolder,
            remoteFullFolder,
            isUseMirror ? FtpFolderSyncMode.Mirror : FtpFolderSyncMode.Update,
            token: token);

        // upload a folder and all its files


        // upload a folder and all its files, and delete extra files on the server
        await client.UploadDirectory(@"C:\website\assets\", @"/public_html/assets", FtpFolderSyncMode.Mirror, token: token);


    }





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
    public string? Download(string saveFullPath, string downlaodFileName)
    {
        Uri tempCurrentURI = _currentURI;
        _currentURI = new Uri($"{_currentURI.OriginalString}/{downlaodFileName}");

        CreateServer();
        _ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;

        string? resultString = string.Empty;
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
        Uri tempCurrentURI = new Uri(;
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




    /// <summary>
    /// 资源释放
    /// </summary>
    public void Dispose()
    {
        // do something.
    }
}
