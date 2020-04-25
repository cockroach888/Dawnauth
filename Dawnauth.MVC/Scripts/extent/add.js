/*----------------------------------------------------------
----    权限扩展编码选取
----------------------------------------------------------*/
function dataChange(val) {
    if (val != -1) {
        $('#txtCode').val($('#sltCodeItem').val());
        $('#txtCodeName').val($("#sltCodeItem").find("option:selected").text());
    }
}
/*----------------------------------------------------------
----    数据保存
----------------------------------------------------------*/
function dataSave() {
    if (!dataCheck()) return false;
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }        
        , { name: 'txtCode', value: $('#txtCode').val() }
        , { name: 'txtCodeName', value: $('#txtCodeName').val() }
        , { name: 'txtMark', value: $('#txtMark').val() }
        , { name: 'txtMarkName', value: $('#txtMarkName').val() }
        , { name: 'txtMemo', value: $('#txtMemo').val() }
    ];
    $.ajax({
        url: '/Extent/Added'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data == 'added') {
                DawnPopMsgboxOf2s(3, MsgExist);
            }
            else if (data == 'success') {
                var url = '/Extent/List/1';
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
    if (Dawn.Validator.EngIsEngAndNum($('#txtCode'), $('#infoCode'), $('#icoCode'), null) != 1) return false;
    if (Dawn.Validator.ChsIsChineseOrEngOrNum($('#txtCodeName'), $('#infoCodeName'), $('#icoCodeName'), null) != 1) return false;
    if (Dawn.Validator.EngIsEngAndNum($('#txtMark'), $('#infoMark'), $('#icoMark'), null) != 1) return false;
    if (Dawn.Validator.ChsIsChineseOrEngOrNum($('#txtMarkName'), $('#infoMarkName'), $('#icoMarkName'), null) != 1) return false;
    if ($('#txtMemo').val().length > 0 && Dawn.Validator.ChsIsMemos($('#txtMemo'), $('#infoMemo'), $('#icoMemo'), null) != 1) return false;
    return true;
}
/*----------------------------------------------------------
----    页面加载完成后立即执行代码
----------------------------------------------------------*/
$(function () {    
    $('#infoCode').text(Dawn.RegularTips['EngIsEngAndNum'].tips);
    $('#infoCodeName').text(Dawn.RegularTips['ChsIsChineseOrEngOrNum'].tips);
    $('#infoMark').text(Dawn.RegularTips['EngIsEngAndNum'].tips);
    $('#infoMarkName').text(Dawn.RegularTips['ChsIsChineseOrEngOrNum'].tips);
    $('#infoMemo').text(Dawn.RegularTips['ChsIsMemos'].tips);
});
/*----------------------------------------------------------
----    重新初始化页面大小
----------------------------------------------------------*/
$(window).resize(function () {

});