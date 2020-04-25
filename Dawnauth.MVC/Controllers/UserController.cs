using System;
using System.Linq;
using System.Web.Mvc;
using DawnXZ.DawnUtility;
using DawnXZ.PagerUtility;
using DawnXZ.VerifyUtility;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.Dawnauth.BLL;
using DawnXZ.Dawnauth.Handler;
using DawnXZ.Dawnauth.MVC.Filters;
using System.Text;

namespace DawnXZ.Dawnauth.MVC.Controllers
{
    /// <summary>
    /// 权限管理核心控制器
    /// </summary>
    [Authorize]
    public class UserController : Controller
    {

        #region 管理员登录信息

        /// <summary>
        /// 管理员登录信息数据列表
        /// </summary>
        /// <param name="id">页码</param>
        /// <returns>执行结果</returns>
        public ActionResult LoginList(string id)
        {
            var pager = new PagerHelperCHS();
            pager.PageSize = GeneralHandler.PageSize;
            pager.PageCurrent = TypeHelper.TypeToInt32(id, 1);
            int pageCount, recordCount;
            var dataList = DawnAuthUserLoginBLL.SelectPSPisAllPurposeRowNumber(pager.PageSize, pager.PageCurrent, string.Format("user_id='{0}'", DawnauthHandler.UserId), out pageCount, out recordCount);
            pager.PageCount = pageCount;
            pager.RecordCount = recordCount;
            pager.PageRecordCount = dataList.Count;
            ViewBag.FPager = pager;
            return View(dataList);
        }
        /// <summary>
        /// 管理员登录信息数据列表
        /// </summary>
        /// <param name="id">管理员编号</param>
        /// <param name="pager">页码</param>
        /// <returns>执行结果</returns>
        public ActionResult LoginDetailed(string id, string pager)
        {
            if (string.IsNullOrEmpty(id) || TypeHelper.TypeToInt32(id, -1) < 0) return RedirectToAction("List");
            var dataPager = new PagerHelperCHS();
            dataPager.PageSize = GeneralHandler.PageSize;
            dataPager.PageCurrent = TypeHelper.TypeToInt32(pager, 1);
            int pageCount, recordCount;
            var dataList = DawnAuthUserLoginBLL.SelectPSPisAllPurposeRowNumber(dataPager.PageSize, dataPager.PageCurrent, string.Format("user_id='{0}'", int.Parse(id)), out pageCount, out recordCount);
            dataPager.PageCount = pageCount;
            dataPager.RecordCount = recordCount;
            dataPager.PageRecordCount = dataList.Count;
            ViewBag.FPager = dataPager;
            ViewBag.UserSurname = DawnAuthUserBLL.Select(int.Parse(id)).UserSurname;
            return View(dataList);
        }

        #endregion

        #region 数据列表

        /// <summary>
        /// 管理员信息数据列表
        /// </summary>
        /// <param name="id">页码</param>
        /// <returns>执行结果</returns>
        public ActionResult List(string id)
        {
            var pager = new PagerHelperCHS();
            pager.PageSize = GeneralHandler.PageSize;
            pager.PageCurrent = TypeHelper.TypeToInt32(id, 1);
            int pageCount, recordCount;
            var dataList = DawnAuthUserBLL.SelectPSPisAllPurposeRowNumber(pager.PageSize, pager.PageCurrent, null, out pageCount, out recordCount);
            pager.PageCount = pageCount;
            pager.RecordCount = recordCount;
            pager.PageRecordCount = dataList.Count;
            ViewBag.FPager = pager;
            ViewBag.PageCurrent = pager.PageCurrent;
            ViewBag.FDepartList = DawnAuthDepartmentBLL.ISelect();
            return View(dataList);
        }

        #endregion

        #region 个人信息

        /// <summary>
        /// 管理员个人详细信息
        /// </summary>
        /// <returns>执行结果</returns>
        public ActionResult MyProfile()
        {
            var dataInfo = DawnAuthUserBLL.Select(DawnauthHandler.UserId);
            return View(dataInfo);
        }

        #endregion

        #region 数据删除

