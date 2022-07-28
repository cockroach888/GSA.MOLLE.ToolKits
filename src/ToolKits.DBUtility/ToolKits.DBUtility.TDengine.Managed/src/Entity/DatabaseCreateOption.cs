//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：DatabaseCreateOption.cs
// 项目名称：TDengine 数据库管理
// 创建时间：2022-07-25 14:02:31
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.ComponentModel.DataAnnotations;

namespace GSA.ToolKits.DBUtility.TDengine.Managed;

/// <summary>
/// 数据库选项参数类
/// </summary>
[Serializable]
public sealed class DatabaseCreateOption
{
    /// <summary>
    /// 数据库选项参数
    /// </summary>
    /// <param name="dBName">数据库名称</param>
    public DatabaseCreateOption(string dBName)
    {
        DBName = dBName;
    }


    /// <summary>
    /// 数据库名称
    /// </summary>
    /// <remarks>数据库名最大长度为33个半角字符。</remarks>
    [StringLength(33)]
    public string DBName { get; set; }

    /// <summary>
    /// 检查是否已存在
    /// <para>默认检查</para>
    /// </summary>
    /// <remarks>当数据已存在时不执行创建操作。</remarks>
    public bool CheckIsExist { get; set; } = true;

    /// <summary>
    /// 内存块的空间大小（单位:MB(兆)，范围1-128）
    /// <para>默认值 32MB</para>
    /// </summary>
    /// <remarks>
    /// TDengine 采用时间驱动缓存管理策略（First-In-First-Out，FIFO），又称为写驱动的缓存管理机制。
    /// <para>直接将最近到达的数据保存在缓存中，可以更加快速地响应用户针对最近一条或一批数据的查询分析，整体上提供更快的数据库查询响应能力。</para>
    /// </remarks>
    public byte Cache { get; set; } = 32;

    /// <summary>
    /// 每个vnode的内存块数量（范围3-10000）
    /// <para>默认值 8</para>
    /// </summary>
    /// <remarks>
    /// 每个vnode（tsdb）中有多少个cache大小的内存块。
    /// <para>而一个vnode所使用的内存大小，可粗略计算为（cache * blocks）。</para>
    /// </remarks>
    public short Blocks { get; set; } = 8;

    /// <summary>
    /// 数据存储时间跨度（单位天，范围1-3650）
    /// <para>默认值：1天</para>
    /// </summary>
    /// <remarks>数据文件存储数据的时间跨度</remarks>
    public short Days { get; set; } = 1;

    /// <summary>
    /// 数据保留天数（单位天，范围1-36500）
    /// <para>默认值 30天</para>
    /// </summary>
    /// <remarks>数据库会自动删除超过时限的数据</remarks>
    public ushort Keep { get; set; } = 30;

    /// <summary>
    /// 文件块中记录的最小条数（范围10-1000）
    /// <para>缺省值 100</para>
    /// </summary>
    public short? MinRows { get; set; }

    /// <summary>
    /// 文件块中记录的最大条数（范围200-10000）
    /// <para>缺省值 4096</para>
    /// </summary>
    public short? MaxRows { get; set; }

    /// <summary>
    /// WAL 级别
    /// <para>缺省值	1</para>
    /// </summary>
    /// <remarks>
    /// 定义：
    /// <para>0: 不写WAL;</para>
    /// <para>1：写 WAL, 但不执行 fsync；</para>
    /// <para>2：写 WAL, 而且执行 fsync。</para>
    /// </remarks>
    public byte? WalLevel { get; set; }

    /// <summary>
    /// 文件同步执行时间间隔（单位毫秒，范围0-180000）
    /// <para>缺省值	3000</para>
    /// </summary>
    /// <remarks>
    /// 当 WAL 设置为 2 时，执行 fsync 的周期。
    /// <para>最小为 0，表示每次写入，立即执行 fsync 最大为 180000（三分钟）</para>
    /// </remarks>
    public int? FSync { get; set; }

    /// <summary>
    /// 数据更新标识
    /// <para>默认值 0，不允许。</para>
    /// </summary>
    /// <remarks>
    /// 允许更新已存在的数据行
    /// <para>0，表示不允许更新数据，相同时间戳的数据会被直接丢弃；</para>
    /// <para>1，表示更新全部列数据，即如果更新一个数据行，其中某些列没有提供取值，那么这些列会被设为 NULL；</para>
    /// <para>2，表示支持更新部分列数据，即如果更新一个数据行，其中某些列没有提供取值，那么这些列会保持原有数据行中的对应值。</para>
    /// </remarks>
    public byte Update { get; set; } = 0;

    /// <summary>
    /// 是否在内存中缓存子表的最近数据
    /// <para>缺省值 0</para>
    /// </summary>
    /// <remarks>
    /// 定义：
    /// <para>0：关闭</para>
    /// <para>1：缓存子表最近一行数据</para>
    /// <para>2：缓存子表每一列的最近的非 NULL 值</para>
    /// <para>3：同时打开缓存最近行和列功能</para>
    /// </remarks>
    public byte? CacheLast { get; set; }

    /// <summary>
    /// 副本个数（范围1-3）
    /// <para>缺省值	1</para>
    /// </summary>
    public byte? Replica { get; set; }

    /// <summary>
    /// 多副本环境下指令执行的确认数要求（范围1，2）
    /// <para>缺省值	1</para>
    /// </summary>
    public byte? Quorum { get; set; }

    /// <summary>
    /// 文件压缩标志位
    /// <para>缺省值	2</para>
    /// </summary>
    /// <remarks>
    /// 定义：
    /// <para>0：关闭</para>
    /// <para>1：一阶段压缩</para>
    /// <para>2：两阶段压缩</para>
    /// </remarks>
    public byte? Comp { get; set; }

    /// <summary>
    /// 创建数据库时使用的时间精度
    /// <para>缺省值	ms</para>
    /// </summary>
    /// <remarks>
    /// 定义：
    /// <para>ms: millisecond</para>
    /// <para>us: microsecond</para>
    /// <para>ns: nanosecond</para>
    /// </remarks>
    public string? Precision { get; set; }
}