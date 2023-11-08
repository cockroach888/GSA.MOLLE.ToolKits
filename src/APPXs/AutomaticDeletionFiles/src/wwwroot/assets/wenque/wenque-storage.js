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