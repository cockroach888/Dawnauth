using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DawnXZ.DawnUtility;
using DawnXZ.PagerUtility;
using DawnXZ.VerifyUtility;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.Dawnauth.BLL;
using DawnXZ.Dawnauth.Handler;
using DawnXZ.Dawnauth.MVC.Filters;
using System.Collections;

namespace DawnXZ.Dawnauth.MVC.Controllers
{
    /// <summary>
    /// 单位部门控制器
    /// </summary>
    [Authorize]
    public class DepartController : Controller
    {
        /// <summary>
        /// 单位部门数据列表
        /// </summary>
        /// <param name="id">页码</param>
        /// <returns>执行结果</returns>
        public ActionResult List(string id)
        {
            var pager = new PagerHelperCHS();
            pager.PageSize = GeneralHandler.PageSize;
            pager.PageCurrent = TypeHelper.TypeToInt32(id, 1);
            int pageCount, recordCount;
            var dataList = DawnAuthDepartmentBLL.SelectPSPisAllPurposeRowNumber(pager.PageSize, pager.PageCurrent, null, out pageCount, out recordCount);
            pager.PageCount = pageCount;
            pager.RecordCount = recordCount;
            pager.PageRecordCount = dataList.Count;
            ViewBag.Pager = pager;
            ViewBag.PagerParam = null;
            return View(dataList);
        }
        /// <summary>
        /// 单位部门数据列表
        /// </summary>
        /// <param name="id">数据表单</param>
        /// <returns>执行结果</returns>
        public ActionResult Search(FormCollection form)
        {
            string strWhere = null;
            var pgParam = "Nothing,Nothing";
            //隶属部门
            var sltDepart = TypeHelper.TypeToInt32(form["sltDepart"], -1);
            if (sltDepart > 0)
            {
                pgParam += string.Format(",sltDepart,{0}", sltDepart);
                if (strWhere == null)
                {
                    strWhere = string.Format("charindex(',{0},',dpt_path)>0", sltDepart);
                }
                else
                {
                    strWhere += string.Format(" and charindex(',{0},',dpt_path)>0", sltDepart);
                }
            }
            //部门编码
            var txtCode = form["txtCode"] as string;
            if (!string.IsNullOrEmpty(txtCode) && ValidHelper.EngIsEngAndNums(txtCode))
            {
                pgParam += string.Format(",txtCode,{0}", txtCode);
                if (strWhere == null)
                {
                    strWhere = string.Format("charindex('{0}',dpt_code)>0", txtCode);
                }
                else
                {
                    strWhere += string.Format(" and charindex('{0}',dpt_code)>0", txtCode);
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
            var dataList = DawnAuthDepartmentBLL.SelectPSPisAllPurposeRowNumber(dataPager.PageSize, dataPager.PageCurrent, "dpt_time desc,dpt_path", strWhere, out pageCount, out recordCount);
            dataPager.PageCount = pageCount;
            dataPager.RecordCount = recordCount;
            dataPager.PageRecordCount = dataList.Count;
            ViewBag.Pager = dataPager;
            ViewBag.PagerParam = pgParam;
            return View("List", dataList);
        }
        /// <summary>
        /// 单位部门目录树
        /// </summary>
        /// <param name="id">模块编号</param>
        /// <returns>执行结果</returns>
        [AuthorizeFilter(tipsMode: 2)]
        [ExceptionFilter(tipsMode: 2)]
        public ActionResult Trees(string id)
        {
            IList<DawnAuthDepartmentMDL> sourceList = null;
            if (!string.IsNullOrEmpty(id))
            {
                sourceList = DepartHandler.GetTree(int.Parse(id));
            }
            return View(sourceList);
        }
        /// <summary>
        /// 单位部门数据删除
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
                DawnAuthDepartmentBLL.Delete(int.Parse(id), true);
            }
            return stateInfo;
        }

        #region 数据添加

        /// <summary>
        /// 单位部门数据添加
        /// </summary>
        /// <returns>执行结果</returns>
        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 单位部门添加数据保存
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
                DawnAuthDepartmentMDL dataInfo = new DawnAuthDepartmentMDL();
                int father = TypeHelper.TypeToInt32(form["ddlFather"], -1);
                dataInfo.DptFather = father;
                dataInfo.DptName = form["txtName"];
                dataInfo.DptCode = form["txtCode"];
                dataInfo.DptIdent = TypeHelper.TypeToInt32(form["txtIdent"], 0);
                dataInfo.DptRank = TypeHelper.TypeToInt32(form["txtRank"], 255);
                dataInfo.DptClick = 0;
                dataInfo.DptCounts = 0;
                dataInfo.DptDesc = form["txtDesc"];
                dataInfo.DptTime = DateTime.Now;
                bool added = false;
                if (father == -1)
                {
                    added = DawnAuthDepartmentBLL.ExistsOfWhere(string.Format("(dpt_name='{0}' or dpt_code='{1}') and dpt_ident='{2}'", dataInfo.DptName, dataInfo.DptCode, dataInfo.DptIdent));
                }
                else
                {
                    added = DawnAuthDepartmentBLL.ExistsOfWhere(string.Format("((dpt_name='{0}' and dpt_father='{1}') or dpt_code='{2}') and dpt_ident='{3}'", dataInfo.DptName, father, dataInfo.DptCode, dataInfo.DptIdent));
                }
                if (added)
                {
                    stateInfo = GeneralHandler.StateAdded;
                }
                else
                {
                    DawnAuthDepartmentBLL.Insert(dataInfo, father == -1 ? false : true);
                }
            }
            return stateInfo;
        }
        /// <summary>
        /// 单位部门添加数据检测
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <param name="stateInfo">状态消息</param>
        /// <returns>执行结果</returns>
        private bool AddedByCheck(FormCollection form, out string stateInfo)
        {
            stateInfo = GeneralHandler.StateSuccess;
            int father = TypeHelper.TypeToInt32(form["ddlFather"], -1);
            if (father == 0 || father < -1)
            {
                stateInfo = "部门标识不正确！";
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
            string txtRank = form["txtRank"] as string;
            if ((txtRank.Length > 0 && !ValidHelper.NumIsIntegralBySignless(txtRank)) || int.Parse(txtRank) < 1 || int.Parse(txtRank) > 65535)
            {
                stateInfo = "您输入的序列不正确！（只能由数字组成，且不小于1及大于65535）";
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
