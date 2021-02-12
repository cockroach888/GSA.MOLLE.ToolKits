﻿//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：MessageType.cs
// 项目名称：文件操作实用工具集
// 创建时间：2014年2月20日15时35分
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;

namespace DawnXZ.FileUtility
{
    /// <summary> 
    /// 日志消息类型枚举
    /// </summary> 
    public enum MessageType
    {
        /// <summary> 
        /// 未知的类型
        /// </summary> 
        Unknown,
        /// <summary> 
        /// 信息类型
        /// </summary> 
        Information,
        /// <summary> 
        /// 警告类型
        /// </summary> 
        Warning,
        /// <summary> 
        /// 错误类型
        /// </summary> 
        Error,
        /// <summary> 
        /// 成功类型
        /// </summary> 
        Success
    }
}
