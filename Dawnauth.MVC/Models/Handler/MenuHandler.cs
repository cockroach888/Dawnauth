using System;
using System.Web;
using System.Text;
using System.Configuration;
using DawnXZ.DawnUtility;

namespace DawnXZ.Dawnauth.Handler
{
    /// <summary>
    /// 菜单显示处理器
    /// </summary>
    public class MenuHandler
    {

        #region 获取菜单项列表信息

        /// <summary>
        /// 获取菜单项列表信息
        /// </summary>
        /// <param name="mIndex">当前父菜单索引</param>
        /// <param name="cIndex">当前子菜单索引</param>
        /// <returns>执行结果</returns>
        public static string GetMenuItems(int mIndex, int cIndex)
        {
            string result = null;
            switch (mIndex)
            {
                case 1:
                    result = GetMenuItemsByInfo(cIndex);
                    break;
                case 2:
                    result = GetMenuItemsByUser(cIndex);
                    break;
                case 3:
                    result = GetMenuItemsByStatus(cIndex);
                    break;
                case 4:
                    result = GetMenuItemsByRole(cIndex);
                    break;
                case 5:
                    result = GetMenuItemsByFunction(cIndex);
                    break;
                case 6:
                    result = GetMenuItemsByModule(cIndex);
                    break;
                case 7:
                    result = GetMenuItemsByDepart(cIndex);
                    break;
                case 8:
                    result = GetMenuItemsByExtent(cIndex);
                    break;
                default:
                    result = GetMenuItemsByNone();
                    break;
            }
            return result;
        }

        #region 成员属性

        /// <summary>
        /// 系统信息管理
        /// <para>探针详细信息</para>
        /// </summary>
        public static string UrlDesktop
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlDesktop"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 系统信息管理
        /// <para>登录信息管理</para>
        /// </summary>
        public static string UrlUserLoginList
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlUserLoginList"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 系统信息管理
        /// <para>错误信息管理</para>
        /// </summary>
        public static string UrlErrorList
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlErrorList"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 系统信息管理
        /// <para>系统日志管理</para>
        /// </summary>
        public static string UrlLogsList
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlLogsList"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 管理员信息管理
        /// <para>数据列表</para>
        /// </summary>
        public static string UrlUserList
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlUserList"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 管理员信息管理
        /// <para>添加新用户</para>
        /// </summary>
        public static string UrlUserAdd
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlUserAdd"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 状态机制管理
        /// <para>数据列表</para>
        /// </summary>
        public static string UrlStatusList
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlStatusList"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 状态机制管理
        /// <para>添加新状态</para>
        /// </summary>
        public static string UrlStatusAdd
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlStatusAdd"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 管理员角色管理
        /// <para>数据列表</para>
        /// </summary>
        public static string UrlRoleList
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlRoleList"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 管理员角色管理
        /// <para>添加新角色</para>
        /// </summary>
        public static string UrlRoleAdd
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlRoleAdd"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 模块功能管理
        /// <para>数据列表</para>
        /// </summary>
        public static string UrlFunctionList
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlFunctionList"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 模块功能管理
        /// <para>添加新功能</para>
        /// </summary>
        public static string UrlFunctionAdd
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlFunctionAdd"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 模块信息管理
        /// <para>数据列表</para>
        /// </summary>
        public static string UrlModuleList
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlModuleList"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 模块信息管理
        /// <para>添加新模块</para>
        /// </summary>
        public static string UrlModuleAdd
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlModuleAdd"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 单位部门管理
        /// <para>数据列表</para>
        /// </summary>
        public static string UrlDepartList
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlDepartList"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 单位部门管理
        /// <para>添加新部门</para>
        /// </summary>
        public static string UrlDepartAdd
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlDepartAdd"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 权限扩展管理
        /// <para>数据列表</para>
        /// </summary>
        public static string UrlExtentList
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlExtentList"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 权限扩展管理
        /// <para>添加新扩展</para>
        /// </summary>
        public static string UrlExtentAdd
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlExtentAdd"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }
        /// <summary>
        /// 权限扩展管理
        /// <para>同步扩展数据</para>
        /// </summary>
        public static string UrlExtentSync
        {
            get
            {
                string tmpVal = ConfigurationManager.AppSettings["UrlExtentSync"] as string;
                return string.IsNullOrEmpty(tmpVal) ? GeneralHandler.DefaultUrl : CryptoHelper.Decrypt(tmpVal, GeneralHandler.TokenKey);
            }
        }

