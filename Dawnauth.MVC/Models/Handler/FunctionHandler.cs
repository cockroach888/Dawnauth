using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.Dawnauth.BLL;

namespace DawnXZ.Dawnauth.Handler
{
    public class FunctionHandler
    {

        #region 成员方法

        /// <summary>
        /// 是否可删除对象
        /// </summary>
        /// <param name="funId">模块功能编号</param>
        /// <returns>是/否</returns>
        public static bool IfDelete(int funId)
        {
            return !DawnAuthFunctionBLL.Exists(string.Format("fun_parent_mark='{0}'", funId));
        }
        /// <summary>
        /// 隶属功能下拉数据
        /// </summary>
        /// <returns>数据集合</returns>
        public static IList<SelectListItem> GetSelectList()
        {
            var list = new List<SelectListItem>()
            {
                new SelectListItem(){
                    Value = "-1",
                    Text = "--模块访问--"
                },
                new SelectListItem(){
                    Value = "1",
                    Text = "--非模块访问--",
                    Selected = true
                }
            };
            //var dataList = DawnAuthFunctionBLL.ISelect("fun_parent_mark=-1");
            //if (dataList.Count > 0)
            //{
            //    foreach (var item in dataList)
            //    {
            //        SelectListItem sli = new SelectListItem();
            //        sli.Text = item.FunName;
            //        sli.Value = item.FunId.ToString();
            //        if (funId > 0) sli.Selected = item.FunId == funId ? true : false;
            //        list.Add(sli);
            //    }
            //}
            return list;
        }        

        #endregion

    }
}