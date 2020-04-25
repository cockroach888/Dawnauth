// =================================================================== 
// 产品（DawnXZ.Dawnauth.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthExtentDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:36:31
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DawnXZ.DBUtility;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.Dawnauth.IDAL;
using DawnXZ.Dawnauth.BLL;

namespace DawnXZ.Dawnauth.SqlServerDAL
{
    /// <summary>
    /// 数据访问层DawnAuthExtent
    /// </summary>
    public partial class DawnAuthExtentDAL : IDawnAuthExtentDAL
    {

        #region -----------实例化接口函数-----------

        #region 获取扩展编码

        /// <summary>
        /// 获取扩展编码数组
        /// </summary>
        /// <returns>扩展编码数组</returns>
        public DataTable SelectByCodeList()
        {
            string cmdSql = "select distinct exte_code,exte_code_name from dawn_auth_extent";
            return SqlHelper.ExecuteDataset(Conn.SqlConn, cmdSql).Tables[0];
        }

        #endregion

        #endregion

    }
}