        #endregion
        
        #region 无默认菜单项

        /// <summary>
        /// 无默认菜单项
        /// </summary>
        /// <returns>执行结果</returns>
        private static string GetMenuItemsByNone()
        {
            StringBuilder sb = new StringBuilder();
            GetMenuItemsOfDawnDef(ref sb);
            GetMenuItemsByInfoOfNone(ref sb);
            GetMenuItemsByUserOfNone(ref sb);
            GetMenuItemsByStatusOfNone(ref sb);
            GetMenuItemsByRoleOfNone(ref sb);
            GetMenuItemsByFunctionOfNone(ref sb);
            GetMenuItemsByModuleOfNone(ref sb);
            GetMenuItemsByDepartOfNone(ref sb);
            GetMenuItemsByExtentOfNone(ref sb);
            return sb.ToString();
        }

        #endregion

        #region 晨曦小竹

        /// <summary>
        /// 晨曦小竹
        /// </summary>
        /// <param name="sb">数据标签</param>
        private static void GetMenuItemsOfDawn(ref StringBuilder sb)
        {
            sb.Append("<li>");
            sb.Append("<a href=\"http://www.dawnxz.com/\" target=\"_blank\" class=\"nav-top-item no-submenu\">晨曦小竹</a>");
            sb.Append("</li>");
        }
        /// <summary>
        /// 晨曦小竹
        /// </summary>
        /// <param name="sb">数据标签</param>
        private static void GetMenuItemsOfDawnDef(ref StringBuilder sb)
        {
            sb.Append("<li>");
            sb.Append("<a href=\"http://www.dawnxz.com/\" target=\"_blank\" class=\"nav-top-item no-submenu current\">晨曦小竹</a>");
            sb.Append("</li>");
        }

        #endregion

        #region 系统信息管理

