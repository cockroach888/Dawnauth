// =================================================================== 
// 产品（DawnXZ.Dawnauth.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthUserPowerDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年04月05日 23:29:33
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
    /// 数据访问层DawnAuthUserPower
    /// </summary>
    internal partial class DawnAuthUserPowerDAL : IDawnAuthUserPowerDAL
    {
		
		#region 构造函数
		
		/// <summary>
		/// 数据层实例化
		/// </summary>
		public DawnAuthUserPowerDAL()
		{ }
		
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 实体对象
		
		/// <summary>
		/// 得到DawnAuthUserPower实体对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>DawnAuthUserPower实体对象</returns>
		public DawnAuthUserPowerMDL Select(DataRow row)
		{
			DawnAuthUserPowerMDL obj = new DawnAuthUserPowerMDL();
			if(row!=null)
			{
				try
				{
					obj.MapId = (( row["map_id"])==DBNull.Value)?0:Convert.ToInt32( row["map_id"]);
				}
				catch { }
				try
				{
					obj.UserId = (( row["user_id"])==DBNull.Value)?0:Convert.ToInt32( row["user_id"]);
				}
				catch { }
				try
				{
					obj.MapTime = (( row["map_time"])==DBNull.Value)?DateTime.MinValue:Convert.ToDateTime( row["map_time"]);
				}
				catch { }
				try
				{
					obj.MapModule = (( row["map_module"])==DBNull.Value)?0:Convert.ToInt32( row["map_module"]);
				}
				catch { }
				try
				{
					obj.MapFunction =  row["map_function"].ToString();
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
		/// 得到DawnAuthUserPower实体对象
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>DawnAuthUserPowers实体对象</returns>
		public DawnAuthUserPowerMDL Select(IDataReader dr)
		{
			DawnAuthUserPowerMDL obj = new DawnAuthUserPowerMDL();
			try
			{
				obj.MapId = (( dr["map_id"])==DBNull.Value)?0:Convert.ToInt32( dr["map_id"]);
			}
			catch { }
			try
			{
				obj.UserId = (( dr["user_id"])==DBNull.Value)?0:Convert.ToInt32( dr["user_id"]);
			}
			catch { }
			try
			{
				obj.MapTime = (( dr["map_time"])==DBNull.Value)?DateTime.MinValue:Convert.ToDateTime( dr["map_time"]);
			}
			catch { }
			try
			{
				obj.MapModule = (( dr["map_module"])==DBNull.Value)?0:Convert.ToInt32( dr["map_module"]);
			}
			catch { }
			try
			{
				obj.MapFunction =  dr["map_function"].ToString();
			}
			catch { }
			return obj;
		}
		/// <summary>
		/// 根据ID,返回一个DawnAuthUserPower实体对象
		/// </summary>
		/// <param name="mapId">系统编号</param>
		/// <returns>DawnAuthUserPower实体对象</returns>
		public DawnAuthUserPowerMDL Select(int mapId)
		{
			DawnAuthUserPowerMDL obj=null;
			SqlParameter[] param={
			new SqlParameter("@MapId",SqlDbType.Int)
			};
			param[0].Value=mapId;
			string sqlCommand="DawnAuthUserPowerSelect";
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
		/// 得到数据表DawnAuthUserPower所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public List< DawnAuthUserPowerMDL> LSelect()
		{
			return this.LSelect(string.Empty);
		}
		/// <summary>
		/// 得到数据表DawnAuthUserPower满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public List< DawnAuthUserPowerMDL> LSelect(string where)
		{
			return this.LSelect(where," [map_id] DESC ");
		}
		/// <summary>
		/// 得到数据表DawnAuthUserPower满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public List< DawnAuthUserPowerMDL> LSelect(string where,string sortField)
		{
			List< DawnAuthUserPowerMDL> list=new List< DawnAuthUserPowerMDL>();
			SqlParameter[] param={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
			param[0].Value=where;
			param[1].Value=sortField;
			string sqlCommand="DawnAuthUserPowerSelectByParams";
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
		/// 得到数据表DawnAuthUserPower所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public IList< DawnAuthUserPowerMDL> ISelect()
		{
			return this.ISelect(string.Empty);
		}
		/// <summary>
		/// 得到数据表DawnAuthUserPower满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public IList< DawnAuthUserPowerMDL> ISelect(string where)
		{
			return this.ISelect(where," [map_id] DESC ");
		}
		/// <summary>
		/// 得到数据表DawnAuthUserPower满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public IList< DawnAuthUserPowerMDL> ISelect(string where,string sortField)
		{
			IList< DawnAuthUserPowerMDL> list=new List< DawnAuthUserPowerMDL>();
			SqlParameter[] param={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
			param[0].Value=where;
			param[1].Value=sortField;
			string sqlCommand="DawnAuthUserPowerSelectByParams";
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
        /// <param name="mapId">系统编号</param>
        /// <returns>存在/不存在</returns>
		public bool Exists(int mapId)
		{
			SqlParameter[] param={
            	new SqlParameter("@MapId",SqlDbType.Int)
            };
            param[0].Value=mapId;
            string sqlCommand="DawnAuthUserPowerIsExist";
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
            string sqlCommand="DawnAuthUserPowerIsExistByWhere";
            string val=SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
		}
		
		#endregion
		
        #endregion
    
	}
}
