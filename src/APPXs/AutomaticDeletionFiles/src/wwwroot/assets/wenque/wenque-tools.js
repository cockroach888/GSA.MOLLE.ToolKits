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