        /// <summary>
        /// 系统信息管理
        /// </summary>
        /// <param name="cIndex">当前子菜单索引</param>
        /// <returns>执行结果</returns>
        private static string GetMenuItemsByInfo(int cIndex)
        {
            StringBuilder sb = new StringBuilder();
            GetMenuItemsOfDawn(ref sb);
            //系统信息管理
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"{0}\" class=\"nav-top-item current\">系统信息管理</a>", GeneralHandler.DefaultUrl);
            sb.Append("<ul>");
            if (cIndex == 1)
            {
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">探针详细信息</a></li>", UrlDesktop);
                sb.AppendFormat("<li><a href=\"{0}\">登录信息管理</a></li>", UrlUserLoginList);
                sb.AppendFormat("<li><a href=\"{0}\">错误信息管理</a></li>", UrlErrorList);
                sb.AppendFormat("<li><a href=\"{0}\">系统日志管理</a></li>", UrlLogsList);
            }
            else if (cIndex == 2)
            {
                sb.AppendFormat("<li><a href=\"{0}\">探针详细信息</a></li>", UrlDesktop);
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">登录信息管理</a></li>", UrlUserLoginList);
                sb.AppendFormat("<li><a href=\"{0}\">错误信息管理</a></li>", UrlErrorList);
                sb.AppendFormat("<li><a href=\"{0}\">系统日志管理</a></li>", UrlLogsList);
            }
            else if (cIndex == 3)
            {
                sb.AppendFormat("<li><a href=\"{0}\">探针详细信息</a></li>", UrlDesktop);
                sb.AppendFormat("<li><a href=\"{0}\">登录信息管理</a></li>", UrlUserLoginList);
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">错误信息管理</a></li>", UrlErrorList);
                sb.AppendFormat("<li><a href=\"{0}\">系统日志管理</a></li>", UrlLogsList);
            }
            else if (cIndex == 4)
            {
                sb.AppendFormat("<li><a href=\"{0}\">探针详细信息</a></li>", UrlDesktop);
                sb.AppendFormat("<li><a href=\"{0}\">登录信息管理</a></li>", UrlUserLoginList);
                sb.AppendFormat("<li><a href=\"{0}\">错误信息管理</a></li>", UrlErrorList);
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">系统日志管理</a></li>", UrlLogsList);
            }
            else
            {
                sb.AppendFormat("<li><a href=\"{0}\">探针详细信息</a></li>", UrlDesktop);
                sb.AppendFormat("<li><a href=\"{0}\">登录信息管理</a></li>", UrlUserLoginList);
                sb.AppendFormat("<li><a href=\"{0}\">错误信息管理</a></li>", UrlErrorList);
                sb.AppendFormat("<li><a href=\"{0}\">系统日志管理</a></li>", UrlLogsList);
            }
            sb.Append("</ul>");
            sb.Append("</li>");
            GetMenuItemsByUserOfNone(ref sb);
            GetMenuItemsByStatusOfNone(ref sb);
            GetMenuItemsByRoleOfNone(ref sb);
            GetMenuItemsByFunctionOfNone(ref sb);
            GetMenuItemsByModuleOfNone(ref sb);
            GetMenuItemsByDepartOfNone(ref sb);
            GetMenuItemsByExtentOfNone(ref sb);
            return sb.ToString();
        }
        /// <summary>
        /// 系统信息管理
        /// </summary>
        /// <param name="sb">数据标签</param>
        private static void GetMenuItemsByInfoOfNone(ref StringBuilder sb)
        {
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"{0}\" class=\"nav-top-item\">系统信息管理</a>", GeneralHandler.DefaultUrl);
            sb.Append("<ul>");
            sb.AppendFormat("<li><a href=\"{0}\">探针详细信息</a></li>", UrlDesktop);
            sb.AppendFormat("<li><a href=\"{0}\">登录信息管理</a></li>", UrlUserLoginList);
            sb.AppendFormat("<li><a href=\"{0}\">错误信息管理</a></li>", UrlErrorList);
            sb.AppendFormat("<li><a href=\"{0}\">系统日志管理</a></li>", UrlLogsList);
            sb.Append("</ul>");
            sb.Append("</li>");
        }

        #endregion
        
        #region 管理员信息管理

        /// <summary>
        /// 管理员信息管理
        /// </summary>
        /// <param name="cIndex">当前子菜单索引</param>
        /// <returns>执行结果</returns>
        private static string GetMenuItemsByUser(int cIndex)
        {
            StringBuilder sb = new StringBuilder();
            GetMenuItemsOfDawn(ref sb);
            GetMenuItemsByInfoOfNone(ref sb);
            //管理员信息管理
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"{0}\" class=\"nav-top-item current\">管理员信息管理</a>", GeneralHandler.DefaultUrl);
            sb.Append("<ul>");
            if (cIndex == 1)
            {
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">数据列表</a></li>", UrlUserList);
                sb.AppendFormat("<li><a href=\"{0}\">添加新管理员</a></li>", UrlUserAdd);
            }
            else if (cIndex == 2)
            {
                sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlUserList);
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">添加新管理员</a></li>", UrlUserAdd);
            }
            else
            {
                sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlUserList);
                sb.AppendFormat("<li><a href=\"{0}\">添加新管理员</a></li>", UrlUserAdd);
            }
            sb.Append("</ul>");
            sb.Append("</li>");
            GetMenuItemsByStatusOfNone(ref sb);
            GetMenuItemsByRoleOfNone(ref sb);
            GetMenuItemsByFunctionOfNone(ref sb);
            GetMenuItemsByModuleOfNone(ref sb);
            GetMenuItemsByDepartOfNone(ref sb);
            GetMenuItemsByExtentOfNone(ref sb);
            return sb.ToString();
        }
        /// <summary>
        /// 管理员信息管理
        /// </summary>
        /// <param name="sb">数据标签</param>
        private static void GetMenuItemsByUserOfNone(ref StringBuilder sb)
        {
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"{0}\" class=\"nav-top-item\">管理员信息管理</a>", GeneralHandler.DefaultUrl);
            sb.Append("<ul>");
            sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlUserList);
            sb.AppendFormat("<li><a href=\"{0}\">添加新管理员</a></li>", UrlUserAdd);
            sb.Append("</ul>");
            sb.Append("</li>");
        }

        #endregion

        #region 状态机制管理

        /// <summary>
        /// 状态机制管理
        /// </summary>
        /// <param name="cIndex">当前子菜单索引</param>
        /// <returns>执行结果</returns>
        private static string GetMenuItemsByStatus(int cIndex)
        {
            StringBuilder sb = new StringBuilder();
            GetMenuItemsOfDawn(ref sb);
            GetMenuItemsByInfoOfNone(ref sb);
            GetMenuItemsByUserOfNone(ref sb);
            //状态机制管理
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"{0}\" class=\"nav-top-item current\">状态机制管理</a>", GeneralHandler.DefaultUrl);
            sb.Append("<ul>");
            if (cIndex == 1)
            {
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">数据列表</a></li>", UrlStatusList);
                //sb.AppendFormat("<li><a href=\"{0}\" title=\"请确认在当前数据列表下操作！\">添加新机制</a></li>", UrlStatusAdd);
            }
            //else if (cIndex == 2)
            //{
            //    sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlStatusList);
            //    sb.AppendFormat("<li><a class=\"current\" href=\"{0}\" title=\"请确认在当前数据列表下操作！\">添加新机制</a></li>", UrlStatusAdd);
            //}
            else
            {
                sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlStatusList);
                //sb.AppendFormat("<li><a href=\"{0}\" title=\"请确认在当前数据列表下操作！\">添加新机制</a></li>", UrlStatusAdd);
            }
            sb.Append("</ul>");
            sb.Append("</li>");
            GetMenuItemsByRoleOfNone(ref sb);
            GetMenuItemsByFunctionOfNone(ref sb);
            GetMenuItemsByModuleOfNone(ref sb);
            GetMenuItemsByDepartOfNone(ref sb);
            GetMenuItemsByExtentOfNone(ref sb);
            return sb.ToString();
        }
        /// <summary>
        /// 状态机制管理
        /// </summary>
        /// <param name="sb">数据标签</param>
        private static void GetMenuItemsByStatusOfNone(ref StringBuilder sb)
        {
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"{0}\" class=\"nav-top-item\">状态机制管理</a>", GeneralHandler.DefaultUrl);
            sb.Append("<ul>");
            sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlStatusList);
            //sb.AppendFormat("<li><a href=\"{0}\" title=\"请确认在当前数据列表下操作！\">添加新机制</a></li>", UrlStatusAdd);
            sb.Append("</ul>");
            sb.Append("</li>");
        }

        #endregion

        #region 管理员角色管理

        /// <summary>
        /// 管理员角色管理
        /// </summary>
        /// <param name="cIndex">当前子菜单索引</param>
        /// <returns>执行结果</returns>
        private static string GetMenuItemsByRole(int cIndex)
        {
            StringBuilder sb = new StringBuilder();
            GetMenuItemsOfDawn(ref sb);
            GetMenuItemsByInfoOfNone(ref sb);
            GetMenuItemsByUserOfNone(ref sb);
            GetMenuItemsByStatusOfNone(ref sb);
            //管理员角色管理
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"{0}\" class=\"nav-top-item current\">管理员角色管理</a>", GeneralHandler.DefaultUrl);
            sb.Append("<ul>");
            if (cIndex == 1)
            {
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">数据列表</a></li>", UrlRoleList);
                //sb.AppendFormat("<li><a href=\"{0}\" title=\"请确认在当前数据列表下操作！\">添加新角色</a></li>", UrlRoleAdd);
            }
            //else if (cIndex == 2)
            //{
            //    sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlRoleList);
            //    sb.AppendFormat("<li><a class=\"current\" href=\"{0}\" title=\"请确认在当前数据列表下操作！\">添加新角色</a></li>", UrlRoleAdd);
            //}
            else
            {
                sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlRoleList);
                //sb.AppendFormat("<li><a href=\"{0}\" title=\"请确认在当前数据列表下操作！\">添加新角色</a></li>", UrlRoleAdd);
            }
            sb.Append("</ul>");
            sb.Append("</li>");
            GetMenuItemsByFunctionOfNone(ref sb);
            GetMenuItemsByModuleOfNone(ref sb);
            GetMenuItemsByDepartOfNone(ref sb);
            GetMenuItemsByExtentOfNone(ref sb);
            return sb.ToString();
        }
        /// <summary>
        /// 管理员角色管理
        /// </summary>
        /// <param name="sb">数据标签</param>
        private static void GetMenuItemsByRoleOfNone(ref StringBuilder sb)
        {
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"{0}\" class=\"nav-top-item\">管理员角色管理</a>", GeneralHandler.DefaultUrl);
            sb.Append("<ul>");
            sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlRoleList);
            //sb.AppendFormat("<li><a href=\"{0}\" title=\"请确认在当前数据列表下操作！\">添加新角色</a></li>", UrlRoleAdd);
            sb.Append("</ul>");
            sb.Append("</li>");
        }

        #endregion

        #region 模块功能管理

        /// <summary>
        /// 模块功能管理
        /// </summary>
        /// <param name="cIndex">当前子菜单索引</param>
        /// <returns>执行结果</returns>
        private static string GetMenuItemsByFunction(int cIndex)
        {
            StringBuilder sb = new StringBuilder();
            GetMenuItemsOfDawn(ref sb);
            GetMenuItemsByInfoOfNone(ref sb);
            GetMenuItemsByUserOfNone(ref sb);
            GetMenuItemsByStatusOfNone(ref sb);
            GetMenuItemsByRoleOfNone(ref sb);
            //模块功能管理
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"{0}\" class=\"nav-top-item current\">模块功能管理</a>", GeneralHandler.DefaultUrl);
            sb.Append("<ul>");
            if (cIndex == 1)
            {
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">数据列表</a></li>", UrlFunctionList);
                sb.AppendFormat("<li><a href=\"{0}\">添加新功能</a></li>", UrlFunctionAdd);
            }
            else if (cIndex == 2)
            {
                sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlFunctionList);
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">添加新功能</a></li>", UrlFunctionAdd);
            }
            else
            {
                sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlFunctionList);
                sb.AppendFormat("<li><a href=\"{0}\">添加新功能</a></li>", UrlFunctionAdd);
            }
            sb.Append("</ul>");
            sb.Append("</li>");
            GetMenuItemsByModuleOfNone(ref sb);
            GetMenuItemsByDepartOfNone(ref sb);
            GetMenuItemsByExtentOfNone(ref sb);
            return sb.ToString();
        }
        /// <summary>
        /// 模块功能管理
        /// </summary>
        /// <param name="sb">数据标签</param>
        private static void GetMenuItemsByFunctionOfNone(ref StringBuilder sb)
        {
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"{0}\" class=\"nav-top-item\">模块功能管理</a>", GeneralHandler.DefaultUrl);
            sb.Append("<ul>");
            sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlFunctionList);
            sb.AppendFormat("<li><a href=\"{0}\">添加新功能</a></li>", UrlFunctionAdd);
            sb.Append("</ul>");
            sb.Append("</li>");
        }

        #endregion

        #region 模块信息管理

        /// <summary>
        /// 模块信息管理
        /// </summary>
        /// <param name="cIndex">当前子菜单索引</param>
        /// <returns>执行结果</returns>
        private static string GetMenuItemsByModule(int cIndex)
        {
            StringBuilder sb = new StringBuilder();
            GetMenuItemsOfDawn(ref sb);
            GetMenuItemsByInfoOfNone(ref sb);
            GetMenuItemsByUserOfNone(ref sb);
            GetMenuItemsByStatusOfNone(ref sb);
            GetMenuItemsByRoleOfNone(ref sb);
            GetMenuItemsByFunctionOfNone(ref sb);
            //模块信息管理
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"{0}\" class=\"nav-top-item current\">模块信息管理</a>", GeneralHandler.DefaultUrl);
            sb.Append("<ul>");
            if (cIndex == 1)
            {
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">数据列表</a></li>", UrlModuleList);
                sb.AppendFormat("<li><a href=\"{0}\">添加新模块</a></li>", UrlModuleAdd);
            }
            else if (cIndex == 2)
            {
                sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlModuleList);
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">添加新模块</a></li>", UrlModuleAdd);
            }
            else
            {
                sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlModuleList);
                sb.AppendFormat("<li><a href=\"{0}\">添加新模块</a></li>", UrlModuleAdd);
            }
            sb.Append("</ul>");
            sb.Append("</li>");
            GetMenuItemsByDepartOfNone(ref sb);
            GetMenuItemsByExtentOfNone(ref sb);
            return sb.ToString();
        }
        /// <summary>
        /// 模块信息管理
        /// </summary>
        /// <param name="sb">数据标签</param>
        private static void GetMenuItemsByModuleOfNone(ref StringBuilder sb)
        {
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"{0}\" class=\"nav-top-item\">模块信息管理</a>", GeneralHandler.DefaultUrl);
            sb.Append("<ul>");
            sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlModuleList);
            sb.AppendFormat("<li><a href=\"{0}\">添加新模块</a></li>", UrlModuleAdd);
            sb.Append("</ul>");
            sb.Append("</li>");
        }

        #endregion

        #region 单位部门管理

        /// <summary>
        /// 单位部门管理
        /// </summary>
        /// <param name="cIndex">当前子菜单索引</param>
        /// <returns>执行结果</returns>
        private static string GetMenuItemsByDepart(int cIndex)
        {
            StringBuilder sb = new StringBuilder();
            GetMenuItemsOfDawn(ref sb);
            GetMenuItemsByInfoOfNone(ref sb);
            GetMenuItemsByUserOfNone(ref sb);
            GetMenuItemsByStatusOfNone(ref sb);
            GetMenuItemsByRoleOfNone(ref sb);
            GetMenuItemsByFunctionOfNone(ref sb);
            GetMenuItemsByModuleOfNone(ref sb);
            //单位部门管理
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"{0}\" class=\"nav-top-item current\">单位部门管理</a>", GeneralHandler.DefaultUrl);
            sb.Append("<ul>");
            if (cIndex == 1)
            {
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">数据列表</a></li>", UrlDepartList);
                sb.AppendFormat("<li><a href=\"{0}\">添加新部门</a></li>", UrlDepartAdd);
            }
            else if (cIndex == 2)
            {
                sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlDepartList);
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">添加新部门</a></li>", UrlDepartAdd);
            }
            else
            {
                sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlDepartList);
                sb.AppendFormat("<li><a href=\"{0}\">添加新部门</a></li>", UrlDepartAdd);
            }
            sb.Append("</ul>");
            sb.Append("</li>");
            GetMenuItemsByExtentOfNone(ref sb);
            return sb.ToString();
        }
        /// <summary>
        /// 单位部门管理
        /// </summary>
        /// <param name="sb">数据标签</param>
        private static void GetMenuItemsByDepartOfNone(ref StringBuilder sb)
        {
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"{0}\" class=\"nav-top-item\">单位部门管理</a>", GeneralHandler.DefaultUrl);
            sb.Append("<ul>");
            sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlDepartList);
            sb.AppendFormat("<li><a href=\"{0}\">添加新部门</a></li>", UrlDepartAdd);
            sb.Append("</ul>");
            sb.Append("</li>");
        }

        #endregion

        #region 权限扩展管理

        /// <summary>
        /// 权限扩展管理
        /// </summary>
        /// <param name="cIndex">当前子菜单索引</param>
        /// <returns>执行结果</returns>
        private static string GetMenuItemsByExtent(int cIndex)
        {
            StringBuilder sb = new StringBuilder();
            GetMenuItemsOfDawn(ref sb);
            GetMenuItemsByInfoOfNone(ref sb);
            GetMenuItemsByUserOfNone(ref sb);
            GetMenuItemsByStatusOfNone(ref sb);
            GetMenuItemsByRoleOfNone(ref sb);
            GetMenuItemsByFunctionOfNone(ref sb);
            GetMenuItemsByModuleOfNone(ref sb);
            GetMenuItemsByDepartOfNone(ref sb);
            //权限扩展管理
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"{0}\" class=\"nav-top-item current\">权限扩展管理</a>", GeneralHandler.DefaultUrl);
            sb.Append("<ul>");
            if (cIndex == 1)
            {
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">数据列表</a></li>", UrlExtentList);
                sb.AppendFormat("<li><a href=\"{0}\">添加新扩展</a></li>", UrlExtentAdd);
                sb.AppendFormat("<li><a href=\"{0}\">同步扩展数据</a></li>", UrlExtentSync);

            }
            else if (cIndex == 2)
            {
                sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlExtentList);
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">添加新扩展</a></li>", UrlExtentAdd);
                sb.AppendFormat("<li><a href=\"{0}\">同步扩展数据</a></li>", UrlExtentSync);
            }
            else if (cIndex == 3)
            {
                sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlExtentList);
                sb.AppendFormat("<li><a href=\"{0}\">添加新扩展</a></li>", UrlExtentAdd);
                sb.AppendFormat("<li><a class=\"current\" href=\"{0}\">同步扩展数据</a></li>", UrlExtentSync);
            }
            else
            {
                sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlExtentList);
                sb.AppendFormat("<li><a href=\"{0}\">添加新扩展</a></li>", UrlExtentAdd);
                sb.AppendFormat("<li><a href=\"{0}\">同步扩展数据</a></li>", UrlExtentSync);
            }
            sb.Append("</ul>");
            sb.Append("</li>");
            return sb.ToString();
        }
        /// <summary>
        /// 权限扩展管理
        /// </summary>
        /// <param name="sb">数据标签</param>
        private static void GetMenuItemsByExtentOfNone(ref StringBuilder sb)
        {
            sb.Append("<li>");
            sb.AppendFormat("<a href=\"{0}\" class=\"nav-top-item\">权限扩展管理</a>", GeneralHandler.DefaultUrl);
            sb.Append("<ul>");
            sb.AppendFormat("<li><a href=\"{0}\">数据列表</a></li>", UrlExtentList);
            sb.AppendFormat("<li><a href=\"{0}\">添加新扩展</a></li>", UrlExtentAdd);
            sb.AppendFormat("<li><a href=\"{0}\">同步扩展数据</a></li>", UrlExtentSync);
            sb.Append("</ul>");
            sb.Append("</li>");
        }

        #endregion

        #endregion

    }
}