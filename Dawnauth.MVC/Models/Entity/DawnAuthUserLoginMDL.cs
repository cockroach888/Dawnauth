// =================================================================== 
// 实体（DawnXZ.Dawnauth.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthUserLoginMDL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年02月28日 23:07:46
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
    ///登录日志管理
    /// </summary>
    [Serializable]
    public class DawnAuthUserLoginMDL
    {

        #region 构造函数

        ///<summary>
        /// 登录日志管理
        ///</summary>
        public DawnAuthUserLoginMDL()
        { }

        #endregion

        #region 公共属性

        ///<summary>
        /// 系统编号
        ///</summary>
        public int LogId { get; set; }
        ///<summary>
        /// 用户编号
        ///</summary>
        public int UserId { get; set; }
        ///<summary>
        /// 登录时间
        ///</summary>
        public DateTime LogTime { get; set; }
        ///<summary>
        /// IP地址
        ///</summary>
        public string LogIp { get; set; }
        ///<summary>
        /// MAC地址
        ///</summary>
        public string LogMac { get; set; }
        ///<summary>
        /// 计算机名称
        ///</summary>
        public string LogComputer { get; set; }
        ///<summary>
        /// 附加信息
        ///</summary>
        public string LogAttach { get; set; }
        ///<summary>
        /// 登录次数
        ///</summary>
        public int LogCount { get; set; }
        ///<summary>
        /// 备用字段一
        ///</summary>
        public int LogFieldOne { get; set; }
        ///<summary>
        /// 备用字段二
        ///</summary>
        public byte LogFieldTwo { get; set; }
        ///<summary>
        /// 备用字段三
        ///</summary>
        public string LogFieldThree { get; set; }

        #endregion

    }
}
