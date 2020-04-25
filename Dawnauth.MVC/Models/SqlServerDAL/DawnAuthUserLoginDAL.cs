// =================================================================== 
// 产品（DawnXZ.Dawnauth.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthUserLoginDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年02月28日 23:29:53
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
    /// 数据访问层DawnAuthUserLogin
    /// </summary>
    public partial class DawnAuthUserLoginDAL : IDawnAuthUserLoginDAL
    {

        #region 构造函数

        /// <summary>
        /// 数据层实例化
        /// </summary>
        public DawnAuthUserLoginDAL()
        { }

        #endregion

        #region -----------实例化接口函数-----------

        #region 添加

        /// <summary>
        /// 向数据表DawnAuthUserLogin中插入一条新记录
        /// </summary>
        /// <param name="dawnAuthUserLogin">DawnAuthUserLogin实体对象</param>
        /// <returns></returns>
        public int Insert(DawnAuthUserLoginMDL dawnAuthUserLogin)
        {
            string sqlCommand = "DawnAuthUserLoginInsert";
            int res;
            SqlParameter[] param ={
				new SqlParameter("@LogId",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@LogTime",SqlDbType.DateTime),
				new SqlParameter("@LogIp",SqlDbType.VarChar,200),
				new SqlParameter("@LogMac",SqlDbType.VarChar,100),
				new SqlParameter("@LogComputer",SqlDbType.VarChar,100),
				new SqlParameter("@LogAttach",SqlDbType.NVarChar,-1),
				new SqlParameter("@LogCount",SqlDbType.Int),
				new SqlParameter("@LogFieldOne",SqlDbType.Int),
				new SqlParameter("@LogFieldTwo",SqlDbType.TinyInt),
				new SqlParameter("@LogFieldThree",SqlDbType.VarChar,-1)
			};
            param[0].Direction = ParameterDirection.Output;
            param[1].Value = dawnAuthUserLogin.UserId;
            param[2].Value = dawnAuthUserLogin.LogTime;
            param[3].Value = dawnAuthUserLogin.LogIp;
            param[4].Value = dawnAuthUserLogin.LogMac;
            param[5].Value = dawnAuthUserLogin.LogComputer;
            param[6].Value = dawnAuthUserLogin.LogAttach;
            param[7].Value = dawnAuthUserLogin.LogCount;
            param[8].Value = dawnAuthUserLogin.LogFieldOne;
            param[9].Value = dawnAuthUserLogin.LogFieldTwo;
            param[10].Value = dawnAuthUserLogin.LogFieldThree;
            res = SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
            dawnAuthUserLogin.LogId = ((param[0].Value) == DBNull.Value) ? 0 : Convert.ToInt32(param[0].Value);
            return res;
        }
        /// <summary>
        /// 向数据表DawnAuthUserLogin中插入一条新记录。带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="dawnAuthUserLogin">DawnAuthUserLogin实体对象</param>
        /// <returns></returns>
        public int Insert(SqlTransaction sp, DawnAuthUserLoginMDL dawnAuthUserLogin)
        {
            string sqlCommand = "DawnAuthUserLoginInsert";
            int res;
            SqlParameter[] param ={
				new SqlParameter("@LogId",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@LogTime",SqlDbType.DateTime),
				new SqlParameter("@LogIp",SqlDbType.VarChar,200),
				new SqlParameter("@LogMac",SqlDbType.VarChar,100),
				new SqlParameter("@LogComputer",SqlDbType.VarChar,100),
				new SqlParameter("@LogAttach",SqlDbType.NVarChar,-1),
				new SqlParameter("@LogCount",SqlDbType.Int),
				new SqlParameter("@LogFieldOne",SqlDbType.Int),
				new SqlParameter("@LogFieldTwo",SqlDbType.TinyInt),
				new SqlParameter("@LogFieldThree",SqlDbType.VarChar,-1)
			};
            param[0].Direction = ParameterDirection.Output;
            param[1].Value = dawnAuthUserLogin.UserId;
            param[2].Value = dawnAuthUserLogin.LogTime;
            param[3].Value = dawnAuthUserLogin.LogIp;
            param[4].Value = dawnAuthUserLogin.LogMac;
            param[5].Value = dawnAuthUserLogin.LogComputer;
            param[6].Value = dawnAuthUserLogin.LogAttach;
            param[7].Value = dawnAuthUserLogin.LogCount;
            param[8].Value = dawnAuthUserLogin.LogFieldOne;
            param[9].Value = dawnAuthUserLogin.LogFieldTwo;
            param[10].Value = dawnAuthUserLogin.LogFieldThree;
            res = SqlHelper.ExecuteNonQuery(sp, CommandType.StoredProcedure, sqlCommand, param);
            dawnAuthUserLogin.LogId = ((param[0].Value) == DBNull.Value) ? 0 : Convert.ToInt32(param[0].Value);
            return res;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表DawnAuthUserLogin修改一条记录
        /// </summary>
        /// <param name="dawnAuthUserLogin">dawnAuthUserLogin实体对象</param>
        /// <returns></returns>
        public int Update(DawnAuthUserLoginMDL dawnAuthUserLogin)
        {
            string sqlCommand = "DawnAuthUserLoginUpdate";
            SqlParameter[] param ={
				new SqlParameter("@LogId",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@LogTime",SqlDbType.DateTime),
				new SqlParameter("@LogIp",SqlDbType.VarChar,200),
				new SqlParameter("@LogMac",SqlDbType.VarChar,100),
				new SqlParameter("@LogComputer",SqlDbType.VarChar,100),
				new SqlParameter("@LogAttach",SqlDbType.NVarChar,-1),
				new SqlParameter("@LogCount",SqlDbType.Int),
				new SqlParameter("@LogFieldOne",SqlDbType.Int),
				new SqlParameter("@LogFieldTwo",SqlDbType.TinyInt),
				new SqlParameter("@LogFieldThree",SqlDbType.VarChar,-1)
			};
            param[0].Value = dawnAuthUserLogin.LogId;
            param[1].Value = dawnAuthUserLogin.UserId;
            param[2].Value = dawnAuthUserLogin.LogTime;
            param[3].Value = dawnAuthUserLogin.LogIp;
            param[4].Value = dawnAuthUserLogin.LogMac;
            param[5].Value = dawnAuthUserLogin.LogComputer;
            param[6].Value = dawnAuthUserLogin.LogAttach;
            param[7].Value = dawnAuthUserLogin.LogCount;
            param[8].Value = dawnAuthUserLogin.LogFieldOne;
            param[9].Value = dawnAuthUserLogin.LogFieldTwo;
            param[10].Value = dawnAuthUserLogin.LogFieldThree;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }
        /// <summary>
        /// 向数据表DawnAuthUserLogin修改一条记录。带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="dawnAuthUserLogin">dawnAuthUserLogin实体对象</param>
        /// <returns></returns>
        public int Update(SqlTransaction sp, DawnAuthUserLoginMDL dawnAuthUserLogin)
        {
            string sqlCommand = "DawnAuthUserLoginUpdate";
            SqlParameter[] param ={
				new SqlParameter("@LogId",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@LogTime",SqlDbType.DateTime),
				new SqlParameter("@LogIp",SqlDbType.VarChar,200),
				new SqlParameter("@LogMac",SqlDbType.VarChar,100),
				new SqlParameter("@LogComputer",SqlDbType.VarChar,100),
				new SqlParameter("@LogAttach",SqlDbType.NVarChar,-1),
				new SqlParameter("@LogCount",SqlDbType.Int),
				new SqlParameter("@LogFieldOne",SqlDbType.Int),
				new SqlParameter("@LogFieldTwo",SqlDbType.TinyInt),
				new SqlParameter("@LogFieldThree",SqlDbType.VarChar,-1)
			};
            param[0].Value = dawnAuthUserLogin.LogId;
            param[1].Value = dawnAuthUserLogin.UserId;
            param[2].Value = dawnAuthUserLogin.LogTime;
            param[3].Value = dawnAuthUserLogin.LogIp;
            param[4].Value = dawnAuthUserLogin.LogMac;
            param[5].Value = dawnAuthUserLogin.LogComputer;
            param[6].Value = dawnAuthUserLogin.LogAttach;
            param[7].Value = dawnAuthUserLogin.LogCount;
            param[8].Value = dawnAuthUserLogin.LogFieldOne;
            param[9].Value = dawnAuthUserLogin.LogFieldTwo;
            param[10].Value = dawnAuthUserLogin.LogFieldThree;
            return SqlHelper.ExecuteNonQuery(sp, CommandType.StoredProcedure, sqlCommand, param);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表DawnAuthUserLogin中的一条记录
        /// </summary>
        /// <param name="logId">系统编号</param>
        /// <returns></returns>
        public int Delete(int logId)
        {
            string sqlCommand = "DawnAuthUserLoginDelete";
            SqlParameter[] param ={
				new SqlParameter("@LogId",SqlDbType.Int)
			};
            param[0].Value = logId;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }
        /// <summary>
        /// 删除数据表DawnAuthUserLogin中的一条记录
        /// </summary>
        /// <param name="dawnAuthUserLogin">dawnAuthUserLogin实体对象</param>
        /// <returns></returns>
        public int Delete(DawnAuthUserLoginMDL dawnAuthUserLogin)
        {
            string sqlCommand = "DawnAuthUserLoginDelete";
            SqlParameter[] param ={
				new SqlParameter("@LogId",SqlDbType.Int)
			};
            param[0].Value = dawnAuthUserLogin.LogId;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }
        /// <summary>
        /// 删除数据表DawnAuthUserLogin中的一条记录,带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="logId">系统编号</param>
        /// <returns></returns>
        public int Delete(SqlTransaction sp, int logId)
        {
            string sqlCommand = "DawnAuthUserLoginDelete";
            SqlParameter[] param ={
				new SqlParameter("@LogId",SqlDbType.Int)
			};
            param[0].Value = logId;
            return SqlHelper.ExecuteNonQuery(sp, CommandType.StoredProcedure, sqlCommand, param);
        }

        /// <summary>
        /// 删除数据表DawnAuthUserLogin中的一条记录,带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="dawnAuthUserLogin">dawnAuthUserLogin实体对象</param>
        /// <returns></returns>
        public int Delete(SqlTransaction sp, DawnAuthUserLoginMDL dawnAuthUserLogin)
        {
            string sqlCommand = "DawnAuthUserLoginDelete";
            SqlParameter[] param ={
				new SqlParameter("@LogId",SqlDbType.Int)
			};
            param[0].Value = dawnAuthUserLogin.LogId;
            return SqlHelper.ExecuteNonQuery(sp, CommandType.StoredProcedure, sqlCommand, param);
        }
        /// <summary>
        /// 根据指定条件删除数据表DawnAuthUserLogin中的记录
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        public int DeleteWhere(string where)
        {
            if (string.IsNullOrEmpty(where)) return -1;
            string sqlCommand = "DawnAuthUserLoginDeleteWhere";
            SqlParameter[] param ={
            	new SqlParameter("@where",SqlDbType.VarChar,8000)
            };
            param[0].Value = where;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }

        #endregion

        #region 实体对象

        /// <summary>
        /// 得到DawnAuthUserLogin实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>DawnAuthUserLogin实体对象</returns>
        public DawnAuthUserLoginMDL Select(DataRow row)
        {
            DawnAuthUserLoginMDL obj = new DawnAuthUserLoginMDL();
            if (row != null)
            {
                try
                {
                    obj.LogId = ((row["log_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["log_id"]);
                }
                catch { }
                try
                {
                    obj.UserId = ((row["user_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["user_id"]);
                }
                catch { }
                try
                {
                    obj.LogTime = ((row["log_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["log_time"]);
                }
                catch { }
                try
                {
                    obj.LogIp = row["log_ip"].ToString();
                }
                catch { }
                try
                {
                    obj.LogMac = row["log_mac"].ToString();
                }
                catch { }
                try
                {
                    obj.LogComputer = row["log_computer"].ToString();
                }
                catch { }
                try
                {
                    obj.LogAttach = row["log_attach"].ToString();
                }
                catch { }
                try
                {
                    obj.LogCount = ((row["log_count"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["log_count"]);
                }
                catch { }
                try
                {
                    obj.LogFieldOne = ((row["log_field_one"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["log_field_one"]);
                }
                catch { }
                try
                {
                    obj.LogFieldTwo = ((row["log_field_two"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(row["log_field_two"]);
                }
                catch { }
                try
                {
                    obj.LogFieldThree = row["log_field_three"].ToString();
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
        /// 得到DawnAuthUserLogin实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>DawnAuthUserLogins实体对象</returns>
        public DawnAuthUserLoginMDL Select(IDataReader dr)
        {
            DawnAuthUserLoginMDL obj = new DawnAuthUserLoginMDL();
            try
            {
                obj.LogId = ((dr["log_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["log_id"]);
            }
            catch { }
            try
            {
                obj.UserId = ((dr["user_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["user_id"]);
            }
            catch { }
            try
            {
                obj.LogTime = ((dr["log_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["log_time"]);
            }
            catch { }
            try
            {
                obj.LogIp = dr["log_ip"].ToString();
            }
            catch { }
            try
            {
                obj.LogMac = dr["log_mac"].ToString();
            }
            catch { }
            try
            {
                obj.LogComputer = dr["log_computer"].ToString();
            }
            catch { }
            try
            {
                obj.LogAttach = dr["log_attach"].ToString();
            }
            catch { }
            try
            {
                obj.LogCount = ((dr["log_count"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["log_count"]);
            }
            catch { }
            try
            {
                obj.LogFieldOne = ((dr["log_field_one"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["log_field_one"]);
            }
            catch { }
            try
            {
                obj.LogFieldTwo = ((dr["log_field_two"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(dr["log_field_two"]);
            }
            catch { }
            try
            {
                obj.LogFieldThree = dr["log_field_three"].ToString();
            }
            catch { }
            return obj;
        }
        /// <summary>
        /// 根据ID,返回一个DawnAuthUserLogin实体对象
        /// </summary>
        /// <param name="logId">系统编号</param>
        /// <returns>DawnAuthUserLogin实体对象</returns>
        public DawnAuthUserLoginMDL Select(int logId)
        {
            DawnAuthUserLoginMDL obj = null;
            SqlParameter[] param ={
			new SqlParameter("@LogId",SqlDbType.Int)
			};
            param[0].Value = logId;
            string sqlCommand = "DawnAuthUserLoginSelect";
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
        /// 得到数据表DawnAuthUserLogin所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public List<DawnAuthUserLoginMDL> LSelect()
        {
            return this.LSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表DawnAuthUserLogin满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public List<DawnAuthUserLoginMDL> LSelect(string where)
        {
            return this.LSelect(where, " [log_id] DESC ");
        }
        /// <summary>
        /// 得到数据表DawnAuthUserLogin满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<DawnAuthUserLoginMDL> LSelect(string where, string sortField)
        {
            List<DawnAuthUserLoginMDL> list = new List<DawnAuthUserLoginMDL>();
            SqlParameter[] param ={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
            param[0].Value = where;
            param[1].Value = sortField;
            string sqlCommand = "DawnAuthUserLoginSelectByParams";
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
        /// 得到数据表DawnAuthUserLogin满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public List<DawnAuthUserLoginMDL> LSelect(CommandType commandType, string sqlCommand, params SqlParameter[] param)
        {
            List<DawnAuthUserLoginMDL> list = new List<DawnAuthUserLoginMDL>();
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
        /// 得到数据表DawnAuthUserLogin所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList<DawnAuthUserLoginMDL> ISelect()
        {
            return this.ISelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表DawnAuthUserLogin满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public IList<DawnAuthUserLoginMDL> ISelect(string where)
        {
            return this.ISelect(where, " [log_id] DESC ");
        }
        /// <summary>
        /// 得到数据表DawnAuthUserLogin满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<DawnAuthUserLoginMDL> ISelect(string where, string sortField)
        {
            IList<DawnAuthUserLoginMDL> list = new List<DawnAuthUserLoginMDL>();
            SqlParameter[] param ={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
            param[0].Value = where;
            param[1].Value = sortField;
            string sqlCommand = "DawnAuthUserLoginSelectByParams";
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
        /// 得到数据表DawnAuthUserLogin满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public IList<DawnAuthUserLoginMDL> ISelect(CommandType commandType, string sqlCommand, params SqlParameter[] param)
        {
            IList<DawnAuthUserLoginMDL> list = new List<DawnAuthUserLoginMDL>();
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
        /// 得到数据表DawnAuthUserLogin满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public void Select(string where, out int recordCount)
        {
            string sqlCommand = "DawnAuthUserLoginCountByWhere";
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
        /// <param name="logId">系统编号</param>
        /// <returns>存在/不存在</returns>
        public bool Exists(int logId)
        {
            SqlParameter[] param ={
            	new SqlParameter("@LogId",SqlDbType.Int)
            };
            param[0].Value = logId;
            string sqlCommand = "DawnAuthUserLoginIsExist";
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
            string sqlCommand = "DawnAuthUserLoginIsExistByWhere";
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPinPK(int pageSize, int pageIndex, string strWhere, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPinPK("dawn_auth_user_login", "*", -1, pageSize, pageIndex, strWhere, "log_id", "log_id desc", 1, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPinPK(int intTop, int pageSize, int pageIndex, string strWhere, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPinPK("dawn_auth_user_login", "*", intTop, pageSize, pageIndex, strWhere, "log_id", "log_id desc", 1, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPinPK(string strField, int intTop, int pageSize, int pageIndex, string strWhere, string strSortField, byte strOrderBy, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPinPK("dawn_auth_user_login", strField, intTop, pageSize, pageIndex, strWhere, "log_id", strSortField, strOrderBy, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPinPK(string strTable, string strField, int intTop, int pageSize, int pageIndex, string strWhere, string strSortKey, string strSortField, byte strOrderBy, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            List<DawnAuthUserLoginMDL> list = new List<DawnAuthUserLoginMDL>();
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurpose(int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurpose("dawn_auth_user_login", "*", pageSize, page, "log_time desc,log_id", 1, strCondition, "log_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurpose(string fldName, int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurpose("dawn_auth_user_login", fldName, pageSize, page, "log_time desc,log_id", 1, strCondition, "log_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurpose(string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, byte Dist, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurpose("dawn_auth_user_login", fldName, pageSize, page, fldSort, Sort, strCondition, "log_id", Dist, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurpose(string tblName, string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, string ID, byte Dist, out int pageCount, out int Counts, out int UsedTime, out string strSql)
        {
            List<DawnAuthUserLoginMDL> list = new List<DawnAuthUserLoginMDL>();
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurposeNotIn(int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeNotIn("dawn_auth_user_login", "*", pageSize, page, "log_time desc,log_id", 0, strCondition, "log_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurposeNotIn(string fldName, int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeNotIn("dawn_auth_user_login", fldName, pageSize, page, "log_time desc,log_id", 0, strCondition, "log_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurposeNotIn(string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, byte Dist, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeNotIn("dawn_auth_user_login", fldName, pageSize, page, fldSort, Sort, strCondition, "log_id", Dist, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurposeNotIn(string tblName, string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, string ID, byte Dist, out int pageCount, out int Counts, out int UsedTime, out string strSql)
        {
            List<DawnAuthUserLoginMDL> list = new List<DawnAuthUserLoginMDL>();
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_user_login", "*", pageSize, pageIndex, "log_time desc", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_user_login", "*", pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_user_login", fldName, pageSize, pageIndex, "log_time desc", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_user_login", fldName, pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_user_login", "*", pageSize, pageIndex, "log_time desc", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_user_login", "*", pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_user_login", fldName, pageSize, pageIndex, "log_time desc", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_user_login", fldName, pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthUserLogin 结果集</returns>
        public List<DawnAuthUserLoginMDL> SelectPSPisAllPurposeRowNumber(string tblName, string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            List<DawnAuthUserLoginMDL> list = new List<DawnAuthUserLoginMDL>();
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
