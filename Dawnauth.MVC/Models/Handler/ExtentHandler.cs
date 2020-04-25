using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.Dawnauth.BLL;

namespace DawnXZ.Dawnauth.Handler
{
    /// <summary>
    /// 权限扩展处理器
    /// </summary>
    public class ExtentHandler
    {

        #region 获得权限扩展编码数据列表

        /// <summary>
        /// 获得权限扩展编码数据列表
        /// </summary>
        /// <returns>数据集合</returns>
        public static IList<SelectListItem> GetSelectList()
        {
            var list = new List<SelectListItem>()
            {
                new SelectListItem(){
                    Value = "-1",
                    Text = "--请选择--"
                }
            };
            var dataList = DawnAuthExtentBLL.SelectByCodeList();
            if (dataList.Rows.Count > 0)
            {
                foreach (DataRow dr in dataList.Rows)
                {
                    SelectListItem sli = new SelectListItem();
                    sli.Text = dr["exte_code_name"].ToString();
                    sli.Value = dr["exte_code"].ToString();
                    list.Add(sli);
                }
            }
            return list;
        }

        #endregion

    }
}