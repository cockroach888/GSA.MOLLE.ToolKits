//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：AutoStationDataHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-09-16 15:21:05
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace TDengineEx.DataHelper;

/// <summary>
/// 气象自动站数据数据访问助手类
/// </summary>
internal sealed class AutoStationDataHelper : DataHelperAbstract, IAutoStationDataHelper
{
    /// <summary>
    /// 气象自动站数据数据访问助手
    /// </summary>
    /// <param name="connector">TDengine RESTful API 连接器</param>
    public AutoStationDataHelper(ITDengineConnector connector)
        : base(connector)
    { }


    /// <summary>
    /// 数据表格前缀
    /// </summary>
    /// <remarks>PS：超级表与子表的关联性，也可以是独立表名称。</remarks>
    internal override string? TablePrefix => "auto_station";
}