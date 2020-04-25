// =================================================================== 
// 产品规则（DawnXZ.Dawnauth.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IDawnAuthUserDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:35:56
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
    /// 数据层DawnAuthUser接口
    /// </summary>
    internal partial interface IDawnAuthUserDAL
    {

        #region 基本方法

        #region 实体对象

        /// <summary>
        /// 通过DataRow创建一个DawnAuthUser实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>DawnAuthUser实体</returns>
        DawnAuthUserMDL Select(DataRow row);
        /// <summary>
        /// 得到DawnAuthUser数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>DawnAuthUser数据实体</returns>
        DawnAuthUserMDL Select(IDataReader dr);
        /// <summary>
        /// 根据ID,返回一个DawnAuthUser对象
        /// </summary>
        /// <param name="userId">系统编号</param>
        /// <returns>DawnAuthUser</returns>
        DawnAuthUserMDL Select(int userId);

        #endregion

        #region 查询

        #region List

        /// <summary>
        /// 得到数据表DawnAuthUser所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        List<DawnAuthUserMDL> LSelect();
        /// <summary>
        /// 得到数据表DawnAuthUser满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        List<DawnAuthUserMDL> LSelect(string where);
        /// <summary>
        /// 得到数据表DawnAuthUser满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        List<DawnAuthUserMDL> LSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表DawnAuthUser满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        List<DawnAuthUserMDL> LSelect(CommandType commandType, string sqlCommand, params SqlParameter[] param);

        #endregion

        #region IList

        /// <summary>
        /// 得到数据表DawnAuthUser所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        IList<DawnAuthUserMDL> ISelect();
        /// <summary>
        /// 得到数据表DawnAuthUser满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        IList<DawnAuthUserMDL> ISelect(string where);
        /// <summary>
        /// 得到数据表DawnAuthUser满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        IList<DawnAuthUserMDL> ISelect(string where, string sortField);
        /// <summary>
        /// 得到数据表DawnAuthUser满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        IList<DawnAuthUserMDL> ISelect(CommandType commandType, string sqlCommand, params SqlParameter[] param);

        #endregion

        #endregion

        #endregion

    }
}
