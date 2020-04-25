// =================================================================== 
// 产品（DawnXZ.Dawnauth.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthUserPowerDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 20:56:34
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
    /// 数据访问层DawnAuthUserPower
    /// </summary>
    public partial class DawnAuthUserPowerDAL : IDawnAuthUserPowerDAL
    {

        #region -----------实例化接口函数-----------

        #region 修改

        /// <summary>
        /// 向数据表DawnAuthUserPower修改一条记录
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="moduleId">模块编号</param>
        /// <param name="strFunction">功能权限集</param>
        /// <returns>执行结果</returns>
        public int UpdateFunction(int userId, int moduleId, string strFunction)
        {
            string sqlCmd = "update dawn_auth_user_power set map_function=@MapFunction where user_id=@UserId and map_module=@MapModule";
            SqlParameter[] param ={
                new SqlParameter("@UserId",SqlDbType.Int),
                new SqlParameter("@MapModule",SqlDbType.Int),
                new SqlParameter("@MapFunction",SqlDbType.VarChar,-1)
            };
            param[0].Value = userId;
            param[1].Value = moduleId;
            param[2].Value = strFunction;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, sqlCmd, param);
        }

        #endregion

        #endregion

    }
}