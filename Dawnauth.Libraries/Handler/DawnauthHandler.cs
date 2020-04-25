using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Collections;
using Newtonsoft.Json;
using DawnXZ.Dawnauth.BLL;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.DawnUtility;
using System.Collections.Generic;
using System.Text;
using DawnXZ.WebUtility;
using DawnXZ.VerifyUtility;

namespace DawnXZ.Dawnauth.Handler
{
    /// <summary>
    /// 管理员登录信息处理器
    /// </summary>
    internal class DawnauthHandler
    {

        #region 成员属性

        /// <summary>
        /// 管理员名称
        /// <para>Session：LoginName</para>
        /// </summary>
        public static string UserName
        {
            get
            {
                var loginName = HttpContext.Current.Session["LoginName"] as string;
                if (string.IsNullOrEmpty(loginName)) return null;
                return loginName;
            }
        }
        /// <summary>
        /// 管理员编号
        /// </summary>
        public static int UserId
        {
            get
            {
                if (UserInfo == null) return -1;
                return UserInfo.UserId;
            }
        }
        /// <summary>
        /// 管理员姓名
        /// </summary>
        public static string UserSurname
        {
            get
            {
                if (UserInfo == null) return null;
                return UserInfo.UserSurname;
            }
        }
        /// <summary>
        /// 管理员信息
        /// <para>Session：UserName</para>
        /// </summary>
        public static DawnAuthUserMDL UserInfo
        {
            get
            {
                var dataInfo = HttpContext.Current.Session[UserName] as string;
                dataInfo = CryptoHelper.Decrypt(dataInfo, GeneralHandler.TokenKey);
                if (string.IsNullOrEmpty(dataInfo)) return null;
                return JsonConvert.DeserializeObject(dataInfo, typeof(DawnAuthUserMDL)) as DawnAuthUserMDL;
            }
        }
        /// <summary>
        /// 管理员权限字符串
        /// <para>Session：LoginAuthority</para>
        /// </summary>
        public static string UserAuthority
        {
            get
            {
                var userAuth = HttpContext.Current.Session["LoginAuthority"] as string;
                userAuth = CryptoHelper.Decrypt(userAuth, GeneralHandler.TokenKey);
                if (string.IsNullOrEmpty(userAuth)) return null;
                return JsonConvert.DeserializeObject(userAuth, typeof(string)) as string;
            }
        }
        /// <summary>
        /// 管理员状态机制字符串
        /// <para>Session：LoginStatus</para>
        /// </summary>
        public static string UserStatus
        {
            get
            {
                var userStat = HttpContext.Current.Session["LoginStatus"] as string;
                userStat = CryptoHelper.Decrypt(userStat, GeneralHandler.TokenKey);
                if (string.IsNullOrEmpty(userStat)) return null;
                return JsonConvert.DeserializeObject(userStat, typeof(string)) as string;
            }
        }
        /// <summary>
        /// 管理员权限扩展编码集合
        /// <para>Session：LoginStatus</para>
        /// </summary>
        public static IList<DawnAuthUserExtentMDL> UserExtent
        {
            get
            {
                var userExtent = HttpContext.Current.Session["LoginExtent"] as string;
                userExtent = CryptoHelper.Decrypt(userExtent, GeneralHandler.TokenKey);
                if (string.IsNullOrEmpty(userExtent)) return null;
                return JsonConvert.DeserializeObject(userExtent, typeof(IList<DawnAuthUserExtentMDL>)) as IList<DawnAuthUserExtentMDL>;
            }
        }

        #endregion

        #region 成员方法

        /// <summary>
        /// 清除登录相关信息
        /// </summary>
        public static void ClearLogin()
        {
            HttpContext.Current.Session[UserName] = null;
            HttpContext.Current.Session["LoginName"] = null;
            HttpContext.Current.Session["LoginAuthority"] = null;
            HttpContext.Current.Session["LoginStatus"] = null;
            CacheHelper.Remove();
            HttpContext.Current.Request.Cookies.Clear();
            HttpContext.Current.Response.Cookies.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();
            HttpContext.Current.ClearError();
            System.Web.Security.FormsAuthentication.SignOut();
        }

