// =================================================================== 
// 产品（DawnXZ.Dawnauth.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthUserDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:36:36
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
    /// 数据访问层DawnAuthUser
    /// </summary>
    internal partial class DawnAuthUserDAL : IDawnAuthUserDAL
    {

        #region -----------实例化接口函数-----------

        #region 取得用户权限字符串

        /// <summary>
        /// 取得用户权限字符串
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>执行结果</returns>
        public string GetUserAuthority(int userId)
        {
            string cmdSql = "select dbo.FunUserAuthority(@UserId)";
            SqlParameter[] param ={
                    new SqlParameter("@UserId",SqlDbType.Int)
                };
            param[0].Value = userId;
            return SqlHelper.ExecuteScalar(Conn.SqlConn, cmdSql, param) as string;
        }

        #endregion

        #region 取得用户状态机制字符串

        /// <summary>
        /// 取得用户状态机制字符串
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>执行结果</returns>
        public string GetUserStatus(int userId)
        {
            string cmdSql = "select dbo.FunUserStatus(@UserId)";
            SqlParameter[] param ={
                    new SqlParameter("@UserId",SqlDbType.Int)
                };
            param[0].Value = userId;
            return SqlHelper.ExecuteScalar(Conn.SqlConn, cmdSql, param) as string;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表DawnAuthUser修改密码
        /// </summary>
        /// <param name="userId">管理员编号</param>
        /// <param name="userPwd">管理员密码</param>
        /// <returns></returns>
        public int Update(int userId, string userPwd)
        {
            string sqlCmd = "update dawn_auth_user set user_pwd=@UserPwd where user_id=@UserId";
            SqlParameter[] param ={
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@UserPwd",SqlDbType.VarChar,32)
			};
            param[0].Value = userId;
            param[1].Value = userPwd;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, sqlCmd, param);
        }

        #endregion

        #region 查询

        /// <summary>
        /// 根据用户名检测是否存在该条记录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>存在/不存在</returns>
        public bool ExistsOfName(string userName)
        {
            string cmdSql = "select count(-1) from dawn_auth_user where user_name=@userName";
            SqlParameter[] param ={
            	new SqlParameter("@userName",SqlDbType.VarChar,16)
            };
            param[0].Value = userName;
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, cmdSql, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }

        #endregion
        
        #endregion

    }
}
