/*----------------------------------------------------------
----    数据保存
----------------------------------------------------------*/
function dataSave() {
    if (!dataCheck()) return false;
    if($('#txtOldPwd').val() == $('#txtNewPwd').val()) {
        $('.notification').removeClass('information');
        $('.notification').addClass('error');
        $('#tab-content-tips').html('<b>新密码不能与旧密码相同！</b>');
        return false;
    }
    else if ($('#txtNewPwd').val() != $('#txtCifPwd').val()) {
        $('.notification').removeClass('information');
        $('.notification').addClass('error');
        $('#tab-content-tips').html('<b>你输入的密码与确认密码不一致！</b>');
        return false;
    }
    else {
        $('.notification').removeClass('error');
        $('.notification').addClass('information');
        $('#tab-content-tips').html('<b>请根据提示信息输入相应数据。</b>');
    }
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'txtOldPwd', value: $('#txtOldPwd').val() }
        , { name: 'txtNewPwd', value: $('#txtNewPwd').val() }
        , { name: 'txtCifPwd', value: $('#txtCifPwd').val() }
    ];
    $.ajax({
        url: '/User/Passworded'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data == 'success') {
                DawnPopMsgboxOf2s(1, MsgSuccess);
            }
            else if (data == 'failing') {
                DawnPopMsgboxOf2s(3, MsgFailing);
            }
            else {
                DawnPopMsgboxOf2s(3, data);
            }
        }
        , error: function (msg) {
            DawnPopMsgbox(4, MsgError);
        }
    });
}
/*----------------------------------------------------------
----    数据保存检测
----------------------------------------------------------*/
function dataCheck() {
    if (Dawn.Validator.EngIsPassword($('#txtOldPwd'), $('#infoOldPwd'), $('#icoOldPwd'), null) != 1) return false;
    if (Dawn.Validator.EngIsPassword($('#txtNewPwd'), $('#infoNewPwd'), $('#icoNewPwd'), null) != 1) return false;
    if (Dawn.Validator.EngIsPassword($('#txtCifPwd'), $('#infoCifPwd'), $('#icoCifPwd'), null) != 1) return false;
    return true;
}
/*----------------------------------------------------------
----    页面加载完成后立即执行代码
----------------------------------------------------------*/
$(function () {
    $('#infoOldPwd').text(Dawn.RegularTips['EngIsPassword'].tips);
    $('#infoNewPwd').text(Dawn.RegularTips['EngIsPassword'].tips);
    $('#infoCifPwd').text(Dawn.RegularTips['EngIsPassword'].tips);
    $('#txtNewPwd').keyup(function () {
        Dawn.Validator.PwdCheckLevel($('#txtNewPwd').val(), 'security-level');
    });
});
/*----------------------------------------------------------
----    重新初始化页面大小
----------------------------------------------------------*/
$(window).resize(function () {

});