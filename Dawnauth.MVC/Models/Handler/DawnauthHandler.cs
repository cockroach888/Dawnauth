using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using DawnXZ.Dawnauth.BLL;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.DawnUtility;
using DawnXZ.WebUtility;
using Newtonsoft.Json;
using System.Text;

namespace DawnXZ.Dawnauth.Handler
{
    /// <summary>
    /// 管理员登录信息处理器
    /// </summary>
    public class DawnauthHandler
    {

        #region 成员属性

        /// <summary>
        /// 管理员名称
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

    }
}