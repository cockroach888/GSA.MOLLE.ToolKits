/*----------------------------------------------------------
----    数据分页
----  1.strUrl 数据获取路径地址
----  2.pageNumber 当前数据分页页码
----  3.parameter 附加参数，格式必须为单个或键值对：
[5] 或 'uid,1,uname,admin'
------------------------------------------------------------
DawnPagerHandler('/Home/Index/', 1, 'uid,1,uname,admin')
----------------------------------------------------------*/
function DawnPagerHandler(strUrl, pageNumber, parameter) {
	var objData = [
        { name: 'pager', value: pageNumber }
	];
	if (parameter != undefined || parameter != 'undefined' || parameter != null || parameter != '') {
		if (parameter != 'Nothing,Nothing') {
			parameter = parameter.split(',');
			if (Object.prototype.toString.call(parameter) === '[object Array]') {
				if (parameter.length == 2) {
					objData = [
                        { name: 'pager', value: pageNumber }
                        , { name: parameter[0], value: parameter[1] }
					];
				}
				else if (parameter.length > 2 && parameter.length % 2 == 0) {
					objData = '[';
					objData += "{ name : 'pager', value: '" + pageNumber + "' }";
					for (var i = 0; i < parameter.length; i += 2) {
						objData += ", { name: '" + parameter[i] + "', value: '" + parameter[i + 1] + "' }";
					}
					objData += ']';
					objData = eval(objData);
				}
			}
		}
	}
	$.ajax({
		url: strUrl
		, data: objData
		, type: 'POST'
		, success: function (data) {
			$('#dataShowArea').html($(data).find('#dataShowArea').html());
			$('#pagerList').html($(data).find('#pagerList').html());
			$('tbody tr:odd').addClass("alt-row");
		}
		, error: function (msg) {
			//alert('获取分页数据时出现未知异常！请重试或联系管理员！');
			popMsg1('获取分页数据时出现未知异常！请重试或联系管理员！');
		}
	});
}
function DawnPagerHandlerOf(pageNumber, parameter) {
	var objData = [
        { name: 'pager', value: pageNumber }
	];
	if (parameter != undefined || parameter != 'undefined' || parameter != null || parameter != '') {
		if (parameter != 'Nothing,Nothing') {
			parameter = parameter.split(',');
			if (Object.prototype.toString.call(parameter) === '[object Array]') {
				if (parameter.length == 2) {
					objData = [
                        { name: 'pager', value: pageNumber }
                        , { name: parameter[0], value: parameter[1] }
					];
				}
				else if (parameter.length > 2 && parameter.length % 2 == 0) {
					objData = '[';
					objData += "{ name : 'pager', value: '" + pageNumber + "' }";
					for (var i = 0; i < parameter.length; i += 2) {
						objData += ", { name: '" + parameter[i] + "', value: '" + parameter[i + 1] + "' }";
					}
					objData += ']';
					objData = eval(objData);
				}
			}
		}
	}
	loadContent(objData);
}
/*----------------------------------------------------------
----    数据分页
----  1.strUrl 数据获取路径地址
----  2.pageNumber 当前数据分页页码
----  3.parameter 附加参数，格式必须为单个或键值对：
[5] 或 'uid,1,uname,admin'
------------------------------------------------------------
DawnPagerMvc('/Home/Index/', 1, 'uid,1,uname,admin')
----------------------------------------------------------*/
function DawnPagerMvc(strUrl, pageNumber, parameter) {
	var objData = [
        { name: 'id', value: pageNumber }
	];
	if (parameter != undefined || parameter != 'undefined' || parameter != null || parameter != '') {
		if (parameter.indexOf(',') == 0) {
			objData = [
                { name: 'id', value: parameter }
                , { name: 'pager', value: pageNumber }
			];
		}
		else if (parameter != 'Nothing,Nothing') {
			parameter = parameter.split(',');
			if (Object.prototype.toString.call(parameter) === '[object Array]' && parameter.length % 2 == 0) {
				objData = '[';
				objData += "{ name : 'pager', value: '" + pageNumber + "' }";
				for (var i = 0; i < parameter.length; i += 2) {
					objData += ", { name: '" + parameter[i] + "', value: '" + parameter[i + 1] + "' }";
				}
				objData += ']';
				objData = eval(objData);
			}
		}
	}
	$.ajax({
		url: strUrl
        , data: objData
        , type: 'POST'
        , success: function (data) {
        	$('#dataShowArea').html($(data).find('#dataShowArea').html());
        	$('#pagerList').html($(data).find('#pagerList').html());
        	$('tbody tr:odd').addClass("alt-row");
        }
        , error: function (msg) {
        	//alert('获取分页数据时出现未知异常！请重试或联系管理员！');
        	popMsg1('获取分页数据时出现未知异常！请重试或联系管理员！');
        }
	});
}
function DawnPagerMvcOf(pageNumber, parameter) {
	var objData = [
        { name: 'id', value: pageNumber }
	];
	if (parameter != undefined || parameter != 'undefined' || parameter != null || parameter != '') {
		if (parameter.indexOf(',') == 0) {
			objData = [
                { name: 'id', value: parameter }
                , { name: 'pager', value: pageNumber }
			];
		}
		else if (parameter != 'Nothing,Nothing') {
			parameter = parameter.split(',');
			if (Object.prototype.toString.call(parameter) === '[object Array]' && parameter.length % 2 == 0) {
				objData = '[';
				objData += "{ name : 'pager', value: '" + pageNumber + "' }";
				for (var i = 0; i < parameter.length; i += 2) {
					objData += ", { name: '" + parameter[i] + "', value: '" + parameter[i + 1] + "' }";
				}
				objData += ']';
				objData = eval(objData);
			}
		}
	}
	loadContent(objData);
}
/*----------------------------------------------------------
----    数据分页
----  1.strUrl 数据获取路径地址
----  2.pageNumber 当前数据分页页码
----  3.parameter 附加参数，格式必须为单个或键值对：
[5] 或 'uid,1,uname,admin'
------------------------------------------------------------
DawnPagerUrl('/Home/Index/', 1, 'uid,1,uname,admin')
----------------------------------------------------------*/
function DawnPagerUrl(strUrl, pageNumber, parameter) {
	if (strUrl.substr(strUrl.length - 1) != '/') strUrl += '/';
	parameter = parameter.split(',');
	if (parameter == undefined || parameter == 'undefined' || parameter == null || parameter == '') {
		strUrl += pageNumber;
	}
	else if (parameter.length > 1) {
		strUrl += pageNumber;
		for (var i = 0; i < parameter.length; i++) {
			strUrl += '/';
			strUrl += parameter[0];
		}
	}
	else {
		strUrl += pageNumber;
		strUrl += '/';
		strUrl += parameter[i];
	}
	$.ajax({
		url: strUrl
        , type: 'GET'
        , success: function (data) {
        	$('#dataShowArea').html($(data).find('#dataShowArea').html());
        	$('#pagerList').html($(data).find('#pagerList').html());
        	$('tbody tr:odd').addClass("alt-row");
        }
        , error: function (msg) {
        	//alert('获取分页数据时出现未知异常！请重试或联系管理员！');
        	popMsg1('获取分页数据时出现未知异常！请重试或联系管理员！');
        }
	});
}
function DawnPagerUrlOf(pageNumber, parameter) {
	var strUrl = '/';
	parameter = parameter.split(',');
	if (parameter == undefined || parameter == 'undefined' || parameter == null || parameter == '') {
		strUrl += pageNumber;
	}
	else if (parameter.length > 1) {
		strUrl += pageNumber;
		for (var i = 0; i < parameter.length; i++) {
			strUrl += '/';
			strUrl += parameter[0];
		}
	}
	else {
		strUrl += pageNumber;
		strUrl += '/';
		strUrl += parameter[i];
	}
	loadContent(strUrl);
}
/*----------------------------------------------------------
----    数据分页跳转功能
------------------------------------------------------------
DawnPagerGotoHref('/Home/Index?pager=', 'uid,1,uname,admin')
----------------------------------------------------------*/
function DawnPagerGotoHref(urlPath, parameter) {
	if (urlPath.length < 1) return false;
	var pagerIndex = $Dawn$('txtPagerIndex');
	var pagerMax = $Dawn$('hidPagerMax');
	if (pagerIndex > pagerMax) pagerIndex = pagerMax;
	var result = urlPath;
	result += pagerIndex;
	result += parameter;
	window.location.href = result;
}
/*----------------------------------------------------------
----    数据分页跳转功能
------------------------------------------------------------
DawnPagerGoto('/Home/Index/', 'uid,1,uname,admin')
----------------------------------------------------------*/
function DawnPagerGoto(urlPath, funName, parameter) {
	if (urlPath.length < 1 || funName.length < 1) return false;
	var pagerIndex = $Dawn$('txtPagerIndex');
	var pagerMax = $Dawn$('hidPagerMax');
	if (pagerIndex > pagerMax) pagerIndex = pagerMax;
	var result = funName;
	result += '(';
	result += "'";
	result += urlPath;
	result += "'";
	result += ',';
	result += pagerIndex;
	result += ',';
	result += "'";
	result += parameter;
	result += "'";
	result += ')';
	eval(result);
}
/*----------------------------------------------------------
----    数据分页跳转功能
------------------------------------------------------------
DawnPagerGotoOf('DawnPagerHandlerOf', 'uid,1,uname,admin')
----------------------------------------------------------*/
function DawnPagerGotoOf(funName, parameter) {
	if (funName.length < 1) return false;
	var pagerIndex = $Dawn$('txtPagerIndex');
	var pagerMax = $Dawn$('hidPagerMax');
	if (pagerIndex > pagerMax) pagerIndex = pagerMax;
	var result = funName;
	result += '(';
	result += pagerIndex;
	result += ',';
	result += "'";
	result += parameter;
	result += "'";
	result += ')';
	eval(result);
}
/*----------------------------------------------------------
----    对象获取功能函数
----------------------------------------------------------*/
var $Dawn$ = function (objId) {
	return parseInt(document.getElementById(objId).value);
}