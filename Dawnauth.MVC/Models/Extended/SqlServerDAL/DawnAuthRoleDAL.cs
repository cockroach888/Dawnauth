// =================================================================== 
// 产品（DawnXZ.Dawnauth.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthRoleDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 20:52:26
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
    /// 数据访问层DawnAuthRole
    /// </summary>
    public partial class DawnAuthRoleDAL : IDawnAuthRoleDAL
    {

        #region -----------实例化接口函数-----------

        #region 修改

        /// <summary>
        /// 向数据表DawnAuthRole修改一条记录
        /// </summary>
        /// <param name="roleId">角色编码</param>
        /// <param name="authString">功能字符串</param>
        /// <returns></returns>
        public int Update(string roleCode, string authString)
        {
            string cmdSql = string.Format(@"update dawn_auth_role set role_authority = @RoleAuthority where role_code = @RoleCode");
            SqlParameter[] param ={
                    new SqlParameter("@RoleCode",SqlDbType.VarChar,50),
                    new SqlParameter("@RoleAuthority",SqlDbType.VarChar,-1)
                };
            param[0].Value = roleCode;
            param[1].Value = authString;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, cmdSql, param);
        }
        /// <summary>
        /// 向数据表DawnAuthRole修改一条记录
        /// </summary>
        /// <param name="dawnAuthRole">dawnAuthRole实体对象</param>
        /// <returns></returns>
        public int UpdateEditor(DawnAuthRoleMDL dawnAuthRole)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update dawn_auth_role set ");
            sb.Append("role_name=@RoleName");
            sb.Append(",role_desc=@RoleDesc");
            sb.Append(" where role_id = @RoleId");
            SqlParameter[] param ={
                    new SqlParameter("@RoleId",SqlDbType.Int),
                    new SqlParameter("@RoleName",SqlDbType.NVarChar,50),
                    new SqlParameter("@RoleDesc",SqlDbType.NVarChar,300)
                };
            param[0].Value = dawnAuthRole.RoleId;
            param[1].Value = dawnAuthRole.RoleName;
            param[2].Value = dawnAuthRole.RoleDesc;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, sb.ToString(), param);
        }

        #endregion

        #endregion

    }
}