/*----------------------------------------------------------
----    内容异步装载
----------------------------------------------------------*/
var loadContent = function (sltModule, txtCode) {
    var objData = [
        { name: 'sltModule', value: sltModule }
        , { name: 'txtCode', value: txtCode }
    ];
    $.ajax({
        url: '/Module/Search'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            $('#dataShowArea').html($(data).find('#dataShowArea').html());
            $('#pagerList').html($(data).find('#pagerList').html());
            $('tbody tr:odd').addClass("alt-row");
        }
    });
    if ((sltModule != undefined && sltModule != -1 && sltModule.length > 0) || (txtCode != undefined && txtCode.length > 0)) {
        var clock = new Clock();
        $('#searchTips').html('<img src="/images/icons/tick_circle.png" /> 检索完成！' + clock.toDetailDate());
    }
};
/*----------------------------------------------------------
----    开始数据检索
----------------------------------------------------------*/
function onSearchGo() {
    var sltModule = $('#sltModule').val();
    var txtCode = $('#txtCode').val();
    //模块编码
    if (txtCode.length > 0 && Dawn.Validator.Simplex(false, $('#txtCode'), 'EngIsEngAndNums') != 1) {
        $('#searchTips').removeClass('color-blue');
        $('#searchTips').addClass('color-red');
        $('#searchTips').html('模块编码 - ' + Dawn.RegularTips['EngIsEngAndNums'].warn);
        return false;
    }
    //开始检索
    if (sltModule != -1 && sltModule.length > 0 || txtCode.length > 0) {
        $('#searchTips').removeClass('color-red');
        $('#searchTips').addClass('color-blue');
        $('#searchTips').html('<img src="/images/loader-small.gif" /> 检索中！请稍等...');
        loadContent(sltModule, txtCode);
    }
    else {
        $('#searchTips').html('<img src="/images/icons/exclamation.png" /> 无检索条件...');
    }
}
/*----------------------------------------------------------
----    清除检索数据
----------------------------------------------------------*/
function onSearchClear() {
    $('#searchTips').html('');
    $('#sltModule').val('');
    $('#txtCode').val('');
    loadContent();
}
/*----------------------------------------------------------
----    数据删除
----------------------------------------------------------*/
function dataDelete(id) {
    if (id.length <= 0) return false;
    DawnPopConfirm('您确定要删除当前数据吗[包含隶属数据]？', function () {
        $.ajax({
            url: '/Module/Delete'
            , data: ({ id: id })
            , type: 'POST'
            , success: function (data) {
                if (data == 'success') {
                    DawnPopMsgboxOf2s(1, MsgSuccess);
                    loadContent();
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
    }, function () {
        DawnPopTips(MsgCancel);
    });
}
/*----------------------------------------------------------
----    目录树
----------------------------------------------------------*/
function dataTrees(id, name) {
    name += ' - 目录树';
    var url = '/Module/Trees/';
    url += id;
    DawnPopIFrame(name, url);
}