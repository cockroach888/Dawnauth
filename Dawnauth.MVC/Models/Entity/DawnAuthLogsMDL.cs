// =================================================================== 
// 实体（DawnXZ.Dawnauth.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthLogsMDL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年02月28日 23:06:48
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Collections.Generic;

namespace DawnXZ.Dawnauth.Entity
{
    /// <summary>
    ///日志信息管理
    /// </summary>
    [Serializable]
    public class DawnAuthLogsMDL
    {

        #region 构造函数

        ///<summary>
        /// 日志信息管理
        ///</summary>
        public DawnAuthLogsMDL()
        { }

        #endregion

        #region 公共属性

        ///<summary>
        /// 系统编号
        ///</summary>
        public Guid LogId { get; set; }
        ///<summary>
        /// 记录时间
        ///</summary>
        public DateTime LogTime { get; set; }
        ///<summary>
        /// 记录级别
        ///</summary>
        public byte LogRating { get; set; }
        ///<summary>
        /// 记录表名
        ///</summary>
        public string LogTable { get; set; }
        ///<summary>
        /// 记录动作
        ///</summary>
        public string LogAction { get; set; }
        ///<summary>
        /// 记录备注
        ///</summary>
        public string LogMemo { get; set; }
        ///<summary>
        /// 用户编号
        ///</summary>
        public int LogUid { get; set; }
        ///<summary>
        /// 用户名称
        ///</summary>
        public string LogUname { get; set; }

        #endregion

    }
}
