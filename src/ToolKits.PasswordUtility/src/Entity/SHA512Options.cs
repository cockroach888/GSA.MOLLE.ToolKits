﻿//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2023 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：SHA512Options.cs
// 项目名称：加解密集约工具集
// 创建时间：2023-02-20 14:30:44
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace GSA.ToolKits.PasswordUtility.Entity;

/// <summary>
/// SHA512选项参数类
/// </summary>
public sealed class SHA512Options : EncryptionOptions
{
    /// <summary>
    /// 是否使用加盐处理 (true 加盐, false 不加盐, 缺省true)
    /// </summary>
    public bool IsUseSalt { get; set; } = true;

    /// <summary>
    /// 加盐在前缀位置还是后缀位置 (true 前缀, false 后缀, 缺省false)
    /// </summary>
    public bool UsePrefixesOrSuffixes { get; set; } = false;

    /// <summary>
    /// 需要加盐的值 (缺省GUID)
    /// </summary>
    public string Salt { get; set; } = Guid.NewGuid().ToString("N");
}