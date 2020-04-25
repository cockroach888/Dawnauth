// =================================================================== 
// 业务逻辑（DawnXZ.Dawnauth.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthStatusBLL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年04月05日 23:39:42
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.Dawnauth.IDAL;
using DawnXZ.Dawnauth.DBFactory;

namespace DawnXZ.Dawnauth.BLL
{
    /// <summary>
    /// 业务逻辑层DawnAuthStatus
    /// </summary>
    public class DawnAuthStatusBLL
    {
		
		#region ---------变量定义-----------
		
		///<summary>
		///得到数据工厂
		///</summary>
		private static readonly IDawnAuthStatusDAL _dal = DALFactory.DawnAuthStatusDALInstance();
		
		#endregion ---------变量定义-----------
		
		#region ----------构造函数----------
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public DawnAuthStatusBLL()
		{ }
		
		#endregion ----------构造函数----------

        #region ---------函数定义-----------
				
		#region 数据实体
		
		/// <summary>
		/// 通过DataRow创建一个DawnAuthStatus实体对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>DawnAuthStatus实体对象</returns>
		public static DawnAuthStatusMDL Select(DataRow row)
		{
			return DawnAuthStatusBLL._dal.Select(row);
		}		
		/// <summary>
		/// 通过DataReader创建一个DawnAuthStatus实体对象
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>DawnAuthStatus实体对象</returns>
		public static DawnAuthStatusMDL Select(IDataReader dr)
		{
			return DawnAuthStatusBLL._dal.Select(dr);	
		}		
        /// <summary>
		/// 根据ID,返回一个DawnAuthStatus实体对象
		/// </summary>
		/// <param name="statId">系统编号</param>
		/// <returns>DawnAuthStatus实体对象</returns>
		public static DawnAuthStatusMDL Select(int statId)
		{
			return DawnAuthStatusBLL._dal.Select(statId);
		}
		
		#endregion
		
		#region 查询
		
        #region List
        
        /// <summary>
		/// 得到数据表DawnAuthStatus所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public static List< DawnAuthStatusMDL> LSelect()
		{
			return DawnAuthStatusBLL._dal.LSelect();
		}/// <summary>
		/// 得到数据表DawnAuthStatus满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public static List< DawnAuthStatusMDL> LSelect(string where)
		{
			return DawnAuthStatusBLL._dal.LSelect(where);
		}
		/// <summary>
		/// 得到数据表DawnAuthStatus满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public static List< DawnAuthStatusMDL> LSelect(string where, string sortField)
		{
			return DawnAuthStatusBLL._dal.LSelect(where,sortField);
		}
        
        #endregion
        
        #region IList
        
        /// <summary>
		/// 得到数据表DawnAuthStatus所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public static IList< DawnAuthStatusMDL> ISelect()
		{
			return DawnAuthStatusBLL._dal.ISelect();
		}/// <summary>
		/// 得到数据表DawnAuthStatus满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public static IList< DawnAuthStatusMDL> ISelect(string where)
		{
			return DawnAuthStatusBLL._dal.ISelect(where);
		}
		/// <summary>
		/// 得到数据表DawnAuthStatus满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public static IList< DawnAuthStatusMDL> ISelect(string where, string sortField)
		{
			return DawnAuthStatusBLL._dal.ISelect(where,sortField);
		}
        
        #endregion
        		
		/// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="statId">系统编号</param>
        /// <returns>存在/不存在</returns>
		public static bool Exists(int statId)
		{
			return DawnAuthStatusBLL._dal.Exists(statId);
		}
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
        public static bool Exists(string where)
        {
            return DawnAuthStatusBLL._dal.Exists(where);
        }
		
		#endregion
		
        #endregion ---------函数定义-----------
    
	}
}
