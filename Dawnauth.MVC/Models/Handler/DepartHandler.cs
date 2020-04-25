using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DawnXZ.Dawnauth.BLL;
using DawnXZ.Dawnauth.Entity;

namespace DawnXZ.Dawnauth.Handler
{
    /// <summary>
    /// 隶属部门处理器
    /// </summary>
    public class DepartHandler
    {

        #region 递归模块信息

        /// <summary>
        /// 递归模块信息·补空格模式
        /// </summary>
        /// <param name="mdlId">模块编号</param>
        /// <returns>数据集合</returns>
        public static IList<SelectListItem> GetSelectList(int mdlId)
        {
            var list = new List<SelectListItem>()
            {
                new SelectListItem(){
                    Value = "-1",
                    Text = "--请选择--"
                }
            };
            var dataList = GetTree();
            if (dataList.Count > 0)
            {
                foreach (var item in dataList)
                {
                    SelectListItem sli = new SelectListItem();
                    sli.Text = item.DptName;
                    sli.Value = item.DptId.ToString();
                    if (mdlId > 0) sli.Selected = item.DptId == mdlId ? true : false;
                    list.Add(sli);
                }
            }
            return list;
        }
        /// <summary>
        /// 递归模块信息·补空格模式
        /// </summary>
        /// <returns>数据集合</returns>
        public static IList<DawnAuthDepartmentMDL> GetTree()
        {
            IList<DawnAuthDepartmentMDL> treeList = new List<DawnAuthDepartmentMDL>();
            IList<DawnAuthDepartmentMDL> rootList = DawnAuthDepartmentBLL.ISelectFather();
            foreach (var item in rootList)
            {
                treeList.Add(item);
                GetTreeNode(treeList, item.DptId, "　");
            }
            return treeList;
        }
        /// <summary>
        /// 递归模块信息·补空格模式
        /// </summary>
        /// <param name="id">模块编号</param>
        /// <returns>数据集合</returns>
        public static IList<DawnAuthDepartmentMDL> GetTree(int id)
        {
            IList<DawnAuthDepartmentMDL> treeList = new List<DawnAuthDepartmentMDL>();
            DawnAuthDepartmentMDL rootInfo = DawnAuthDepartmentBLL.Select(id);
            treeList.Add(rootInfo);
            GetTreeNode(treeList, rootInfo.DptId, "　");
            return treeList;
        }
        /// <summary>
        /// 递归模块信息·子
        /// </summary>
        /// <param name="treeList">树存储器</param>
        /// <param name="fId">父编号</param>
        /// <param name="tbMarker">符号标识</param>
        private static void GetTreeNode(IList<DawnAuthDepartmentMDL> treeList, int fId, string tbMarker)
        {
            IList<DawnAuthDepartmentMDL> nodeList = DawnAuthDepartmentBLL.ISelect(string.Format("dpt_father='{0}'", fId));
            if (nodeList == null || nodeList.Count <= 0) return;
            foreach (DawnAuthDepartmentMDL nodeInfo in nodeList)
            {
                nodeInfo.DptName = tbMarker + nodeInfo.DptName;
                treeList.Add(nodeInfo);
                string strMarker = tbMarker + "　";
                GetTreeNode(treeList, nodeInfo.DptId, strMarker);
            }
        }

        #endregion

    }
}