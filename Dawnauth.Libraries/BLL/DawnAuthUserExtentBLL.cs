// =================================================================== 
// 业务逻辑（DawnXZ.Dawnauth.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthUserExtentBLL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:36:20
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
    /// 业务逻辑层DawnAuthUserExtent
    /// </summary>
    internal partial class DawnAuthUserExtentBLL
    {
		
		#region ---------变量定义-----------
		
		///<summary>
		///得到数据工厂
		///</summary>
		private static readonly IDawnAuthUserExtentDAL _dal = DALFactory.DawnAuthUserExtentDALInstance();
		
		#endregion ---------变量定义-----------
		
		#region ----------构造函数----------
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public DawnAuthUserExtentBLL()
		{ }
		
		#endregion ----------构造函数----------

        #region ---------函数定义-----------
		
		#region 添加
		
		/// <summary>
		/// 向数据表DawnAuthUserExtent中插入一条新记录
		/// </summary>
		/// <param name="dawnAuthUserExtent">DawnAuthUserExtent实体对象</param>
		/// <returns></returns>
		public static int Insert(DawnAuthUserExtentMDL dawnAuthUserExtent)
		{
			if (dawnAuthUserExtent == null)
				return 0;
			return DawnAuthUserExtentBLL._dal.Insert(dawnAuthUserExtent);
		}
		/// <summary>
		/// 向数据表DawnAuthUserExtent中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="dawnAuthUserExtent">DawnAuthUserExtent实体对象</param>
		/// <returns>ı</returns>
		public static int Insert(SqlTransaction sp,DawnAuthUserExtentMDL dawnAuthUserExtent)
		{
			if (dawnAuthUserExtent == null)
				return 0;
			return DawnAuthUserExtentBLL._dal.Insert(sp,dawnAuthUserExtent);
		}
		
		#endregion
		
		#region 修改
		
		/// <summary>
		/// 向数据表DawnAuthUserExtent修改一条记录
		/// </summary>
		/// <param name="dawnAuthUserExtent">DawnAuthUserExtent实体对象</param>
		/// <returns></returns>
		public  static int Update(DawnAuthUserExtentMDL dawnAuthUserExtent)
		{
			if (dawnAuthUserExtent==null)
				return 0; 
			return DawnAuthUserExtentBLL._dal.Update(dawnAuthUserExtent);
		}
		/// <summary>
		/// 向数据表DawnAuthUserExtent修改一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="dawnAuthUserExtent">DawnAuthUserExtent实体对象</param>
		/// <returns></returns>
		public static int Update(SqlTransaction sp,DawnAuthUserExtentMDL dawnAuthUserExtent)
		{
			if (dawnAuthUserExtent==null)
				return 0; 
			return DawnAuthUserExtentBLL._dal.Update(sp,dawnAuthUserExtent);
		}
		
		#endregion
		
		#region 删除
		
		/// <summary>
		/// 删除数据表DawnAuthUserExtent中的一条记录
		/// </summary>
	    /// <param name="extId">系统编号</param>
		/// <returns></returns>
		public static int Delete(int extId)
		{
			if(extId<0)
				return 0;
			return DawnAuthUserExtentBLL._dal.Delete(extId);
		}
		/// <summary>
		/// 删除数据表DawnAuthUserExtent中的一条记录
		/// </summary>
	    /// <param name="dawnAuthUserExtent">DawnAuthUserExtent实体对象</param>
		/// <returns></returns>
		public static int Delete(DawnAuthUserExtentMDL dawnAuthUserExtent)
		{
			return DawnAuthUserExtentBLL._dal.Delete(dawnAuthUserExtent);
		}		
		/// <summary>
		/// 删除数据表DawnAuthUserExtent中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
        /// <param name="extId">系统编号</param>
		/// <returns></returns>
        public static int Delete(SqlTransaction sp, int extId)
		{
			if(extId<0)
				return 0;
			return DawnAuthUserExtentBLL._dal.Delete(sp,extId);
		}
		/// <summary>
		/// 删除数据表DawnAuthUserExtent中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="dawnAuthUserExtent">DawnAuthUserExtent实体对象</param>
		/// <returns></returns>
		public int Delete(SqlTransaction sp,DawnAuthUserExtentMDL dawnAuthUserExtent)
		{
			return DawnAuthUserExtentBLL._dal.Delete(sp,dawnAuthUserExtent);
		}
        /// <summary>
        /// 根据指定条件删除数据表DawnAuthUserExtent中的记录
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        public static int DeleteWhere(string where)
        {
            return DawnAuthUserExtentBLL._dal.DeleteWhere(where);
        }
		
		#endregion
		
		#region 数据实体
		
		/// <summary>
		/// 通过DataRow创建一个DawnAuthUserExtent实体对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>DawnAuthUserExtent实体对象</returns>
		public static DawnAuthUserExtentMDL Select(DataRow row)
		{
			return DawnAuthUserExtentBLL._dal.Select(row);
		}		
		/// <summary>
		/// 通过DataReader创建一个DawnAuthUserExtent实体对象
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>DawnAuthUserExtent实体对象</returns>
		public static DawnAuthUserExtentMDL Select(IDataReader dr)
		{
			return DawnAuthUserExtentBLL._dal.Select(dr);	
		}		
        /// <summary>
		/// 根据ID,返回一个DawnAuthUserExtent实体对象
		/// </summary>
		/// <param name="extId">系统编号</param>
		/// <returns>DawnAuthUserExtent实体对象</returns>
		public static DawnAuthUserExtentMDL Select(int extId)
		{
			return DawnAuthUserExtentBLL._dal.Select(extId);
		}
		
		#endregion
		
		#region 查询
		
        #region List
        
        /// <summary>
		/// 得到数据表DawnAuthUserExtent所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public static List< DawnAuthUserExtentMDL> LSelect()
		{
			return DawnAuthUserExtentBLL._dal.LSelect();
		}/// <summary>
		/// 得到数据表DawnAuthUserExtent满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public static List< DawnAuthUserExtentMDL> LSelect(string where)
		{
			return DawnAuthUserExtentBLL._dal.LSelect(where);
		}
		/// <summary>
		/// 得到数据表DawnAuthUserExtent满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public static List< DawnAuthUserExtentMDL> LSelect(string where, string sortField)
		{
			return DawnAuthUserExtentBLL._dal.LSelect(where,sortField);
		}
        /// <summary>
		/// 得到数据表DawnAuthUserExtent满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		public static List< DawnAuthUserExtentMDL > LSelect(CommandType commandType,string sqlCommand,params SqlParameter[] param)
		{
			return DawnAuthUserExtentBLL._dal.LSelect(commandType,sqlCommand,param);
		}
        
        #endregion
        
        #region IList
        
        /// <summary>
		/// 得到数据表DawnAuthUserExtent所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public static IList< DawnAuthUserExtentMDL> ISelect()
		{
			return DawnAuthUserExtentBLL._dal.ISelect();
		}/// <summary>
		/// 得到数据表DawnAuthUserExtent满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public static IList< DawnAuthUserExtentMDL> ISelect(string where)
		{
			return DawnAuthUserExtentBLL._dal.ISelect(where);
		}
		/// <summary>
		/// 得到数据表DawnAuthUserExtent满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public static IList< DawnAuthUserExtentMDL> ISelect(string where, string sortField)
		{
			return DawnAuthUserExtentBLL._dal.ISelect(where,sortField);
		}
        /// <summary>
		/// 得到数据表DawnAuthUserExtent满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		public static IList< DawnAuthUserExtentMDL > ISelect(CommandType commandType,string sqlCommand,params SqlParameter[] param)
		{
			return DawnAuthUserExtentBLL._dal.ISelect(commandType,sqlCommand,param);
		}
        
        #endregion
                		
		/// <summary>
		/// 得到数据表DawnAuthUserExtent满足查询条件的记录数
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="recordCount">记录数</param>
		public static void Select(string where,out int recordCount)
		{
			DawnAuthUserExtentBLL._dal.Select(where,out recordCount);
		}		
		/// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="extId">系统编号</param>
        /// <returns>存在/不存在</returns>
		public static bool Exists(int extId)
		{
			return DawnAuthUserExtentBLL._dal.Exists(extId);
		}
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
        public static bool Exists(string where)
        {
            return DawnAuthUserExtentBLL._dal.Exists(where);
        }
		
		#endregion
				
        #endregion ---------函数定义-----------
    
	}
}
