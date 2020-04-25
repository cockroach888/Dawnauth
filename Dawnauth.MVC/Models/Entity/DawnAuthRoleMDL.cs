// =================================================================== 
// 实体（DawnXZ.Dawnauth.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthRoleMDL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年02月28日 23:07:13
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
    ///角色信息管理
    /// </summary>
    [Serializable]
    public class DawnAuthRoleMDL
    {

        #region 构造函数

        ///<summary>
        /// 角色信息管理
        ///</summary>
        public DawnAuthRoleMDL()
        { }

        #endregion

        #region 公共属性

        ///<summary>
        /// 系统编号
        ///</summary>
        public int RoleId { get; set; }
        ///<summary>
        /// 添加时间
        ///</summary>
        public DateTime RoleTime { get; set; }
        ///<summary>
        /// 角色名称
        ///</summary>
        public string RoleName { get; set; }
        ///<summary>
        /// 角色编码
        ///</summary>
        public string RoleCode { get; set; }
        ///<summary>
        /// 角色权限
        ///</summary>
        public string RoleAuthority { get; set; }
        ///<summary>
        /// 角色描述
        ///</summary>
        public string RoleDesc { get; set; }
        ///<summary>
        /// 备用字段一
        ///</summary>
        public int RoleFieldOne { get; set; }
        ///<summary>
        /// 备用字段二
        ///</summary>
        public byte RoleFieldTwo { get; set; }
        ///<summary>
        /// 备用字段三
        ///</summary>
        public string RoleFieldThree { get; set; }

        #endregion

    }
}
