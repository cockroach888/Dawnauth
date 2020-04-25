// =================================================================== 
// 业务逻辑（DawnXZ.Dawnauth.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthModuleBLL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年04月05日 20:17:10
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
    /// 业务逻辑层DawnAuthModule
    /// </summary>
    public class DawnAuthModuleBLL
    {
		
		#region ---------变量定义-----------
		
		///<summary>
		///得到数据工厂
		///</summary>
		private static readonly IDawnAuthModuleDAL _dal = DALFactory.DawnAuthModuleDALInstance();
		
		#endregion
		
		#region ----------构造函数----------
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public DawnAuthModuleBLL()
		{ }
		
		#endregion

        #region ---------函数定义-----------
				
		#region 实体对象
		
		/// <summary>
		/// 通过DataRow创建一个DawnAuthModule实体对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>DawnAuthModule实体对象</returns>
		public static DawnAuthModuleMDL Select(DataRow row)
		{
			return DawnAuthModuleBLL._dal.Select(row);
		}		
		/// <summary>
		/// 通过DataReader创建一个DawnAuthModule实体对象
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>DawnAuthModule实体对象</returns>
		public static DawnAuthModuleMDL Select(IDataReader dr)
		{
			return DawnAuthModuleBLL._dal.Select(dr);
		}
		/// <summary>
		/// 根据ID,返回一个DawnAuthModule实体对象
		/// </summary>
		/// <param name="mdlId">模块编号</param>
		/// <returns>DawnAuthModule实体对象</returns>
		public static DawnAuthModuleMDL Select(int mdlId)
		{
			return DawnAuthModuleBLL._dal.Select(mdlId);
		}
		
		#endregion
		
		#region 查询
		
        #region List
        
        /// <summary>
		/// 得到数据表DawnAuthModule所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public static List< DawnAuthModuleMDL> LSelect()
		{
			return DawnAuthModuleBLL._dal.LSelect();
		}
        /// <summary>
        /// 得到数据表DawnAuthModule所有父记录
        /// </summary>
        /// <returns>结果集</returns>
        public static List< DawnAuthModuleMDL> LSelectFather()
        {
            return DawnAuthModuleBLL._dal.LSelectFather();
        }
		/// <summary>
		/// 得到数据表DawnAuthModule满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public static List< DawnAuthModuleMDL> LSelect(string where)
		{
			return DawnAuthModuleBLL._dal.LSelect(where);
		}
		/// <summary>
		/// 得到数据表DawnAuthModule满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public static List< DawnAuthModuleMDL> LSelect(string where, string sortField)
		{
			return DawnAuthModuleBLL._dal.LSelect(where,sortField);
		}
        
        #endregion
        
        #region IList
        
        /// <summary>
		/// 得到数据表DawnAuthModule所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public static IList< DawnAuthModuleMDL> ISelect()
		{
			return DawnAuthModuleBLL._dal.ISelect();
		}
        /// <summary>
        /// 得到数据表DawnAuthModule所有父记录
        /// </summary>
        /// <returns>结果集</returns>
        public static IList< DawnAuthModuleMDL> ISelectFather()
        {
            return DawnAuthModuleBLL._dal.ISelectFather();
        }
		/// <summary>
		/// 得到数据表DawnAuthModule满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public static IList< DawnAuthModuleMDL> ISelect(string where)
		{
			return DawnAuthModuleBLL._dal.ISelect(where);
		}
		/// <summary>
		/// 得到数据表DawnAuthModule满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public static IList< DawnAuthModuleMDL> ISelect(string where, string sortField)
		{
			return DawnAuthModuleBLL._dal.ISelect(where,sortField);
		}
        
        #endregion
        
        #region Exists
        
		/// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="mdlId">模块编号</param>
        /// <returns>存在/不存在</returns>
		public static bool Exists(int mdlId)
		{
			return DawnAuthModuleBLL._dal.Exists(mdlId);
		}
        /// <summary>
        /// 根据名称检测是否存在该条记录
        /// </summary>
        /// <param name="mdlName">模块名称</param>
        /// <returns>存在/不存在</returns>
		public static bool Exists(string mdlName)
        {
            return DawnAuthModuleBLL._dal.Exists(mdlName);
        }
        /// <summary>
        /// 根据点击检测是否存在该条记录
        /// </summary>
        /// <param name="mdlClick">模块点击</param>
        /// <returns>存在/不存在</returns>
        public static bool ExistsOfClick(int mdlClick)
        {
            return DawnAuthModuleBLL._dal.ExistsOfClick(mdlClick);
        }
        /// <summary>
        /// 根据父标识检测是否存在该条记录
        /// </summary>
        /// <param name="mdlFather">模块标识</param>
        /// <returns>存在/不存在</returns>
		public static bool ExistsOfFather(int mdlFather)
        {
            return DawnAuthModuleBLL._dal.ExistsOfFather(mdlFather);
        }
        /// <summary>
        /// 根据名称和父标识检测是否存在该条记录
        /// </summary>
        /// <param name="mdlName">模块名称</param>
        /// <param name="mdlFather">模块标识</param>
        /// <returns>存在/不存在</returns>
		public static bool Exists(string mdlName,int mdlFather)
        {
            return DawnAuthModuleBLL._dal.Exists(mdlName,mdlFather);
        }
        /// <summary>
        /// 根据编码检测是否存在该条记录
        /// </summary>
        /// <param name="mdlCode">模块编码</param>
        /// <returns>存在/不存在</returns>
		public static bool ExistsOfCode(string mdlCode)
        {
            return DawnAuthModuleBLL._dal.ExistsOfCode(mdlCode);
        }
        /// <summary>
        /// 根据识别码检测是否存在该条记录
        /// </summary>
        /// <param name="mdlIdent">模块识别码</param>
        /// <returns>存在/不存在</returns>
		public static bool ExistsOfIdent(int mdlIdent)
        {
            return DawnAuthModuleBLL._dal.ExistsOfIdent(mdlIdent);
        }
        /// <summary>
        /// 根据编码和识别码检测是否存在该条记录
        /// </summary>
        /// <param name="mdlCode">模块编码</param>
        /// <param name="mdlIdent">模块识别码</param>
        /// <returns>存在/不存在</returns>
		public static bool ExistsOfCodeIdent(string mdlCode,int mdlIdent)
        {
            return DawnAuthModuleBLL._dal.ExistsOfCodeIdent(mdlCode,mdlIdent);
        }
        /// <summary>
        /// 根据名称和父标识及编码检测是否存在该条记录
        /// </summary>
        /// <param name="mdlName">模块名称</param>
        /// <param name="mdlFather">模块标识</param>
        /// <param name="mdlCode">模块编码</param>
        /// <returns>存在/不存在</returns>
		public static bool Exists(string mdlName,int mdlFather,string mdlCode)
        {
            return DawnAuthModuleBLL._dal.Exists(mdlName,mdlFather,mdlCode);
        }
        /// <summary>
        /// 根据名称和父标识、编码、识别码检测是否存在该条记录
        /// </summary>
        /// <param name="mdlName">模块名称</param>
        /// <param name="mdlFather">模块标识</param>
        /// <param name="mdlCode">模块编码</param>
        /// <param name="mdlIdent">模块识别码</param>
        /// <returns>存在/不存在</returns>
		public static bool Exists(string mdlName,int mdlFather,string mdlCode,int mdlIdent)
        {
            return DawnAuthModuleBLL._dal.Exists(mdlName,mdlFather,mdlCode,mdlIdent);
        }
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
        public static bool ExistsOfWhere(string where)
        {
            return DawnAuthModuleBLL._dal.ExistsOfWhere(where);
        }
        
        #endregion
		
		#endregion
		
        #endregion
    
	}
}
