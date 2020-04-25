using System;
using System.Web.Mvc;
using DawnXZ.DawnUtility;
using DawnXZ.PagerUtility;
using DawnXZ.VerifyUtility;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.Dawnauth.BLL;
using DawnXZ.Dawnauth.Handler;
using DawnXZ.Dawnauth.MVC.Filters;

namespace DawnXZ.Dawnauth.MVC.Controllers
{
    /// <summary>
    /// 模块功能控制器
    /// </summary>
    [Authorize]
    public class FunctionController : Controller
    {
        /// <summary>
        /// 模块功能数据列表
        /// </summary>
        /// <param name="id">页码</param>
        /// <returns>执行结果</returns>
        public ActionResult List(string id)
        {
            var pager = new PagerHelperCHS();
            pager.PageSize = GeneralHandler.PageSize;
            pager.PageCurrent = TypeHelper.TypeToInt32(id, 1);
            int pageCount, recordCount;
            var dataList = DawnAuthFunctionBLL.SelectPSPisAllPurposeRowNumber(pager.PageSize, pager.PageCurrent, null, out pageCount, out recordCount);
            pager.PageCount = pageCount;
            pager.RecordCount = recordCount;
            pager.PageRecordCount = dataList.Count;
            ViewBag.Pager = pager;
            ViewBag.PagerParam = null;
            ViewBag.ModuleList = DawnAuthModuleBLL.ISelect();
            return View(dataList);
        }
        /// <summary>
        /// 模块功能数据列表
        /// </summary>
        /// <param name="id">数据表单</param>
        /// <returns>执行结果</returns>
        public ActionResult Search(FormCollection form)
        {
            string strWhere = null;
            var pgParam = "Nothing,Nothing";
            //隶属模块
            var sltModule = TypeHelper.TypeToInt32(form["sltModule"], -1);
            if (sltModule > 0)
            {
                pgParam += string.Format(",sltModule,{0}", sltModule);
                if (strWhere == null)
                {
                    strWhere = string.Format("mdl_id='{0}'", sltModule);
                }
                else
                {
                    strWhere += string.Format(" and mdl_id='{0}'", sltModule);
                }
            }
            //功能编码
            var txtCode = form["txtCode"] as string;
            if (!string.IsNullOrEmpty(txtCode) && ValidHelper.EngIsEngAndNums(txtCode))
            {
                pgParam += string.Format(",txtCode,{0}", txtCode);
                if (strWhere == null)
                {
                    strWhere = string.Format("charindex('{0}',fun_code)>0", txtCode);
                }
                else
                {
                    strWhere += string.Format(" and charindex('{0}',fun_code)>0", txtCode);
                }
            }
            var dataPager = new PagerHelperCHS();
            dataPager.PageSize = GeneralHandler.PageSize;
            if (form.Count > 1)
            {
                dataPager.PageCurrent = TypeHelper.TypeToInt32(form["pager"], 1);
            }
            else
            {
                dataPager.PageCurrent = TypeHelper.TypeToInt32(form["id"], 1);
            }
            int pageCount, recordCount;
            var dataList = DawnAuthFunctionBLL.SelectPSPisAllPurposeRowNumber(dataPager.PageSize, dataPager.PageCurrent, "fun_time desc,mdl_id", strWhere, out pageCount, out recordCount);
            dataPager.PageCount = pageCount;
            dataPager.RecordCount = recordCount;
            dataPager.PageRecordCount = dataList.Count;
            ViewBag.Pager = dataPager;
            ViewBag.PagerParam = pgParam;
            ViewBag.ModuleList = DawnAuthModuleBLL.ISelect();
            return View("List", dataList);
        }
        /// <summary>
        /// 模块功能数据删除
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
                DawnAuthFunctionBLL.Delete(int.Parse(id));
            }
            return stateInfo;
        }

        #region 数据添加

        /// <summary>
        /// 模块信息数据添加
        /// </summary>
        /// <returns>执行结果</returns>
        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 模块功能添加数据保存
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
                DawnAuthFunctionMDL dataInfo = new DawnAuthFunctionMDL();
                dataInfo.MdlId = int.Parse(form["ddlModule"]);
                dataInfo.FunTime = DateTime.Now;
                dataInfo.FunName = form["txtName"];
                dataInfo.FunCode = form["txtCode"];
                dataInfo.FunIdent = TypeHelper.TypeToInt32(form["txtIdent"], 0);
                dataInfo.FunMark = DawnAuthFunctionBLL.GetMaxFunMark(dataInfo.MdlId);
                dataInfo.FunMark += 1;
                var mark = TypeHelper.TypeToInt32(form["ddlParentMark"], -1);
                dataInfo.FunParentMark = mark != -1 ? DawnAuthFunctionBLL.GetParentMark(dataInfo.MdlId) : mark;
                dataInfo.FunDesc = form["txtDesc"];
                bool added = false;
                if (dataInfo.FunIdent == 0)
                {
                    added = DawnAuthFunctionBLL.Exists(string.Format("mdl_id='{0}' and (fun_name='{1}' or fun_code='{2}')", dataInfo.MdlId, dataInfo.FunName, dataInfo.FunCode));
                }
                else
                {
                    added = DawnAuthFunctionBLL.Exists(string.Format("(mdl_id='{0}' and (fun_name='{1}' or fun_code='{2}')) or fun_ident='{3}'", dataInfo.MdlId, dataInfo.FunName, dataInfo.FunCode, dataInfo.FunIdent));
                }
                if (added)
                {
                    stateInfo = GeneralHandler.StateAdded;
                }
                else
                {
                    DawnAuthFunctionBLL.Insert(dataInfo);
                }
            }
            return stateInfo;
        }
        /// <summary>
        /// 模块功能添加数据检测
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <param name="stateInfo">状态消息</param>
        /// <returns>执行结果</returns>
        private bool AddedByCheck(FormCollection form, out string stateInfo)
        {
            stateInfo = GeneralHandler.StateSuccess;
            int Function = TypeHelper.TypeToInt32(form["ddlModule"], -1);
            if (Function == 0 || Function < -1)
            {
                stateInfo = "模块标识不正确！";
                return false;
            }
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
            string txtIdent = form["txtIdent"] as string;
            if (!ValidHelper.NumIsInteger(txtIdent))
            {
                stateInfo = "您输入的识别码不正确！（只能由数字组成，介于1-65535为佳）";
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

    }
}