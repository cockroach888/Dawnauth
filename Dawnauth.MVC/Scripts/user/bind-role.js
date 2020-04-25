/*----------------------------------------------------------
----    取消管理员角色绑定
----------------------------------------------------------*/
function dataUnSave(indexId, uId, rId) {
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'userId', value: uId }
        , { name: 'roleId', value: rId }
        , { name: 'opFlag', value: 'del' }
    ];
    $.ajax({
        url: '/User/BindRoled'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data == 'success') {
                $('#btn' + indexId).removeClass('switch-on');
                $('#btn' + indexId).addClass('switch-off');
                $('#btn' + indexId).attr('onclick', 'dataSave(' + indexId + ',' + uId + ',' + rId + ');');
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
----    赋予管理员角色绑定
----------------------------------------------------------*/
function dataSave(indexId, uId, rId) {
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'userId', value: uId }
        , { name: 'roleId', value: rId }
        , { name: 'opFlag', value: 'add' }
    ];
    $.ajax({
        url: '/User/BindRoled'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data == 'success') {
                $('#btn' + indexId).removeClass('switch-off');
                $('#btn' + indexId).addClass('switch-on');
                $('#btn' + indexId).attr('onclick', 'dataUnSave(' + indexId + ',' + uId + ',' + rId + ');');
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