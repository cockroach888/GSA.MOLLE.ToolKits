'use strict';
/*
 * ---------------------------------------------------
 * 脉脉含情的充满精神的高尚的小强精神
 * 风幽思静繁花落；夜半楼台听江雨。
 * @author 宋杰军（cockroach888@outlook.com）
 * @date 2022-10-31
 * ---------------------------------------------------
*/


/**
 * 数据分页
 * @param {Int32} pageNumber 页码
 * @param {Int32} paginationSize 分页大小
 * @param {Object} parameter 额外的自定义参数
 *    - 请确认自定义参数是单参还是多参；
 *    - 通常建议 parameter 使用JSON格式以便扩展；
 *    - 并自行扩展此函数的参数个数；
 *    - 但须与生成调用处保持一致；
 *    - 请在“do something”处添加数据分页执行。
 * @return {Void}
*/
function OnPagingUtility(pageNumber, paginationSize, parameter) {
    // do something.
}

/**
 * 分页跳转
 * @param {Int32} paginationSize 分页大小
 * @return {Void}
*/
function OnPagingJumpto(paginationSize) {
    const __pageNumber = document.getElementById('txtPagingJumpto').value

    if (!isNaN(__pageNumber)) {
        OnPagingUtility(parseInt(__pageNumber), paginationSize)
    }
}