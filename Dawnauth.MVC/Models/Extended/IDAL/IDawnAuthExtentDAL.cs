// =================================================================== 
// 产品规则（DawnXZ.Dawnauth.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IDawnAuthExtentDAL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:35:51
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
    /// 数据层DawnAuthExtent接口
    /// </summary>
    public partial interface IDawnAuthExtentDAL : PagerInterface<DawnAuthExtentMDL>
    {

        #region 基本方法

        #region 获取扩展编码

        /// <summary>
        /// 获取扩展编码数组
        /// </summary>
        /// <returns>扩展编码数组</returns>
        DataTable SelectByCodeList();

        #endregion

        #endregion

    }
}