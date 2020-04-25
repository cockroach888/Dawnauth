/*----------------------------------------------------------
----- 宽高比动态计算
----------------------------------------------------------*/
var dynSetContentHeight = function () {
    var boxBody = $('.content-box-content').height();
    var tbSearch = $('#table-search').height();
    var tbThead = $('#table-thead').height();
    var tbTfoot = $('#table-tfoot').height();
    var tbOther = 10; //线条、间距等宽度
    var tbTbody = boxBody - tbSearch - tbThead - tbTfoot - tbOther;
    $('#table-tbody').height(tbTbody);
};
/*----------------------------------------------------------
----- 全局初始化操作
----------------------------------------------------------*/
//页面加载完成后立即执行代码
$(function () {
    dynSetContentHeight();
    // Alternating table rows:
    //$('tbody tr:even').addClass('alt-row'); // 单行 Add class "alt-row" to even table rows
    $('tbody tr:odd').addClass('alt-row'); // 双行 Add class "alt-row" to even table rows
    // 2013-03-28 宋杰军
    // 增加数据列表全文点击事件
    //$(document).bind('click', function () {
    //    $('tr.alt-selected').removeClass('alt-selected');
    //});
});
//重新初始化页面大小
$(window).resize(function () {
    dynSetContentHeight();
});