        #region 功能权限验证

        /// <summary>
        /// 验证用户是否具有指定功能的权限
        /// </summary>
        /// <param name="moduleCode">模块编码</param>
        /// <param name="functionMark">功能标识</param>
        /// <returns>执行结果</returns>
        public static bool VerifyModule(string moduleCode, int functionMark)
        {
            if (string.IsNullOrEmpty(UserAuthority) || UserAuthority.Length == 1) return false;
            bool result = false;
            int mi = UserAuthority.IndexOf(";" + moduleCode + "|");
            if (mi >= 0)
            {
                int ml = UserAuthority.IndexOf(";", mi + 1);
                if (ml < 0)
                {
                    ml = UserAuthority.Length;
                }
                string authString = UserAuthority.Substring(mi + moduleCode.Length + 2, ml - mi - moduleCode.Length - 2);
                if (authString.Length >= functionMark)
                {
                    if (authString.Substring(functionMark - 1, 1) == "1")
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 验证用户是否具有指定状态机制的操作权限
        /// </summary>
        /// <param name="moduleCode">模块编码</param>
        /// <param name="status">数据状态</param>
        /// <returns>执行结果</returns>
        public static bool VerifyStatus(string moduleCode, int status)
        {
            if (string.IsNullOrEmpty(UserStatus) || UserStatus.Length == 1) return false;
            bool result = false;
            int mi = UserStatus.IndexOf(";" + moduleCode + "|");
            if (mi >= 0)
            {
                int ml = UserStatus.IndexOf(";", mi + 1);
                if (ml < 0)
                {
                    ml = UserStatus.Length;
                }
                string authString = UserStatus.Substring(mi + moduleCode.Length + 2, ml - mi - moduleCode.Length - 2);
                var ckStat = string.Format(",{0},", status);
                result = authString.Contains(ckStat);
            }
            return result;
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
            if (UserId < 1 || identModule < 1 || identFunction < 1) return false;
            string cmdSql = string.Format("user_id='{0}' and map_module='{1}' and charindex(',{2},',map_function)>0", UserId, identModule, identFunction);
            return DawnAuthUserPowerBLL.Exists(cmdSql);
        }
        /// <summary>
        /// 验证用户是否具有指定的权限扩展标识权限
        /// </summary>
        /// <param name="exteCode">权限扩展编码</param>
        /// <param name="exteMark">权限扩展标识</param>
        /// <returns>执行结果</returns>
        public static bool VerifyExtent(string exteCode, string exteMark)
        {
            var result = false;
            if (UserExtent.Count(p => p.ExtCode == "" && p.ExtMark == "") == 1) result = true;
            return result;
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
            if (UserExtent == null || UserExtent.Count < 1) return null;
            StringBuilder sb = new StringBuilder();
            var exteList = UserExtent.Where(p => p.ExtCode == exteCode);
            int index = exteList.Count();
            foreach (DawnAuthUserExtentMDL item in exteList)
            {
                index--;
                if (dataType == 2)
                {
                    sb.Append(item.ExtMark);
                }
                else
                {
                    sb.AppendFormat("'{0}'", item.ExtMark);
                }
                if (index > 0) sb.Append(",");
            }
            return sb.ToString();
        }

        #endregion

        #region 登录验证及密码修改

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
            outEx = null;
            Hashtable ht = new Hashtable();
            ht.Add("Msg", GeneralHandler.FBaseInfo);
            ht.Add("Url", GeneralHandler.SiteLoginUrl);
            ht.Add("IsCode", false);
            try
            {
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userPwd) || string.IsNullOrEmpty(checkCode)) return ht;
                userPwd = CryptoHelper.MD5(userPwd, true);
                checkCode = checkCode.ToLower();
                string verifyCode = HttpContext.Current.Session["CheckCode"] as string;
                verifyCode = verifyCode.ToLower();
                if (checkCode.Length != 4 || !ValidHelper.EngIsEngAndNum(checkCode) || checkCode != verifyCode)
                {
                    ht["Msg"] = "您输入的验证码不正确[4个字符]。";
                    ht["IsCode"] = true;
                }
                else if (userName.Length < 4 || userName.Length > 16 || !ValidHelper.EngIsRegisters(userName))
                {
                    ht["Msg"] = "您输入的用户名不正确[4-16个字符]。";
                }
                else if (ValidHelper.IsSqlFilter(userName))
                {
                    ht["Msg"] = "您输入的用户名不正确[4-16个字符]。IsSqlFilter";
                }
                else if (!DawnAuthUserBLL.ExistsOfName(userName))
                {
                    ht["Msg"] = "您输入的用户名不存在！";
                }
                else
                {
                    var userIList = DawnAuthUserBLL.ISelect(string.Format("[user_name]='{0}' and [user_pwd]='{1}'", userName, userPwd));
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
                        else if (userInfo.UserGrade < 1)
                        {
                            ht["Msg"] = "对不起，您的管理级别不符合！";
                        }
                        else
                        {
                            userIList.Clear();
                            HttpContext.Current.Session["LoginName"] = userName;
                            HttpContext.Current.Session[userName] = CryptoHelper.Encrypt(JsonConvert.SerializeObject(userInfo), GeneralHandler.TokenKey);
                            var userAuth = DawnAuthUserBLL.GetUserAuthority(userInfo.UserId);
                            HttpContext.Current.Session["LoginAuthority"] = CryptoHelper.Encrypt(JsonConvert.SerializeObject(userAuth), GeneralHandler.TokenKey);
                            var userStat = DawnAuthUserBLL.GetUserStatus(userInfo.UserId);
                            HttpContext.Current.Session["LoginStatus"] = CryptoHelper.Encrypt(JsonConvert.SerializeObject(userStat), GeneralHandler.TokenKey);
                            var userExtent = DawnAuthUserExtentBLL.ISelect(string.Format("user_id='{0}'", userInfo.UserId));
                            HttpContext.Current.Session["LoginExtent"] = CryptoHelper.Encrypt(JsonConvert.SerializeObject(userExtent), GeneralHandler.TokenKey);
                            FormsAuthentication.SetAuthCookie(CryptoHelper.Encrypt(userName, GeneralHandler.TokenKey), false);

                            #region 登录日志

                            DawnAuthUserLoginMDL dataInfo = new DawnAuthUserLoginMDL();
                            dataInfo.UserId = userInfo.UserId;
                            dataInfo.LogTime = DateTime.Now;
                            dataInfo.LogIp = RequestHelper.GetIPAddress();
							dataInfo.LogMac = DawnXZ.PHYUtility.ManagementHelper.Instance().MacAddress.ToUpper();
                            dataInfo.LogComputer = "Unknown";
                            dataInfo.LogAttach = null;
                            dataInfo.LogCount = 1;
                            DawnAuthUserLoginBLL.Insert(dataInfo);

                            #endregion

                            ht["Msg"] = GeneralHandler.StateSuccess;
                            ht["Url"] = string.IsNullOrEmpty(returnUrl) ? GeneralHandler.SiteLoginedUrl : returnUrl;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                outEx = ex;
                ht["Msg"] = GeneralHandler.StateRefresh;
            }
            return ht;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="userPwd">用户密码</param>
        public static void ChangePassword(int userId, string userPwd)
        {
            if (userId < 1 || string.IsNullOrEmpty(userPwd)) return;
            if (userPwd.Length != 32) userPwd = CryptoHelper.MD5(userPwd, true);
            DawnAuthUserBLL.Update(userId, userPwd);
        }

        #endregion

        #endregion

    }
}