// =================================================================== 
// 产品（DawnXZ.Dawnauth.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthFunctionDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 20:39:28
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
    /// 数据访问层DawnAuthFunction
    /// </summary>
    public partial class DawnAuthFunctionDAL : IDawnAuthFunctionDAL
    {

        #region -----------实例化接口函数-----------

        #region GetMaxId

        /// <summary>
        /// 获取当前最大功能标识编号
        /// </summary>
        /// <param name="mdlId">模块编号</param>
        /// <returns>功能标识编号</returns>
        public int GetMaxFunMark(int mdlId)
        {
            string cmdSql = "select case when max(fun_mark) is null then 0 else max(fun_mark) end from dawn_auth_function where mdl_id=@MdlId";
            SqlParameter[] param ={
                    new SqlParameter("@MdlId",SqlDbType.Int)
                };
            param[0].Value = mdlId;
            int funMark = 0;
            string tmpVal = SqlHelper.ExecuteScalar(Conn.SqlConn, cmdSql, param).ToString();
            int.TryParse(tmpVal, out funMark);
            return funMark;
        }

        #endregion

        #region GetParentMark

        /// <summary>
        /// 获取当前模块内部功能标识
        /// </summary>
        /// <param name="mdlId">模块编号</param>
        /// <returns>内部功能标识</returns>
        public int GetParentMark(int mdlId)
        {
            string cmdSql = "select fun_id from dawn_auth_function where fun_parent_mark=-1 and mdl_id=@MdlId";
            SqlParameter[] param ={
                    new SqlParameter("@MdlId",SqlDbType.Int)
                };
            param[0].Value = mdlId;
            int funMark = 0;
            string tmpVal = SqlHelper.ExecuteScalar(Conn.SqlConn, cmdSql, param).ToString();
            int.TryParse(tmpVal, out funMark);
            return funMark;
        }

        #endregion

        #endregion

    }
}
