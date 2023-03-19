//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：StatusHelper.cs
// 项目名称：EMQX消息服务工具集
// 创建时间：2023-03-16 23:19:02
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.EMQXUtility;

/// <summary>
/// 服务节点状态信息助手
/// </summary>
internal sealed class StatusHelper : EMQXConnectorAbstract, IStatusHelper
{
    /// <summary>
    /// 服务节点状态信息助手
    /// </summary>
    /// <param name="options">选项参数</param>
    internal StatusHelper(EMQXManagementOptions options)
        : base(options) { }


    #region 接口实现[IStatusHelper]

    // do something.

    #endregion

}