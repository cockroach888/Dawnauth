using System;
using System.Configuration;
using DawnXZ.DawnUtility;

namespace DawnXZ.Dawnauth.Handler
{
    /// <summary>
    /// 通用的处理器
    /// </summary>
    internal class GeneralHandler
    {

        #region 成员字段

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
        /// <para>AppConfig：SiteUrl</para>
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
        /// <para>AppConfig：SiteName</para>
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
        /// <para>AppConfig：SiteLogin</para>
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
        /// <para>AppConfig：SiteLogined</para>
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
        /// 令牌键值
        /// <para>AppConfig：TokenKey</para>
        /// </summary>
        public static string TokenKey
        {
            get
            {
                return CryptoHelper.Decrypt(ConfigurationManager.AppSettings["TokenKey"]);
            }
        }

        #endregion

    }
}