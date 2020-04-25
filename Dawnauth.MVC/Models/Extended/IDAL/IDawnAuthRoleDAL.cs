// =================================================================== 
// 产品规则（DawnXZ.Dawnauth.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IDawnAuthRoleDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 20:47:36
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
    /// 数据层DawnAuthRole接口
    /// </summary>
    public partial interface IDawnAuthRoleDAL : PagerInterface<DawnAuthRoleMDL>
    {

        #region 基本方法

        #region 修改

        /// <summary>
        /// 向数据表DawnAuthRole修改一条记录
        /// </summary>
        /// <param name="roleId">角色编码</param>
        /// <param name="authString">功能字符串</param>
        /// <returns></returns>
        int Update(string roleCode, string authString);

        /// <summary>
        /// 向数据表DawnAuthRole修改一条记录
        /// </summary>
        /// <param name="dawnAuthRole">DawnAuthRole实体</param>
        /// <returns></returns>
        int UpdateEditor(DawnAuthRoleMDL dawnAuthRole);

        #endregion

        #endregion

    }
}