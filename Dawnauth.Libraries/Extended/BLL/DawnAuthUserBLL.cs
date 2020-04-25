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

        #region ---------函数定义-----------

        #region 取得用户权限字符串

        /// <summary>
        /// 取得用户权限字符串
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>执行结果</returns>
        public static string GetUserAuthority(int userId)
        {
            if (userId < 1) return null;
            return DawnAuthUserBLL._dal.GetUserAuthority(userId);
        }

        #endregion

        #region 取得用户状态机制字符串

        /// <summary>
        /// 取得用户状态机制字符串
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>执行结果</returns>
        public static string GetUserStatus(int userId)
        {
            if (userId < 1) return null;
            return DawnAuthUserBLL._dal.GetUserStatus(userId);
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表DawnAuthUser修改密码
        /// </summary>
        /// <param name="userId">管理员编号</param>
        /// <param name="userPwd">管理员密码</param>
        /// <returns></returns>
        public static int Update(int userId, string userPwd)
        {
            if (userId < 1) return 0;
            return DawnAuthUserBLL._dal.Update(userId, userPwd);
        }

        #endregion

        #region 查询
        
        /// <summary>
        /// 根据用户名检测是否存在该条记录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>存在/不存在</returns>
        public static bool ExistsOfName(string userName)
        {
            return DawnAuthUserBLL._dal.ExistsOfName(userName);
        }

        #endregion

        #endregion ---------函数定义-----------

    }
}
