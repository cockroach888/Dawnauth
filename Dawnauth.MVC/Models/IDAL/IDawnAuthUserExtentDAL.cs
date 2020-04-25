// =================================================================== 
// 产品规则（DawnXZ.Dawnauth.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IDawnAuthUserExtentDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:36:00
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
    /// 数据层DawnAuthUserExtent接口
    /// </summary>
    public partial interface IDawnAuthUserExtentDAL : PagerInterface< DawnAuthUserExtentMDL>
    {
		
		#region 基本方法
		
		#region 添加
		
		/// <summary>
		/// 向数据表DawnAuthUserExtent中插入一条新记录
		/// </summary>
		/// <param name="dawnAuthUserExtent">DawnAuthUserExtent实体</param>
		/// <returns></returns>
		int Insert(DawnAuthUserExtentMDL dawnAuthUserExtent);
		
		/// <summary>
		/// 向数据表DawnAuthUserExtent中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="dawnAuthUserExtent">DawnAuthUserExtent实体</param>
		/// <returns></returns>
		int Insert(SqlTransaction sp,DawnAuthUserExtentMDL dawnAuthUserExtent);
		
		#endregion
		
		#region 修改
		
		/// <summary>
		/// 向数据表DawnAuthUserExtent修改一条记录
		/// </summary>
		/// <param name="dawnAuthUserExtent">DawnAuthUserExtent实体</param>
		/// <returns></returns>
		int Update(DawnAuthUserExtentMDL dawnAuthUserExtent);		
		
        /// <summary>
		/// 向数据表DawnAuthUserExtent修改一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="dawnAuthUserExtent">DawnAuthUserExtent实体</param>
		/// <returns></returns>
		int Update(SqlTransaction sp,DawnAuthUserExtentMDL dawnAuthUserExtent);
		
		#endregion
		
		#region 删除
		
		/// <summary>
		/// 删除数据表DawnAuthUserExtent中的一条记录
		/// </summary>
	    /// <param name="extId">系统编号</param>
		/// <returns></returns>
		int Delete(int extId);		
		
        /// <summary>
		/// 删除数据表DawnAuthUserExtent中的一条记录
		/// </summary>
	    /// <param name="dawnAuthUserExtent">DawnAuthUserExtent实体</param>
		/// <returns></returns>
		int Delete(DawnAuthUserExtentMDL dawnAuthUserExtent);		
		
        /// <summary>
		/// 删除数据表DawnAuthUserExtent中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="extId">系统编号</param>
		/// <returns></returns>
		int Delete(SqlTransaction sp,int extId);		
		
        /// <summary>
		/// 删除数据表DawnAuthUserExtent中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="dawnAuthUserExtent">DawnAuthUserExtent实体</param>
		/// <returns></returns>
		int Delete(SqlTransaction sp,DawnAuthUserExtentMDL dawnAuthUserExtent);
		
        /// <summary>
        /// 根据指定条件删除数据表DawnAuthUserExtent中的记录
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        int DeleteWhere(string where);
        
		#endregion
		
		#region 实体对象
		
		/// <summary>
		/// 通过DataRow创建一个DawnAuthUserExtent实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>DawnAuthUserExtent实体</returns>
		DawnAuthUserExtentMDL Select(DataRow row);		
		/// <summary>
		/// 得到DawnAuthUserExtent数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>DawnAuthUserExtent数据实体</returns>
		DawnAuthUserExtentMDL Select(IDataReader dr);		        
		/// <summary>
		/// 根据ID,返回一个DawnAuthUserExtent对象
		/// </summary>
		/// <param name="extId">系统编号</param>
		/// <returns>DawnAuthUserExtent</returns>
		DawnAuthUserExtentMDL Select(int extId);		
				
		#endregion
		
		#region 查询
		
        #region List
        
        /// <summary>
		/// 得到数据表DawnAuthUserExtent所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		List< DawnAuthUserExtentMDL> LSelect();		
		/// <summary>
        /// 得到数据表DawnAuthUserExtent满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
		List< DawnAuthUserExtentMDL> LSelect(string where);
		/// <summary>
        /// 得到数据表DawnAuthUserExtent满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
		List< DawnAuthUserExtentMDL> LSelect(string where,string sortField);
        /// <summary>
		/// 得到数据表DawnAuthUserExtent满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		List< DawnAuthUserExtentMDL > LSelect(CommandType commandType,string sqlCommand,params SqlParameter[] param);
        
        #endregion
        
        #region IList
        
        /// <summary>
		/// 得到数据表DawnAuthUserExtent所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< DawnAuthUserExtentMDL> ISelect();		
		/// <summary>
        /// 得到数据表DawnAuthUserExtent满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
		IList< DawnAuthUserExtentMDL> ISelect(string where);
		/// <summary>
        /// 得到数据表DawnAuthUserExtent满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
		IList< DawnAuthUserExtentMDL> ISelect(string where,string sortField);
        /// <summary>
		/// 得到数据表DawnAuthUserExtent满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		IList< DawnAuthUserExtentMDL > ISelect(CommandType commandType,string sqlCommand,params SqlParameter[] param);
        
        #endregion
                		
		/// <summary>
		/// 得到数据表DawnAuthUserExtent满足查询条件的记录数
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="recordCount">记录数</param>
		void Select(string where,out int recordCount);		
		/// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="extId">系统编号</param>
        /// <returns>存在/不存在</returns>
		bool Exists(int extId);
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
