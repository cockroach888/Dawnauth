/*----------------------------------------------------------
----    数据保存
----------------------------------------------------------*/
function dataSave() {
    if (!dataCheck()) return false;
    if ($('#txtPwd').val() != $('#txtPwds').val()) {
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
        , { name: 'sltDepart', value: $('#sltDepart').val() }
        , { name: 'ddlGrade', value: $('#ddlGrade').val() }
        , { name: 'txtSurname', value: $('#txtSurname').val() }
        , { name: 'txtName', value: $('#txtName').val() }
        , { name: 'txtPwd', value: $('#txtPwd').val() }
        , { name: 'txtPwds', value: $('#txtPwds').val() }
        , { name: 'txtMobile', value: $('#txtMobile').val() }
        , { name: 'txtEmail', value: $('#txtEmail').val() }
        , { name: 'txtDesc', value: $('#txtDesc').val() }
    ];
    $.ajax({
        url: '/User/Added'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data == 'added') {
                DawnPopMsgboxOf2s(3, MsgExist);
            }
            else if (data == 'success') {
                var url = '/User/List/1';
                DawnPopMsgjumpOf2s(1, MsgSuccess, url);
            }
            else if (data == 'failing') {
                DawnPopMsgboxOf2s(3, MsgFailing);
            }
            else {
                DawnPopMsgbox(3, data);
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
    if (Dawn.Validator.Selector($('#sltDepart'), $('#infoDepart'), $('#icoDepart'), null) != 1) return false;
    if (Dawn.Validator.Selector($('#ddlGrade'), $('#infoGrade'), $('#icoGrade'), null) != 1) return false;
    if (Dawn.Validator.ChsIsTname($('#txtSurname'), $('#infoSurname'), $('#icoSurname'), null) != 1) return false;
    if (Dawn.Validator.EngIsRegisters($('#txtName'), $('#infoName'), $('#icoName'), null) != 1) return false;
    if (Dawn.Validator.EngIsPassword($('#txtPwd'), $('#infoPwd'), $('#icoPwd'), null) != 1) return false;
    if (Dawn.Validator.EngIsPassword($('#txtPwds'), $('#infoPwds'), $('#icoPwds'), null) != 1) return false;
    if (Dawn.Validator.TelIsMobile($('#txtMobile'), $('#infoMobile'), $('#icoMobile'), null) != 1) return false;
    if (Dawn.Validator.IsEmail($('#txtEmail'), $('#infoEmail'), $('#icoEmail'), null) != 1) return false;    
    if ($('#txtDesc').val().length > 0 && Dawn.Validator.ChsIsMemos($('#txtDesc'), $('#infoDesc'), $('#icoDesc'), null) != 1) return false;
    return true;
}
/*----------------------------------------------------------
----    页面加载完成后立即执行代码
----------------------------------------------------------*/
$(function () {
    $('#infoDepart').text(Dawn.RegularTips['Selector'].tips);
    $('#infoGrade').text(Dawn.RegularTips['Selector'].tips);
    $('#infoSurname').text(Dawn.RegularTips['ChsIsChinese'].tips);
    $('#infoName').text(Dawn.RegularTips['EngIsRegisters'].tips);
    $('#infoPwd').text(Dawn.RegularTips['EngIsPassword'].tips);
    $('#infoPwds').text(Dawn.RegularTips['EngIsPassword'].tips);
    $('#infoMobile').text(Dawn.RegularTips['TelIsMobile'].tips);
    $('#infoEmail').text(Dawn.RegularTips['IsEmail'].tips);
    $('#infoDesc').text(Dawn.RegularTips['ChsIsMemos'].tips);
    $('#txtPwd').keyup(function () {
        Dawn.Validator.PwdCheckLevel($('#txtPwd').val(), 'security-level');
    });
});
/*----------------------------------------------------------
----    重新初始化页面大小
----------------------------------------------------------*/
$(window).resize(function () {

});