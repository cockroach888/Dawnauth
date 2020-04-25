// =================================================================== 
// 实体（DawnXZ.Dawnauth.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthModuleMDL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年04月05日 11:48:37
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
	///模块信息管理表
	/// </summary>
	[Serializable]
	public class DawnAuthModuleMDL
	{
		
		#region 构造函数
		
		///<summary>
		/// 模块信息管理表
		///</summary>
		public DawnAuthModuleMDL()
		{ }
		
		#endregion
			
		#region 公共属性
		
		///<summary>
		/// 模块编号
		///</summary>
		public int MdlId{get;set;}
		///<summary>
		/// 模块名称
		///</summary>
		public string MdlName{get;set;}
		///<summary>
		/// 模块标识
		///</summary>
		public int MdlFather{get;set;}
		///<summary>
		/// 模块路径
		///</summary>
		public string MdlPath{get;set;}
		///<summary>
		/// 模块编码
		///</summary>
		public string MdlCode{get;set;}
		///<summary>
		/// 模块识别码
		///</summary>
		public int MdlIdent{get;set;}
		///<summary>
		/// 模块序列
		///</summary>
		public int MdlRank{get;set;}
		///<summary>
		/// 模块点击
		///</summary>
		public int MdlClick{get;set;}
		///<summary>
		/// 模块统计
		///</summary>
		public int MdlCounts{get;set;}
		///<summary>
		/// 模块描述
		///</summary>
		public string MdlDesc{get;set;}
		///<summary>
		/// 添加时间
		///</summary>
		public DateTime MdlTime{get;set;}
	
		#endregion
		
	}
}
