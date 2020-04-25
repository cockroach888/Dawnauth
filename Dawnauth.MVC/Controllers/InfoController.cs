using System;
using System.Web.Mvc;
using DawnXZ.DawnUtility;
using DawnXZ.PagerUtility;
using DawnXZ.VerifyUtility;
using DawnXZ.Dawnauth.BLL;
using DawnXZ.Dawnauth.Handler;
using DawnXZ.Dawnauth.MVC.Filters;

namespace DawnXZ.Dawnauth.MVC.Controllers
{
    /// <summary>
    /// 错误与日志信息控制器
    /// </summary>
    [Authorize]
    public class InfoController : Controller
    {

        #region 错误信息管理

        /// <summary>
        /// 错误信息列表
        /// </summary>
        /// <param name="id">页码</param>
        /// <returns>执行结果</returns>
        public ActionResult ErrorList(string id)
        {
            var pager = new PagerHelperCHS();
            pager.PageSize = GeneralHandler.PageSize;
            pager.PageCurrent = TypeHelper.TypeToInt32(id, 1);
            int pageCount, recordCount;
            var dataList = DawnAuthErrorBLL.SelectPSPisAllPurposeRowNumber(pager.PageSize, pager.PageCurrent, null, out pageCount, out recordCount);
            pager.PageCount = pageCount;
            pager.RecordCount = recordCount;
            pager.PageRecordCount = dataList.Count;
            ViewBag.FPager = pager;
            ViewBag.PageCurrent = pager.PageCurrent;
            return View(dataList);
        }
        /// <summary>
        /// 错误信息清空
        /// </summary>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string ErrorClear()
        {
            var stateInfo = GeneralHandler.StateSuccess;
            DawnAuthErrorBLL.DeleteAll();
            return stateInfo;
        }
        /// <summary>
        /// 错误信息详细信息
        /// </summary>
        /// <param name="id">错误编号</param>
        /// <param name="pager">页码</param>
        /// <returns>执行结果</returns>
        public ActionResult ErrorDetailed(string id, string pager)
        {
            if (string.IsNullOrEmpty(id) || !ValidHelper.IsGuid(id)) return RedirectToAction("ErrorList");
            var dataInfo = DawnAuthErrorBLL.Select(Guid.Parse(id));
            ViewBag.PageCurrent = pager;
            return View(dataInfo);
        }

        #endregion

        #region 日志信息管理

        /// <summary>
        /// 日志信息列表
        /// </summary>
        /// <param name="id">页码</param>
        /// <returns>执行结果</returns>        
        public ActionResult LogsList(string id)
        {
            var pager = new PagerHelperCHS();
            pager.PageSize = GeneralHandler.PageSize;
            pager.PageCurrent = TypeHelper.TypeToInt32(id, 1);
            int pageCount, recordCount;
            var dataList = DawnAuthLogsBLL.SelectPSPisAllPurposeRowNumber(pager.PageSize, pager.PageCurrent, null, out pageCount, out recordCount);
            pager.PageCount = pageCount;
            pager.RecordCount = recordCount;
            pager.PageRecordCount = dataList.Count;
            ViewBag.FPager = pager;
            ViewBag.PageCurrent = pager.PageCurrent;
            return View(dataList);
        }
        /// <summary>
        /// 日志信息清空
        /// </summary>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string LogsClear()
        {
            var stateInfo = GeneralHandler.StateSuccess;
            DawnAuthLogsBLL.DeleteAll();
            return stateInfo;
        }
        /// <summary>
        /// 日志信息详细信息
        /// </summary>
        /// <param name="id">日志编号</param>
        /// <param name="pager">页码</param>
        /// <returns>执行结果</returns>
        public ActionResult LogsDetailed(string id, string pager)
        {
            if (string.IsNullOrEmpty(id) || !ValidHelper.IsGuid(id)) return RedirectToAction("LogsList");
            var dataInfo = DawnAuthLogsBLL.Select(Guid.Parse(id));
            ViewBag.PageCurrent = pager;
            return View(dataInfo);
        }

        #endregion

    }
}