// =================================================================== 
// 产品（DawnXZ.Dawnauth.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthModuleDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 20:45:15
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

        #region GetMaxId

        /// <summary>
        /// 获取当前最大系统编号
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            string cmdSql = "select case when max(mdl_id) is null then 0 else max(mdl_id) end from dawn_auth_module";
            int mdlId = 0;
            string tmpVal = SqlHelper.ExecuteScalar(Conn.SqlConn, cmdSql).ToString();
            int.TryParse(tmpVal, out mdlId);
            return mdlId;
        }

        #endregion
        
        #region 添加

        /// <summary>
        /// 向数据表DawnAuthModule中插入一条新记录
        /// </summary>
        /// <param name="dawnAuthModule">DawnAuthModule实体对象</param>
        /// <param name="addFlag">添加标记：False  主分类，True 子分类</param>
        /// <returns></returns>
        public int Insert(DawnAuthModuleMDL dawnAuthModule, bool addFlag)
        {
            string sqlCommand = "DawnAuthModuleInsert";
            int res;
            SqlParameter[] param ={
				new SqlParameter("@MdlId",SqlDbType.Int),
				new SqlParameter("@MdlName",SqlDbType.NVarChar,50),
				new SqlParameter("@MdlFather",SqlDbType.Int),
				new SqlParameter("@MdlCode",SqlDbType.VarChar,50),
				new SqlParameter("@MdlIdent",SqlDbType.Int),
				new SqlParameter("@MdlRank",SqlDbType.Int),
				new SqlParameter("@MdlClick",SqlDbType.Int),
				new SqlParameter("@MdlCounts",SqlDbType.Int),
				new SqlParameter("@MdlDesc",SqlDbType.NVarChar,300),
				new SqlParameter("@MdlTime",SqlDbType.DateTime),
				new SqlParameter("@addFlag",SqlDbType.Bit)
			};
            param[0].Direction = ParameterDirection.Output;
            param[1].Value = dawnAuthModule.MdlName;
            param[2].Value = dawnAuthModule.MdlFather;
            param[3].Value = dawnAuthModule.MdlCode;
            param[4].Value = dawnAuthModule.MdlIdent;
            param[5].Value = dawnAuthModule.MdlRank;
            param[6].Value = dawnAuthModule.MdlClick;
            param[7].Value = dawnAuthModule.MdlCounts;
            param[8].Value = dawnAuthModule.MdlDesc;
            param[9].Value = dawnAuthModule.MdlTime;
            param[10].Value = addFlag;
            res = SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
            dawnAuthModule.MdlId = ((param[0].Value) == DBNull.Value) ? 0 : Convert.ToInt32(param[0].Value);
            return res;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表DawnAuthModule修改一条记录
        /// </summary>
        /// <param name="dawnAuthModule">DawnAuthModule实体对象</param>
        /// <returns></returns>
        public int Update(DawnAuthModuleMDL dawnAuthModule)
        {
            string sqlCommand = "DawnAuthModuleUpdate";
            SqlParameter[] param ={
				new SqlParameter("@MdlId",SqlDbType.Int),
				new SqlParameter("@MdlName",SqlDbType.NVarChar,50),
				new SqlParameter("@MdlCode",SqlDbType.VarChar,50),
				new SqlParameter("@MdlIdent",SqlDbType.Int),
				new SqlParameter("@MdlRank",SqlDbType.Int),
				new SqlParameter("@MdlClick",SqlDbType.Int),
				new SqlParameter("@MdlCounts",SqlDbType.Int),
				new SqlParameter("@MdlDesc",SqlDbType.NVarChar,300)
			};
            param[0].Value = dawnAuthModule.MdlId;
            param[1].Value = dawnAuthModule.MdlName;
            param[2].Value = dawnAuthModule.MdlCode;
            param[3].Value = dawnAuthModule.MdlIdent;
            param[4].Value = dawnAuthModule.MdlRank;
            param[5].Value = dawnAuthModule.MdlClick;
            param[6].Value = dawnAuthModule.MdlCounts;
            param[7].Value = dawnAuthModule.MdlDesc;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }

        #endregion

        #region 点击率

        /// <summary>
        /// 向数据表DawnAuthModule更新点击率
        /// </summary>
        /// <param name="mdlId">系统编号</param>
        /// <returns></returns>
        public int UpdateClick(int mdlId)
        {
            string sqlCommand = "DawnAuthModuleClick";
            SqlParameter[] param ={
				new SqlParameter("@MdlId",SqlDbType.Int)
			};
            param[0].Value = mdlId;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }

        #endregion

        #region 数据统计

        /// <summary>
        /// 向数据表DawnAuthModule更新数据统计
        /// </summary>
        /// <param name="mdlId">系统编号</param>
        /// <param name="countFlag">数据统计标记：0添加，1删除</param>
        /// <returns></returns>
        public int UpdateCounts(int mdlId, byte countFlag)
        {
            string sqlCommand = "DawnAuthModuleCounts";
            SqlParameter[] param ={
				new SqlParameter("@MdlId",SqlDbType.Int),
				new SqlParameter("@CountFlag",SqlDbType.TinyInt)
			};
            param[0].Value = mdlId;
            param[1].Value = countFlag;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }
        /// <summary>
        /// 向数据表DawnAuthModule更新数据统计
        /// </summary>
        /// <param name="mdlId">系统编号</param>
        /// <param name="countFlag">数据统计标记：0添加，1删除</param>
        /// <returns></returns>
        public void UpdateCountAll(int mdlId, byte countFlag)
        {
            UpdateCounts(mdlId, countFlag);
            string cmdSql = "select mdl_father from dawn_auth_module where mdl_id=@MdlId";
            SqlParameter[] param ={
				new SqlParameter("@MdlId",SqlDbType.Int)
			};
            param[0].Value = mdlId;
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, cmdSql, param).ToString();
            int fId = 0;
            int.TryParse(val, out fId);
            if (fId != -1 && fId != 0) UpdateCountAll(fId, countFlag);
        }

        #endregion

        #region 变更

        /// <summary>
        /// 向数据表DawnAuthModule变更一条记录
        /// </summary>
        /// <param name="mdlId">系统编号</param>
        /// <param name="mdlFather">父标识</param>
        /// <returns></returns>
        public int Change(int mdlId, int mdlFather)
        {
            string sqlCommand = "DawnAuthModuleChange";
            SqlParameter[] param ={
				new SqlParameter("@MdlId",SqlDbType.Int),
				new SqlParameter("@MdlFather",SqlDbType.Int)
			};
            param[0].Value = mdlId;
            param[1].Value = mdlFather;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表DawnAuthModule中的一条记录
        /// </summary>
        /// <param name="mdlId">系统编号</param>
        /// <param name="delFlag">删除标记：False  删除指定，True 删除所有</param>
        /// <returns></returns>
        public int Delete(int mdlId, bool delFlag)
        {
            string sqlCommand = "DawnAuthModuleDelete";
            SqlParameter[] param ={
				new SqlParameter("@MdlId",SqlDbType.Int),
				new SqlParameter("@delFlag",SqlDbType.Bit)
			};
            param[0].Value = mdlId;
            param[1].Value = delFlag;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }
        /// <summary>
        /// 根据指定条件删除数据表DawnAuthModule中的记录
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        public int DeleteWhere(string where)
        {
            if (string.IsNullOrEmpty(where)) return -1;
            string sqlCommand = "DawnAuthModuleDeleteWhere";
            SqlParameter[] param ={
            	new SqlParameter("@where",SqlDbType.VarChar,8000)
            };
            param[0].Value = where;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }

        #endregion

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
        /// <summary>
        /// 得到数据表DawnAuthModule满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public List<DawnAuthModuleMDL> LSelect(CommandType commandType, string sqlCommand, params SqlParameter[] param)
        {
            List<DawnAuthModuleMDL> list = new List<DawnAuthModuleMDL>();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, commandType, sqlCommand, param))
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
        /// <summary>
        /// 得到数据表DawnAuthModule满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public IList<DawnAuthModuleMDL> ISelect(CommandType commandType, string sqlCommand, params SqlParameter[] param)
        {
            IList<DawnAuthModuleMDL> list = new List<DawnAuthModuleMDL>();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(Conn.SqlConn, commandType, sqlCommand, param))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }

        #endregion

        /// <summary>
        /// 得到数据表DawnAuthModule满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public void Select(string where, out int recordCount)
        {
            string sqlCommand = "DawnAuthModuleCountByWhere";
            SqlParameter[] param ={
			new SqlParameter("@where",SqlDbType.VarChar,8000),
			new SqlParameter("@recordCount",SqlDbType.Int)
			};
            param[0].Value = where;
            param[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
            recordCount = Convert.ToInt32(param[1].Value);
        }

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

        #region 按指定条件分页查询数据（仅用于主键排序）

        /// <summary>
        /// 通过指定条件分页查询数据（仅用于主键排序）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="pageIndex">要显示那一页的记录</param>
        /// <param name="strWhere">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="RecordCount">查询到的总记录数</param>
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPinPK(int pageSize, int pageIndex, string strWhere, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPinPK("dawn_auth_module", "*", -1, pageSize, pageIndex, strWhere, "mdl_id", "mdl_id", 1, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPinPK(int intTop, int pageSize, int pageIndex, string strWhere, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPinPK("dawn_auth_module", "*", intTop, pageSize, pageIndex, strWhere, "mdl_id", "mdl_id", 1, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPinPK(string strField, int intTop, int pageSize, int pageIndex, string strWhere, string strSortField, byte strOrderBy, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPinPK("dawn_auth_module", strField, intTop, pageSize, pageIndex, strWhere, "mdl_id", strSortField, strOrderBy, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPinPK(string strTable, string strField, int intTop, int pageSize, int pageIndex, string strWhere, string strSortKey, string strSortField, byte strOrderBy, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            List<DawnAuthModuleMDL> list = new List<DawnAuthModuleMDL>();
            string sqlCommand = "ThePSPInPrimaryKey";
            SqlParameter[] param ={
                                      new SqlParameter("@strTable",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@strField",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@intTop",SqlDbType.Int),
                                      new SqlParameter("@pageSize",SqlDbType.Int),
                                      new SqlParameter("@pageIndex",SqlDbType.Int),
                                      new SqlParameter("@strWhere",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@strSortKey",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@strSortField",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@strOrderBy",SqlDbType.Bit),
                                      new SqlParameter("@pageCount",SqlDbType.Int),
                                      new SqlParameter("@RecordCount",SqlDbType.Int),
                                      new SqlParameter("@UsedTime",SqlDbType.Int),
                                      new SqlParameter("@strSql",SqlDbType.NVarChar,-1)
                                  };
            param[0].Value = strTable;
            param[1].Value = strField;
            param[2].Value = intTop;
            param[3].Value = pageSize;
            param[4].Value = pageIndex;
            param[5].Value = strWhere;
            param[6].Value = strSortKey;
            param[7].Value = strSortField;
            param[8].Value = strOrderBy;
            param[9].Direction = ParameterDirection.Output;
            param[10].Direction = ParameterDirection.Output;
            param[11].Direction = ParameterDirection.Output;
            param[12].Direction = ParameterDirection.Output;
            using (DataSet ds = SqlHelper.ExecuteDataset(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param))
            {
                foreach (DataTable dt in ds.Tables)
                {
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        list.Add(this.Select(dt.Rows[intCount]));
                    }
                }
            }
            pageCount = Convert.ToInt32(param[9].Value);
            RecordCount = Convert.ToInt32(param[10].Value);
            UsedTime = Convert.ToInt32(param[11].Value);
            strSql = Convert.ToString(param[12].Value);
            return list;
        }

        #endregion 按指定条件分页查询数据（仅用于主键排序）

        #region 按指定条件分页查询数据（通用排序方式）

        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurpose(int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurpose("dawn_auth_module", "*", pageSize, page, "mdl_id", 1, strCondition, "mdl_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurpose(string fldName, int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurpose("dawn_auth_module", fldName, pageSize, page, "mdl_id", 1, strCondition, "mdl_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurpose(string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, byte Dist, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurpose("dawn_auth_module", fldName, pageSize, page, fldSort, Sort, strCondition, "mdl_id", Dist, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurpose(string tblName, string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, string ID, byte Dist, out int pageCount, out int Counts, out int UsedTime, out string strSql)
        {
            List<DawnAuthModuleMDL> list = new List<DawnAuthModuleMDL>();
            string sqlCommand = "ThePSPIsAllPurpose";
            SqlParameter[] param ={
                                      new SqlParameter("@tblName",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@fldName",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@pageSize",SqlDbType.Int),
                                      new SqlParameter("@page",SqlDbType.Int),
                                      new SqlParameter("@fldSort",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@Sort",SqlDbType.Bit),
                                      new SqlParameter("@strCondition",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@ID",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@Dist",SqlDbType.Bit),
                                      new SqlParameter("@pageCount",SqlDbType.Int),
                                      new SqlParameter("@Counts",SqlDbType.Int),
                                      new SqlParameter("@UsedTime",SqlDbType.Int),
                                      new SqlParameter("@strSql",SqlDbType.NVarChar,-1)
                                  };
            param[0].Value = tblName;
            param[1].Value = fldName;
            param[2].Value = pageSize;
            param[3].Value = page;
            param[4].Value = fldSort;
            param[5].Value = Sort;
            param[6].Value = strCondition;
            param[7].Value = ID;
            param[8].Value = Dist;
            param[9].Direction = ParameterDirection.Output;
            param[10].Direction = ParameterDirection.Output;
            param[11].Direction = ParameterDirection.Output;
            param[12].Direction = ParameterDirection.Output;
            using (DataSet ds = SqlHelper.ExecuteDataset(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param))
            {
                foreach (DataTable dt in ds.Tables)
                {
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        list.Add(this.Select(dt.Rows[intCount]));
                    }
                }
            }
            pageCount = Convert.ToInt32(param[9].Value);
            Counts = Convert.ToInt32(param[10].Value);
            UsedTime = Convert.ToInt32(param[11].Value);
            strSql = Convert.ToString(param[12].Value);
            return list;
        }

        #endregion 按指定条件分页查询数据（通用排序方式）

        #region 按指定条件分页查询数据（通用排序方式·NotIn）

        /// <summary>
        /// 通过指定条件分页查询数据（通用排序方式·NotIn）
        /// </summary>
        /// <param name="pageSize">每页显示的记录个数</param>
        /// <param name="page">要显示那一页的记录</param>
        /// <param name="strCondition">查询条件,不需where</param>
        /// <param name="pageCount">查询结果分页后的总页数</param>
        /// <param name="Counts">查询到的总记录数</param>
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurposeNotIn(int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeNotIn("dawn_auth_module", "*", pageSize, page, "mdl_id", 0, strCondition, "mdl_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurposeNotIn(string fldName, int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeNotIn("dawn_auth_module", fldName, pageSize, page, "mdl_id", 0, strCondition, "mdl_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurposeNotIn(string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, byte Dist, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeNotIn("dawn_auth_module", fldName, pageSize, page, fldSort, Sort, strCondition, "mdl_id", Dist, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurposeNotIn(string tblName, string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, string ID, byte Dist, out int pageCount, out int Counts, out int UsedTime, out string strSql)
        {
            List<DawnAuthModuleMDL> list = new List<DawnAuthModuleMDL>();
            string sqlCommand = "ThePSPIsAllPurposeNotIn";
            SqlParameter[] param ={
                                      new SqlParameter("@tblName",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@fldName",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@pageSize",SqlDbType.Int),
                                      new SqlParameter("@page",SqlDbType.Int),
                                      new SqlParameter("@fldSort",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@Sort",SqlDbType.Bit),
                                      new SqlParameter("@strCondition",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@ID",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@Dist",SqlDbType.Bit),
                                      new SqlParameter("@pageCount",SqlDbType.Int),
                                      new SqlParameter("@Counts",SqlDbType.Int),
                                      new SqlParameter("@UsedTime",SqlDbType.Int),
                                      new SqlParameter("@strSql",SqlDbType.NVarChar,-1)
                                  };
            param[0].Value = tblName;
            param[1].Value = fldName;
            param[2].Value = pageSize;
            param[3].Value = page;
            param[4].Value = fldSort;
            param[5].Value = Sort;
            param[6].Value = strCondition;
            param[7].Value = ID;
            param[8].Value = Dist;
            param[9].Direction = ParameterDirection.Output;
            param[10].Direction = ParameterDirection.Output;
            param[11].Direction = ParameterDirection.Output;
            param[12].Direction = ParameterDirection.Output;
            using (DataSet ds = SqlHelper.ExecuteDataset(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param))
            {
                foreach (DataTable dt in ds.Tables)
                {
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        list.Add(this.Select(dt.Rows[intCount]));
                    }
                }
            }
            pageCount = Convert.ToInt32(param[9].Value);
            Counts = Convert.ToInt32(param[10].Value);
            UsedTime = Convert.ToInt32(param[11].Value);
            strSql = Convert.ToString(param[12].Value);
            return list;
        }

        #endregion 按指定条件分页查询数据（通用排序方式·NotIn）

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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_module", "*", pageSize, pageIndex, "mdl_id", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_module", "*", pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_module", fldName, pageSize, pageIndex, "mdl_id", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_module", fldName, pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_module", "*", pageSize, pageIndex, "mdl_id", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_module", "*", pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_module", fldName, pageSize, pageIndex, "mdl_id", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_module", fldName, pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthModule 结果集</returns>
        public List<DawnAuthModuleMDL> SelectPSPisAllPurposeRowNumber(string tblName, string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            List<DawnAuthModuleMDL> list = new List<DawnAuthModuleMDL>();
            string sqlCommand = "SjjPagination";
            SqlParameter[] param ={
                                      new SqlParameter("@tblName",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@fldName",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@pageSize",SqlDbType.Int),
                                      new SqlParameter("@pageIndex",SqlDbType.Int),
                                      new SqlParameter("@fldSort",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@strCondition",SqlDbType.NVarChar,-1),
                                      new SqlParameter("@pageCount",SqlDbType.Int),
                                      new SqlParameter("@RecordCount",SqlDbType.Int),
                                      new SqlParameter("@UsedTime",SqlDbType.Int),
                                      new SqlParameter("@strSql",SqlDbType.NVarChar,-1)
                                  };
            param[0].Value = tblName;
            param[1].Value = fldName;
            param[2].Value = pageSize;
            param[3].Value = pageIndex;
            param[4].Value = fldSort;
            param[5].Value = strCondition;
            param[6].Direction = ParameterDirection.Output;
            param[7].Direction = ParameterDirection.Output;
            param[8].Direction = ParameterDirection.Output;
            param[9].Direction = ParameterDirection.Output;
            using (DataSet ds = SqlHelper.ExecuteDataset(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param))
            {
                foreach (DataTable dt in ds.Tables)
                {
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        list.Add(this.Select(dt.Rows[intCount]));
                    }
                }
            }
            pageCount = Convert.ToInt32(param[6].Value);
            RecordCount = Convert.ToInt32(param[7].Value);
            UsedTime = Convert.ToInt32(param[8].Value);
            strSql = Convert.ToString(param[9].Value);
            return list;
        }

        #endregion

        #endregion

    }
}
