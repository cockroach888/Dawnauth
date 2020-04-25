// =================================================================== 
// 产品（DawnXZ.Dawnauth.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthModuleDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 20:45:15
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
    /// 数据访问层DawnAuthModule
    /// </summary>
    public partial class DawnAuthModuleDAL : IDawnAuthModuleDAL
    {

        #region -----------实例化接口函数-----------

        #region GetFirstName

        /// <summary>
        /// 获取当前模块父标识名称
        /// </summary>
        /// <param name="mdlId">模块编号</param>
        /// <returns>执行结果</returns>
        public string GetFirstName(int mdlId)
        {
            string cmdSql = "select dbo.fn_recursion_catalog_first(@MdlId)";
            SqlParameter[] param ={
                new SqlParameter("@MdlId",SqlDbType.Int)
            };
            param[0].Value = mdlId;
            return SqlHelper.ExecuteScalar(Conn.SqlConn, cmdSql, param) as string;
        }

        #endregion

        #endregion

    }
}