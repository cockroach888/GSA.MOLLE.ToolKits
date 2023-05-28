//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：XmlParameter.cs
// 项目名称：文件操作实用工具集
// 创建时间：2023-05-28 18:14:23
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.FileUtility.Entity;

/// <summary>
/// Xml 参数
/// </summary>
[Serializable]
public sealed class XmlParameter
{
    /// <summary>
    /// 属性名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 内部文本
    /// </summary>
    public string? InnerText { get; set; }

    /// <summary>
    /// 命名空间的前缀
    /// </summary>
    public string? NamespaceOfPrefix { get; set; }

    /// <summary>
    /// 属性参数
    /// </summary>
    public AttributeParameter[]? Attributes { get; set; }
}