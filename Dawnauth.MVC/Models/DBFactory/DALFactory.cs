// ===================================================================
// 工厂（DawnXZ.Dawnauth.DBFactory）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DALFactory.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:30:05
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Reflection;
using DawnXZ.Dawnauth.IDAL;

namespace DawnXZ.Dawnauth.DBFactory
{
    /// <summary>
    /// 数据层工厂
    /// </summary>
    public class DALFactory
    {
		/// <summary>
    	/// 通过反射机制，实例化接口对象
    	/// </summary>
        private static readonly string _assembly = "DawnAuthority";
        private static readonly string _path = "DawnXZ.Dawnauth.SqlServerDAL";
		
		/// <summary>
    	/// 通过反射机制，实例化接口对象
    	/// </summary>
		/// <param name="CacheKey">接口对象名称(键)</param>
		///<returns>接口对象</returns>
		private static object GetInstance(string CacheKey)
		{			
			object objType = DataCache.GetCache(CacheKey);
			if (objType == null)
			{
				try
				{
					objType = Assembly.Load(DALFactory._assembly).CreateInstance(CacheKey);					
					DataCache.SetCache(CacheKey, objType);
				}
				catch(Exception ex)
				{
					throw ex;
				}
			}
			return objType;
		}
		
		/// <summary>
    	/// 通过反射机制，实例化DawnAuthDepartment接口对象
    	/// </summary>
		///<returns>DawnAuthDepartment接口对象</returns>
		public static IDawnAuthDepartmentDAL DawnAuthDepartmentDALInstance()
		{
            string CacheKey = string.Format("{0}{1}", DALFactory._path, ".DawnAuthDepartmentDAL");
			object objType = DALFactory.GetInstance(CacheKey);
			return (IDawnAuthDepartmentDAL)objType;
		}

		/// <summary>
    	/// 通过反射机制，实例化DawnAuthError接口对象
    	/// </summary>
		///<returns>DawnAuthError接口对象</returns>
		public static IDawnAuthErrorDAL DawnAuthErrorDALInstance()
		{
            string CacheKey = string.Format("{0}{1}", DALFactory._path, ".DawnAuthErrorDAL");
			object objType = DALFactory.GetInstance(CacheKey);
			return (IDawnAuthErrorDAL)objType;
		}

		/// <summary>
    	/// 通过反射机制，实例化DawnAuthExtent接口对象
    	/// </summary>
		///<returns>DawnAuthExtent接口对象</returns>
		public static IDawnAuthExtentDAL DawnAuthExtentDALInstance()
		{
            string CacheKey = string.Format("{0}{1}", DALFactory._path, ".DawnAuthExtentDAL");
			object objType = DALFactory.GetInstance(CacheKey);
			return (IDawnAuthExtentDAL)objType;
		}

		/// <summary>
    	/// 通过反射机制，实例化DawnAuthFunction接口对象
    	/// </summary>
		///<returns>DawnAuthFunction接口对象</returns>
		public static IDawnAuthFunctionDAL DawnAuthFunctionDALInstance()
		{
            string CacheKey = string.Format("{0}{1}", DALFactory._path, ".DawnAuthFunctionDAL");
			object objType = DALFactory.GetInstance(CacheKey);
			return (IDawnAuthFunctionDAL)objType;
		}

		/// <summary>
    	/// 通过反射机制，实例化DawnAuthLogs接口对象
    	/// </summary>
		///<returns>DawnAuthLogs接口对象</returns>
		public static IDawnAuthLogsDAL DawnAuthLogsDALInstance()
		{
            string CacheKey = string.Format("{0}{1}", DALFactory._path, ".DawnAuthLogsDAL");
			object objType = DALFactory.GetInstance(CacheKey);
			return (IDawnAuthLogsDAL)objType;
		}

		/// <summary>
    	/// 通过反射机制，实例化DawnAuthModule接口对象
    	/// </summary>
		///<returns>DawnAuthModule接口对象</returns>
		public static IDawnAuthModuleDAL DawnAuthModuleDALInstance()
		{
            string CacheKey = string.Format("{0}{1}", DALFactory._path, ".DawnAuthModuleDAL");
			object objType = DALFactory.GetInstance(CacheKey);
			return (IDawnAuthModuleDAL)objType;
		}

