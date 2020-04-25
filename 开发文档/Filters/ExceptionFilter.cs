using System;
using System.Web.Mvc;
using System.Web.Routing;
using DawnXZ.Dawnauth.Libraries;
using DawnXZ.HDWM.Libraries.BLL;
using DawnXZ.HDWM.Libraries.Entity;
using DawnXZ.Tools;

namespace DawnXZ.HDWM.WebSite.Filters
{
    /// <summary>
    /// 异常信息过滤器
    /// </summary>
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {

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
                DawnLogHelper logger = new DawnLogHelper();
                logger.Write(filterContext.Exception.Message, DawnMessageType.Error);
                logger.Dispose();
                this.InsertByError(filterContext.Exception);
                var result = "Login";
                switch (TipsMode)
                {
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

        #region 记录错误日志

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="ex">错误数据对象</param>
        /// <returns></returns>
        private int InsertByError(Exception ex)
        {
            try
            {
                if ((ex is System.Threading.ThreadAbortException)) return -1;
                DawnWfmpErrorMDL errInfo = new DawnWfmpErrorMDL();
                if (ex.InnerException != null)
                {
                    errInfo.ErrTime = System.DateTime.Now;
                    errInfo.ErrAddress = string.IsNullOrEmpty(DawnRequest.GetUrl()) == true ? "非法数据！（页面信息）" : DawnRequest.GetUrl();
                    errInfo.ErrMessage = string.IsNullOrEmpty(ex.InnerException.Message) == true ? "非法数据！（错误日志）" : ex.InnerException.Message;
                    errInfo.ErrTarget = string.IsNullOrEmpty(ex.InnerException.TargetSite.ToString()) == true ? "非法数据！（异常方法）" : ex.InnerException.TargetSite.ToString();
                    errInfo.ErrTrace = string.IsNullOrEmpty(ex.InnerException.StackTrace) == true ? "非法数据！（表示形式）" : ex.InnerException.StackTrace;
                    errInfo.ErrSource = string.IsNullOrEmpty(ex.InnerException.Source) == true ? "非法数据！（数据源）" : ex.InnerException.Source;
                    errInfo.ErrIp = string.IsNullOrEmpty(DawnRequest.GetIPAddress()) == true ? "非法数据！（IP地址）" : DawnRequest.GetIPAddress();
                    errInfo.ErrUid = DawnAuthlib.UserId;
                    errInfo.ErrUname = string.IsNullOrEmpty(DawnAuthlib.UserSurname) ? "未登录" : DawnAuthlib.UserSurname;
                }
                else
                {
                    errInfo.ErrTime = System.DateTime.Now;
                    errInfo.ErrAddress = string.IsNullOrEmpty(DawnRequest.GetUrl()) == true ? "非法数据！（页面信息）" : DawnRequest.GetUrl();
                    errInfo.ErrMessage = string.IsNullOrEmpty(ex.Message) == true ? "非法数据！（错误日志）" : ex.Message;
                    errInfo.ErrTarget = string.IsNullOrEmpty(ex.TargetSite.ToString()) == true ? "非法数据！（异常方法）" : ex.TargetSite.ToString();
                    errInfo.ErrTrace = string.IsNullOrEmpty(ex.StackTrace) == true ? "非法数据！（表示形式）" : ex.StackTrace;
                    errInfo.ErrSource = string.IsNullOrEmpty(ex.Source) == true ? "非法数据！（数据源）" : ex.Source;
                    errInfo.ErrIp = string.IsNullOrEmpty(DawnRequest.GetIPAddress()) == true ? "非法数据！（IP地址）" : DawnRequest.GetIPAddress();
                    errInfo.ErrUid = DawnAuthlib.UserId;
                    errInfo.ErrUname = string.IsNullOrEmpty(DawnAuthlib.UserSurname) ? "未登录" : DawnAuthlib.UserSurname;
                }
                int res = DawnWfmpErrorBLL.Insert(errInfo);
                return res;
            }
            catch
            {
                return -1;
            }
        }

        #endregion

    }
}