        /// <summary>
        /// 管理员信息数据删除
        /// </summary>
        /// <param name="id">管理员编号</param>
        /// <returns>执行结果</returns>
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || TypeHelper.TypeToInt32(id, -1) < 0) return GeneralHandler.FBaseInfo;
            var stateInfo = GeneralHandler.StateSuccess;
            if (int.Parse(id) == DawnauthHandler.UserId)
            {
                stateInfo = "不可对当前登录管理员进行数据删除操作！";
            }
            else
            {
                //形象照片
                var picList = DawnAuthUserPicBLL.ISelect();
                foreach (var item in picList)
                {
                    DawnAuthUserPicBLL.Delete(item.PicId);
                }
                //登录日志
                var logList = DawnAuthUserLoginBLL.ISelect();
                foreach (var item in logList)
                {
                    DawnAuthUserLoginBLL.Delete(item.LogId);
                }
                //角色映射
                var roleList = DawnAuthUserRoleBLL.ISelect();
                foreach (var item in roleList)
                {
                    DawnAuthUserRoleBLL.Delete(item.MapId);
                }
                //状态机制
                var statList = DawnAuthUserStatusBLL.ISelect();
                foreach (var item in statList)
                {
                    DawnAuthUserStatusBLL.Delete(item.MapId);
                }
                //管理员数据
                DawnAuthUserBLL.Delete(int.Parse(id));
            }
            return stateInfo;
        }

        #endregion

        #region 数据添加

        /// <summary>
        /// 管理员信息数据添加
        /// </summary>
        /// <returns>执行结果</returns>
        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 管理员信息添加数据保存
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string Added(FormCollection form)
        {
            var stateInfo = GeneralHandler.StateSuccess;
            if (AddedByCheck(form, out stateInfo))
            {
                DawnAuthUserMDL dataInfo = new DawnAuthUserMDL();
                dataInfo.DptId = TypeHelper.TypeToTinyInt(form["sltDepart"], 1);
                dataInfo.UserTime = DateTime.Now;
                dataInfo.UserStatus = 1;
                dataInfo.UserGrade = TypeHelper.TypeToTinyInt(form["ddlGrade"], 1);
                dataInfo.UserSurname = form["txtSurname"];
                dataInfo.UserName = form["txtName"];
                dataInfo.UserPwd = CryptoHelper.MD5(form["txtPwd"], true);
                dataInfo.UserMobile = form["txtMobile"];
                dataInfo.UserEmail = form["txtEmail"];
                dataInfo.UserDesc = form["txtDesc"];
                bool added = DawnAuthUserBLL.Exists(string.Format("user_name='{0}'", dataInfo.UserName));
                if (added)
                {
                    stateInfo = GeneralHandler.StateAdded;
                }
                else
                {
                    DawnAuthUserBLL.Insert(dataInfo);
                }
            }
            return stateInfo;
        }
        /// <summary>
        /// 管理员信息添加数据检测
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <param name="stateInfo">状态消息</param>
        /// <returns>执行结果</returns>
        private bool AddedByCheck(FormCollection form, out string stateInfo)
        {
            stateInfo = GeneralHandler.StateSuccess;
            int sltDepart = TypeHelper.TypeToInt32(form["sltDepart"], -1);
            if (sltDepart < 1)
            {
                stateInfo = "隶属部门不正确！";
                return false;
            }
            int ddlGrade = TypeHelper.TypeToInt32(form["ddlGrade"], -1);
            if (ddlGrade < 1 || ddlGrade > 3)
            {
                stateInfo = "管理级别不正确！";
                return false;
            }
            string txtSurname = form["txtSurname"] as string;
            if (string.IsNullOrEmpty(txtSurname) || txtSurname.Length < 2 || txtSurname.Length > 10)
            {
                stateInfo = "姓名不能为空或小于2个或大于10个汉字！";
                return false;
            }
            if (!ValidHelper.ChsIsChinese(txtSurname))
            {
                stateInfo = "您输入的姓名不正确！（只能由汉字组成）";
                return false;
            }
            string txtName = form["txtName"] as string;
            if (string.IsNullOrEmpty(txtName) || txtName.Length < 4 || txtName.Length > 16)
            {
                stateInfo = "账号名称不能为空或小于4个或大于16个字符！";
                return false;
            }
            if (!ValidHelper.EngIsEngAndNums(txtName))
            {
                stateInfo = "您输入的账号名称不正确！（只能由字母、数字组成）";
                return false;
            }
            string txtPwd = form["txtPwd"] as string;
            if (string.IsNullOrEmpty(txtPwd) || txtPwd.Length < 6 || txtPwd.Length > 16)
            {
                stateInfo = "账号密码不能为空或不小于6个或大于16个字符！";
                return false;
            }
            if (!ValidHelper.EngIsPassword(txtPwd))
            {
                stateInfo = "您输入的密码不正确！（字母开头的任意字符）";
                return false;
            }
            string txtPwds = form["txtPwds"] as string;
            if (txtPwd != txtPwds)
            {
                stateInfo = "你输入的密码与确认密码不一致！";
                return false;
            }
            string txtMobile = form["txtMobile"] as string;
            if (string.IsNullOrEmpty(txtMobile) || txtMobile.Length > 15 || !ValidHelper.TelIsMobile(txtMobile))
            {
                stateInfo = "您输入的手机号码为空或不正确！";
                return false;
            }
            string txtEmail = form["txtEmail"] as string;
            if (string.IsNullOrEmpty(txtEmail) || txtEmail.Length > 50 || !ValidHelper.IsEmail(txtEmail))
            {
                stateInfo = "您输入的电子邮件为空或不正确！";
                return false;
            }
            string txtDesc = form["txtDesc"] as string;
            if ((txtDesc.Length > 0 && !ValidHelper.ChsIsMemos(txtDesc)) || txtDesc.Length > 300)
            {
                stateInfo = "您输入的描述不正确！（只能由汉字、字母、数字组成，且不大于300个字）";
                return false;
            }
            return true;
        }

        #endregion

        #region 数据编辑

        /// <summary>
        /// 管理员信息数据编辑
        /// </summary>
        /// <param name="id">管理员编号</param>
        /// <param name="pager">页码</param>
        /// <returns>执行结果</returns>
        public ActionResult Editor(string id, string pager)
        {
            if (string.IsNullOrEmpty(id) || TypeHelper.TypeToInt32(id, -1) < 0) return RedirectToAction("List");
            var dataInfo = DawnAuthUserBLL.Select(int.Parse(id));
            ViewBag.PageCurrent = pager;
            return View(dataInfo);
        }
        /// <summary>
        /// 管理员信息保存编辑数据
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string Editored(FormCollection form)
        {
            if (TypeHelper.TypeToInt32(form["hidUserId"], -1) < 0) return GeneralHandler.FBaseInfo;
            var stateInfo = GeneralHandler.StateSuccess;
            if (EditoredByCheck(form, out stateInfo))
            {
                DawnAuthUserMDL dataInfo = new DawnAuthUserMDL();
                dataInfo.UserId = int.Parse(form["hidUserId"]);
                dataInfo.DptId = TypeHelper.TypeToTinyInt(form["sltDepart"], 1);
                dataInfo.UserGrade = TypeHelper.TypeToTinyInt(form["ddlGrade"], 1);
                dataInfo.UserSurname = form["txtSurname"];
                dataInfo.UserMobile = form["txtMobile"];
                dataInfo.UserEmail = form["txtEmail"];
                dataInfo.UserDesc = form["txtDesc"];
                DawnAuthUserBLL.UpdateEditor(dataInfo);
            }
            return stateInfo;
        }
        /// <summary>
        /// 管理员信息编辑数据检测
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <param name="stateInfo">状态消息</param>
        /// <returns>执行结果</returns>
        private bool EditoredByCheck(FormCollection form, out string stateInfo)
        {
            stateInfo = GeneralHandler.StateSuccess;
            int sltDepart = TypeHelper.TypeToInt32(form["sltDepart"], -1);
            if (sltDepart < 1)
            {
                stateInfo = "隶属部门不正确！";
                return false;
            }
            int ddlGrade = TypeHelper.TypeToInt32(form["ddlGrade"], -1);
            if (ddlGrade < 1 || ddlGrade > 3)
            {
                stateInfo = "管理级别不正确！";
                return false;
            }
            string txtSurname = form["txtSurname"] as string;
            if (string.IsNullOrEmpty(txtSurname) || txtSurname.Length < 2 || txtSurname.Length > 10)
            {
                stateInfo = "姓名不能为空或小于2个或大于10个汉字！";
                return false;
            }
            if (!ValidHelper.ChsIsChinese(txtSurname))
            {
                stateInfo = "您输入的姓名不正确！（只能由汉字组成）";
                return false;
            }
            string txtMobile = form["txtMobile"] as string;
            if (string.IsNullOrEmpty(txtMobile) || txtMobile.Length > 15 || !ValidHelper.TelIsMobile(txtMobile))
            {
                stateInfo = "您输入的手机号码为空或不正确！";
                return false;
            }
            string txtEmail = form["txtEmail"] as string;
            if (string.IsNullOrEmpty(txtEmail) || txtEmail.Length > 50 || !ValidHelper.IsEmail(txtEmail))
            {
                stateInfo = "您输入的电子邮件为空或不正确！";
                return false;
            }
            string txtDesc = form["txtDesc"] as string;
            if ((txtDesc.Length > 0 && !ValidHelper.ChsIsMemos(txtDesc)) || txtDesc.Length > 300)
            {
                stateInfo = "您输入的描述不正确！（只能由汉字、字母、数字组成，且不大于300个字）";
                return false;
            }
            return true;
        }

        #endregion

        #region 角色绑定

        /// <summary>
        /// 管理员角色绑定
        /// </summary>
        /// <param name="id">管理员编号</param>
        /// <returns>执行结果</returns>
        [AuthorizeFilter(tipsMode: 2)]
        [ExceptionFilter(tipsMode: 2)]
        public ActionResult BindRole(string id)
        {
            if (string.IsNullOrEmpty(id) || TypeHelper.TypeToInt32(id, -1) < 0) return RedirectToAction("List");
            var dataList = DawnAuthRoleBLL.ISelect();
            var roleList = DawnAuthUserRoleBLL.ISelect(string.Format("user_id='{0}'", int.Parse(id)));
            ViewBag.UserId = id;
            ViewBag.UserBindRole = roleList;
            return View(dataList);
        }
        /// <summary>
        /// 管理员角色绑定数据保存
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 2)]
        [ExceptionFilter(tipsMode: 2)]
        public string BindRoled(FormCollection form)
        {
            var stateInfo = GeneralHandler.StateSuccess;
            int userId = TypeHelper.TypeToInt32(form["userId"], -1);
            int roleId = TypeHelper.TypeToInt32(form["roleId"], -1);
            string opFlag = form["opFlag"] as string;
            if (userId > 0 && roleId > 0 && !string.IsNullOrEmpty(opFlag))
            {
                if (opFlag == "add")
                {
                    DawnAuthUserRoleMDL dataInfo = new DawnAuthUserRoleMDL();
                    dataInfo.UserId = userId;
                    dataInfo.RoleId = roleId;
                    dataInfo.MapTime = DateTime.Now;
                    DawnAuthUserRoleBLL.Insert(dataInfo);
                }
                else if (opFlag == "del")
                {
                    DawnAuthUserRoleBLL.DeleteWhere(string.Format("user_id='{0}' and role_id='{1}'", userId, roleId));
                }
            }
            else
            {
                stateInfo = GeneralHandler.FBaseInfo;
            }
            return stateInfo;
        }

        #endregion

        #region 机制绑定

        /// <summary>
        /// 管理员机制绑定
        /// </summary>
        /// <param name="id">管理员编号</param>
        /// <param name="pager">页码</param>
        /// <returns>执行结果</returns>
        public ActionResult BindStatus(string id, string pager)
        {
            if (string.IsNullOrEmpty(id) || TypeHelper.TypeToInt32(id, -1) < 0) return RedirectToAction("List");
            ViewBag.UserId = id;
            ViewBag.PageCurrent = pager;
            return View(ModuleHandler.GetTree());
        }
        /// <summary>
        /// 管理员机制绑定数据保存
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string BindStatused(FormCollection form)
        {
            var stateInfo = GeneralHandler.StateSuccess;
            int userId = TypeHelper.TypeToInt32(form["userId"], -1);
            int statusId = TypeHelper.TypeToInt32(form["statusId"], -1);
            string opFlag = form["opFlag"] as string;
            if (userId > 0 && statusId > 0 && !string.IsNullOrEmpty(opFlag))
            {
                if (opFlag == "add")
                {
                    DawnAuthUserStatusMDL dataInfo = new DawnAuthUserStatusMDL();
                    dataInfo.UserId = userId;
                    dataInfo.StatId = statusId;
                    dataInfo.MapTime = DateTime.Now;
                    DawnAuthUserStatusBLL.Insert(dataInfo);
                }
                else if (opFlag == "del")
                {
                    DawnAuthUserStatusBLL.DeleteWhere(string.Format("user_id='{0}' and stat_id='{1}'", userId, statusId));
                }
            }
            else
            {
                stateInfo = GeneralHandler.FBaseInfo;
            }
            return stateInfo;
        }

        #endregion

        #region 隶属模块状态机制获取

        /// <summary>
        /// 隶属模块状态机制获取
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string GetStatus(FormCollection form)
        {
            int moduleId = TypeHelper.TypeToInt32(form["moduleId"], 0);
            int userId = TypeHelper.TypeToInt32(form["userId"], 0);
            if (moduleId < 1 || userId < 1) return GeneralHandler.FNoneInfo;
            var dataList = DawnAuthStatusBLL.ISelect(string.Format("mdl_id='{0}'", moduleId), "stat_mark");
            if (dataList == null || dataList.Count < 1) return GeneralHandler.FNoneInfo;
            var mapList = DawnAuthUserStatusBLL.ISelect(string.Format("user_id='{0}'", userId));
            int indexVal = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var item in dataList)
            {
                indexVal++;
                sb.Append("<li class=\"field-item bi\">");
                sb.AppendFormat("<label>{0}</label>", item.StatName);
                if (mapList != null && mapList.Count(p => p.StatId == item.StatId) > 0)
                {
                    sb.AppendFormat("<input class=\"switch-on\" type=\"button\" id=\"btn{0}\" onclick=\"dataUnSave({0},{1},{2});\" />", indexVal, userId, item.StatId);
                }
                else
                {
                    sb.AppendFormat("<input class=\"switch-off\" type=\"button\" id=\"btn{0}\" onclick=\"dataSave({0},{1},{2});\" />", indexVal, userId, item.StatId);
                }
                sb.AppendFormat("<span class=\"margin-left-10\">{0}</span>", item.StatDesc);
                sb.Append("</li>");
            }
            return sb.ToString();
        }

        #endregion

        #region 权限绑定

        /// <summary>
        /// 管理员权限绑定
        /// </summary>
        /// <param name="id">管理员编号</param>
        /// <param name="pager">页码</param>
        /// <returns>执行结果</returns>
        public ActionResult BindPower(string id, string pager)
        {
            if (string.IsNullOrEmpty(id) || TypeHelper.TypeToInt32(id, -1) < 0) return RedirectToAction("List");
            ViewBag.UserId = id;
            ViewBag.PageCurrent = pager;            
            return View(ModuleHandler.GetPowerTree());
        }
        /// <summary>
        /// 管理员权限绑定数据保存
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string BindPowered(FormCollection form)
        {
            var stateInfo = GeneralHandler.StateSuccess;
            int userId = TypeHelper.TypeToInt32(form["userId"], -1);
            int mapModule = TypeHelper.TypeToInt32(form["mapModule"], -1);
            int mapFunction = TypeHelper.TypeToInt32(form["mapFunction"], -1);
            string opFlag = form["opFlag"] as string;
            if (userId > 0 && mapModule > 0 && mapFunction > 0)
            {                
                var powList = DawnAuthUserPowerBLL.ISelect(string.Format("user_id='{0}' and map_module='{1}'", userId, mapModule));
                if (powList == null || powList.Count < 1)
                {
                    var upFun = string.Format(",{0},", mapFunction);
                    if (opFlag == "add")
                    {
                        DawnAuthUserPowerMDL dataInfo = new DawnAuthUserPowerMDL();
                        dataInfo.UserId = userId;
                        dataInfo.MapTime = DateTime.Now;
                        dataInfo.MapModule = mapModule;
                        dataInfo.MapFunction = upFun;
                        DawnAuthUserPowerBLL.Insert(dataInfo);
                    }
                }
                else
                {
                    var upFun = string.Format("{0},", mapFunction);
                    var strFun = powList.First().MapFunction;
                    if (string.IsNullOrEmpty(strFun)) strFun = ",";
                    if (opFlag == "add")
                    {
                        if (!strFun.Contains(upFun))
                        {
                            strFun += upFun;
                            DawnAuthUserPowerBLL.UpdateFunction(userId, mapModule, strFun);
                        }
                    }
                    else if (opFlag == "del")
                    {
                        upFun = string.Format(",{0},", mapFunction);
                        strFun = strFun.Replace(upFun, ",");
                        DawnAuthUserPowerBLL.UpdateFunction(userId, mapModule, strFun);
                    }
                }                
            }
            else
            {
                stateInfo = GeneralHandler.FBaseInfo;
            }
            return stateInfo;
        }

        #endregion

        #region 隶属模块绑定权限获取

        /// <summary>
        /// 隶属模块绑定权限获取
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string GetPower(FormCollection form)
        {
            int moduleId = TypeHelper.TypeToInt32(form["moduleId"], 0);
            int userId = TypeHelper.TypeToInt32(form["userId"], 0);
            if (moduleId < 1 || userId < 1) return GeneralHandler.FNoneInfo;
            var dataList = DawnAuthFunctionBLL.ISelect("fun_ident > 0", "fun_ident");
            if (dataList == null || dataList.Count < 1) return GeneralHandler.FNoneInfo;
            var mapList = DawnAuthUserPowerBLL.ISelect(string.Format("user_id='{0}' and map_module='{1}'", userId, moduleId));
            string mapFunction = null;
            if (mapList.Count > 0) mapFunction = mapList.First().MapFunction;
            int indexVal = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var item in dataList)
            {
                indexVal++;
                sb.Append("<li class=\"field-item bi\">");
                sb.AppendFormat("<label>{0}</label>", item.FunName);
                var findFun = string.Format(",{0},", item.FunIdent);
                if (mapFunction != null && mapFunction.Contains(findFun))
                {
                    sb.AppendFormat("<input class=\"switch-on\" type=\"button\" id=\"btn{0}\" onclick=\"dataUnSave({0},{1},{2},{3});\" />", indexVal, userId, moduleId, item.FunIdent);
                }
                else
                {
                    sb.AppendFormat("<input class=\"switch-off\" type=\"button\" id=\"btn{0}\" onclick=\"dataSave({0},{1},{2},{3});\" />", indexVal, userId, moduleId, item.FunIdent);
                }
                sb.AppendFormat("<span class=\"margin-left-10\">{0}</span>", item.FunDesc);
                sb.Append("</li>");
            }
            return sb.ToString();
        }

        #endregion

        #region 权限扩展

        /// <summary>
        /// 管理员权限扩展
        /// </summary>
        /// <param name="id">管理员编号</param>
        /// <param name="pager">页码</param>
        /// <returns>执行结果</returns>
        public ActionResult BindExtent(string id, string pager)
        {
            if (string.IsNullOrEmpty(id) || TypeHelper.TypeToInt32(id, -1) < 0) return RedirectToAction("List");
            ViewBag.UserId = id;
            ViewBag.PageCurrent = pager;
            return View(DawnAuthExtentBLL.SelectByCodeList());
        }
        /// <summary>
        /// 管理员权限扩展数据保存
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string BindExtented(FormCollection form)
        {
            var stateInfo = GeneralHandler.StateSuccess;
            int userId = TypeHelper.TypeToInt32(form["userId"], -1);
            string exteCode = form["exteCode"] as string;
            string exteMark = form["exteMark"] as string;
            string opFlag = form["opFlag"] as string;
            if (userId > 0 && !string.IsNullOrEmpty(exteCode) && !string.IsNullOrEmpty(exteMark))
            {
                if (opFlag == "add")
                {
                    DawnAuthUserExtentMDL dataInfo = new DawnAuthUserExtentMDL();
                    dataInfo.UserId = userId;
                    dataInfo.ExtTime = DateTime.Now;
                    dataInfo.ExtCode = exteCode;
                    dataInfo.ExtMark = exteMark;
                    DawnAuthUserExtentBLL.Insert(dataInfo);
                }
                else if (opFlag == "del")
                {
                    DawnAuthUserExtentBLL.DeleteWhere(string.Format("user_id='{0}' and ext_code='{1}' and ext_mark='{2}'", userId, exteCode, exteMark));
                }
            }
            else
            {
                stateInfo = GeneralHandler.FBaseInfo;
            }
            return stateInfo;
        }

        #endregion

        #region 获取权限扩展标识数据列表

        /// <summary>
        /// 隶属模块绑定权限获取
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string GetExtentMark(FormCollection form)
        {
            string exteCode = form["exteCode"] as string;
            int userId = TypeHelper.TypeToInt32(form["userId"], 0);
            if (string.IsNullOrEmpty(exteCode) || userId < 1) return GeneralHandler.FNoneInfo;
            var dataList = DawnAuthExtentBLL.ISelect(string.Format("exte_code='{0}'", exteCode));
            if (dataList == null || dataList.Count < 1) return GeneralHandler.FNoneInfo;
            var mapExtent = UserHandler.GetUserExtent(userId, exteCode);            
            int indexVal = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var item in dataList)
            {
                indexVal++;
                sb.Append("<li class=\"field-item bi\">");
                sb.AppendFormat("<label class=\"fixed240\">{0}</label>", item.ExteMarkName);
                var findFun = string.Format(",{0},", item.ExteMark);
                if (mapExtent != null && mapExtent.Contains(findFun))
                {
                    sb.AppendFormat("<input class=\"switch-on\" type=\"button\" id=\"btn{0}\" onclick=\"dataUnSave({0},{1},'{2}','{3}');\" />", indexVal, userId, exteCode, item.ExteMark);
                }
                else
                {
                    sb.AppendFormat("<input class=\"switch-off\" type=\"button\" id=\"btn{0}\" onclick=\"dataSave({0},{1},'{2}','{3}');\" />", indexVal, userId, exteCode, item.ExteMark);
                }
                sb.AppendFormat("<span class=\"margin-left-10\">{0}</span>", item.ExteMemo);
                sb.Append("</li>");
            }
            return sb.ToString();
        }

        #endregion

        #region 密码重置

        /// <summary>
        /// 管理员密码重置
        /// </summary>
        /// <param name="id">管理员编号</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string Reset(string id)
        {
            if (string.IsNullOrEmpty(id) || TypeHelper.TypeToInt32(id, -1) < 0) return GeneralHandler.FBaseInfo;
            var stateInfo = GeneralHandler.StateSuccess;
            if (int.Parse(id) == DawnauthHandler.UserId)
            {
                stateInfo = "不可对当前登录管理员进行密码重置操作！";
            }
            else
            {
                stateInfo = "Dawn";
                stateInfo += CheckCodeHelper.GetEngAndNum(8);
                DawnAuthUserBLL.Update(int.Parse(id), CryptoHelper.MD5(stateInfo, true));
            }
            return stateInfo;
        }

        #endregion

        #region 密码修改

        /// <summary>
        /// 管理员密码修改
        /// </summary>
        /// <returns>执行结果</returns>
        [AuthorizeFilter(tipsMode: 2)]
        [ExceptionFilter(tipsMode: 2)]
        public ActionResult Password()
        {
            return View();
        }
        /// <summary>
        /// 管理员密码修改
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string Passworded(FormCollection form)
        {
            string oldPwd = form["txtOldPwd"] as string;
            string newPwd = form["txtNewPwd"] as string;
            string cifPwd = form["txtCifPwd"] as string;
            if (oldPwd == newPwd)
            {
                return "新密码不能与旧密码相同！";
            }
            oldPwd = CryptoHelper.MD5(oldPwd, true);
            if (oldPwd != DawnauthHandler.UserInfo.UserPwd)
            {
                return "您输入的旧密码有误，请重新输入。";
            }
            if (newPwd != cifPwd)
            {
                return "你输入的密码与确认密码不一致！";
            }
            var stateInfo = GeneralHandler.StateSuccess;
            cifPwd = CryptoHelper.MD5(newPwd, true);
            DawnAuthUserBLL.Update(DawnauthHandler.UserId, cifPwd);
            return stateInfo;
        }

        #endregion

        #region 照片补传

        /// <summary>
        /// 管理员照片补传
        /// </summary>
        /// <param name="id">管理员编号</param>
        /// <returns>执行结果</returns>
        [AuthorizeFilter(tipsMode: 2)]
        [ExceptionFilter(tipsMode: 2)]
        public ActionResult Photo(string id)
        {
            if (string.IsNullOrEmpty(id) || TypeHelper.TypeToInt32(id, -1) < 0) return RedirectToAction("List");
            ViewBag.UserId = id;
            return View();
        }
        /// <summary>
        /// 管理员照片补传数据保存
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <returns>执行结果</returns>
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string Photoed(FormCollection form)
        {
            //string userId = form["hidUserId"] as string;
            //string fupPicture = form["fupPicture"] as string;

            var stateInfo = GeneralHandler.StateSuccess;
            stateInfo = "敬请期待！！！";
            //cifPwd = CryptoHelper.MD5(newPwd, true);
            //DawnAuthUserBLL.Update(DawnauthHandler.UserId, cifPwd);
            return stateInfo;
        }

        #endregion

    }
}