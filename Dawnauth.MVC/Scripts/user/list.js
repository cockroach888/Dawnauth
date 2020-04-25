/*----------------------------------------------------------
----    内容异步装载
----------------------------------------------------------*/
var loadContent = function () {
    var url = '/User/List/1/';
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
function dataDelete(uid, uname) {
    if (uid.length <= 0) return false;
    DawnPopConfirm('您确定要删除管理员 [' + uname + '] 的数据吗？', function () {
        $.ajax({
            url: '/User/Delete'
            , data: ({ id: uid })
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
        $('#dataShowArea tr.alt-selected').removeClass('alt-selected');
    }, function () {
        DawnPopTips(MsgCancel);
        $('#dataShowArea tr.alt-selected').removeClass('alt-selected');
    });
}
/*----------------------------------------------------------
----    气泡数据操作菜单
----------------------------------------------------------*/
function ShowOperate(object, uid, surname, uname, loginname) {
    $('#dataShowArea tr.alt-selected').removeClass('alt-selected');
    $(object).addClass('alt-selected');
    if (uname != loginname) {
        DawnPopFollow({
            id: 'popfollowto'
            , title: surname + ' - 数据操作'
            , content: '管理员名称：' + surname
            , lock: true
            , padding: '20px 25px'
            , follow: object
            , opacity: 0.37
            , button: [
                {
                    name: '角色绑定',
                    callback: function () {
                        var title = surname;
                        title += ' - 角色绑定';
                        var url = '/User/BindRole/';
                        url += uid;
                        DawnPopIFrameReload(title, url);
                    }
                },
                {
                    name: '机制绑定',
                    callback: function () {
                        var url = '/User/BindStatus/';
                        url += uid;
                        url += '/';
                        url += $('#hidPageCurrent').val();
                        GotoHref(url);
                    }
                },
                {
                    name: '权限绑定',
                    callback: function () {
                        var url = '/User/BindPower/';
                        url += uid;
                        url += '/';
                        url += $('#hidPageCurrent').val();
                        GotoHref(url);
                    }
                },
                {
                    name: '权限扩展',
                    callback: function () {
                        var url = '/User/BindExtent/';
                        url += uid;
                        url += '/';
                        url += $('#hidPageCurrent').val();
                        GotoHref(url);
                    }
                },
                {
                    name: '密码初始',
                    callback: function () {
                        dataReset(uid, surname);
                    }
                },
                {
                    name: '登录日志',
                    callback: function () {
                        GotoHref('/User/LoginDetailed/' + uid);
                    }
                },
                {
                    name: '照片补传',
                    callback: function () {
                        var title = surname;
                        title += ' - 照片补传';
                        var url = '/User/Photo/';
                        url += uid;
                        DawnPopIFrameReload(title, url);
                    }
                },
                {
                    name: '数据编辑',
                    callback: function () {
                        var url = '/User/Editor/';
                        url += uid;
                        url += '/';
                        url += $('#hidPageCurrent').val();
                        GotoHref(url);
                    }
                },
                {
                    name: '数据删除',
                    callback: function () {
                        dataDelete(uid, surname);
                    }
                }
            ]
            , cancel: function () {
                $(object).removeClass('alt-selected');
            }
            , cancelVal: '关闭'
        });
    }
    else {
        DawnPopFollow({
            id: 'popfollowto'
            , title: surname + ' - 数据操作'
            , content: '管理员名称：' + surname
            , lock: true
            , padding: '20px 25px'
            , follow: object
            , opacity: 0.37
            , button: [
                {
                    name: '角色绑定',
                    callback: function () {
                        var title = surname;
                        title += ' - 角色绑定';
                        var url = '/User/BindRole/';
                        url += uid;
                        DawnPopIFrameReload(title, url);
                    }
                },
                {
                    name: '机制绑定',
                    callback: function () {
                        var url = '/User/BindStatus/';
                        url += uid;
                        url += '/';
                        url += $('#hidPageCurrent').val();
                        GotoHref(url);
                    }
                },
                {
                    name: '权限绑定',
                    callback: function () {
                        var url = '/User/BindPower/';
                        url += uid;
                        url += '/';
                        url += $('#hidPageCurrent').val();
                        GotoHref(url);
                    }
                },
                {
                    name: '权限扩展',
                    callback: function () {
                        var url = '/User/BindExtent/';
                        url += uid;
                        url += '/';
                        url += $('#hidPageCurrent').val();
                        GotoHref(url);
                    }
                },
                {
                    name: '照片补传',
                    callback: function () {
                        var title = surname;
                        title += ' - 照片补传';
                        var url = '/User/Photo/';
                        url += uid;
                        DawnPopIFrameReload(title, url);
                    }
                },
                {
                    name: '数据编辑',
                    callback: function () {
                        var url = '/User/Editor/';
                        url += uid;
                        url += '/';
                        url += $('#hidPageCurrent').val();
                        GotoHref(url);
                    }
                }
            ]
            , cancel: function () {
                $(object).removeClass('alt-selected');
            }
            , cancelVal: '关闭'
        });
    }
}
/*----------------------------------------------------------
----    重置管理员密码
----------------------------------------------------------*/
function dataReset(uid, surname) {
    if (uid <= 0) return false;
    DawnPopConfirm('您确定要重置管理员 [' + surname + '] 的密码吗？', function () {
        var objData = [
            { name: '__RequestVerificationToken', value: $('input[name="__RequestVerificationToken"]').val() }
            , { name: 'id', value: uid }
        ];
        $.ajax({
            url: '/User/Reset'
            , data: objData
            , type: 'POST'
            , success: function (data) {
                if (data != 'failing') {
                    var msg = '密码成功重置为：<span class="color-red">';
                    msg += data;
                    msg += '</span>';
                    msg += ' 请及时修改密码！';
                    DawnPopMsgbox(1, msg);
                }
                else {
                    DawnPopMsgboxOf2s(3, MsgFailing);
                }
            }
            , error: function (msg) {
                DawnPopMsgbox(4, MsgError);
            }
        });
        $('#dataShowArea tr.alt-selected').removeClass('alt-selected');
    }, function () {
        DawnPopTips(MsgCancel);
        $('#dataShowArea tr.alt-selected').removeClass('alt-selected');
    });
}
/*----------------------------------------------------------
----    页面加载完成后立即执行代码
----------------------------------------------------------*/
$(function () {
    
});
/*----------------------------------------------------------
----    重新初始化页面大小
----------------------------------------------------------*/
$(window).resize(function () {

});