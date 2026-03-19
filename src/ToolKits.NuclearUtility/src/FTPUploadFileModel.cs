//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2026 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：FTPUploadFileOption.cs
// 项目名称：原子能式的高深学问方法实用工具集
// 创建时间：2026-03-18 16:18:51
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.NuclearUtility;

/// <summary>
/// FTP文件上传实体类
/// </summary>
[Serializable]
public sealed class FTPUploadFileModel
{
    /// <summary>
    /// 本地文件路径
    /// </summary>
    /// <remarks>需要上传的本地文件全路径</remarks>
    public string LocalFullPath { get; set; } = string.Empty;

    /// <summary>
    /// 远程文件路径（以/开头）
    /// </summary>
    /// <remarks>FTP服务器中以“/”开头的文件全路径</remarks>
    public string RemoteFullPath { get; set; } = string.Empty;

    /// <summary>
    /// 文件存在时是否自动覆盖（默认为覆盖）
    /// </summary>
    /// <remarks>true 覆盖，false 不覆盖。</remarks>
    public bool IsOverwrite { get; set; } = true;

    /// <summary>
    /// 是否自动创建目标路径中不存在的目录（默认为创建）
    /// </summary>
    /// <remarks>true 创建，false 不创建。</remarks>
    public bool AutoCreateDirectory { get; set; } = true;

    /// <summary>
    /// 上传完成后，是否自动检查该文件的正确性。（默认为检查）
    /// </summary>
    /// <remarks>true 检查，false 不检查。</remarks>
    public bool AutoVerify { get; set; } = true;

    /// <summary>
    /// CancellationToken (default is default)
    /// </summary>
    public CancellationToken CancelToken { get; set; } = default;
}