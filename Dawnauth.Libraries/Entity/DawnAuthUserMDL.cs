// =================================================================== 
// 实体（DawnXZ.Dawnauth.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DawnAuthUserMDL.cs
// 项目名称：晨曦小竹权限云管理系统
// 创建时间：2013年11月22日 19:32:39
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
	///管理员信息管理
	/// </summary>
	[Serializable]
    public class DawnAuthUserMDL
	{
		
		#region 构造函数
		
		///<summary>
		/// 管理员信息管理
		///</summary>
		public DawnAuthUserMDL()
		{ }
		
		#endregion
			
		#region 公共属性
		
		///<summary>
		/// 系统编号
		///</summary>
		public int UserId{get;set;}
		///<summary>
		/// 部门编号
		///</summary>
		public int DptId{get;set;}
		///<summary>
		/// 添加时间
		///</summary>
		public DateTime UserTime{get;set;}
		///<summary>
		/// 账号状态
		///</summary>
		public byte UserStatus{get;set;}
		///<summary>
		/// 管理级别
		///</summary>
		public byte UserGrade{get;set;}
		///<summary>
		/// 用户姓名
		///</summary>
		public string UserSurname{get;set;}
		///<summary>
		/// 账号名称
		///</summary>
		public string UserName{get;set;}
		///<summary>
		/// 账号密码
		///</summary>
		public string UserPwd{get;set;}
		///<summary>
		/// 手机号码
		///</summary>
		public string UserMobile{get;set;}
		///<summary>
		/// 电子邮箱
		///</summary>
		public string UserEmail{get;set;}
		///<summary>
		/// 用户描述
		///</summary>
		public string UserDesc{get;set;}
		///<summary>
		/// 备用字段一
		///</summary>
		public int UserFieldOne{get;set;}
		///<summary>
		/// 备用字段二
		///</summary>
		public int UserFieldTwo{get;set;}
		///<summary>
		/// 备用字段三
		///</summary>
		public byte UserFieldThree{get;set;}
		///<summary>
		/// 备用字段四
		///</summary>
		public byte UserFieldFour{get;set;}
		///<summary>
		/// 备用字段五
		///</summary>
		public string UserFieldFive{get;set;}
		///<summary>
		/// 备用字段六
		///</summary>
		public string UserFieldSix{get;set;}
	
		#endregion
		
	}
}
