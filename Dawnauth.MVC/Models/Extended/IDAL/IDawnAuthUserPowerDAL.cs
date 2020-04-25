// =================================================================== 
// 产品规则（DawnXZ.Dawnauth.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IDawnAuthUserPowerDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 20:53:08
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
    /// 数据层DawnAuthUserPower接口
    /// </summary>
    public partial interface IDawnAuthUserPowerDAL : PagerInterface<DawnAuthUserPowerMDL>
    {

        #region 基本方法

        #region 修改

        /// <summary>
        /// 向数据表DawnAuthUserPower修改一条记录
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="moduleId">模块编号</param>
        /// <param name="strFunction">功能权限集</param>
        /// <returns></returns>
        int UpdateFunction(int userId, int moduleId, string strFunction);
        
        #endregion

        #endregion

    }
}