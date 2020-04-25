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
    internal class DALFactory
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
    	/// 通过反射机制，实例化DawnAuthUserPower接口对象
    	/// </summary>
		///<returns>DawnAuthUserPower接口对象</returns>
		public static IDawnAuthUserPowerDAL DawnAuthUserPowerDALInstance()
		{
            string CacheKey = string.Format("{0}{1}", DALFactory._path, ".DawnAuthUserPowerDAL");
			object objType = DALFactory.GetInstance(CacheKey);
			return (IDawnAuthUserPowerDAL)objType;
		}
    }
}
