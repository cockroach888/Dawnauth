// =================================================================== 
// 业务逻辑（DawnXZ.Dawnauth.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthModuleBLL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 20:43:51
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
    /// 业务逻辑层DawnAuthModule
    /// </summary>
    public partial class DawnAuthModuleBLL
    {

        #region ---------函数定义-----------

        #region GetFirstName

        /// <summary>
        /// 获取当前模块父标识名称
        /// </summary>
        /// <param name="mdlId">模块编号</param>
        /// <returns>执行结果</returns>
        public static string GetFirstName(int mdlId)
        {
            if (mdlId < 1) return null;
            return DawnAuthModuleBLL._dal.GetFirstName(mdlId);
        }

        #endregion
        
        #endregion

    }
}