/*----------------------------------------------------------
----    获取数据
----------------------------------------------------------*/
function GetSyncData() {
    if (!dataCheck()) return false;
    DawnPopMsgbox2(5, '数据获取中，请稍等...');
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'txtSetCode', value: $('#txtSetCode').val() }
        , { name: 'txtSetName', value: $('#txtSetName').val() }
        , { name: 'sltSyncItem', value: $('#sltSyncItem').val() }
        , { name: 'txtFieldTable', value: $('#txtFieldTable').val() }
        , { name: 'txtFieldMark', value: $('#txtFieldMark').val() }
        , { name: 'txtFieldName', value: $('#txtFieldName').val() }
        , { name: 'txtFieldMemo', value: $('#txtFieldMemo').val() }
        , { name: 'txtFieldWhere', value: $('#txtFieldWhere').val() }
        , { name: 'txtConnSource', value: $('#txtConnSource').val() }
        , { name: 'txtConnData', value: $('#txtConnData').val() }
        , { name: 'txtConnUser', value: $('#txtConnUser').val() }
        , { name: 'txtConnPwd', value: $('#txtConnPwd').val() }
    ];
    $.ajax({
        url: '/Extent/GetSyncData'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            $('#dataShowArea').html(data);
            $('tbody tr:odd').addClass("alt-row");
            DawnPopCloseAll();
        }
    });
}
/*----------------------------------------------------------
----    开始同步
----------------------------------------------------------*/
function dataSave() {
    DawnPopConfirm('您确定要进行数据同步吗？', function () {
        if (dataCheck()) {
            var objData = [
                { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
                , { name: 'txtSetCode', value: $('#txtSetCode').val() }
                , { name: 'txtSetName', value: $('#txtSetName').val() }
                , { name: 'sltSyncItem', value: $('#sltSyncItem').val() }
                , { name: 'txtFieldTable', value: $('#txtFieldTable').val() }
                , { name: 'txtFieldMark', value: $('#txtFieldMark').val() }
                , { name: 'txtFieldName', value: $('#txtFieldName').val() }
                , { name: 'txtFieldMemo', value: $('#txtFieldMemo').val() }
                , { name: 'txtFieldWhere', value: $('#txtFieldWhere').val() }
                , { name: 'txtConnSource', value: $('#txtConnSource').val() }
                , { name: 'txtConnData', value: $('#txtConnData').val() }
                , { name: 'txtConnUser', value: $('#txtConnUser').val() }
                , { name: 'txtConnPwd', value: $('#txtConnPwd').val() }
            ];
            $.ajax({
                url: '/Extent/Synced'
                , data: objData
                , type: 'POST'
                , success: function (data) {
                    if (data == 'success') {
                        var url = '/Extent/List/1';
                        DawnPopMsgjumpOf2s(1, MsgSuccess, url);
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
    }, function () {
        DawnPopTips(MsgCancel);
    });    
}
/*----------------------------------------------------------
----    数据保存检测
----------------------------------------------------------*/
function dataCheck() {
    //扩展设定：扩展编码
    if (Dawn.Validator.Simplex(false, $('#txtSetCode'), 'EngIsEngAndNum') != 1) {
        $('#dataShowArea').html(GetResult('扩展设定：扩展编码 - ', Dawn.RegularTips['EngIsEngAndNums'].warn));
        return false;
    }
    //扩展设定：编码名称
    if (Dawn.Validator.Simplex(false, $('#txtSetName'), 'ChsIsChineseOrEngOrNum') != 1) {
        $('#dataShowArea').html(GetResult('扩展设定：编码名称 - ', Dawn.RegularTips['ChsIsChineseOrEngOrNum'].warn));
        return false;
    }
    //字段名称：数据表名
    if ($('#txtFieldTable').val().length < 1) {
        $('#dataShowArea').html(GetResult('字段名称：数据表名 - ', '不能为空！'));
        $('#txtFieldTable').focus();
        return false;
    }
    //字段名称：扩展标识
    if ($('#txtFieldMark').val().length < 1) {
        $('#dataShowArea').html(GetResult('字段名称：扩展标识 - ', '不能为空！'));
        $('#txtFieldMark').focus();
        return false;
    }
    //字段名称：标识名称
    if ($('#txtFieldName').val().length < 1) {
        $('#dataShowArea').html(GetResult('字段名称：标识名称 - ', '不能为空！'));
        $('#txtFieldName').focus();
        return false;
    }
    //字段名称：扩展备注
    if ($('#txtFieldMemo').val().length < 1) {
        $('#dataShowArea').html(GetResult('字段名称：扩展备注 - ', '不能为空！'));
        $('#txtFieldMemo').focus();
        return false;
    }
    //字段名称：查询条件
    if ($('#txtFieldWhere').val().length < 1) {
        $('#dataShowArea').html(GetResult('字段名称：查询条件 - ', '不能为空！'));
        $('#txtFieldWhere').focus();
        return false;
    }
    //连接属性：数据源
    if ($('#txtConnSource').val().length < 1) {
        $('#dataShowArea').html(GetResult('字段名称：数据源 - ', '不能为空！'));
        $('#txtConnSource').focus();
        return false;
    }
    //连接属性：数据库名
    if ($('#txtConnData').val().length < 1) {
        $('#dataShowArea').html(GetResult('字段名称：数据库名 - ', '不能为空！'));
        $('#txtConnData').focus();
        return false;
    }
    //连接属性：用户名称
    if ($('#txtConnUser').val().length < 1) {
        $('#dataShowArea').html(GetResult('字段名称：用户名称 - ', '不能为空！'));
        $('#txtConnUser').focus();
        return false;
    }
    //连接属性：用户密码
    if ($('#txtConnPwd').val().length < 1) {
        $('#dataShowArea').html(GetResult('字段名称：用户密码 - ', '不能为空！'));
        $('#txtConnPwd').focus();
        return false;
    }
    return true;
}
function GetResult(strTitle, strMsg) {
    var result = '<tr><td colspan="5"><span class="color-red f14 margin-left-10">';
    result += strTitle;
    result += strMsg;
    result += '</span></td></tr>';
    return result;
}
/*----------------------------------------------------------
----    页面加载完成后立即执行代码
----------------------------------------------------------*/
$(function () {
    
});
/*----------------------------------------------------------
----    重新初始化页面大小
----------------------------------------------------------*/
$(window).resize(function () {

});