/*----------------------------------------------------------
----    内容异步装载
----------------------------------------------------------*/
var loadContent = function () {
    var url = '/Info/ErrorList/1/';
    $.ajax({
        url: url
        , type: 'POST'
        , success: function (data) {
            $('#dataShowArea').html($(data).find('#dataShowArea').html());
            $('#pagerList').html($(data).find('#pagerList').html());
            $('tbody tr:odd').addClass("alt-row");
        }
    });
};
/*----------------------------------------------------------
----    数据清空
----------------------------------------------------------*/
function dataclear() {
    DawnPopConfirm('您确定要清空错误信息数据吗？', function () {
        $.ajax({
            url: '/Info/ErrorClear'
            , data: { '__RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val() }
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