/*----------------------------------------------------------
----    登录
----------------------------------------------------------*/
var countErr = 0;
var entryCheck = function () {
    var txtCheckCode = $('#txt-checkcode').val();
    var codeRule = /^[A-Za-z0-9]{4}$/;
    if (!new RegExp(codeRule).test(txtCheckCode)) {
        ShowTips('您输入的验证码不正确[4个字符]。', 1);
        $('#txt-checkcode').focus();
        return false;
    }
    var cookieCode = $.cookie('QTXgt7AC5q5aLlVLwpTw');
    if (cookieCode != undefined || cookieCode != 'undefined' || cookieCode != null || cookieCode != '') {
        cookieCode = cookieCode.toLocaleLowerCase();
        if (txtCheckCode.toLocaleLowerCase() != cookieCode) {
            ShowTips('验证码不正确，请重新输入。', 1);
            $('#img-checkcode').trigger('click');
            $('#txt-checkcode').focus();
            return false;
        }
    }
    else {
        ShowTips('验证码已过期，请重新输入。', 1);
        $('#img-checkcode').trigger('click');
        $('#txt-checkcode').focus();
        return false;
    }
    var txtUname = $('#txt-uname').val();
    var nameRule = /^[a-zA-Z]{1}([a-zA-Z0-9]){3,15}$/;
    if (!new RegExp(nameRule).test(txtUname)) {
        ShowTips('您输入的用户名不正确[4-16个字符]。', 1);
        $('#txt-uname').focus();
        return false;
    }
    var txtUpwd = $('#txt-upwd').val();
    var pwdRule = /(.){5,15}$/;
    if (!new RegExp(pwdRule).test(txtUpwd)) {
        ShowTips('您输入的密码不正确[6-16个字符]。', 1);
        $('#txt-upwd').focus();
        return false;
    }
    var token = $('input[name="__RequestVerificationToken"]').val();
    var backUrl = $('#hidReturnUrl').val();
    ShowTips('在登录中鸟，稍等片刻...', 2);
    if ($('#remember-long').val() == 1) {//记住密码
        $.cookie('Xo4eP0XyDpFpCRXzEA4s', txtUname, { expires: 7, path: '/' });
        $.cookie('Yuv9vPVRdqOxUSTv4CTX', txtUpwd, { expires: 7, path: '/' });
    }
    else if ($('#remember-long').val() == 0) {//没有记住密码
        $.cookie('Xo4eP0XyDpFpCRXzEA4s', '', { expires: 7, path: '/' });
        $.cookie('Yuv9vPVRdqOxUSTv4CTX', '', { expires: 7, path: '/' });
    }
    var objData = [
        { name: '__RequestVerificationToken', value: token }
        , { name: 'hidReturnUrl', value: backUrl }
        , { name: 'txtUname', value: txtUname }
        , { name: 'txtUpwd', value: txtUpwd }
        , { name: 'txtCheckCode', value: txtCheckCode }
    ];
    $.ajax({
        url: '/Auth/Logined'
        , data: objData
        , dataType: 'json'
        , type: 'POST'
        , success: function (data) {
            if (data.Msg == 'success') {
                window.location.href = data.Url;
            }
            else if (data.Msg == 'refresh') {
                window.location.reload();
            }
            else {
                if (data.IsCode) $('#img-checkcode').trigger('click');
                ShowTips(data.Msg, 3);
            }
        }
        , error: function (msg) {            
            ShowTips('您的操作有误，请重试！', 3);
            countErr += 1;
            if (countErr > 1) window.location.reload();
        }
    });
}
/*----------------------------------------------------------
----    显示提示信息
----------------------------------------------------------*/
var ShowTips = function (msg, flag) {
    $('#info-tips').text(msg);
    if (flag == 2) {
        $('.notification').removeClass('information');
        $('.notification').removeClass('error');
        $('.notification').removeClass('attention');
        $('.notification').addClass('success');
    }
    else if (flag == 3) {
        $('.notification').removeClass('information');
        $('.notification').removeClass('error');
        $('.notification').removeClass('success');
        $('.notification').addClass('attention');
    }
    else {
        $('.notification').removeClass('information');
        $('.notification').removeClass('success');
        $('.notification').removeClass('attention');
        $('.notification').addClass('error');
    }
}
/*----------------------------------------------------------
----    记住我
----------------------------------------------------------*/
var checkClick = function () {
    if ($('#remember-long').val() == 1) {
        $('#remember-long').removeProp('checked');
        $('#remember-long').val('0');
    }
    else {
        $('#remember-long').prop('checked', 'checked');
        $('#remember-long').val('1');
    }
}
/*----------------------------------------------------------
----    页面加载完成之后执行自动登录检查
----------------------------------------------------------*/
var rememberPassword = function () {
    var ckname = $.cookie('Xo4eP0XyDpFpCRXzEA4s');
    var ckpwd = $.cookie('Yuv9vPVRdqOxUSTv4CTX');
    if (ckname != '' && ckpwd != '' && ckname != null && ckpwd != null) {
        $('#remember-long').val('1');
        $('#remember-long').prop('checked', 'checked');
        $('#txt-uname').val(ckname); //用户名
        $('#txt-upwd').val(ckpwd); //用户密码
        var logout = $.cookie('logout'); //判断用户是否是从内部退出
        if (logout == 'safe') {
            $.cookie('logout', '', { expires: 1, path: '/' });
            var result = confirm('是否清除保存的[用户名]和[密码]？');
            if (result) {
                $.clearCookie();
                $('#img-checkcode').trigger('click');
                top.window.close();
            }
            else {
                top.window.close();
            }
        }
        else if (logout == 'unsafe') {
            $.cookie('logout', '', { expires: 1, path: '/' });
            var result = confirm('是否清除保存的[用户名]和[密码]？');
            if (result) {
                $.clearCookie();
                $('#img-checkcode').trigger('click');
                rememberPassword();
            }
        }
        else {
            $.cookie('logout', '', { expires: 1, path: '/' });
        }
    }
    else {
        $('#remember-long').val('0');
        $('#remember-long').removeProp('checked');
        $('#txt-uname').val(''); //用户名
        $('#txt-upwd').val(''); //用户密码
    }    
}
/*----------------------------------------------------------
----- 宽高比动态计算
----------------------------------------------------------*/
var dynSetGlobalHeight = function () {
    var headerH = $('header').height();
    var footerH = $('footer').height();
    var windowH = $(window).height();
    var loginH = windowH - headerH - footerH - 1;
    $('#login-content').height(loginH);
};
/*----------------------------------------------------------
----    页面加载完成后立即执行代码
----------------------------------------------------------*/
$(function () {
    dynSetGlobalHeight();
    //验证码
    $('#img-checkcode').bind('click', function () {
        var url = '/Auth/CheckCode/';
        url += (new Date()).getTime();
        this.src = url;
    });
    $('.code-change').bind('click', function () {
        $('#img-checkcode').trigger('click');
    });
    $('.button').bind('click', function () {
        entryCheck();
    });
    //记住我
    $('.remember').bind('click', function () {
        checkClick();
    });
    $('#remember-long').click(function () {
        checkClick();
    });
    rememberPassword();
    $('#img-checkcode').trigger('click');
    if (self.location != top.location) {
        top.location.href = '/Auth/Login';
    }
});
/*----------------------------------------------------------
----    重新初始化页面大小
----------------------------------------------------------*/
$(window).resize(function () {
    dynSetGlobalHeight();
});