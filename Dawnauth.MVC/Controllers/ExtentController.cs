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
    /// 权限扩展控制器
    /// </summary>
    [Authorize]
    public class ExtentController : Controller
    {

        #region 数据列表

        /// <summary>
        /// 权限扩展数据列表
        /// </summary>
        /// <param name="id">页码</param>
        /// <returns>执行结果</returns>
        public ActionResult List(string id)
        {
            var pager = new PagerHelperCHS();
            pager.PageSize = GeneralHandler.PageSize;
            pager.PageCurrent = TypeHelper.TypeToInt32(id, 1);
            int pageCount, recordCount;
            var dataList = DawnAuthExtentBLL.SelectPSPisAllPurposeRowNumber(pager.PageSize, pager.PageCurrent, null, out pageCount, out recordCount);
            pager.PageCount = pageCount;
            pager.RecordCount = recordCount;
            pager.PageRecordCount = dataList.Count;
            ViewBag.Pager = pager;
            ViewBag.PagerParam = null;
            return View(dataList);
        }
        /// <summary>
        /// 权限扩展数据列表
        /// </summary>
        /// <param name="id">数据表单</param>
        /// <returns>执行结果</returns>
        public ActionResult Search(FormCollection form)
        {
            string strWhere = null;
            var pgParam = "Nothing,Nothing";
            //扩展编码
            var txtCode = form["txtCode"] as string;
            if (!string.IsNullOrEmpty(txtCode) && ValidHelper.EngIsEngAndNum(txtCode))
            {
                pgParam += string.Format(",txtCode,{0}", txtCode);
                if (strWhere == null)
                {
                    strWhere = string.Format("charindex('{0}',exte_code)>0", txtCode);
                }
                else
                {
                    strWhere += string.Format(" and charindex('{0}',exte_code)>0", txtCode);
                }
            }
            //扩展标识
            var txtMark = form["txtMark"] as string;
            if (!string.IsNullOrEmpty(txtMark) && ValidHelper.EngIsEngAndNum(txtMark))
            {
                pgParam += string.Format(",txtMark,{0}", txtMark);
                if (strWhere == null)
                {
                    strWhere = string.Format("charindex('{0}',exte_mark)>0", txtMark);
                }
                else
                {
                    strWhere += string.Format(" and charindex('{0}',exte_mark)>0", txtMark);
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
            var dataList = DawnAuthExtentBLL.SelectPSPisAllPurposeRowNumber(dataPager.PageSize, dataPager.PageCurrent, "exte_time desc,exte_code", strWhere, out pageCount, out recordCount);
            dataPager.PageCount = pageCount;
            dataPager.RecordCount = recordCount;
            dataPager.PageRecordCount = dataList.Count;
            ViewBag.Pager = dataPager;
            ViewBag.PagerParam = pgParam;
            return View("List", dataList);
        }

        #endregion

        #region 数据删除

        /// <summary>
        /// 权限扩展数据删除
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
                DawnAuthExtentBLL.Delete(int.Parse(id));
            }
            return stateInfo;
        }

        #endregion

        #region 数据添加

        /// <summary>
        /// 权限扩展数据添加
        /// </summary>
        /// <returns>执行结果</returns>
        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 权限扩展添加数据保存
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
                DawnAuthExtentMDL dataInfo = new DawnAuthExtentMDL();
                dataInfo.ExteTime = DateTime.Now;
                dataInfo.ExteStatus = 1;
                dataInfo.ExteCode = form["txtCode"].Trim();
                dataInfo.ExteCodeName = form["txtCodeName"].Trim();
                dataInfo.ExteMark = form["txtMark"].Trim();
                dataInfo.ExteMarkName = form["txtMarkName"].Trim();
                dataInfo.ExteMemo = form["txtMemo"].Trim();
                bool added = DawnAuthExtentBLL.Exists(string.Format("exte_code='{0}' and exte_mark='{1}'", dataInfo.ExteCode, dataInfo.ExteMark));
                if (added)
                {
                    stateInfo = GeneralHandler.StateAdded;
                }
                else
                {
                    DawnAuthExtentBLL.Insert(dataInfo);
                }
            }
            return stateInfo;
        }
        /// <summary>
        /// 权限扩展添加数据检测
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <param name="stateInfo">状态消息</param>
        /// <returns>执行结果</returns>
        private bool AddedByCheck(FormCollection form, out string stateInfo)
        {
            stateInfo = GeneralHandler.StateSuccess;            
            string txtCode = form["txtCode"] as string;
            if ((txtCode.Length > 0 && !ValidHelper.EngIsEngAndNum(txtCode)) || txtCode.Length > 100)
            {
                stateInfo = "您输入的编码不正确！（只能由字母和数字组成，且不大于100个字）";
                return false;
            }
            string txtCodeName = form["txtCodeName"] as string;
            if (string.IsNullOrEmpty(txtCodeName) || txtCodeName.Length < 2 || txtCodeName.Length > 200)
            {
                stateInfo = "编码名称不能为空或小于2个或大于200个字符！";
                return false;
            }
            if (!ValidHelper.ChsIsChineseOrEngOrNum(txtCodeName))
            {
                stateInfo = "您输入的编码名称不正确！（只能由汉字、字母、数字组成）";
                return false;
            }
            string txtMark = form["txtMark"] as string;
            if ((txtMark.Length > 0 && !ValidHelper.EngIsEngAndNum(txtMark)) || txtMark.Length > 100)
            {
                stateInfo = "您输入的标识不正确！（只能由字母和数字组成，且不大于100个字）";
                return false;
            }
            string txtMarkName = form["txtMarkName"] as string;
            if (string.IsNullOrEmpty(txtMarkName) || txtMarkName.Length < 2 || txtMarkName.Length > 200)
            {
                stateInfo = "标识名称不能为空或小于2个或大于200个字符！";
                return false;
            }
            if (!ValidHelper.ChsIsChineseOrEngOrNum(txtMarkName))
            {
                stateInfo = "您输入的标识名称不正确！（只能由汉字、字母、数字组成）";
                return false;
            }
            string txtMemo = form["txtMemo"] as string;
            if ((txtMemo.Length > 0 && !ValidHelper.ChsIsMemos(txtMemo)) || txtMemo.Length > 500)
            {
                stateInfo = "您输入的扩展备注不正确！（只能由汉字、字母、数字组成，且不大于500个字）";
                return false;
            }
            return true;
        }

        #endregion

        #region 数据同步

        /// <summary>
        /// 权限扩展数据同步
        /// </summary>
        /// <returns>执行结果</returns>
        public ActionResult Sync()
        {
            return View();
        }

        #region 保存同步数据

        /// <summary>
        /// 权限扩展保存同步数据
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string Synced(FormCollection form)
        {
            var stateInfo = GeneralHandler.StateSuccess;
            if (GetSyncDataByCheck(form, out stateInfo))
            {
                string txtSetCode = form["txtSetCode"] as string;
                string txtSetName = form["txtSetName"] as string;
                int sltSyncItem = TypeHelper.TypeToInt32(form["sltSyncItem"], 2);
                string txtFieldTable = form["txtFieldTable"] as string;
                string txtFieldMark = form["txtFieldMark"] as string;
                string txtFieldName = form["txtFieldName"] as string;
                string txtFieldMemo = form["txtFieldMemo"] as string;
                string txtFieldWhere = form["txtFieldWhere"] as string;
                string txtConnSource = form["txtConnSource"] as string;
                string txtConnData = form["txtConnData"] as string;
                string txtConnUser = form["txtConnUser"] as string;
                string txtConnPwd = form["txtConnPwd"] as string;
                System.Data.DataTable dt = Session["ExtentSyncData"] as System.Data.DataTable;//直接获取会话数据                
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (sltSyncItem == 2) DawnAuthExtentBLL.DeleteWhere(string.Format("exte_status=2 and exte_code='{0}'", txtSetCode));
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        //DawnAuthExtentMDL dataInfo;
                        DawnAuthExtentMDL dataInfo = new DawnAuthExtentMDL();
                        foreach (System.Data.DataRow dr in dt.Rows)
                        {
                            //dataInfo = new DawnAuthExtentMDL();
                            dataInfo.ExteTime = DateTime.Now;
                            dataInfo.ExteStatus = 2;
                            dataInfo.ExteCode = txtSetCode;
                            dataInfo.ExteCodeName = txtSetName;
                            dataInfo.ExteMark = dr[txtFieldMark].ToString();
                            dataInfo.ExteMarkName = dr[txtFieldName].ToString();
                            dataInfo.ExteMemo = txtFieldMemo == "null" ? "无" : dr[txtFieldMemo].ToString();
                            DawnAuthExtentBLL.Insert(dataInfo);
                        }
                        dataInfo = null;
                    }
                    else
                    {
                        stateInfo = "请先执行【获取数据】操作后，再执行【开始同步】操作。";
                    }
                    Session["ExtentSyncData"] = null;
                }
                catch (Exception ex)
                {
                    Session["ExtentSyncData"] = null;
                    stateInfo = ex.Message;
                    GeneralHandler.InsertByError(ex);
                }
            }
            return stateInfo;
        }

        #endregion

        #region 获取同步数据

        /// <summary>
        /// 权限扩展获取同步数据
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <returns>执行结果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeFilter(tipsMode: 3)]
        [ExceptionFilter(tipsMode: 3)]
        public string GetSyncData(FormCollection form)
        {     
            var stateInfo = GeneralHandler.StateSuccess;
            if (GetSyncDataByCheck(form, out stateInfo))
            {
                string txtSetCode = form["txtSetCode"] as string;
                string txtSetName = form["txtSetName"] as string;
                int sltSyncItem = TypeHelper.TypeToInt32(form["sltSyncItem"], 2);
                string txtFieldTable = form["txtFieldTable"] as string;
                string txtFieldMark = form["txtFieldMark"] as string;
                string txtFieldName = form["txtFieldName"] as string;
                string txtFieldMemo = form["txtFieldMemo"] as string;
                string txtFieldWhere = form["txtFieldWhere"] as string;
                string txtConnSource = form["txtConnSource"] as string;
                string txtConnData = form["txtConnData"] as string;
                string txtConnUser = form["txtConnUser"] as string;
                string txtConnPwd = form["txtConnPwd"] as string;
                string cmdConn = string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};", txtConnSource, txtConnData, txtConnUser, txtConnPwd);
                System.Text.StringBuilder cmdSql = new System.Text.StringBuilder();
                cmdSql.AppendFormat("select {0},{1}", txtFieldMark, txtFieldName);
                if (txtFieldMemo != "null") cmdSql.AppendFormat(",{0}", txtFieldMemo);
                cmdSql.AppendFormat(" from {0}", txtFieldTable);
                if (txtFieldWhere != "null") cmdSql.AppendFormat(" where {0}", txtFieldWhere);
                try
                {
                    System.Data.DataTable dt = DawnXZ.DBUtility.SqlHelper.ExecuteDataset(cmdConn, cmdSql.ToString()).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        Session["ExtentSyncData"] = dt;//存入会话中，以供直接使用
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        foreach (System.Data.DataRow dr in dt.Rows)
                        {
                            sb.Append("<tr>");
                            sb.AppendFormat("<td class=\"per15\">{0}</td>", txtSetCode);
                            sb.AppendFormat("<td class=\"per20\">{0}</td>", txtSetName);
                            sb.AppendFormat("<td class=\"per15\">{0}</td>", dr[txtFieldMark]);
                            sb.AppendFormat("<td class=\"per20\">{0}</td>", dr[txtFieldName]);
                            if (txtFieldMemo != "null") sb.AppendFormat("<td class=\"per15\">{0}</td>", dr[txtFieldMemo]);
                            sb.Append("</tr>");
                        }
                        sb.AppendFormat("<tr><td colspan=\"5\"><span class=\"color-blue f14 margin-left-10\">共获取数据：{0}条。</span></td></tr>", dt.Rows.Count);
                        stateInfo = sb.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Session["ExtentSyncData"] = null;
                    stateInfo = string.Format("<tr><td colspan=\"5\"><span class=\"color-red f14 margin-left-10\">{0}</span></td></tr>", ex.Message);
                    GeneralHandler.InsertByError(ex);
                }
            }
            else
            {
                Session["ExtentSyncData"] = null;
                System.Text.StringBuilder sbInfo = new System.Text.StringBuilder();
                sbInfo.Append("<tr><td colspan=\"5\"><span class=\"color-red f14 margin-left-10\">");
                sbInfo.Append(stateInfo);
                sbInfo.Append("</span></td></tr>");
                stateInfo = sbInfo.ToString();
            }
            return stateInfo;
        }

        #endregion

        #region 数据检测

        /// <summary>
        /// 权限扩展获取同步数据
        /// <para>数据检测</para>
        /// </summary>
        /// <param name="form">数据表单</param>
        /// <param name="stateInfo">状态消息</param>
        /// <returns>执行结果</returns>
        private bool GetSyncDataByCheck(FormCollection form, out string stateInfo)
        {
            stateInfo = GeneralHandler.StateSuccess;
            //扩展设定：扩展编码
            string txtSetCode = form["txtSetCode"] as string;
            if ((txtSetCode.Length > 0 && !ValidHelper.EngIsEngAndNum(txtSetCode)) || txtSetCode.Length > 100)
            {
                stateInfo = "您输入的[扩展设定：扩展编码]不正确！（只能由字母和数字组成，且不大于100个字）";
                return false;
            }
            if (ValidHelper.IsSqlFilter(txtSetCode))
            {
                stateInfo = "您输入的[扩展设定：扩展编码]存在安全问题，请检查后重试！";
                return false;
            }
            //扩展设定：编码名称
            string txtSetName = form["txtSetName"] as string;
            if (string.IsNullOrEmpty(txtSetName) || txtSetName.Length < 2 || txtSetName.Length > 200)
            {
                stateInfo = "[扩展设定：编码名称]不能为空或小于2个或大于200个字符！";
                return false;
            }
            if (!ValidHelper.ChsIsChineseOrEngOrNum(txtSetName))
            {
                stateInfo = "您输入的[扩展设定：编码名称]不正确！（只能由汉字、字母、数字组成）";
                return false;
            }
            if (ValidHelper.IsSqlFilter(txtSetName))
            {
                stateInfo = "您输入的[扩展设定：编码名称]存在安全问题，请检查后重试！";
                return false;
            }
            //字段名称：数据表名
            string txtFieldTable = form["txtFieldTable"] as string;
            if (string.IsNullOrWhiteSpace(txtFieldTable))
            {
                stateInfo = "[字段名称：数据表名]不能为空！";
                return false;
            }
            if (ValidHelper.IsSqlFilter(txtFieldTable))
            {
                stateInfo = "您输入的[字段名称：数据表名]存在安全问题，请检查后重试！";
                return false;
            }
            //字段名称：扩展标识
            string txtFieldMark = form["txtFieldMark"] as string;
            if (string.IsNullOrWhiteSpace(txtFieldMark))
            {
                stateInfo = "[字段名称：扩展标识]不能为空！";
                return false;
            }
            if (ValidHelper.IsSqlFilter(txtFieldMark))
            {
                stateInfo = "您输入的[字段名称：扩展标识]存在安全问题，请检查后重试！";
                return false;
            }
            //字段名称：标识名称
            string txtFieldName = form["txtFieldName"] as string;
            if (string.IsNullOrWhiteSpace(txtFieldName))
            {
                stateInfo = "[字段名称：标识名称]不能为空！";
                return false;
            }
            if (ValidHelper.IsSqlFilter(txtFieldName))
            {
                stateInfo = "您输入的[字段名称：标识名称]存在安全问题，请检查后重试！";
                return false;
            }
            //字段名称：扩展备注
            string txtFieldMemo = form["txtFieldMemo"] as string;
            if (string.IsNullOrWhiteSpace(txtFieldMemo))
            {
                stateInfo = "[字段名称：扩展备注]不能为空！";
                return false;
            }
            if (ValidHelper.IsSqlFilter(txtFieldMemo))
            {
                stateInfo = "您输入的[字段名称：扩展备注]存在安全问题，请检查后重试！";
                return false;
            }
            //字段名称：查询条件
            string txtFieldWhere = form["txtFieldWhere"] as string;
            if (string.IsNullOrWhiteSpace(txtFieldWhere))
            {
                stateInfo = "[字段名称：查询条件]不能为空！";
                return false;
            }
            if (ValidHelper.IsSqlInjectionOfString(txtFieldWhere) || ValidHelper.IsSqlInjectionOfType(txtFieldWhere))
            {
                stateInfo = "您输入的[字段名称：查询条件]存在安全问题，请检查后重试！";
                return false;
            }
            //连接属性：数据源
            string txtConnSource = form["txtConnSource"] as string;
            if (string.IsNullOrWhiteSpace(txtConnSource))
            {
                stateInfo = "[连接属性：数据源]不能为空！";
                return false;
            }
            if (txtConnSource != "(local)" && ValidHelper.IsSqlFilter(txtConnSource))
            {
                stateInfo = "您输入的[连接属性：数据源]存在安全问题，请检查后重试！";
                return false;
            }
            //连接属性：数据库名
            string txtConnData = form["txtConnData"] as string;
            if (string.IsNullOrWhiteSpace(txtConnData))
            {
                stateInfo = "[连接属性：数据库名]不能为空！";
                return false;
            }
            if (ValidHelper.IsSqlFilter(txtConnData))
            {
                stateInfo = "您输入的[连接属性：数据库名]存在安全问题，请检查后重试！";
                return false;
            }
            //连接属性：用户名称
            string txtConnUser = form["txtConnUser"] as string;
            if (string.IsNullOrWhiteSpace(txtConnUser))
            {
                stateInfo = "[连接属性：用户名称]不能为空！";
                return false;
            }
            if (ValidHelper.IsSqlFilter(txtConnUser))
            {
                stateInfo = "您输入的[连接属性：用户名称]存在安全问题，请检查后重试！";
                return false;
            }
            //连接属性：用户密码
            string txtConnPwd = form["txtConnPwd"] as string;
            if (string.IsNullOrWhiteSpace(txtConnPwd))
            {
                stateInfo = "[连接属性：用户密码]不能为空！";
                return false;
            }
            if (ValidHelper.IsSqlFilter(txtConnPwd))
            {
                stateInfo = "您输入的[连接属性：用户密码]存在安全问题，请检查后重试！";
                return false;
            }
            return true;
        }

        #endregion

        #endregion

    }
}
