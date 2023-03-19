//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：AuthenticationHelper.cs
// 项目名称：EMQX消息服务工具集
// 创建时间：2023-03-16 21:44:14
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
/// 全局认证管理助手
/// </summary>
internal sealed class AuthenticationHelper : EMQXConnectorAbstract, IAuthenticationHelper
{
    /// <summary>
    /// 全局认证管理助手
    /// </summary>
    /// <param name="options">选项参数</param>
    internal AuthenticationHelper(EMQXManagementOptions options)
        : base(options) { }


    #region 接口实现[IAuthenticationHelper]

    // do something.

    #endregion

}