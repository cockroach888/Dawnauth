// =================================================================== 
// 产品规则（DawnXZ.Dawnauth.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IDawnAuthUserDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:35:56
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
    /// 数据层DawnAuthUser接口
    /// </summary>
    public partial interface IDawnAuthUserDAL : PagerInterface<DawnAuthUserMDL>
    {

        #region 基本方法

        #region 取得用户权限字符串

        /// <summary>
        /// 取得用户权限字符串
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>执行结果</returns>
        string GetUserAuthority(int userId);

        #endregion

        #region 取得用户状态机制字符串

        /// <summary>
        /// 取得用户状态机制字符串
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>执行结果</returns>
        string GetUserStatus(int userId);

        #endregion
                
        #region 修改

        /// <summary>
        /// 向数据表DawnAuthUser修改密码
        /// </summary>
        /// <param name="userId">管理员编号</param>
        /// <param name="userPwd">管理员密码</param>
        /// <returns></returns>
        int Update(int userId, string userPwd);

        /// <summary>
        /// 向数据表DawnAuthUser修改一条记录
        /// </summary>
        /// <param name="dawnAuthUser">DawnAuthUser实体</param>
        /// <returns></returns>
        int UpdateEditor(DawnAuthUserMDL dawnAuthUser);

        #endregion
        
        #region 查询
        
        /// <summary>
        /// 根据用户名检测是否存在该条记录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>存在/不存在</returns>
        bool ExistsOfName(string userName);

        #endregion

        #endregion

    }
}
