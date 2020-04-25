// =================================================================== 
// 产品（DawnXZ.Dawnauth.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthModuleDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年04月05日 20:40:31
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DawnXZ.DBUtility;
using DawnXZ.Dawnauth.Entity;
using DawnXZ.Dawnauth.IDAL;
using DawnXZ.Dawnauth.BLL;

namespace DawnXZ.Dawnauth.SqlServerDAL
{
    /// <summary>
    /// 数据访问层DawnAuthModule
    /// </summary>
    public partial class DawnAuthModuleDAL : IDawnAuthModuleDAL
    {

        #region 构造函数

        /// <summary>
        /// 数据层实例化
        /// </summary>
        public DawnAuthModuleDAL()
        { }

        #endregion

        #region -----------实例化接口函数-----------

        #region 实体对象

        /// <summary>
        /// 得到DawnAuthModule实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>DawnAuthModule实体对象</returns>
        public DawnAuthModuleMDL Select(DataRow row)
        {
            DawnAuthModuleMDL obj = new DawnAuthModuleMDL();
            if (row != null)
            {
                try
                {
                    obj.MdlId = ((row["mdl_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["mdl_id"]);
                }
                catch { }
                try
                {
                    obj.MdlName = row["mdl_name"].ToString();
                }
                catch { }
                try
                {
                    obj.MdlFather = ((row["mdl_father"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["mdl_father"]);
                }
                catch { }
                try
                {
                    obj.MdlPath = row["mdl_path"].ToString();
                }
                catch { }
                try
                {
                    obj.MdlCode = row["mdl_code"].ToString();
                }
                catch { }
                try
                {
                    obj.MdlIdent = ((row["mdl_ident"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["mdl_ident"]);
                }
                catch { }
                try
                {
                    obj.MdlRank = ((row["mdl_rank"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["mdl_rank"]);
                }
                catch { }
                try
                {
                    obj.MdlClick = ((row["mdl_click"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["mdl_click"]);
                }
                catch { }
                try
                {
                    obj.MdlCounts = ((row["mdl_counts"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["mdl_counts"]);
                }
                catch { }
                try
                {
                    obj.MdlDesc = row["mdl_desc"].ToString();
                }
                catch { }
                try
                {
                    obj.MdlTime = ((row["mdl_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["mdl_time"]);
                }
                catch { }
            }
            else
            {
                return null;
            }
            return obj;
        }

        /// <summary>
        /// 得到DawnAuthModule实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>DawnAuthModule实体对象</returns>
        public DawnAuthModuleMDL Select(IDataReader dr)
        {
            DawnAuthModuleMDL obj = new DawnAuthModuleMDL();
            try
            {
                obj.MdlId = ((dr["mdl_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["mdl_id"]);
            }
            catch { }
            try
            {
                obj.MdlName = dr["mdl_name"].ToString();
            }
            catch { }
            try
            {
                obj.MdlFather = ((dr["mdl_father"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["mdl_father"]);
            }
            catch { }
            try
            {
                obj.MdlPath = dr["mdl_path"].ToString();
            }
            catch { }
            try
            {
                obj.MdlCode = dr["mdl_code"].ToString();
            }
            catch { }
            try
            {
                obj.MdlIdent = ((dr["mdl_ident"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["mdl_ident"]);
            }
            catch { }
            try
            {
                obj.MdlRank = ((dr["mdl_rank"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["mdl_rank"]);
            }
            catch { }
            try
            {
                obj.MdlClick = ((dr["mdl_click"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["mdl_click"]);
            }
            catch { }
            try
            {
                obj.MdlCounts = ((dr["mdl_counts"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["mdl_counts"]);
            }
            catch { }
            try
            {
                obj.MdlDesc = dr["mdl_desc"].ToString();
            }
            catch { }
            try
            {
                obj.MdlTime = ((dr["mdl_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["mdl_time"]);
            }
            catch { }
            return obj;
        }
        /// <summary>
        /// 根据ID,返回一个DawnAuthModule实体对象
        /// </summary>
        /// <param name="mdlId">模块编号</param>
        /// <returns>DawnAuthModule实体对象</returns>
        public DawnAuthModuleMDL Select(int mdlId)
        {
            DawnAuthModuleMDL obj = null;
            SqlParameter[] param ={
			new SqlParameter("@MdlId",SqlDbType.Int)
			};
            param[0].Value = mdlId;
            string sqlCommand = "DawnAuthModuleSelect";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param))
            {
                while (dr.Read())
                {
                    obj = this.Select(dr);
                }
            }
            return obj;
        }

        #endregion

        #region 查询

        #region List

        /// <summary>
        /// 得到数据表DawnAuthModule所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public List<DawnAuthModuleMDL> LSelect()
        {
            return this.LSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表DawnAuthModule所有父记录
        /// </summary>
        /// <returns>结果集</returns>
        public List<DawnAuthModuleMDL> LSelectFather()
        {
            return this.LSelect(" mdl_father = -1");
        }
        /// <summary>
        /// 得到数据表DawnAuthModule满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public List<DawnAuthModuleMDL> LSelect(string where)
        {
            return this.LSelect(where, " [mdl_id] DESC ");
        }
        /// <summary>
        /// 得到数据表DawnAuthModule满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<DawnAuthModuleMDL> LSelect(string where, string sortField)
        {
            List<DawnAuthModuleMDL> list = new List<DawnAuthModuleMDL>();
            SqlParameter[] param ={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
            param[0].Value = where;
            param[1].Value = sortField;
            string sqlCommand = "DawnAuthModuleSelectByParams";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }

        #endregion

        #region IList

        /// <summary>
        /// 得到数据表DawnAuthModule所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList<DawnAuthModuleMDL> ISelect()
        {
            return this.ISelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表DawnAuthModule所有父记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList<DawnAuthModuleMDL> ISelectFather()
        {
            return this.ISelect(" mdl_father = -1");
        }
        /// <summary>
        /// 得到数据表DawnAuthModule满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public IList<DawnAuthModuleMDL> ISelect(string where)
        {
            return this.ISelect(where, " [mdl_id] DESC ");
        }
        /// <summary>
        /// 得到数据表DawnAuthModule满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<DawnAuthModuleMDL> ISelect(string where, string sortField)
        {
            IList<DawnAuthModuleMDL> list = new List<DawnAuthModuleMDL>();
            SqlParameter[] param ={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
            param[0].Value = where;
            param[1].Value = sortField;
            string sqlCommand = "DawnAuthModuleSelectByParams";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }

        #endregion
        
        #region Exists

        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="mdlId">模块编号</param>
        /// <returns>存在/不存在</returns>
        public bool Exists(int mdlId)
        {
            SqlParameter[] param ={
                new SqlParameter("@MdlId",SqlDbType.Int)
            };
            param[0].Value = mdlId;
            string sqlCommand = "DawnAuthModuleIsExistById";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }
        /// <summary>
        /// 根据名称检测是否存在该条记录
        /// </summary>
        /// <param name="mdlName">模块名称</param>
        /// <returns>存在/不存在</returns>
        public bool Exists(string mdlName)
        {
            SqlParameter[] param ={
                new SqlParameter("@MdlName",SqlDbType.NVarChar,50)
            };
            param[0].Value = mdlName;
            string sqlCommand = "DawnAuthModuleIsExistByName";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }
        /// <summary>
        /// 根据点击检测是否存在该条记录
        /// </summary>
        /// <param name="mdlClick">模块点击</param>
        /// <returns>存在/不存在</returns>
        public bool ExistsOfClick(int mdlClick)
        {
            SqlParameter[] param ={
                new SqlParameter("@MdlClick",SqlDbType.Int)
            };
            param[0].Value = mdlClick;
            string sqlCommand = "DawnAuthModuleIsExistByClick";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }
        /// <summary>
        /// 根据父标识检测是否存在该条记录
        /// </summary>
        /// <param name="mdlFather">模块标识</param>
        /// <returns>存在/不存在</returns>
        public bool ExistsOfFather(int mdlFather)
        {
            SqlParameter[] param ={
                new SqlParameter("@MdlFather",SqlDbType.Int)
            };
            param[0].Value = mdlFather;
            string sqlCommand = "DawnAuthModuleIsExistByChild";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }
        /// <summary>
        /// 根据名称和父标识检测是否存在该条记录
        /// </summary>
        /// <param name="mdlName">模块名称</param>
        /// <param name="mdlFather">模块标识</param>
        /// <returns>存在/不存在</returns>
        public bool Exists(string mdlName, int mdlFather)
        {
            SqlParameter[] param ={
				new SqlParameter("@MdlName",SqlDbType.NVarChar,50),
				new SqlParameter("@MdlFather",SqlDbType.Int)
			};
            param[0].Value = mdlName;
            param[1].Value = mdlFather;
            string sqlCommand = "DawnAuthModuleIsExistByFather";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }
        /// <summary>
        /// 根据编码检测是否存在该条记录
        /// </summary>
        /// <param name="mdlCode">模块编码</param>
        /// <returns>存在/不存在</returns>
        public bool ExistsOfCode(string mdlCode)
        {
            SqlParameter[] param ={
                new SqlParameter("@MdlCode",SqlDbType.VarChar,50)
            };
            param[0].Value = mdlCode;
            string sqlCommand = "DawnAuthModuleIsExistByCode";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }
        /// <summary>
        /// 根据识别码检测是否存在该条记录
        /// </summary>
        /// <param name="mdlIdent">模块识别码</param>
        /// <returns>存在/不存在</returns>
        public bool ExistsOfIdent(int mdlIdent)
        {
            SqlParameter[] param ={
                new SqlParameter("@MdlIdent",SqlDbType.Int)
            };
            param[0].Value = mdlIdent;
            string sqlCommand = "DawnAuthModuleIsExistByIdent";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }
        /// <summary>
        /// 根据编码和识别码检测是否存在该条记录
        /// </summary>
        /// <param name="mdlCode">模块编码</param>
        /// <param name="mdlIdent">模块识别码</param>
        /// <returns>存在/不存在</returns>
        public bool ExistsOfCodeIdent(string mdlCode, int mdlIdent)
        {
            SqlParameter[] param ={
                new SqlParameter("@MdlCode",SqlDbType.VarChar,50),
                new SqlParameter("@MdlIdent",SqlDbType.Int)
            };
            param[0].Value = mdlCode;
            param[1].Value = mdlIdent;
            string sqlCommand = "DawnAuthModuleIsExistByCodeIdent";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }
        /// <summary>
        /// 根据名称和父标识及编码检测是否存在该条记录
        /// </summary>
        /// <param name="mdlName">模块名称</param>
        /// <param name="mdlFather">模块标识</param>
        /// <param name="mdlCode">模块编码</param>
        /// <returns>存在/不存在</returns>
        public bool Exists(string mdlName, int mdlFather, string mdlCode)
        {
            SqlParameter[] param ={
				new SqlParameter("@MdlName",SqlDbType.NVarChar,50),
				new SqlParameter("@MdlFather",SqlDbType.Int),
                new SqlParameter("@MdlCode",SqlDbType.VarChar,50)
			};
            param[0].Value = mdlName;
            param[1].Value = mdlFather;
            param[2].Value = mdlCode;
            string sqlCommand = "DawnAuthModuleIsExistByStrict";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }
        /// <summary>
        /// 根据名称和父标识、编码、识别码检测是否存在该条记录
        /// </summary>
        /// <param name="mdlName">模块名称</param>
        /// <param name="mdlFather">模块标识</param>
        /// <param name="mdlCode">模块编码</param>
        /// <param name="mdlIdent">模块识别码</param>
        /// <returns>存在/不存在</returns>
        public bool Exists(string mdlName, int mdlFather, string mdlCode, int mdlIdent)
        {
            SqlParameter[] param ={
				new SqlParameter("@MdlName",SqlDbType.NVarChar,50),
				new SqlParameter("@MdlFather",SqlDbType.Int),
                new SqlParameter("@MdlCode",SqlDbType.VarChar,50),
                new SqlParameter("@MdlIdent",SqlDbType.Int)
			};
            param[0].Value = mdlName;
            param[1].Value = mdlFather;
            param[2].Value = mdlCode;
            param[3].Value = mdlIdent;
            string sqlCommand = "DawnAuthModuleIsExistByForbid";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
        public bool ExistsOfWhere(string where)
        {
            if (string.IsNullOrEmpty(where)) return false;
            SqlParameter[] param ={
            	new SqlParameter("@where",SqlDbType.VarChar,8000)
            };
            param[0].Value = where;
            string sqlCommand = "DawnAuthModuleIsExistByWhere";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }

        #endregion

        #endregion

        #endregion

    }
}
