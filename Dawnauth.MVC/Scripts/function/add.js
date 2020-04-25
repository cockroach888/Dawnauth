/*----------------------------------------------------------
----    隶属功能
----------------------------------------------------------*/
function dataChange(val) {
    if (val == -1) {
        $('#txtName').val('模块访问');
    }
    else {
        $('#txtName').val('');
    }
}
/*----------------------------------------------------------
----    常规选项
----------------------------------------------------------*/
function dataRoutine(flag) {
    $('#ddlParentMark').val(1);
    switch (flag) {
        case 0:
            $('#txtName').val('站务管理');
            $('#txtCode').val('WebSite');
            $('#ddlParentMark').val(-1);
            $('#txtDesc').val('站务管理');
            break;
        case 1:
            $('#txtName').val('模块访问');
            $('#txtCode').val('Module');
            $('#ddlParentMark').val(-1);
            $('#txtDesc').val('模块访问');
            break;
        case 2:
            $('#txtName').val('数据列表');
            $('#txtCode').val('List');
            $('#txtDesc').val('数据列表');
            break;
        case 3:
            $('#txtName').val('数据添加');
            $('#txtCode').val('Added');
            $('#txtDesc').val('数据添加');
            break;
        case 4:
            $('#txtName').val('数据编辑');
            $('#txtCode').val('Editor');
            $('#txtDesc').val('数据编辑');
            break;
        case 5:
            $('#txtName').val('数据删除');
            $('#txtCode').val('Delete');
            $('#txtDesc').val('数据删除');
            break;
        case 6:
            $('#txtName').val('数据归档');
            $('#txtCode').val('Sealup');
            $('#txtDesc').val('数据归档');
            break;
        case 7:
            $('#txtName').val('数据清空');
            $('#txtCode').val('Clear');
            $('#txtDesc').val('数据清空');
            break;
        case 8:
            $('#txtName').val('数据流程');
            $('#txtCode').val('DataFlow');
            $('#txtDesc').val('数据流程');
            break;
    }
}
/*----------------------------------------------------------
----    数据保存
----------------------------------------------------------*/
function dataSave() {
    if (!dataCheck()) return false;
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'ddlModule', value: $('#ddlModule').val() }
        , { name: 'ddlParentMark', value: $('#ddlParentMark').val() }
        , { name: 'txtName', value: $('#txtName').val() }
        , { name: 'txtCode', value: $('#txtCode').val() }
        , { name: 'txtIdent', value: $('#txtIdent').val() }
        , { name: 'txtDesc', value: $('#txtDesc').val() }
    ];    
    $.ajax({
        url: '/Function/Added'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data == 'added') {
                DawnPopMsgboxOf2s(3, MsgExist);
            }
            else if (data == 'success') {
                var url = '/Function/List/1';
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
    if (Dawn.Validator.Selector($('#ddlModule'), $('#infoModule'), $('#icoModule'), null) != 1) return false;
    if (Dawn.Validator.ChsIsChineseOrEngOrNums($('#txtName'), $('#infoName'), $('#icoName'), null) != 1) return false;
    if (Dawn.Validator.EngIsEngAndNums($('#txtCode'), $('#infoCode'), $('#icoCode'), null) != 1) return false;
    if ($('#txtIdent').val().length > 0 && Dawn.Validator.NumIsInteger($('#txtIdent'), $('#infoIdent'), $('#icoIdent'), null) != 1) return false;
    if ($('#txtDesc').val().length > 0 && Dawn.Validator.ChsIsMemos($('#txtDesc'), $('#infoDesc'), $('#icoDesc'), null) != 1) return false;
    return true;
}
/*----------------------------------------------------------
----    页面加载完成后立即执行代码
----------------------------------------------------------*/
$(function () {
    $('#infoModule').text(Dawn.RegularTips['Selector'].tips);
    $('#infoParentMark').text(Dawn.RegularTips['Selector'].tips);
    $('#infoName').text(Dawn.RegularTips['ChsIsChineseOrEngOrNums'].tips);
    $('#infoCode').text(Dawn.RegularTips['EngIsEngAndNums'].tips);
    $('#infoIdent').text(Dawn.RegularTips['NumIsInteger'].tips);
    $('#infoDesc').text(Dawn.RegularTips['ChsIsMemos'].tips);
});
/*----------------------------------------------------------
----    重新初始化页面大小
----------------------------------------------------------*/
$(window).resize(function () {

});