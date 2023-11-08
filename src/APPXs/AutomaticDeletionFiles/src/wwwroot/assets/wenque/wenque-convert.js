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