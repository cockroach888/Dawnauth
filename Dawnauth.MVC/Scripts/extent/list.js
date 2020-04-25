/*----------------------------------------------------------
----    内容异步装载
----------------------------------------------------------*/
var loadContent = function (txtCode, txtMark) {
    var objData = [
        { name: 'txtCode', value: txtCode }
        , { name: 'txtMark', value: txtMark }
    ];
    $.ajax({
        url: '/Extent/Search'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            $('#dataShowArea').html($(data).find('#dataShowArea').html());
            $('#pagerList').html($(data).find('#pagerList').html());
            $('tbody tr:odd').addClass("alt-row");
        }
    });
    if ((txtCode != undefined && txtCode.length > 0) || (txtMark != undefined && txtMark.length > 0)) {
        var clock = new Clock();
        $('#searchTips').html('<img src="/images/icons/tick_circle.png" /> 检索完成！' + clock.toDetailDate());
    }
};
/*----------------------------------------------------------
----    开始数据检索
----------------------------------------------------------*/
function onSearchGo() {
    var txtCode = $('#txtCode').val();
    var txtMark = $('#txtMark').val();
    //扩展编码
    if (txtCode.length > 0 && Dawn.Validator.Simplex(false, $('#txtCode'), 'EngIsEngAndNum') != 1) {
        $('#searchTips').removeClass('color-blue');
        $('#searchTips').addClass('color-red');
        $('#searchTips').html('扩展编码 - ' + Dawn.RegularTips['EngIsEngAndNums'].warn);
        return false;
    }
    //扩展标识
    if (txtMark.length > 0 && Dawn.Validator.Simplex(false, $('#txtMark'), 'EngIsEngAndNum') != 1) {
        $('#searchTips').removeClass('color-blue');
        $('#searchTips').addClass('color-red');
        $('#searchTips').html('扩展标识 - ' + Dawn.RegularTips['EngIsEngAndNums'].warn);
        return false;
    }
    //开始检索
    if (txtCode.length > 0 || txtMark.length > 0) {
        $('#searchTips').removeClass('color-red');
        $('#searchTips').addClass('color-blue');
        $('#searchTips').html('<img src="/images/loader-small.gif" /> 检索中！请稍等...');
        loadContent(txtCode, txtMark);
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
    $('#txtCode').val('');
    $('#txtMark').val('');
    loadContent();
}
/*----------------------------------------------------------
----    数据删除
----------------------------------------------------------*/
function dataDelete(id) {
    if (id.length <= 0) return false;
    DawnPopConfirm('您确定要删除当前数据吗？', function () {
        $.ajax({
            url: '/Extent/Delete'
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