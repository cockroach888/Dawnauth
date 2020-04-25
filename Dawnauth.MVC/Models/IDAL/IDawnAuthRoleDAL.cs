// =================================================================== 
// 产品规则（DawnXZ.Dawnauth.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IDawnAuthRoleDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 20:47:36
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
    /// 数据层DawnAuthRole接口
    /// </summary>
    public partial interface IDawnAuthRoleDAL : PagerInterface<DawnAuthRoleMDL>
    {

        #region 基本方法

        #region 添加

        /// <summary>
        /// 向数据表DawnAuthRole中插入一条新记录
        /// </summary>
        /// <param name="dawnAuthRole">DawnAuthRole实体</param>
        /// <returns></returns>
        int Insert(DawnAuthRoleMDL dawnAuthRole);

        /// <summary>
        /// 向数据表DawnAuthRole中插入一条新记录。带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="dawnAuthRole">DawnAuthRole实体</param>
        /// <returns></returns>
        int Insert(SqlTransaction sp, DawnAuthRoleMDL dawnAuthRole);

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表DawnAuthRole修改一条记录
        /// </summary>
        /// <param name="dawnAuthRole">DawnAuthRole实体</param>
        /// <returns></returns>
        int Update(DawnAuthRoleMDL dawnAuthRole);

        /// <summary>
        /// 向数据表DawnAuthRole修改一条记录。带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="dawnAuthRole">DawnAuthRole实体</param>
        /// <returns></returns>
        int Update(SqlTransaction sp, DawnAuthRoleMDL dawnAuthRole);

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表DawnAuthRole中的一条记录
        /// </summary>
        /// <param name="roleId">系统编号</param>
        /// <returns></returns>
        int Delete(int roleId);

        /// <summary>
        /// 删除数据表DawnAuthRole中的一条记录
        /// </summary>
        /// <param name="dawnAuthRole">DawnAuthRole实体</param>
        /// <returns></returns>
        int Delete(DawnAuthRoleMDL dawnAuthRole);

        /// <summary>
        /// 删除数据表DawnAuthRole中的一条记录，带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="roleId">系统编号</param>
        /// <returns></returns>
        int Delete(SqlTransaction sp, int roleId);

        /// <summary>
        /// 删除数据表DawnAuthRole中的一条记录,带事务
        /// </summary>
        /// <param name="sp">事务对象</param>
        /// <param name="dawnAuthRole">DawnAuthRole实体</param>
        /// <returns></returns>
        int Delete(SqlTransaction sp, DawnAuthRoleMDL dawnAuthRole);

        /// <summary>
        /// 根据指定条件删除数据表DawnAuthRole中的记录
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        int DeleteWhere(string where);

        #endregion

        #region 实体对象

        /// <summary>
        /// 通过DataRow创建一个DawnAuthRole实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>DawnAuthRole实体</returns>
        DawnAuthRoleMDL Select(DataRow row);
        /// <summary>
        /// 得到DawnAuthRole数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>DawnAuthRole数据实体</returns>
        DawnAuthRoleMDL Select(IDataReader dr);
        /// <summary>
        /// 根据ID,返回一个DawnAuthRole对象
        /// </summary>
        /// <param name="roleId">系统编号</param>
        /// <returns>DawnAuthRole</returns>
        DawnAuthRoleMDL Select(int roleId);

        #endregion

        #region 查询

        #region List

        /// <summary>
        /// 得到数据表DawnAuthRole所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        List<DawnAuthRoleMDL> LSelect();
        /// <summary>
        /// 得到数据表DawnAuthRole满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        List<DawnAuthRoleMDL> LSelect(string where);
        /// <summary>
        /// 得到数据表DawnAuthRole满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        List<DawnAuthRoleMDL> LSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表DawnAuthRole满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        List<DawnAuthRoleMDL> LSelect(CommandType commandType, string sqlCommand, params SqlParameter[] param);

        #endregion

        #region IList

        /// <summary>
        /// 得到数据表DawnAuthRole所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        IList<DawnAuthRoleMDL> ISelect();
        /// <summary>
        /// 得到数据表DawnAuthRole满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        IList<DawnAuthRoleMDL> ISelect(string where);
        /// <summary>
        /// 得到数据表DawnAuthRole满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        IList<DawnAuthRoleMDL> ISelect(string where, string sortField);
        /// <summary>
        /// 得到数据表DawnAuthRole满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        IList<DawnAuthRoleMDL> ISelect(CommandType commandType, string sqlCommand, params SqlParameter[] param);

        #endregion

        /// <summary>
        /// 得到数据表DawnAuthRole满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        void Select(string where, out int recordCount);
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="roleId">系统编号</param>
        /// <returns>存在/不存在</returns>
        bool Exists(int roleId);
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
