//==================================================================== 
//*****                    晨曦小竹常用工具集                    *****
//====================================================================
//**   Copyright © DawnXZ.com 2014 -- QQ：6808240 -- 请保留此注释   **
//====================================================================
// 文件名称：ValidTips.cs
// 项目名称：数据校验实用工具集
// 创建时间：2014年2月21日15时56分
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
    /// 数据校验提示信息
    /// </summary>
    public class ValidTips
    {
        /// <summary>
        /// 下拉框数据选择
        /// </summary>
        public const string Selector = "请从下拉框选择";

        #region 电子邮件

        /// <summary>
        /// 判断字符串是否符合Email格式
        /// </summary>
        public const string IsEmail = "请输入常用电子邮箱";
        /// <summary>
        /// 判断字符串是否符合Email格式
        /// </summary>
        public const string IsEmailValid = "请输入常用电子邮箱";

        #endregion

        #region 中文·汉字

        /// <summary>
        /// 判断字符串是否为真实姓名
        /// <para>不低于2个汉字且不大于8个汉字</para>
        /// </summary>
        public const string ChsIsTname = "请输入真实姓名，2-8个汉字";
        /// <summary>
        /// 判断字符串是否由中文组成
        /// </summary>
        public const string ChsIsChinese = "请输入中文，简体中文";
        /// <summary>
        /// 判断字符串是否由中文、英文、数字组成
        /// </summary>
        public const string ChsIsChineseOrEngOrNum = "请输入中文、英文、数字";
        /// <summary>
        /// 判断字符串是否由中文、英文、数字组成
        /// <para>中文或英文开头</para>
        /// </summary>
        public const string ChsIsChineseOrEngOrNums = "请输入中文、英文、数字，中文或英文开头";
        /// <summary>
        /// 判断字符串是否由中文、字母、数字组成
        /// <para>可含标点符号()[]（）</para>
        /// </summary>
        public const string ChsIsText = "请输入中文、英文、数字，符号：《》()[]（）";
        /// <summary>
        /// 判断字符串是否由中文、字母、数字组成
        /// <para>可含标点符号()[]（）</para>
        /// <para>中文或英文开头</para>
        /// </summary>
        public const string ChsIsTexts = "请输入中文、英文、数字，符号：《》()[]（），中文或英文开头";
        /// <summary>
        /// 判断字符串是否由中文、字母、数字组成
        /// <para>可含标点符号()[]（）：:、，,。.；;！!……</para>
        /// <para>含换行符及回车符</para>
        /// </summary>
        public const string ChsIsMemo = "请输入中文、英文、数字，符号：《》()[]（）：:、，,。.；;！!……";
        /// <summary>
        /// 判断字符串是否由中文、字母、数字组成
        /// <para>可含标点符号()[]（）：:、，,。.；;！!……</para>
        /// <para>含换行符及回车符</para>
        /// <para>中文或英文开头</para>
        /// </summary>
        public const string ChsIsMemos = "请输入中文、英文、数字，符号：《》()[]（）：:、，,。.；;！!……，中文或英文开头";
        /// <summary>
        /// 判断字符串是否由中文、字母、数字组成
        /// <para>可含标点符号()[-]（、）</para>
        /// <para>中文或英文开头</para>
        /// </summary>
        public const string ChsIsAddress = "请输入中文、英文、数字，符号：《》()[-]（、）";

        #endregion

        #region 英文字母

        /// <summary>
        /// 判断字符串是否符合密码规范
        /// <para>任意字符</para>
        /// <para>长度：6-16 [区分大小写]</para>
        /// </summary>
        public const string EngIsPwd = "请输入由任意字符组成的密码，长度：6-16 [区分大小写]";
        /// <summary>
        /// 判断字符串是否符合密码规范
        /// <para>任意字符</para>
        /// <para>长度：6-16 [区分大小写]</para>
        /// <para>英文开头</para>
        /// </summary>
        public const string EngIsPassword = "请输入由任意字符组成的密码，长度：6-16 [区分大小写]，英文开头";
        /// <summary>
        /// 判断字符串是否符合密码规范
        /// <para>由英文和数字及下划线组成</para>
        /// <para>长度：6-16 [区分大小写]</para>
        /// <para>英文开头</para>
        /// </summary>
        public const string EngIsPasswords = "请输入由英文和数字及下划线组成的密码，长度：6-16 [区分大小写]，英文开头";
        /// <summary>
        /// 判断字符串是否由英文和数字组成
        /// <para>用于检测注册帐号是否符合规范用</para>
        /// <para>长度：4-8 [不区分大小写]</para>
        /// <para>英文开头</para>
        /// </summary>
        public const string EngIsRegister = "请输入由英文和数字组成的注册帐号，长度：4-8 [不区分大小写]，英文开头";
        /// <summary>
        /// 判断字符串是否由英文和数字组成
        /// <para>用于检测注册帐号是否符合规范用</para>
        /// <para>长度：4-16 [不区分大小写]</para>
        /// <para>英文开头</para>
        /// </summary>
        public const string EngIsRegisters = "请输入由英文和数字组成的注册帐号，长度：4-16 [不区分大小写]，英文开头";
        /// <summary>
        /// 判断字符串是否由26个英文字母组成
        /// <para>不区分大小写</para>
        /// </summary>
        public const string EngIsEnglish = "请输入由26个英文字母组成的数据，不区分大小写";
        /// <summary>
        /// 判断字符串是否由26个英文字母组成
        /// <para>大写</para>
        /// </summary>
        public const string EngIsUppercase = "请输入由26个英文大写字母组成的数据";
        /// <summary>
        /// 判断字符串是否由26个英文字母组成
        /// <para>小写</para>
        /// </summary>
        public const string EngIsLowercase = "请输入由26个英文小写字母组成的数据";
        /// <summary>
        /// 判断字符串是否由26个英文和数字组成
        /// </summary>
        public const string EngIsEngAndNum = "请输入由26个英文和数字组成的数据";
        /// <summary>
        /// 判断字符串是否由26个英文和数字组成
        /// <para>英文开头</para>
        /// </summary>
        public const string EngIsEngAndNums = "请输入由26个英文和数字组成的数据，英文开头";
        /// <summary>
        /// 判断字符串是否由26个英文、数字及逗号组成
        /// <para>英文开头</para>
        /// </summary>
        public const string EngIsEngAndNumComma = "请输入由26个英文和数字及逗号组成的数据，英文开头";
        /// <summary>
        /// 判断字符串是否由26个英文和数字及下划线组成
        /// </summary>
        public const string EngIsEngAndNumOrUnderline = "请输入由26个英文和数字及下划线组成的数据";

        #endregion

        #region 数字验证

        /// <summary>
        /// 判断对象是否为0-255数据
        /// </summary>
        public const string NumIsByteTinyint = "请输入由0-255组成的整数";
        /// <summary>
        /// 判断对象是否由数字组成
        /// </summary>
        public const string NumIsInteger = "请输入由数字组成的数据，0-9";
        /// <summary>
        /// 判断对象是否为零和非零开头的数字
        /// </summary>
        public const string NumIsZeroOrNot = "请输入由零或非零开头组成的数字";
        /// <summary>
        /// 判断对象是否为2位小数的正实数
        /// </summary>
        public const string NumIsPlus2Point = "请输入由2位小数组成的正实数";
        /// <summary>
        /// 判断对象是否为1至3位小数的正实数
        /// </summary>
        public const string NumIsPlus3Point = "请输入由1至3位小数组成的正实数";
        /// <summary>
        /// 判断对象是否为非零的正整数
        /// </summary>
        public const string NumIsIntegralBySignless = "请输入为非零的正整数";
        /// <summary>
        /// 判断对象是否为非零的负整数
        /// </summary>
        public const string NumIsIntegralByNegative = "请输入为非零的负整数";
        /// <summary>
        /// 判断对象是否为正浮点数
        /// </summary>
        public const string NumIsFloatBySignless = "请输入为正浮点数的数据";
        /// <summary>
        /// 判断对象是否为负浮点数
        /// </summary>
        public const string NumIsFloatByNegative = "请输入为负浮点数的数据";
        /// <summary>
        /// 判断对象是否为Double类型
        /// </summary>
        public const string NumIsDouble = "请输入为双精度类型的数据";
        /// <summary>
        /// 判断对象是否为Double类型
        /// <para>包含正负号</para>
        /// </summary>
        public const string NumIsDoubles = "请输入为双精度类型的数据，包含正负号";
        /// <summary>
        /// 判断对象是否为Money类型
        /// </summary>
        public const string NumIsMoney = "请输入为Money类型的数据";

        #endregion

        #region 电话号码

        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>包含电话号码与手机号码共同验证</para>
        /// </summary>
        public const string TelIsPhone = "请输入联系电话，座机或手机，座机用“-”隔开";
        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>
        /// 座机号码，格式：010-12345678、020-1234567、0755-1234567、0755-12345678、1234567、12345678
        /// </para>
        /// </summary>
        public const string TelIsTelephone = "请输入符合电话号码格式的数据，010-88888888，区号3-4位，号码7-8位";
        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>中国电信、中国移动、中国联通共同验证</para>
        /// </summary>
        public const string TelIsMobile = "请输入符合手机号码格式的数据";
        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>
        /// 手机号码·中国移动【134 135 136 137 138 139 147 150 151 152 157 158 159 182 187 188】
        /// </para>
        /// </summary>
        public const string TelIsChinaMobile = "请输入符合中国移动的手机号码格式的数据";
        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>
        /// 手机号码·中国联通【130 131 132 145 155 156 185 186】
        /// </para>
        /// </summary>
        public const string TelIsChinaUnicom = "请输入符合中国联通的手机号码格式的数据";
        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>
        /// 手机号码·中国电信 【133 153 180 189】
        /// </para>
        /// </summary>
        public const string TelIsChinaTelecom = "请输入符合中国电信的手机号码格式的数据";

        #endregion

        #region IP 验证

        /// <summary>
        /// 判断字符串是否为正确的IP地址格式
        /// </summary>
        public const string IsIP = "请输入IP地址格式的数据";
        /// <summary>
        /// 判断字符串是否为正确的IP地址格式
        /// </summary>
        public const string IsIPs = "请输入IP地址格式的数据";
        /// <summary>
        /// 判断字符串是否为正确的IP地址格式
        /// </summary>
        public const string IsIPSect = "请输入IP地址格式的数据";

        #endregion

        #region 常规检测

        /// <summary>
        /// 判断字符串是否符合大陆身份证规范
        /// </summary>
        public const string IsIDCard = "请输入符合中国公民身份证规范的数据";
        /// <summary>
        /// 判断字符串是否存在用于链接的危险字符
        /// </summary>
        public const string IsSafeString = "请输入符合安全标准的数据";
        /// <summary>
        /// 判断字符串是否为正确的URL地址格式
        /// </summary>
        public const string IsURL = "请输入正确的URL地址格式数据";
        /// <summary>
        /// 判断字符串是否符合邮政编码格式
        /// </summary>
        public const string IsPost = "请输入符合邮政编码格式的数据";
        /// <summary>
        /// 判断字符串是否符合日期格式
        /// </summary>
        public const string IsDate = "请输入符合日期格式标准的数据，例：2012-12-21";
        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        public const string IsEmpty = "请输入相应的内容";

        #endregion

    }
}
