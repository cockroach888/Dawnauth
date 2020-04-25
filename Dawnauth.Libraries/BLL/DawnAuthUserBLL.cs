// =================================================================== 
// 业务逻辑（DawnXZ.Dawnauth.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthUserBLL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:36:16
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
    /// 业务逻辑层DawnAuthUser
    /// </summary>
    internal partial class DawnAuthUserBLL
    {

        #region ---------变量定义-----------

        ///<summary>
        ///得到数据工厂
        ///</summary>
        private static readonly IDawnAuthUserDAL _dal = DALFactory.DawnAuthUserDALInstance();

        #endregion ---------变量定义-----------

        #region ----------构造函数----------

        /// <summary>
        /// 构造函数
        /// </summary>
        public DawnAuthUserBLL()
        { }

        #endregion ----------构造函数----------

        #region ---------函数定义-----------

        #region 数据实体

        /// <summary>
        /// 通过DataRow创建一个DawnAuthUser实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>DawnAuthUser实体对象</returns>
        public static DawnAuthUserMDL Select(DataRow row)
        {
            return DawnAuthUserBLL._dal.Select(row);
        }
        /// <summary>
        /// 通过DataReader创建一个DawnAuthUser实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>DawnAuthUser实体对象</returns>
        public static DawnAuthUserMDL Select(IDataReader dr)
        {
            return DawnAuthUserBLL._dal.Select(dr);
        }
        /// <summary>
        /// 根据ID,返回一个DawnAuthUser实体对象
        /// </summary>
        /// <param name="userId">系统编号</param>
        /// <returns>DawnAuthUser实体对象</returns>
        public static DawnAuthUserMDL Select(int userId)
        {
            return DawnAuthUserBLL._dal.Select(userId);
        }

        #endregion

        #region 查询

        #region List

        /// <summary>
        /// 得到数据表DawnAuthUser所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static List<DawnAuthUserMDL> LSelect()
        {
            return DawnAuthUserBLL._dal.LSelect();
        }/// <summary>
        /// 得到数据表DawnAuthUser满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static List<DawnAuthUserMDL> LSelect(string where)
        {
            return DawnAuthUserBLL._dal.LSelect(where);
        }
        /// <summary>
        /// 得到数据表DawnAuthUser满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static List<DawnAuthUserMDL> LSelect(string where, string sortField)
        {
            return DawnAuthUserBLL._dal.LSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表DawnAuthUser满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static List<DawnAuthUserMDL> LSelect(CommandType commandType, string sqlCommand, params SqlParameter[] param)
        {
            return DawnAuthUserBLL._dal.LSelect(commandType, sqlCommand, param);
        }

        #endregion

        #region IList

        /// <summary>
        /// 得到数据表DawnAuthUser所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static IList<DawnAuthUserMDL> ISelect()
        {
            return DawnAuthUserBLL._dal.ISelect();
        }/// <summary>
        /// 得到数据表DawnAuthUser满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static IList<DawnAuthUserMDL> ISelect(string where)
        {
            return DawnAuthUserBLL._dal.ISelect(where);
        }
        /// <summary>
        /// 得到数据表DawnAuthUser满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static IList<DawnAuthUserMDL> ISelect(string where, string sortField)
        {
            return DawnAuthUserBLL._dal.ISelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表DawnAuthUser满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static IList<DawnAuthUserMDL> ISelect(CommandType commandType, string sqlCommand, params SqlParameter[] param)
        {
            return DawnAuthUserBLL._dal.ISelect(commandType, sqlCommand, param);
        }

        #endregion

        #endregion
        
        #endregion ---------函数定义-----------

    }
}
