﻿// =================================================================== 
// 产品规则（DawnXZ.Dawnauth.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IDawnAuthUserStatusDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年02月28日 23:25:49
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
    /// 数据层DawnAuthUserStatus接口
    /// </summary>
    public interface IDawnAuthUserStatusDAL : PagerInterface<DawnAuthUserStatusMDL>
    {

        #region 基本方法

        #region 添加

        /// <summary>
        /// 向数据表DawnAuthUserStatus中插入一条新记录
        /// </summary>
        /// <param name="dawnAuthUserStatus">DawnAuthUserStatus实体</param>
        /// <returns></returns>
        int Insert(DawnAuthUserStatusMDL dawnAuthUserStatus);

        /// <summary>
        /// 向数据表DawnAuthUserStatus中插入一条新记录。带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="dawnAuthUserStatus">DawnAuthUserStatus实体</param>
        /// <returns></returns>
        int Insert(SqlTransaction sp, DawnAuthUserStatusMDL dawnAuthUserStatus);

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表DawnAuthUserStatus修改一条记录
        /// </summary>
        /// <param name="dawnAuthUserStatus">DawnAuthUserStatus实体</param>
        /// <returns></returns>
        int Update(DawnAuthUserStatusMDL dawnAuthUserStatus);

        /// <summary>
        /// 向数据表DawnAuthUserStatus修改一条记录。带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="dawnAuthUserStatus">DawnAuthUserStatus实体</param>
        /// <returns></returns>
        int Update(SqlTransaction sp, DawnAuthUserStatusMDL dawnAuthUserStatus);

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表DawnAuthUserStatus中的一条记录
        /// </summary>
        /// <param name="mapId">系统编号</param>
        /// <returns></returns>
        int Delete(int mapId);

        /// <summary>
        /// 删除数据表DawnAuthUserStatus中的一条记录
        /// </summary>
        /// <param name="dawnAuthUserStatus">DawnAuthUserStatus实体</param>
        /// <returns></returns>
        int Delete(DawnAuthUserStatusMDL dawnAuthUserStatus);

        /// <summary>
        /// 删除数据表DawnAuthUserStatus中的一条记录，带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="mapId">系统编号</param>
        /// <returns></returns>
        int Delete(SqlTransaction sp, int mapId);

        /// <summary>
        /// 删除数据表DawnAuthUserStatus中的一条记录,带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="dawnAuthUserStatus">DawnAuthUserStatus实体</param>
        /// <returns></returns>
        int Delete(SqlTransaction sp, DawnAuthUserStatusMDL dawnAuthUserStatus);

        /// <summary>
        /// 根据指定条件删除数据表DawnAuthUserStatus中的记录
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        int DeleteWhere(string where);

        #endregion

        #region 实体对象

        /// <summary>
        /// 通过DataRow创建一个DawnAuthUserStatus实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>DawnAuthUserStatus实体</returns>
        DawnAuthUserStatusMDL Select(DataRow row);
        /// <summary>
        /// 得到DawnAuthUserStatus数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>DawnAuthUserStatus数据实体</returns>
        DawnAuthUserStatusMDL Select(IDataReader dr);
        /// <summary>
        /// 根据ID,返回一个DawnAuthUserStatus对象
        /// </summary>
        /// <param name="mapId">系统编号</param>
        /// <returns>DawnAuthUserStatus</returns>
        DawnAuthUserStatusMDL Select(int mapId);

        #endregion

        #region 查询

        #region List

        /// <summary>
        /// 得到数据表DawnAuthUserStatus所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        List<DawnAuthUserStatusMDL> LSelect();
        /// <summary>
        /// 得到数据表DawnAuthUserStatus满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        List<DawnAuthUserStatusMDL> LSelect(string where);
        /// <summary>
        /// 得到数据表DawnAuthUserStatus满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        List<DawnAuthUserStatusMDL> LSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表DawnAuthUserStatus满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        List<DawnAuthUserStatusMDL> LSelect(CommandType commandType, string sqlCommand, params SqlParameter[] param);

        #endregion

        #region IList

        /// <summary>
        /// 得到数据表DawnAuthUserStatus所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        IList<DawnAuthUserStatusMDL> ISelect();
        /// <summary>
        /// 得到数据表DawnAuthUserStatus满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        IList<DawnAuthUserStatusMDL> ISelect(string where);
        /// <summary>
        /// 得到数据表DawnAuthUserStatus满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        IList<DawnAuthUserStatusMDL> ISelect(string where, string sortField);
        /// <summary>
        /// 得到数据表DawnAuthUserStatus满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        IList<DawnAuthUserStatusMDL> ISelect(CommandType commandType, string sqlCommand, params SqlParameter[] param);

        #endregion

        /// <summary>
        /// 得到数据表DawnAuthUserStatus满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        void Select(string where, out int recordCount);
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
