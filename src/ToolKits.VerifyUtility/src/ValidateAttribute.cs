//==================================================================== 
//*****                     晨曦小竹常用工具集                   *****
//====================================================================
//**   Copyright © DawnXZ.com 2014 -- QQ：6808240 -- 请保留此注释   **
//====================================================================
// 文件名称：ValidateAttribute.cs
// 项目名称：数据校验实用工具集
// 创建时间：2014-03-24 14:49:09
// 创建人员：宋杰军
// 负 责 人：宋杰军
// 参与人员：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;

namespace DawnXZ.VerifyUtility
{
    /// <summary>
    /// 为元素添加验证信息的特性类
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class ValidateAttribute : Attribute
    {
        /// <summary>
        /// 验证类型
        /// </summary>
        public ValidateType ValidateType { get; private set; }
        /// <summary>
        /// 最小长度
        /// </summary>
        public int MinLength { get; set; }
        /// <summary>
        /// 最大长度
        /// </summary>
        public int MaxLength { get; set; }
        /// <summary>
        /// 自定义数据源
        /// </summary>
        public string[] CustomArray { get; set; }
        /// <summary>
        /// 指定采取何种验证方式来验证元素的有效性
        /// </summary>
        /// <param name="validateType">验证类型</param>
        public ValidateAttribute(ValidateType validateType)
        {
            ValidateType = validateType;
        }
    }
}
