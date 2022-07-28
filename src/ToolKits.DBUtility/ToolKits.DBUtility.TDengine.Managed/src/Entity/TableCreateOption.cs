//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TableCreateOption.cs
// 项目名称：TDengine 数据库管理
// 创建时间：2022-07-25 14:02:56
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
/// 数据表创建选项参数类
/// </summary>
[Serializable]
public sealed class TableCreateOption
{
    /// <summary>
    /// 数据表创建选项参数
    /// </summary>
    /// <param name="dBName">数据库名称</param>
    /// <param name="tbName">数据表名称</param>
    public TableCreateOption(string dBName, string tbName)
    {
        DBName = dBName;
        TableName = tbName;
    }


    /// <summary>
    /// 检查是否已存在
    /// <para>默认检查</para>
    /// </summary>
    /// <remarks>当超级数据表已存在时不执行创建操作。</remarks>
    public bool CheckIsExist { get; set; } = true;

    /// <summary>
    /// 数据库名称
    /// </summary>
    /// <remarks>数据库名最大长度为33个半角字符。</remarks>
    [Required]
    [StringLength(33)]
    public string DBName { get; set; }

    /// <summary>
    /// 数据表名称
    /// </summary>
    /// <remarks>数据表名称最大长度为192个半角字符</remarks>    
    [Required]
    [StringLength(192)]
    public string TableName { get; set; }

    /// <summary>
    /// 包含所有字段名称和对应数据类型的字符串
    /// <para>当使用超级表作为数据表约束创建时，此字段将无效。</para>
    /// </summary>
    /// <remarks>
    /// 注意事项：
    /// <para>字段名称和数据类型之间，使用半角空格隔开。</para>
    /// <para>多个字段定义之间，使用半角逗号(,)分隔。</para>
    /// </remarks>
    public string? Columns { get; set; }

    /// <summary>
    /// 超级数据表名称
    /// </summary>
    [StringLength(192)]
    public string? STableName { get; set; }

    /// <summary>
    /// 使用超级表中指定的标签定义
    /// <para>当不指定时，将默认使用超级表中定义的所有标签。</para>
    /// </summary>
    /// <remarks>多个标签名称之间使用半角逗号(,)隔开</remarks>
    public string? TagNames { get; set; } = string.Empty;

    /// <summary>
    /// 各标签定义的值
    /// </summary>
    /// <remarks>多个标签值之间使用半角逗号(,)隔开</remarks>
    public string? TagValues { get; set; } = string.Empty;
}