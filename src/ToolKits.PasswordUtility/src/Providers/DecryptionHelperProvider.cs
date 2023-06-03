//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：DecryptionHelperProvider.cs
// 项目名称：加解密集约工具集
// 创建时间：2023-06-03 15:16:36
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.PasswordUtility;

/// <summary>
/// 解密集约助手提供者
/// </summary>
public sealed class DecryptionHelperProvider
{

    #region 单例模式

    private static readonly Lazy<DecryptionHelperProvider> _lazyInstance = new(() => new DecryptionHelperProvider());

    /// <summary>
    /// 加解密集约助手提供者
    /// </summary>
    public static DecryptionHelperProvider Default => _lazyInstance.Value;

    #endregion


    //private readonly Dictionary<PasswordType, IPasswordHelper> _helpers = new();


    /// <summary>
    /// 加解密集约助手提供者
    /// </summary>
    public DecryptionHelperProvider()
    {
        // do something.
    }
}