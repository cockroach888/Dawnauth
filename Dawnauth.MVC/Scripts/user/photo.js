/*----------------------------------------------------------
----    数据保存
----------------------------------------------------------*/
function dataSave() {
    if (!dataCheck()) return false;
    var objData = [
        { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
        , { name: 'hidUserId', value: $('#hidUserId').val() }
        , { name: 'fupPicture', value: $('#fupPicture').val() }
    ];
    $.ajax({
        url: '/User/Photoed'
        , data: objData
        , type: 'POST'
        , success: function (data) {
            if (data == 'success') {
                DawnPopMsgboxOf2s(1, MsgSuccess);
            }
            else if (data == 'failing') {
                DawnPopMsgboxOf2s(3, MsgFailing);
            }
            else {
                //DawnPopMsgboxOf2s(3, data);
                DawnPopMsgboxOf2s(3, data);
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
    var file = $('#fupPicture').val();
    if (file == undefined || file == 'undefined' || file == null || file == '' || file.length < 1) {
        $('.notification').removeClass('information');
        $('.notification').addClass('error');
        $('#tab-content-tips').html('<b>管理员个人肖像不能为空！</b>');
        $('#fupPicture').focus();
        return false;
    }
    else {
        $('.notification').removeClass('error');
        $('.notification').addClass('information');
        $('#tab-content-tips').html('<b>请选择管理员个人肖像。</b>');
    }
    return true;
}
/*----------------------------------------------------------
----    页面加载完成后立即执行代码
----------------------------------------------------------*/
$(function () {
    //var ip = new ImagePreview('fupPicture', 'imgPicture', {
    //    maxWidth: 150, maxHeight: 180, action: 'UploadTools/ImagePreview.ashx'
    //});
    //ip.img.src = ImagePreview.TRANSPARENT;
    //ip.file.onchange = function () { ip.preview(); };
});
/*----------------------------------------------------------
----    重新初始化页面大小
----------------------------------------------------------*/
$(window).resize(function () {

});