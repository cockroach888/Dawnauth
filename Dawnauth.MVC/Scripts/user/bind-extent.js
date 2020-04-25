/*----------------------------------------------------------
----    显示相应数据列表
----------------------------------------------------------*/
function GetExtentMark(objThis, exteCode, userId) {
    $('.float-left input[type="button"]').attr('class', 'button-black');
    $(objThis).attr('class', 'button');
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'exteCode', value: exteCode }
        , { name: 'userId', value: userId }
    ];
    $.ajax({
        url: '/User/GetExtentMark'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data != 'failing') {
                $('#divExtentArea').html(data);
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
----    解绑管理员权限扩展
----------------------------------------------------------*/
function dataUnSave(indexId, uId, cId, mId) {
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'userId', value: uId }
        , { name: 'exteCode', value: cId }
        , { name: 'exteMark', value: mId }
        , { name: 'opFlag', value: 'del' }
    ];
    $.ajax({
        url: '/User/BindExtented'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data == 'success') {
                $('#btn' + indexId).removeClass('switch-on');
                $('#btn' + indexId).addClass('switch-off');
                $('#btn' + indexId).attr('onclick', 'dataSave(' + indexId + ',' + uId + ',"' + cId + '","' + mId + '");');
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
----    绑定管理员权限扩展
----------------------------------------------------------*/
function dataSave(indexId, uId, cId, mId) {
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'userId', value: uId }
        , { name: 'exteCode', value: cId }
        , { name: 'exteMark', value: mId }
        , { name: 'opFlag', value: 'add' }
    ];
    $.ajax({
        url: '/User/BindExtented'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data == 'success') {
                $('#btn' + indexId).removeClass('switch-off');
                $('#btn' + indexId).addClass('switch-on');
                $('#btn' + indexId).attr('onclick', 'dataUnSave(' + indexId + ',' + uId + ',"' + cId + '","' + mId + '");');
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
    $('#extentList').height(mlH);
});
/*----------------------------------------------------------
----    重新初始化页面大小
----------------------------------------------------------*/
$(window).resize(function () {
    var boxH = $('.content-box-content').height();
    var mlH = boxH - 80;
    $('#extentList').height(mlH);
});