// ===================================================================
// 工厂（DawnXZ.Dawnauth.DBFactory）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DALFactory.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年02月28日 23:09:18
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
        private static readonly string _assembly = "DawnBuilder";
        private static readonly string _path = "Dawnauth.SqlServerDAL";

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
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return objType;
        }

        /// <summary>
        /// 通过反射机制，实例化DawnAuthFunction接口对象
        /// </summary>
        ///<returns>DawnAuthFunction接口对象</returns>
        public static IDawnAuthFunctionDAL DawnAuthFunctionDALInstance()
        {
            string CacheKey = string.Format("DawnXZ.{0}{1}", DALFactory._path, ".DawnAuthFunctionDAL");
            object objType = DALFactory.GetInstance(CacheKey);
            return (IDawnAuthFunctionDAL)objType;
        }

        /// <summary>
        /// 通过反射机制，实例化DawnAuthModule接口对象
        /// </summary>
        ///<returns>DawnAuthModule接口对象</returns>
        public static IDawnAuthModuleDAL DawnAuthModuleDALInstance()
        {
            string CacheKey = string.Format("DawnXZ.{0}{1}", DALFactory._path, ".DawnAuthModuleDAL");
            object objType = DALFactory.GetInstance(CacheKey);
            return (IDawnAuthModuleDAL)objType;
        }

        /// <summary>
        /// 通过反射机制，实例化DawnAuthStatus接口对象
        /// </summary>
        ///<returns>DawnAuthStatus接口对象</returns>
        public static IDawnAuthStatusDAL DawnAuthStatusDALInstance()
        {
            string CacheKey = string.Format("DawnXZ.{0}{1}", DALFactory._path, ".DawnAuthStatusDAL");
            object objType = DALFactory.GetInstance(CacheKey);
            return (IDawnAuthStatusDAL)objType;
        }
    }
}
