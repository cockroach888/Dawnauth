using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections;
using System.Web.Security;
using DawnXZ.DawnUtility;
using DawnXZ.WebUtility;
using DawnXZ.VerifyUtility;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.Dawnauth.BLL;
using DawnXZ.Dawnauth.Handler;
using Newtonsoft.Json;

namespace DawnXZ.Dawnauth.MVC.Controllers
{
    /// <summary>
    /// 系统登录相关控制器
    /// </summary>
    [Authorize]
    public partial class AuthController : Controller
    {
        /// <summary>
        /// 系统登录
        /// </summary>
        /// <param name="returnUrl">需要定向或回退的URL路径</param>
        /// <returns>执行结果</returns>
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        /// <summary>
        /// 确认登录
        /// </summary>
        /// <param name="FormCollection">数据表单</param>
        /// <returns>执行结果</returns>
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Logined(FormCollection form)
        {
            Hashtable ht = new Hashtable();
            ht.Add("Msg", GeneralHandler.FBaseInfo);
            ht.Add("Url", GeneralHandler.SiteLoginUrl);
            ht.Add("IsCode", false);
            try
            {
                string txtUname = form["txtUname"] as string;
                string txtUpwd = form["txtUpwd"] as string;
                txtUpwd = CryptoHelper.MD5(txtUpwd, true);
                string txtCheckCode = form["txtCheckCode"] as string;
                txtCheckCode = txtCheckCode.ToLower();
                string strCheckCode = Session["CheckCode"] as string;
                strCheckCode = strCheckCode.ToLower();
                if (txtCheckCode.Length != 4 || !ValidHelper.EngIsEngAndNum(txtCheckCode) || txtCheckCode != strCheckCode)
                {
                    ht["Msg"] = "您输入的验证码不正确[4个字符]。";
                    ht["IsCode"] = true;
                }
                else if (txtUname.Length < 4 || txtUname.Length > 16 || !ValidHelper.EngIsRegisters(txtUname))
                {
                    ht["Msg"] = "您输入的用户名不正确[4-16个字符]。";
                }
                else if (ValidHelper.IsSqlFilter(txtUname))
                {
                    ht["Msg"] = "您输入的用户名不正确[4-16个字符]。IsSqlFilter";
                }
                else if (!DawnAuthUserBLL.ExistsOfName(txtUname))
                {
                    ht["Msg"] = "您输入的用户名不存在！";
                }
                else
                {
                    var userIList = DawnAuthUserBLL.ISelect(string.Format("[user_name]='{0}' and [user_pwd]='{1}'", txtUname, txtUpwd));
                    if (userIList.Count == 0)
                    {
                        ht["Msg"] = "您输入的用户名与密码不匹配！";
                    }
                    else if (userIList.Count > 1)
                    {
                        ht["Msg"] = "您的账号存在异常，请联系管理员！";
                    }
                    else
                    {
                        var userInfo = userIList.First();
                        if (userInfo.UserStatus == 0)
                        {
                            ht["Msg"] = "您的账号存已禁用，请联系管理员！";
                        }
                        else if (userInfo.UserGrade < 2)
                        {
                            ht["Msg"] = "对不起，您的管理级别不符合！";
                        }
                        else
                        {
                            userIList.Clear();
                            Session["LoginName"] = txtUname;
                            Session[txtUname] = CryptoHelper.Encrypt(JsonConvert.SerializeObject(userInfo), GeneralHandler.TokenKey);
                            var userAuth = DawnAuthUserBLL.GetUserAuthority(userInfo.UserId);
                            Session["LoginAuthority"] = CryptoHelper.Encrypt(JsonConvert.SerializeObject(userAuth), GeneralHandler.TokenKey);
                            var userStat = DawnAuthUserBLL.GetUserStatus(userInfo.UserId);
                            Session["LoginStatus"] = CryptoHelper.Encrypt(JsonConvert.SerializeObject(userStat), GeneralHandler.TokenKey);
                            var userExtent = DawnAuthUserExtentBLL.ISelect(string.Format("user_id='{0}'", userInfo.UserId));
                            Session["LoginExtent"] = CryptoHelper.Encrypt(JsonConvert.SerializeObject(userExtent), GeneralHandler.TokenKey);
                            FormsAuthentication.SetAuthCookie(CryptoHelper.Encrypt(txtUname, GeneralHandler.TokenKey), false);

                            #region 登录日志

                            DawnAuthUserLoginMDL dataInfo = new DawnAuthUserLoginMDL();
                            dataInfo.UserId = userInfo.UserId;
                            dataInfo.LogTime = DateTime.Now;
                            dataInfo.LogIp = RequestHelper.GetIPAddress();
                            dataInfo.LogMac = "Unknown";
                            dataInfo.LogComputer = "Unknown";
                            dataInfo.LogAttach = null;
                            dataInfo.LogCount = 1;
                            DawnAuthUserLoginBLL.Insert(dataInfo);

                            #endregion

                            ht["Msg"] = GeneralHandler.StateSuccess;
                            ht["Url"] = GeneralHandler.SiteLoginedUrl;
                            //var hidReturnUrl = form["hidReturnUrl"] as string;
                            //ht["Url"] = string.IsNullOrEmpty(hidReturnUrl) ? GeneralHandler.SiteLoginedUrl : hidReturnUrl;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //ht["Msg"] = GeneralHandler.StateRefresh;
                ht["Msg"] = "对不起！无法与数据库建立连接！请联系管理员！";
                GeneralHandler.InsertByError(ex);
            }
            return Json(ht);
        }
        /// <summary>
        /// 注销登录
        /// </summary>
        /// <returns>执行结果</returns>
        public ActionResult Logout()
        {
            DawnauthHandler.ClearLogin();
            CookieHelper.Add("logout", "unsafe", 1);
            return RedirectToAction("Login");
        }
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <returns>执行结果</returns>
        public ActionResult Exit()
        {
            DawnauthHandler.ClearLogin();
            CookieHelper.Add("logout", "safe", 1);
            return RedirectToAction("Login");
        }
    }
}