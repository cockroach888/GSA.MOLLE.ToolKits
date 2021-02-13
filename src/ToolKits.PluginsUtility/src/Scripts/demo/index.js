'use strict';
/*----------------------------------------------------------
----    页面加载完成后立即执行代码
----------------------------------------------------------*/
$(function () {
	$('#txtDatetimes1').datetimepicker();
	$('#txtDatetimes2').datetimepicker({
		allowTimes: ['12:00', '13:00', '15:00', '17:00', '17:05', '17:20', '19:00', '20:00']
	});
	var logic = function (currentDateTime) {
		if (currentDateTime.getDay() == 6) {
			this.setOptions({
				minTime: '11:00'
			});
		} else
			this.setOptions({
				minTime: '8:00'
			});
	};
	$('#txtDatetimes3').datetimepicker({
		onChangeDateTime: logic,
		onShow: logic
	});
	$('#txtDatetimes4').datetimepicker({
		onGenerate: function (ct) {
			$(this).find('.xdsoft_date.xdsoft_weekend')
				.addClass('xdsoft_disabled');
		},
		weekends: ['01.01.2014', '02.01.2014', '03.01.2014', '04.01.2014', '05.01.2014', '06.01.2014'],
		timepicker: false
	});
	// CustomAttrib
	$('input[datepicker=1]').datetimepicker({
		format: 'Y-m-d',
		timepicker: false
	});
});
/*----------------------------------------------------------
----    重新初始化页面大小
----------------------------------------------------------*/
$(window).resize(function () {

});