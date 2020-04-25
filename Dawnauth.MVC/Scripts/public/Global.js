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
    window.location.href = url;
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
----- 回到顶部
----------------------------------------------------------*/
function goTopEx() {
    var obj = document.getElementById("goTopBtn");
    function getScrollTop() {
        return document.documentElement.scrollTop;
    }
    function setScrollTop(value) {
        document.documentElement.scrollTop = value;
    }
    window.onscroll = function () { getScrollTop() > 0 ? obj.style.display = "" : obj.style.display = "none"; }
    obj.onclick = function () {
        var goTop = setInterval(scrollMove, 10);
        function scrollMove() {
            setScrollTop(getScrollTop() / 1.1);
            if (getScrollTop() < 1) clearInterval(goTop);
        }
    }
}
/*----------------------------------------------------------
----- 时钟
----------------------------------------------------------*/
function Clock() {
    var date = new Date();
    this.year = date.getFullYear();
    this.month = date.getMonth() + 1;
    this.date = date.getDate();
    this.month = this.month < 10 ? "0" + this.month : this.month;
    this.day = new Array("星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六")[date.getDay()];
    this.hour = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
    this.minute = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
    this.second = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();

    this.toString = function () {
        //var result = '日期：';
        var result = null;
        result += this.year;
        result += '年';
        result += this.month;
        result += '月';
        result += this.date;
        result += '日';
        result += ' ';
        result += this.hour;
        result += ':';
        result += this.minute;
        result += ':';
        result += this.second;
        result += ' ';
        result += this.day;
        return result;
    };

    this.toSimpleDate = function () {
        return this.year + "-" + this.month + "-" + this.date;
    };

    this.toDetailDate = function () {
        return this.year + "-" + this.month + "-" + this.date + " " + this.hour + ":" + this.minute + ":" + this.second;
    };

    this.display = function (ele) {
        var clock = new Clock();
        ele.innerHTML = clock.toString();
        window.setTimeout(function () { clock.display(ele); }, 1000);
    };
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
    goTopEx();
    //-----时钟    
    var clock = new Clock();
    clock.display(document.getElementById("clock"));
    //-----左侧导航菜单
    $("#main-nav li ul").hide(); // Hide all sub menus
    $("#main-nav li a.current").parent().find("ul").slideToggle("slow"); // Slide down the current menu item's sub menu		
    $("#main-nav li a.nav-top-item").click( // When a top menu item is clicked...
        function () {
            $(this).parent().siblings().find("ul").slideUp("normal"); // Slide up all sub menus except the one clicked
            $(this).next().slideToggle("normal"); // Slide down the clicked sub menu
            return false;
        }
    );
    $("#main-nav li a.no-submenu").click( // When a menu item with no sub menu is clicked...
        function () {
            window.location.href = (this.href); // Just open the link instead of a sub menu
            return false;
        }
    );
    //-----左侧导航菜单激活效果
    $("#main-nav li .nav-top-item").hover(
        function () {
            $(this).stop().animate({ paddingRight: "25px" }, 200);
        },
        function () {
            $(this).stop().animate({ paddingRight: "15px" });
        }
    );
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