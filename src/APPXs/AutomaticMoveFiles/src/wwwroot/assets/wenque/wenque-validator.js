'use strict';
/**
* ---------------------------------------------------
* 文雀 - 通用验证器
* 风幽思静繁花落，夜半楼台听江雨。
* @author 宋杰军（cockroach888@outlook.com）
* @date 2019-10-10
* @modify 2019-10-11 宋杰军
*    完善整体功能。
* ---------------------------------------------------
*/
WenQue.Validator = {
    /**
	* 版本号
	* @return {String} 版本号
	*/
	version: '3.0.0',
	/**
	* 判断指定数据是否符合 Email(电子邮件) 格式。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isEmail: function (valueString) {
		var patternString = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否符合 Email(电子邮件) 格式。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isEmailPlus: function (valueString) {
		var patternString = /^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.(([0-9]{1,3})|([a-zA-Z]{2,4})|(aero|coop|info|museum|name))$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否为真实姓名，2-8个中文。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isRealName: function (valueString) {
		var patternString = /^[\u4E00-\u9FA5]{2,8}$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由中文组成。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isChinese: function (valueString) {
		var patternString = /^[\u4E00-\u9FA5]+$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由中文、英文、数字组成。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isChsEngNum: function (valueString) {
		var patternString = /^[a-zA-Z0-9\u4E00-\u9FA5]+$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由中文、英文、数字组成，且中文或英文开头。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isChsEngNumPlus: function (valueString) {
		var patternString = /^[a-zA-Z\u4e00-\u9fa5]+([a-zA-Z0-9\u4E00-\u9FA5]{0,}$)/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由中文、字母、数字组成，可含标点符号()[]（）《》。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isText: function (valueString) {
		var patternString = /^[0-9a-zA-Z\u4E00-\u9FA5()\[\]（）《》]+$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由中文、字母、数字组成，可含标点符号()[]（）《》，且中文或英文开头。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isTextPlus: function (valueString) {
		var patternString = /^[a-zA-Z\u4E00-\u9FA5]+([0-9a-zA-Z\u4E00-\u9FA5()\[\]（）《》]{0,}$)/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由中文、字母、数字组成，可含标点符号()[]（）《》：:、，,。.；;！!……，含换行符及回车符。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isMemo: function (valueString) {
		var patternString = /^[0-9a-zA-Z\u4E00-\u9FA5()\[\]（）《》：:、，,。.；;！!……\n\r]+$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由中文、字母、数字组成，可含标点符号()[]（）《》：:、，,。.；;！!……，含换行符及回车符，且中文或英文开头。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isMemoPlus: function (valueString) {
		var patternString = /^[a-zA-Z\u4E00-\u9FA5]+([0-9a-zA-Z\u4E00-\u9FA5()\[\]（）《》：:、，,。.；;！!……\n\r]{0,}$)/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由中文、字母、数字组成，可含标点符号()[-]（、）《》，且中文或英文开头。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isAddress: function (valueString) {
		var patternString = /^[a-zA-Z\u4E00-\u9FA5]+([0-9a-zA-Z\u4E00-\u9FA5()\[\-\]（、）《》]{0,}$)/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否符合密码规范，任意字符，长度：6-16 [区分大小写]。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isPassword: function (valueString) {
		var patternString = /^.{6,16}$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否符合密码规范，任意字符，长度：6-16 [区分大小写]，且英文开头。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isPasswordPlus: function (valueString) {
		var patternString = /^[a-zA-Z]{1}.{5,15}$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否符合密码规范，由英文和数字及下划线组成，长度：6-16 [区分大小写]，且英文开头。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isPasswordAt: function (valueString) {
		var patternString = /^[a-zA-Z]{1}(\w){5,15}$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由英文和数字组成，用于检测注册帐号是否符合规范用，长度：6-15 [不区分大小写]，且英文开头。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isAccount: function (valueString) {
		var patternString = /^[a-zA-Z]{1}([a-zA-Z0-9]){5,15}$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由26个英文字母组成，不区分大小写。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isEnglish: function (valueString) {
		var patternString = /^[A-Za-z]+$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由26个英文大写字母组成。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isEngUppercase: function (valueString) {
		var patternString = /^[A-Z]+$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由26个英文小写字母组成。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isEngLowercase: function (valueString) {
		var patternString = /^[a-z]+$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由26个英文和数字组成。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isEngNum: function (valueString) {
		var patternString = /^[A-Za-z0-9]+$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由26个英文和数字组成，且英文开头。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isEngNumPlus: function (valueString) {
		var patternString = /^[a-zA-Z]+([a-zA-Z0-9]{0,}$)/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由26个英文、数字及逗号组成，且英文开头。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isEngNumComma: function (valueString) {
		var patternString = /^[a-zA-Z]+([0-9a-zA-Z,]{0,}$)/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由26个英文和数字及下划线组成。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isEngNumUnderline: function (valueString) {
		var patternString = /^\w+$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否为 Byte 类型，0-255数值。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isByte: function (valueString) {
		var patternString = /((^[0-9]{1,2})|(^[1][0-9]{1,2})|(^[2][0-5][0-5]))$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否由数字组成。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isInteger: function (valueString) {
		var patternString = /^[-\+]?\d+$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否为零和非零开头的数字。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isZeroNot: function (valueString) {
		var patternString = /^(0|[1-9][0-9]*)$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否为2位小数的正实数。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isReals2Point: function (valueString) {
		var patternString = /^[0-9]+(.[0-9]{2})?$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否为1至3位小数的正实数。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isReals3Point: function (valueString) {
		var patternString = /^[0-9]+(.[0-9]{1,3})?$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否为非零的正整数。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isIntegralSignless: function (valueString) {
		var patternString = /^\+?[1-9][0-9]*$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否为非零的负整数。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isIntegralNegative: function (valueString) {
		var patternString = /^\-[1-9][0-9]*$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否为正浮点数。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isFloatSignless: function (valueString) {
		var patternString = /^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否为负浮点数。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isFloatNegative: function (valueString) {
		var patternString = /^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否为Double类型。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isDouble: function (valueString) {
		var patternString = /^([0-9])[0-9]*(\.\w*)?$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否为Double类型，包含正负号。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isDoublePlus: function (valueString) {
		var patternString = /^[-\+]?\d+(\.\d+)?$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否为Money类型。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isMoney: function (valueString) {
		var patternString = /^(([1-9]\d*)|(([0-9]{1}|[1-9]+)\.[0-9]{1,2}))$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否符合电话号码格式。
	* 座机号码，格式：010-12345678、020-1234567、0755-1234567、0755-12345678、1234567、12345678
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isTelephone: function (valueString) {
		var patternString = /^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否符合手机号码格式。
	* 中国移动、中国联通、中国电信
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isMobile: function (valueString) {
		return (isChinaMobile(valueString) || isChinaUnicom(valueString) || isChinaTelecom(valueString));
	},
	/**
	* 判断指定数据是否符合（中国移动）手机号码格式。
	* 【134 135 136 137 138 139 147 150 151 152 157 158 159 182 187 188】
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isChinaMobile: function (valueString) {
		var patternString = /(^134135|^136|^137|^138|^139|^147|^150|^151|^152|^157|^158|^159|^172|^178|^182|^183|^184|^187|^188|^198)[0-9]{8}$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否符合（中国联通）手机号码格式。
	* 【130 131 132 145 155 156 185 186】
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isChinaUnicom: function (valueString) {
		var patternString = /(^130|^131|^132|^145|^155|^156|^166|^171|^175|^176|^185|^186|^166)[0-9]{8}$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否符合（中国电信）手机号码格式。
	* 【133 153 180 189】
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isChinaTelecom: function (valueString) {
		var patternString = /(^133|^149|^153|^173|^177|^180|^181|^189|^199)[0-9]{8}$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否为正确的IP地址格式。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isIPAddress: function (valueString) {
		var patternString = /^(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5])$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否符合大陆身份证规范。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isIDCard: function (valueString) {
		var patternString = /(^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3})|(^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])(\d{4}|\d{3}[x]))$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否为正确的URL地址格式。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isURL: function (valueString) {
		var patternString = /^http:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否符合邮政编码格式。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isPost: function (valueString) {
		var patternString = /^[1-9]\d{5}$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否符合安全标准。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isUnSafe: function (valueString) {
		var patternString = /^(([A-Z]*|[a-z]*|\d*|[-_\~!@#\$%\^&\*\.\(\)\[\]\{\}<>\?\\\/\'\"]*)|.{0,5})$|\s/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否为百分比格式。
	* @param {String} valueString 需要判断的数据
	* @return {Boolean} True/False，是/否
	*/
	isPer: function (valueString) {
		var patternString = /^(?:[1-9][0-9]?|100)(?:\.[0-9]{1,2})?$/;
		return new RegExp(patternString).test(valueString);
	},
	/**
	* 判断指定数据是否为日期格式。
	* @param {String} valueString 需要判断的数据
	* @param {String} format 日期格式化方式
	* @return {Boolean} True/False，是/否
	*/
	isDate: function (valueString, format) {
		format = format || 'yyyy-MM-dd HH:mm';
		var input = date,
			i,
			o = {},
			d = new Date();
		f1 = format.split(/[^a-z]+/gi),
			f2 = input.split(/\D+/g),
			f3 = format.split(/[a-z]+/gi),
			f4 = input.split(/\d+/g),
			len = f1.length,
			len1 = f3.length,
			reVal = false,
			s = function (s1, s2, s3, s4, s5) {
				s4 = s4 || 60, s5 = s5 || 2;
				var reVal = s3;
				if (s1 != undefined && s1 != '' || !isNaN(s1)) {
					reVal = s1 * 1;
				}
				if (s2 != undefined && s2 != '' && !isNaN(s2)) {
					reVal = s2 * 1;
				}
				return (reVal == s1 && s1.length != s5 || reVal > s4) ? -10000 : reVal;
			};
		if (len != f2.length || len1 != f4.length) {
			return false;
		}
		for (i = 0; i < len1; i += 1) {
			if (f3[i] != f4[i]) {
				return false;
			}
		}
		for (i = 0; i < len; i += 1) {
			o[f1[i]] = f2[i];
		}
		o.yyyy = s(o.yyyy, o.yy, d.getFullYear(), 9999, 4);
		o.MM = s(o.MM, o.M, d.getMonth() + 1, 12);
		o.dd = s(o.dd, o.d, d.getDate(), 31);
		o.hh = s(o.hh, o.h, d.getHours(), 24);
		o.mm = s(o.mm, o.m, d.getMinutes());
		o.ss = s(o.ss, o.s, d.getSeconds());
		o.ms = s(o.ms, o.ms, d.getMilliseconds(), 999, 3);
		if (o.yyyy + o.MM + o.dd + o.hh + o.mm + o.ss + o.ms < 0) {
			return false;
		}
		if (o.yyyy < 100) {
			o.yyyy += (o.yyyy > 30 ? 1900 : 2000);
		}
		d = new Date(o.yyyy, o.MM - 1, o.dd, o.hh, o.mm, o.ss, o.ms);
		reVal = d.getFullYear() == o.yyyy && d.getMonth() + 1 == o.MM && d.getDate() == o.dd && d.getHours() == o.hh && d.getMinutes() == o.mm && d.getSeconds() == o.ss && d.getMilliseconds() == o.ms;
		return reVal ? d : reVal;
	},
	/**
	* 判断指定对象是否为数组
	* @param {Object} obj 检测对象
	* @return {Boolean} True/False，是/否
	*/
	isArray: function (obj) {
		return Array.isArray(obj);
	}
};