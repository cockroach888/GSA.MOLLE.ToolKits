//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：TDengineFieldDesc.cs
// 项目名称：TDengine RESTful API 连接器
// 创建时间：2022-06-22 22:16:05
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.DBUtility.TDengine;

/// <summary>
/// 字段描述实体类
/// </summary>
[Serializable]
public sealed class TDengineFieldDesc
{
    /// <summary>
    /// 字段名称
    /// </summary>
    public string? FieldName { get; set; }

    /// <summary>
    /// 字段类型
    /// </summary>
    public TDengineDataType FieldType { get; set; }

    /// <summary>
    /// 字段大小
    /// </summary>
    public short FiledSize { get; set; }
}