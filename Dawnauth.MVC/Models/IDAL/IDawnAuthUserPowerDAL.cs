// =================================================================== 
// 产品规则（DawnXZ.Dawnauth.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IDawnAuthUserPowerDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 20:53:08
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
    /// 数据层DawnAuthUserPower接口
    /// </summary>
    public partial interface IDawnAuthUserPowerDAL : PagerInterface<DawnAuthUserPowerMDL>
    {
		
		#region 基本方法
		
		#region 添加
		
		/// <summary>
		/// 向数据表DawnAuthUserPower中插入一条新记录
		/// </summary>
		/// <param name="dawnAuthUserPower">DawnAuthUserPower实体</param>
		/// <returns></returns>
		int Insert(DawnAuthUserPowerMDL dawnAuthUserPower);
		
		/// <summary>
		/// 向数据表DawnAuthUserPower中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="dawnAuthUserPower">DawnAuthUserPower实体</param>
		/// <returns></returns>
		int Insert(SqlTransaction sp,DawnAuthUserPowerMDL dawnAuthUserPower);
		
		#endregion
		
		#region 修改

		/// <summary>
		/// 向数据表DawnAuthUserPower修改一条记录
		/// </summary>
		/// <param name="dawnAuthUserPower">DawnAuthUserPower实体</param>
		/// <returns></returns>
		int Update(DawnAuthUserPowerMDL dawnAuthUserPower);
		
        /// <summary>
		/// 向数据表DawnAuthUserPower修改一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="dawnAuthUserPower">DawnAuthUserPower实体</param>
		/// <returns></returns>
		int Update(SqlTransaction sp,DawnAuthUserPowerMDL dawnAuthUserPower);
		
		#endregion
		
		#region 删除
		
		/// <summary>
		/// 删除数据表DawnAuthUserPower中的一条记录
		/// </summary>
	    /// <param name="mapId">系统编号</param>
		/// <returns></returns>
		int Delete(int mapId);		
		
        /// <summary>
		/// 删除数据表DawnAuthUserPower中的一条记录
		/// </summary>
	    /// <param name="dawnAuthUserPower">DawnAuthUserPower实体</param>
		/// <returns></returns>
		int Delete(DawnAuthUserPowerMDL dawnAuthUserPower);		
		
        /// <summary>
		/// 删除数据表DawnAuthUserPower中的一条记录，带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="mapId">系统编号</param>
		/// <returns></returns>
		int Delete(SqlTransaction sp,int mapId);		
		
        /// <summary>
		/// 删除数据表DawnAuthUserPower中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="dawnAuthUserPower">DawnAuthUserPower实体</param>
		/// <returns></returns>
		int Delete(SqlTransaction sp,DawnAuthUserPowerMDL dawnAuthUserPower);
		
        /// <summary>
        /// 根据指定条件删除数据表DawnAuthUserPower中的记录
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        int DeleteWhere(string where);
        
		#endregion
		
		#region 实体对象
		
		/// <summary>
		/// 通过DataRow创建一个DawnAuthUserPower实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>DawnAuthUserPower实体</returns>
		DawnAuthUserPowerMDL Select(DataRow row);		
		/// <summary>
		/// 得到DawnAuthUserPower数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>DawnAuthUserPower数据实体</returns>
		DawnAuthUserPowerMDL Select(IDataReader dr);		        
		/// <summary>
		/// 根据ID,返回一个DawnAuthUserPower对象
		/// </summary>
		/// <param name="mapId">系统编号</param>
		/// <returns>DawnAuthUserPower</returns>
		DawnAuthUserPowerMDL Select(int mapId);		
				
		#endregion
		
		#region 查询
		
        #region List
        
        /// <summary>
		/// 得到数据表DawnAuthUserPower所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		List< DawnAuthUserPowerMDL> LSelect();		
		/// <summary>
        /// 得到数据表DawnAuthUserPower满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
		List< DawnAuthUserPowerMDL> LSelect(string where);
		/// <summary>
        /// 得到数据表DawnAuthUserPower满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
		List< DawnAuthUserPowerMDL> LSelect(string where,string sortField);
        /// <summary>
		/// 得到数据表DawnAuthUserPower满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		List< DawnAuthUserPowerMDL > LSelect(CommandType commandType,string sqlCommand,params SqlParameter[] param);
        
        #endregion
        
        #region IList
        
        /// <summary>
		/// 得到数据表DawnAuthUserPower所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< DawnAuthUserPowerMDL> ISelect();		
		/// <summary>
        /// 得到数据表DawnAuthUserPower满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
		IList< DawnAuthUserPowerMDL> ISelect(string where);
		/// <summary>
        /// 得到数据表DawnAuthUserPower满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
		IList< DawnAuthUserPowerMDL> ISelect(string where,string sortField);
        /// <summary>
		/// 得到数据表DawnAuthUserPower满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		IList< DawnAuthUserPowerMDL > ISelect(CommandType commandType,string sqlCommand,params SqlParameter[] param);
        
        #endregion
                		
		/// <summary>
		/// 得到数据表DawnAuthUserPower满足查询条件的记录数
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="recordCount">记录数</param>
		void Select(string where,out int recordCount);		
		/// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="mapId">系统编号</param>
        /// <returns>存在/不存在</returns>
		bool Exists(int mapId);
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
