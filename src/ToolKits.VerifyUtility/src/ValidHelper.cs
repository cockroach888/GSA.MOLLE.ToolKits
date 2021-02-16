//==================================================================== 
//*****                    晨曦小竹常用工具集                    *****
//====================================================================
//**   Copyright © DawnXZ.com 2014 -- QQ：6808240 -- 请保留此注释   **
//====================================================================
// 文件名称：ValidHelper.cs
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
using System.Text.RegularExpressions;

namespace DawnXZ.VerifyUtility
{
    /// <summary>
    /// 数据校验操作辅助类
    /// </summary>
    public static class ValidHelper
    {

        #region 电子邮件

        /// <summary>
        /// 判断字符串是否符合Email格式
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，符合/不符合</returns>
        public static bool IsEmail(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        /// <summary>
        /// 判断字符串是否符合Email格式
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，符合/不符合</returns>
        public static bool IsEmailValid(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.(([0-9]{1,3})|([a-zA-Z]{2,4})|(aero|coop|info|museum|name))$");
        }

        #endregion

        #region 中文·汉字

        /// <summary>
        /// 判断字符串是否为真实姓名
        /// <para>不低于2个汉字且不大于8个汉字</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool ChsIsTname(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, "^[\u4E00-\u9FA5]{2,8}$");
        }
        /// <summary>
        /// 判断字符串是否由中文组成
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool ChsIsChinese(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^[\u4E00-\u9FA5]+$");
        }
        /// <summary>
        /// 判断字符串是否由中文、英文、数字组成
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool ChsIsChineseOrEngOrNum(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^[a-zA-Z0-9\u4E00-\u9FA5]+$");
        }
        /// <summary>
        /// 判断字符串是否由中文、英文、数字组成
        /// <para>中文或英文开头</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool ChsIsChineseOrEngOrNums(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^[a-zA-Z\u4e00-\u9fa5]+([a-zA-Z0-9\u4E00-\u9FA5]{0,}$)");
        }
        /// <summary>
        /// 判断字符串是否由中文、字母、数字组成
        /// <para>可含标点符号()[]（）</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool ChsIsText(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, "^[0-9a-zA-Z\u4E00-\u9FA5()\\[\\]（）《》]+$");
        }
        /// <summary>
        /// 判断字符串是否由中文、字母、数字组成
        /// <para>可含标点符号()[]（）</para>
        /// <para>中文或英文开头</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool ChsIsTexts(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, "^[a-zA-Z\u4E00-\u9FA5]+([0-9a-zA-Z\u4E00-\u9FA5()\\[\\]（）《》]{0,}$)");
        }
        /// <summary>
        /// 判断字符串是否由中文、字母、数字组成
        /// <para>可含标点符号()[]（）：:、，,。.；;！!……</para>
        /// <para>含换行符及回车符</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool ChsIsMemo(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, "^[0-9a-zA-Z\u4E00-\u9FA5()\\[\\]（）《》：:、，,。.；;！!……\n\r]+$");
        }
        /// <summary>
        /// 判断字符串是否由中文、字母、数字组成
        /// <para>可含标点符号()[]（）：:、，,。.；;！!……</para>
        /// <para>含换行符及回车符</para>
        /// <para>中文或英文开头</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool ChsIsMemos(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, "^[a-zA-Z\u4E00-\u9FA5]+([0-9a-zA-Z\u4E00-\u9FA5()\\[\\]（）《》：:、，,。.；;！!……\n\r]{0,}$)");
        }
        /// <summary>
        /// 判断字符串是否由中文、字母、数字组成
        /// <para>可含标点符号()[-]（、）</para>
        /// <para>中文或英文开头</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool ChsIsAddress(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, "^[a-zA-Z\u4E00-\u9FA5]+([0-9a-zA-Z\u4E00-\u9FA5()\\[\\-\\]（、）《》]{0,}$)");
        }
        /// <summary>
        /// 全角转半角的函数(DBC case)
        /// </summary>
        /// <param name="strChange">需要转换的字符串</param>
        /// <returns>半角字符串</returns>
        /// <remarks>
        /// 全角空格为12288，半角空格为32
        /// 其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        /// </remarks>
        public static string ChsToDBC(string strChange)
        {
            if (string.IsNullOrEmpty(strChange)) return null;
            char[] c = strChange.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        #endregion

        #region 英文字母

        /// <summary>
        /// 判断字符串是否符合密码规范
        /// <para>任意字符</para>
        /// <para>长度：6-16 [区分大小写]</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool EngIsPwd(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"(.){6,16}$");
        }
        /// <summary>
        /// 判断字符串是否符合密码规范
        /// <para>任意字符</para>
        /// <para>长度：6-16 [区分大小写]</para>
        /// <para>英文开头</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool EngIsPassword(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^[a-zA-Z]{1}(.){5,15}$");
        }
        /// <summary>
        /// 判断字符串是否符合密码规范
        /// <para>由英文和数字及下划线组成</para>
        /// <para>长度：6-16 [区分大小写]</para>
        /// <para>英文开头</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool EngIsPasswords(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^[a-zA-Z]{1}(\w){5,15}$");
        }
        /// <summary>
        /// 判断字符串是否由英文和数字组成
        /// <para>用于检测注册帐号是否符合规范用</para>
        /// <para>长度：4-8 [不区分大小写]</para>
        /// <para>英文开头</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool EngIsRegister(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^[a-zA-Z]{1}([a-zA-Z0-9]){3,7}$");
        }
        /// <summary>
        /// 判断字符串是否由英文和数字组成
        /// <para>用于检测注册帐号是否符合规范用</para>
        /// <para>长度：4-16 [不区分大小写]</para>
        /// <para>英文开头</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool EngIsRegisters(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^[a-zA-Z]{1}([a-zA-Z0-9]){3,15}$");
        }
        /// <summary>
        /// 判断字符串是否由26个英文字母组成
        /// <para>不区分大小写</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool EngIsEnglish(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^[A-Za-z]+$");
        }
        /// <summary>
        /// 判断字符串是否由26个英文字母组成
        /// <para>大写</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool EngIsUppercase(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^[A-Z]+$");
        }
        /// <summary>
        /// 判断字符串是否由26个英文字母组成
        /// <para>小写</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool EngIsLowercase(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^[a-z]+$");
        }
        /// <summary>
        /// 判断字符串是否由26个英文和数字组成
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool EngIsEngAndNum(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^[A-Za-z0-9]+$");
        }
        /// <summary>
        /// 判断字符串是否由26个英文和数字组成
        /// <para>英文开头</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool EngIsEngAndNums(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^[a-zA-Z]+([a-zA-Z0-9]{0,}$)");
        }
        /// <summary>
        /// 判断字符串是否由26个英文、数字及逗号组成
        /// <para>英文开头</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool EngIsEngAndNumComma(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^[a-zA-Z]+([0-9a-zA-Z,]{0,}$)");
        }
        /// <summary>
        /// 判断字符串是否由26个英文和数字及下划线组成
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool EngIsEngAndNumOrUnderline(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^\w+$");
        }

        #endregion

        #region 数字验证

        /// <summary>
        /// 判断对象是否为0-255数据
        /// </summary>
        /// <param name="objVerify">需要验证的对象</param>
        /// <returns>True/False，是/否</returns>
        public static bool NumIsByteTinyint(object objVerify)
        {
            if (objVerify == null) return false;
            return Regex.IsMatch(objVerify.ToString(), @"((^[0-9]{1,2})|(^[1][0-9]{1,2})|(^[2][0-5][0-5]))$");
        }
        /// <summary>
        /// 判断对象是否由数字组成
        /// </summary>
        /// <param name="objVerify">需要验证的对象</param>
        /// <returns>True/False，是/否</returns>
        public static bool NumIsInteger(object objVerify)
        {
            if (objVerify == null) return false;
            return Regex.IsMatch(objVerify.ToString(), @"^[-\+]?\d+$");
        }
        /// <summary>
        /// 判断对象是否为零和非零开头的数字
        /// </summary>
        /// <param name="objVerify">需要验证的对象</param>
        /// <returns>True/False，是/否</returns>
        public static bool NumIsZeroOrNot(object objVerify)
        {
            if (objVerify == null) return false;
            return Regex.IsMatch(objVerify.ToString(), @"^(0|[1-9][0-9]*)$");
        }
        /// <summary>
        /// 判断对象是否为2位小数的正实数
        /// </summary>
        /// <param name="objVerify">需要验证的对象</param>
        /// <returns>True/False，是/否</returns>
        public static bool NumIsPlus2Point(object objVerify)
        {
            if (objVerify == null) return false;
            return Regex.IsMatch(objVerify.ToString(), @"^[0-9]+(.[0-9]{2})?$");
        }
        /// <summary>
        /// 判断对象是否为1至3位小数的正实数
        /// </summary>
        /// <param name="objVerify">需要验证的对象</param>
        /// <returns>True/False，是/否</returns>
        public static bool NumIsPlus3Point(object objVerify)
        {
            if (objVerify == null) return false;
            return Regex.IsMatch(objVerify.ToString(), @"^[0-9]+(.[0-9]{1,3})?$");
        }
        /// <summary>
        /// 判断对象是否为非零的正整数
        /// </summary>
        /// <param name="objVerify">需要验证的对象</param>
        /// <returns>True/False，是/否</returns>
        public static bool NumIsIntegralBySignless(object objVerify)
        {
            if (objVerify == null) return false;
            return Regex.IsMatch(objVerify.ToString(), @"^\+?[1-9][0-9]*$");
        }
        /// <summary>
        /// 判断对象是否为非零的负整数
        /// </summary>
        /// <param name="objVerify">需要验证的对象</param>
        /// <returns>True/False，是/否</returns>
        public static bool NumIsIntegralByNegative(object objVerify)
        {
            if (objVerify == null) return false;
            return Regex.IsMatch(objVerify.ToString(), @"^\-[1-9][0-9]*$");
        }
        /// <summary>
        /// 判断对象是否为正浮点数
        /// </summary>
        /// <param name="objVerify">需要验证的对象</param>
        /// <returns>True/False，是/否</returns>
        public static bool NumIsFloatBySignless(object objVerify)
        {
            if (objVerify == null) return false;
            return Regex.IsMatch(objVerify.ToString(), @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$");
        }
        /// <summary>
        /// 判断对象是否为负浮点数
        /// </summary>
        /// <param name="objVerify">需要验证的对象</param>
        /// <returns>True/False，是/否</returns>
        public static bool NumIsFloatByNegative(object objVerify)
        {
            if (objVerify == null) return false;
            return Regex.IsMatch(objVerify.ToString(), @"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$");
        }
        /// <summary>
        /// 判断对象是否为Int32类型
        /// </summary>
        /// <param name="objVerify">需要验证的对象</param>
        /// <returns>True/False，是/否</returns>
        public static bool NumIsNumeric(object objVerify)
        {
            if (objVerify == null) return false;
            string strTmp = objVerify.ToString();
            if (strTmp.Length > 0 && strTmp.Length <= 11 && Regex.IsMatch(strTmp, @"^[-]?[0-9]*[.]?[0-9]*$"))
            {
                if ((strTmp.Length < 10) || (strTmp.Length == 10 && strTmp[0] == '1') || (strTmp.Length == 11 && strTmp[0] == '-' && strTmp[1] == '1'))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 判断对象是否为Double类型
        /// </summary>
        /// <param name="objVerify">需要验证的对象</param>
        /// <returns>True/False，是/否</returns>
        public static bool NumIsDouble(object objVerify)
        {
            if (objVerify == null) return false;
            return Regex.IsMatch(objVerify.ToString(), @"^([0-9])[0-9]*(\.\w*)?$");
        }
        /// <summary>
        /// 判断对象是否为Double类型
        /// <para>包含正负号</para>
        /// </summary>
        /// <param name="objVerify">需要验证的对象</param>
        /// <returns>True/False，是/否</returns>
        public static bool NumIsDoubles(object objVerify)
        {
            if (objVerify == null) return false;
            return Regex.IsMatch(objVerify.ToString(), @"^[-\+]?\d+(\.\d+)?$");
        }
        /// <summary>
        /// 判断对象是否为Money类型
        /// </summary>
        /// <param name="objVerify">需要验证的对象</param>
        /// <returns>True/False，是/否</returns>
        public static bool NumIsMoney(object objVerify)
        {
            if (objVerify == null) return false;
            return Regex.IsMatch(objVerify.ToString(), @"^(([1-9]\d*)|(([0-9]{1}|[1-9]+)\.[0-9]{1,2}))$");
        }
        /// <summary>
        /// 判断字符串数组的值是否全为Int32类型
        /// </summary>
        /// <param name="strVerify">需要验证的字符串数组</param>
        /// <returns>True/False，是/否</returns>
        public static bool NumIsNumericArray(string[] strVerify)
        {
            if (strVerify == null) return false;
            if (strVerify.Length < 1) return false;
            foreach (string strTmp in strVerify)
            {
                if (!NumIsNumeric(strTmp)) return false;
            }
            return true;
        }
        /// <summary>
        /// 判断字符串是否为Int32类型
        /// <remarks>
        /// 字符串分割符默认为半角逗号[,]
        /// </remarks>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool NumIsNumericList(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return NumIsNumericList(strVerify, ',');
        }
        /// <summary>
        /// 判断字符串是否为Int32类型
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <param name="flgSplit">字符串分割符</param>
        /// <returns>True/False，是/否</returns>
        public static bool NumIsNumericList(string strVerify, char flgSplit)
        {
            if (string.IsNullOrEmpty(strVerify) || char.IsWhiteSpace(flgSplit)) return false;
            return NumIsNumericArray(strVerify.Split(flgSplit));
        }

        #endregion

        #region 电话号码

        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>任意电话号码或手机号码</para>
        /// <para>包含Any电话号码与Any手机号码共同验证</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，符合/不符合</returns>
        public static bool TelIsAnyPhone(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            bool result = TelIsTelephoneAny(strVerify);
            if (!result) result = TelIsMobileAny(strVerify);
            return result;
        }
        /// <summary>
        /// 判断字符串是否符合电话号码格式
		/// <para>四种常用判断</para>
        /// <para>包含电话号码与手机号码共同验证</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，符合/不符合</returns>
        public static bool TelIsAllPhone(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            bool result = TelIsTelephone(strVerify);
            if (!result) result = TelIsChinaMobile(strVerify);
            if (!result) result = TelIsChinaUnicom(strVerify);
            if (!result) result = TelIsChinaTelecom(strVerify);
            return result;
        }
        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>电话号码：+000086-1234-12345678-1234</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，符合/不符合</returns>
        public static bool TelIsTelephoneAny(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^(\+([0-9]{1,6})|([0-9]{1,6}))?(\-)?(\d){1,4}?(\-)?(\d){7,8}(\-)?(\d){1,4}?$");
        }
        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>
        /// 座机号码，格式：010-12345678、020-1234567、0755-1234567、0755-12345678、1234567、12345678
        /// </para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，符合/不符合</returns>
        public static bool TelIsTelephone(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$");
        }
        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>中国电信、中国移动、中国联通共同验证</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，符合/不符合</returns>
        public static bool TelIsMobile(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            bool result = TelIsChinaMobile(strVerify);
            if (!result) result = TelIsChinaUnicom(strVerify);
            if (!result) result = TelIsChinaTelecom(strVerify);
            return result;
        }
        /// <summary>
        /// 判断字符串是否符合手机号码格式
        /// <para>1开头，长度等于11位。</para>
        /// <para>11、12、13、14、15、16、17、18、19</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，符合/不符合</returns>
        public static bool TelIsMobileAny(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^(\+([0-9]{1,6})|([0-9]{1,6}))?(11|12|13|14|15|16|17|18|19)\d{9}$");
        }
        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>
        /// 手机号码·中国移动【134 135 136 137 138 139 147 150 151 152 157 158 159 182 187 188】
        /// </para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，符合/不符合</returns>
        public static bool TelIsChinaMobile(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"(^134|^135|^136|^137|^138|^139|^147|^150|^151|^152|^157|^158|^159|^182|^187|^188)[0-9]{8}$");
        }
        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>
        /// 手机号码·中国联通【130 131 132 145 155 156 185 186】
        /// </para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，符合/不符合</returns>
        public static bool TelIsChinaUnicom(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"(^130|^131|^132|^145|^155|^156|^185|^186)[0-9]{8}$");
        }
        /// <summary>
        /// 判断字符串是否符合电话号码格式
        /// <para>
        /// 手机号码·中国电信 【133 153 180 189】
        /// </para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，符合/不符合</returns>
        public static bool TelIsChinaTelecom(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"(^133|^153|^180|^189)[0-9]{8}$");
        }

        #endregion

        #region IP 验证

        /// <summary>
        /// 判断字符串是否为正确的IP地址格式
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool IsIP(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
        /// <summary>
        /// 判断字符串是否为正确的IP地址格式
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool IsIPs(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5])$");
        }
        /// <summary>
        /// 判断字符串是否为正确的IP地址格式
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool IsIPSect(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){2}((2[0-4]\d|25[0-5]|[01]?\d\d?|\*)\.)(2[0-4]\d|25[0-5]|[01]?\d\d?|\*)$");
        }
        /// <summary>
        /// 判断字符串是否为限定的IP地址格式
        /// <remarks>
        /// 返回指定IP是否在指定的IP数组所限定的范围内, IP数组内的IP地址可以使用*表示该IP段任意, 例如192.168.1.*
        /// </remarks>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <param name="limitArray">限定范围，IP数组</param>
        /// <returns>True/False，是/否</returns>
        public static bool IsIPOfArray(string strVerify, string[] limitArray)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            string[] userip = SplitString(strVerify, @".");
            for (int ipIndex = 0; ipIndex < limitArray.Length; ipIndex++)
            {
                string[] tmpip = SplitString(limitArray[ipIndex], @".");
                int r = 0;
                for (int i = 0; i < tmpip.Length; i++)
                {
                    if (tmpip[i] == "*") return true;
                    if (userip.Length > i)
                    {
                        if (tmpip[i] == userip[i]) { r++; } else { break; }
                    }
                    else
                    {
                        break;
                    }
                }
                if (r == 4) return true;
            }
            return false;
        }
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">要分割的字符串</param>
        /// <param name="strSplit">分割标识</param>
        /// <returns>字符串数组</returns>
        internal static string[] SplitString(string strContent, string strSplit)
        {
            if (!string.IsNullOrEmpty(strContent))
            {
                if (strContent.IndexOf(strSplit) < 0) return new string[] { strContent };
                return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
            }
            else
            {
                return new string[0] { };
            }
        }

        #endregion

        #region 身份证

        /// <summary>
        /// 判断字符串是否符合大陆身份证规范
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool IsIDCard(string strVerify)
        {
            if (strVerify.Length == 18)
            {
                return IsIDCard18(strVerify);
            }
            else if (strVerify.Length == 15)
            {
                return IsIDCard15(strVerify);
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断字符串是否符合大陆身份证规范
        /// <para>验证15位身份证号码</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        private static bool IsIDCard18(string strVerify)
        {
            long n = 0;
            if (long.TryParse(strVerify.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(strVerify.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(strVerify.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = strVerify.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = strVerify.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != strVerify.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        /// <summary>
        /// 判断字符串是否符合大陆身份证规范
        /// <para>验证18位身份证号码</para>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        private static bool IsIDCard15(string strVerify)
        {
            long n = 0;
            if (long.TryParse(strVerify, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(strVerify.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = strVerify.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }

        #endregion

        #region 颜色值验证

        /// <summary>
        /// 判断字符串是否为3/6位的合法颜色值
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool IsColor(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            if (GetOccurrenceNumber(strVerify, "#") > 1) return false;
            strVerify = strVerify.Trim().Trim('#');
            if (strVerify.Length != 3 && strVerify.Length != 6) return false;
            //不包含0-9  a-f以外的字符
            if (!Regex.IsMatch(strVerify, @"[^0-9a-f]", RegexOptions.IgnoreCase)) return true;
            return false;
        }
        /// <summary>
        /// 查找一个字符串在另一个字符串中出现的次数
        /// </summary>
        /// <param name="strSource">源数据</param>
        /// <param name="strFind">查找数据</param>
        /// <returns>出现次数，默认为 0</returns>
        public static int GetOccurrenceNumber(string strSource, string strFind)
        {
            if (strSource.Length <= 0 | strFind.Length <= 0) return 0;
            int intSum = 0, intTemp = 0;
            do
            {
                intTemp = strSource.IndexOf(strFind, intTemp);
                if (intTemp != -1)
                {
                    intSum++;
                    intTemp += strFind.Length;
                }
            }
            while (intTemp != -1);
            return intSum;
        }

        #endregion

        #region SQL 注入

        /// <summary>
        /// 判断字符串是否存在用于SQL注入的关键字、数据类型、危险字符
        /// <remarks>
        /// 结合四个SQL注入检测方法
        /// </remarks>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，存在/不存在</returns>
        public static bool IsSqlFilter(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            if (IsSqlInjectionOfKey(strVerify)) return true;
            if (IsSqlInjectionOfType(strVerify)) return true;
            if (IsSqlInjectionOfURL(strVerify)) return true;
            if (IsSqlInjectionOfString(strVerify)) return true;
            return false;
        }
        /// <summary>
        /// 判断字符串是否存在用于SQL注入的SQL关键字
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，存在/不存在</returns>
        public static bool IsSqlInjectionOfKey(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            string keyWord = "table|proc|procedure|and|exec|from|execute|drop|insert|into|select|delete|update|alter|when|set|chr|mid|master|or|then|like|truncate|char|declare|inner|join|where|order|by|as|case|commit|create|distinct|identity";
            foreach (string strTmp in keyWord.Split('|'))
            {
                if ((strVerify.ToLower().IndexOf(strTmp + " ") > -1) || (strVerify.ToLower().IndexOf(" " + strTmp) > -1)) return true;
            }
            return false;
        }
        /// <summary>
        /// 判断字符串是否存在用于SQL注入的SQL数据类型
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，存在/不存在</returns>
        public static bool IsSqlInjectionOfType(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            string keyWord = "bigint|numeric|bit|smallint|decimal|smallmoney|int|tinyint|money|float|real|date|datetimeoffset|smalldatetime|datetime|time|char|varchar|text|nchar|nvarchar|ntext|binary|varbinary|image|cursor|timestamp|xml|table";
            foreach (string strTmp in keyWord.Split('|'))
            {
                if ((strVerify.ToLower().IndexOf(strTmp + " ") > -1) || (strVerify.ToLower().IndexOf(" " + strTmp) > -1)) return true;
            }
            return false;
        }
        /// <summary>
        /// 判断字符串是否存在用于SQL注入的SQL危险字符
        /// <remarks>
        /// 常用于 URL 链接检测
        /// </remarks>
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，存在/不存在</returns>
        public static bool IsSqlInjectionOfURL(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            string keyWord = "and|as|alter|declare|delete|double(|drop|exec(|exec|execute|from|in|inner|insert|into|join|like|or|order|proc|procedure|return|select|set|top|update|values(|where |bigint(|numeric(|bit(|smallint(|decimal(|smallmoney(|int(|tinyint(|money(|float(|date(|datetimeoffset(|smalldatetime(|datetime(|char(|varchar(|text(|nchar(|nvarchar(|ntext(";
            foreach (string strTmp in keyWord.Split('|'))
            {
                if ((strVerify.ToLower().IndexOf(strTmp + " ") > -1) || (strVerify.ToLower().IndexOf(" " + strTmp) > -1)) return true;
            }
            return false;
        }
        /// <summary>
        /// 判断字符串是否存在用于SQL注入的SQL危险字符
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，存在/不存在</returns>
        public static bool IsSqlInjectionOfString(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        #endregion

        #region 常规检测

        /// <summary>
        /// 判断字符串是否存在用于链接的危险字符
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，存在/不存在</returns>
        public static bool IsSafeString(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^\s*$|^c:\\con\\con$|[%,\*" + "\"" + @"\s\t\<\>\&]|游客|^Guest");
        }
        /// <summary>
        /// 判断字符串是否为正确的URL地址格式
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool IsURL(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            return Regex.IsMatch(strVerify, @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$");
        }
        /// <summary>
        /// 判断字符串是否为Base64字符串
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool IsBase64String(string strVerify)
        {
            if (string.IsNullOrEmpty(strVerify)) return false;
            //A-Z, a-z, 0-9, +, /, =
            bool tmpFlg = Regex.IsMatch(strVerify, @"[A-Za-z0-9\+\/\=]");
            if (tmpFlg)
            {
                try
                {
                    Convert.FromBase64String(strVerify);
                }
                catch
                {
                    tmpFlg = false;
                }
            }
            return tmpFlg;
        }
        /// <summary>
        /// 判断字符串是否符合邮政编码格式
        /// </summary>
        /// <param name="strVerify">需要验证的字符串</param>
        /// <returns>True/False，是/否</returns>
        public static bool IsPost(string strVerify)
        {
            return Regex.IsMatch(strVerify, @"^[1-9]\d{5}$");
        }
        /// <summary>
        /// 是否为正确的全球唯一标识
        /// </summary>
        /// <param name="strVerify">全球唯一标识</param>
        /// <returns>True / False</returns>
        public static bool IsGuid(string strVerify)
        {
            try
            {
#if (NET20 || NET35)
                Guid result = new Guid(strVerify);
                return true;
#else
                Guid result;
                return Guid.TryParse(strVerify, out result);
#endif
            }
            catch
            {
                return false;
            }
        }

        #endregion

    }
}
