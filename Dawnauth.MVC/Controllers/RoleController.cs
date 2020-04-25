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
    /// 角色信息控制器
    /// </summary>
    [Authorize]
    public class RoleController : Controller
    {
        /// <summary>
        /// 角色信息数据列表
        /// </summary>
        /// <param name="id">页码</param>
        /// <returns>执行结果</returns>
        public ActionResult List(string id)
        {
            var pager = new PagerHelperCHS();
            pager.PageSize = GeneralHandler.PageSize;
            pager.PageCurrent = TypeHelper.TypeToInt32(id, 1);
            int pageCount, recordCount;
            var dataList = DawnAuthRoleBLL.SelectPSPisAllPurposeRowNumber(pager.PageSize, pager.PageCurrent, null, out pageCount, out recordCount);
            pager.PageCount = pageCount;
            pager.RecordCount = recordCount;
            pager.PageRecordCount = dataList.Count;
            ViewBag.FPager = pager;
            ViewBag.PageCurrent = pager.PageCurrent;
            return View(dataList);
        }
        /// <summary>
        /// 角色信息数据删除
        /// </summary>
        /// <param name="id">模块编号</param>
        /// <returns>执行结果</returns>
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string Delete(string id)
        {
            var stateInfo = GeneralHandler.StateSuccess;
            if (!string.IsNullOrEmpty(id))
            {
                DawnAuthRoleBLL.Delete(int.Parse(id));
            }
            return stateInfo;
        }

        #region 数据添加

        /// <summary>
        /// 角色信息数据添加
        /// </summary>
        /// <returns>执行结果</returns>
        [AuthorizeFilter(tipsMode: 2)]
        [ExceptionFilter(tipsMode: 2)]
        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 角色信息添加数据保存
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
                DawnAuthRoleMDL dataInfo = new DawnAuthRoleMDL();
                dataInfo.RoleTime = DateTime.Now;
                dataInfo.RoleName = form["txtName"];
                dataInfo.RoleCode = form["txtCode"];
                dataInfo.RoleDesc = form["txtDesc"];
                bool added = DawnAuthRoleBLL.Exists(string.Format("role_code='{0}'", dataInfo.RoleCode));
                if (added)
                {
                    stateInfo = GeneralHandler.StateAdded;
                }
                else
                {
                    DawnAuthRoleBLL.Insert(dataInfo);
                }
            }
            return stateInfo;
        }
        /// <summary>
        /// 角色信息添加数据检测
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <param name="stateInfo">状态消息</param>
        /// <returns>执行结果</returns>
        private bool AddedByCheck(FormCollection form, out string stateInfo)
        {
            stateInfo = GeneralHandler.StateSuccess;
            string txtName = form["txtName"] as string;
            if (string.IsNullOrEmpty(txtName) || txtName.Length < 2 || txtName.Length > 50)
            {
                stateInfo = "名称不能为空或小于2个或大于50个字符！";
                return false;
            }
            if (!ValidHelper.ChsIsChineseOrEngOrNums(txtName))
            {
                stateInfo = "您输入的名称不正确！（只能由汉字、字母、数字组成）";
                return false;
            }
            string txtCode = form["txtCode"] as string;
            if ((txtCode.Length > 0 && !ValidHelper.EngIsEngAndNums(txtCode)) || txtCode.Length > 50)
            {
                stateInfo = "您输入的编码不正确！（只能由字母和数字组成，且不大于50个字）";
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
        /// 角色信息数据编辑
        /// </summary>
        /// <param name="id">管理员编号</param>
        /// <param name="pager">页码</param>
        /// <returns>执行结果</returns>
        [AuthorizeFilter(tipsMode: 2)]
        [ExceptionFilter(tipsMode: 2)]
        public ActionResult Editor(string id)
        {
            if (string.IsNullOrEmpty(id) || TypeHelper.TypeToInt32(id, -1) < 0) return RedirectToAction("List");
            var dataInfo = DawnAuthRoleBLL.Select(int.Parse(id));
            return View(dataInfo);
        }
        /// <summary>
        /// 角色信息编辑数据保存
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string Editored(FormCollection form)
        {
            if (TypeHelper.TypeToInt32(form["hidRoleId"], -1) < 0) return GeneralHandler.FBaseInfo;
            var stateInfo = GeneralHandler.StateSuccess;
            if (EditoredByCheck(form, out stateInfo))
            {
                DawnAuthRoleMDL dataInfo = new DawnAuthRoleMDL();
                dataInfo.RoleId = int.Parse(form["hidRoleId"]);
                dataInfo.RoleName = form["txtName"];
                dataInfo.RoleDesc = form["txtDesc"];
                DawnAuthRoleBLL.UpdateEditor(dataInfo);
            }
            return stateInfo;
        }
        /// <summary>
        /// 角色信息编辑数据检测
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <param name="stateInfo">状态消息</param>
        /// <returns>执行结果</returns>
        private bool EditoredByCheck(FormCollection form, out string stateInfo)
        {
            stateInfo = GeneralHandler.StateSuccess;
            string txtName = form["txtName"] as string;
            if (string.IsNullOrEmpty(txtName) || txtName.Length < 2 || txtName.Length > 50)
            {
                stateInfo = "名称不能为空或小于2个或大于50个字符！";
                return false;
            }
            if (!ValidHelper.ChsIsChineseOrEngOrNums(txtName))
            {
                stateInfo = "您输入的名称不正确！（只能由汉字、字母、数字组成）";
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

        #region 权限设定

        /// <summary>
        /// 角色信息权限设定
        /// </summary>
        /// <param name="id">角色编码</param>
        /// <param name="pager">页码</param>
        /// <returns>执行结果</returns>
        public ActionResult Authority(string id, string pager)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction("List");
            ViewBag.RoleCode = id;
            ViewBag.PageCurrent = pager;
            return View(ModuleHandler.GetTree());
        }

        #region 模块功能设定保存

        /// <summary>
        /// 角色信息权限设定保存
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string Authorityed(FormCollection form)
        {
            var stateInfo = GeneralHandler.StateSuccess;
            string roleCode = form["hidRoleCode"];
            string moduleCode = form["moduleCode"];
            string authString = form["authString"];
            var roleInfo = DawnAuthRoleBLL.ISelect(string.Format("role_code='{0}'", roleCode)).First();
            if (string.IsNullOrEmpty(roleInfo.RoleAuthority) || string.IsNullOrWhiteSpace(roleInfo.RoleAuthority) || !roleInfo.RoleAuthority.Contains(moduleCode))
            {
                authString = "|" + authString;
                authString = moduleCode + authString;
                authString += ";";
                if (!string.IsNullOrWhiteSpace(roleInfo.RoleAuthority)) authString = roleInfo.RoleAuthority + authString;
            }
            else
            {
                string[] authArray = GetModuleFunction(roleInfo.RoleAuthority);
                for (int i = 0; i < authArray.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(authArray[i])) continue;
                    if (authArray[i].Contains(moduleCode))
                    {
                        authArray[i] = "|" + authString;
                        authArray[i] = moduleCode + authArray[i];
                        break;
                    }
                }
                authString = null;
                for (int i = 0; i < authArray.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(authArray[i])) continue;
                    authString += authArray[i];
                    authString += ";";
                }
            }
            DawnAuthRoleBLL.Update(roleCode, authString);
            return stateInfo;
        }
        /// <summary>
        /// 取得模块功能权限列表
        /// <para>模块与功能为单一字符串</para>
        /// </summary>
        /// <param name="authString">功能字符串</param>
        /// <returns>执行结果</returns>
        private string[] GetModuleFunction(string authString)
        {
            string[] tmpArray = authString.Split(';');
            if (tmpArray.Length <= 0) return null;
            return tmpArray;
        }

        #endregion

        #region 模块功能获取

        /// <summary>
        /// 角色信息权限模块功能获取
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string Function(FormCollection form)
        {
            int moduleId = TypeHelper.TypeToInt32(form["moduleId"], 0);
            string roleCode = form["roleCode"] as string;
            string moduleCode = form["moduleCode"] as string;
            var stateInfo = GeneralHandler.StateFailing;
            if (moduleId > 0 && !string.IsNullOrEmpty(roleCode) && !string.IsNullOrEmpty(moduleCode))
            {
                StringBuilder sb = new StringBuilder();
                int indexVal = 0;
                var roleInfo = DawnAuthRoleBLL.ISelect(string.Format("role_code='{0}'", roleCode)).First();
                int[] funArray = null;
                if (!string.IsNullOrEmpty(roleInfo.RoleAuthority) && !string.IsNullOrWhiteSpace(roleInfo.RoleAuthority)) funArray = GetFunction(moduleCode, roleInfo.RoleAuthority);
                var funList = DawnAuthFunctionBLL.ISelect(string.Format("mdl_id='{0}' and (fun_ident < 1)", moduleId), "fun_mark");
                if (funList == null || funList.Count < 1)
                {
                    sb.Append("<li class=\"field-item bi\">");
                    sb.Append(GeneralHandler.FNoneInfo);
                    sb.Append("</li>");
                }
                else
                {
                    foreach (var item in funList)
                    {
                        indexVal++;
                        sb.Append("<li class=\"field-item bi\">");
                        sb.AppendFormat("<label>{0}</label>", item.FunName);
                        int flag = 0;
                        if (funArray != null && funArray.Length > 0)
                        {
                            int indexValue = item.FunMark - 1;
                            if (indexValue < funArray.Length)
                            {
                                if (funArray[indexValue] == 1) flag = 1;
                            }
                        }
                        if (flag == 1)
                        {
                            sb.AppendFormat("<input class=\"switch-on\" type=\"button\" id=\"btn{0}\" onclick=\"dataSave({0},'{1}','del');\" />", indexVal, moduleCode);
                            sb.AppendFormat("<input type=\"hidden\" id=\"hidAuth{0}\" value=\"1\" />", indexVal);
                        }
                        else
                        {
                            sb.AppendFormat("<input class=\"switch-off\" type=\"button\" id=\"btn{0}\" onclick=\"dataSave({0},'{1}','add');\" />", indexVal, moduleCode);
                            sb.AppendFormat("<input type=\"hidden\" id=\"hidAuth{0}\" value=\"0\" />", indexVal);
                        }
                        sb.Append("</li>");
                    }
                }
                sb.AppendFormat("<input type=\"hidden\" id=\"hidAuthCount\" value=\"{0}\" />", funList.Count);
                stateInfo = sb.ToString();
            }
            return stateInfo;
        }
        /// <summary>
        /// 获取功能项列表
        /// 整形数组
        /// </summary>
        /// <param name="moduleCode">模块编码</param>
        /// <param name="roleAuth">功能字符串</param>
        /// <returns></returns>
        private int[] GetFunction(string moduleCode, string roleAuth)
        {
            int[] funArray = null;
            string[] tmpArray = roleAuth.Split(';');
            if (tmpArray.Length <= 0) return null;
            foreach (string tmp in tmpArray)
            {
                if (string.IsNullOrWhiteSpace(tmp)) continue;
                string modStr = tmp.Substring(0, tmp.IndexOf('|'));
                if (modStr != moduleCode) continue;
                string funStr = tmp.Substring(tmp.IndexOf('|') + 1);
                funArray = new int[funStr.Length];
                for (int i = 0; i < funStr.Length; i++)
                {
                    funArray[i] = TypeHelper.TypeToInt32(funStr.Substring(i, 1), 0);
                }
                break;
            }
            return funArray;
        }

        #endregion

        #endregion

    }
}