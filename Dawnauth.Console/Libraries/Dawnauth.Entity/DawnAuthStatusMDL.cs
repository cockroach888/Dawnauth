// =================================================================== 
// 实体（DawnXZ.Dawnauth.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthStatusMDL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年04月05日 23:39:03
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
	///状态机制管理表
	/// </summary>
	[Serializable]
	public class DawnAuthStatusMDL
	{
		
		#region 构造函数
		
		///<summary>
		/// 状态机制管理表
		///</summary>
		public DawnAuthStatusMDL()
		{ }
		
		#endregion
			
		#region 公共属性
		
		///<summary>
		/// 系统编号
		///</summary>
		public int StatId{get;set;}
		///<summary>
		/// 模块信息编号
		///</summary>
		public int MdlId{get;set;}
		///<summary>
		/// 添加时间
		///</summary>
		public DateTime StatTime{get;set;}
		///<summary>
		/// 状态名称
		///</summary>
		public string StatName{get;set;}
		///<summary>
		/// 状态编码
		///</summary>
		public string StatCode{get;set;}
		///<summary>
		/// 状态标识
		///</summary>
		public int StatMark{get;set;}
		///<summary>
		/// 状态描述
		///</summary>
		public string StatDesc{get;set;}
		///<summary>
		/// 备用字段一
		///</summary>
		public int StatFieldOne{get;set;}
		///<summary>
		/// 备用字段二
		///</summary>
		public byte StatFieldTwo{get;set;}
		///<summary>
		/// 备用字段三
		///</summary>
		public string StatFieldThree{get;set;}
	
		#endregion
		
	}
}
