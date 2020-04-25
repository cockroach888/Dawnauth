// =================================================================== 
// 实体（DawnXZ.Dawnauth.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthErrorMDL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年02月28日 23:06:19
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
    ///错误信息管理表
    /// </summary>
    [Serializable]
    public class DawnAuthErrorMDL
    {

        #region 构造函数

        ///<summary>
        /// 错误信息管理表
        ///</summary>
        public DawnAuthErrorMDL()
        { }

        #endregion

        #region 公共属性

        ///<summary>
        /// 系统编号
        ///</summary>
        public Guid ErrId { get; set; }
        ///<summary>
        /// 记录时间
        ///</summary>
        public DateTime ErrTime { get; set; }
        ///<summary>
        /// 错误地址
        ///</summary>
        public string ErrAddress { get; set; }
        ///<summary>
        /// 错误消息
        ///</summary>
        public string ErrMessage { get; set; }
        ///<summary>
        /// 错误目标
        ///</summary>
        public string ErrTarget { get; set; }
        ///<summary>
        /// 错误跟踪
        ///</summary>
        public string ErrTrace { get; set; }
        ///<summary>
        /// 错误来源
        ///</summary>
        public string ErrSource { get; set; }
        ///<summary>
        /// 用户IP码
        ///</summary>
        public string ErrIp { get; set; }
        ///<summary>
        /// 用户编号
        ///</summary>
        public int ErrUid { get; set; }
        ///<summary>
        /// 用户名称
        ///</summary>
        public string ErrUname { get; set; }

        #endregion

    }
}
