using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.Dawnauth.BLL;
using System.Text;

namespace DawnXZ.Dawnauth.Handler
{
    public class UserHandler
    {

        #region 成员方法
        
        /// <summary>
        /// 管理级别下拉数据
        /// </summary>
        /// <param name="grade">管理级别</param>
        /// <returns>数据集合</returns>
        public static IList<SelectListItem> GetSelectList(int grade)
        {
            var list = new List<SelectListItem>()
            {
                new SelectListItem(){
                    Value = "1",
                    Text = "--普通管理员--"
                },
                new SelectListItem(){
                    Value = "2",
                    Text = "--高级管理员--"
                },
                new SelectListItem(){
                    Value = "3",
                    Text = "--超级管理员--"
                }
            };
            list.Where(p => p.Value == grade.ToString()).First().Selected = true;
            return list;
        }
        /// <summary>
        /// 获取管理员对应的权限扩展值
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="exteCode">扩展编码</param>
        /// <returns>扩展标识字符串</returns>
        public static string GetUserExtent(int userId, string exteCode)
        {
            var dataList = DawnAuthUserExtentBLL.ISelect(string.Format("user_id='{0}' and ext_code='{1}'", userId, exteCode));
            if (dataList == null || dataList.Count < 1) return null;
            StringBuilder sb = new StringBuilder();
            sb.Append("0,");
            foreach (DawnAuthUserExtentMDL item in dataList)
            {
                sb.AppendFormat("{0},", item.ExtMark);
            }
            return sb.ToString();
        }

        #endregion

    }
}