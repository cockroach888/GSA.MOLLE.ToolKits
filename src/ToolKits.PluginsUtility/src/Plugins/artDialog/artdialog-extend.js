
/*----------------------------------------------------------
----- 变量定义    ★★★
----------------------------------------------------------*/
var timer;
/*----------------------------------------------------------
----- 功能定义    ★★★
----------------------------------------------------------*/
var popConfirm = art.dialog.confirm;
var popTips = art.dialog.tips;
var popDataPass = art.dialog.data;
/*----------------------------------------------------------
----- 消息提示类型·一    ★★★
----------------------------------------------------------*/
function popMsg1(strMsg) {
    art.dialog({
        id: 'popmsg'
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
    });
}
/*----------------------------------------------------------
----- 消息提示类型·二
----------------------------------------------------------*/
function popMsg2(strTitle, strMsg) {
    art.dialog({
        id: 'popmsg'
        , title: strTitle
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
    });
}
/*----------------------------------------------------------
----- 消息提示并关闭类型·一    ★★★
----------------------------------------------------------*/
function popClose1(strMsg) {
    art.dialog({
        id: 'popclose'
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , ok: function () {
            popCloseAll();
        }
    });
}
/*----------------------------------------------------------
----- 消息提示并关闭类型·二
----------------------------------------------------------*/
function popClose2(strTitle, strMsg) {
    art.dialog({
        id: 'popclose'
        , title: strTitle
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , ok: function () {
            popCloseAll();
        }
    });
}
/*----------------------------------------------------------
----- 消息提示并自动关闭类型·一    ★★★
----------------------------------------------------------*/
function popAutoClose1(strMsg) {
    art.dialog({
        id: 'popautoclose'
        , title: '消息[2秒后关闭]'
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , time: 2
        , icon: 'succeed'
        , cancelVal: '关闭'
        , cancel: function () {
            popCloseAll();
        }
    });
}
/*----------------------------------------------------------
----- 消息提示并自动关闭类型·二
----------------------------------------------------------*/
function popAutoClose2(strTitle, strMsg) {
    strTitle = strTitle + '[2秒后关闭]';
    art.dialog({
        id: 'popautoclose'
        , title: strTitle
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , time: 2
        , icon: 'succeed'
        , cancelVal: '关闭'
        , cancel: function () {
            popCloseAll();
        }
    });
}
/*----------------------------------------------------------
----- 消息提示并自动关闭类型·三
----------------------------------------------------------*/
function popAutoClose3(strMsg, strInterval) {
    var strTitle = '消息[' + strInterval + '秒后关闭]';
    art.dialog({
        id: 'popautoclose'
        , title: strTitle
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , time: strInterval
        , icon: 'succeed'
        , cancelVal: '关闭'
        , cancel: function () {
            popCloseAll();
        }
    });
}
/*----------------------------------------------------------
----- 消息提示并自动关闭类型·四
----------------------------------------------------------*/
function popAutoClose4(strTitle, strMsg, strInterval) {
    strTitle = strTitle + '[' + strInterval + '秒后关闭]';
    art.dialog({
        id: 'popautoclose'
        , title: strTitle
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , time: strInterval
        , icon: 'succeed'
        , cancelVal: '关闭'
        , cancel: function () {
            popCloseAll();
        }
    });
}
/*----------------------------------------------------------
----- 消息提示并自动跳转类型·一    ★★★
----------------------------------------------------------*/
function popAutoJump1(strMsg, strUrl) {
    art.dialog({
        id: 'popautojump'
        , title: '消息[2秒后关闭]'
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , time: 2
        , icon: 'succeed'
        , cancelVal: '关闭'
        , cancel: function () {
            window.location.href = strUrl;
        }
    });
}
/*----------------------------------------------------------
----- 消息提示并自动跳转类型·二
----------------------------------------------------------*/
function popAutoJump2(strTitle, strMsg, strUrl) {
    strTitle = strTitle + '[2秒后关闭]';
    art.dialog({
        id: 'popautojump'
        , title: strTitle
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , time: 2
        , icon: 'succeed'
        , cancelVal: '关闭'
        , cancel: function () {
            window.location.href = strUrl;
        }
    });
}
/*----------------------------------------------------------
----- 消息提示并自动跳转类型·三
----------------------------------------------------------*/
function popAutoJump3(strMsg, strUrl, strInterval) {
    var strTitle = '消息[' + strInterval + '秒后关闭]';
    art.dialog({
        id: 'popautojump'
        , title: strTitle
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , time: strInterval
        , icon: 'succeed'
        , cancelVal: '关闭'
        , cancel: function () {
            window.location.href = strUrl;
        }
    });
}
/*----------------------------------------------------------
----- 消息提示并自动跳转类型·四
----------------------------------------------------------*/
function popAutoJump4(strTitle, strMsg, strUrl, strInterval) {
    strTitle = strTitle + '[' + strInterval + '秒后关闭]';
    art.dialog({
        id: 'popautojump'
        , title: strTitle
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , time: strInterval
        , icon: 'succeed'
        , cancelVal: '关闭'
        , cancel: function () {
            window.location.href = strUrl;
        }
    });
}
/*----------------------------------------------------------
----- 消息提示且父页面自动跳转类型·一    ★★★
----------------------------------------------------------*/
function popAutoParentJump1(strMsg, strUrl) {
    art.dialog({
        id: 'popautoparentjump'
        , title: '消息[2秒后关闭]'
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , time: 2
        , icon: 'succeed'
        , cancelVal: '关闭'
        , cancel: function () {
            parent.location.href = strUrl;            
        }
    });
}
/*----------------------------------------------------------
----- 消息提示且父页面自动跳转类型·二
----------------------------------------------------------*/
function popAutoParentJump2(strTitle, strMsg, strUrl) {
    strTitle = strTitle + '[2秒后关闭]';
    art.dialog({
        id: 'popautoparentjump'
        , title: strTitle
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , time: 2
        , icon: 'succeed'
        , cancelVal: '关闭'
        , cancel: function () {
        	parent.location.href = strUrl;
        }
    });
}
/*----------------------------------------------------------
----- 消息提示且父页面自动跳转类型·三
----------------------------------------------------------*/
function popAutoParentJump3(strMsg, strUrl, strInterval) {
    var strTitle = '消息[' + strInterval + '秒后关闭]';
    art.dialog({
        id: 'popautoparentjump'
        , title: strTitle
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , time: strInterval
        , icon: 'succeed'
        , cancelVal: '关闭'
        , cancel: function () {
        	parent.location.href = strUrl;
        }
    });
}
/*----------------------------------------------------------
----- 消息提示且父页面自动跳转类型·四
----------------------------------------------------------*/
function popAutoParentJump4(strTitle, strMsg, strUrl, strInterval) {
    strTitle = strTitle + '[' + strInterval + '秒后关闭]';
    art.dialog({
        id: 'popautoparentjump'
        , title: strTitle
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , time: strInterval
        , icon: 'succeed'
        , cancelVal: '关闭'
        , cancel: function () {
        	parent.location.href = strUrl;
        }
    });
}
/*----------------------------------------------------------
----- 消息提示并倒计时关闭类型·一    ★★★
----------------------------------------------------------*/
function popTimer1(strMsg) {
    art.dialog({
        id: 'poptimer'
        , title: '消息[2秒后关闭]'
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , time: 2
    });
}
/*----------------------------------------------------------
----- 消息提示并倒计时关闭类型·二
----------------------------------------------------------*/
function popTimer2(strTitle, strMsg) {
    art.dialog({
        id: 'poptimer'
        , title: strTitle + '[2秒后关闭]'
		, content: strMsg
        , lock: true
        , padding: '20px 25px'
        , time: 2
    });
}
/*----------------------------------------------------------
----- 消息提示并倒计时关闭类型·三
----------------------------------------------------------*/
function popTimer3(strMsg, strInterval) {
    var strTitle = '消息[' + strInterval + '秒后关闭]';
    art.dialog({
        id: 'poptimer'
        , title: strTitle
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , time: strInterval
    });
}
/*----------------------------------------------------------
----- 消息提示并倒计时关闭类型·四
----------------------------------------------------------*/
function popTimer4(strTitle, strMsg, strInterval) {
	strTitle = strTitle + '[' + strInterval + '秒后关闭]';
    art.dialog({
        id: 'poptimer'
        , title: strTitle
		, content: strMsg
        , lock: true
        , padding: '20px 25px'
        , time: strInterval
    });
}
/*----------------------------------------------------------
----- 弹出窗口类型·一    ★★★
----------------------------------------------------------*/
function popWid1(url) {
    art.dialog.open(url, {
        id: 'popwidusual1'
        , title: '操作'
        , width: 660
        , height: 550
        , lock: true
        , padding: '20px 25px'
    });
}
/*----------------------------------------------------------
----- 弹出窗口类型·二
----------------------------------------------------------*/
function popWid2(strTitle, url) {
    art.dialog.open(url, {
        id: 'popwidusual2'
        , title: strTitle
        , width: 660
        , height: 550
        , lock: true
        , padding: '20px 25px'
    });
}
/*----------------------------------------------------------
----- 弹出窗口类型·三
----------------------------------------------------------*/
function popWid3(url, strWeight, strHeight) {
    art.dialog.open(url, {
        id: 'popwidusual3'
        , title: '操作'
        , width: strWeight
        , height: strHeight
        , lock: true
        , padding: '20px 25px'
    });
}
/*----------------------------------------------------------
----- 弹出窗口类型·四
----------------------------------------------------------*/
function popWid4(strTitle, url, strWeight, strHeight) {
    art.dialog.open(url, {
        id: 'popwidusual4'
        , title: strTitle
        , width: strWeight
        , height: strHeight
        , lock: true
        , padding: '20px 25px'
    });
}
/*----------------------------------------------------------
----- 弹出窗口并刷新父窗口类型·一    ★★★
----------------------------------------------------------*/
function popRefresh1(url) {
    art.dialog.open(url, {
        id: 'popadvanced1'
        , title: '操作'
        , width: 660
        , height: 550
        , lock: true
        , padding: '20px 25px'
        , close: function () {
            loadContent();
        }
    });
}
/*----------------------------------------------------------
----- 弹出窗口并刷新父窗口类型·二
----------------------------------------------------------*/
function popRefresh2(strTitle, url) {
    art.dialog.open(url, {
        id: 'popadvanced2'
        , title: strTitle
        , width: 660
        , height: 550
        , lock: true
        , padding: '20px 25px'
        , close: function () {
            loadContent();
        }
    });
}
/*----------------------------------------------------------
----- 弹出窗口并刷新父窗口类型·三
----------------------------------------------------------*/
function popRefresh3(url, strWeight, strHeight) {
    art.dialog.open(url, {
        id: 'popadvanced3'
        , title: '操作'
        , width: strWeight
        , height: strHeight
        , lock: true
        , padding: '20px 25px'
        , close: function () {
            loadContent();
        }
    });
}
/*----------------------------------------------------------
----- 弹出窗口并刷新父窗口类型·四
----------------------------------------------------------*/
function popRefresh4(strTitle, url, strWeight, strHeight) {
    art.dialog.open(url, {
        id: 'popadvanced4'
        , title: strTitle
        , width: strWeight
        , height: strHeight
        , lock: true
        , padding: '20px 25px'
        , close: function () {
            loadContent();
        }
    });
}
/*----------------------------------------------------------
----- 弹出窗口并赋于指定对象传递值类型·一    ★★★
----------------------------------------------------------*/
function popWidSetval1(tranArry, objArry, url) {
    art.dialog.open(url, {
        id: 'popsuper1'
        , title: '操作'
        , width: 660
        , height: 550
        , lock: true
        , padding: '20px 25px'
        , close: function () {
            if (tranArry.length == objArry.length) {
                for (var i = 0; i < tranArry.length; i++) {
                    var ctl = '#';
                    ctl += objArry[i];
                    $(ctl).val(popDataPass(tranArry[i]));
                    art.dialog.removeData(tranArry[i]);
                }
            }
        }
    });
}
/*----------------------------------------------------------
----- 弹出窗口并赋于指定对象传递值类型·二
----------------------------------------------------------*/
function popWidSetval2(tranArry, objArry, strTitle, url) {
    art.dialog.open(url, {
        id: 'popsuper2'
        , title: strTitle
        , width: 660
        , height: 550
        , lock: true
        , padding: '20px 25px'
        , close: function () {
            if (tranArry.length == objArry.length) {
                for (var i = 0; i < tranArry.length; i++) {
                    var ctl = '#';
                    ctl += objArry[i];
                    $(ctl).val(popDataPass(tranArry[i]));
                    art.dialog.removeData(tranArry[i]);
                }
            }
        }
    });
}
/*----------------------------------------------------------
----- 弹出窗口并赋于指定对象传递值类型·三
----------------------------------------------------------*/
function popWidSetval3(tranArry, objArry, url, strWeight, strHeight) {
    art.dialog.open(url, {
        id: 'popsuper3'
        , title: '操作'
        , width: strWeight
        , height: strHeight
        , lock: true
        , padding: '20px 25px'
        , close: function () {
            if (tranArry.length == objArry.length) {
                for (var i = 0; i < tranArry.length; i++) {
                    var ctl = '#';
                    ctl += objArry[i];
                    $(ctl).val(popDataPass(tranArry[i]));
                    art.dialog.removeData(tranArry[i]);
                }
            }
        }
    });
}
/*----------------------------------------------------------
----- 弹出窗口并赋于指定对象传递值类型·四
----------------------------------------------------------*/
function popWidSetval4(tranArry, objArry, strTitle, url, strWeight, strHeight) {
    art.dialog.open(url, {
        id: 'popsuper4'
        , title: strTitle
        , width: strWeight
        , height: strHeight
        , lock: true
        , padding: '20px 25px'
        , close: function () {
            if (tranArry.length == objArry.length) {
                for (var i = 0; i < tranArry.length; i++) {
                    var ctl = '#';
                    ctl += objArry[i];
                    $(ctl).val(popDataPass(tranArry[i]));
                    art.dialog.removeData(tranArry[i]);
                }
            }
        }
    });
}
/*----------------------------------------------------------
----- 关闭所有弹出窗口    ★★★
----------------------------------------------------------*/
var popCloseAll = function () {    
    var list = art.dialog.list;
    for (var i in list) {
        list[i].close();
    };
    art.dialog.close();
};
/*----------------------------------------------------------
----- 跟随指定元素弹出窗口    ★★★
----------------------------------------------------------*/
var popFollowTo = function (param) {
    popCloseAll();
    art.dialog(param);
};