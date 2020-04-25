using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DawnXZ.Dawnauth.Libraries;

namespace DawnXZ.HDWM.WebSite.Filters
{
    /// <summary>
    /// 登录验证过滤器
    /// </summary>
    public class LoginedFilter : AuthorizeAttribute
    {

        #region 成员重写方法

        /// <summary>
        /// 自定义授权检查
        /// </summary>
        /// <param name="httpContext">
        /// <para>HTTP 上下文</para>
        /// <para>封装有关单个 HTTP 请求的所有 HTTP 特定的信息</para>
        /// </param>
        /// <returns>执行结果</returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null) return false;
            if (httpContext.User.Identity.IsAuthenticated)
            {
                if (DawnAuthlib.UserId > 0 && !string.IsNullOrEmpty(DawnAuthlib.UserName) && DawnAuthlib.UserInfo != null)
                {
                    return true;
                }
                else
                {
                    DawnAuthlib.ClearLogin();
                    httpContext.Response.StatusCode = 401;
                }
            }
            return false;
        }
        /// <summary>
        /// 处理未能授权的 HTTP 请求
        /// </summary>
        /// <param name="filterContext">
        /// <para>控制器</para>
        /// <para>HTTP 上下文</para>
        /// <para>请求上下文</para>
        /// <para>操作结果</para>
        /// <para>路由数据</para>
        /// </param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }
        /// <summary>
        /// 在过程请求授权时调用
        /// </summary>
        /// <param name="filterContext">
        /// <para>筛选器上下文</para>
        /// <para>封装有关使用 System.Web.Mvc.AuthorizeAttribute 的信息</para>
        /// </param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.HttpContext.Response.StatusCode == 401)
            {
                filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { controller = "Auth", action = "Login" }));
            }
        }
        /// <summary>
        /// 在缓存模块请求授权时调用
        /// </summary>
        /// <param name="httpContext">
        /// <para>HTTP 上下文</para>
        /// <para>封装有关单个 HTTP 请求的所有 HTTP 特定的信息</para>
        /// </param>
        /// <returns>对验证状态的引用</returns>
        protected override HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
        {
            return base.OnCacheAuthorization(httpContext);
        }

        #endregion

    }
}