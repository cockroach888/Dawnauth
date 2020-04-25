/*----------------------------------------------------------
----    数据保存
----------------------------------------------------------*/
function dataSave() {
    if (!dataCheck()) return false;
    var current = $('#hidPageCurrent').val();
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'hidUserId', value: $('#hidUserId').val() }
        , { name: 'sltDepart', value: $('#sltDepart').val() }
        , { name: 'ddlGrade', value: $('#ddlGrade').val() }
        , { name: 'txtSurname', value: $('#txtSurname').val() }       
        , { name: 'txtMobile', value: $('#txtMobile').val() }
        , { name: 'txtEmail', value: $('#txtEmail').val() }
        , { name: 'txtDesc', value: $('#txtDesc').val() }
    ];
    $.ajax({
        url: '/User/Editored'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data == 'success') {
                var url = '/User/List/' + current;
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
    $('#infoMobile').text(Dawn.RegularTips['TelIsMobile'].tips);
    $('#infoEmail').text(Dawn.RegularTips['IsEmail'].tips);
    $('#infoDesc').text(Dawn.RegularTips['ChsIsMemos'].tips);
});
/*----------------------------------------------------------
----    重新初始化页面大小
----------------------------------------------------------*/
$(window).resize(function () {

});