// =================================================================== 
// 实体（DawnXZ.Dawnauth.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthUserPowerMDL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年04月05日 23:31:06
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
	///权限映射管理表
	/// </summary>
	[Serializable]
	public class DawnAuthUserPowerMDL
	{
		
		#region 构造函数
		
		///<summary>
		/// 权限映射管理表
		///</summary>
		public DawnAuthUserPowerMDL()
		{ }
		
		#endregion
			
		#region 公共属性
		
		///<summary>
		/// 系统编号
		///</summary>
		public int MapId{get;set;}
		///<summary>
		/// 用户编号
		///</summary>
		public int UserId{get;set;}
		///<summary>
		/// 添加时间
		///</summary>
		public DateTime MapTime{get;set;}
		///<summary>
		/// 模块识别码
		///</summary>
		public int MapModule{get;set;}
		///<summary>
		/// 功能识别码
		///</summary>
		public string MapFunction{get;set;}
	
		#endregion
		
	}
}
