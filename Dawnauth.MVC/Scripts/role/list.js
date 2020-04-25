/*----------------------------------------------------------
----    内容异步装载
----------------------------------------------------------*/
var loadContent = function () {
    var url = '/Role/List/1/';
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
----    数据删除
----------------------------------------------------------*/
function dataDelete(id) {
    if (id.length <= 0) return false;
    DawnPopConfirm('您确定要删除当前数据吗？', function () {
        $.ajax({
            url: '/Role/Delete'
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