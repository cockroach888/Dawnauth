using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using DawnXZ.DawnUtility;
using DawnXZ.VerifyUtility;
using DawnXZ.WebUtility;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.Dawnauth.BLL;
using System.Web.Mvc;

namespace DawnXZ.Dawnauth.Handler
{
    /// <summary>
    /// 通用的处理器
    /// </summary>
    public class GeneralHandler
    {

        #region 成员字段属性

        /// <summary>
        /// 基本提示信息正文
        /// </summary>
        public static string FBaseInfo
        {
            get
            {
                return "请确认您正在进行的操作是否正确！请重试或联系管理员！";
            }
        }
        /// <summary>
        /// 无记录提示信息正文
        /// </summary>
        public static string FNoneInfo
        {
            get
            {
                return "<div class=\"field-item\"><label>暂无记录。</label></div>";
            }
        }
        /// <summary>
        /// 权限验证提示标题
        /// </summary>
        public static string FAccessTitle
        {
            get
            {
                return "访问受限";
            }
        }
        /// <summary>
        /// 权限验证提示正文
        /// </summary>
        public static string FAccessMessage
        {
            get
            {
                return "您的权限验证失败，请确认是否具有相应操作权限。";
            }
        }

        #endregion

        #region 成员属性

        /// <summary>
        /// 默认无触发链接URL
        /// </summary>
        public static string DefaultUrl
        {
            get
            {
                return "javascript:void(0);";
            }
        }
        /// <summary>
        /// 站点URL
        /// </summary>
        public static string SiteUrl
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["SiteUrl"] as string;
                return string.IsNullOrEmpty(tmpVal) ? DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 站点名称
        /// </summary>
        public static string SiteName
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["SiteName"] as string;
                return string.IsNullOrEmpty(tmpVal) ? "晨曦小竹" : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 站点登录URL
        /// </summary>
        public static string SiteLoginUrl
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["SiteLogin"] as string;
                return string.IsNullOrEmpty(tmpVal) ? DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 站点登录完成URL
        /// </summary>
        public static string SiteLoginedUrl
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["SiteLogined"] as string;
                return string.IsNullOrEmpty(tmpVal) ? DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 分页大小
        /// </summary>
        public static int PageSize
        {
            get
            {
                return TypeHelper.TypeToInt32(ConfigurationManager.AppSettings["PageSize"], 100);
            }
        }
        /// <summary>
        /// 令牌键值
        /// </summary>
        public static string TokenKey
        {
            get
            {
                return CryptoHelper.Decrypt(ConfigurationManager.AppSettings["TokenKey"]);
            }
        }

        #endregion

        #region 成员状态消息属性

        /// <summary>
        /// 已存在
        /// </summary>
        public static string StateAdded { get { return "added"; } }
        /// <summary>
        /// 成功
        /// </summary>
        public static string StateSuccess { get { return "success"; } }
        /// <summary>
        /// 失败
        /// </summary>
        public static string StateFailing { get { return "failing"; } }
        /// <summary>
        /// 页面需要刷新
        /// </summary>
        public static string StateRefresh { get { return "refresh"; } }

        #endregion

