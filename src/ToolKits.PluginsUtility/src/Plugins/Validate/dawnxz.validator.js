Dawn.Validator = {
    SimplexError: function (chkObj) {
        //文本框状态
        $(chkObj).removeClass('validator-pass');
        $(chkObj).addClass('validator-error');
    },
    SimplexPass: function (chkObj) {
        //文本框状态
        $(chkObj).removeClass('validator-error');
        $(chkObj).addClass('validator-pass');
    },
    Simplex: function (isSelect, chkObj, regObj) {
        if (chkObj == undefined || regObj == undefined) return false;
        if (chkObj == 'undefined' || regObj == 'undefined') return false;
        if (chkObj == '' || regObj == '') return false;
        var value = $(chkObj).val();
        var result = false;
        if (isSelect) {
            result = value <= 0 ? false : true;
        }
        else {
            result = new RegExp(Dawn.Regular[regObj]).test(value);
        }
        if (!result) {
            this.SimplexError(chkObj);
            $(chkObj).focus();
        }
        else {
            this.SimplexPass(chkObj);
        }
        return !result ? 0 : 1;
    },
    TipsError: function (chkObj, msgObj, icoObj) {
        //ICO图标
        $(icoObj).removeClass('validator-ico-pass');
        $(icoObj).addClass('validator-ico-error');
        //颜色标识
        $(msgObj).removeClass('color-blue');
        $(msgObj).addClass('color-red');
        //文本框状态
        $(chkObj).removeClass('validator-pass');
        $(chkObj).addClass('validator-error');
    },
    TipsPass: function (chkObj, msgObj, icoObj) {
        //ICO图标
        $(icoObj).removeClass('validator-ico-error');
        $(icoObj).addClass('validator-ico-pass');
        //颜色标识
        $(msgObj).removeClass('color-red');
        $(msgObj).addClass('color-blue');
        //文本框状态
        $(chkObj).removeClass('validator-error');
        $(chkObj).addClass('validator-pass');
    },
    Exec: function (chkObj, msgObj, icoObj, info, regObj) {
        if (chkObj == undefined || msgObj == undefined || icoObj == undefined || regObj == undefined) return false;
        if (chkObj == 'undefined' || msgObj == 'undefined' || icoObj == 'undefined' || regObj == 'undefined') return false;
        if (chkObj == '' || msgObj == '' || icoObj == '' || regObj == '') return false;
        var value = $(chkObj).val();
        var result = new RegExp(Dawn.Regular[regObj]).test(value);
        if (!result) {
            if (info == 'undefined' || info == '' || info != 'object') {
                $(msgObj).text(Dawn.RegularTips[regObj].warn);
            }
            else {
                $(msgObj).text(info.warn);
            }
            this.TipsError(chkObj, msgObj, icoObj);
            $(chkObj).focus();
        }
        else {
            if (info == undefined || info == 'undefined' || info == '' || info != 'object') {
                $(msgObj).text(Dawn.RegularTips[regObj].tips);
            }
            else {
                $(msgObj).text(info.tips);
            }
            this.TipsPass(chkObj, msgObj, icoObj);
        }
        return !result ? 0 : 1;
    },
    Selector: function (chkObj, msgObj, icoObj, info) {
        if (chkObj == 'undefined' || msgObj == 'undefined' || icoObj == 'undefined') return false;
        if (chkObj == '' || msgObj == '' || icoObj == '') return false;
        var value = $(chkObj).val();
        var result = value <= 0 ? false : true;
        if (!result) {
            if (info == 'undefined' || info == '' || info != 'object') {
                $(msgObj).text(Dawn.RegularTips['Selector'].warn);
            }
            else {
                $(msgObj).text(info.warn);
            }
            this.TipsError(chkObj, msgObj, icoObj);
            $(chkObj).focus();
        }
        else {
            if (info == 'undefined' || info == '' || info != 'object') {
                $(msgObj).text(Dawn.RegularTips['Selector'].tips);
            }
            else {
                $(msgObj).text(info.tips);
            }
            this.TipsPass(chkObj, msgObj, icoObj);
        }
        return !result ? 0 : 1;
    },
    IsEmpty: function (chkObj, msgObj, icoObj, info) {
        if (chkObj == 'undefined' || msgObj == 'undefined' || icoObj == 'undefined') return false;
        if (chkObj == '' || msgObj == '' || icoObj == '') return false;
        var value = $(chkObj).val();
        var result = value <= 0 ? true : false;
        if (result) {
            if (info == 'undefined' || info == '' || info != 'object') {
                $(msgObj).text(Dawn.RegularTips['IsEmpty'].warn);
            }
            else {
                $(msgObj).text(info.warn);
            }
            this.TipsError(chkObj, msgObj, icoObj);
            $(chkObj).focus();
        }
        else {
            if (info == 'undefined' || info == '' || info != 'object') {
                $(msgObj).text(Dawn.RegularTips['IsEmpty'].tips);
            }
            else {
                $(msgObj).text(info.tips);
            }
            this.TipsPass(chkObj, msgObj, icoObj);
        }
        return result ? 0 : 1;
    },
    IsDate: function (chkObj, msgObj, icoObj, info) {
        if (chkObj == 'undefined' || msgObj == 'undefined' || icoObj == 'undefined') return false;
        if (chkObj == '' || msgObj == '' || icoObj == '') return false;
        var value = $(chkObj).val();
        var result = Dawn.Regular.IsDate(value);
        if (!result) {
            if (info == 'undefined' || info == '' || info != 'object') {
                $(msgObj).text(Dawn.RegularTips['IsDate'].warn);
            }
            else {
                $(msgObj).text(info.warn);
            }
            this.TipsError(chkObj, msgObj, icoObj);
            $(chkObj).focus();
        }
        else {
            if (info == 'undefined' || info == '' || info != 'object') {
                $(msgObj).text(Dawn.RegularTips['IsDate'].tips);
            }
            else {
                $(msgObj).text(info.tips);
            }
            this.TipsPass(chkObj, msgObj, icoObj);
        }
        return !result ? 0 : 1;
    },
    /*----------------------------------------------------------
    ----    电子邮件
    ----------------------------------------------------------*/
    IsEmail: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'IsEmail');
    },
    IsEmailValid: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'IsEmailValid');
    },
    /*----------------------------------------------------------
    ----    中文验证
    ----------------------------------------------------------*/
    ChsIsTname: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'ChsIsTname');
    },
    ChsIsChinese: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'ChsIsChinese');
    },
    ChsIsChineseOrEngOrNum: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'ChsIsChineseOrEngOrNum');
    },
    ChsIsChineseOrEngOrNums: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'ChsIsChineseOrEngOrNums');
    },
    ChsIsText: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'ChsIsText');
    },
    ChsIsTexts: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'ChsIsTexts');
    },
    ChsIsMemo: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'ChsIsMemo');
    },
    ChsIsMemos: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'ChsIsMemos');
    },
    ChsIsAddress: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'ChsIsAddress');
    },
    /*----------------------------------------------------------
    ----    英文验证
    ----------------------------------------------------------*/
    EngIsPwd: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'EngIsPwd');
    },
    EngIsPassword: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'EngIsPassword');
    },
    EngIsPasswords: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'EngIsPasswords');
    },
    EngIsRegister: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'EngIsRegister');
    },
    EngIsRegisters: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'EngIsRegisters');
    },
    EngIsEnglish: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'EngIsEnglish');
    },
    EngIsUppercase: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'EngIsUppercase');
    },
    EngIsLowercase: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'EngIsLowercase');
    },
    EngIsEngAndNum: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'EngIsEngAndNum');
    },
    EngIsEngAndNums: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'EngIsEngAndNums');
    },
    EngIsEngAndNumComma: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'EngIsEngAndNumComma');
    },
    EngIsEngAndNumOrUnderline: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'EngIsEngAndNumOrUnderline');
    },
    /*----------------------------------------------------------
    ----    数字验证
    ----------------------------------------------------------*/
    NumIsByteTinyint: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'NumIsByteTinyint');
    },
    NumIsInteger: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'NumIsInteger');
    },
    NumIsZeroOrNot: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'NumIsZeroOrNot');
    },
    NumIsPlus2Point: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, info, icoObj, 'NumIsPlus2Point');
    },
    NumIsPlus3Point: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'NumIsPlus3Point');
    },
    NumIsIntegralBySignless: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'NumIsIntegralBySignless');
    },
    NumIsIntegralByNegative: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'NumIsIntegralByNegative');
    },
    NumIsFloatBySignless: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'NumIsFloatBySignless');
    },
    NumIsFloatByNegative: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'NumIsFloatByNegative');
    },
    NumIsDouble: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'NumIsDouble');
    },
    NumIsDoubles: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'NumIsDoubles');
    },
    NumIsMoney: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'NumIsMoney');
    },
    /*----------------------------------------------------------
    ----    电话号码
    ----------------------------------------------------------*/
    TelIsAnyPhone: function (chkObj, msgObj, icoObj, info) {
    	var result = this.Exec(chkObj, msgObj, icoObj, info, 'TelIsTelephoneAny');
    	if (result == 0) {
    		result = this.Exec(chkObj, msgObj, icoObj, info, 'TelIsMobileAny');
    	}
    	return result;
    },
    TelIsAllPhone: function (chkObj, msgObj, icoObj, info) {
    	var result = this.Exec(chkObj, msgObj, icoObj, info, 'TelIsTelephone');
    	if (result == 0) {
    		result = this.Exec(chkObj, msgObj, icoObj, info, 'TelIsChinaMobile');
    	}
    	if (result == 0) {
    		result = this.Exec(chkObj, msgObj, icoObj, info, 'TelIsChinaUnicom');
    	}
    	if (result == 0) {
    		result = this.Exec(chkObj, msgObj, icoObj, info, 'TelIsChinaTelecom');
    	}
    	return result;
    },
    TelIsTelephoneAny: function (chkObj, msgObj, icoObj, info) {
    	return this.Exec(chkObj, msgObj, icoObj, info, 'TelIsTelephoneAny');
    },
    TelIsTelephone: function (chkObj, msgObj, icoObj, info) {
    	return this.Exec(chkObj, msgObj, icoObj, info, 'TelIsTelephone');
    },
    TelIsMobile: function (chkObj, msgObj, icoObj, info) {
    	var result = this.Exec(chkObj, msgObj, icoObj, info, 'TelIsChinaMobile');
    	if (result == 0) {
    		result = this.Exec(chkObj, msgObj, icoObj, info, 'TelIsChinaUnicom');
    	}
    	if (result == 0) {
    		result = this.Exec(chkObj, msgObj, icoObj, info, 'TelIsChinaTelecom');
    	}
    	return result;
    },
    TelIsMobileAny: function (chkObj, msgObj, icoObj, info) {
    	return this.Exec(chkObj, msgObj, icoObj, info, 'TelIsMobileAny');
    },
    TelIsChinaMobile: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'TelIsChinaMobile');
    },
    TelIsChinaUnicom: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'TelIsChinaUnicom');
    },
    TelIsChinaTelecom: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'TelIsChinaTelecom');
    },
    /*----------------------------------------------------------
    ----    IP 地址
    ----------------------------------------------------------*/
    IsIP: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'IsIP');
    },
    IsIPs: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'IsIPs');
    },
    IsIPSect: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'IsIPSect');
    },
    /*----------------------------------------------------------
    ----    常规验证
    ----------------------------------------------------------*/
    IdCard: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'IdCard');
    },
    IsURL: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'IsURL');
    },
    IsPost: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'IsPost');
    },
    UnSafe: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'UnSafe');
    },
    IsPer: function (chkObj, msgObj, icoObj, info) {
        return this.Exec(chkObj, msgObj, icoObj, info, 'IsPer');
    },
    //检测密码的安全级别，并设置相应级别提示的背景图片
    PwdCheckLevel: function (pwd, level) {
        var n = this.PwdGetLevel(pwd);
        $('#' + level).attr('class', 'security-level' + n);
    },
    //获得密码输入框的密码的安全级别
    PwdGetLevel: function (pwd) {
        var l = pwd.length, min = 6, level = 0;
        if (l < min) {
            if (l > 0) {
                level = 1;
            }
        }
        else {
            if (/^(\d{6,9}|[a-z]{6,9}|[A-Z]{6,9})$/.test(pwd)) {
                level = 1;
            }
            else {
                if (/^[^a-z\d]{6,8}$/i.test(pwd) || !/^(\d{6,9}|[a-z]{6,9}|[A-Z]{6,9})$/.test(pwd)) {
                    level = 2;
                }
            }
            if (!/^(([A-Z]*|[a-z]*|\d*|[-_\~!@#\$%\^&\*\.\(\)\[\]\{\}<>\?\\\/\'\"]*)|.{0,5})$|\s/.test(pwd)) {
                level = l < 10 ? 3 : 4;
            }
        }
        return level;
    }
};