// =================================================================== 
// 业务逻辑（DawnXZ.Dawnauth.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthExtentBLL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:36:11
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.Dawnauth.IDAL;
using DawnXZ.Dawnauth.DBFactory;

namespace DawnXZ.Dawnauth.BLL
{
    /// <summary>
    /// 业务逻辑层DawnAuthExtent
    /// </summary>
    public partial class DawnAuthExtentBLL
    {

        #region ---------函数定义-----------

        #region 获取扩展编码

        /// <summary>
        /// 获取扩展编码数组
        /// </summary>
        /// <returns>扩展编码数组</returns>
        public static DataTable SelectByCodeList()
        {
            return DawnAuthExtentBLL._dal.SelectByCodeList();
        }

        #endregion

        #endregion

    }
}