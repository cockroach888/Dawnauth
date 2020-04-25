/*----------------------------------------------------------
----    数据保存
----------------------------------------------------------*/
function dataSave() {
    if (!dataCheck()) return false;
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'hidRoleId', value: $('#hidRoleId').val() }
        , { name: 'txtName', value: $('#txtName').val() }
        , { name: 'txtDesc', value: $('#txtDesc').val() }
    ];
    $.ajax({
        url: '/Role/Editored'
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
    if (Dawn.Validator.ChsIsChineseOrEngOrNums($('#txtName'), $('#infoName'), $('#icoName'), null) != 1) return false;
    if ($('#txtDesc').val().length > 0 && Dawn.Validator.ChsIsMemos($('#txtDesc'), $('#infoDesc'), $('#icoDesc'), null) != 1) return false;
    return true;
}
/*----------------------------------------------------------
----    页面加载完成后立即执行代码
----------------------------------------------------------*/
$(function () {
    $('#infoName').text(Dawn.RegularTips['ChsIsChineseOrEngOrNums'].tips);
    $('#infoDesc').text(Dawn.RegularTips['ChsIsMemos'].tips);
});
/*----------------------------------------------------------
----    重新初始化页面大小
----------------------------------------------------------*/
$(window).resize(function () {

});