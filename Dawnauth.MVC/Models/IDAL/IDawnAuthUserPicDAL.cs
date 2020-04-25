// =================================================================== 
// 产品规则（DawnXZ.Dawnauth.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IDawnAuthUserPicDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年02月28日 23:25:26
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
    /// 数据层DawnAuthUserPic接口
    /// </summary>
    public interface IDawnAuthUserPicDAL : PagerInterface<DawnAuthUserPicMDL>
    {

        #region 基本方法

        #region 添加

        /// <summary>
        /// 向数据表DawnAuthUserPic中插入一条新记录
        /// </summary>
        /// <param name="dawnAuthUserPic">DawnAuthUserPic实体</param>
        /// <returns></returns>
        int Insert(DawnAuthUserPicMDL dawnAuthUserPic);

        /// <summary>
        /// 向数据表DawnAuthUserPic中插入一条新记录。带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="dawnAuthUserPic">DawnAuthUserPic实体</param>
        /// <returns></returns>
        int Insert(SqlTransaction sp, DawnAuthUserPicMDL dawnAuthUserPic);

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表DawnAuthUserPic修改一条记录
        /// </summary>
        /// <param name="dawnAuthUserPic">DawnAuthUserPic实体</param>
        /// <returns></returns>
        int Update(DawnAuthUserPicMDL dawnAuthUserPic);

        /// <summary>
        /// 向数据表DawnAuthUserPic修改一条记录。带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="dawnAuthUserPic">DawnAuthUserPic实体</param>
        /// <returns></returns>
        int Update(SqlTransaction sp, DawnAuthUserPicMDL dawnAuthUserPic);

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表DawnAuthUserPic中的一条记录
        /// </summary>
        /// <param name="picId">系统编号</param>
        /// <returns></returns>
        int Delete(int picId);

        /// <summary>
        /// 删除数据表DawnAuthUserPic中的一条记录
        /// </summary>
        /// <param name="dawnAuthUserPic">DawnAuthUserPic实体</param>
        /// <returns></returns>
        int Delete(DawnAuthUserPicMDL dawnAuthUserPic);

        /// <summary>
        /// 删除数据表DawnAuthUserPic中的一条记录，带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="picId">系统编号</param>
        /// <returns></returns>
        int Delete(SqlTransaction sp, int picId);

        /// <summary>
        /// 删除数据表DawnAuthUserPic中的一条记录,带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="dawnAuthUserPic">DawnAuthUserPic实体</param>
        /// <returns></returns>
        int Delete(SqlTransaction sp, DawnAuthUserPicMDL dawnAuthUserPic);

        /// <summary>
        /// 根据指定条件删除数据表DawnAuthUserPic中的记录
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        int DeleteWhere(string where);

        #endregion

        #region 实体对象

        /// <summary>
        /// 通过DataRow创建一个DawnAuthUserPic实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>DawnAuthUserPic实体</returns>
        DawnAuthUserPicMDL Select(DataRow row);
        /// <summary>
        /// 得到DawnAuthUserPic数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>DawnAuthUserPic数据实体</returns>
        DawnAuthUserPicMDL Select(IDataReader dr);
        /// <summary>
        /// 根据ID,返回一个DawnAuthUserPic对象
        /// </summary>
        /// <param name="picId">系统编号</param>
        /// <returns>DawnAuthUserPic</returns>
        DawnAuthUserPicMDL Select(int picId);

        #endregion

        #region 查询

        #region List

        /// <summary>
        /// 得到数据表DawnAuthUserPic所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        List<DawnAuthUserPicMDL> LSelect();
        /// <summary>
        /// 得到数据表DawnAuthUserPic满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        List<DawnAuthUserPicMDL> LSelect(string where);
        /// <summary>
        /// 得到数据表DawnAuthUserPic满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        List<DawnAuthUserPicMDL> LSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表DawnAuthUserPic满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        List<DawnAuthUserPicMDL> LSelect(CommandType commandType, string sqlCommand, params SqlParameter[] param);

        #endregion

        #region IList

        /// <summary>
        /// 得到数据表DawnAuthUserPic所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        IList<DawnAuthUserPicMDL> ISelect();
        /// <summary>
        /// 得到数据表DawnAuthUserPic满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        IList<DawnAuthUserPicMDL> ISelect(string where);
        /// <summary>
        /// 得到数据表DawnAuthUserPic满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        IList<DawnAuthUserPicMDL> ISelect(string where, string sortField);
        /// <summary>
        /// 得到数据表DawnAuthUserPic满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        IList<DawnAuthUserPicMDL> ISelect(CommandType commandType, string sqlCommand, params SqlParameter[] param);

        #endregion

        /// <summary>
        /// 得到数据表DawnAuthUserPic满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        void Select(string where, out int recordCount);
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="picId">系统编号</param>
        /// <returns>存在/不存在</returns>
        bool Exists(int picId);
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
