//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：AttributeHandle.cs
// 项目名称：数据校验实用工具集
// 创建时间：2014-03-24 14:53:28
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Reflection;
using System.Text.RegularExpressions;

namespace GSA.ToolKits.VerifyUtility
{
    /// <summary>
    /// 实体对象数据验证处理器
    /// <para>使用方法：</para>
    /// <para>string checkMessage = AttributeHandle.GetValidateResult(objectModel);</para>
    /// <para>if(!string.IsNullOrEmpty(checkMessage)) return checkMessage;</para>
    /// </summary>
    public static class AttributeHandle
    {
        /// <summary>
        /// 验证实体对象的所有带验证特性的元素  并返回验证结果  如果返回结果为String.Empty 则说明元素符合验证要求
        /// </summary>
        /// <param name="entityObject">实体对象</param>
        /// <returns></returns>
        public static string GetValidateResult(object entityObject)
        {
#if NET8_0_OR_GREATER
            ArgumentNullException.ThrowIfNull("需要验证的实体对象不能为空！");

#else
            if (entityObject is null)
            {
                throw new ArgumentNullException("需要验证的实体对象不能为空！");
            }
#endif

            Type type = entityObject.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                //获取验证特性
                object[] validateContent = property.GetCustomAttributes(typeof(ValidateAttribute), true);

                if (validateContent is not null &&
                    validateContent.Length != 0)
                {
                    //获取属性的值
                    object? value = property.GetValue(entityObject, null);

                    if (value is null ||
                        string.IsNullOrWhiteSpace(value.ToString()) is true)
                    {
                        return $"需要验证的属性“{property.Name}”不能为空！";
                    }

                    string validateValue = $"{value}";

                    foreach (ValidateAttribute validateAttr in validateContent.Cast<ValidateAttribute>())
                    {
                        switch (validateAttr.ValidateType)
                        {
                            //验证元素的长度是否小于指定最小长度
                            case ValidateType.MinLength:
                                if (validateValue.Length < validateAttr.MinLength)
                                {
                                    return $"属性“{property.Name}”的长度不能小于“{validateAttr.MinLength}”。";
                                }
                                break;
                            //验证元素的长度是否大于指定最大长度
                            case ValidateType.MaxLength:
                                if (validateValue.Length > validateAttr.MaxLength)
                                {
                                    return $"属性“{property.Name}”的长度不能大于“{validateAttr.MaxLength}”。";
                                }
                                break;
                            //验证元素的长度是否符合指定的最大长度和最小长度的范围
                            case ValidateType.MinLength | ValidateType.MaxLength:
                                if (null == value || value.ToString().Length < 1)
                                    break;
                                if (value.ToString().Length > validateAttr.MaxLength
                                    || value.ToString().Length < validateAttr.MinLength)
                                    validateResult = string.Format(
                                        "元素 {0} 不符合指定的最小长度和最大长度的范围,应该在 {1} 与 {2} 之间",
                                        property.Name,
                                        validateAttr.MinLength,
                                        validateAttr.MaxLength);
                                break;
                            //验证元素的值是否为值类型
                            case ValidateType.IsNumber:
                                if (null == value || value.ToString().Length < 1)
                                    break;
                                if (!Regex.IsMatch(value.ToString(), @"^\d+$"))
                                    validateResult = string.Format("元素 {0} 的值不是值类型",
                                        property.Name);
                                break;
                            //验证元素的值是否为正确的时间格式
                            case ValidateType.IsDateTime:
                                if (null == value || value.ToString().Length < 1)
                                    break;
                                if (!Regex.IsMatch(value.ToString(), @"(\d{2,4})[-/]?([0]?[1-9]|[1][12])[-/]?([0][1-9]|[12]\d|[3][01])\s*([01]\d|[2][0-4])?[:]?([012345]?\d)?[:]?([012345]?\d)?"))
                                    validateResult = string.Format("元素 {0} 不是正确的时间格式",
                                        property.Name);
                                break;
                            //验证元素的值是否为正确的浮点格式
                            case ValidateType.IsDecimal:
                                if (null == value || value.ToString().Length < 1)
                                    break;
                                if (!Regex.IsMatch(value.ToString(), @"^\d+[.]?\d+$"))
                                    validateResult = string.Format("元素 {0} 不是正确的金额格式",
                                        property.Name);
                                break;
                            //验证元素的值是否在指定的数据源中
                            case ValidateType.IsInCustomArray:
                                if (null == value || value.ToString().Length < 1)
                                    break;
                                if (null == validateAttr.CustomArray
                                    || validateAttr.CustomArray.Length < 1)
                                    validateResult = string.Format(
                                        "系统内部错误：元素 {0} 指定的数据源为空或没有数据",
                                        property.Name);

                                bool isHas = Array.Exists<string>(
                                    validateAttr.CustomArray, delegate (string str)
                                    {
                                        return str == value.ToString();
                                    }
                                );

                                if (!isHas)
                                    validateResult = string.Format(
                                        "元素 {0} 的值设定不正确 , 应该为 {1} 中的一种",
                                        property.Name,
                                        string.Join(",", validateAttr.CustomArray));
                                break;
                            //验证元素的值是否为固定电话号码格式
                            case ValidateType.IsTelphone:
                                if (null == value || value.ToString().Length < 1)
                                    break;
                                if (!Regex.IsMatch(value.ToString(), @"^(\d{3,4}-)?\d{6,8}$"))
                                    validateResult = string.Format(
                                        "元素 {0} 不是正确的固定电话号码格式",
                                        property.Name);
                                break;
                            //验证元素的值是否为手机号码格式
                            case ValidateType.IsMobile:
                                if (null == value || value.ToString().Length < 1)
                                    break;
                                if (!Regex.IsMatch(value.ToString(), @"^[1]+[3,5]+\d{9}$"))
                                    validateResult = string.Format(
                                        "元素 {0} 不是正确的手机号码格式", property.Name);
                                break;

                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(validateResult) is false)
                {
                    break;
                }
            }

            return validateResult;
        }
    }
}
