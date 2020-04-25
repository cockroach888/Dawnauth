/*----------------------------------------------------------
----    显示相应功能列表
----------------------------------------------------------*/
function dataStatus(objThis, mdlId, userId) {
    $('.float-left input[type="button"]').attr('class', 'button-black');
    $(objThis).attr('class', 'button');
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'moduleId', value: mdlId }
        , { name: 'userId', value: userId }
    ];
    $.ajax({
        url: '/User/GetStatus'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data != 'failing') {
                $('#divStatusArea').html(data);
            }
            else {
                DawnPopMsgboxOf2s(3, MsgFailing);
            }
        }
        , error: function (msg) {
            DawnPopMsgbox(4, MsgError);
        }
    });
}
/*----------------------------------------------------------
----    取消管理员机制绑定
----------------------------------------------------------*/
function dataUnSave(indexId, uId, sId) {
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'userId', value: uId }
        , { name: 'statusId', value: sId }
        , { name: 'opFlag', value: 'del' }
    ];
    $.ajax({
        url: '/User/BindStatused'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data == 'success') {
                $('#btn' + indexId).removeClass('switch-on');
                $('#btn' + indexId).addClass('switch-off');
                $('#btn' + indexId).attr('onclick', 'dataSave(' + indexId + ',' + uId + ',' + sId + ');');
            }
            else {
                DawnPopMsgboxOf2s(3, MsgFailing);
            }
        }
        , error: function (msg) {
            DawnPopMsgbox(4, MsgError);
        }
    });
}
/*----------------------------------------------------------
----    赋予管理员机制绑定
----------------------------------------------------------*/
function dataSave(indexId, uId, sId) {
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'userId', value: uId }
        , { name: 'statusId', value: sId }
        , { name: 'opFlag', value: 'add' }
    ];
    $.ajax({
        url: '/User/BindStatused'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data == 'success') {
                $('#btn' + indexId).removeClass('switch-off');
                $('#btn' + indexId).addClass('switch-on');
                $('#btn' + indexId).attr('onclick', 'dataUnSave(' + indexId + ',' + uId + ',' + sId + ');');
            }
            else {
                DawnPopMsgboxOf2s(3, MsgFailing);
            }
        }
        , error: function (msg) {
            DawnPopMsgbox(4, MsgError);
        }
    });
}
/*----------------------------------------------------------
----    页面加载完成后立即执行代码
----------------------------------------------------------*/
$(function () {
    var boxH = $('.content-box-content').height();
    var mlH = boxH - 80;
    $('#moduleList').height(mlH);
});
/*----------------------------------------------------------
----    重新初始化页面大小
----------------------------------------------------------*/
$(window).resize(function () {
    var boxH = $('.content-box-content').height();
    var mlH = boxH - 80;
    $('#moduleList').height(mlH);
});