//=========================================================================
//**   魂哥常用工具集（CRS.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：InternalTypeHelper.cs
// 项目名称：魂哥常用工具集
// 创建时间：2022-10-20 11:27:37
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Text.RegularExpressions;

namespace GSA.ToolKits.CommonUtility;

/// <summary>
/// 内部的数据类型转换助手类
/// </summary>
internal static class InternalTypeHelper
{
    /// <summary>
    /// 将对象转换为 Int64 (long) 类型
    /// </summary>
    /// <remarks>范围：-9,223,372,036,854,775,808 — 9,223,372,036,854,775,807</remarks>
    /// <param name="strValue">要转换的字符串值</param>
    /// <param name="defValue">缺省值</param>
    /// <returns>转换结果数值</returns>
    public static long TypeToInt64(string? strValue, long defValue)
    {
        if (string.IsNullOrWhiteSpace(strValue) ||
            strValue is null ||
            strValue.Trim().Length > 20 ||
            Regex.IsMatch(strValue.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$") is false)
        {
            return defValue;
        }

        if (long.TryParse(strValue, out long value))
        {
            return value;
        }

        try
        {
            return Convert.ToInt64(strValue);
        }
        catch
        {
            return defValue;
        }
    }
}