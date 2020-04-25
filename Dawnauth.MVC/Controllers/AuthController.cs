using System;
using System.Web.Mvc;
using DawnXZ.DawnUtility;
using DawnXZ.WebUtility;
using DawnXZ.Dawnauth.Handler;
using System.Text;

namespace DawnXZ.Dawnauth.MVC.Controllers
{
    /// <summary>
    /// 权限管理核心控制器
    /// </summary>
    [Authorize]
    public partial class AuthController : Controller
    {

        #region 模板样例

        /// <summary>
        /// 内容页通用模板
        /// </summary>
        /// <returns>执行结果</returns>
        [AllowAnonymous]
        public ActionResult TemplateBody()
        {
            return View();
        }
        /// <summary>
        /// 编辑页通用模板
        /// </summary>
        /// <returns>执行结果</returns>
        [AllowAnonymous]
        public ActionResult TemplateEditor()
        {
            return View();
        }
        /// <summary>
        /// 弹窗页通用模板
        /// </summary>
        /// <returns>执行结果</returns>
        [AllowAnonymous]
        public ActionResult TemplateDialog()
        {
            return View();
        }

        #endregion

        /// <summary>
        /// 验证码
        /// <para>Cookie：QTXgt7AC5q5aLlVLwpTw</para>
        /// </summary>
        /// <returns>执行结果</returns>
        [AllowAnonymous]
        public ActionResult CheckCode()
        {
			string checkCode = CheckCodeHelper.GetEngAndNum(4);
            Session["CheckCode"] = checkCode;
            CookieHelper.Add("QTXgt7AC5q5aLlVLwpTw", checkCode, 10);
            return File(CheckCodeHelper.CreateToByte(checkCode, false), @"image/jpeg");
        }
        /// <summary>
        /// 默认页面
        /// </summary>
        /// <returns>执行结果</returns>
        public ActionResult Desktop()
        {
            return View();
        }

        #region 访问受限

        /// <summary>
        /// 无权限访问信息提示页
        /// </summary>
        /// <returns>执行结果</returns>
        public ActionResult AuthBody()
        {
            ViewBag.ErrorTitle = GeneralHandler.FAccessTitle;
            ViewBag.ErrorMessage = GeneralHandler.FAccessMessage;
            return View("AccessBody");
        }
        /// <summary>
        /// 无权限访问信息提示页
        /// </summary>
        /// <returns>执行结果</returns>
        public ActionResult AuthDialog()
        {
            ViewBag.ErrorTitle = GeneralHandler.FAccessTitle;
            ViewBag.ErrorMessage = GeneralHandler.FAccessMessage;
            return View("AccessDialog");
        }
        /// <summary>
        /// 无权限访问信息提示页
        /// </summary>
        /// <returns>执行结果</returns>
        public string AuthContent()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"notification error\">");
            sb.Append("<div id=\"tab-content-tips\">");
            sb.AppendFormat("<div class=\"error-title\">{0}</div>", GeneralHandler.FAccessTitle);
            sb.AppendFormat("<div class=\"error-message\">{0}</div>", GeneralHandler.FAccessMessage);
            sb.Append("</div>");
            sb.Append("</div>");
            return sb.ToString();
        }

        #endregion

        #region 访问异常

        /// <summary>
        /// 访问异常提示消息
        /// </summary>
        private string GetErrorMsg
        {
            get
            {
                var result = Session["ErrorMessage"] as string;
                if (string.IsNullOrEmpty(result)) result = "发现未知访问异常，请重试或联系管理员！";
                return result;
            }
            set
            {
                Session.Remove("ErrorMessage");
            }
        }
        /// <summary>
        /// 访问出现异常信息提示页
        /// </summary>
        /// <returns>执行结果</returns>
        public ActionResult ErrorBody()
        {
            ViewBag.ErrorTitle = "访问异常";
            ViewBag.ErrorMessage = GetErrorMsg;
            GetErrorMsg = null;
            return View("AccessBody");
        }
        /// <summary>
        /// 访问出现异常信息提示页
        /// </summary>
        /// <returns>执行结果</returns>
        public ActionResult ErrorDialog()
        {
            ViewBag.ErrorTitle = "访问异常";
            ViewBag.ErrorMessage = GetErrorMsg;
            GetErrorMsg = null;
            return View("AccessDialog");
        }
        /// <summary>
        /// 访问出现异常信息提示页
        /// </summary>
        /// <returns>执行结果</returns>
        public string ErrorContent()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"notification error\">");
            sb.Append("<div id=\"tab-content-tips\">");
            sb.AppendFormat("<div class=\"error-title\">访问异常</div>");
            sb.AppendFormat("<div class=\"error-message\">{0}</div>", GetErrorMsg);
            sb.Append("</div>");
            sb.Append("</div>");
            GetErrorMsg = null;
            return sb.ToString();
        }

        #endregion

    }
}