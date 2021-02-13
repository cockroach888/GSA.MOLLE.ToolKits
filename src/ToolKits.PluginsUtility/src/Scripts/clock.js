'use strict';
/*----------------------------------------------------------
----- 时钟
----------------------------------------------------------*/
function Clock() {
	var date = new Date();
	this.year = date.getFullYear();
	this.month = date.getMonth() + 1;
	this.date = date.getDate();
	this.month = this.month < 10 ? "0" + this.month : this.month;
	this.day = new Array("星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六")[date.getDay()];
	this.hour = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
	this.minute = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
	this.second = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
	this.toString = function () {
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
	};
	this.toSimpleDate = function () {
		return this.year + "-" + this.month + "-" + this.date;
	};
	this.toDetailDate = function () {
		return this.year + "-" + this.month + "-" + this.date + " " + this.hour + ":" + this.minute + ":" + this.second;
	};
	this.display = function (ele) {
		var clock = new Clock();
		ele.innerHTML = clock.toString();
		window.setTimeout(function () { clock.display(ele); }, 1000);
	};
}