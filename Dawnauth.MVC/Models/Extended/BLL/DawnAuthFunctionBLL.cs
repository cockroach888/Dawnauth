// =================================================================== 
// 业务逻辑（DawnXZ.Dawnauth.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthFunctionBLL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 20:37:30
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
    /// 业务逻辑层DawnAuthFunction
    /// </summary>
    public partial class DawnAuthFunctionBLL
    {

        #region ---------函数定义-----------

        #region GetMaxId

        /// <summary>
        /// 获取当前最大功能标识编号
        /// </summary>
        /// <param name="mdlId">模块编号</param>
        /// <returns>功能标识编号</returns>
        public static int GetMaxFunMark(int mdlId)
        {
            if (mdlId <= 0) return 0;
            return DawnAuthFunctionBLL._dal.GetMaxFunMark(mdlId);
        }

        #endregion

        #region GetParentMark

        /// <summary>
        /// 获取当前模块内部功能标识
        /// </summary>
        /// <param name="mdlId">模块编号</param>
        /// <returns>内部功能标识</returns>
        public static int GetParentMark(int mdlId)
        {
            if (mdlId <= 0) return 0;
            return DawnAuthFunctionBLL._dal.GetParentMark(mdlId);
        }

        #endregion

        #endregion ---------函数定义-----------

    }
}
