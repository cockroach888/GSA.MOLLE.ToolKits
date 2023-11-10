//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：DeletionFilesParam.cs
// 项目名称：自动删除文件工具
// 创建时间：2023-11-10 17:17:23
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Text.Json.Serialization;

namespace GSA.ToolKits.AutomaticDeletionFiles.Entity;

/// <summary>
/// 自动删除文件参数
/// </summary>
[Serializable]
public sealed class DeletionFilesParam
{
    /// <summary>
    /// 监视目录
    /// </summary>
    public string MonitorDirectories { get; set; } = string.Empty;

    /// <summary>
    /// 是否包含子目录
    /// </summary>
    public bool IncludeSubdirectories { get; set; }

    /// <summary>
    /// 排除隐藏文件和文件夹
    /// </summary>
    public bool ExcludeHiddenFiles { get; set; }

    /// <summary>
    /// 排除系统文件和文件夹
    /// </summary>
    public bool ExcludeSystemFiles { get; set; }

    /// <summary>
    /// 轮循周期
    /// </summary>
    public int CycleTimeDelay { get; set; }

    /// <summary>
    /// 前置时间
    /// </summary>
    public int LeadTime { get; set; }

    /// <summary>
    /// 前置时间单位
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public LeadTimeType LeadTimeUnit { get; set; }

    /// <summary>
    /// 工作线程
    /// </summary>
    public int WorkerThreads { get; set; }
}