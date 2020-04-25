using System;
using System.Web.Mvc;
using System.Web.Routing;
using DawnXZ.Dawnauth.Handler;
using DawnXZ.DawnUtility;
using DawnXZ.FileUtility;

namespace DawnXZ.Dawnauth.MVC.Filters
{
    /// <summary>
    /// 异常信息过滤器
    /// </summary>
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {

        #region 成员变量

        /// <summary>
        /// 操作日志文件记录器
        /// </summary>
        private LogHelper FLogger;

        #endregion

        #region 成员属性

        /// <summary>
        /// 消息提示模式
        /// <para>1 正常窗体模式</para>
        /// <para>2 弹出窗体模式</para>
        /// <para>3 字符串内容模式</para>
        /// </summary>
        public byte TipsMode { get; private set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tipsMode">
        /// 消息提示模式
        /// <para>1 正常窗体模式</para>
        /// <para>2 弹出窗体模式</para>
        /// <para>3 字符串内容模式</para>
        /// </param>
        /// <param name="seqOrder">执行次序</param>
        public ExceptionFilter(byte tipsMode = 1, int seqOrder = 9999)
        {
            TipsMode = tipsMode;
            Order = seqOrder;
        }

        #endregion

        #region 成员方法

        /// <summary>
        /// 出现异常时
        /// </summary>
        /// <param name="filterContext">异常上下文</param>
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                //写操作日志文件
                if (null == this.FLogger) {
                    var logPath = System.IO.Path.Combine(FileHelper.AppPath, "logs", "Exception");
                    this.FLogger = new LogHelper(logPath, 2, LogType.Hour);
                }
                this.FLogger.Write(filterContext.Exception.Message, MessageType.Error);
                GeneralHandler.InsertByError(filterContext.Exception); //写入数据库
                var result = "Login";
                switch (TipsMode) {
                    case 1:
                        result = "ErrorBody";
                        break;
                    case 2:
                        result = "ErrorDialog";
                        break;
                    case 3:
                        result = "ErrorContent";
                        break;
                }
                filterContext.HttpContext.Session["ErrorMessage"] = filterContext.Exception.Message;
                filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { controller = "Auth", action = result }));
                filterContext.ExceptionHandled = true;
            }
        }

        #endregion

    }
}