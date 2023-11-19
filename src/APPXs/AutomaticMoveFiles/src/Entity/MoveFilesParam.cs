//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MoveFilesParam.cs
// 项目名称：自动移动文件工具
// 创建时间：2023-11-15 22:02:45
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.AutomaticMoveFiles.Entity;

/// <summary>
/// 自动移动文件参数
/// </summary>
[Serializable]
public sealed class MoveFilesParam
{
    /// <summary>
    /// 监视目录
    /// </summary>
    public string MonitorDirectories { get; set; } = string.Empty;

    /// <summary>
    /// 目标目录
    /// </summary>
    public string TargetDirectories { get; set; } = string.Empty;

    /// <summary>
    /// 是否包含子目录
    /// </summary>
    public bool IsIncludeSubdirectories { get; set; }

    /// <summary>
    /// 是否清理所有层级的空目录
    /// </summary>
    public bool IsCleanEmptyFolder { get; set; }

    /// <summary>
    /// 排除隐藏文件和文件夹
    /// </summary>
    public bool ExcludeHiddenFiles { get; set; }

    /// <summary>
    /// 排除系统文件和文件夹
    /// </summary>
    public bool ExcludeSystemFiles { get; set; }

    /// <summary>
    /// 排除临时文件和文件夹
    /// </summary>
    public bool ExcludeTemporaryFiles { get; set; }

    /// <summary>
    /// 轮循周期
    /// </summary>
    public TimeSpan CycleTimeDelay { get; set; }

    /// <summary>
    /// 前置时间
    /// </summary>
    public TimeSpan LeadTime { get; set; }

    /// <summary>
    /// 工作线程
    /// </summary>
    public int WorkerThreads { get; set; }
}