		/// <summary>
    	/// 通过反射机制，实例化DawnAuthRole接口对象
    	/// </summary>
		///<returns>DawnAuthRole接口对象</returns>
		public static IDawnAuthRoleDAL DawnAuthRoleDALInstance()
		{
            string CacheKey = string.Format("{0}{1}", DALFactory._path, ".DawnAuthRoleDAL");
			object objType = DALFactory.GetInstance(CacheKey);
			return (IDawnAuthRoleDAL)objType;
		}

		/// <summary>
    	/// 通过反射机制，实例化DawnAuthStatus接口对象
    	/// </summary>
		///<returns>DawnAuthStatus接口对象</returns>
		public static IDawnAuthStatusDAL DawnAuthStatusDALInstance()
		{
            string CacheKey = string.Format("{0}{1}", DALFactory._path, ".DawnAuthStatusDAL");
			object objType = DALFactory.GetInstance(CacheKey);
			return (IDawnAuthStatusDAL)objType;
		}

		/// <summary>
    	/// 通过反射机制，实例化DawnAuthUser接口对象
    	/// </summary>
		///<returns>DawnAuthUser接口对象</returns>
		public static IDawnAuthUserDAL DawnAuthUserDALInstance()
		{
            string CacheKey = string.Format("{0}{1}", DALFactory._path, ".DawnAuthUserDAL");
			object objType = DALFactory.GetInstance(CacheKey);
			return (IDawnAuthUserDAL)objType;
		}

		/// <summary>
    	/// 通过反射机制，实例化DawnAuthUserExtent接口对象
    	/// </summary>
		///<returns>DawnAuthUserExtent接口对象</returns>
		public static IDawnAuthUserExtentDAL DawnAuthUserExtentDALInstance()
		{
            string CacheKey = string.Format("{0}{1}", DALFactory._path, ".DawnAuthUserExtentDAL");
			object objType = DALFactory.GetInstance(CacheKey);
			return (IDawnAuthUserExtentDAL)objType;
		}

		/// <summary>
    	/// 通过反射机制，实例化DawnAuthUserLogin接口对象
    	/// </summary>
		///<returns>DawnAuthUserLogin接口对象</returns>
		public static IDawnAuthUserLoginDAL DawnAuthUserLoginDALInstance()
		{
            string CacheKey = string.Format("{0}{1}", DALFactory._path, ".DawnAuthUserLoginDAL");
			object objType = DALFactory.GetInstance(CacheKey);
			return (IDawnAuthUserLoginDAL)objType;
		}

		/// <summary>
    	/// 通过反射机制，实例化DawnAuthUserPic接口对象
    	/// </summary>
		///<returns>DawnAuthUserPic接口对象</returns>
		public static IDawnAuthUserPicDAL DawnAuthUserPicDALInstance()
		{
            string CacheKey = string.Format("{0}{1}", DALFactory._path, ".DawnAuthUserPicDAL");
			object objType = DALFactory.GetInstance(CacheKey);
			return (IDawnAuthUserPicDAL)objType;
		}

		/// <summary>
    	/// 通过反射机制，实例化DawnAuthUserPower接口对象
    	/// </summary>
		///<returns>DawnAuthUserPower接口对象</returns>
		public static IDawnAuthUserPowerDAL DawnAuthUserPowerDALInstance()
		{
            string CacheKey = string.Format("{0}{1}", DALFactory._path, ".DawnAuthUserPowerDAL");
			object objType = DALFactory.GetInstance(CacheKey);
			return (IDawnAuthUserPowerDAL)objType;
		}

		/// <summary>
    	/// 通过反射机制，实例化DawnAuthUserRole接口对象
    	/// </summary>
		///<returns>DawnAuthUserRole接口对象</returns>
		public static IDawnAuthUserRoleDAL DawnAuthUserRoleDALInstance()
		{
            string CacheKey = string.Format("{0}{1}", DALFactory._path, ".DawnAuthUserRoleDAL");
			object objType = DALFactory.GetInstance(CacheKey);
			return (IDawnAuthUserRoleDAL)objType;
		}

		/// <summary>
    	/// 通过反射机制，实例化DawnAuthUserStatus接口对象
    	/// </summary>
		///<returns>DawnAuthUserStatus接口对象</returns>
		public static IDawnAuthUserStatusDAL DawnAuthUserStatusDALInstance()
		{
            string CacheKey = string.Format("{0}{1}", DALFactory._path, ".DawnAuthUserStatusDAL");
			object objType = DALFactory.GetInstance(CacheKey);
			return (IDawnAuthUserStatusDAL)objType;
		}
    }
}
