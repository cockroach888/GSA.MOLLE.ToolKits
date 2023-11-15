'use strict';

const controller = chrome.webview.hostObjects.mainWindow

let viewModel = new function () {
    let self = this
    self.dataIncludeList = ko.observableArray([])
    self.dataExcludeList = ko.observableArray([])
    self.fireIncludeRemove = function (value) {
        onIncludeRemove(value)
    }
    self.fireExcludeRemove = function (value) {
        onExcludeRemove(value)
    }
}
ko.applyBindings(viewModel)


$(() => {
    'use strict'

    swal({
        title: "警告",
        text: "所有参数和逻辑，未作任何校验，请按照正常思维使用，不要搞特殊。程序崩溃，小心让你电脑爆炸！（^_^）",
        icon: "warning",
        button: "No zuo no die. You can you up, no can no BB."
    })
})


/**
* 监视目录浏览
* @return {void}
*/
async function onBrowserDirectories() {
    const dirPath = await controller.BrowserDirectories()
    $('#txtMonitorDirectories').val(dirPath)
}

/**
* 包含内容单位
* @param {string} unitIdent 单位名称
* @return {void}
*/
function onIncludeUnitChange(unitIdent) {
    $('#sltIncludeContent').text(unitIdent)
}

/**
* 排除内容单位
* @param {string} unitIdent 单位名称
* @return {void}
*/
function onExcludeUnitChange(unitIdent) {
    $('#sltExcludeContent').text(unitIdent)
}

/**
* 添加要包含的内容
* @return {void}
*/
async function onIncludeAddin() {
    const value = $('#txtIncludeContent').val().trim()
    $('#txtIncludeContent').val('')

    if (value.length <= 0) {
        return
    }

    const keyword = $('#sltIncludeContent').text()
    const source = `${keyword}-${value}`

    if (viewModel.dataIncludeList.indexOf(source) === -1) {
        viewModel.dataIncludeList.push(source)
        await controller.IncludeAddin(keyword, value)
    }
    else {
        swal({
            text: "已存在相同内容",
            icon: "error",
            button: false,
            timer: 1000
        })
    }
}

/**
* 添加要排除的内容
* @return {void}
*/
async function onExcludeAddin() {
    const value = $('#txtExcludeContent').val().trim()
    $('#txtExcludeContent').val('')

    if (value.length <= 0) {
        return
    }

    const keyword = $('#sltExcludeContent').text()
    const source = `${keyword}-${value}`

    if (viewModel.dataExcludeList.indexOf(source) === -1) {
        viewModel.dataExcludeList.push(source)
        await controller.ExcludeAddin(keyword, value)
    }
    else {
        swal({
            text: "已存在相同内容",
            icon: "error",
            button: false,
            timer: 1000
        })
    }
}

/**
* 移除要包含的内容
* @param {string} value 值
* @return {void}
*/
async function onIncludeRemove(value) {
    if (viewModel.dataIncludeList.indexOf(value) !== -1) {
        viewModel.dataIncludeList.remove(value)
        await controller.IncludeRemove(value)
    }
}

/**
* 移除要排除的内容
* @param {string} value 值
* @return {void}
*/
async function onExcludeRemove(value) {
    if (viewModel.dataExcludeList.indexOf(value) !== -1) {
        viewModel.dataExcludeList.remove(value)
        await controller.ExcludeRemove(value)
    }
}

/**
* 启动
* @return {void}
*/
async function onStart() {
    const monitorPath = $('#txtMonitorDirectories').val().trim()

    if (monitorPath.length <= 0) {
        swal({
            text: "哥们儿！您逗我呢！！需要监视的目录都没有配置咧！！！",
            icon: "error",
            button: "我知道了，马上改正。",
            timer: 3000
        })

        return
    }

    const dataSource = {
        'MonitorDirectories': monitorPath,
        'IsIncludeSubdirectories': document.getElementById('chkIncludeSubdirectories').checked,
        'IsCleanEmptyFolder': document.getElementById('chkCleanEmptyFolder').checked,
        'ExcludeHiddenFiles': document.getElementById('chkExcludeHiddenFiles').checked,
        'ExcludeSystemFiles': document.getElementById('chkExcludeSystemFiles').checked,
        'ExcludeTemporaryFiles': document.getElementById('chkExcludeTemporaryFiles').checked,
        'CycleTimeDelay': $('#txtCycleTimeDelay').val(),
        'LeadTime': `${$('#txtLeadDay').val()}.${$('#txtLeadTime').val()}`,
        'WorkerThreads': $('#txtWorkerThreads').val() * 1
    }
    const result = await controller.StartAsync(JSON.stringify(dataSource))

    $('#btnStart').attr('disabled', 'disabled')
    $('#btnStop').removeAttr('disabled')

    swal({
        text: result[0],
        icon: result[1],
        button: "确定"
    })
}

/**
* 停止
* @return {void}
*/
async function onStop() {
    await controller.StopAsync()

    $('#btnStop').attr('disabled', 'disabled')
    $('#btnStart').removeAttr('disabled')

    swal({
        //title: "系统提示",
        text: "停止自动化移动文件",
        icon: "warning",
        button: "确定",
        timer: 2000
    })
}