// =================================================================== 
// 产品规则（DawnXZ.Dawnauth.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IDawnAuthFunctionDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 20:33:22
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DawnXZ.Dawnauth.Entity;

namespace DawnXZ.Dawnauth.IDAL
{
    /// <summary>
    /// 数据层DawnAuthFunction接口
    /// </summary>
    public partial interface IDawnAuthFunctionDAL : PagerInterface<DawnAuthFunctionMDL>
    {
		
		#region 基本方法

		#region 添加
		
		/// <summary>
		/// 向数据表DawnAuthFunction中插入一条新记录
		/// </summary>
		/// <param name="dawnAuthFunction">DawnAuthFunction实体</param>
		/// <returns></returns>
		int Insert(DawnAuthFunctionMDL dawnAuthFunction);
		
		/// <summary>
		/// 向数据表DawnAuthFunction中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="dawnAuthFunction">DawnAuthFunction实体</param>
		/// <returns></returns>
		int Insert(SqlTransaction sp,DawnAuthFunctionMDL dawnAuthFunction);
		
		#endregion
		
		#region 修改
		
		/// <summary>
		/// 向数据表DawnAuthFunction修改一条记录
		/// </summary>
		/// <param name="dawnAuthFunction">DawnAuthFunction实体</param>
		/// <returns></returns>
		int Update(DawnAuthFunctionMDL dawnAuthFunction);		
		
        /// <summary>
		/// 向数据表DawnAuthFunction修改一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="dawnAuthFunction">DawnAuthFunction实体</param>
		/// <returns></returns>
		int Update(SqlTransaction sp,DawnAuthFunctionMDL dawnAuthFunction);
		
		#endregion
		
		#region 删除
		
		/// <summary>
		/// 删除数据表DawnAuthFunction中的一条记录
		/// </summary>
	    /// <param name="funId">系统编号</param>
		/// <returns></returns>
		int Delete(int funId);		
		
        /// <summary>
		/// 删除数据表DawnAuthFunction中的一条记录
		/// </summary>
	    /// <param name="dawnAuthFunction">DawnAuthFunction实体</param>
		/// <returns></returns>
		int Delete(DawnAuthFunctionMDL dawnAuthFunction);		
		
        /// <summary>
		/// 删除数据表DawnAuthFunction中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="funId">系统编号</param>
		/// <returns></returns>
		int Delete(SqlTransaction sp,int funId);		
		
        /// <summary>
		/// 删除数据表DawnAuthFunction中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="dawnAuthFunction">DawnAuthFunction实体</param>
		/// <returns></returns>
		int Delete(SqlTransaction sp,DawnAuthFunctionMDL dawnAuthFunction);
		
        /// <summary>
        /// 根据指定条件删除数据表DawnAuthFunction中的记录
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        int DeleteWhere(string where);
        
		#endregion
		
		#region 实体对象
		
		/// <summary>
		/// 通过DataRow创建一个DawnAuthFunction实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>DawnAuthFunction实体</returns>
		DawnAuthFunctionMDL Select(DataRow row);		
		/// <summary>
		/// 得到DawnAuthFunction数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>DawnAuthFunction数据实体</returns>
		DawnAuthFunctionMDL Select(IDataReader dr);		        
		/// <summary>
		/// 根据ID,返回一个DawnAuthFunction对象
		/// </summary>
		/// <param name="funId">系统编号</param>
		/// <returns>DawnAuthFunction</returns>
		DawnAuthFunctionMDL Select(int funId);		
				
		#endregion
		
		#region 查询
		
        #region List
        
        /// <summary>
		/// 得到数据表DawnAuthFunction所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		List< DawnAuthFunctionMDL> LSelect();		
		/// <summary>
        /// 得到数据表DawnAuthFunction满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
		List< DawnAuthFunctionMDL> LSelect(string where);
		/// <summary>
        /// 得到数据表DawnAuthFunction满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
		List< DawnAuthFunctionMDL> LSelect(string where,string sortField);
        /// <summary>
		/// 得到数据表DawnAuthFunction满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		List< DawnAuthFunctionMDL > LSelect(CommandType commandType,string sqlCommand,params SqlParameter[] param);
        
        #endregion
        
        #region IList
        
        /// <summary>
		/// 得到数据表DawnAuthFunction所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< DawnAuthFunctionMDL> ISelect();		
		/// <summary>
        /// 得到数据表DawnAuthFunction满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
		IList< DawnAuthFunctionMDL> ISelect(string where);
		/// <summary>
        /// 得到数据表DawnAuthFunction满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
		IList< DawnAuthFunctionMDL> ISelect(string where,string sortField);
        /// <summary>
		/// 得到数据表DawnAuthFunction满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		IList< DawnAuthFunctionMDL > ISelect(CommandType commandType,string sqlCommand,params SqlParameter[] param);
        
        #endregion
                		
		/// <summary>
		/// 得到数据表DawnAuthFunction满足查询条件的记录数
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="recordCount">记录数</param>
		void Select(string where,out int recordCount);		
		/// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="funId">系统编号</param>
        /// <returns>存在/不存在</returns>
		bool Exists(int funId);
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
        bool Exists(string where);
		
		#endregion
				
        #endregion
		
    }
}
