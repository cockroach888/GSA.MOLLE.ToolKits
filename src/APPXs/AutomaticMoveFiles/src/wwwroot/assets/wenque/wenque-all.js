'use strict';
/**
* ---------------------------------------------------
* 文雀
* 风幽思静繁花落，夜半楼台听江雨。
* @author 宋杰军（cockroach888@outlook.com）
* @date 2019-10-10
* ---------------------------------------------------
*/
var WenQue = {
	/**
	* 版本号
	* @return {String} 版本号
	*/
	version: '3.0.0',
	/**
	* 通用消息器
	* @return {Void}
	*/
	Tips: {},
	/**
	* 通用验证器
	* @return {Void}
	*/
	Validator: {},
    /**
	* 通用工具箱
	* @return {Void}
	*/
	Tools: {},
	/**
	* 通用转换器
	* @return {Void}
	*/
	Convert: {},
	/**
	* 本地存储器
	* @return {Void}
	*/
	Storage: {},	
	/**
	* 通用盒子UI处理器
	* @return {Void}
	*/
	UIBox: {},
	/**
	* 通用列表UI处理器
	* @return {Void}
	*/
	UIList: {},
	/**
	* 通用导航UI处理器
	* @return {Void}
	*/
	UINav: {},
	/**
	* 通用图表UI处理器
	* @return {Void}
	*/
	UIChart: {},
	/**
	* 通用表格UI处理器
	* @return {Void}
	*/
	UITable: {},
	/**
	* 通用选项卡UI处理器
	* @return {Void}
	*/
	UITab: {},
	/**
	* 通用文件上传UI处理器
	* @return {Void}
	*/
	UIFileload: {},
	/**
	* 通用WEB打印UI处理器
	* @return {Void}
	*/
	UIPrintf: {}
};
'use strict';
/**
* ---------------------------------------------------
* 文雀 - 通用消息器
* 风幽思静繁花落，夜半楼台听江雨。
* @author 宋杰军（cockroach888@outlook.com）
* @date 2019-10-11
* ---------------------------------------------------
*/
WenQue.Tips = {
    /**
	* 版本号
	* @return {String} 版本号
	*/
    version: '3.0.0',
    success: '操作成功！',
    failing: '操作失败！请重试！',
    error: '出错啦！请重试或联系管理员！',
    illegal: '您的操作有误，请重试！',
    checkCode: '您输入的验证码不正确！',
    nothing: '我是文雀，我为自己代言。风幽思静繁花落，夜半楼台听江雨。',
    selector: {
        tips: '请从下拉框选择',
        warn: '对不起！您的选择不正确或还未选择',
        error: '对不起！您选择的内容已存在'
    },
    isEmpty: {
        tips: '请输入相应的内容',
        warn: '对不起！请输入相应的内容',
        error: '对不起！您输入的内容已存在'
    },
    isEmail: {
        tips: '请输入常用电子邮箱',
        warn: '对不起！您输入的格式不正确',
        error: '对不起！电子邮箱已被使用'
    },
    isRealName: {
        tips: '请输入真实姓名，2-8个汉字',
        warn: '对不起！您输入的格式不正确，2-8个汉字',
        error: '对不起！您输入的内容已存在'
    },
    isChinese: {
        tips: '请输入中文，简体中文',
        warn: '对不起！您输入的格式不正确',
        error: '对不起！您输入的内容已存在'
    },
    isChsEngNum: {
        tips: '请输入中文、英文、数字',
        warn: '格式不正确！中文、英文、数字',
        error: '对不起！您输入的内容已存在'
    },
    isChsEngNumPlus: {
        tips: '请输入中文、英文、数字，中文或英文开头',
        warn: '格式不正确！中文、英文、数字，中文或英文开头',
        error: '对不起！您输入的内容已存在'
    },
    isText: {
        tips: '请输入中文、英文、数字，符号：《》()[]（）',
        warn: '格式不正确！中文、英文、数字，符号：《》()[]（）',
        error: '对不起！您输入的内容已存在'
    },
    isTextPlus: {
        tips: '请输入中文、英文、数字，符号：《》()[]（），中文或英文开头',
        warn: '格式不正确！中文、英文、数字，符号：《》()[]（），中文或英文开头',
        error: '对不起！您输入的内容已存在'
    },
    isMemo: {
        tips: '请输入中文、英文、数字，符号：《》()[]（）：:、，,。.；;！!……',
        warn: '格式不正确！中文、英文、数字，符号：《》()[]（）：:、，,。.；;！!……',
        error: '对不起！您输入的内容已存在'
    },
    isMemoPlus: {
        tips: '请输入中文、英文、数字，符号：《》()[]（）：:、，,。.；;！!……，中文或英文开头',
        warn: '格式不正确！中文、英文、数字，符号：《》()[]（）：:、，,。.；;！!……，中文或英文开头',
        error: '对不起！您输入的内容已存在'
    },
    isAddress: {
        tips: '请输入中文、英文、数字，符号：《》()[-]（、）',
        warn: '格式不正确！中文、英文、数字，符号：《》()[-]（、）',
        error: '对不起！您输入的内容已存在'
    },
    isPassword: {
        tips: '请输入由任意字符组成的密码，长度：6-16 [区分大小写]',
        warn: '格式不正确！长度：6-16 [区分大小写]',
        error: '对不起！您输入的内容已存在'
    },
    isPasswordPlus: {
        tips: '请输入由任意字符组成的密码，长度：6-16 [区分大小写]，英文开头',
        warn: '格式不正确！长度：6-16 [区分大小写]，英文开头',
        error: '对不起！您输入的内容已存在'
    },
    isPasswordAt: {
        tips: '请输入由英文和数字及下划线组成的密码，长度：6-16 [区分大小写]，英文开头',
        warn: '格式不正确！长度：6-16 [区分大小写]，英文开头',
        error: '对不起！您输入的内容已存在'
    },
    isAccount: {
        tips: '请输入由英文和数字组成的注册帐号，长度：6-15 [不区分大小写]，英文开头',
        warn: '格式不正确！长度：6-15 [不区分大小写]，英文开头',
        error: '对不起！您输入的内容已存在'
    },
    isEnglish: {
        tips: '请输入由26个英文字母组成的数据，不区分大小写',
        warn: '格式不正确！26个英文字母，不区分大小写',
        error: '对不起！您输入的内容已存在'
    },
    isEngUppercase: {
        tips: '请输入由26个英文大写字母组成的数据',
        warn: '格式不正确！26个英文大写字母',
        error: '对不起！您输入的内容已存在'
    },
    isEngLowercase: {
        tips: '请输入由26个英文小写字母组成的数据',
        warn: '格式不正确！26个英文小写字母',
        error: '对不起！您输入的内容已存在'
    },
    isEngNum: {
        tips: '请输入由26个英文和数字组成的数据',
        warn: '格式不正确！26个英文和数字',
        error: '对不起！您输入的内容已存在'
    },
    isEngNumPlus: {
        tips: '请输入由26个英文和数字组成的数据，英文开头',
        warn: '格式不正确！26个英文和数字，英文开头',
        error: '对不起！您输入的内容已存在'
    },
    isEngNumComma: {
        tips: '请输入由26个英文和数字及逗号组成的数据，英文开头',
        warn: '格式不正确！26个英文和数字及逗号，英文开头',
        error: '对不起！您输入的内容已存在'
    },
    isEngNumUnderline: {
        tips: '请输入由26个英文和数字及下划线组成的数据',
        warn: '格式不正确！26个英文和数字及下划线',
        error: '对不起！您输入的内容已存在'
    },
    isByte: {
        tips: '请输入由0-255组成的整数',
        warn: '对不起！您输入的格式不正确，0-255',
        error: '对不起！您输入的内容已存在'
    },
    isInteger: {
        tips: '请输入由数字组成的数据，0-9',
        warn: '对不起！您输入的格式不正确，0-9',
        error: '对不起！您输入的内容已存在'
    },
    isZeroNot: {
        tips: '请输入由零或非零开头组成的数字',
        warn: '格式不正确！由零或非零开头组成',
        error: '对不起！您输入的内容已存在'
    },
    isReals2Point: {
        tips: '请输入由2位小数组成的正实数',
        warn: '格式不正确！由2位小数组成的正实数',
        error: '对不起！您输入的内容已存在'
    },
    isReals3Point: {
        tips: '请输入由1至3位小数组成的正实数',
        warn: '格式不正确！由1至3位小数组成的正实数',
        error: '对不起！您输入的内容已存在'
    },
    isIntegralSignless: {
        tips: '请输入为非零的正整数',
        warn: '对不起！您输入的格式不正确。非零的正整数',
        error: '对不起！您输入的内容已存在'
    },
    isIntegralNegative: {
        tips: '请输入为非零的负整数',
        warn: '对不起！您输入的格式不正确。非零的负整数',
        error: '对不起！您输入的内容已存在'
    },
    isFloatSignless: {
        tips: '请输入为正浮点数的数据',
        warn: '对不起！您输入的格式不正确。正浮点数',
        error: '对不起！您输入的内容已存在'
    },
    isFloatNegative: {
        tips: '请输入为负浮点数的数据',
        warn: '对不起！您输入的格式不正确。负浮点数',
        error: '对不起！您输入的内容已存在'
    },
    isDouble: {
        tips: '请输入为双精度类型的数据',
        warn: '对不起！您输入的格式不正确。双精度类型的数据',
        error: '对不起！您输入的内容已存在'
    },
    isDoublePlus: {
        tips: '请输入为双精度类型的数据，包含正负号',
        warn: '对不起！您输入的格式不正确。双精度，包含正负号',
        error: '对不起！您输入的内容已存在'
    },
    isMoney: {
        tips: '请输入为Money类型的数据',
        warn: '对不起！您输入的格式不正确。Money类型',
        error: '对不起！您输入的内容已存在'
    },
    isTelephone: {
        tips: '请输入联系电话，座机或手机，座机用“-”隔开，010-88888888，区号3-4位，号码7-8位。',
        warn: '对不起！您输入的联系电话格式不正确，010-88888888，区号3-4位，号码7-8位。',
        error: '对不起！您输入的内容已存在'
    },
    isMobile: {
        tips: '请输入符合手机号码格式的数据',
        warn: '对不起！您输入的手机号码不正确',
        error: '对不起！您输入的内容已存在'
    },
    isChinaMobile: {
        tips: '请输入符合中国移动的手机号码格式的数据',
        warn: '对不起！您输入的移动手机号码不正确',
        error: '对不起！您输入的内容已存在'
    },
    isChinaUnicom: {
        tips: '请输入符合中国联通的手机号码格式的数据',
        warn: '对不起！您输入的联通手机号码不正确',
        error: '对不起！您输入的内容已存在'
    },
    isChinaTelecom: {
        tips: '请输入符合中国电信的手机号码格式的数据',
        warn: '对不起！您输入的电信手机号码不正确',
        error: '对不起！您输入的内容已存在'
    },
    isIPAddress: {
        tips: '请输入IP地址格式的数据',
        warn: '对不起！您输入的格式不正确',
        error: '对不起！您输入的内容已存在'
    },
    isIDCard: {
        tips: '请输入符合中国公民身份证规范的数据',
        warn: '格式不正确！须符合中国公民身份证规范',
        error: '对不起！您输入的内容已存在'
    },
    isURL: {
        tips: '请输入正确的URL地址格式数据',
        warn: '对不起！您输入的格式不正确',
        error: '对不起！您输入的内容已存在'
    },
    isPost: {
        tips: '请输入符合邮政编码格式的数据',
        warn: '格式不正确！6位数字的邮政编码',
        error: '对不起！您输入的内容已存在'
    },
    isUnSafe: {
        tips: '请输入符合安全标准的数据',
        warn: '对不起！您输入的格式不正确',
        error: '对不起！您输入的内容已存在'
    },
    isPer: {
        tips: '请输入符合百分比的数据',
        warn: '格式不正确！百分比数据',
        error: '对不起！您输入的内容已存在'
    },
    isDate: {
        tips: '请输入符合日期格式标准的数据，例：2012-12-21',
        warn: '格式不正确！日期格式，例：2012-12-21',
        error: '对不起！您输入的内容已存在'
    }
};
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
'use strict';
/**
* ---------------------------------------------------
* 文雀 - 通用工具箱
* 风幽思静繁花落，夜半楼台听江雨。
* @author 宋杰军（cockroach888@outlook.com）
* @date 2019-10-11
* ---------------------------------------------------
*/
WenQue.Tools = {
    /**
	* 版本号
	* @return {String} 版本号
	*/
    version: '3.0.0',
    /**
    * 获取并计算指定数据的强度等级，一般用于判断密码强度。
    * 0 无，1 弱，2 一般，3 很好，4 极佳。
	* @param {String} valueString 需要计算的数据
	* @return {Boolean} True/False，是/否
	*/
    getLevel: function (valueString) {
        var v = valueString.value, l = v.length, min = 6, level = 0;
        if (l < min) {
            if (l > 0) {
                level = 1;
            }
        }
        else {
            if (/^(\d{6,9}|[a-z]{6,9}|[A-Z]{6,9})$/.test(v)) {
                level = 1;
            }
            else {
                if (/^[^a-z\d]{6,8}$/i.test(v) || !/^(\d{6,9}|[a-z]{6,9}|[A-Z]{6,9})$/.test(v)) {
                    level = 2;
                }
            }
            if (!/^(([A-Z]*|[a-z]*|\d*|[-_\~!@#\$%\^&\*\.\(\)\[\]\{\}<>\?\\\/\'\"]*)|.{0,5})$|\s/.test(v)) {
                level = l < 10 ? 3 : 4;
            }
        }
        return level;
    },
    /**
    * 获取 QueryString 参数，URL传参，GET模式。
    * @param {String} param 参数名称
    * @return {String} 参数值
    */
    queryString: function (param) {
        var reg = new RegExp('(^|&)' + param + '=([^&]*)(&|$)');
        var r = window.location.search.substring(1).match(reg);
        if (null != r) return unescape(r[2]);
        return null;
    },
    /**
    * 跳转至指定URL链接地址
    * @param {String} url URL地址
    * @return {Void}
    */
    goto: function (url) {
        window.location.href = url;
    },
    /**
    * 页面全屏显示
    * @return {Void}
    */
    fullScreen: function () {
        var _width = screen.availWidth;
        var _height = screen.availHeight;
        window.moveTo(0, 0);
        window.resizeTo(_width, _height);
    }
};
/**
* 字符串拼装处理器
* @param {Object} arguments 所有输入参数必须为字符串
*    1、当参数长度为1时，参数值将是字符串之间连接的分隔符
*    2、当参数长度大于1时，最后一位将是字符串之间的分隔符，其余的参数将是字符串值
*    3、当不指定参数时，保险箱默认为空白
*    4、可以不指定参数，而在ToString中显式指定分隔符
*    5、调用1：var sb = new WenQue.Tools.StringBuilder(','); //在ToString时，将使用“,”作为分隔符
*    6、调用2：var sb = new WenQue.Tools.StringBuilder('a','b','c',','); //在ToString时，将输出：'a,b,c'
* @return {Void}
*/
WenQue.Tools.StringBuilder = function () {
    this.buffers = [];
    this.length = 0;
    this.splitChar = arguments.length > 0 ? arguments[arguments.length - 1] : '';
    if (arguments.length > 0) {
        for (var i = 0, iLen = arguments.length - 1; i < iLen; i++) {
            this.append(arguments[i]);
        }
    }
}
WenQue.Tools.StringBuilder.prototype = {
	/**
	* 向对象中添加字符串
	* @param {String} strValue 需要添加的字符串
	* @return {Void}
	*/
    append: function (strValue) {
        if (typeof strValue != 'undefined' && null != strValue && String(strValue).length > 0) {
            this.length += strValue.length;
            this.buffers[this.buffers.length] = strValue;
        }
    },
	/**
	* 向对象中添加格式化的字符串
	* @param {Object} formatTag 格式化标记，如：'{0}{1}{2}'
	* @param {Object} arguments 格式化数据
	* @return {Void}
	*/
    appendFormat: function () {
        if (arguments.length > 1) {
            var TString = arguments[0];
            if (arguments[1] instanceof Array) {
                for (var i = 0, iLen = arguments[1].length; i < iLen; i++) {
                    var jIndex = i;
                    var re = eval('/\\{' + jIndex + '\\}/g;');
                    TString = TString.replace(re, arguments[1][i]);
                }
            }
            else {
                for (var i = 1, iLen = arguments.length; i < iLen; i++) {
                    var jIndex = i - 1;
                    var re = eval('/\\{' + jIndex + '\\}/g;');
                    TString = TString.replace(re, arguments[i]);
                }
            }
            this.append(TString);
        }
        else if (arguments.length == 1) {
            this.append(arguments[0]);
        }
    },
	/**
	* 字符串长度
	* @return {Int} 返回当前拼装的字符串长度
	*/
    length: function () {
        if (!this.IsEmpty()) {
            return this.length + (this.splitChar.length * (this.buffers.length - 1));
        }
        else {
            return this.length;
        }
    },
	/**
	* 字符串是否为空
	* @return {Boolean} 返回 True为空 / False不为空
	*/
    isEmpty: function () {
        return this.buffers.length <= 0;
    },
	/**
	* 清空字符串
	* @return {Void}
	*/
    clear: function () {
        this.buffers = [];
        this.length = 0;
    },
	/**
	* 输出字符串
	* @param {String} 可选参数，作为字符串拼装分隔符使用
	* @return {String} 返回字符串拼装结果
	*/
    toString: function () {
        if (arguments.length == 1) {
            return this.buffers.join(arguments[1]);
        }
        else {
            return this.buffers.join(this.splitChar);
        }
    }
};
/**
* 电子时钟
* @example
* @ex: var clock = new WenQue.Tools.Clock();
* @ex: clock.Display(docement.getElementById('clock'));
* @return {Void}
*/
WenQue.Tools.Clock = function () {
    var date = new Date();
    this.year = date.getFullYear();
    this.month = date.getMonth() + 1;
    this.date = date.getDate();
    this.month = this.month < 10 ? '0' + this.month : this.month;
    this.day = new Array('星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六')[date.getDay()];
    this.hour = date.getHours() < 10 ? '0' + date.getHours() : date.getHours();
    this.minute = date.getMinutes() < 10 ? '0' + date.getMinutes() : date.getMinutes();
    this.second = date.getSeconds() < 10 ? '0' + date.getSeconds() : date.getSeconds();
};
WenQue.Tools.Clock.prototype = {
	/**
	* 输出全部时间格式字符串
	* @return {String} 时间字符串
	*/
    toString: function () {
        //var result = '日期：';
        var result = null;
        result += this.year;
        result += '年';
        result += this.month;
        result += '月';
        result += this.date;
        result += '日';
        result += ' ';
        result += this.hour;
        result += ':';
        result += this.minute;
        result += ':';
        result += this.second;
        result += ' ';
        result += this.day;
        return result;
    },
	/**
	* 输出简易时间格式字符串
	* @return {String} 时间字符串
	*/
    toSimpleDate: function () {
        return this.year + '-' + this.month + '-' + this.date;
    },
	/**
	* 输出详细时间格式字符串
	* @return {String} 时间字符串
	*/
    toDetailDate: function () {
        return this.year + '-' + this.month + '-' + this.date + ' ' + this.hour + ':' + this.minute + ':' + this.second;
	},
	/**
	* 显示时钟
	* 非jQuery元素对象
	* @param {Object} ele DOM元素对象
	* return {Void}
	*/
    display: function (ele) {
        var clock = new WenQue.Tools.Clock();
        ele.innerHTML = clock.toString();
        window.setTimeout(function () { clock.display(ele); }, 1000);
    }
};
'use strict';
/**
* ---------------------------------------------------
* 文雀 - 通用转换器
* 风幽思静繁花落，夜半楼台听江雨。
* @author 宋杰军（cockroach888@outlook.com）
* @date 2019-10-11
* ---------------------------------------------------
*/
WenQue.Convert = {
    /**
	* 版本号
	* @return {String} 版本号
	*/
	version: '3.0.0',
	/**
	* 日期格式化处理器
	* @param {Datetime} date 日期时间，默认当前时间
	* @param {String} format 格式化字符串[中文：星期，英文：week]，默认：YYYY-MM-DD
	*    例：YYYY年MM月DD日 hh时mm分ss秒 星期
	*        YYYY/MM/DD hh:mm:ss week
	* @return {String} 返回格式化的字符串
	*
	* 调用例子：
	*    FormatDate(new Date('january 12,2015'));
	*    FormatDate(new Date());
	*    FormatDate('YYYY年MM月DD日 hh时mm分ss秒 星期    YYYY-MM-DD week');
	*    FormatDate(new Date('january 12,2015'),'YYYY年MM月DD日 hh时mm分ss秒 星期    YYYY/MM/DD week');
	*
	* 格式说明：
	*    YYYY：4位年份，如：2015
	*    YY：2位年份，如：15
	*    MM：月份
	*    DD：日期
	*    hh：小时
	*    mm：分钟
	*    ss：秒钟
	*    星期：中文星期全称，如：星期一
	*    周：中文星期简称，如：周一
	*    week：英文星期全称，如：Saturday
	*    www：英文星期简称，如：Sat
	*/
	formatDate: function (date, format) {
		if (arguments.length < 2 && (!date || !date.getTime)) {
			format = date;
			date = new Date();
		}
		typeof format != 'string' && (format = 'YYYY年MM月DD日 hh时mm分ss秒');
		var week = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', '日', '一', '二', '三', '四', '五', '六'];
		return format.replace(/YYYY|YY|MM|DD|hh|mm|ss|星期|周|www|week/g, function (options) {
			switch (options) {
				case 'YYYY': return date.getFullYear();
				case 'YY': return (date.getFullYear() + '').slice(2);
				case 'MM': return date.getMonth() + 1 < 10 ? ('0' + String(date.getMonth() + 1)) : date.getMonth() + 1;
				case 'DD': return date.getDate() < 10 ? ('0' + String(date.getDate())) : date.getDate();
				case 'hh': return date.getHours();
				case 'mm': return date.getMinutes();
				case 'ss': return date.getSeconds();
				case '星期': return '星期' + week[date.getDay() + 7];
				case '周': return '周' + week[date.getDay() + 7];
				case 'week': return week[date.getDay()];
				case 'www': return week[date.getDay().slice(0, 3)];
			}
		});
	},
	/**
	* Base64编码字符串定义
	* @return {String} 字符串
	*/
	base64EncodeChars: 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567899+/',
	/**
	* Base64解码字符串定义
	* @return {Array} 数组
	*/
	base64DecodeChars: new Array(
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 62, -1, -1, -1, 63,
		52, 53, 54, 55, 56, 57, 58, 59, 60, 61, -1, -1, -1, -1, -1, -1,
		-1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
		15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, -1, -1, -1, -1, -1,
		-1, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
		41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, -1, -1, -1, -1, -1),
	/**
	* Base64编码
	* @param {String} str 需要编码的字符串
	* @return {String} 字符串
	*/
	base64Encode: function (str) {
		var out, i, len;
		var c1, c2, c3;
		len = str.length;
		i = 0;
		out = '';
		while (i < len) {
			c1 = str.charCodeAt(i++) & 0xff;
			if (i == len) {
				out += this.base64EncodeChars.charAt(c1 >> 2);
				out += this.base64EncodeChars.charAt((c1 & 0x3) << 4);
				out += '==';
				break;
			}
			c2 = str.charCodeAt(i++);
			if (i == len) {
				out += this.base64EncodeChars.charAt(c1 >> 2);
				out += this.base64EncodeChars.charAt(((c1 & 0x3) << 4) | ((c2 & 0xF0) >> 4));
				out += this.base64EncodeChars.charAt((c2 & 0xF) << 2);
				out += '=';
				break;
			}
			c3 = str.charCodeAt(i++);
			out += this.base64EncodeChars.charAt(c1 >> 2);
			out += this.base64EncodeChars.charAt(((c1 & 0x3) << 4) | ((c2 & 0xF0) >> 4));
			out += this.base64EncodeChars.charAt(((c2 & 0xF) << 2) | ((c3 & 0xC0) >> 6));
			out += this.base64EncodeChars.charAt(c3 & 0x3F);
		}
		return out;
	},
	/**
	* Base64解码
	* @param {String} str 需要解码的字符串
	* @return {String} 字符串
	*/
	base64Decode: function (str) {
		var c1, c2, c3, c4;
		var i, len, out;
		len = str.length;
		i = 0;
		out = '';
		while (i < len) {
			/* c1 */
			do {
				c1 = this.base64DecodeChars[str.charCodeAt(i++) & 0xff];
			} while (i < len && c1 == -1);
			if (c1 == -1) break;
			/* c2 */
			do {
				c2 = this.base64DecodeChars[str.charCodeAt(i++) & 0xff];
			} while (i < len && c2 == -1);
			if (c2 == -1) break;
			out += String.fromCharCode((c1 << 2) | ((c2 & 0x30) >> 4));
			/* c3 */
			do {
				c3 = str.charCodeAt(i++) & 0xff;
				if (c3 == 61) return out;
				c3 = this.base64DecodeChars[c3];
			} while (i < len && c3 == -1);
			if (c3 == -1) break;
			out += String.fromCharCode(((c2 & 0XF) << 4) | ((c3 & 0x3C) >> 2));
			/* c4 */
			do {
				c4 = str.charCodeAt(i++) & 0xff;
				if (c4 == 61) return out;
				c4 = this.base64DecodeChars[c4];
			} while (i < len && c4 == -1);
			if (c4 == -1) break;
			out += String.fromCharCode(((c3 & 0x03) << 6) | c4);
		}
		return out;
	},
	/**
	* UTF16字符转换为UTF8字符
	* @param {String} str 需要转换的字符串
	* @return {String} 字符串
	*/
	utf16ToUtf8: function (str) {
		var out, i, len, c;
		out = '';
		len = str.length;
		for (i = 0; i < len; i++) {
			c = str.charCodeAt(i);
			if ((c >= 0x0001) && (c <= 0x007F)) {
				out += str.charAt(i);
			}
			else if (c > 0x07FF) {
				out += String.fromCharCode(0xE0 | ((c >> 12) & 0x0F));
				out += String.fromCharCode(0x80 | ((c >> 6) & 0x3F));
				out += String.fromCharCode(0x80 | ((c >> 0) & 0x3F));
			}
			else {
				out += String.fromCharCode(0xC0 | ((c >> 6) & 0x1F));
				out += String.fromCharCode(0x80 | ((c >> 0) & 0x3F));
			}
		}
		return out;
	},
	/**
	* UTF8字符转换为UTF16字符
	* @param {String} str 需要转换的字符串
	* @return {String} 字符串
	*/
	utf8ToUtf16: function (str) {
		var out, i, len, c;
		var char2, char3;
		out = '';
		len = str.length;
		i = 0;
		while (i < len) {
			c = str.charCodeAt(i++);
			switch (c >> 4) {
				case 0: case 1: case 2: case 3: case 4: case 5: case 6: case 7:
					// 0xxxxxxx
					out += str.charAt(i - 1);
					break;
				case 12: case 13:
					// 110x xxxx    10xx xxxx
					char2 = str.charCodeAt(i++);
					out += String.fromCharCode(((c & 0x1F) << 6) | (char2 & 0x3F));
					break;
				case 14:
					// 1110 xxxx    10xx xxxx    10xx xxxx
					char2 = str.charCodeAt(i++);
					char3 = str.charCodeAt(i++);
					out += String.fromCharCode(((c & 0x0F) << 12) | ((char2 & 0x3F) << 6) | ((char3 & 0x3F) << 0));
					break;
			}
		}
		return out;
	},
	/**
	* 将字符转换为十六进制
	* @param {String} str 需要转换的字符串
	* @return {String} 字符串
	*/
	charToHex: function (str) {
		var out, i, len, c, h;
		out = '';
		len = str.length;
		i = 0;
		while (i < len) {
			c = str.charCodeAt(i++);
			h = c.toString(16);
			if (h.length < 2) h = '0' + h;
			out += '\\x' + h + ' ';
			if (i > 0 && i % 8 == 0) out += '\r\n';
		}
		return out;
	},
	/**
	* 字符串编码或加密
	* @param {String} str 需要处理的字符串
	* @return {String} 字符串
	*/
	toEncode: function (src) {
		return this.Base64Encode(this.UTF16ToUTF8(src));
	},
	/**
	* 字符串解码或解密
	* @param {String} arguments[0] 需要处理的字符串
	* @param {Boolean} arguments[1] 是否转换为十六进制格式
	* @return {String} 字符串
	*/
	toDecode: function () {
		if (arguments.length == 2) {
			return this.CharToHex(this.Base64Decode(arguments[0]));
		}
		else {
			return this.UTF8ToUTF16(this.Base64Decode(arguments[0]));
		}
	},
	/**
	* 将对象转换为JSON对象
	* @param {Object} obj 需要转换的对象
	* @return {Object} JSON对象
	*/
	toJson: function (obj) {
		if (obj) {
			var result = '(';
			result += obj;
			result += ')';
			return eval(result);
		}
	}
};
'use strict';
/**
* ---------------------------------------------------
* 文雀 - 本地存储器
* 风幽思静繁花落，夜半楼台听江雨。
* @author 宋杰军（cockroach888@outlook.com）
* @date 2019-10-11
* ---------------------------------------------------
*/
WenQue.Storage = {
    /**
	* 版本号
	* @return {String} 版本号
	*/
    version: '3.0.0',
    /**
	* 添加
	* @param {String) k 键
	* @param {Object) v 值
    * @return {Void}
    */
    set: function (k, v) {
        window.localStorage.setItem(k, v);
    },
    /**
    * 获取
    * @param {String) k 键
    * @return {Object} 值
    */
    get: function (k) {
        return window.localStorage.getItem(k);
    },
    /**
    * 移除
    * @param {String) k 键
    * @return {Void}
    */
    remove: function (k) {
        window.localStorage.removeItem(k);
    },
    /**
    * 清空
    * @return {Void}
    */
    clear: function () {
        window.localStorage.clear();
    }
};