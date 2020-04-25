// =================================================================== 
// 业务逻辑（DawnXZ.Dawnauth.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthRoleBLL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 20:51:15
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
    /// 业务逻辑层DawnAuthRole
    /// </summary>
    public partial class DawnAuthRoleBLL
    {

        #region ---------函数定义-----------

        #region 修改

        /// <summary>
        /// 向数据表DawnAuthRole修改一条记录
        /// </summary>
        /// <param name="roleId">角色编码</param>
        /// <param name="authString">功能字符串</param>
        /// <returns></returns>
        public static int Update(string roleCode, string authString)
        {
            if (string.IsNullOrEmpty(roleCode)) return 0;
            return DawnAuthRoleBLL._dal.Update(roleCode, authString);
        }
        /// <summary>
        /// 向数据表DawnAuthRole修改一条记录
        /// </summary>
        /// <param name="dawnAuthRole">DawnAuthRole实体对象</param>
        /// <returns></returns>
        public static int UpdateEditor(DawnAuthRoleMDL dawnAuthRole)
        {
            if (dawnAuthRole == null) return 0;
            return DawnAuthRoleBLL._dal.UpdateEditor(dawnAuthRole);
        }

        #endregion

        #endregion

    }
}