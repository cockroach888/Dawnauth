// =================================================================== 
// 实体（DawnXZ.Dawnauth.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthDepartmentMDL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:32:59
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
	///单位部门管理
	/// </summary>
	[Serializable]
    public class DawnAuthDepartmentMDL
	{
		
		#region 构造函数
		
		///<summary>
		/// 单位部门管理
		///</summary>
		public DawnAuthDepartmentMDL()
		{ }
		
		#endregion
			
		#region 公共属性
		
		///<summary>
		/// 系统编号
		///</summary>
		public int DptId{get;set;}
		///<summary>
		/// 部门名称
		///</summary>
		public string DptName{get;set;}
		///<summary>
		/// 部门标识
		///</summary>
		public int DptFather{get;set;}
		///<summary>
		/// 部门路径
		///</summary>
		public string DptPath{get;set;}
		///<summary>
		/// 部门编码
		///</summary>
		public string DptCode{get;set;}
		///<summary>
		/// 部门识别码
		///</summary>
		public int DptIdent{get;set;}
		///<summary>
		/// 部门序列
		///</summary>
		public int DptRank{get;set;}
		///<summary>
		/// 部门点击
		///</summary>
		public int DptClick{get;set;}
		///<summary>
		/// 部门统计
		///</summary>
		public int DptCounts{get;set;}
		///<summary>
		/// 部门描述
		///</summary>
		public string DptDesc{get;set;}
		///<summary>
		/// 添加时间
		///</summary>
		public DateTime DptTime{get;set;}
	
		#endregion
		
	}
}
