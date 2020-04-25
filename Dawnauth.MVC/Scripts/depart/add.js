/*----------------------------------------------------------
----    数据保存
----------------------------------------------------------*/
function dataSave() {
    if (!dataCheck()) return false;
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'ddlFather', value: $('#ddlFather').val() }
        , { name: 'txtName', value: $('#txtName').val() }
        , { name: 'txtCode', value: $('#txtCode').val() }
        , { name: 'txtIdent', value: $('#txtIdent').val() }
        , { name: 'txtRank', value: $('#txtRank').val() }
        , { name: 'txtDesc', value: $('#txtDesc').val() }
    ];
    $.ajax({
        url: '/Depart/Added'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data == 'added') {
                DawnPopMsgboxOf2s(3, MsgExist);
            }
            else if (data == 'success') {
                var url = '/Depart/List/1';
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
    if (Dawn.Validator.ChsIsChineseOrEngOrNums($('#txtName'), $('#infoName'), $('#icoName'), null) != 1) return false;
    if ($('#txtCode').val().length > 0 && Dawn.Validator.EngIsEngAndNums($('#txtCode'), $('#infoCode'), $('#icoCode'), null) != 1) return false;
    if ($('#txtIdent').val().length > 0 && Dawn.Validator.NumIsInteger($('#txtIdent'), $('#infoIdent'), $('#icoIdent'), null) != 1) return false;
    if ($('#txtRank').val().length > 0 && Dawn.Validator.NumIsIntegralBySignless($('#txtRank'), $('#infoRank'), $('#icoRank'), null) != 1) return false;
    if ($('#txtDesc').val().length > 0 && Dawn.Validator.ChsIsMemos($('#txtDesc'), $('#infoDesc'), $('#icoDesc'), null) != 1) return false;
    return true;
}
/*----------------------------------------------------------
----    页面加载完成后立即执行代码
----------------------------------------------------------*/
$(function () {
    $('#infoFather').text(Dawn.RegularTips['Selector'].tips);
    $('#infoName').text(Dawn.RegularTips['ChsIsChineseOrEngOrNums'].tips);
    $('#infoCode').text(Dawn.RegularTips['EngIsEngAndNums'].tips);
    $('#infoIdent').text(Dawn.RegularTips['NumIsInteger'].tips);
    $('#infoRank').text(Dawn.RegularTips['NumIsIntegralBySignless'].tips);
    $('#infoDesc').text(Dawn.RegularTips['ChsIsMemos'].tips);
});
/*----------------------------------------------------------
----    重新初始化页面大小
----------------------------------------------------------*/
$(window).resize(function () {

});