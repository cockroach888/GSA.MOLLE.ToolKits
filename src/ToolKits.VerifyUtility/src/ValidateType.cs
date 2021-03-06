﻿//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：ValidateType.cs
// 项目名称：数据校验实用工具集
// 创建时间：2014-03-24 14:47:31
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;

namespace GSA.ToolKits.VerifyUtility
{
    /// <summary>
    /// 验证类型
    /// </summary>
    [Flags]
    public enum ValidateType
    {
        /// <summary>
        /// 字段或属性是否为空字串
        /// </summary>
        IsEmpty = 0x0001,
        /// <summary>
        /// 字段或属性的最小长度
        /// </summary>
        MinLength = 0x0002,
        /// <summary>
        /// 字段或属性的最大长度
        /// </summary>
        MaxLength = 0x0004,
        /// <summary>
        /// 字段或属性的值是否为数值型
        /// </summary>
        IsNumber = 0x0008,
        /// <summary>
        /// 字段或属性的值是否为时间类型
        /// </summary>
        IsDateTime = 0x0010,
        /// <summary>
        /// 字段或属性的值是否为正确的浮点类型
        /// </summary>
        IsDecimal = 0x0020,
        /// <summary>
        /// 字段或属性的值是否包含在指定的数据源数组中
        /// </summary>
        IsInCustomArray = 0x0040,
        /// <summary>
        /// 字段或属性的值是否为固定电话号码格式
        /// </summary>
        IsTelphone = 0x0080,
        /// <summary>
        /// 字段或属性的值是否为手机号码格式
        /// </summary>
        IsMobile = 0x0100
    }
}
