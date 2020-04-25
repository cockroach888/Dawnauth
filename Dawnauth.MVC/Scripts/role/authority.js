/*----------------------------------------------------------
----    显示相应功能列表
----------------------------------------------------------*/
function dataFunction(objThis, mdlId, mdlCode) {
    $('.float-left input[type="button"]').attr('class', 'button-black');
    $(objThis).attr('class', 'button');
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'moduleId', value: mdlId }
        , { name: 'roleCode', value: $('#hidRoleCode').val() }
        , { name: 'moduleCode', value: mdlCode }
    ];
    $.ajax({
        url: '/Role/Function'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data != 'failing') {
                $('#divFunArea').html(data);
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
----    设定功能权限
----------------------------------------------------------*/
function dataSave(indexId, moduleCode, opFlag) {
    var authCount = $('#hidAuthCount').val();
    var authString = '';
    for (var i = 1; i <= authCount; i++) {
        var authVal = $('#hidAuth' + i).val();
        if (i == indexId) {
            if (authVal == 0) {
                authString += '1';
                $('#hidAuth' + i).val('1');
            }
            else {
                authString += '0';
                $('#hidAuth' + i).val('0');
            }
        }
        else {
            authString += authVal;
        }
    }
    if (authString == null | authString.length <= 0) {
        DawnPopMsgboxOf2s(3, '设置角色权限失败！请重试！');
        return;
    }
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'hidRoleCode', value: $('#hidRoleCode').val() }
        , { name: 'moduleCode', value: moduleCode }
        , { name: 'authString', value: authString }
    ];
    $.ajax({
        url: '/Role/Authorityed'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data == 'success') {
                if (opFlag == 'add') {
                    $('#btn' + indexId).attr('class', 'switch-on');
                    $('#btn' + indexId).attr('onclick', "dataSave(" + indexId + ",'" + moduleCode + "','del');");
                }
                else if (opFlag == 'del') {
                    $('#btn' + indexId).attr('class', 'switch-off');
                    $('#btn' + indexId).attr('onclick', "dataSave(" + indexId + ",'" + moduleCode + "','add');");
                }
                else {
                    DawnPopMsgboxOf2s(3, MsgFailing);
                }
            }
            else if (data == 'failing') {
                DawnPopMsgboxOf2s(3, MsgFailing);
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