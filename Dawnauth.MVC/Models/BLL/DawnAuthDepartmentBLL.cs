// =================================================================== 
// 业务逻辑（DawnXZ.Dawnauth.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthDepartmentBLL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:34:27
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
    /// 业务逻辑层DawnAuthDepartment
    /// </summary>
    public class DawnAuthDepartmentBLL
    {
		
		#region ---------变量定义-----------
		
		///<summary>
		///得到数据工厂
		///</summary>
		private static readonly IDawnAuthDepartmentDAL _dal = DALFactory.DawnAuthDepartmentDALInstance();
		
		#endregion
		
		#region ----------构造函数----------
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public DawnAuthDepartmentBLL()
		{ }
		
		#endregion

        #region ---------函数定义-----------
		
        #region GetMaxId
        /// <summary>
        /// 获取当前最大系统编号
        /// </summary>
        /// <returns></returns>
        public static int GetMaxId()
        {
            return DawnAuthDepartmentBLL._dal.GetMaxId();
        }
        #endregion
        
		#region 添加
		
		/// <summary>
		/// 向数据表DawnAuthDepartment中插入一条新记录
		/// </summary>
		/// <param name="dawnAuthDepartment">DawnAuthDepartment实体对象</param>
		/// <param name="addFlag">添加标记：False  主分类，True 子分类</param>
		/// <returns></returns>
		public static int Insert(DawnAuthDepartmentMDL dawnAuthDepartment,bool addFlag)
		{
			if (dawnAuthDepartment == null) return 0;
			return DawnAuthDepartmentBLL._dal.Insert(dawnAuthDepartment,addFlag);
		}
		
		#endregion
		
		#region 修改
		
		/// <summary>
		/// 向数据表DawnAuthDepartment修改一条记录
		/// </summary>
		/// <param name="dawnAuthDepartment">dawnAuthDepartment实体对象</param>
		/// <returns></returns>
		public  static int Update(DawnAuthDepartmentMDL dawnAuthDepartment)
		{
			if (dawnAuthDepartment==null) return 0; 
			return DawnAuthDepartmentBLL._dal.Update(dawnAuthDepartment);
		}
		
		#endregion
		
		#region 点击率
		
		/// <summary>
		/// 向数据表DawnAuthDepartment更新点击率
		/// </summary>
		/// <param name="dptId">系统编号</param>
		/// <returns></returns>
		public static int UpdateClick(int dptId)
		{
			if (dptId<0) return 0;
			return DawnAuthDepartmentBLL._dal.UpdateClick(dptId);
		}
		
		#endregion
		
		#region 数据统计
		
		/// <summary>
		/// 向数据表DawnAuthDepartment更新数据统计
		/// </summary>
		/// <param name="dptId">系统编号</param>
		/// <param name="countFlag">数据统计标记：0添加，1删除</param>
		/// <returns></returns>
		public static int UpdateCounts(int dptId,byte countFlag)
		{
			if (dptId<0) return 0; 
			return DawnAuthDepartmentBLL._dal.UpdateCounts(dptId,countFlag);
		}
        /// <summary>
		/// 向数据表DawnAuthDepartment更新数据统计
		/// </summary>
		/// <param name="dptId">系统编号</param>
		/// <param name="countFlag">数据统计标记：0添加，1删除</param>
		/// <returns></returns>
		public static void UpdateCountAll(int dptId,byte countFlag)
		{
			if (dptId<0) return; 
			DawnAuthDepartmentBLL._dal.UpdateCountAll(dptId,countFlag);
		}
		
		#endregion
		
		#region 变更
		
		/// <summary>
		/// 向数据表DawnAuthDepartment变更一条记录
		/// </summary>
		/// <param name="dptId">系统编号</param>
		/// <param name="dptFather">父标识</param>
		/// <returns></returns>
		public  static int Change(int dptId,int dptFather)
		{
			if (dptId<0) return 0; 
			return DawnAuthDepartmentBLL._dal.Change(dptId,dptFather);
		}
		
		#endregion
		
		#region 删除
		
		/// <summary>
		/// 删除数据表DawnAuthDepartment中的一条记录
		/// </summary>
	    /// <param name="dptId">系统编号</param>
		/// <param name="delFlag">删除标记：False  删除指定，True 删除所有</param>
		/// <returns></returns>
		public static int Delete(int dptId,bool delFlag)
		{
			if (dptId<0) return 0; 
			return DawnAuthDepartmentBLL._dal.Delete(dptId,delFlag);
		}
        /// <summary>
        /// 根据指定条件删除数据表DawnAuthDepartment中的记录
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        public static int DeleteWhere(string where)
        {
            return DawnAuthDepartmentBLL._dal.DeleteWhere(where);
        }
		
		#endregion
		
		#region 实体对象
		
		/// <summary>
		/// 通过DataRow创建一个DawnAuthDepartment实体对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>DawnAuthDepartment实体对象</returns>
		public static DawnAuthDepartmentMDL Select(DataRow row)
		{
			return DawnAuthDepartmentBLL._dal.Select(row);
		}		
		/// <summary>
		/// 通过DataReader创建一个DawnAuthDepartment实体对象
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>DawnAuthDepartment实体对象</returns>
		public static DawnAuthDepartmentMDL Select(IDataReader dr)
		{
			return DawnAuthDepartmentBLL._dal.Select(dr);
		}
		/// <summary>
		/// 根据ID,返回一个DawnAuthDepartment实体对象
		/// </summary>
		/// <param name="dptId">系统编号</param>
		/// <returns>DawnAuthDepartment实体对象</returns>
		public static DawnAuthDepartmentMDL Select(int dptId)
		{
			return DawnAuthDepartmentBLL._dal.Select(dptId);
		}
		
		#endregion
		
		#region 查询
		
        #region List
        
        /// <summary>
		/// 得到数据表DawnAuthDepartment所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public static List< DawnAuthDepartmentMDL> LSelect()
		{
			return DawnAuthDepartmentBLL._dal.LSelect();
		}
        /// <summary>
        /// 得到数据表DawnAuthDepartment所有父记录
        /// </summary>
        /// <returns>结果集</returns>
        public static List< DawnAuthDepartmentMDL> LSelectFather()
        {
            return DawnAuthDepartmentBLL._dal.LSelectFather();
        }
		/// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public static List< DawnAuthDepartmentMDL> LSelect(string where)
		{
			return DawnAuthDepartmentBLL._dal.LSelect(where);
		}
		/// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public static List< DawnAuthDepartmentMDL> LSelect(string where, string sortField)
		{
			return DawnAuthDepartmentBLL._dal.LSelect(where,sortField);
		}
        /// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		public static List< DawnAuthDepartmentMDL > LSelect(CommandType commandType,string sqlCommand,params SqlParameter[] param)
		{
			return DawnAuthDepartmentBLL._dal.LSelect(commandType,sqlCommand,param);
		}
        
        #endregion
        
        #region IList
        
        /// <summary>
		/// 得到数据表DawnAuthDepartment所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public static IList< DawnAuthDepartmentMDL> ISelect()
		{
			return DawnAuthDepartmentBLL._dal.ISelect();
		}
        /// <summary>
        /// 得到数据表DawnAuthDepartment所有父记录
        /// </summary>
        /// <returns>结果集</returns>
        public static IList< DawnAuthDepartmentMDL> ISelectFather()
        {
            return DawnAuthDepartmentBLL._dal.ISelectFather();
        }
		/// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public static IList< DawnAuthDepartmentMDL> ISelect(string where)
		{
			return DawnAuthDepartmentBLL._dal.ISelect(where);
		}
		/// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public static IList< DawnAuthDepartmentMDL> ISelect(string where, string sortField)
		{
			return DawnAuthDepartmentBLL._dal.ISelect(where,sortField);
		}
        /// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		public static IList< DawnAuthDepartmentMDL > ISelect(CommandType commandType,string sqlCommand,params SqlParameter[] param)
		{
			return DawnAuthDepartmentBLL._dal.ISelect(commandType,sqlCommand,param);
		}
        
        #endregion
                		
		/// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件的记录数
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="recordCount">记录数</param>
		public static void Select(string where,out int recordCount)
		{
			DawnAuthDepartmentBLL._dal.Select(where,out recordCount);
		}
        
        #region Exists
        
		/// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="dptId">系统编号</param>
        /// <returns>存在/不存在</returns>
		public static bool Exists(int dptId)
		{
			return DawnAuthDepartmentBLL._dal.Exists(dptId);
		}
        /// <summary>
        /// 根据名称检测是否存在该条记录
        /// </summary>
        /// <param name="dptName">部门名称</param>
        /// <returns>存在/不存在</returns>
		public static bool Exists(string dptName)
        {
            return DawnAuthDepartmentBLL._dal.Exists(dptName);
        }
        /// <summary>
        /// 根据点击检测是否存在该条记录
        /// </summary>
        /// <param name="dptClick">部门点击</param>
        /// <returns>存在/不存在</returns>
        public static bool ExistsOfClick(int dptClick)
        {
            return DawnAuthDepartmentBLL._dal.ExistsOfClick(dptClick);
        }
        /// <summary>
        /// 根据父标识检测是否存在该条记录
        /// </summary>
        /// <param name="dptFather">部门标识</param>
        /// <returns>存在/不存在</returns>
		public static bool ExistsOfFather(int dptFather)
        {
            return DawnAuthDepartmentBLL._dal.ExistsOfFather(dptFather);
        }
        /// <summary>
        /// 根据名称和父标识检测是否存在该条记录
        /// </summary>
        /// <param name="dptName">部门名称</param>
        /// <param name="dptFather">部门标识</param>
        /// <returns>存在/不存在</returns>
		public static bool Exists(string dptName,int dptFather)
        {
            return DawnAuthDepartmentBLL._dal.Exists(dptName,dptFather);
        }
        /// <summary>
        /// 根据编码检测是否存在该条记录
        /// </summary>
        /// <param name="dptCode">部门编码</param>
        /// <returns>存在/不存在</returns>
		public static bool ExistsOfCode(string dptCode)
        {
            return DawnAuthDepartmentBLL._dal.ExistsOfCode(dptCode);
        }
        /// <summary>
        /// 根据识别码检测是否存在该条记录
        /// </summary>
        /// <param name="dptIdent">部门识别码</param>
        /// <returns>存在/不存在</returns>
		public static bool ExistsOfIdent(int dptIdent)
        {
            return DawnAuthDepartmentBLL._dal.ExistsOfIdent(dptIdent);
        }
        /// <summary>
        /// 根据编码和识别码检测是否存在该条记录
        /// </summary>
        /// <param name="dptCode">部门编码</param>
        /// <param name="dptIdent">部门识别码</param>
        /// <returns>存在/不存在</returns>
		public static bool ExistsOfCodeIdent(string dptCode,int dptIdent)
        {
            return DawnAuthDepartmentBLL._dal.ExistsOfCodeIdent(dptCode,dptIdent);
        }
        /// <summary>
        /// 根据名称和父标识及编码检测是否存在该条记录
        /// </summary>
        /// <param name="dptName">部门名称</param>
        /// <param name="dptFather">部门标识</param>
        /// <param name="dptCode">部门编码</param>
        /// <returns>存在/不存在</returns>
		public static bool Exists(string dptName,int dptFather,string dptCode)
        {
            return DawnAuthDepartmentBLL._dal.Exists(dptName,dptFather,dptCode);
        }
        /// <summary>
        /// 根据名称和父标识、编码、识别码检测是否存在该条记录
        /// </summary>
        /// <param name="dptName">部门名称</param>
        /// <param name="dptFather">部门标识</param>
        /// <param name="dptCode">部门编码</param>
        /// <param name="dptIdent">部门识别码</param>
        /// <returns>存在/不存在</returns>
		public static bool Exists(string dptName,int dptFather,string dptCode,int dptIdent)
        {
            return DawnAuthDepartmentBLL._dal.Exists(dptName,dptFather,dptCode,dptIdent);
        }
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
        public static bool ExistsOfWhere(string where)
        {
            return DawnAuthDepartmentBLL._dal.ExistsOfWhere(where);
        }
        
        #endregion
		
		#endregion
		
		#region 按指定条件分页查询数据（仅用于主键排序）

        /// <summary>
        /// 通过指定条件分页查询数据（仅用于主键排序）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strWhere">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPinPK(int pageSize, int pageIndex, string strWhere, out int pageCount, out int RecordCount)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPinPK(pageSize, pageIndex, strWhere, out pageCount, out RecordCount);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（仅用于主键排序）
        /// </summary>
        /// <param name="intTop">最多读取记录数</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strWhere">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPinPK(int intTop, int pageSize, int pageIndex, string strWhere, out int pageCount, out int RecordCount)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPinPK(intTop, pageSize, pageIndex, strWhere, out pageCount, out RecordCount);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（仅用于主键排序）
        /// </summary>
        /// <param name="strField">要查询出的字段列表,*表示全部字段</param>
        /// <param name="intTop">最多读取记录数</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strWhere">查询条件,不需where</param>
        /// <param name="strSortField">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="strOrderBy">排序,0-顺序,1-倒序</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPinPK(string strField, int intTop, int pageSize, int pageIndex, string strWhere, string strSortField, byte strOrderBy, out int pageCount, out int RecordCount)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPinPK(strField, intTop, pageSize, pageIndex, strWhere, strSortField, strOrderBy, out pageCount, out RecordCount);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（仅用于主键排序）
        /// </summary>
        /// <param name="strTable">要显示的表或多个表的连接</param>
        /// <param name="strField">要查询出的字段列表,*表示全部字段</param>
        /// <param name="intTop">最多读取记录数</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strWhere">查询条件,不需where</param>
        /// <param name="strSortKey">用于排序的主键</param>
        /// <param name="strSortField">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="strOrderBy">排序,0-顺序,1-倒序</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <param name="UsedTime">耗时测试时间差</param>
        /// <param name="strSql">生成的完整SQL语句</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPinPK(string strTable, string strField, int intTop, int pageSize, int pageIndex, string strWhere, string strSortKey, string strSortField, byte strOrderBy, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPinPK(strTable, strField, intTop, pageSize, pageIndex, strWhere, strSortKey, strSortField, strOrderBy, out pageCount, out RecordCount, out UsedTime, out strSql);
        }

        #endregion

        #region 按指定条件分页查询数据（通用排序方式）

        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·NotIn）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurpose(int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurpose(pageSize, page, strCondition, out  pageCount, out  Counts);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·NotIn）
        /// </summary>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurpose(string fldName, int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurpose(fldName, pageSize, page, strCondition, out  pageCount, out  Counts);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·NotIn）
        /// </summary>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="Sort">排序方法，0为升序，1为降序(如果是多字段排列Sort指代最后一个排序字段的排列顺序(最后一个排序字段不加排序标记)--程序传参如：' SortA Asc,SortB Desc,SortC ')</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="Dist">是否添加查询字段的 DISTINCT 默认0不添加/1添加（去掉重复值）</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurpose(string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, byte Dist, out int pageCount, out int Counts)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurpose(fldName, pageSize, page, fldSort, Sort, strCondition, Dist, out  pageCount, out  Counts);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·NotIn）
        /// </summary>
        /// <param name="tblName">要显示的表或多个表的连接</param>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="Sort">排序方法，0为升序，1为降序(如果是多字段排列Sort指代最后一个排序字段的排列顺序(最后一个排序字段不加排序标记)--程序传参如：' SortA Asc,SortB Desc,SortC ')</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="ID">主表的主键</param>
        /// <param name="Dist">是否添加查询字段的 DISTINCT 默认0不添加/1添加（去掉重复值）</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <param name="UsedTime">耗时测试时间差</param>
        /// <param name="strSql">生成的完整SQL语句</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurpose(string tblName, string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, string ID, byte Dist, out int pageCount, out int Counts, out int UsedTime, out string strSql)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurpose(tblName, fldName, pageSize, page, fldSort, Sort, strCondition, ID, Dist, out pageCount, out Counts, out UsedTime, out strSql);
        }

        #endregion

        #region 按指定条件分页查询数据（通用排序方式·NotIn）

        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeNotIn(int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurposeNotIn(pageSize, page, strCondition, out  pageCount, out  Counts);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式）
        /// </summary>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeNotIn(string fldName, int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurposeNotIn(fldName, pageSize, page, strCondition, out  pageCount, out  Counts);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式）
        /// </summary>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="Sort">排序方法，0为升序，1为降序(如果是多字段排列Sort指代最后一个排序字段的排列顺序(最后一个排序字段不加排序标记)--程序传参如：' SortA Asc,SortB Desc,SortC ')</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="Dist">是否添加查询字段的 DISTINCT 默认0不添加/1添加（去掉重复值）</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeNotIn(string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, byte Dist, out int pageCount, out int Counts)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurposeNotIn(fldName, pageSize, page, fldSort, Sort, strCondition, Dist, out  pageCount, out  Counts);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式）
        /// </summary>
        /// <param name="tblName">要显示的表或多个表的连接</param>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="Sort">排序方法，0为升序，1为降序(如果是多字段排列Sort指代最后一个排序字段的排列顺序(最后一个排序字段不加排序标记)--程序传参如：' SortA Asc,SortB Desc,SortC ')</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="ID">主表的主键</param>
        /// <param name="Dist">是否添加查询字段的 DISTINCT 默认0不添加/1添加（去掉重复值）</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <param name="UsedTime">耗时测试时间差</param>
        /// <param name="strSql">生成的完整SQL语句</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeNotIn(string tblName, string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, string ID, byte Dist, out int pageCount, out int Counts, out int UsedTime, out string strSql)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurposeNotIn(tblName, fldName, pageSize, page, fldSort, Sort, strCondition, ID, Dist, out pageCount, out Counts, out UsedTime, out strSql);
        }

        #endregion

        #region 按指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        
        #region 不输出SQL执行语句和执行时间
        
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurposeRowNumber(pageSize, pageIndex, strCondition, out  pageCount, out  RecordCount);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurposeRowNumber(pageSize, pageIndex, fldSort, strCondition, out  pageCount, out  RecordCount);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurposeRowNumber(fldName, pageSize, pageIndex, strCondition, out  pageCount, out RecordCount);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurposeRowNumber(fldName, pageSize, pageIndex, fldSort, strCondition, out  pageCount, out  RecordCount);
        }
        
        #endregion
        
        #region 输出SQL执行语句和执行时间
        
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <param name="UsedTime">耗时测试时间差</param>
        /// <param name="strSql">生成的完整SQL语句</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurposeRowNumber(pageSize, pageIndex, strCondition, out  pageCount, out  RecordCount, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <param name="UsedTime">耗时测试时间差</param>
        /// <param name="strSql">生成的完整SQL语句</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurposeRowNumber(pageSize, pageIndex, fldSort, strCondition, out  pageCount, out  RecordCount, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <param name="UsedTime">耗时测试时间差</param>
        /// <param name="strSql">生成的完整SQL语句</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurposeRowNumber(fldName, pageSize, pageIndex, strCondition, out  pageCount, out RecordCount, out UsedTime, out strSql);
        }
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <param name="UsedTime">耗时测试时间差</param>
        /// <param name="strSql">生成的完整SQL语句</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurposeRowNumber(fldName, pageSize, pageIndex, fldSort, strCondition, out  pageCount, out  RecordCount, out UsedTime, out strSql);
        }
        
        #endregion
        
        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·ROW_NUMBER）
        /// </summary>
        /// <param name="tblName">要显示的表或多个表的连接</param>
        /// <param name="fldName">要查询出的字段列表,*表示全部字段</param>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="fldSort">排序字段列表或条件，如：id desc (多个id desc,dt asc)</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <param name="UsedTime">耗时测试时间差</param>
        /// <param name="strSql">生成的完整SQL语句</param>
        /// <returns>DawnAuthDepartment 结果集</returns>
        public static List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(string tblName, string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return DawnAuthDepartmentBLL._dal.SelectPSPisAllPurposeRowNumber(tblName, fldName, pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
        }

        #endregion
		
        #endregion
    
	}
}
