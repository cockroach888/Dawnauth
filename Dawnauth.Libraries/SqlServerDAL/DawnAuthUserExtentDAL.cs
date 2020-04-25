// =================================================================== 
// 产品（DawnXZ.Dawnauth.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthUserExtentDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:36:41
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
    /// 数据访问层DawnAuthUserExtent
    /// </summary>
    internal partial class DawnAuthUserExtentDAL : IDawnAuthUserExtentDAL
    {
		
		#region 构造函数
		
		/// <summary>
		/// 数据层实例化
		/// </summary>
		public DawnAuthUserExtentDAL()
		{ }
		
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加
		
		/// <summary>
		/// 向数据表DawnAuthUserExtent中插入一条新记录
		/// </summary>
		/// <param name="dawnAuthUserExtent">DawnAuthUserExtent实体对象</param>
		/// <returns></returns>
		public int Insert(DawnAuthUserExtentMDL dawnAuthUserExtent)
		{
			string sqlCommand="DawnAuthUserExtentInsert";
			int res;
			SqlParameter[] param={
				new SqlParameter("@ExtId",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@ExtTime",SqlDbType.DateTime),
				new SqlParameter("@ExtCode",SqlDbType.VarChar,100),
				new SqlParameter("@ExtMark",SqlDbType.VarChar,100)
			};
			param[0].Direction = ParameterDirection.Output;
			param[1].Value=dawnAuthUserExtent.UserId;
			param[2].Value=dawnAuthUserExtent.ExtTime;
			param[3].Value=dawnAuthUserExtent.ExtCode;
			param[4].Value=dawnAuthUserExtent.ExtMark;
			res = SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param);
			dawnAuthUserExtent.ExtId=((param[0].Value)==DBNull.Value)?0:Convert.ToInt32(param[0].Value);
			return res;
		}
		/// <summary>
		/// 向数据表DawnAuthUserExtent中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="dawnAuthUserExtent">DawnAuthUserExtent实体对象</param>
		/// <returns></returns>
		public int Insert(SqlTransaction sp,DawnAuthUserExtentMDL dawnAuthUserExtent)
		{
			string sqlCommand="DawnAuthUserExtentInsert";
			int res;
			SqlParameter[] param={
				new SqlParameter("@ExtId",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@ExtTime",SqlDbType.DateTime),
				new SqlParameter("@ExtCode",SqlDbType.VarChar,100),
				new SqlParameter("@ExtMark",SqlDbType.VarChar,100)
			};
			param[0].Direction = ParameterDirection.Output;
			param[1].Value=dawnAuthUserExtent.UserId;
			param[2].Value=dawnAuthUserExtent.ExtTime;
			param[3].Value=dawnAuthUserExtent.ExtCode;
			param[4].Value=dawnAuthUserExtent.ExtMark;
			res = SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlCommand,param);
			dawnAuthUserExtent.ExtId=((param[0].Value)==DBNull.Value)?0:Convert.ToInt32(param[0].Value);
			return res;
		}
		
		#endregion
		
		#region 修改
		
		/// <summary>
		/// 向数据表DawnAuthUserExtent修改一条记录
		/// </summary>
		/// <param name="dawnAuthUserExtent">dawnAuthUserExtent实体对象</param>
		/// <returns></returns>
		public int Update(DawnAuthUserExtentMDL dawnAuthUserExtent)
		{
            string sqlCommand="DawnAuthUserExtentUpdate";
			SqlParameter[] param={
				new SqlParameter("@ExtId",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@ExtTime",SqlDbType.DateTime),
				new SqlParameter("@ExtCode",SqlDbType.VarChar,100),
				new SqlParameter("@ExtMark",SqlDbType.VarChar,100)
			};
			param[0].Value=dawnAuthUserExtent.ExtId;
			param[1].Value=dawnAuthUserExtent.UserId;
			param[2].Value=dawnAuthUserExtent.ExtTime;
			param[3].Value=dawnAuthUserExtent.ExtCode;
			param[4].Value=dawnAuthUserExtent.ExtMark;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param);
		}
		/// <summary>
		/// 向数据表DawnAuthUserExtent修改一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="dawnAuthUserExtent">dawnAuthUserExtent实体对象</param>
		/// <returns></returns>
		public int Update(SqlTransaction sp,DawnAuthUserExtentMDL dawnAuthUserExtent)
		{
            string sqlCommand="DawnAuthUserExtentUpdate";
			SqlParameter[] param={
				new SqlParameter("@ExtId",SqlDbType.Int),
				new SqlParameter("@UserId",SqlDbType.Int),
				new SqlParameter("@ExtTime",SqlDbType.DateTime),
				new SqlParameter("@ExtCode",SqlDbType.VarChar,100),
				new SqlParameter("@ExtMark",SqlDbType.VarChar,100)
			};
			param[0].Value=dawnAuthUserExtent.ExtId;
			param[1].Value=dawnAuthUserExtent.UserId;
			param[2].Value=dawnAuthUserExtent.ExtTime;
			param[3].Value=dawnAuthUserExtent.ExtCode;
			param[4].Value=dawnAuthUserExtent.ExtMark;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlCommand,param);
		}
		
		#endregion
		
		#region 删除
		
		/// <summary>
		/// 删除数据表DawnAuthUserExtent中的一条记录
		/// </summary>
	    /// <param name="extId">系统编号</param>
		/// <returns></returns>
		public int Delete(int extId)
		{
			string sqlCommand="DawnAuthUserExtentDelete";
			SqlParameter[] param={
				new SqlParameter("@ExtId",SqlDbType.Int)
			};
			param[0].Value=extId;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param);
		}
		/// <summary>
		/// 删除数据表DawnAuthUserExtent中的一条记录
		/// </summary>
	    /// <param name="dawnAuthUserExtent">dawnAuthUserExtent实体对象</param>
		/// <returns></returns>
		public int Delete(DawnAuthUserExtentMDL dawnAuthUserExtent)
		{
			string sqlCommand="DawnAuthUserExtentDelete";
			SqlParameter[] param={
				new SqlParameter("@ExtId",SqlDbType.Int)
			};
			param[0].Value=dawnAuthUserExtent.ExtId;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param);
		}
		/// <summary>
		/// 删除数据表DawnAuthUserExtent中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="extId">系统编号</param>
		/// <returns></returns>
		public int Delete(SqlTransaction sp,int extId)
		{
			string sqlCommand="DawnAuthUserExtentDelete";
			SqlParameter[] param={
				new SqlParameter("@ExtId",SqlDbType.Int)
			};
			param[0].Value=extId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlCommand,param);
		}
		
		/// <summary>
		/// 删除数据表DawnAuthUserExtent中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="dawnAuthUserExtent">dawnAuthUserExtent实体对象</param>
		/// <returns></returns>
		public int Delete(SqlTransaction sp,DawnAuthUserExtentMDL dawnAuthUserExtent)
		{
			string sqlCommand="DawnAuthUserExtentDelete";
			SqlParameter[] param={
				new SqlParameter("@ExtId",SqlDbType.Int)
			};
			param[0].Value=dawnAuthUserExtent.ExtId;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.StoredProcedure,sqlCommand,param);
		}
        /// <summary>
        /// 根据指定条件删除数据表DawnAuthUserExtent中的记录
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        public int DeleteWhere(string where)
        {
            if(string.IsNullOrEmpty(where)) return -1;
            string sqlCommand = "DawnAuthUserExtentDeleteWhere";
            SqlParameter[] param={
            	new SqlParameter("@where",SqlDbType.VarChar,8000)
            };
            param[0].Value=where;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }
		
		#endregion
		
		#region 实体对象
		
		/// <summary>
		/// 得到DawnAuthUserExtent实体对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>DawnAuthUserExtent实体对象</returns>
		public DawnAuthUserExtentMDL Select(DataRow row)
		{
			DawnAuthUserExtentMDL obj = new DawnAuthUserExtentMDL();
			if(row!=null)
			{
				try
				{
					obj.ExtId = (( row["ext_id"])==DBNull.Value)?0:Convert.ToInt32( row["ext_id"]);
				}
				catch { }
				try
				{
					obj.UserId = (( row["user_id"])==DBNull.Value)?0:Convert.ToInt32( row["user_id"]);
				}
				catch { }
				try
				{
					obj.ExtTime = (( row["ext_time"])==DBNull.Value)?DateTime.MinValue:Convert.ToDateTime( row["ext_time"]);
				}
				catch { }
				try
				{
					obj.ExtCode =  row["ext_code"].ToString();
				}
				catch { }
				try
				{
					obj.ExtMark =  row["ext_mark"].ToString();
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
		/// 得到DawnAuthUserExtent实体对象
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>DawnAuthUserExtents实体对象</returns>
		public DawnAuthUserExtentMDL Select(IDataReader dr)
		{
			DawnAuthUserExtentMDL obj = new DawnAuthUserExtentMDL();
			try
			{
				obj.ExtId = (( dr["ext_id"])==DBNull.Value)?0:Convert.ToInt32( dr["ext_id"]);
			}
			catch { }
			try
			{
				obj.UserId = (( dr["user_id"])==DBNull.Value)?0:Convert.ToInt32( dr["user_id"]);
			}
			catch { }
			try
			{
				obj.ExtTime = (( dr["ext_time"])==DBNull.Value)?DateTime.MinValue:Convert.ToDateTime( dr["ext_time"]);
			}
			catch { }
			try
			{
				obj.ExtCode =  dr["ext_code"].ToString();
			}
			catch { }
			try
			{
				obj.ExtMark =  dr["ext_mark"].ToString();
			}
			catch { }
			return obj;
		}
		/// <summary>
		/// 根据ID,返回一个DawnAuthUserExtent实体对象
		/// </summary>
		/// <param name="extId">系统编号</param>
		/// <returns>DawnAuthUserExtent实体对象</returns>
		public DawnAuthUserExtentMDL Select(int extId)
		{
			DawnAuthUserExtentMDL obj=null;
			SqlParameter[] param={
			new SqlParameter("@ExtId",SqlDbType.Int)
			};
			param[0].Value=extId;
			string sqlCommand="DawnAuthUserExtentSelect";
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
		/// 得到数据表DawnAuthUserExtent所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public List< DawnAuthUserExtentMDL> LSelect()
		{
			return this.LSelect(string.Empty);
		}
		/// <summary>
		/// 得到数据表DawnAuthUserExtent满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public List< DawnAuthUserExtentMDL> LSelect(string where)
		{
			return this.LSelect(where," [ext_id] DESC ");
		}
		/// <summary>
		/// 得到数据表DawnAuthUserExtent满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public List< DawnAuthUserExtentMDL> LSelect(string where,string sortField)
		{
			List< DawnAuthUserExtentMDL> list=new List< DawnAuthUserExtentMDL>();
			SqlParameter[] param={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
			param[0].Value=where;
			param[1].Value=sortField;
			string sqlCommand="DawnAuthUserExtentSelectByParams";
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
		/// 得到数据表DawnAuthUserExtent满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		public List< DawnAuthUserExtentMDL > LSelect(CommandType commandType,string sqlCommand,params SqlParameter[] param)
		{
			List< DawnAuthUserExtentMDL> list=new List< DawnAuthUserExtentMDL>();
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
		/// 得到数据表DawnAuthUserExtent所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public IList< DawnAuthUserExtentMDL> ISelect()
		{
			return this.ISelect(string.Empty);
		}
		/// <summary>
		/// 得到数据表DawnAuthUserExtent满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public IList< DawnAuthUserExtentMDL> ISelect(string where)
		{
			return this.ISelect(where," [ext_id] DESC ");
		}
		/// <summary>
		/// 得到数据表DawnAuthUserExtent满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public IList< DawnAuthUserExtentMDL> ISelect(string where,string sortField)
		{
			IList< DawnAuthUserExtentMDL> list=new List< DawnAuthUserExtentMDL>();
			SqlParameter[] param={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
			param[0].Value=where;
			param[1].Value=sortField;
			string sqlCommand="DawnAuthUserExtentSelectByParams";
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
		/// 得到数据表DawnAuthUserExtent满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		public IList< DawnAuthUserExtentMDL > ISelect(CommandType commandType,string sqlCommand,params SqlParameter[] param)
		{
			IList< DawnAuthUserExtentMDL> list=new List< DawnAuthUserExtentMDL>();
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
                		
		/// <summary>
		/// 得到数据表DawnAuthUserExtent满足查询条件的记录数
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="recordCount">记录数</param>
		public void Select(string where,out int recordCount)
		{
			string sqlCommand="DawnAuthUserExtentCountByWhere";
			SqlParameter[] param={
			new SqlParameter("@where",SqlDbType.VarChar,8000),
			new SqlParameter("@recordCount",SqlDbType.Int)
			};
			param[0].Value=where;
			param[1].Direction = ParameterDirection.Output;
			SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param);
			recordCount = Convert.ToInt32(param[1].Value);
		}		
		/// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="extId">系统编号</param>
        /// <returns>存在/不存在</returns>
		public bool Exists(int extId)
		{
			SqlParameter[] param={
            	new SqlParameter("@ExtId",SqlDbType.Int)
            };
            param[0].Value=extId;
            string sqlCommand="DawnAuthUserExtentIsExist";
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
            string sqlCommand="DawnAuthUserExtentIsExistByWhere";
            string val=SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
		}
		
		#endregion
				
        #endregion
    
	}
}
