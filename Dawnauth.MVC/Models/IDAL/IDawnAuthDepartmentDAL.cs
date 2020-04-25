// =================================================================== 
// 产品规则（DawnXZ.Dawnauth.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IDawnAuthDepartmentDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:34:19
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
    /// 数据层DawnAuthDepartment接口
    /// </summary>
    public interface IDawnAuthDepartmentDAL : PagerInterface< DawnAuthDepartmentMDL>
    {
		
		#region 基本方法
		
        #region GetMaxId
        
        /// <summary>
        /// 获取当前最大系统编号
        /// </summary>
        /// <returns></returns>
        int GetMaxId();
        
        #endregion
        
		#region 添加
		
		/// <summary>
		/// 向数据表DawnAuthDepartment中插入一条新记录
		/// </summary>
		/// <param name="dawnAuthDepartment">DawnAuthDepartment实体对象</param>
		/// <param name="addFlag">添加标记：False  主分类，True 子分类</param>
		/// <returns></returns>
		int Insert(DawnAuthDepartmentMDL dawnAuthDepartment,bool addFlag);
		
		#endregion
		
		#region 修改
		
		/// <summary>
		/// 向数据表DawnAuthDepartment修改一条记录
		/// </summary>
		/// <param name="dawnAuthDepartment">DawnAuthDepartment实体</param>
		/// <returns></returns>
		int Update(DawnAuthDepartmentMDL dawnAuthDepartment);
		
		#endregion
		
		#region 点击率
		
		/// <summary>
		/// 向数据表DawnAuthDepartment更新点击率
		/// </summary>
		/// <param name="dptId">系统编号</param>
		/// <returns></returns>
		int UpdateClick(int dptId);	
		
		#endregion
		
		#region 数据统计
		
		/// <summary>
		/// 向数据表DawnAuthDepartment更新数据统计
		/// </summary>
		/// <param name="dptId">系统编号</param>
		/// <param name="countFlag">数据统计标记：0添加，1删除</param>
		/// <returns></returns>
		int UpdateCounts(int dptId,byte countFlag);
		/// <summary>
		/// 向数据表DawnAuthDepartment更新数据统计
		/// </summary>
		/// <param name="dptId">系统编号</param>
		/// <param name="countFlag">数据统计标记：0添加，1删除</param>
		/// <returns></returns>
		void UpdateCountAll(int dptId,byte countFlag);
        
		#endregion
		
		#region 变更
		
		/// <summary>
		/// 向数据表DawnAuthDepartment变更一条记录
		/// </summary>
		/// <param name="dptId">系统编号</param>
		/// <param name="dptFather">父标识</param>
		/// <returns></returns>
		int Change(int dptId,int dptFather);	
		
		#endregion
		
		#region 删除
		
		/// <summary>
		/// 删除数据表DawnAuthDepartment中的一条记录
		/// </summary>
	    /// <param name="dptId">系统编号</param>
		/// <param name="delFlag">删除标记：False  删除指定，True 删除所有</param>
		/// <returns></returns>
		int Delete(int dptId,bool delFlag);		
		/// <summary>
        /// 根据指定条件删除数据表DawnAuthDepartment中的记录
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        int DeleteWhere(string where);
        
		#endregion
		
		#region 实体对象
		
		/// <summary>
		/// 通过DataRow创建一个DawnAuthDepartment实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>DawnAuthDepartment实体</returns>
		DawnAuthDepartmentMDL Select(DataRow row);		
		/// <summary>
		/// 得到DawnAuthDepartment数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>DawnAuthDepartment数据实体</returns>
		DawnAuthDepartmentMDL Select(IDataReader dr);
		/// <summary>
		/// 根据ID,返回一个DawnAuthDepartment对象
		/// </summary>
		/// <param name="dptId">系统编号</param>
		/// <returns>DawnAuthDepartment</returns>
		DawnAuthDepartmentMDL Select(int dptId);
		
		#endregion
		
		#region 查询
		
        #region List
        
        /// <summary>
		/// 得到数据表DawnAuthDepartment所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		List< DawnAuthDepartmentMDL> LSelect();
        /// <summary>
        /// 得到数据表DawnAuthDepartment所有父模块记录
        /// </summary>
        /// <returns>数据实体</returns>
        List< DawnAuthDepartmentMDL> LSelectFather();
		/// <summary>
        /// 得到数据表DawnAuthDepartment满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
		List< DawnAuthDepartmentMDL> LSelect(string where);
		/// <summary>
        /// 得到数据表DawnAuthDepartment满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
		List< DawnAuthDepartmentMDL> LSelect(string where,string sortField);
        /// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		List< DawnAuthDepartmentMDL > LSelect(CommandType commandType,string sqlCommand,params SqlParameter[] param);
        
        #endregion
        
        #region IList
        
        /// <summary>
		/// 得到数据表DawnAuthDepartment所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< DawnAuthDepartmentMDL> ISelect();
        /// <summary>
        /// 得到数据表DawnAuthDepartment所有父模块记录
        /// </summary>
        /// <returns>数据实体</returns>
        IList< DawnAuthDepartmentMDL> ISelectFather();
		/// <summary>
        /// 得到数据表DawnAuthDepartment满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
		IList< DawnAuthDepartmentMDL> ISelect(string where);
		/// <summary>
        /// 得到数据表DawnAuthDepartment满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
		IList< DawnAuthDepartmentMDL> ISelect(string where,string sortField);
        /// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		IList< DawnAuthDepartmentMDL > ISelect(CommandType commandType,string sqlCommand,params SqlParameter[] param);
        
        #endregion
                		
		/// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件的记录数
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="recordCount">记录数</param>
		void Select(string where,out int recordCount);
        
        #region Exists
        
		/// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="dptId">系统编号</param>
        /// <returns>存在/不存在</returns>
		bool Exists(int dptId);
        /// <summary>
        /// 根据名称检测是否存在该条记录
        /// </summary>
        /// <param name="dptName">部门名称</param>
        /// <returns>存在/不存在</returns>
		bool Exists(string dptName);
        /// <summary>
        /// 根据点击检测是否存在该条记录
        /// </summary>
        /// <param name="dptClick">部门点击</param>
        /// <returns>存在/不存在</returns>
        bool ExistsOfClick(int dptClick);
        /// <summary>
        /// 根据父标识检测是否存在该条记录
        /// </summary>
        /// <param name="dptFather">部门标识</param>
        /// <returns>存在/不存在</returns>
		bool ExistsOfFather(int dptFather);
        /// <summary>
        /// 根据名称和父标识检测是否存在该条记录
        /// </summary>
        /// <param name="dptName">部门名称</param>
        /// <param name="dptFather">部门标识</param>
        /// <returns>存在/不存在</returns>
		bool Exists(string dptName,int dptFather);
        /// <summary>
        /// 根据编码检测是否存在该条记录
        /// </summary>
        /// <param name="dptCode">部门编码</param>
        /// <returns>存在/不存在</returns>
		bool ExistsOfCode(string dptCode);
		/// <summary>
        /// 根据识别码检测是否存在该条记录
        /// </summary>
        /// <param name="dptIdent">部门识别码</param>
        /// <returns>存在/不存在</returns>
		bool ExistsOfIdent(int dptIdent);
        /// <summary>
        /// 根据编码和识别码检测是否存在该条记录
        /// </summary>
        /// <param name="dptCode">部门编码</param>
        /// <param name="dptIdent">部门识别码</param>
        /// <returns>存在/不存在</returns>
		bool ExistsOfCodeIdent(string dptCode,int dptIdent);
        /// <summary>
        /// 根据名称和父标识及编码检测是否存在该条记录
        /// </summary>
        /// <param name="dptName">部门名称</param>
        /// <param name="dptFather">部门标识</param>
        /// <param name="dptCode">部门编码</param>
        /// <returns>存在/不存在</returns>
		bool Exists(string dptName,int dptFather,string dptCode);
        /// <summary>
        /// 根据名称和父标识、编码、识别码检测是否存在该条记录
        /// </summary>
        /// <param name="dptName">部门名称</param>
        /// <param name="dptFather">部门标识</param>
        /// <param name="dptCode">部门编码</param>
        /// <param name="dptIdent">部门识别码</param>
        /// <returns>存在/不存在</returns>
		bool Exists(string dptName,int dptFather,string dptCode,int dptIdent);
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
        bool ExistsOfWhere(string where);
        
        #endregion
        
		#endregion
				
        #endregion
		
    }
}
