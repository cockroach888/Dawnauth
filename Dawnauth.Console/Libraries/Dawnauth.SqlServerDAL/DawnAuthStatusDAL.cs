// =================================================================== 
// 产品（DawnXZ.Dawnauth.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthStatusDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年04月05日 23:39:34
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
    /// 数据访问层DawnAuthStatus
    /// </summary>
    public partial class DawnAuthStatusDAL : IDawnAuthStatusDAL
    {
		
		#region 构造函数
		
		/// <summary>
		/// 数据层实例化
		/// </summary>
		public DawnAuthStatusDAL()
		{ }
		
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 实体对象
		
		/// <summary>
		/// 得到DawnAuthStatus实体对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>DawnAuthStatus实体对象</returns>
		public DawnAuthStatusMDL Select(DataRow row)
		{
			DawnAuthStatusMDL obj = new DawnAuthStatusMDL();
			if(row!=null)
			{
				try
				{
					obj.StatId = (( row["stat_id"])==DBNull.Value)?0:Convert.ToInt32( row["stat_id"]);
				}
				catch { }
				try
				{
					obj.MdlId = (( row["mdl_id"])==DBNull.Value)?0:Convert.ToInt32( row["mdl_id"]);
				}
				catch { }
				try
				{
					obj.StatTime = (( row["stat_time"])==DBNull.Value)?DateTime.MinValue:Convert.ToDateTime( row["stat_time"]);
				}
				catch { }
				try
				{
					obj.StatName =  row["stat_name"].ToString();
				}
				catch { }
				try
				{
					obj.StatCode =  row["stat_code"].ToString();
				}
				catch { }
				try
				{
					obj.StatMark = (( row["stat_mark"])==DBNull.Value)?0:Convert.ToInt32( row["stat_mark"]);
				}
				catch { }
				try
				{
					obj.StatDesc =  row["stat_desc"].ToString();
				}
				catch { }
				try
				{
					obj.StatFieldOne = (( row["stat_field_one"])==DBNull.Value)?0:Convert.ToInt32( row["stat_field_one"]);
				}
				catch { }
				try
				{
					obj.StatFieldTwo = (( row["stat_field_two"])==DBNull.Value)?Convert.ToByte(0):Convert.ToByte( row["stat_field_two"]);
				}
				catch { }
				try
				{
					obj.StatFieldThree =  row["stat_field_three"].ToString();
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
		/// 得到DawnAuthStatus实体对象
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>DawnAuthStatuss实体对象</returns>
		public DawnAuthStatusMDL Select(IDataReader dr)
		{
			DawnAuthStatusMDL obj = new DawnAuthStatusMDL();
			try
			{
				obj.StatId = (( dr["stat_id"])==DBNull.Value)?0:Convert.ToInt32( dr["stat_id"]);
			}
			catch { }
			try
			{
				obj.MdlId = (( dr["mdl_id"])==DBNull.Value)?0:Convert.ToInt32( dr["mdl_id"]);
			}
			catch { }
			try
			{
				obj.StatTime = (( dr["stat_time"])==DBNull.Value)?DateTime.MinValue:Convert.ToDateTime( dr["stat_time"]);
			}
			catch { }
			try
			{
				obj.StatName =  dr["stat_name"].ToString();
			}
			catch { }
			try
			{
				obj.StatCode =  dr["stat_code"].ToString();
			}
			catch { }
			try
			{
				obj.StatMark = (( dr["stat_mark"])==DBNull.Value)?0:Convert.ToInt32( dr["stat_mark"]);
			}
			catch { }
			try
			{
				obj.StatDesc =  dr["stat_desc"].ToString();
			}
			catch { }
			try
			{
				obj.StatFieldOne = (( dr["stat_field_one"])==DBNull.Value)?0:Convert.ToInt32( dr["stat_field_one"]);
			}
			catch { }
			try
			{
				obj.StatFieldTwo = (( dr["stat_field_two"])==DBNull.Value)?Convert.ToByte(0):Convert.ToByte( dr["stat_field_two"]);
			}
			catch { }
			try
			{
				obj.StatFieldThree =  dr["stat_field_three"].ToString();
			}
			catch { }
			return obj;
		}
		/// <summary>
		/// 根据ID,返回一个DawnAuthStatus实体对象
		/// </summary>
		/// <param name="statId">系统编号</param>
		/// <returns>DawnAuthStatus实体对象</returns>
		public DawnAuthStatusMDL Select(int statId)
		{
			DawnAuthStatusMDL obj=null;
			SqlParameter[] param={
			new SqlParameter("@StatId",SqlDbType.Int)
			};
			param[0].Value=statId;
			string sqlCommand="DawnAuthStatusSelect";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param))
			{
				while(dr.Read())
				{
            		obj=this.Select(dr);
				}
			}
			return obj;
		}
		
		#endregion
		
		#region 查询
		
        #region List
        
        /// <summary>
		/// 得到数据表DawnAuthStatus所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public List< DawnAuthStatusMDL> LSelect()
		{
			return this.LSelect(string.Empty);
		}
		/// <summary>
		/// 得到数据表DawnAuthStatus满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public List< DawnAuthStatusMDL> LSelect(string where)
		{
			return this.LSelect(where," [stat_id] DESC ");
		}
		/// <summary>
		/// 得到数据表DawnAuthStatus满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public List< DawnAuthStatusMDL> LSelect(string where,string sortField)
		{
			List< DawnAuthStatusMDL> list=new List< DawnAuthStatusMDL>();
			SqlParameter[] param={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
			param[0].Value=where;
			param[1].Value=sortField;
			string sqlCommand="DawnAuthStatusSelectByParams";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param))
			{
				while(dr.Read())
				{
					list.Add(this.Select(dr));
				}
			}
			return list;
		}
        
        #endregion
        
        #region IList
        
        /// <summary>
		/// 得到数据表DawnAuthStatus所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public IList< DawnAuthStatusMDL> ISelect()
		{
			return this.ISelect(string.Empty);
		}
		/// <summary>
		/// 得到数据表DawnAuthStatus满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public IList< DawnAuthStatusMDL> ISelect(string where)
		{
			return this.ISelect(where," [stat_id] DESC ");
		}
		/// <summary>
		/// 得到数据表DawnAuthStatus满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public IList< DawnAuthStatusMDL> ISelect(string where,string sortField)
		{
			IList< DawnAuthStatusMDL> list=new List< DawnAuthStatusMDL>();
			SqlParameter[] param={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
			param[0].Value=where;
			param[1].Value=sortField;
			string sqlCommand="DawnAuthStatusSelectByParams";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param))
			{
				while(dr.Read())
				{
					list.Add(this.Select(dr));
				}
			}
			return list;
		}
        
        #endregion
        		
		/// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="statId">系统编号</param>
        /// <returns>存在/不存在</returns>
		public bool Exists(int statId)
		{
			SqlParameter[] param={
            	new SqlParameter("@StatId",SqlDbType.Int)
            };
            param[0].Value=statId;
            string sqlCommand="DawnAuthStatusIsExist";
            string val=SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param).ToString();
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
            if(string.IsNullOrEmpty(where)) return false;
			SqlParameter[] param={
            	new SqlParameter("@where",SqlDbType.VarChar,8000)
            };
            param[0].Value=where;
            string sqlCommand="DawnAuthStatusIsExistByWhere";
            string val=SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
		}
		
		#endregion
		
        #endregion
    
	}
}
