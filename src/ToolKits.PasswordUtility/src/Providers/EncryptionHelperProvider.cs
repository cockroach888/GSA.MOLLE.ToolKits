//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：EncryptionHelperProvider.cs
// 项目名称：加解密集约工具集
// 创建时间：2023-06-03 15:27:11
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
/// 加密集约助手提供者
/// </summary>
public sealed class EncryptionHelperProvider
{

    #region 单例模式

    private static readonly Lazy<EncryptionHelperProvider> _lazyInstance = new(() => new EncryptionHelperProvider());

    /// <summary>
    /// 加解密集约助手提供者
    /// </summary>
    public static EncryptionHelperProvider Default => _lazyInstance.Value;

    #endregion


    private readonly Dictionary<EncryptionType, IEncryptionHelper> _helpers = new();


    /// <summary>
    /// 加解密集约助手提供者
    /// </summary>
    public EncryptionHelperProvider()
    {
        _helpers[EncryptionType.SHA512] = new SHA512Helper();
    }


    /// <summary>
    /// 执行
    /// </summary>
    /// <param name="type">加密类型</param>
    /// <param name="options">选项参数</param>
    /// <returns>加密结果</returns>
    public async Task<string> ExecuteAsync(EncryptionType type, EncryptionOptions options)
    {
        if (!_helpers.ContainsKey(type))
        {
            throw new InvalidOperationException("对不起！您使用的加密类型暂未支持，敬请期待！为此带来的不便，深表歉意！");
        }

        if (string.IsNullOrWhiteSpace(options.SourceString))
        {
            throw new ArgumentNullException(nameof(options.SourceString), "对不起！需要加密的源字符串不能为空。");
        }

        return await _helpers[type].EncryptionAsync(options).ConfigureAwait(false);
    }
}