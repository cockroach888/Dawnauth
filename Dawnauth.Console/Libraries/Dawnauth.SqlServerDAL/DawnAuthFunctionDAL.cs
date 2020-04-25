// =================================================================== 
// 产品（DawnXZ.Dawnauth.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthFunctionDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年04月05日 23:01:54
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
    /// 数据访问层DawnAuthFunction
    /// </summary>
    public partial class DawnAuthFunctionDAL : IDawnAuthFunctionDAL
    {
		
		#region 构造函数
		
		/// <summary>
		/// 数据层实例化
		/// </summary>
		public DawnAuthFunctionDAL()
		{ }
		
		#endregion

        #region -----------实例化接口函数-----------

		#region 实体对象
		
		/// <summary>
		/// 得到DawnAuthFunction实体对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>DawnAuthFunction实体对象</returns>
		public DawnAuthFunctionMDL Select(DataRow row)
		{
			DawnAuthFunctionMDL obj = new DawnAuthFunctionMDL();
			if(row!=null)
			{
				try
				{
					obj.FunId = (( row["fun_id"])==DBNull.Value)?0:Convert.ToInt32( row["fun_id"]);
				}
				catch { }
				try
				{
					obj.MdlId = (( row["mdl_id"])==DBNull.Value)?0:Convert.ToInt32( row["mdl_id"]);
				}
				catch { }
				try
				{
					obj.FunTime = (( row["fun_time"])==DBNull.Value)?DateTime.MinValue:Convert.ToDateTime( row["fun_time"]);
				}
				catch { }
				try
				{
					obj.FunName =  row["fun_name"].ToString();
				}
				catch { }
				try
				{
					obj.FunCode =  row["fun_code"].ToString();
				}
				catch { }
				try
				{
					obj.FunIdent = (( row["fun_ident"])==DBNull.Value)?0:Convert.ToInt32( row["fun_ident"]);
				}
				catch { }
				try
				{
					obj.FunMark = (( row["fun_mark"])==DBNull.Value)?0:Convert.ToInt32( row["fun_mark"]);
				}
				catch { }
				try
				{
					obj.FunParentMark = (( row["fun_parent_mark"])==DBNull.Value)?0:Convert.ToInt32( row["fun_parent_mark"]);
				}
				catch { }
				try
				{
					obj.FunDesc =  row["fun_desc"].ToString();
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
		/// 得到DawnAuthFunction实体对象
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>DawnAuthFunctions实体对象</returns>
		public DawnAuthFunctionMDL Select(IDataReader dr)
		{
			DawnAuthFunctionMDL obj = new DawnAuthFunctionMDL();
			try
			{
				obj.FunId = (( dr["fun_id"])==DBNull.Value)?0:Convert.ToInt32( dr["fun_id"]);
			}
			catch { }
			try
			{
				obj.MdlId = (( dr["mdl_id"])==DBNull.Value)?0:Convert.ToInt32( dr["mdl_id"]);
			}
			catch { }
			try
			{
				obj.FunTime = (( dr["fun_time"])==DBNull.Value)?DateTime.MinValue:Convert.ToDateTime( dr["fun_time"]);
			}
			catch { }
			try
			{
				obj.FunName =  dr["fun_name"].ToString();
			}
			catch { }
			try
			{
				obj.FunCode =  dr["fun_code"].ToString();
			}
			catch { }
			try
			{
				obj.FunIdent = (( dr["fun_ident"])==DBNull.Value)?0:Convert.ToInt32( dr["fun_ident"]);
			}
			catch { }
			try
			{
				obj.FunMark = (( dr["fun_mark"])==DBNull.Value)?0:Convert.ToInt32( dr["fun_mark"]);
			}
			catch { }
			try
			{
				obj.FunParentMark = (( dr["fun_parent_mark"])==DBNull.Value)?0:Convert.ToInt32( dr["fun_parent_mark"]);
			}
			catch { }
			try
			{
				obj.FunDesc =  dr["fun_desc"].ToString();
			}
			catch { }
			return obj;
		}
		/// <summary>
		/// 根据ID,返回一个DawnAuthFunction实体对象
		/// </summary>
		/// <param name="funId">系统编号</param>
		/// <returns>DawnAuthFunction实体对象</returns>
		public DawnAuthFunctionMDL Select(int funId)
		{
			DawnAuthFunctionMDL obj=null;
			SqlParameter[] param={
			new SqlParameter("@FunId",SqlDbType.Int)
			};
			param[0].Value=funId;
			string sqlCommand="DawnAuthFunctionSelect";
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
		/// 得到数据表DawnAuthFunction所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public List< DawnAuthFunctionMDL> LSelect()
		{
			return this.LSelect(string.Empty);
		}
		/// <summary>
		/// 得到数据表DawnAuthFunction满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public List< DawnAuthFunctionMDL> LSelect(string where)
		{
			return this.LSelect(where," [fun_id] DESC ");
		}
		/// <summary>
		/// 得到数据表DawnAuthFunction满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public List< DawnAuthFunctionMDL> LSelect(string where,string sortField)
		{
			List< DawnAuthFunctionMDL> list=new List< DawnAuthFunctionMDL>();
			SqlParameter[] param={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
			param[0].Value=where;
			param[1].Value=sortField;
			string sqlCommand="DawnAuthFunctionSelectByParams";
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
		/// 得到数据表DawnAuthFunction所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public IList< DawnAuthFunctionMDL> ISelect()
		{
			return this.ISelect(string.Empty);
		}
		/// <summary>
		/// 得到数据表DawnAuthFunction满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public IList< DawnAuthFunctionMDL> ISelect(string where)
		{
			return this.ISelect(where," [fun_id] DESC ");
		}
		/// <summary>
		/// 得到数据表DawnAuthFunction满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public IList< DawnAuthFunctionMDL> ISelect(string where,string sortField)
		{
			IList< DawnAuthFunctionMDL> list=new List< DawnAuthFunctionMDL>();
			SqlParameter[] param={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
			param[0].Value=where;
			param[1].Value=sortField;
			string sqlCommand="DawnAuthFunctionSelectByParams";
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
        /// <param name="funId">系统编号</param>
        /// <returns>存在/不存在</returns>
		public bool Exists(int funId)
		{
			SqlParameter[] param={
            	new SqlParameter("@FunId",SqlDbType.Int)
            };
            param[0].Value=funId;
            string sqlCommand="DawnAuthFunctionIsExist";
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
            string sqlCommand="DawnAuthFunctionIsExistByWhere";
            string val=SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
		}
		
		#endregion
		
        #endregion
    
	}
}
