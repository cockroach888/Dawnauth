using System;
using System.Web.Mvc;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.Dawnauth.BLL;
using DawnXZ.Dawnauth.Handler;
using DawnXZ.DawnUtility;
using DawnXZ.WebUtility;
using DawnXZ.FileUtility;

namespace DawnXZ.Dawnauth.MVC.Filters
{
    /// <summary>
    /// 控制器动作和结果执行过滤器
    /// </summary>
    public class ActionExecutFilter : ActionFilterAttribute
    {
        #region 成员变量

        /// <summary>
        /// 操作日志文件记录器
        /// </summary>
        private LogHelper FLogger;

        #endregion

        #region 成员重写方法

        /// <summary>
        /// 动作执行时需要处理的信息
        /// <para>记录执行动作</para>
        /// <para>动作执行时</para>
        /// </summary>
        /// <param name="filterContext">动作执行上下文</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //写操作日志文件
            if (null == this.FLogger) {
                var logPath = System.IO.Path.Combine(FileHelper.AppPath, "logs", "Action");
                this.FLogger = new LogHelper(logPath, 2, LogType.Hour);
            }
            this.FLogger.Write(string.Format("控制器名称：{0}", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName));
            this.FLogger.Write(string.Format("动作名称：{0}", filterContext.ActionDescriptor.ActionName));
            this.FLogger.Write(string.Format("　　客户端请求时间：{0}", filterContext.HttpContext.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff")));
            this.FLogger.Write(string.Format("　　　客户端IP地址：{0}", RequestHelper.GetIPAddress()));
            this.FLogger.Write(string.Format("客户端IP地址[强制]：{0}", RequestHelper.GetIPAddressAt()));
            this.FLogger.Write(string.Format("　　 客户端MAC地址：{0}", "Unknown"));
            this.FLogger.Write(string.Format("　　客户端原始地址：{0}", RequestHelper.GetUrlOfRaw()));
            this.FLogger.Write(string.Format("　　客户端来源地址：{0}", RequestHelper.GetUrlOfReferrer()));
            this.FLogger.Write(string.Format("　　客户端访问方式：{0}", RequestHelper.IsBrowserGet() ? "来自于浏览器" : "非浏览器访问"));
            this.FLogger.Write(string.Format("　客户端浏览器类型：{0}", RequestHelper.GetClientOfType()));
            this.FLogger.Write(string.Format("　客户端浏览器名称：{0}", RequestHelper.GetClientOfBrowser()));
            this.FLogger.Write(string.Format("客户端浏览器主版本：{0}", RequestHelper.GetClientOfMajorVersion()));
            this.FLogger.Write(string.Format("客户端浏览器版本号：{0}", RequestHelper.GetClientOfVersion()));
            this.FLogger.Write(string.Format("　客户端远程IP地址：{0}", RequestHelper.GetClientOfUserHostAddress()));
            this.FLogger.Write(string.Format(" 客户端远程DNS名称：{0}", RequestHelper.GetClientOfUserHostName()));
            this.FLogger.Write(string.Format("　　客户端操作系统：{0}", RequestHelper.GetClientOfPlatform()));
            this.FLogger.Write(string.Format("客户端是否16位环境：{0}", RequestHelper.GetClientOfWin16()));
            this.FLogger.Write(string.Format("客户端是否32位环境：{0}", RequestHelper.GetClientOfWin32()));
            this.FLogger.Write(string.Format("　　客户端用户编号：{0}", DawnauthHandler.UserId));
            this.FLogger.Write(string.Format("　　客户端用户名称：{0}", DawnauthHandler.UserName));
            this.FLogger.Write(string.Format("　　客户端用户姓名：{0}", DawnauthHandler.UserSurname));
            this.FLogger.Write("\r\n\r\n");
            //写入数据库
            DawnAuthLogsMDL dataInfo = new DawnAuthLogsMDL();
            dataInfo.LogTime = DateTime.Now;
            dataInfo.LogRating = 1;
            dataInfo.LogTable = string.Format("{0} - {1}", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName);
            dataInfo.LogAction = string.Format("{0} - {1} - {2} - {3}", filterContext.Controller.ToString(), RequestHelper.GetIPAddressAt(), "Unknown", RequestHelper.GetIPAddress());
            dataInfo.LogMemo = string.Format("{0} - {1} - {2}", filterContext.HttpContext.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff"), RequestHelper.GetUrlOfRaw(), RequestHelper.GetUrlOfReferrer());
            dataInfo.LogUid = DawnauthHandler.UserId < 1 ? -1 : DawnauthHandler.UserId;
            dataInfo.LogUname = string.IsNullOrEmpty(DawnauthHandler.UserSurname) ? "匿名用户" : DawnauthHandler.UserSurname;
            DawnAuthLogsBLL.Insert(dataInfo);
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

        #endregion

    }
}