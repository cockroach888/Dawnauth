// =================================================================== 
// 实体（DawnXZ.Dawnauth.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthUserExtentMDL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:32:45
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
	///扩展映射管理表
	/// </summary>
	[Serializable]
	public class DawnAuthUserExtentMDL
	{
		
		#region 构造函数
		
		///<summary>
		/// 扩展映射管理表
		///</summary>
		public DawnAuthUserExtentMDL()
		{ }
		
		#endregion
			
		#region 公共属性
		
		///<summary>
		/// 系统编号
		///</summary>
		public int ExtId{get;set;}
		///<summary>
		/// 用户编号
		///</summary>
		public int UserId{get;set;}
		///<summary>
		/// 添加时间
		///</summary>
		public DateTime ExtTime{get;set;}
		///<summary>
		/// 扩展编码
		///</summary>
		public string ExtCode{get;set;}
		///<summary>
		/// 扩展标识
		///</summary>
		public string ExtMark{get;set;}
	
		#endregion
		
	}
}
