using System;
using System.Collections;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.Dawnauth.Handler;
using DawnXZ.DawnUtility;
using DawnXZ.WebUtility;

namespace DawnXZ.Dawnauth.Libraries
{
    /// <summary>
    /// 晨曦小竹权限云管理系统
    /// <para>权限验证通用类库</para>
    /// </summary>
    public class DawnAuthlib
    {

        #region 成员字段属性

        /// <summary>
        /// 基本提示信息正文
        /// </summary>
        public static string FBaseInfo { get { return GeneralHandler.FBaseInfo; } }
        /// <summary>
        /// 无记录提示信息正文
        /// </summary>
        public static string FNoneInfo { get { return GeneralHandler.FNoneInfo; } }
        /// <summary>
        /// 权限验证提示标题
        /// </summary>
        public static string FAccessTitle { get { return GeneralHandler.FAccessTitle; } }
        /// <summary>
        /// 权限验证提示正文
        /// </summary>
        public static string FAccessMessage { get { return GeneralHandler.FAccessMessage; } }

        #endregion

        #region 成员属性

        /// <summary>
        /// 默认无触发链接URL
        /// </summary>
        public static string DefaultUrl { get { return GeneralHandler.DefaultUrl; } }
        /// <summary>
        /// 站点URL
        /// </summary>
        public static string SiteUrl { get { return GeneralHandler.SiteUrl; } }
        /// <summary>
        /// 站点名称
        /// </summary>
        public static string SiteName { get { return GeneralHandler.SiteName; } }
        /// <summary>
        /// 站点登录URL
        /// </summary>
        public static string SiteLoginUrl { get { return GeneralHandler.SiteLoginUrl; } }
        /// <summary>
        /// 站点登录完成URL
        /// </summary>
        public static string SiteLoginedUrl { get { return GeneralHandler.SiteLoginedUrl; } }
        /// <summary>
        /// 令牌键值
        /// </summary>
        public static string TokenKey { get { return GeneralHandler.TokenKey; } }

        #endregion

        #region 成员状态消息属性

        /// <summary>
        /// 已存在
        /// </summary>
        public static string StateAdded { get { return GeneralHandler.StateAdded; } }
        /// <summary>
        /// 成功
        /// </summary>
        public static string StateSuccess { get { return GeneralHandler.StateSuccess; } }
        /// <summary>
        /// 失败
        /// </summary>
        public static string StateFailing { get { return GeneralHandler.StateFailing; } }
        /// <summary>
        /// 页面需要刷新
        /// </summary>
        public static string StateRefresh { get { return GeneralHandler.StateRefresh; } }

        #endregion

        #region 成员用户属性

        /// <summary>
        /// 管理员名称
        /// </summary>
        public static string UserName { get { return DawnauthHandler.UserName; } }
        /// <summary>
        /// 管理员编号
        /// </summary>
        public static int UserId { get { return DawnauthHandler.UserId; } }
        /// <summary>
        /// 管理员姓名
        /// </summary>
        public static string UserSurname { get { return DawnauthHandler.UserSurname; } }
        /// <summary>
        /// 管理员信息
        /// </summary>
        public static DawnAuthUserMDL UserInfo { get { return DawnauthHandler.UserInfo; } }

        #endregion

        #region 成员方法
        
        /// <summary>
        /// 清除登录相关信息
        /// </summary>
        public static void ClearLogin()
        {
            DawnauthHandler.ClearLogin();
        }
        /// <summary>
        /// 验证用户是否具有指定功能的权限
        /// </summary>
        /// <param name="moduleCode">模块编码</param>
        /// <param name="functionMark">功能标识</param>
        /// <returns>执行结果</returns>
        public static bool VerifyModule(string moduleCode, int functionMark)
        {
            return DawnauthHandler.VerifyModule(moduleCode, functionMark);
        }
        /// <summary>
        /// 验证用户是否具有指定状态机制的操作权限
        /// </summary>
        /// <param name="moduleCode">模块编码</param>
        /// <param name="status">数据状态</param>
        /// <returns>执行结果</returns>
        public static bool VerifyStatus(string moduleCode,int status)
        {
            return DawnauthHandler.VerifyStatus(moduleCode, status);
        }
        /// <summary>
        /// 验证用户是否具有指定的模块与功能权限
        /// <para>验证方式：</para>
        /// <para>模块识别码及功能识别码</para>
        /// </summary>
        /// <param name="identModule">模块识别码</param>
        /// <param name="identFunction">功能识别码</param>
        /// <returns>执行结果</returns>
        public static bool VerifyRealtime(int identModule, int identFunction)
        {
            return DawnauthHandler.VerifyRealtime(identModule, identFunction);
        }
        /// <summary>
        /// 验证用户是否具有指定的权限扩展标识权限
        /// </summary>
        /// <param name="exteCode">权限扩展编码</param>
        /// <param name="exteMark">权限扩展标识</param>
        /// <returns>执行结果</returns>
        public static bool VerifyExtent(string exteCode, string exteMark)
        {
            return DawnauthHandler.VerifyExtent(exteCode, exteMark);
        }
        /// <summary>
        /// 获取用户指定权限扩展编码的扩展标识字符串
        /// <para>格式：1,2,3,4,5</para>
        /// </summary>
        /// <param name="exteCode">权限扩展编码</param>
        /// <param name="dataType">数据类型（1string，2int）</param>
        /// <returns>权限扩展标识字符串</returns>
        public static string UserExtentString(string exteCode, byte dataType)
        {
            return DawnauthHandler.UserExtentString(exteCode, dataType);
        }
        /// <summary>
        /// 用户登录验证
        /// <para>返回的哈希表包含键值：</para>
        /// <para>Msg 消息正文，值为[refresh]时需要刷新整个页面</para>
        /// <para>Url 跳转的URL链接</para>
        /// <para>IsCode 刷新验证码</para>
        /// </summary>
        /// <param name="userName">帐号名称</param>
        /// <param name="userPwd">帐号密码</param>
        /// <param name="checkCode">验证码</param>
        /// <param name="returnUrl">登录跳转页面</param>
        /// <param name="outEx">异常信息对象</param>
        /// <returns>验证结果</returns>
        public static Hashtable VerifyLogin(string userName, string userPwd, string checkCode, string returnUrl, out Exception outEx)
        {
            return DawnauthHandler.VerifyLogin(userName, userPwd, checkCode, returnUrl, out outEx);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="userPwd">用户密码</param>
        public static void ChangePassword(int userId, string userPwd)
        {
            DawnauthHandler.ChangePassword(userId, userPwd);
        }
        /// <summary>
        /// 注销登录
        /// </summary>
        public static void Logout()
        {
            DawnauthHandler.ClearLogin();
            CookieHelper.Add("logout", "unsafe", 1);
        }
        /// <summary>
        /// 退出系统
        /// </summary>
        public static void Exit()
        {
            DawnauthHandler.ClearLogin();
            CookieHelper.Add("logout", "safe", 1);
        }

        #endregion

    }
}