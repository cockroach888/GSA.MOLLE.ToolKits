//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：STableCreateOption.cs
// 项目名称：TDengine 数据库管理
// 创建时间：2022-07-25 14:03:10
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
/// 超级数据表创建选项参数类
/// </summary>
[Serializable]
public sealed class STableCreateOption
{
    /// <summary>
    /// 超级数据表创建选项参数
    /// </summary>
    /// <param name="dBName">数据库名称</param>
    /// <param name="stbName">超级数据表名称</param>
    public STableCreateOption(string dBName, string stbName)
    {
        DBName = dBName;
        STableName = stbName;
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
    /// 超级数据表名称
    /// </summary>
    /// <remarks>超级数据表名称最大长度为192个半角字符</remarks>
    [Required]
    [StringLength(192)]
    public string STableName { get; set; }

    /// <summary>
    /// 包含所有字段名称和对应数据类型定义的字符串
    /// </summary>
    /// <remarks>
    /// 注意事项：
    /// <para>字段名称和数据类型之间，使用半角空格隔开。</para>
    /// <para>多个字段定义之间，使用半角逗号(,)分隔。</para>
    /// </remarks>
    [Required]
    public string Columns { get; set; } = string.Empty;

    /// <summary>
    /// 包含所有标签名称和对应数据类型定义的字符串
    /// </summary>
    /// <remarks>
    /// 注意事项：
    /// <para>标签名称和数据类型之间，使用半角空格隔开。</para>
    /// <para>多个标签定义之间，使用半角逗号(,)分隔。</para>
    /// </remarks>
    [Required]
    public string Tags { get; set; } = string.Empty;
}