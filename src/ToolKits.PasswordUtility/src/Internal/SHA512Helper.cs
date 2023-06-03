//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：SHA512Helper.cs
// 项目名称：加解密集约工具集
// 创建时间：2023-02-20 14:31:32
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Security.Cryptography;
using System.Text;

namespace GSA.ToolKits.PasswordUtility.Internal;

/// <summary>
/// SHA512助手类
/// </summary>
internal sealed class SHA512Helper : IEncryptionHelper
{

    #region 接口实现[IEncryptionHelper]

    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="options">选项参数</param>
    /// <returns>加密后的字符串</returns>
    public async Task<string?> EncryptionAsync(EncryptionOptions options)
    {
        await Task.Delay(0).ConfigureAwait(false);

        if (options is not SHA512Options opts ||
            string.IsNullOrWhiteSpace(opts.SourceString))
        {
            return default;
        }

        string source = opts.SourceString;

        if (opts.IsUseSalt &&
            !string.IsNullOrWhiteSpace(opts.Salt))
        {
            if (opts.UsePrefixesOrSuffixes)
            {
                source = $"{opts.Salt}{opts.SourceString}";
            }
            else
            {
                source = $"{opts.SourceString}{opts.Salt}";
            }
        }


        SHA512 sha512 = SHA512.Create();
        byte[] buffer = sha512.ComputeHash(Encoding.UTF8.GetBytes(source));
        return BitConverter.ToString(buffer).Replace("-", string.Empty).ToLower();
    }

    #endregion

}