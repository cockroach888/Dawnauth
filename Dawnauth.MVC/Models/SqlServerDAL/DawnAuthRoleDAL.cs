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

        #region 构造函数

        /// <summary>
        /// 数据层实例化
        /// </summary>
        public DawnAuthRoleDAL()
        { }

        #endregion

        #region -----------实例化接口函数-----------

        #region 添加

        /// <summary>
        /// 向数据表DawnAuthRole中插入一条新记录
        /// </summary>
        /// <param name="dawnAuthRole">DawnAuthRole实体对象</param>
        /// <returns></returns>
        public int Insert(DawnAuthRoleMDL dawnAuthRole)
        {
            string sqlCommand = "DawnAuthRoleInsert";
            int res;
            SqlParameter[] param ={
				new SqlParameter("@RoleId",SqlDbType.Int),
				new SqlParameter("@RoleTime",SqlDbType.DateTime),
				new SqlParameter("@RoleName",SqlDbType.NVarChar,50),
				new SqlParameter("@RoleCode",SqlDbType.VarChar,50),
				new SqlParameter("@RoleAuthority",SqlDbType.VarChar,-1),
				new SqlParameter("@RoleDesc",SqlDbType.NVarChar,300),
				new SqlParameter("@RoleFieldOne",SqlDbType.Int),
				new SqlParameter("@RoleFieldTwo",SqlDbType.TinyInt),
				new SqlParameter("@RoleFieldThree",SqlDbType.VarChar,50)
			};
            param[0].Direction = ParameterDirection.Output;
            param[1].Value = dawnAuthRole.RoleTime;
            param[2].Value = dawnAuthRole.RoleName;
            param[3].Value = dawnAuthRole.RoleCode;
            param[4].Value = dawnAuthRole.RoleAuthority;
            param[5].Value = dawnAuthRole.RoleDesc;
            param[6].Value = dawnAuthRole.RoleFieldOne;
            param[7].Value = dawnAuthRole.RoleFieldTwo;
            param[8].Value = dawnAuthRole.RoleFieldThree;
            res = SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
            dawnAuthRole.RoleId = ((param[0].Value) == DBNull.Value) ? 0 : Convert.ToInt32(param[0].Value);
            return res;
        }
        /// <summary>
        /// 向数据表DawnAuthRole中插入一条新记录。带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="dawnAuthRole">DawnAuthRole实体对象</param>
        /// <returns></returns>
        public int Insert(SqlTransaction sp, DawnAuthRoleMDL dawnAuthRole)
        {
            string sqlCommand = "DawnAuthRoleInsert";
            int res;
            SqlParameter[] param ={
				new SqlParameter("@RoleId",SqlDbType.Int),
				new SqlParameter("@RoleTime",SqlDbType.DateTime),
				new SqlParameter("@RoleName",SqlDbType.NVarChar,50),
				new SqlParameter("@RoleCode",SqlDbType.VarChar,50),
				new SqlParameter("@RoleAuthority",SqlDbType.VarChar,-1),
				new SqlParameter("@RoleDesc",SqlDbType.NVarChar,300),
				new SqlParameter("@RoleFieldOne",SqlDbType.Int),
				new SqlParameter("@RoleFieldTwo",SqlDbType.TinyInt),
				new SqlParameter("@RoleFieldThree",SqlDbType.VarChar,50)
			};
            param[0].Direction = ParameterDirection.Output;
            param[1].Value = dawnAuthRole.RoleTime;
            param[2].Value = dawnAuthRole.RoleName;
            param[3].Value = dawnAuthRole.RoleCode;
            param[4].Value = dawnAuthRole.RoleAuthority;
            param[5].Value = dawnAuthRole.RoleDesc;
            param[6].Value = dawnAuthRole.RoleFieldOne;
            param[7].Value = dawnAuthRole.RoleFieldTwo;
            param[8].Value = dawnAuthRole.RoleFieldThree;
            res = SqlHelper.ExecuteNonQuery(sp, CommandType.StoredProcedure, sqlCommand, param);
            dawnAuthRole.RoleId = ((param[0].Value) == DBNull.Value) ? 0 : Convert.ToInt32(param[0].Value);
            return res;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表DawnAuthRole修改一条记录
        /// </summary>
        /// <param name="dawnAuthRole">dawnAuthRole实体对象</param>
        /// <returns></returns>
        public int Update(DawnAuthRoleMDL dawnAuthRole)
        {
            string sqlCommand = "DawnAuthRoleUpdate";
            SqlParameter[] param ={
				new SqlParameter("@RoleId",SqlDbType.Int),
				new SqlParameter("@RoleTime",SqlDbType.DateTime),
				new SqlParameter("@RoleName",SqlDbType.NVarChar,50),
				new SqlParameter("@RoleCode",SqlDbType.VarChar,50),
				new SqlParameter("@RoleAuthority",SqlDbType.VarChar,-1),
				new SqlParameter("@RoleDesc",SqlDbType.NVarChar,300),
				new SqlParameter("@RoleFieldOne",SqlDbType.Int),
				new SqlParameter("@RoleFieldTwo",SqlDbType.TinyInt),
				new SqlParameter("@RoleFieldThree",SqlDbType.VarChar,50)
			};
            param[0].Value = dawnAuthRole.RoleId;
            param[1].Value = dawnAuthRole.RoleTime;
            param[2].Value = dawnAuthRole.RoleName;
            param[3].Value = dawnAuthRole.RoleCode;
            param[4].Value = dawnAuthRole.RoleAuthority;
            param[5].Value = dawnAuthRole.RoleDesc;
            param[6].Value = dawnAuthRole.RoleFieldOne;
            param[7].Value = dawnAuthRole.RoleFieldTwo;
            param[8].Value = dawnAuthRole.RoleFieldThree;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }
        /// <summary>
        /// 向数据表DawnAuthRole修改一条记录。带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="dawnAuthRole">dawnAuthRole实体对象</param>
        /// <returns></returns>
        public int Update(SqlTransaction sp, DawnAuthRoleMDL dawnAuthRole)
        {
            string sqlCommand = "DawnAuthRoleUpdate";
            SqlParameter[] param ={
				new SqlParameter("@RoleId",SqlDbType.Int),
				new SqlParameter("@RoleTime",SqlDbType.DateTime),
				new SqlParameter("@RoleName",SqlDbType.NVarChar,50),
				new SqlParameter("@RoleCode",SqlDbType.VarChar,50),
				new SqlParameter("@RoleAuthority",SqlDbType.VarChar,-1),
				new SqlParameter("@RoleDesc",SqlDbType.NVarChar,300),
				new SqlParameter("@RoleFieldOne",SqlDbType.Int),
				new SqlParameter("@RoleFieldTwo",SqlDbType.TinyInt),
				new SqlParameter("@RoleFieldThree",SqlDbType.VarChar,50)
			};
            param[0].Value = dawnAuthRole.RoleId;
            param[1].Value = dawnAuthRole.RoleTime;
            param[2].Value = dawnAuthRole.RoleName;
            param[3].Value = dawnAuthRole.RoleCode;
            param[4].Value = dawnAuthRole.RoleAuthority;
            param[5].Value = dawnAuthRole.RoleDesc;
            param[6].Value = dawnAuthRole.RoleFieldOne;
            param[7].Value = dawnAuthRole.RoleFieldTwo;
            param[8].Value = dawnAuthRole.RoleFieldThree;
            return SqlHelper.ExecuteNonQuery(sp, CommandType.StoredProcedure, sqlCommand, param);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表DawnAuthRole中的一条记录
        /// </summary>
        /// <param name="roleId">系统编号</param>
        /// <returns></returns>
        public int Delete(int roleId)
        {
            string sqlCommand = "DawnAuthRoleDelete";
            SqlParameter[] param ={
				new SqlParameter("@RoleId",SqlDbType.Int)
			};
            param[0].Value = roleId;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }
        /// <summary>
        /// 删除数据表DawnAuthRole中的一条记录
        /// </summary>
        /// <param name="dawnAuthRole">dawnAuthRole实体对象</param>
        /// <returns></returns>
        public int Delete(DawnAuthRoleMDL dawnAuthRole)
        {
            string sqlCommand = "DawnAuthRoleDelete";
            SqlParameter[] param ={
				new SqlParameter("@RoleId",SqlDbType.Int)
			};
            param[0].Value = dawnAuthRole.RoleId;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }
        /// <summary>
        /// 删除数据表DawnAuthRole中的一条记录,带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="roleId">系统编号</param>
        /// <returns></returns>
        public int Delete(SqlTransaction sp, int roleId)
        {
            string sqlCommand = "DawnAuthRoleDelete";
            SqlParameter[] param ={
				new SqlParameter("@RoleId",SqlDbType.Int)
			};
            param[0].Value = roleId;
            return SqlHelper.ExecuteNonQuery(sp, CommandType.StoredProcedure, sqlCommand, param);
        }

        /// <summary>
        /// 删除数据表DawnAuthRole中的一条记录,带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="dawnAuthRole">dawnAuthRole实体对象</param>
        /// <returns></returns>
        public int Delete(SqlTransaction sp, DawnAuthRoleMDL dawnAuthRole)
        {
            string sqlCommand = "DawnAuthRoleDelete";
            SqlParameter[] param ={
				new SqlParameter("@RoleId",SqlDbType.Int)
			};
            param[0].Value = dawnAuthRole.RoleId;
            return SqlHelper.ExecuteNonQuery(sp, CommandType.StoredProcedure, sqlCommand, param);
        }
        /// <summary>
        /// 根据指定条件删除数据表DawnAuthRole中的记录
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        public int DeleteWhere(string where)
        {
            if (string.IsNullOrEmpty(where)) return -1;
            string sqlCommand = "DawnAuthRoleDeleteWhere";
            SqlParameter[] param ={
            	new SqlParameter("@where",SqlDbType.VarChar,8000)
            };
            param[0].Value = where;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }

        #endregion

        #region 实体对象

        /// <summary>
        /// 得到DawnAuthRole实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>DawnAuthRole实体对象</returns>
        public DawnAuthRoleMDL Select(DataRow row)
        {
            DawnAuthRoleMDL obj = new DawnAuthRoleMDL();
            if (row != null)
            {
                try
                {
                    obj.RoleId = ((row["role_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["role_id"]);
                }
                catch { }
                try
                {
                    obj.RoleTime = ((row["role_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["role_time"]);
                }
                catch { }
                try
                {
                    obj.RoleName = row["role_name"].ToString();
                }
                catch { }
                try
                {
                    obj.RoleCode = row["role_code"].ToString();
                }
                catch { }
                try
                {
                    obj.RoleAuthority = row["role_authority"].ToString();
                }
                catch { }
                try
                {
                    obj.RoleDesc = row["role_desc"].ToString();
                }
                catch { }
                try
                {
                    obj.RoleFieldOne = ((row["role_field_one"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["role_field_one"]);
                }
                catch { }
                try
                {
                    obj.RoleFieldTwo = ((row["role_field_two"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(row["role_field_two"]);
                }
                catch { }
                try
                {
                    obj.RoleFieldThree = row["role_field_three"].ToString();
                }
                catch { }
            }
            else
            {
                return null;
            }
            return obj;
        }
        /// <summary>
        /// 得到DawnAuthRole实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>DawnAuthRoles实体对象</returns>
        public DawnAuthRoleMDL Select(IDataReader dr)
        {
            DawnAuthRoleMDL obj = new DawnAuthRoleMDL();
            try
            {
                obj.RoleId = ((dr["role_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["role_id"]);
            }
            catch { }
            try
            {
                obj.RoleTime = ((dr["role_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["role_time"]);
            }
            catch { }
            try
            {
                obj.RoleName = dr["role_name"].ToString();
            }
            catch { }
            try
            {
                obj.RoleCode = dr["role_code"].ToString();
            }
            catch { }
            try
            {
                obj.RoleAuthority = dr["role_authority"].ToString();
            }
            catch { }
            try
            {
                obj.RoleDesc = dr["role_desc"].ToString();
            }
            catch { }
            try
            {
                obj.RoleFieldOne = ((dr["role_field_one"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["role_field_one"]);
            }
            catch { }
            try
            {
                obj.RoleFieldTwo = ((dr["role_field_two"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(dr["role_field_two"]);
            }
            catch { }
            try
            {
                obj.RoleFieldThree = dr["role_field_three"].ToString();
            }
            catch { }
            return obj;
        }
        /// <summary>
        /// 根据ID,返回一个DawnAuthRole实体对象
        /// </summary>
        /// <param name="roleId">系统编号</param>
        /// <returns>DawnAuthRole实体对象</returns>
        public DawnAuthRoleMDL Select(int roleId)
        {
            DawnAuthRoleMDL obj = null;
            SqlParameter[] param ={
			new SqlParameter("@RoleId",SqlDbType.Int)
			};
            param[0].Value = roleId;
            string sqlCommand = "DawnAuthRoleSelect";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param))
            {
                while (dr.Read())
                {
                    obj = this.Select(dr);
                }
            }
            return obj;
        }

        #endregion

        #region 查询

        #region List

        /// <summary>
        /// 得到数据表DawnAuthRole所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public List<DawnAuthRoleMDL> LSelect()
        {
            return this.LSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表DawnAuthRole满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public List<DawnAuthRoleMDL> LSelect(string where)
        {
            return this.LSelect(where, " [role_id] DESC ");
        }
        /// <summary>
        /// 得到数据表DawnAuthRole满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<DawnAuthRoleMDL> LSelect(string where, string sortField)
        {
            List<DawnAuthRoleMDL> list = new List<DawnAuthRoleMDL>();
            SqlParameter[] param ={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
            param[0].Value = where;
            param[1].Value = sortField;
            string sqlCommand = "DawnAuthRoleSelectByParams";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 得到数据表DawnAuthRole满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public List<DawnAuthRoleMDL> LSelect(CommandType commandType, string sqlCommand, params SqlParameter[] param)
        {
            List<DawnAuthRoleMDL> list = new List<DawnAuthRoleMDL>();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, commandType, sqlCommand, param))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }

        #endregion

        #region IList

        /// <summary>
        /// 得到数据表DawnAuthRole所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList<DawnAuthRoleMDL> ISelect()
        {
            return this.ISelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表DawnAuthRole满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public IList<DawnAuthRoleMDL> ISelect(string where)
        {
            return this.ISelect(where, " [role_id] DESC ");
        }
        /// <summary>
        /// 得到数据表DawnAuthRole满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<DawnAuthRoleMDL> ISelect(string where, string sortField)
        {
            IList<DawnAuthRoleMDL> list = new List<DawnAuthRoleMDL>();
            SqlParameter[] param ={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
            param[0].Value = where;
            param[1].Value = sortField;
            string sqlCommand = "DawnAuthRoleSelectByParams";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 得到数据表DawnAuthRole满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public IList<DawnAuthRoleMDL> ISelect(CommandType commandType, string sqlCommand, params SqlParameter[] param)
        {
            IList<DawnAuthRoleMDL> list = new List<DawnAuthRoleMDL>();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, commandType, sqlCommand, param))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }

        #endregion

        /// <summary>
        /// 得到数据表DawnAuthRole满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public void Select(string where, out int recordCount)
        {
            string sqlCommand = "DawnAuthRoleCountByWhere";
            SqlParameter[] param ={
			new SqlParameter("@where",SqlDbType.VarChar,8000),
			new SqlParameter("@recordCount",SqlDbType.Int)
			};
            param[0].Value = where;
            param[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
            recordCount = Convert.ToInt32(param[1].Value);
        }
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="roleId">系统编号</param>
        /// <returns>存在/不存在</returns>
        public bool Exists(int roleId)
        {
            SqlParameter[] param ={
            	new SqlParameter("@RoleId",SqlDbType.Int)
            };
            param[0].Value = roleId;
            string sqlCommand = "DawnAuthRoleIsExist";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
        public bool Exists(string where)
        {
            if (string.IsNullOrEmpty(where)) return false;
            SqlParameter[] param ={
            	new SqlParameter("@where",SqlDbType.VarChar,8000)
            };
            param[0].Value = where;
            string sqlCommand = "DawnAuthRoleIsExistByWhere";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }

        #endregion

        #region 按指定条件分页查询数据（仅用于主键排序）

        /// <summary>
        /// 通过指定条件分页查询数据（仅用于主键排序）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strWhere">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPinPK(int pageSize, int pageIndex, string strWhere, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPinPK("dawn_auth_role", "*", -1, pageSize, pageIndex, strWhere, "role_id", "role_id desc", 1, out pageCount, out RecordCount, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（仅用于主键排序）
        /// </summary>
        /// <param name="intTop">最多读取记录数</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strWhere">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPinPK(int intTop, int pageSize, int pageIndex, string strWhere, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPinPK("dawn_auth_role", "*", intTop, pageSize, pageIndex, strWhere, "role_id", "role_id desc", 1, out pageCount, out RecordCount, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（仅用于主键排序）
        /// </summary>
        /// <param name="strField">要查询出的字段列表,*表示全部字段</param>
        /// <param name="intTop">最多读取记录数</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strWhere">查询条件,不需where</param>
        /// <param name="strSortField">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="strOrderBy">排序,0-顺序,1-倒序</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPinPK(string strField, int intTop, int pageSize, int pageIndex, string strWhere, string strSortField, byte strOrderBy, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPinPK("dawn_auth_role", strField, intTop, pageSize, pageIndex, strWhere, "role_id", strSortField, strOrderBy, out pageCount, out RecordCount, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（仅用于主键排序）
        /// </summary>
        /// <param name="strTable">要显示的表或多个表的连接</param>
        /// <param name="strField">要查询出的字段列表,*表示全部字段</param>
        /// <param name="intTop">最多读取记录数</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strWhere">查询条件,不需where</param>
        /// <param name="strSortKey">用于排序的主键</param>
        /// <param name="strSortField">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="strOrderBy">排序,0-顺序,1-倒序</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <param name="UsedTime">耗时测试时间差</param>
        /// <param name="strSql">生成的完整SQL语句</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPinPK(string strTable, string strField, int intTop, int pageSize, int pageIndex, string strWhere, string strSortKey, string strSortField, byte strOrderBy, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            List<DawnAuthRoleMDL> list = new List<DawnAuthRoleMDL>();
            string sqlCommand = "ThePSPInPrimaryKey";
            SqlParameter[] param ={
                                      new SqlParameter("@strTable",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@strField",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@intTop",SqlDbType.Int),
                                      new SqlParameter("@pageSize",SqlDbType.Int),
                                      new SqlParameter("@pageIndex",SqlDbType.Int),
                                      new SqlParameter("@strWhere",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@strSortKey",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@strSortField",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@strOrderBy",SqlDbType.Bit),
                                      new SqlParameter("@pageCount",SqlDbType.Int),
                                      new SqlParameter("@RecordCount",SqlDbType.Int),
                                      new SqlParameter("@UsedTime",SqlDbType.Int),
                                      new SqlParameter("@strSql",SqlDbType.NVarChar,-1)
                                  };
            param[0].Value = strTable;
            param[1].Value = strField;
            param[2].Value = intTop;
            param[3].Value = pageSize;
            param[4].Value = pageIndex;
            param[5].Value = strWhere;
            param[6].Value = strSortKey;
            param[7].Value = strSortField;
            param[8].Value = strOrderBy;
            param[9].Direction = ParameterDirection.Output;
            param[10].Direction = ParameterDirection.Output;
            param[11].Direction = ParameterDirection.Output;
            param[12].Direction = ParameterDirection.Output;
            using (DataSet ds = SqlHelper.ExecuteDataset(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param))
            {
                foreach (DataTable dt in ds.Tables)
                {
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        list.Add(this.Select(dt.Rows[intCount]));
                    }
                }
            }
            pageCount = Convert.ToInt32(param[9].Value);
            RecordCount = Convert.ToInt32(param[10].Value);
            UsedTime = Convert.ToInt32(param[11].Value);
            strSql = Convert.ToString(param[12].Value);
            return list;
        }

        #endregion 按指定条件分页查询数据（仅用于主键排序）

        #region 按指定条件分页查询数据（通用排序方式）

        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurpose(int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurpose("dawn_auth_role", "*", pageSize, page, "role_time desc,role_id", 1, strCondition, "role_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式）
        /// </summary>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurpose(string fldName, int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurpose("dawn_auth_role", fldName, pageSize, page, "role_time desc,role_id", 1, strCondition, "role_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式）
        /// </summary>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="Sort">排序方法，0为升序，1为降序(如果是多字段排列Sort指代最后一个排序字段的排列顺序(最后一个排序字段不加排序标记)--程序传参如：' SortA Asc,SortB Desc,SortC ')</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="Dist">是否添加查询字段的 DISTINCT 默认0不添加/1添加（去掉重复值）</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurpose(string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, byte Dist, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurpose("dawn_auth_role", fldName, pageSize, page, fldSort, Sort, strCondition, "role_id", Dist, out pageCount, out Counts, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式）
        /// </summary>
        /// <param name="tblName">要显示的表或多个表的连接</param>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="Sort">排序方法，0为升序，1为降序(如果是多字段排列Sort指代最后一个排序字段的排列顺序(最后一个排序字段不加排序标记)--程序传参如：' SortA Asc,SortB Desc,SortC ')</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="ID">主表的主键</param>
        /// <param name="Dist">是否添加查询字段的 DISTINCT 默认0不添加/1添加（去掉重复值）</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <param name="UsedTime">耗时测试时间差</param>
        /// <param name="strSql">生成的完整SQL语句</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurpose(string tblName, string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, string ID, byte Dist, out int pageCount, out int Counts, out int UsedTime, out string strSql)
        {
            List<DawnAuthRoleMDL> list = new List<DawnAuthRoleMDL>();
            string sqlCommand = "ThePSPIsAllPurpose";
            SqlParameter[] param ={
                                      new SqlParameter("@tblName",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@fldName",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@pageSize",SqlDbType.Int),
                                      new SqlParameter("@page",SqlDbType.Int),
                                      new SqlParameter("@fldSort",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@Sort",SqlDbType.Bit),
                                      new SqlParameter("@strCondition",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@ID",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@Dist",SqlDbType.Bit),
                                      new SqlParameter("@pageCount",SqlDbType.Int),
                                      new SqlParameter("@Counts",SqlDbType.Int),
                                      new SqlParameter("@UsedTime",SqlDbType.Int),
                                      new SqlParameter("@strSql",SqlDbType.NVarChar,-1)
                                  };
            param[0].Value = tblName;
            param[1].Value = fldName;
            param[2].Value = pageSize;
            param[3].Value = page;
            param[4].Value = fldSort;
            param[5].Value = Sort;
            param[6].Value = strCondition;
            param[7].Value = ID;
            param[8].Value = Dist;
            param[9].Direction = ParameterDirection.Output;
            param[10].Direction = ParameterDirection.Output;
            param[11].Direction = ParameterDirection.Output;
            param[12].Direction = ParameterDirection.Output;
            using (DataSet ds = SqlHelper.ExecuteDataset(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param))
            {
                foreach (DataTable dt in ds.Tables)
                {
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        list.Add(this.Select(dt.Rows[intCount]));
                    }
                }
            }
            pageCount = Convert.ToInt32(param[9].Value);
            Counts = Convert.ToInt32(param[10].Value);
            UsedTime = Convert.ToInt32(param[11].Value);
            strSql = Convert.ToString(param[12].Value);
            return list;
        }

        #endregion 按指定条件分页查询数据（通用排序方式）

        #region 按指定条件分页查询数据（通用排序方式·NotIn）

        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·NotIn）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurposeNotIn(int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeNotIn("dawn_auth_role", "*", pageSize, page, "role_time desc,role_id", 0, strCondition, "role_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·NotIn）
        /// </summary>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurposeNotIn(string fldName, int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeNotIn("dawn_auth_role", fldName, pageSize, page, "role_time desc,role_id", 0, strCondition, "role_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·NotIn）
        /// </summary>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="Sort">排序方法，0为升序，1为降序(如果是多字段排列Sort指代最后一个排序字段的排列顺序(最后一个排序字段不加排序标记)--程序传参如：' SortA Asc,SortB Desc,SortC ')</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="Dist">是否添加查询字段的 DISTINCT 默认0不添加/1添加（去掉重复值）</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurposeNotIn(string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, byte Dist, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeNotIn("dawn_auth_role", fldName, pageSize, page, fldSort, Sort, strCondition, "role_id", Dist, out pageCount, out Counts, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·NotIn）
        /// </summary>
        /// <param name="tblName">要显示的表或多个表的连接</param>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="Sort">排序方法，0为升序，1为降序(如果是多字段排列Sort指代最后一个排序字段的排列顺序(最后一个排序字段不加排序标记)--程序传参如：' SortA Asc,SortB Desc,SortC ')</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="ID">主表的主键</param>
        /// <param name="Dist">是否添加查询字段的 DISTINCT 默认0不添加/1添加（去掉重复值）</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <param name="UsedTime">耗时测试时间差</param>
        /// <param name="strSql">生成的完整SQL语句</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurposeNotIn(string tblName, string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, string ID, byte Dist, out int pageCount, out int Counts, out int UsedTime, out string strSql)
        {
            List<DawnAuthRoleMDL> list = new List<DawnAuthRoleMDL>();
            string sqlCommand = "ThePSPIsAllPurposeNotIn";
            SqlParameter[] param ={
                                      new SqlParameter("@tblName",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@fldName",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@pageSize",SqlDbType.Int),
                                      new SqlParameter("@page",SqlDbType.Int),
                                      new SqlParameter("@fldSort",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@Sort",SqlDbType.Bit),
                                      new SqlParameter("@strCondition",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@ID",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@Dist",SqlDbType.Bit),
                                      new SqlParameter("@pageCount",SqlDbType.Int),
                                      new SqlParameter("@Counts",SqlDbType.Int),
                                      new SqlParameter("@UsedTime",SqlDbType.Int),
                                      new SqlParameter("@strSql",SqlDbType.NVarChar,-1)
                                  };
            param[0].Value = tblName;
            param[1].Value = fldName;
            param[2].Value = pageSize;
            param[3].Value = page;
            param[4].Value = fldSort;
            param[5].Value = Sort;
            param[6].Value = strCondition;
            param[7].Value = ID;
            param[8].Value = Dist;
            param[9].Direction = ParameterDirection.Output;
            param[10].Direction = ParameterDirection.Output;
            param[11].Direction = ParameterDirection.Output;
            param[12].Direction = ParameterDirection.Output;
            using (DataSet ds = SqlHelper.ExecuteDataset(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param))
            {
                foreach (DataTable dt in ds.Tables)
                {
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        list.Add(this.Select(dt.Rows[intCount]));
                    }
                }
            }
            pageCount = Convert.ToInt32(param[9].Value);
            Counts = Convert.ToInt32(param[10].Value);
            UsedTime = Convert.ToInt32(param[11].Value);
            strSql = Convert.ToString(param[12].Value);
            return list;
        }

        #endregion 按指定条件分页查询数据（通用排序方式·NotIn）

        #region 按指定条件分页查询数据（通用排序方式·ROW_NUMBER）

        #region 不输出SQL执行语句和执行时间

        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_role", "*", pageSize, pageIndex, "role_time desc", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="strCondition">查询条件,不需where</param>        
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_role", "*", pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_role", fldName, pageSize, pageIndex, "role_time desc", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_role", fldName, pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
        }

        #endregion

        #region 输出SQL执行语句和执行时间

        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <param name="UsedTime">耗时测试时间差</param>
        /// <param name="strSql">生成的完整SQL语句</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_role", "*", pageSize, pageIndex, "role_time desc", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="strCondition">查询条件,不需where</param>        
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <param name="UsedTime">耗时测试时间差</param>
        /// <param name="strSql">生成的完整SQL语句</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_role", "*", pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <param name="UsedTime">耗时测试时间差</param>
        /// <param name="strSql">生成的完整SQL语句</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_role", fldName, pageSize, pageIndex, "role_time desc", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <param name="UsedTime">耗时测试时间差</param>
        /// <param name="strSql">生成的完整SQL语句</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_role", fldName, pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
        }

        #endregion

        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="tblName">要显示的表或多个表的连接</param>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <param name="UsedTime">耗时测试时间差</param>
        /// <param name="strSql">生成的完整SQL语句</param>
        /// <returns>DawnAuthRole 结果集</returns>
        public List<DawnAuthRoleMDL> SelectPSPisAllPurposeRowNumber(string tblName, string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            List<DawnAuthRoleMDL> list = new List<DawnAuthRoleMDL>();
            string sqlCommand = "SjjPagination";
            SqlParameter[] param ={
                                      new SqlParameter("@tblName",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@fldName",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@pageSize",SqlDbType.Int),
                                      new SqlParameter("@pageIndex",SqlDbType.Int),
                                      new SqlParameter("@fldSort",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@strCondition",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@pageCount",SqlDbType.Int),
                                      new SqlParameter("@RecordCount",SqlDbType.Int),
                                      new SqlParameter("@UsedTime",SqlDbType.Int),
                                      new SqlParameter("@strSql",SqlDbType.NVarChar,-1)
                                  };
            param[0].Value = tblName;
            param[1].Value = fldName;
            param[2].Value = pageSize;
            param[3].Value = pageIndex;
            param[4].Value = fldSort;
            param[5].Value = strCondition;
            param[6].Direction = ParameterDirection.Output;
            param[7].Direction = ParameterDirection.Output;
            param[8].Direction = ParameterDirection.Output;
            param[9].Direction = ParameterDirection.Output;
            using (DataSet ds = SqlHelper.ExecuteDataset(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param))
            {
                foreach (DataTable dt in ds.Tables)
                {
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        list.Add(this.Select(dt.Rows[intCount]));
                    }
                }
            }
            pageCount = Convert.ToInt32(param[6].Value);
            RecordCount = Convert.ToInt32(param[7].Value);
            UsedTime = Convert.ToInt32(param[8].Value);
            strSql = Convert.ToString(param[9].Value);
            return list;
        }

        #endregion

        #endregion

    }
}
