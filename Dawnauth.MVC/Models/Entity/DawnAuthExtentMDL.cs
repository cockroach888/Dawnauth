// =================================================================== 
// 实体（DawnXZ.Dawnauth.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthExtentMDL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:32:55
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
	///权限扩展管理
	/// </summary>
	[Serializable]
	public class DawnAuthExtentMDL
	{
		
		#region 构造函数
		
		///<summary>
		/// 权限扩展管理
		///</summary>
		public DawnAuthExtentMDL()
		{ }
		
		#endregion
			
		#region 公共属性
		
		///<summary>
		/// 
		///</summary>
		public int ExteId{get;set;}
		///<summary>
		/// 
		///</summary>
		public DateTime ExteTime{get;set;}
		///<summary>
		/// 
		///</summary>
		public byte ExteStatus{get;set;}
		///<summary>
		/// 
		///</summary>
		public string ExteCode{get;set;}
		///<summary>
		/// 
		///</summary>
		public string ExteCodeName{get;set;}
		///<summary>
		/// 
		///</summary>
		public string ExteMark{get;set;}
		///<summary>
		/// 
		///</summary>
		public string ExteMarkName{get;set;}
		///<summary>
		/// 
		///</summary>
		public string ExteMemo{get;set;}
		///<summary>
		/// 
		///</summary>
		public int ExteFieldOne{get;set;}
		///<summary>
		/// 
		///</summary>
		public byte ExteFieldTwo{get;set;}
		///<summary>
		/// 
		///</summary>
		public string ExteFieldThree{get;set;}
	
		#endregion
		
	}
}
