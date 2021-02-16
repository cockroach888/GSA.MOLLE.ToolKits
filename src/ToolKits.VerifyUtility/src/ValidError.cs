//==================================================================== 
//*****                    晨曦小竹常用工具集                    *****
//====================================================================
//**   Copyright © DawnXZ.com 2014 -- QQ：6808240 -- 请保留此注释   **
//====================================================================
// 文件名称：ValidError.cs
// 项目名称：数据校验实用工具集
// 创建时间：2014年2月21日15时53分
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
    /// 数据校验错误信息
    /// </summary>
    public class ValidError
    {
        /// <summary>
        /// 下拉框数据选择
        /// </summary>
        public const string Selector = "对不起！您选择的内容已存在";

        #region 电子邮件

        /// <summary>
        /// 判断字符串是否符合Email格式
        /// </summary>
        public const string IsEmail = "对不起！电子邮箱已被使用";
        /// <summary>
        /// 判断字符串是否符合Email格式
        /// </summary>
        public const string IsEmailValid = "对不起！电子邮箱已被使用";

        #endregion

        #region 中文·汉字

        /// <summary>
        /// 判断字符串是否为真实姓名
        /// <para>不低于2个汉字且不大于4个汉字</para>
        /// </summary>
        public const string ChsIsTname = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由中文组成
        /// </summary>
        public const string ChsIsChinese = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由中文、英文、数字组成
        /// </summary>
        public const string ChsIsChineseOrEngOrNum = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由中文、英文、数字组成
        /// <para>中文或英文开头</para>
        /// </summary>
        public const string ChsIsChineseOrEngOrNums = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由中文、字母、数字组成
        /// <para>可含标点符号()[]（）</para>
        /// </summary>
        public const string ChsIsText = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由中文、字母、数字组成
        /// <para>可含标点符号()[]（）</para>
        /// <para>中文或英文开头</para>
        /// </summary>
        public const string ChsIsTexts = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由中文、字母、数字组成
        /// <para>可含标点符号()[]（）：:、，,。.；;！!……</para>
        /// <para>含换行符及回车符</para>
        /// </summary>
        public const string ChsIsMemo = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由中文、字母、数字组成
        /// <para>可含标点符号()[]（）：:、，,。.；;！!……</para>
        /// <para>含换行符及回车符</para>
        /// <para>中文或英文开头</para>
        /// </summary>
        public const string ChsIsMemos = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由中文、字母、数字组成
        /// <para>可含标点符号()[-]（、）</para>
        /// <para>中文或英文开头</para>
        /// </summary>
        public const string ChsIsAddress = "对不起！您输入的内容已存在";

        #endregion

        #region 英文字母

        /// <summary>
        /// 判断字符串是否符合密码规范
        /// <para>任意字符</para>
        /// <para>长度：6-16 [区分大小写]</para>
        /// </summary>
        public const string EngIsPwd = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否符合密码规范
        /// <para>任意字符</para>
        /// <para>长度：6-16 [区分大小写]</para>
        /// <para>英文开头</para>
        /// </summary>
        public const string EngIsPassword = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否符合密码规范
        /// <para>由英文和数字及下划线组成</para>
        /// <para>长度：6-16 [区分大小写]</para>
        /// <para>英文开头</para>
        /// </summary>
        public const string EngIsPasswords = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由英文和数字组成
        /// <para>用于检测注册帐号是否符合规范用</para>
        /// <para>长度：4-8 [不区分大小写]</para>
        /// <para>英文开头</para>
        /// </summary>
        public const string EngIsRegister = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由英文和数字组成
        /// <para>用于检测注册帐号是否符合规范用</para>
        /// <para>长度：4-16 [不区分大小写]</para>
        /// <para>英文开头</para>
        /// </summary>
        public const string EngIsRegisters = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由26个英文字母组成
        /// <para>不区分大小写</para>
        /// </summary>
        public const string EngIsEnglish = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由26个英文字母组成
        /// <para>大写</para>
        /// </summary>
        public const string EngIsUppercase = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由26个英文字母组成
        /// <para>小写</para>
        /// </summary>
        public const string EngIsLowercase = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由26个英文和数字组成
        /// </summary>
        public const string EngIsEngAndNum = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由26个英文和数字组成
        /// <para>英文开头</para>
        /// </summary>
        public const string EngIsEngAndNums = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由26个英文、数字及逗号组成
        /// <para>英文开头</para>
        /// </summary>
        public const string EngIsEngAndNumComma = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否由26个英文和数字及下划线组成
        /// </summary>
        public const string EngIsEngAndNumOrUnderline = "对不起！您输入的内容已存在";

        #endregion

        #region 数字验证

        /// <summary>
        /// 判断对象是否为0-255数据
        /// </summary>
        public const string NumIsByteTinyint = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断对象是否由数字组成
        /// </summary>
        public const string NumIsInteger = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断对象是否为零和非零开头的数字
        /// </summary>
        public const string NumIsZeroOrNot = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断对象是否为2位小数的正实数
        /// </summary>
        public const string NumIsPlus2Point = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断对象是否为1至3位小数的正实数
        /// </summary>
        public const string NumIsPlus3Point = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断对象是否为非零的正整数
        /// </summary>
        public const string NumIsIntegralBySignless = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断对象是否为非零的负整数
        /// </summary>
        public const string NumIsIntegralByNegative = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断对象是否为正浮点数
        /// </summary>
        public const string NumIsFloatBySignless = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断对象是否为负浮点数
        /// </summary>
        public const string NumIsFloatByNegative = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断对象是否为Double类型
        /// </summary>
        public const string NumIsDouble = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断对象是否为Double类型
        /// <para>包含正负号</para>
        /// </summary>
        public const string NumIsDoubles = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断对象是否为Money类型
        /// </summary>
        public const string NumIsMoney = "对不起！您输入的内容已存在";

        #endregion

        #region 电话号码

        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>包含电话号码与手机号码共同验证</para>
        /// </summary>
        public const string TelIsPhone = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>
        /// 座机号码，格式：010-12345678、020-1234567、0755-1234567、0755-12345678、1234567、12345678
        /// </para>
        /// </summary>
        public const string TelIsTelephone = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>中国电信、中国移动、中国联通共同验证</para>
        /// </summary>
        public const string TelIsMobile = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>
        /// 手机号码·中国移动【134 135 136 137 138 139 147 150 151 152 157 158 159 182 187 188】
        /// </para>
        /// </summary>
        public const string TelIsChinaMobile = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>
        /// 手机号码·中国联通【130 131 132 145 155 156 185 186】
        /// </para>
        /// </summary>
        public const string TelIsChinaUnicom = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>
        /// 手机号码·中国电信 【133 153 180 189】
        /// </para>
        /// </summary>
        public const string TelIsChinaTelecom = "对不起！您输入的内容已存在";

        #endregion

        #region IP 验证

        /// <summary>
        /// 判断字符串是否为正确的IP地址格式
        /// </summary>
        public const string IsIP = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否为正确的IP地址格式
        /// </summary>
        public const string IsIPs = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否为正确的IP地址格式
        /// </summary>
        public const string IsIPSect = "对不起！您输入的内容已存在";

        #endregion

        #region 常规检测

        /// <summary>
        /// 判断字符串是否符合大陆身份证规范
        /// </summary>
        public const string IsIDCard = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否存在用于链接的危险字符
        /// </summary>
        public const string IsSafeString = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否为正确的URL地址格式
        /// </summary>
        public const string IsURL = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否符合邮政编码格式
        /// </summary>
        public const string IsPost = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否符合日期格式
        /// </summary>
        public const string IsDate = "对不起！您输入的内容已存在";
        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        public const string IsEmpty = "对不起！您输入的内容已存在";

        #endregion

    }
}
