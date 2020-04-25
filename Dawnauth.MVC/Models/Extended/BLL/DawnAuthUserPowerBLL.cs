// =================================================================== 
// 业务逻辑（DawnXZ.Dawnauth.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthUserPowerBLL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 20:55:29
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
    /// 业务逻辑层DawnAuthUserPower
    /// </summary>
    public partial class DawnAuthUserPowerBLL
    {

        #region ---------函数定义-----------

        #region 修改

        /// <summary>
        /// 向数据表DawnAuthUserPower修改一条记录
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="moduleId">模块编号</param>
        /// <param name="strFunction">功能权限集</param>
        /// <returns></returns>
        public static int UpdateFunction(int userId, int moduleId, string strFunction)
        {
            if (userId < 1 || moduleId < 1 || string.IsNullOrEmpty(strFunction)) return 0;
            return DawnAuthUserPowerBLL._dal.UpdateFunction(userId, moduleId, strFunction);
        }

        #endregion

        #endregion

    }
}