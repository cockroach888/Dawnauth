/*----------------------------------------------------------
------ 功能定义
----------------------------------------------------------*/
var DawnPopConfirm = art.dialog.confirm;
var DawnPopTips = art.dialog.tips;
var DawnPopDataPass = art.dialog.data;
/*----------------------------------------------------------
------ 关闭所有弹窗窗口
----------------------------------------------------------*/
var DawnPopCloseAll = function () {
    var list = art.dialog.list;
    for (var i in list) {
        list[i].close();
    };
    art.dialog.close();
};
/*----------------------------------------------------------
------ 跟随指定元素弹窗窗口
----------------------------------------------------------*/
var DawnPopFollow = function (param) {
    DawnPopCloseAll();
    art.dialog(param);
};
/*----------------------------------------------------------
------ 获得自定义提示图标类型
----------------------------------------------------------*/
function DawnPopGetIcon(index) {
    var result = 'succeed';
    switch (index) {
        case 1:
            result = 'succeed';
            break;
        case 2:
            result = 'question';
            break;
        case 3:
            result = 'warning';
            break;
        case 4:
            result = 'error';
            break;
        case 5:
            result = 'loading';
            break;
        case 6:
            result = 'face-smile';
            break;
        case 7:
            result = 'face-sad';
            break;
        default:
            result = 'succeed';
            break;
    }
    return result;
}
/*----------------------------------------------------------
------ 通用消息提示
----------------------------------------------------------*/
function DawnPopMsgbox(index, strMsg) {
    art.dialog({
        id: 'DawnPopMsgbox'
        , title: '系统提示'
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , icon: DawnPopGetIcon(index)
        , cancelVal: '关闭'
        , cancel: true
    });
}
function DawnPopMsgbox2(index, strMsg) {
    art.dialog({
        id: 'DawnPopMsgbox2'
        , title: '系统提示'
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , icon: DawnPopGetIcon(index)
        , cancel: false
    });
}
/*----------------------------------------------------------
------ 通用消息提示 - 自动关闭 - 2秒后关闭
----------------------------------------------------------*/
function DawnPopMsgboxOf2s(index, strMsg) {
    art.dialog({
        id: 'DawnPopMsgboxOf2s'
        , title: '系统提示[2秒后关闭]'
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , icon: DawnPopGetIcon(index)
        , time: 2
        , cancelVal: '关闭'
        , cancel: true        
    });
}
/*----------------------------------------------------------
------ 通用消息提示 - 自动关闭 - 自定义关闭时间（秒）
----------------------------------------------------------*/
function DawnPopMsgboxOfTime(index, strMsg, interval) {
    var strTitle = '系统提示[' + interval + '秒后关闭]';
    art.dialog({
        id: 'DawnPopMsgboxOfTime'
        , title: strTitle
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , icon: DawnPopGetIcon(index)
        , time: interval
        , cancelVal: '关闭'
        , cancel: true        
    });
}
/*----------------------------------------------------------
------ 通用消息提示 - 关闭所有窗体 - 2秒后关闭
----------------------------------------------------------*/
function DawnPopMsgcloseOf2s(index, strMsg) {
    art.dialog({
        id: 'DawnPopMsgcloseOf2s'
        , title: '系统提示[2秒后关闭]'
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , icon: DawnPopGetIcon(index)
        , time: 2
        , cancelVal: '关闭'
        , cancel: function () {
            DawnPopCloseAll();
        }
    });
}
/*----------------------------------------------------------
------ 通用消息提示 - 关闭所有窗体 - 自定义关闭时间（秒）
----------------------------------------------------------*/
function DawnPopMsgcloseOfTime(index, strMsg, interval) {
    var strTitle = '系统提示[' + interval + '秒后关闭]';
    art.dialog({
        id: 'DawnPopMsgcloseOfTime'
        , title: strTitle
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , icon: DawnPopGetIcon(index)
        , time: interval
        , cancelVal: '关闭'
        , cancel: function () {
            DawnPopCloseAll();
        }
    });
}
/*----------------------------------------------------------
------ 通用消息提示 - 页面跳转 - 2秒后跳转
----------------------------------------------------------*/
function DawnPopMsgjumpOf2s(index, strMsg, strUrl) {
    art.dialog({
        id: 'DawnPopMsgjumpOf2s'
        , title: '系统提示[2秒后跳转]'
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , icon: DawnPopGetIcon(index)
        , time: 2
        , cancelVal: '关闭'
        , cancel: function () {
            window.location.href = strUrl;
        }        
    });
}
/*----------------------------------------------------------
------ 通用消息提示 - 页面跳转 - 自定义跳转时间（秒）
----------------------------------------------------------*/
function DawnPopMsgjumpOfTime(index, strMsg, strUrl, interval) {
    var strTitle = '系统提示[' + interval + '秒后关闭]';
    art.dialog({
        id: 'DawnPopMsgjumpOfTime'
        , title: strTitle
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , icon: DawnPopGetIcon(index)
        , time: interval
        , cancelVal: '关闭'
        , cancel: function () {
            window.location.href = strUrl;
        }
    });
}
/*----------------------------------------------------------
------ 通用消息提示 - 父页面跳转 - 2秒后跳转
----------------------------------------------------------*/
function DawnPopMsgparentOf2s(index, strMsg, strUrl) {
    art.dialog({
        id: 'DawnPopMsgparentOf2s'
        , title: '系统提示[2秒后跳转]'
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , icon: DawnPopGetIcon(index)
        , time: 2
        , cancelVal: '关闭'
        , cancel: function () {
            window.parent.href = strUrl;
        }
    });
}
/*----------------------------------------------------------
------ 通用消息提示 - 父页面跳转 - 自定义跳转时间（秒）
----------------------------------------------------------*/
function DawnPopMsgparentOfTime(index, strMsg, strUrl, interval) {
    var strTitle = '系统提示[' + interval + '秒后关闭]';
    art.dialog({
        id: 'DawnPopMsgparentOfTime'
        , title: strTitle
        , content: strMsg
        , lock: true
        , padding: '20px 25px'
        , icon: DawnPopGetIcon(index)
        , time: interval
        , cancelVal: '关闭'
        , cancel: function () {
            window.parent.href = strUrl;
        }
    });
}
/*----------------------------------------------------------
------ 通用IFrame框架 - 窗口弹出 - 默认宽高
----------------------------------------------------------*/
function DawnPopIFrame(strTitle, strUrl) {
    art.dialog.open(strUrl, {
        id: 'DawnPopIFrame'
        , title: strTitle        
        , lock: true
        , padding: '20px 25px'
        , width: 660
        , height: 550
    });
}
/*----------------------------------------------------------
------ 通用IFrame框架 - 窗口弹出 - 自定义宽高
----------------------------------------------------------*/
function DawnPopIFrameHW(strTitle, strUrl, valWeight, valHeight) {
    art.dialog.open(strUrl, {
        id: 'DawnPopIFrameHW'
        , title: strTitle
        , lock: true
        , padding: '20px 25px'
        , width: valWeight
        , height: valHeight
    });
}
/*----------------------------------------------------------
------ 通用IFrame框架 - 父窗体重新加载 - 默认宽高
----------------------------------------------------------*/
function DawnPopIFrameReload(strTitle, strUrl) {
    art.dialog.open(strUrl, {
        id: 'DawnPopIFrameReload'
        , title: strTitle
        , lock: true
        , padding: '20px 25px'
        , width: 660
        , height: 550
        , close: function () {
            loadContent();
        }
    });
}
/*----------------------------------------------------------
------ 通用IFrame框架 - 父窗体重新加载 - 自定义宽高
----------------------------------------------------------*/
function DawnPopIFrameReloadHW(strTitle, strUrl, valWeight, valHeight) {
    art.dialog.open(strUrl, {
        id: 'DawnPopIFrameReloadHW'
        , title: strTitle
        , lock: true
        , padding: '20px 25px'
        , width: valWeight
        , height: valHeight
        , close: function () {
            loadContent();
        }
    });
}
/*----------------------------------------------------------
------ 通用IFrame框架 - 指定对象赋值 - 默认宽高
----------------------------------------------------------*/
function DawnPopIFrameTrans(objTrans, strTitle, strUrl) {
    art.dialog.open(strUrl, {
        id: 'DawnPopIFrameTrans'
        , title: strTitle
        , lock: true
        , padding: '20px 25px'
        , width: 660
        , height: 550
        , close: function () {
            $(objTrans).val(DawnPopDataPass('TransmitValue'));
        }
    });
}
/*----------------------------------------------------------
------ 通用IFrame框架 - 指定对象赋值 - 自定义宽高
----------------------------------------------------------*/
function DawnPopIFrameTransHW(objTrans, trTitle, strUrl, valWeight, valHeight) {
    art.dialog.open(strUrl, {
        id: 'DawnPopIFrameTransHW'
        , title: strTitle
        , lock: true
        , padding: '20px 25px'
        , width: valWeight
        , height: valHeight
        , close: function () {
            $(objTrans).val(DawnPopDataPass('TransmitValue'));
        }
    });
}