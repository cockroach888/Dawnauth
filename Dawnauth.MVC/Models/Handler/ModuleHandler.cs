using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.Dawnauth.BLL;

namespace DawnXZ.Dawnauth.Handler
{
    /// <summary>
    /// 模块信息处理器
    /// </summary>
    public class ModuleHandler
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
                    sli.Text = item.MdlName;
                    sli.Value = item.MdlId.ToString();
                    if (mdlId > 0) sli.Selected = item.MdlId == mdlId ? true : false;
                    list.Add(sli);
                }
            }
            return list;
        }
        /// <summary>
        /// 递归模块信息·补空格模式
        /// </summary>
        /// <returns>数据集合</returns>
        public static IList<DawnAuthModuleMDL> GetTree()
        {
            IList<DawnAuthModuleMDL> treeList = new List<DawnAuthModuleMDL>();
            IList<DawnAuthModuleMDL> rootList = DawnAuthModuleBLL.ISelectFather();
            foreach (var item in rootList)
            {
                treeList.Add(item);
                GetTreeNode(treeList, item.MdlId, "　");
            }
            return treeList;
        }
        /// <summary>
        /// 递归模块信息·补空格模式
        /// </summary>
        /// <param name="id">模块编号</param>
        /// <returns>数据集合</returns>
        public static IList<DawnAuthModuleMDL> GetTree(int id)
        {
            IList<DawnAuthModuleMDL> treeList = new List<DawnAuthModuleMDL>();
            DawnAuthModuleMDL rootInfo = DawnAuthModuleBLL.Select(id);
            treeList.Add(rootInfo);
            GetTreeNode(treeList, rootInfo.MdlId, "　");
            return treeList;
        }
        /// <summary>
        /// 递归模块信息·子
        /// </summary>
        /// <param name="treeList">树存储器</param>
        /// <param name="fId">父编号</param>
        /// <param name="tbMarker">符号标识</param>
        private static void GetTreeNode(IList<DawnAuthModuleMDL> treeList, int fId, string tbMarker)
        {
            IList<DawnAuthModuleMDL> nodeList = DawnAuthModuleBLL.ISelect(string.Format("mdl_father='{0}'", fId));
            if (nodeList == null || nodeList.Count <= 0) return;
            foreach (DawnAuthModuleMDL nodeInfo in nodeList)
            {
                nodeInfo.MdlName = tbMarker + nodeInfo.MdlName;
                treeList.Add(nodeInfo);
                string strMarker = tbMarker + "　";
                GetTreeNode(treeList, nodeInfo.MdlId, strMarker);
            }
        }

        #endregion

        #region 权限绑定专用树

        /// <summary>
        /// 递归模块信息·补空格模式
        /// </summary>
        /// <returns>数据集合</returns>
        public static IList<DawnAuthModuleMDL> GetPowerTree()
        {
            IList<DawnAuthModuleMDL> treeList = new List<DawnAuthModuleMDL>();
            IList<DawnAuthModuleMDL> rootList = DawnAuthModuleBLL.ISelect(string.Format("mdl_father = -1 and mdl_ident > 0"));
            foreach (var item in rootList)
            {
                treeList.Add(item);
                GetPowerTreeNode(treeList, item.MdlId, "　");
            }
            return treeList;
        }
        /// <summary>
        /// 递归模块信息·子
        /// </summary>
        /// <param name="treeList">树存储器</param>
        /// <param name="fId">父编号</param>
        /// <param name="tbMarker">符号标识</param>
        private static void GetPowerTreeNode(IList<DawnAuthModuleMDL> treeList, int fId, string tbMarker)
        {
            IList<DawnAuthModuleMDL> nodeList = DawnAuthModuleBLL.ISelect(string.Format("mdl_father='{0}' and mdl_ident > 0", fId));
            if (nodeList == null || nodeList.Count <= 0) return;
            foreach (DawnAuthModuleMDL nodeInfo in nodeList)
            {
                nodeInfo.MdlName = tbMarker + nodeInfo.MdlName;
                treeList.Add(nodeInfo);
                string strMarker = tbMarker + "　";
                GetPowerTreeNode(treeList, nodeInfo.MdlId, strMarker);
            }
        }

        #endregion

        #region 获取父标识名称

        /// <summary>
        /// 获取父标识名称
        /// </summary>
        /// <param name="mdlId">模块编号</param>
        /// <returns>执行结果</returns>
        public static string GetFatherName(int mdlId)
        {
            return DawnAuthModuleBLL.GetFirstName(mdlId);
        }

        #endregion

    }
}