// =================================================================== 
// 产品规则（DawnXZ.Dawnauth.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IDawnAuthModuleDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年04月05日 20:16:53
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
    /// 数据层DawnAuthModule接口
    /// </summary>
    public interface IDawnAuthModuleDAL
    {
		
		#region 基本方法
			
		#region 实体对象
		
		/// <summary>
		/// 通过DataRow创建一个DawnAuthModule实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>DawnAuthModule实体</returns>
		DawnAuthModuleMDL Select(DataRow row);		
		/// <summary>
		/// 得到DawnAuthModule数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>DawnAuthModule数据实体</returns>
		DawnAuthModuleMDL Select(IDataReader dr);
		/// <summary>
		/// 根据ID,返回一个DawnAuthModule对象
		/// </summary>
		/// <param name="mdlId">模块编号</param>
		/// <returns>DawnAuthModule</returns>
		DawnAuthModuleMDL Select(int mdlId);
		
		#endregion
		
		#region 查询
		
        #region List
        
        /// <summary>
		/// 得到数据表DawnAuthModule所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		List< DawnAuthModuleMDL> LSelect();
        /// <summary>
        /// 得到数据表DawnAuthModule所有父模块记录
        /// </summary>
        /// <returns>数据实体</returns>
        List< DawnAuthModuleMDL> LSelectFather();
		/// <summary>
        /// 得到数据表DawnAuthModule满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
		List< DawnAuthModuleMDL> LSelect(string where);
		/// <summary>
        /// 得到数据表DawnAuthModule满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
		List< DawnAuthModuleMDL> LSelect(string where,string sortField);
        
        #endregion
        
        #region IList
        
        /// <summary>
		/// 得到数据表DawnAuthModule所有记录
		/// </summary>
		/// <returns>数据实体</returns>
		IList< DawnAuthModuleMDL> ISelect();
        /// <summary>
        /// 得到数据表DawnAuthModule所有父模块记录
        /// </summary>
        /// <returns>数据实体</returns>
        IList< DawnAuthModuleMDL> ISelectFather();
		/// <summary>
        /// 得到数据表DawnAuthModule满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
		IList< DawnAuthModuleMDL> ISelect(string where);
		/// <summary>
        /// 得到数据表DawnAuthModule满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
		IList< DawnAuthModuleMDL> ISelect(string where,string sortField);
        
        #endregion
                
        #region Exists
        
		/// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="mdlId">系统编号</param>
        /// <returns>存在/不存在</returns>
		bool Exists(int mdlId);
        /// <summary>
        /// 根据名称检测是否存在该条记录
        /// </summary>
        /// <param name="mdlName">模块名称</param>
        /// <returns>存在/不存在</returns>
		bool Exists(string mdlName);
        /// <summary>
        /// 根据点击检测是否存在该条记录
        /// </summary>
        /// <param name="mdlClick">模块点击</param>
        /// <returns>存在/不存在</returns>
        bool ExistsOfClick(int mdlClick);
        /// <summary>
        /// 根据父标识检测是否存在该条记录
        /// </summary>
        /// <param name="mdlFather">模块标识</param>
        /// <returns>存在/不存在</returns>
		bool ExistsOfFather(int mdlFather);
        /// <summary>
        /// 根据名称和父标识检测是否存在该条记录
        /// </summary>
        /// <param name="mdlName">模块名称</param>
        /// <param name="mdlFather">模块标识</param>
        /// <returns>存在/不存在</returns>
		bool Exists(string mdlName,int mdlFather);
        /// <summary>
        /// 根据编码检测是否存在该条记录
        /// </summary>
        /// <param name="mdlCode">模块编码</param>
        /// <returns>存在/不存在</returns>
		bool ExistsOfCode(string mdlCode);
		/// <summary>
        /// 根据识别码检测是否存在该条记录
        /// </summary>
        /// <param name="mdlIdent">模块识别码</param>
        /// <returns>存在/不存在</returns>
		bool ExistsOfIdent(int mdlIdent);
        /// <summary>
        /// 根据编码和识别码检测是否存在该条记录
        /// </summary>
        /// <param name="mdlCode">模块编码</param>
        /// <param name="mdlIdent">模块识别码</param>
        /// <returns>存在/不存在</returns>
		bool ExistsOfCodeIdent(string mdlCode,int mdlIdent);
        /// <summary>
        /// 根据名称和父标识及编码检测是否存在该条记录
        /// </summary>
        /// <param name="mdlName">模块名称</param>
        /// <param name="mdlFather">模块标识</param>
        /// <param name="mdlCode">模块编码</param>
        /// <returns>存在/不存在</returns>
		bool Exists(string mdlName,int mdlFather,string mdlCode);
        /// <summary>
        /// 根据名称和父标识、编码、识别码检测是否存在该条记录
        /// </summary>
        /// <param name="mdlName">模块名称</param>
        /// <param name="mdlFather">模块标识</param>
        /// <param name="mdlCode">模块编码</param>
        /// <param name="mdlIdent">模块识别码</param>
        /// <returns>存在/不存在</returns>
		bool Exists(string mdlName,int mdlFather,string mdlCode,int mdlIdent);
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