        #region 记录错误信息

        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="ex">错误数据对象</param>
        /// <returns></returns>
        public static int InsertByError(Exception ex)
        {
            try
            {
                if ((ex is System.Threading.ThreadAbortException)) return -1;
                DawnAuthErrorMDL errInfo = new DawnAuthErrorMDL();
                if (ex.InnerException != null)
                {
                    errInfo.ErrTime = System.DateTime.Now;
                    errInfo.ErrAddress = string.IsNullOrEmpty(RequestHelper.GetUrl()) == true ? "非法数据！（页面信息）" : RequestHelper.GetUrl();
                    errInfo.ErrMessage = string.IsNullOrEmpty(ex.InnerException.Message) == true ? "非法数据！（错误信息）" : ex.InnerException.Message;
                    errInfo.ErrTarget = string.IsNullOrEmpty(ex.InnerException.TargetSite.ToString()) == true ? "非法数据！（异常方法）" : ex.InnerException.TargetSite.ToString();
                    errInfo.ErrTrace = string.IsNullOrEmpty(ex.InnerException.StackTrace) == true ? "非法数据！（表示形式）" : ex.InnerException.StackTrace;
                    errInfo.ErrSource = string.IsNullOrEmpty(ex.InnerException.Source) == true ? "非法数据！（数据源）" : ex.InnerException.Source;
                    errInfo.ErrIp = string.IsNullOrEmpty(RequestHelper.GetIPAddress()) == true ? "非法数据！（IP地址）" : RequestHelper.GetIPAddress();
                    errInfo.ErrUid = DawnauthHandler.UserId;
                    errInfo.ErrUname = string.IsNullOrEmpty(DawnauthHandler.UserSurname) ? "未登录" : DawnauthHandler.UserSurname;
                }
                else
                {
                    errInfo.ErrTime = System.DateTime.Now;
                    errInfo.ErrAddress = string.IsNullOrEmpty(RequestHelper.GetUrl()) == true ? "非法数据！（页面信息）" : RequestHelper.GetUrl();
                    errInfo.ErrMessage = string.IsNullOrEmpty(ex.Message) == true ? "非法数据！（错误信息）" : ex.Message;
                    errInfo.ErrTarget = string.IsNullOrEmpty(ex.TargetSite.ToString()) == true ? "非法数据！（异常方法）" : ex.TargetSite.ToString();
                    errInfo.ErrTrace = string.IsNullOrEmpty(ex.StackTrace) == true ? "非法数据！（表示形式）" : ex.StackTrace;
                    errInfo.ErrSource = string.IsNullOrEmpty(ex.Source) == true ? "非法数据！（数据源）" : ex.Source;
                    errInfo.ErrIp = string.IsNullOrEmpty(RequestHelper.GetIPAddress()) == true ? "非法数据！（IP地址）" : RequestHelper.GetIPAddress();
                    errInfo.ErrUid = DawnauthHandler.UserId;
                    errInfo.ErrUname = string.IsNullOrEmpty(DawnauthHandler.UserSurname) ? "未登录" : DawnauthHandler.UserSurname;
                }
                int res = DawnAuthErrorBLL.Insert(errInfo);
                return res;
            }
            catch
            {
                return -1;
            }
        }

        #endregion

        #region 成员方法
        
        /// <summary>
        /// 判断访问请求是否安全
        /// </summary>
        /// <param name="lastPageName">来路</param>
        /// <param name="context">Http 请求</param>
        /// <returns>true / false</returns>
        public static bool IsRequestSafe(string lastPageName, HttpContext context)
        {
            try
            {
                if (!RequestHelper.IsBrowserGet()) return false;
                if (!RequestHelper.RequestIsPost()) return false;
                if (!string.IsNullOrEmpty(lastPageName)) if (RequestHelper.GetUrlByFilename(RequestHelper.GetUrlOfReferrer()).ToLower() != lastPageName) return false;
                if (RequestHelper.GetUrl().Substring(0, GeneralHandler.SiteUrl.Length) != GeneralHandler.SiteUrl) return false;
                if (!ValidateParamIsSafeOfRequest(context)) return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 判断请求中的成员参数是否安全
        /// </summary>
        /// <param name="context">Http 请求</param>
        /// <returns>验证结果</returns>
        private static bool ValidateParamIsSafeOfRequest(HttpContext context)
        {
            string getkeys = string.Empty;
            // QueryString 参数
            if (context.Request.QueryString != null)
            {
                for (int i = 0; i < context.Request.QueryString.Count; i++)
                {
                    getkeys = context.Request.QueryString.Keys[i];
                    if (ValidHelper.IsSqlFilter(context.Request.QueryString[getkeys].ToLower())) return false;
                }
            }
            // Form 参数
            if (context.Request.Form != null)
            {
                for (int i = 0; i < context.Request.Form.Count; i++)
                {
                    getkeys = context.Request.Form.Keys[i];
                    if (ValidHelper.IsSqlFilter(context.Request.Form[getkeys].ToLower())) return false;
                }
            }
            // Cookies 参数
            if (context.Request.Cookies != null)
            {
                for (int i = 0; i < context.Request.Cookies.Count; i++)
                {
                    getkeys = context.Request.Cookies.Keys[i];
                    if (ValidHelper.IsSqlFilter(context.Request.Cookies[getkeys].Value.ToLower())) return false;
                }
            }
            return true;
        }

        #endregion

    }
}