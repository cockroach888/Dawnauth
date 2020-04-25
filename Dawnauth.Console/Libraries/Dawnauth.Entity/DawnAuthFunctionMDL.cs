// =================================================================== 
// 实体（DawnXZ.Dawnauth.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthFunctionMDL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年04月05日 23:01:47
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
	///模块功能管理
	/// </summary>
	[Serializable]
	public class DawnAuthFunctionMDL
	{
		
		#region 构造函数
		
		///<summary>
		/// 模块功能管理
		///</summary>
		public DawnAuthFunctionMDL()
		{ }
		
		#endregion
			
		#region 公共属性
		
		///<summary>
		/// 系统编号
		///</summary>
		public int FunId{get;set;}
		///<summary>
		/// 模块信息编号
		///</summary>
		public int MdlId{get;set;}
		///<summary>
		/// 添加时间
		///</summary>
		public DateTime FunTime{get;set;}
		///<summary>
		/// 功能名称
		///</summary>
		public string FunName{get;set;}
		///<summary>
		/// 功能编码
		///</summary>
		public string FunCode{get;set;}
		///<summary>
		/// 功能识别码
		///</summary>
		public int FunIdent{get;set;}
		///<summary>
		/// 功能标识
		///</summary>
		public int FunMark{get;set;}
		///<summary>
		/// 内部标识
		///</summary>
		public int FunParentMark{get;set;}
		///<summary>
		/// 功能描述
		///</summary>
		public string FunDesc{get;set;}
	
		#endregion
		
	}
}
