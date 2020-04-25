using System;
using System.Web.Mvc;
using DawnXZ.Dawnauth.Libraries;
using DawnXZ.HDWM.Libraries.Entity;
using DawnXZ.HDWM.Libraries.BLL;
using DawnXZ.HDWM.WebSite.Models;
using DawnXZ.Tools;

namespace DawnXZ.HDWM.WebSite.Filters
{
    /// <summary>
    /// 控制器动作和结果执行过滤器
    /// </summary>
    public class ActionExecutFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 动作执行时需要处理的信息
        /// <para>记录执行动作</para>
        /// <para>动作执行时</para>
        /// </summary>
        /// <param name="filterContext">动作执行上下文</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (WeighingHandler.AutoSyslog)
            {
                DawnWfmpSyslogMDL dataInfo = new DawnWfmpSyslogMDL();
                dataInfo.LogTime = DateTime.Now;
                dataInfo.LogRating = 1;
                dataInfo.LogTable = string.Format("{0} - {1}", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName);
                dataInfo.LogAction = string.Format("{0} - {1} - {2} - {3}", filterContext.Controller.ToString(), DawnRequest.GetIPAddressByNet(), DawnRequest.GetMacAddress().ToUpper(), DawnRequest.GetIP());
                dataInfo.LogMemo = string.Format("{0} - {1} - {2}", filterContext.HttpContext.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff"), DawnRequest.GetUrlByRaw(), DawnRequest.GetUrlByReferrer());
                dataInfo.LogUid = DawnAuthlib.UserId < 1 ? -1 : DawnAuthlib.UserId;
                dataInfo.LogUname = string.IsNullOrEmpty(DawnAuthlib.UserSurname) ? "匿名用户" : DawnAuthlib.UserSurname;
                DawnWfmpSyslogBLL.Insert(dataInfo);
            }
        }
        /// <summary>
        /// 动作执行时需要处理的信息
        /// <para>动作执行完成</para>
        /// </summary>
        /// <param name="filterContext">动作执行上下文</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
        /// <summary>
        /// 结果执行时需要处理的信息
        /// <para>结果执行时</para>
        /// </summary>
        /// <param name="filterContext">结果执行上下文</param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
        /// <summary>
        /// 结果执行时需要处理的信息
        /// <para>结果执行完成</para>
        /// </summary>
        /// <param name="filterContext">结果执行上下文</param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}