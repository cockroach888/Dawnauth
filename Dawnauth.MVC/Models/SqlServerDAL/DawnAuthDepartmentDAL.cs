// =================================================================== 
// 产品（DawnXZ.Dawnauth.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthDepartmentDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:34:35
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
    /// 数据访问层DawnAuthDepartment
    /// </summary>
    public partial class DawnAuthDepartmentDAL : IDawnAuthDepartmentDAL
    {
		
		#region 构造函数
		
		/// <summary>
		/// 数据层实例化
		/// </summary>
		public DawnAuthDepartmentDAL()
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
            string cmdSql="select case when max(dpt_id) is null then 0 else max(dpt_id) end from dawn_auth_department";
            int dptId=0;
            string tmpVal=SqlHelper.ExecuteScalar(Conn.SqlConn, cmdSql).ToString();
            int.TryParse(tmpVal,out dptId);
            return dptId;
        }
        
        #endregion
        
		#region 添加
		
		/// <summary>
		/// 向数据表DawnAuthDepartment中插入一条新记录
		/// </summary>
		/// <param name="dawnAuthDepartment">DawnAuthDepartment实体对象</param>
		/// <param name="addFlag">添加标记：False  主分类，True 子分类</param>
		/// <returns></returns>
		public int Insert(DawnAuthDepartmentMDL dawnAuthDepartment,bool addFlag)
		{
			string sqlCommand="DawnAuthDepartmentInsert";
			int res;
			SqlParameter[] param={
				new SqlParameter("@DptId",SqlDbType.Int),
				new SqlParameter("@DptName",SqlDbType.NVarChar,50),
				new SqlParameter("@DptFather",SqlDbType.Int),
				new SqlParameter("@DptCode",SqlDbType.VarChar,50),
				new SqlParameter("@DptIdent",SqlDbType.Int),
				new SqlParameter("@DptRank",SqlDbType.Int),
				new SqlParameter("@DptClick",SqlDbType.Int),
				new SqlParameter("@DptCounts",SqlDbType.Int),
				new SqlParameter("@DptDesc",SqlDbType.NVarChar,300),
				new SqlParameter("@DptTime",SqlDbType.DateTime),
				new SqlParameter("@addFlag",SqlDbType.Bit)
			};
			param[0].Direction = ParameterDirection.Output;
			param[1].Value=dawnAuthDepartment.DptName;
			param[2].Value=dawnAuthDepartment.DptFather;
			param[3].Value=dawnAuthDepartment.DptCode;
			param[4].Value=dawnAuthDepartment.DptIdent;
			param[5].Value=dawnAuthDepartment.DptRank;
			param[6].Value=dawnAuthDepartment.DptClick;
			param[7].Value=dawnAuthDepartment.DptCounts;
			param[8].Value=dawnAuthDepartment.DptDesc;
			param[9].Value=dawnAuthDepartment.DptTime;
			param[10].Value=addFlag;
			res = SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param);
			dawnAuthDepartment.DptId=((param[0].Value)==DBNull.Value)?0:Convert.ToInt32(param[0].Value);
			return res;
		}
		
		#endregion
		
		#region 修改
		
		/// <summary>
		/// 向数据表DawnAuthDepartment修改一条记录
		/// </summary>
		/// <param name="dawnAuthDepartment">DawnAuthDepartment实体对象</param>
		/// <returns></returns>
		public int Update(DawnAuthDepartmentMDL dawnAuthDepartment)
		{
            string sqlCommand="DawnAuthDepartmentUpdate";
			SqlParameter[] param={
				new SqlParameter("@DptId",SqlDbType.Int),
				new SqlParameter("@DptName",SqlDbType.NVarChar,50),
				new SqlParameter("@DptCode",SqlDbType.VarChar,50),
				new SqlParameter("@DptIdent",SqlDbType.Int),
				new SqlParameter("@DptRank",SqlDbType.Int),
				new SqlParameter("@DptClick",SqlDbType.Int),
				new SqlParameter("@DptCounts",SqlDbType.Int),
				new SqlParameter("@DptDesc",SqlDbType.NVarChar,300)
			};
			param[0].Value=dawnAuthDepartment.DptId;
			param[1].Value=dawnAuthDepartment.DptName;
			param[2].Value=dawnAuthDepartment.DptCode;
			param[3].Value=dawnAuthDepartment.DptIdent;
			param[4].Value=dawnAuthDepartment.DptRank;
			param[5].Value=dawnAuthDepartment.DptClick;
			param[6].Value=dawnAuthDepartment.DptCounts;
			param[7].Value=dawnAuthDepartment.DptDesc;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param);
		}
		
		#endregion
		
		#region 点击率
		
		/// <summary>
		/// 向数据表DawnAuthDepartment更新点击率
		/// </summary>
		/// <param name="dptId">系统编号</param>
		/// <returns></returns>
		public int UpdateClick(int dptId)
		{
            string sqlCommand="DawnAuthDepartmentClick";
			SqlParameter[] param={
				new SqlParameter("@DptId",SqlDbType.Int)
			};
			param[0].Value=dptId;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param);
		}
		
		#endregion
		
		#region 数据统计
		
		/// <summary>
		/// 向数据表DawnAuthDepartment更新数据统计
		/// </summary>
		/// <param name="dptId">系统编号</param>
		/// <param name="countFlag">数据统计标记：0添加，1删除</param>
		/// <returns></returns>
		public int UpdateCounts(int dptId,byte countFlag)
		{
            string sqlCommand="DawnAuthDepartmentCounts";
			SqlParameter[] param={
				new SqlParameter("@DptId",SqlDbType.Int),
				new SqlParameter("@CountFlag",SqlDbType.TinyInt)
			};
			param[0].Value=dptId;
			param[1].Value=countFlag;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param);
		}
        /// <summary>
		/// 向数据表DawnAuthDepartment更新数据统计
		/// </summary>
		/// <param name="dptId">系统编号</param>
		/// <param name="countFlag">数据统计标记：0添加，1删除</param>
		/// <returns></returns>
		public void UpdateCountAll(int dptId,byte countFlag)
		{
            UpdateCounts(dptId, countFlag);
            string cmdSql = "select dpt_father from dawn_auth_department where dpt_id=@DptId";            
			SqlParameter[] param={
				new SqlParameter("@DptId",SqlDbType.Int)
			};
			param[0].Value=dptId;            
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, cmdSql, param).ToString();            
            int fId = 0;
            int.TryParse(val, out fId);
            if (fId != -1 && fId != 0) UpdateCountAll(fId, countFlag);
		}
		
		#endregion
		
		#region 变更
		
		/// <summary>
		/// 向数据表DawnAuthDepartment变更一条记录
		/// </summary>
		/// <param name="dptId">系统编号</param>
		/// <param name="dptFather">父标识</param>
		/// <returns></returns>
		public int Change(int dptId,int dptFather)
		{
            string sqlCommand="DawnAuthDepartmentChange";
			SqlParameter[] param={
				new SqlParameter("@DptId",SqlDbType.Int),
				new SqlParameter("@DptFather",SqlDbType.Int)
			};
			param[0].Value=dptId;
			param[1].Value=dptFather;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param);
		}
		
		#endregion
		
		#region 删除
		
		/// <summary>
		/// 删除数据表DawnAuthDepartment中的一条记录
		/// </summary>
	    /// <param name="dptId">系统编号</param>
		/// <param name="delFlag">删除标记：False  删除指定，True 删除所有</param>
		/// <returns></returns>
		public int Delete(int dptId,bool delFlag)
		{
			string sqlCommand="DawnAuthDepartmentDelete";
			SqlParameter[] param={
				new SqlParameter("@DptId",SqlDbType.Int),
				new SqlParameter("@delFlag",SqlDbType.Bit)
			};
			param[0].Value=dptId;
			param[1].Value=delFlag;
			return SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param);
		}
        /// <summary>
        /// 根据指定条件删除数据表DawnAuthDepartment中的记录
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        public int DeleteWhere(string where)
        {
            if(string.IsNullOrEmpty(where)) return -1;
            string sqlCommand = "DawnAuthDepartmentDeleteWhere";
            SqlParameter[] param={
            	new SqlParameter("@where",SqlDbType.VarChar,8000)
            };
            param[0].Value=where;
            return SqlHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param);
        }
		
		#endregion
		
		#region 实体对象
		
		/// <summary>
		/// 得到DawnAuthDepartment实体对象
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>DawnAuthDepartment实体对象</returns>
		public DawnAuthDepartmentMDL Select(DataRow row)
		{
			DawnAuthDepartmentMDL obj = new DawnAuthDepartmentMDL();
			if(row!=null)
			{
				try
				{
					obj.DptId = (( row["dpt_id"])==DBNull.Value)?0:Convert.ToInt32( row["dpt_id"]);
				}
				catch { }
				try
				{
					obj.DptName =  row["dpt_name"].ToString();
				}
				catch { }
				try
				{
					obj.DptFather = (( row["dpt_father"])==DBNull.Value)?0:Convert.ToInt32( row["dpt_father"]);
				}
				catch { }
				try
				{
					obj.DptPath =  row["dpt_path"].ToString();
				}
				catch { }
				try
				{
					obj.DptCode =  row["dpt_code"].ToString();
				}
				catch { }
				try
				{
					obj.DptIdent = (( row["dpt_ident"])==DBNull.Value)?0:Convert.ToInt32( row["dpt_ident"]);
				}
				catch { }
				try
				{
					obj.DptRank = (( row["dpt_rank"])==DBNull.Value)?0:Convert.ToInt32( row["dpt_rank"]);
				}
				catch { }
				try
				{
					obj.DptClick = (( row["dpt_click"])==DBNull.Value)?0:Convert.ToInt32( row["dpt_click"]);
				}
				catch { }
				try
				{
					obj.DptCounts = (( row["dpt_counts"])==DBNull.Value)?0:Convert.ToInt32( row["dpt_counts"]);
				}
				catch { }
				try
				{
					obj.DptDesc =  row["dpt_desc"].ToString();
				}
				catch { }
				try
				{
					obj.DptTime = (( row["dpt_time"])==DBNull.Value)?DateTime.MinValue:Convert.ToDateTime( row["dpt_time"]);
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
		/// 得到DawnAuthDepartment实体对象
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>DawnAuthDepartment实体对象</returns>
		public DawnAuthDepartmentMDL Select(IDataReader dr)
		{
			DawnAuthDepartmentMDL obj = new DawnAuthDepartmentMDL();
			try
			{
				obj.DptId = (( dr["dpt_id"])==DBNull.Value)?0:Convert.ToInt32( dr["dpt_id"]);
			}
			catch { }
			try
			{
				obj.DptName =  dr["dpt_name"].ToString();
			}
			catch { }
			try
			{
				obj.DptFather = (( dr["dpt_father"])==DBNull.Value)?0:Convert.ToInt32( dr["dpt_father"]);
			}
			catch { }
			try
			{
				obj.DptPath =  dr["dpt_path"].ToString();
			}
			catch { }
			try
			{
				obj.DptCode =  dr["dpt_code"].ToString();
			}
			catch { }
			try
			{
				obj.DptIdent = (( dr["dpt_ident"])==DBNull.Value)?0:Convert.ToInt32( dr["dpt_ident"]);
			}
			catch { }
			try
			{
				obj.DptRank = (( dr["dpt_rank"])==DBNull.Value)?0:Convert.ToInt32( dr["dpt_rank"]);
			}
			catch { }
			try
			{
				obj.DptClick = (( dr["dpt_click"])==DBNull.Value)?0:Convert.ToInt32( dr["dpt_click"]);
			}
			catch { }
			try
			{
				obj.DptCounts = (( dr["dpt_counts"])==DBNull.Value)?0:Convert.ToInt32( dr["dpt_counts"]);
			}
			catch { }
			try
			{
				obj.DptDesc =  dr["dpt_desc"].ToString();
			}
			catch { }
			try
			{
				obj.DptTime = (( dr["dpt_time"])==DBNull.Value)?DateTime.MinValue:Convert.ToDateTime( dr["dpt_time"]);
			}
			catch { }
			return obj;
		}			
		/// <summary>
		/// 根据ID,返回一个DawnAuthDepartment实体对象
		/// </summary>
		/// <param name="dptId">系统编号</param>
		/// <returns>DawnAuthDepartment实体对象</returns>
		public DawnAuthDepartmentMDL Select(int dptId)
		{
			DawnAuthDepartmentMDL obj=null;
			SqlParameter[] param={
			new SqlParameter("@DptId",SqlDbType.Int)
			};
			param[0].Value=dptId;
			string sqlCommand="DawnAuthDepartmentSelect";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param))
			{
				while(dr.Read())
				{
            		obj=this.Select(dr);
				}
			}
			return obj;
		}
		
		#endregion
		
		#region 查询
		
        #region List
        
        /// <summary>
		/// 得到数据表DawnAuthDepartment所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public List< DawnAuthDepartmentMDL> LSelect()
		{
			return this.LSelect(string.Empty);
		}
        /// <summary>
        /// 得到数据表DawnAuthDepartment所有父记录
        /// </summary>
        /// <returns>结果集</returns>
        public List< DawnAuthDepartmentMDL> LSelectFather()
        {
            return this.LSelect(" dpt_father = -1");
        }
		/// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public List< DawnAuthDepartmentMDL> LSelect(string where)
		{
			return this.LSelect(where," [dpt_id] DESC ");
		}
		/// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public List< DawnAuthDepartmentMDL> LSelect(string where,string sortField)
		{
			List< DawnAuthDepartmentMDL> list=new List< DawnAuthDepartmentMDL>();
			SqlParameter[] param={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
			param[0].Value=where;
			param[1].Value=sortField;
			string sqlCommand="DawnAuthDepartmentSelectByParams";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param))
			{
				while(dr.Read())
				{
					list.Add(this.Select(dr));
				}
			}
			return list;
		}
        /// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		public List< DawnAuthDepartmentMDL > LSelect(CommandType commandType,string sqlCommand,params SqlParameter[] param)
		{
			List< DawnAuthDepartmentMDL> list=new List< DawnAuthDepartmentMDL>();
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,commandType,sqlCommand,param))
			{
				while(dr.Read())
				{
					list.Add(this.Select(dr));
				}
			}
			return list;
		}
        
        #endregion
        
        #region IList
        
        /// <summary>
		/// 得到数据表DawnAuthDepartment所有记录
		/// </summary>
		/// <returns>结果集</returns>
		public IList< DawnAuthDepartmentMDL> ISelect()
		{
			return this.ISelect(string.Empty);
		}
        /// <summary>
        /// 得到数据表DawnAuthDepartment所有父记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList< DawnAuthDepartmentMDL> ISelectFather()
        {
            return this.ISelect(" dpt_father = -1");
        }
		/// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <returns>结果集</returns>
		public IList< DawnAuthDepartmentMDL> ISelect(string where)
		{
			return this.ISelect(where," [dpt_id] DESC ");
		}
		/// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件的记录
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="sortField">排序字段</param>
		/// <returns>结果集</returns>
		public IList< DawnAuthDepartmentMDL> ISelect(string where,string sortField)
		{
			IList< DawnAuthDepartmentMDL> list=new List< DawnAuthDepartmentMDL>();
			SqlParameter[] param={
				new SqlParameter("@where",SqlDbType.VarChar,8000),
				new SqlParameter("@sortField",SqlDbType.VarChar,100)
			};
			param[0].Value=where;
			param[1].Value=sortField;
			string sqlCommand="DawnAuthDepartmentSelectByParams";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param))
			{
				while(dr.Read())
				{
					list.Add(this.Select(dr));
				}
			}
			return list;
		}
        /// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件记录
		/// </summary>
		/// <param name="commandType">命令类型</param>
		/// <param name="sqlCommand">SQL命令</param>
		/// <param name="param">命令参数数组</param>
		/// <returns>结果集</returns>
		public IList< DawnAuthDepartmentMDL > ISelect(CommandType commandType,string sqlCommand,params SqlParameter[] param)
		{
			IList< DawnAuthDepartmentMDL> list=new List< DawnAuthDepartmentMDL>();
			using(SqlDataReader dr=SqlHelper.ExecuteReader(Conn.SqlConn,commandType,sqlCommand,param))
			{
				while(dr.Read())
				{
					list.Add(this.Select(dr));
				}
			}
			return list;
		}
        
        #endregion
                		
		/// <summary>
		/// 得到数据表DawnAuthDepartment满足查询条件的记录数
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="recordCount">记录数</param>
		public void Select(string where,out int recordCount)
		{
			string sqlCommand="DawnAuthDepartmentCountByWhere";
			SqlParameter[] param={
			new SqlParameter("@where",SqlDbType.VarChar,8000),
			new SqlParameter("@recordCount",SqlDbType.Int)
			};
			param[0].Value=where;
			param[1].Direction = ParameterDirection.Output;
			SqlHelper.ExecuteNonQuery(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param);
			recordCount = Convert.ToInt32(param[1].Value);
		}
        
        #region Exists
        
		/// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="dptId">系统编号</param>
        /// <returns>存在/不存在</returns>
		public bool Exists(int dptId)
		{
			SqlParameter[] param={
                new SqlParameter("@DptId",SqlDbType.Int)
            };
            param[0].Value=dptId;
            string sqlCommand="DawnAuthDepartmentIsExistById";
            string val=SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp>0?true:false;
		}
        /// <summary>
        /// 根据名称检测是否存在该条记录
        /// </summary>
        /// <param name="dptName">部门名称</param>
        /// <returns>存在/不存在</returns>
		public bool Exists(string dptName)
        {
            SqlParameter[] param={
                new SqlParameter("@DptName",SqlDbType.NVarChar,50)
            };
            param[0].Value =dptName;
            string sqlCommand = "DawnAuthDepartmentIsExistByName";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp>0?true:false;
        }
        /// <summary>
        /// 根据点击检测是否存在该条记录
        /// </summary>
        /// <param name="dptClick">部门点击</param>
        /// <returns>存在/不存在</returns>
		public bool ExistsOfClick(int dptClick)
        {
            SqlParameter[] param ={
                new SqlParameter("@DptClick",SqlDbType.Int)
            };
            param[0].Value =dptClick;
            string sqlCommand = "DawnAuthDepartmentIsExistByClick";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp>0?true:false;
        }
        /// <summary>
        /// 根据父标识检测是否存在该条记录
        /// </summary>
        /// <param name="dptFather">部门标识</param>
        /// <returns>存在/不存在</returns>
		public bool ExistsOfFather(int dptFather)
        {
            SqlParameter[] param ={
                new SqlParameter("@DptFather",SqlDbType.Int)
            };
            param[0].Value =dptFather;
            string sqlCommand = "DawnAuthDepartmentIsExistByChild";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp>0?true:false;
        }
        /// <summary>
        /// 根据名称和父标识检测是否存在该条记录
        /// </summary>
        /// <param name="dptName">部门名称</param>
        /// <param name="dptFather">部门标识</param>
        /// <returns>存在/不存在</returns>
		public bool Exists(string dptName,int dptFather)
        {
            SqlParameter[] param={
				new SqlParameter("@DptName",SqlDbType.NVarChar,50),
				new SqlParameter("@DptFather",SqlDbType.Int)
			};
            param[0].Value =dptName;
            param[1].Value =dptFather;
            string sqlCommand = "DawnAuthDepartmentIsExistByFather";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp>0?true:false;
        }
        /// <summary>
        /// 根据编码检测是否存在该条记录
        /// </summary>
        /// <param name="dptCode">部门编码</param>
        /// <returns>存在/不存在</returns>
		public bool ExistsOfCode(string dptCode)
        {
            SqlParameter[] param ={
                new SqlParameter("@DptCode",SqlDbType.VarChar,50)
            };
            param[0].Value =dptCode;
            string sqlCommand = "DawnAuthDepartmentIsExistByCode";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp>0?true:false;
        }
        /// <summary>
        /// 根据识别码检测是否存在该条记录
        /// </summary>
        /// <param name="dptIdent">部门识别码</param>
        /// <returns>存在/不存在</returns>
		public bool ExistsOfIdent(int dptIdent)
        {
            SqlParameter[] param ={
                new SqlParameter("@DptIdent",SqlDbType.Int)
            };
            param[0].Value =dptIdent;
            string sqlCommand = "DawnAuthDepartmentIsExistByIdent";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp>0?true:false;
        }
        /// <summary>
        /// 根据编码和识别码检测是否存在该条记录
        /// </summary>
        /// <param name="dptCode">部门编码</param>
        /// <param name="dptIdent">部门识别码</param>
        /// <returns>存在/不存在</returns>
		public bool ExistsOfCodeIdent(string dptCode,int dptIdent)
        {
            SqlParameter[] param ={
                new SqlParameter("@DptCode",SqlDbType.VarChar,50),
                new SqlParameter("@DptIdent",SqlDbType.Int)
            };
            param[0].Value =dptCode;
            param[1].Value =dptIdent;
            string sqlCommand = "DawnAuthDepartmentIsExistByCodeIdent";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp>0?true:false;
        }
        /// <summary>
        /// 根据名称和父标识及编码检测是否存在该条记录
        /// </summary>
        /// <param name="dptName">部门名称</param>
        /// <param name="dptFather">部门标识</param>
        /// <param name="dptCode">部门编码</param>
        /// <returns>存在/不存在</returns>
		public bool Exists(string dptName,int dptFather,string dptCode)
        {
            SqlParameter[] param={
				new SqlParameter("@DptName",SqlDbType.NVarChar,50),
				new SqlParameter("@DptFather",SqlDbType.Int),
                new SqlParameter("@DptCode",SqlDbType.VarChar,50)
			};
            param[0].Value =dptName;
            param[1].Value =dptFather;
            param[2].Value =dptCode;
            string sqlCommand = "DawnAuthDepartmentIsExistByStrict";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp>0?true:false;
        }
        /// <summary>
        /// 根据名称和父标识、编码、识别码检测是否存在该条记录
        /// </summary>
        /// <param name="dptName">部门名称</param>
        /// <param name="dptFather">部门标识</param>
        /// <param name="dptCode">部门编码</param>
        /// <param name="dptIdent">部门识别码</param>
        /// <returns>存在/不存在</returns>
		public bool Exists(string dptName,int dptFather,string dptCode,int dptIdent)
        {
            SqlParameter[] param={
				new SqlParameter("@DptName",SqlDbType.NVarChar,50),
				new SqlParameter("@DptFather",SqlDbType.Int),
                new SqlParameter("@DptCode",SqlDbType.VarChar,50),
                new SqlParameter("@DptIdent",SqlDbType.Int)
			};
            param[0].Value =dptName;
            param[1].Value =dptFather;
            param[2].Value =dptCode;
            param[3].Value =dptIdent;
            string sqlCommand = "DawnAuthDepartmentIsExistByForbid";
            string val = SqlHelper.ExecuteScalar(Conn.SqlConn, CommandType.StoredProcedure, sqlCommand, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp>0?true:false;
        }
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
		public bool ExistsOfWhere(string where)
		{
            if(string.IsNullOrEmpty(where)) return false;
			SqlParameter[] param={
            	new SqlParameter("@where",SqlDbType.VarChar,8000)
            };
            param[0].Value=where;
            string sqlCommand="DawnAuthDepartmentIsExistByWhere";
            string val=SqlHelper.ExecuteScalar(Conn.SqlConn,CommandType.StoredProcedure,sqlCommand,param).ToString();
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPinPK(int pageSize, int pageIndex, string strWhere, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPinPK("dawn_auth_department", "*", -1, pageSize, pageIndex, strWhere, "dpt_id", "dpt_id", 1, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPinPK(int intTop, int pageSize, int pageIndex, string strWhere, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPinPK("dawn_auth_department", "*", intTop, pageSize, pageIndex, strWhere, "dpt_id", "dpt_id", 1, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPinPK(string strField, int intTop, int pageSize, int pageIndex, string strWhere, string strSortField, byte strOrderBy, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPinPK("dawn_auth_department", strField, intTop, pageSize, pageIndex, strWhere, "dpt_id", strSortField, strOrderBy, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPinPK(string strTable, string strField, int intTop, int pageSize, int pageIndex, string strWhere, string strSortKey, string strSortField, byte strOrderBy, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            List< DawnAuthDepartmentMDL> list = new List< DawnAuthDepartmentMDL>();
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurpose(int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurpose("dawn_auth_department", "*", pageSize, page, "dpt_id", 1, strCondition, "dpt_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurpose(string fldName, int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurpose("dawn_auth_department", fldName, pageSize, page, "dpt_id", 1, strCondition, "dpt_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurpose(string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, byte Dist, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurpose("dawn_auth_department", fldName, pageSize, page, fldSort, Sort, strCondition, "dpt_id", Dist, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurpose(string tblName, string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, string ID, byte Dist, out int pageCount, out int Counts, out int UsedTime, out string strSql)
        {
            List< DawnAuthDepartmentMDL> list = new List< DawnAuthDepartmentMDL>();
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeNotIn(int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeNotIn("dawn_auth_department", "*", pageSize, page, "dpt_id", 0, strCondition, "dpt_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeNotIn(string fldName, int pageSize, int page, string strCondition, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeNotIn("dawn_auth_department", fldName, pageSize, page, "dpt_id", 0, strCondition, "dpt_id", 0, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeNotIn(string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, byte Dist, out int pageCount, out int Counts)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeNotIn("dawn_auth_department", fldName, pageSize, page, fldSort, Sort, strCondition, "dpt_id", Dist, out pageCount, out Counts, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeNotIn(string tblName, string fldName, int pageSize, int page, string fldSort, byte Sort, string strCondition, string ID, byte Dist, out int pageCount, out int Counts, out int UsedTime, out string strSql)
        {
            List< DawnAuthDepartmentMDL> list = new List< DawnAuthDepartmentMDL>();
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_department", "*", pageSize, pageIndex, "dpt_id", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_department", "*", pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_department", fldName, pageSize, pageIndex, "dpt_id", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount)
        {
            int UsedTime = 0;
            string strSql = null;
            return SelectPSPisAllPurposeRowNumber("dawn_auth_department", fldName, pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_department", "*", pageSize, pageIndex, "dpt_id", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_department", "*", pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_department", fldName, pageSize, pageIndex, "dpt_id", strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            return SelectPSPisAllPurposeRowNumber("dawn_auth_department", fldName, pageSize, pageIndex, fldSort, strCondition, out pageCount, out RecordCount, out UsedTime, out strSql);
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
        /// <returns>DawnAuthDepartment 结果集</returns>
        public List< DawnAuthDepartmentMDL> SelectPSPisAllPurposeRowNumber(string tblName, string fldName, int pageSize, int pageIndex, string fldSort, string strCondition, out int pageCount, out int RecordCount, out int UsedTime, out string strSql)
        {
            List< DawnAuthDepartmentMDL> list = new List< DawnAuthDepartmentMDL>();
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
