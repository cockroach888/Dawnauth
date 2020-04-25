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
		
		#region 构造函数
		
		/// <summary>
		/// 数据层实例化
		/// </summary>
		public DawnAuthUserDAL()
		{ }
		
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 实体对象
		
		/// <summary>
		/// 得到DawnAuthUser实体对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>DawnAuthUser实体对象</returns>
		public DawnAuthUserMDL Select(DataRow row)
		{
			DawnAuthUserMDL obj = new DawnAuthUserMDL();
			if(row!=null)
			{
				try
				{
					obj.UserId = (( row["user_id"])==DBNull.Value)?0:Convert.ToInt32( row["user_id"]);
				}
				catch { }
				try
				{
					obj.DptId = (( row["dpt_id"])==DBNull.Value)?0:Convert.ToInt32( row["dpt_id"]);
				}
				catch { }
				try
				{
					obj.UserTime = (( row["user_time"])==DBNull.Value)?DateTime.MinValue:Convert.ToDateTime( row["user_time"]);
				}
				catch { }
				try
				{
					obj.UserStatus = (( row["user_status"])==DBNull.Value)?Convert.ToByte(0):Convert.ToByte( row["user_status"]);
				}
				catch { }
				try
				{
					obj.UserGrade = (( row["user_grade"])==DBNull.Value)?Convert.ToByte(0):Convert.ToByte( row["user_grade"]);
				}
				catch { }
				try
				{
					obj.UserSurname =  row["user_surname"].ToString();
				}
				catch { }
				try
				{
					obj.UserName =  row["user_name"].ToString();
				}
				catch { }
				try
				{
					obj.UserPwd =  row["user_pwd"].ToString();
				}
				catch { }
				try
				{
					obj.UserMobile =  row["user_mobile"].ToString();
				}
				catch { }
				try
				{
					obj.UserEmail =  row["user_email"].ToString();
				}
				catch { }
				try
				{
					obj.UserDesc =  row["user_desc"].ToString();
				}
				catch { }
				try
				{
					obj.UserFieldOne = (( row["user_field_one"])==DBNull.Value)?0:Convert.ToInt32( row["user_field_one"]);
				}
				catch { }
				try
				{
					obj.UserFieldTwo = (( row["user_field_two"])==DBNull.Value)?0:Convert.ToInt32( row["user_field_two"]);
				}
				catch { }
				try
				{
					obj.UserFieldThree = (( row["user_field_three"])==DBNull.Value)?Convert.ToByte(0):Convert.ToByte( row["user_field_three"]);
				}
				catch { }
				try
				{
					obj.UserFieldFour = (( row["user_field_four"])==DBNull.Value)?Convert.ToByte(0):Convert.ToByte( row["user_field_four"]);
				}
				catch { }
				try
				{
					obj.UserFieldFive =  row["user_field_five"].ToString();
				}
				catch { }
				try
				{
					obj.UserFieldSix =  row["user_field_six"].ToString();
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
		/// 得到DawnAuthUser实体对象
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>DawnAuthUsers实体对象</returns>
		public DawnAuthUserMDL Select(IDataReader dr)
		{
			DawnAuthUserMDL obj = new DawnAuthUserMDL();
			try
			{
				obj.UserId = (( dr["user_id"])==DBNull.Value)?0:Convert.ToInt32( dr["user_id"]);
			}
			catch { }
			try
			{
				obj.DptId = (( dr["dpt_id"])==DBNull.Value)?0:Convert.ToInt32( dr["dpt_id"]);
			}
			catch { }
			try
			{
				obj.UserTime = (( dr["user_time"])==DBNull.Value)?DateTime.MinValue:Convert.ToDateTime( dr["user_time"]);
			}
			catch { }
			try
			{
				obj.UserStatus = (( dr["user_status"])==DBNull.Value)?Convert.ToByte(0):Convert.ToByte( dr["user_status"]);
			}
			catch { }
			try
			{
				obj.UserGrade = (( dr["user_grade"])==DBNull.Value)?Convert.ToByte(0):Convert.ToByte( dr["user_grade"]);
			}
			catch { }
			try
			{
				obj.UserSurname =  dr["user_surname"].ToString();
			}
			catch { }
			try
			{
				obj.UserName =  dr["user_name"].ToString();
			}
			catch { }
			try
			{
				obj.UserPwd =  dr["user_pwd"].ToString();
			}
			catch { }
			try
			{
				obj.UserMobile =  dr["user_mobile"].ToString();
			}
			catch { }
			try
			{
				obj.UserEmail =  dr["user_email"].ToString();
			}
			catch { }
			try
			{
				obj.UserDesc =  dr["user_desc"].ToString();
			}
			catch { }
			try
			{
				obj.UserFieldOne = (( dr["user_field_one"])==DBNull.Value)?0:Convert.ToInt32( dr["user_field_one"]);
			}
			catch { }
			try
			{
				obj.UserFieldTwo = (( dr["user_field_two"])==DBNull.Value)?0:Convert.ToInt32( dr["user_field_two"]);
			}
			catch { }
			try
			{
				obj.UserFieldThree = (( dr["user_field_three"])==DBNull.Value)?Convert.ToByte(0):Convert.ToByte( dr["user_field_three"]);
			}
			catch { }
			try
			{
				obj.UserFieldFour = (( dr["user_field_four"])==DBNull.Value)?Convert.ToByte(0):Convert.ToByte( dr["user_field_four"]);
			}
			catch { }
			try
			{
				obj.UserFieldFive =  dr["user_field_five"].ToString();
			}
			catch { }
			try
			{
				obj.UserFieldSix =  dr["user_field_six"].ToString();
			}
			catch { }
			return obj;
		}
		/// <summary>
		/// 根据ID,返回一个DawnAuthUser实体对象
		/// </summary>
		/// <param name="userId">系统编号</param>
		/// <returns>DawnAuthUser实体对象</returns>
		public DawnAuthUserMDL Select(int userId)
		{
			DawnAuthUserMDL obj=null;
			SqlParameter[] param={
			new SqlParameter("@UserId",SqlDbType.Int)
			};
			param[0].Value=userId;
			string sqlCommand="DawnAuthUserSelect";
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
		/// 得到数据表DawnAuthUser所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public List< DawnAuthUserMDL> LSelect()
		{
			return this.LSelect(string.Empty);
		}
		/// <summary>
		/// 得到数据表DawnAuthUser满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public List< DawnAuthUserMDL> LSelect(string where)
		{
			return this.LSelect(where," [user_id] DESC ");
		}
		/// <summary>
		/// 得到数据表DawnAuthUser满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public List< DawnAuthUserMDL> LSelect(string where,string sortField)
		{
			List< DawnAuthUserMDL> list=new List< DawnAuthUserMDL>();
			SqlParameter[] param={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
			param[0].Value=where;
			param[1].Value=sortField;
			string sqlCommand="DawnAuthUserSelectByParams";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param))
			{
				while(dr.Read())
				{
					list.Add(this.Select(dr));
				}
			}
			return list;
		}
        /// <summary>
		/// 得到数据表DawnAuthUser满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		public List< DawnAuthUserMDL > LSelect(CommandType commandType,string sqlCommand,params SqlParameter[] param)
		{
			List< DawnAuthUserMDL> list=new List< DawnAuthUserMDL>();
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,commandType,sqlCommand,param))
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
		/// 得到数据表DawnAuthUser所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public IList< DawnAuthUserMDL> ISelect()
		{
			return this.ISelect(string.Empty);
		}
		/// <summary>
		/// 得到数据表DawnAuthUser满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public IList< DawnAuthUserMDL> ISelect(string where)
		{
			return this.ISelect(where," [user_id] DESC ");
		}
		/// <summary>
		/// 得到数据表DawnAuthUser满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public IList< DawnAuthUserMDL> ISelect(string where,string sortField)
		{
			IList< DawnAuthUserMDL> list=new List< DawnAuthUserMDL>();
			SqlParameter[] param={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
			param[0].Value=where;
			param[1].Value=sortField;
			string sqlCommand="DawnAuthUserSelectByParams";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param))
			{
				while(dr.Read())
				{
					list.Add(this.Select(dr));
				}
			}
			return list;
		}
        /// <summary>
		/// 得到数据表DawnAuthUser满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		public IList< DawnAuthUserMDL > ISelect(CommandType commandType,string sqlCommand,params SqlParameter[] param)
		{
			IList< DawnAuthUserMDL> list=new List< DawnAuthUserMDL>();
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,commandType,sqlCommand,param))
			{
				while(dr.Read())
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
