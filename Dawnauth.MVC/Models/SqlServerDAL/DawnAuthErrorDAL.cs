﻿// =================================================================== 
// 产品（DawnXZ.Dawnauth.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthErrorDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年02月28日 23:22:27
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
    /// 数据访问层DawnAuthError
    /// </summary>
    public partial class DawnAuthErrorDAL : IDawnAuthErrorDAL
    {

        #region 构造函数

        /// <summary>
        /// 数据层实例化
        /// </summary>
        public DawnAuthErrorDAL()
        { }

        #endregion

        #region -----------实例化接口函数-----------

        #region 添加

        /// <summary>
        /// 向数据表DawnAuthError中插入一条新记录
        /// </summary>
        /// <param name="dawnAuthError">DawnAuthError实体对象</param>
        /// <returns></returns>
        public int Insert(DawnAuthErrorMDL dawnAuthError)
        {
            try
            {
                string sqlCommand = "DawnAuthErrorInsert";
                int res;
                SqlParameter[] param ={
				    new SqlParameter("@ErrId",SqlDbType.UniqueIdentifier),
				    new SqlParameter("@ErrTime",SqlDbType.DateTime),
				    new SqlParameter("@ErrAddress",SqlDbType.VarChar,2000),
				    new SqlParameter("@ErrMessage",SqlDbType.VarChar,4000),
				    new SqlParameter("@ErrTarget",SqlDbType.VarChar,-1),
				    new SqlParameter("@ErrTrace",SqlDbType.NVarChar,-1),
				    new SqlParameter("@ErrSource",SqlDbType.NVarChar,-1),
				    new SqlParameter("@ErrIp",SqlDbType.VarChar,200),
				    new SqlParameter("@ErrUid",SqlDbType.Int),
				    new SqlParameter("@ErrUname",SqlDbType.NVarChar,20)
			    };
                param[0].Direction = ParameterDirection.Output;
                param[1].Value = dawnAuthError.ErrTime;
                param[2].Value = dawnAuthError.ErrAddress;
                param[3].Value = dawnAuthError.ErrMessage;
                param[4].Value = dawnAuthError.ErrTarget;
                param[5].Value = dawnAuthError.ErrTrace;
                param[6].Value = dawnAuthError.ErrSource;
                param[7].Value = dawnAuthError.ErrIp;
                param[8].Value = dawnAuthError.ErrUid;
                param[9].Value = dawnAuthError.ErrUname;
                res = SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
                dawnAuthError.ErrId = (Guid)param[0].Value;
                return res;
            }
            catch
            {
                return -1;
            }
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表DawnAuthError中的一条记录
        /// </summary>
        /// <param name="errId">系统编号</param>
        /// <returns></returns>
        public int Delete(Guid errId)
        {
            string sqlCommand = "DawnAuthErrorDelete";
            SqlParameter[] param ={
				new SqlParameter("@ErrId",SqlDbType.UniqueIdentifier)
			};
            param[0].Value = errId;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }
        /// <summary>
        /// 根据指定条件删除数据表DawnAuthError中的记录
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        public int DeleteWhere(string where)
        {
            if (string.IsNullOrEmpty(where)) return -1;
            string sqlCommand = "DawnAuthErrorDeleteWhere";
            SqlParameter[] param ={
            	new SqlParameter("@where",SqlDbType.VarChar,8000)
            };
            param[0].Value = where;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }
        /// <summary>
        /// 删除数据表DawnAuthError中的所有记录
        /// </summary>
        /// <returns></returns>
        public int DeleteAll()
        {
            string sqlCommand = "DawnAuthErrorDeleteAll";
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand);
        }

        #endregion

        #region 实体对象

        /// <summary>
        /// 得到DawnAuthError实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>DawnAuthError实体对象</returns>
        public DawnAuthErrorMDL Select(DataRow row)
        {
            DawnAuthErrorMDL obj = new DawnAuthErrorMDL();
            if (row != null)
            {
                try
                {
                    obj.ErrId = (Guid)row["err_id"];
                }
                catch { }
                try
                {
                    obj.ErrTime = ((row["err_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["err_time"]);
                }
                catch { }
                try
                {
                    obj.ErrAddress = row["err_address"].ToString();
                }
                catch { }
                try
                {
                    obj.ErrMessage = row["err_message"].ToString();
                }
                catch { }
                try
                {
                    obj.ErrTarget = row["err_target"].ToString();
                }
                catch { }
                try
                {
                    obj.ErrTrace = row["err_trace"].ToString();
                }
                catch { }
                try
                {
                    obj.ErrSource = row["err_source"].ToString();
                }
                catch { }
                try
                {
                    obj.ErrIp = row["err_ip"].ToString();
                }
                catch { }
                try
                {
                    obj.ErrUid = ((row["err_uid"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["err_uid"]);
                }
                catch { }
                try
                {
                    obj.ErrUname = row["err_uname"].ToString();
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
        /// 得到DawnAuthError实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>DawnAuthError实体对象</returns>
        public DawnAuthErrorMDL Select(IDataReader dr)
        {
            DawnAuthErrorMDL obj = new DawnAuthErrorMDL();
            try
            {
                obj.ErrId = (Guid)dr["err_id"];
            }
            catch { }
            try
            {
                obj.ErrTime = ((dr["err_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["err_time"]);
            }
            catch { }
            try
            {
                obj.ErrAddress = dr["err_address"].ToString();
            }
            catch { }
            try
            {
                obj.ErrMessage = dr["err_message"].ToString();
            }
            catch { }
            try
            {
                obj.ErrTarget = dr["err_target"].ToString();
            }
            catch { }
            try
            {
                obj.ErrTrace = dr["err_trace"].ToString();
            }
            catch { }
            try
            {
                obj.ErrSource = dr["err_source"].ToString();
            }
            catch { }
            try
            {
                obj.ErrIp = dr["err_ip"].ToString();
            }
            catch { }
            try
            {
                obj.ErrUid = ((dr["err_uid"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["err_uid"]);
            }
            catch { }
            try
            {
                obj.ErrUname = dr["err_uname"].ToString();
            }
            catch { }
            return obj;
        }

        /// <summary>
        /// 根据ID,返回一个DawnAuthError实体对象
        /// </summary>
        /// <param name="errId">系统编号</param>
        /// <returns>DawnAuthError实体对象</returns>
        public DawnAuthErrorMDL Select(Guid errId)
        {
            DawnAuthErrorMDL obj = null;
            SqlParameter[] param ={
			new SqlParameter("@ErrId",SqlDbType.UniqueIdentifier)
			};
            param[0].Value = errId;
            string sqlCommand = "DawnAuthErrorSelect";
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
        /// 得到数据表DawnAuthError所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public List<DawnAuthErrorMDL> LSelect()
        {
            return this.LSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表DawnAuthError满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<DawnAuthErrorMDL> LSelect(string where)
        {
            return this.LSelect(where, " [err_id] DESC ");
        }
        /// <summary>
        /// 得到数据表DawnAuthError满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<DawnAuthErrorMDL> LSelect(string where, string sortField)
        {
            List<DawnAuthErrorMDL> list = new List<DawnAuthErrorMDL>();
            SqlParameter[] param ={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
            param[0].Value = where;
            param[1].Value = sortField;
            string sqlCommand = "DawnAuthErrorSelectByParams";
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
        /// 得到数据表DawnAuthError满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public List<DawnAuthErrorMDL> LSelect(CommandType commandType, string sqlCommand, params SqlParameter[] param)
        {
            List<DawnAuthErrorMDL> list = new List<DawnAuthErrorMDL>();
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
        /// 得到数据表DawnAuthError所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList<DawnAuthErrorMDL> ISelect()
        {
            return this.ISelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表DawnAuthError满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<DawnAuthErrorMDL> ISelect(string where)
        {
            return this.ISelect(where, " [err_id] DESC ");
        }
        /// <summary>
        /// 得到数据表DawnAuthError满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<DawnAuthErrorMDL> ISelect(string where, string sortField)
        {
            IList<DawnAuthErrorMDL> list = new List<DawnAuthErrorMDL>();
            SqlParameter[] param ={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
            param[0].Value = where;
            param[1].Value = sortField;
            string sqlCommand = "DawnAuthErrorSelectByParams";
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
        /// 得到数据表DawnAuthError满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public IList<DawnAuthErrorMDL> ISelect(CommandType commandType, string sqlCommand, params SqlParameter[] param)
        {
            IList<DawnAuthErrorMDL> list = new List<DawnAuthErrorMDL>();
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
        /// 得到数据表DawnAuthError满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public void Select(string where, out int recordCount)
        {
            string sqlCommand = "DawnAuthErrorCountByWhere";
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
        /// <param name="errId">系统编号</param>
        /// <returns>存在/不存在</returns>
        public bool Exists(Guid errId)
        {
            SqlParameter[] param ={
            	new SqlParameter("@ErrId",SqlDbType.UniqueIdentifier)
            };
            param[0].Value = errId;
            string sqlCommand = "DawnAuthErrorIsExist";
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
            string sqlCommand = "DawnAuthErrorIsExistByWhere";
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPinPK(int pageSize, int pageIndex, string strWhere, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPinPK("dawn_auth_error", "*", -1, pageSize, pageIndex, strWhere, "err_id", "err_id desc", 1, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPinPK(int intTop, int pageSize, int pageIndex, string strWhere, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPinPK("dawn_auth_error", "*", intTop, pageSize, pageIndex, strWhere, "err_id", "err_id desc", 1, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPinPK(string strField, int intTop, int pageSize, int pageIndex, string strWhere, string strSortField, byte strOrderBy, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPinPK("dawn_auth_error", strField, intTop, pageSize, pageIndex, strWhere, "err_id", strSortField, strOrderBy, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPinPK(string strTable, string strField, int intTop, int pageSize, int pageIndex, string strWhere, string strSortKey, string strSortField, byte strOrderBy, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            List<DawnAuthErrorMDL> list = new List<DawnAuthErrorMDL>();
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurpose(int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurpose("dawn_auth_error", "*", pageSize, page, "err_time desc,err_id", 1, strCondition, "err_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurpose(string fldName, int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurpose("dawn_auth_error", fldName, pageSize, page, "err_time desc,err_id", 1, strCondition, "err_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurpose(string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, byte Dist, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurpose("dawn_auth_error", fldName, pageSize, page, fldSort, Sort, strCondition, "err_id", Dist, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurpose(string tblName, string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, string ID, byte Dist, out int pageCount, out int Counts, out int UsedTime, out string strSql)
        {
            List<DawnAuthErrorMDL> list = new List<DawnAuthErrorMDL>();
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurposeNotIn(int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeNotIn("dawn_auth_error", "*", pageSize, page, "err_time desc,err_id", 0, strCondition, "err_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurposeNotIn(string fldName, int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeNotIn("dawn_auth_error", fldName, pageSize, page, "err_time desc,err_id", 0, strCondition, "err_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurposeNotIn(string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, byte Dist, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeNotIn("dawn_auth_error", fldName, pageSize, page, fldSort, Sort, strCondition, "err_id", Dist, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurposeNotIn(string tblName, string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, string ID, byte Dist, out int pageCount, out int Counts, out int UsedTime, out string strSql)
        {
            List<DawnAuthErrorMDL> list = new List<DawnAuthErrorMDL>();
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_error", "*", pageSize, pageIndex, "err_time desc", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_error", "*", pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_error", fldName, pageSize, pageIndex, "err_time desc", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_error", fldName, pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_error", "*", pageSize, pageIndex, "err_time desc", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_error", "*", pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_error", fldName, pageSize, pageIndex, "err_time desc", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_error", fldName, pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthError 结果集</returns>
        public List<DawnAuthErrorMDL> SelectPSPisAllPurposeRowNumber(string tblName, string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            List<DawnAuthErrorMDL> list = new List<DawnAuthErrorMDL>();
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
