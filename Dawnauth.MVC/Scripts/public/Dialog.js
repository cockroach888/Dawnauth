var MsgSuccess = '操作成功！';
var MsgFailing = '操作失败！请重试！';
var MsgError = '出错啦！请重试或联系管理员！';
var MsgCancel = '您取消了本次操作！';
var MsgExist = '已存在相同数据！';
var MsgIllegal = '您的操作有误，请重试！';
var MsgNothing = '我是《晨曦小竹权限云管理系统》，我为自己代言。';
/*----------------------------------------------------------
----- 常用功能函数
----------------------------------------------------------*/
function GotoHref(url) {
    top.location.href = url;
}
/*----------------------------------------------------------
----- JQuery复选框操作 CheckBox
----------------------------------------------------------*/
//获取选择的值
function getCheckBoxList(boxName) {
    if (boxName == undefined || boxName == 'undefined' || boxName == null || boxName == '') return null;
    var chkValue = [];
    $('input[name="' + boxName + '"]:checked').each(function () {
        chkValue.push($(this).val());
    });
    return chkValue;
}
//全选/取消
function setCheckBox(boxName, flag) {
    if (boxName == undefined || boxName == 'undefined' || boxName == null || boxName == '') return;
    if (flag != 1 && flag != 2) return;
    if (flag == 1) {
        $('input[name="' + boxName + '"]').prop('checked', 'checked');
    }
    else if (flag == 2) {
        $('input[name="' + boxName + '"]').removeProp('checked');
    }
}
function setCheckBoxs(boxName, obj) {
    if (boxName == undefined || boxName == 'undefined' || boxName == null || boxName == '') return;
    if ($(obj).prop('checked')) {
        $('input[name="' + boxName + '"]').prop('checked', 'true');
    }
    else {
        $('input[name="' + boxName + '"]').removeProp('checked');
    }
}
/*----------------------------------------------------------
----- 宽高比动态计算
----------------------------------------------------------*/
var dynSetGlobalHeight = function () {
    var widH = $(window).height();
    var headH = $('header').height();
    var footH = $('footer').height();
    var otherH = 6; //线条、间距等宽度
    var mainH = widH - headH - footH - otherH;
    $('#main-content').height(mainH);
    var boxHead = $('.content-box-header').height();
    var boxBody = mainH - boxHead - otherH;
    $('.content-box-content').height(boxBody);
};
/*----------------------------------------------------------
----- 全局初始化操作
----------------------------------------------------------*/
//页面加载完成后立即执行代码
$(function () {
    //-----提示信息关闭按钮
    $(".close").click(
        function () {
            $(this).parent().fadeTo(400, 0, function () { // Links with the class "close" will close parent
                $(this).slideUp(400);
            });
            return false;
        }
    );
    //-----主内容区域收缩
    //Minimize Content Box
    $(".closed-box .content-box-content").hide();
    $(".closed-box .content-box-tabs").hide();
    $(".content-box-header span").click(
        function () {
            $(this).parent().next().toggle();
            $(this).parent().parent().toggleClass("closed-box");
            $(this).parent().find(".content-box-tabs").toggle();
        }
    );
    // Content box tabs:
    $('.content-box .content-box-content div.tab-content').hide();
    $('ul.content-box-tabs li a.default-tab').addClass('current');
    $('.content-box-content div.default-tab').show();
    $('.content-box ul.content-box-tabs li a').click(
        function () {
            $(this).parent().siblings().find("a").removeClass('current');
            $(this).addClass('current');
            var currentTab = $(this).attr('href');
            $(currentTab).siblings().hide();
            $(currentTab).show();
            return false;
        }
    );
    dynSetGlobalHeight();
});
//重新初始化页面大小
$(window).resize(function () {
    dynSetGlobalHeight();
});