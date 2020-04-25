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
    /// 状态机制控制器
    /// </summary>
    [Authorize]
    public class StatusController : Controller
    {
        /// <summary>
        /// 状态机制数据列表
        /// </summary>
        /// <param name="id">页码</param>
        /// <returns>执行结果</returns>
        public ActionResult List(string id)
        {
            var pager = new PagerHelperCHS();
            pager.PageSize = GeneralHandler.PageSize;
            pager.PageCurrent = TypeHelper.TypeToInt32(id, 1);
            int pageCount, recordCount;
            var dataList = DawnAuthStatusBLL.SelectPSPisAllPurposeRowNumber(pager.PageSize, pager.PageCurrent, null, out pageCount, out recordCount);
            pager.PageCount = pageCount;
            pager.RecordCount = recordCount;
            pager.PageRecordCount = dataList.Count;
            ViewBag.Pager = pager;
            ViewBag.PagerParam = null;
            return View(dataList);
        }
        /// <summary>
        /// 状态机制数据列表
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
            //机制编码
            var txtCode = form["txtCode"] as string;
            if (!string.IsNullOrEmpty(txtCode) && ValidHelper.EngIsEngAndNums(txtCode))
            {
                pgParam += string.Format(",txtCode,{0}", txtCode);
                if (strWhere == null)
                {
                    strWhere = string.Format("charindex('{0}',stat_code)>0", txtCode);
                }
                else
                {
                    strWhere += string.Format(" and charindex('{0}',stat_code)>0", txtCode);
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
            var dataList = DawnAuthStatusBLL.SelectPSPisAllPurposeRowNumber(dataPager.PageSize, dataPager.PageCurrent, "stat_time desc,mdl_id", strWhere, out pageCount, out recordCount);
            dataPager.PageCount = pageCount;
            dataPager.RecordCount = recordCount;
            dataPager.PageRecordCount = dataList.Count;
            ViewBag.Pager = dataPager;
            ViewBag.PagerParam = pgParam;
            return View("List", dataList);
        }
        /// <summary>
        /// 状态机制数据删除
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
                DawnAuthStatusBLL.Delete(int.Parse(id));
            }
            return stateInfo;
        }

        #region 数据添加

        /// <summary>
        /// 状态机制数据添加
        /// </summary>
        /// <returns>执行结果</returns>
        [AuthorizeFilter(tipsMode: 2)]
        [ExceptionFilter(tipsMode: 2)]
        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 状态机制添加数据保存
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
                DawnAuthStatusMDL dataInfo = new DawnAuthStatusMDL();
                dataInfo.StatTime = DateTime.Now;
                dataInfo.MdlId = int.Parse(form["ddlModule"]);
                dataInfo.StatName = form["txtName"];
                dataInfo.StatCode = form["txtCode"];
                dataInfo.StatMark = int.Parse(form["txtMark"]);
                dataInfo.StatDesc = form["txtDesc"];
                bool added = DawnAuthStatusBLL.Exists(string.Format("stat_code='{0}'", dataInfo.StatCode));
                if (added)
                {
                    stateInfo = GeneralHandler.StateAdded;
                }
                else
                {
                    DawnAuthStatusBLL.Insert(dataInfo);
                }
            }
            return stateInfo;
        }
        /// <summary>
        /// 状态机制添加数据检测
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
            string txtMark = form["txtMark"];
            if (!ValidHelper.NumIsInteger(txtMark))
            {
                stateInfo = "您输入的状态标识不正确！（只能由数字组成）";
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