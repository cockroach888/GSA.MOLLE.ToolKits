//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：Definition.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-08-25 23:04:59
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace TDengineEx.Bootstrapper.ResetDB;

/// <summary>
/// 我是传奇
/// </summary>
internal sealed class Definition
{

    #region 单例模式

    private static readonly Lazy<Definition> _lazyInstance = new(() => new Definition());

    /// <summary>
    /// 我是传奇
    /// </summary>
    internal static Definition Default { get; } = _lazyInstance.Value;

    #endregion


    /// <summary>
    /// 气象自动站编号列表
    /// </summary>
    public (string id, string name, float longitude, float latitude, float altitude, int level)[] Ids { get; } = new (string id, string name, float longitude, float latitude, float altitude, int level)[]
    {
        (id:"qx1001",name:"气象自动站1001",66.66f,110.11f,1000f,16),
        (id:"qx1002",name:"气象自动站1002",66.66f,110.11f,1000f,16),
        (id:"qx1003",name:"气象自动站1003",66.66f,110.11f,1000f,16),
        (id:"qx1004",name:"气象自动站1004",66.66f,110.11f,1000f,16),
        (id:"qx1005",name:"气象自动站1005",66.66f,110.11f,1000f,16),
        (id:"qx1006",name:"气象自动站1006",66.66f,110.11f,1000f,16),
        (id:"qx1007",name:"气象自动站1007",66.66f,110.11f,1000f,16),
        (id:"qx1008",name:"气象自动站1008",66.66f,110.11f,1000f,16),
        (id:"qx1009",name:"气象自动站1009",66.66f,110.11f,1000f,16),
        (id:"qx1010",name:"气象自动站1010",66.66f,110.11f,1000f,16)
    };
}