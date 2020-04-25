// =================================================================== 
// 业务逻辑（DawnXZ.Dawnauth.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthUserLoginBLL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年02月28日 23:27:00
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
    /// 业务逻辑层DawnAuthUserLogin
    /// </summary>
    internal class DawnAuthUserLoginBLL
    {

        #region ---------变量定义-----------

        ///<summary>
        ///得到数据工厂
        ///</summary>
        private static readonly IDawnAuthUserLoginDAL _dal = DALFactory.DawnAuthUserLoginDALInstance();

        #endregion ---------变量定义-----------

        #region ----------构造函数----------

        /// <summary>
        /// 构造函数
        /// </summary>
        public DawnAuthUserLoginBLL()
        { }

        #endregion ----------构造函数----------

        #region ---------函数定义-----------

        #region 添加

        /// <summary>
        /// 向数据表DawnAuthUserLogin中插入一条新记录
        /// </summary>
        /// <param name="dawnAuthUserLogin">DawnAuthUserLogin实体对象</param>
        /// <returns></returns>
        public static int Insert(DawnAuthUserLoginMDL dawnAuthUserLogin)
        {
            if (dawnAuthUserLogin == null)
                return 0;
            return DawnAuthUserLoginBLL._dal.Insert(dawnAuthUserLogin);
        }

        #endregion
        
        #region 数据实体

        /// <summary>
        /// 通过DataRow创建一个DawnAuthUserLogin实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>DawnAuthUserLogin实体对象</returns>
        public static DawnAuthUserLoginMDL Select(DataRow row)
        {
            return DawnAuthUserLoginBLL._dal.Select(row);
        }
        /// <summary>
        /// 通过DataReader创建一个DawnAuthUserLogin实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>DawnAuthUserLogin实体对象</returns>
        public static DawnAuthUserLoginMDL Select(IDataReader dr)
        {
            return DawnAuthUserLoginBLL._dal.Select(dr);
        }
        /// <summary>
        /// 根据ID,返回一个DawnAuthUserLogin实体对象
        /// </summary>
        /// <param name="logId">系统编号</param>
        /// <returns>DawnAuthUserLogin实体对象</returns>
        public static DawnAuthUserLoginMDL Select(int logId)
        {
            return DawnAuthUserLoginBLL._dal.Select(logId);
        }

        #endregion

        #region 查询

        #region List

        /// <summary>
        /// 得到数据表DawnAuthUserLogin所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static List<DawnAuthUserLoginMDL> LSelect()
        {
            return DawnAuthUserLoginBLL._dal.LSelect();
        }/// <summary>
        /// 得到数据表DawnAuthUserLogin满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static List<DawnAuthUserLoginMDL> LSelect(string where)
        {
            return DawnAuthUserLoginBLL._dal.LSelect(where);
        }
        /// <summary>
        /// 得到数据表DawnAuthUserLogin满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static List<DawnAuthUserLoginMDL> LSelect(string where, string sortField)
        {
            return DawnAuthUserLoginBLL._dal.LSelect(where, sortField);
        }

        #endregion

        #region IList

        /// <summary>
        /// 得到数据表DawnAuthUserLogin所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static IList<DawnAuthUserLoginMDL> ISelect()
        {
            return DawnAuthUserLoginBLL._dal.ISelect();
        }/// <summary>
        /// 得到数据表DawnAuthUserLogin满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static IList<DawnAuthUserLoginMDL> ISelect(string where)
        {
            return DawnAuthUserLoginBLL._dal.ISelect(where);
        }
        /// <summary>
        /// 得到数据表DawnAuthUserLogin满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static IList<DawnAuthUserLoginMDL> ISelect(string where, string sortField)
        {
            return DawnAuthUserLoginBLL._dal.ISelect(where, sortField);
        }

        #endregion

        #endregion
        
        #endregion ---------函数定义-----------

    }
}
