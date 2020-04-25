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
    internal partial class DawnAuthUserLoginDAL : IDawnAuthUserLoginDAL
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

        #endregion
        
        #endregion
        
        #endregion

    }
}
