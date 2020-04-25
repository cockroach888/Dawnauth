USE [DawnAuthority]
GO

/******************************【管理员信息管理】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2013年11月22日 18:52:43】----
----------------------------------------------------------------------------------------------

/********************数据表【DawnAuthUser】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@UserId  系统编号
@DptId  部门编号 
@UserTime  添加时间 
@UserStatus  账号状态 
@UserGrade  管理级别 
@UserSurname  用户姓名 
@UserName  账号名称 
@UserPwd  账号密码 
@UserMobile  手机号码 
@UserEmail  电子邮箱 
@UserDesc  用户描述 
@UserFieldOne  备用字段一 
@UserFieldTwo  备用字段二 
@UserFieldThree  备用字段三 
@UserFieldFour  备用字段四 
@UserFieldFive  备用字段五 
@UserFieldSix  备用字段六 
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserInsert]
	@UserId int output,
	@DptId int,
	@UserTime datetime,
	@UserStatus tinyint,
	@UserGrade tinyint,
	@UserSurname nvarchar(20),
	@UserName varchar(16),
	@UserPwd varchar(32),
	@UserMobile varchar(15),
	@UserEmail varchar(50),
	@UserDesc nvarchar(300),
	@UserFieldOne int,
	@UserFieldTwo int,
	@UserFieldThree tinyint,
	@UserFieldFour tinyint,
	@UserFieldFive varchar(500),
	@UserFieldSix varchar(500)
AS
	SET NOCOUNT ON
	insert into dawn_auth_user
	(
		[dpt_id],
		[user_time],
		[user_status],
		[user_grade],
		[user_surname],
		[user_name],
		[user_pwd],
		[user_mobile],
		[user_email],
		[user_desc],
		[user_field_one],
		[user_field_two],
		[user_field_three],
		[user_field_four],
		[user_field_five],
		[user_field_six]
	) 
	values
	(
		@DptId,
		@UserTime,
		@UserStatus,
		@UserGrade,
		@UserSurname,
		@UserName,
		@UserPwd,
		@UserMobile,
		@UserEmail,
		@UserDesc,
		@UserFieldOne,
		@UserFieldTwo,
		@UserFieldThree,
		@UserFieldFour,
		@UserFieldFive,
		@UserFieldSix
	)
	set @UserId=scope_identity()
	return @@error
GO

/********************数据表【DawnAuthUser】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@UserId  系统编号
@DptId  部门编号 
@UserTime  添加时间 
@UserStatus  账号状态 
@UserGrade  管理级别 
@UserSurname  用户姓名 
@UserName  账号名称 
@UserPwd  账号密码 
@UserMobile  手机号码 
@UserEmail  电子邮箱 
@UserDesc  用户描述 
@UserFieldOne  备用字段一 
@UserFieldTwo  备用字段二 
@UserFieldThree  备用字段三 
@UserFieldFour  备用字段四 
@UserFieldFive  备用字段五 
@UserFieldSix  备用字段六 
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserUpdate]
	@UserId int,
	@DptId int,
	@UserTime datetime,
	@UserStatus tinyint,
	@UserGrade tinyint,
	@UserSurname nvarchar(20),
	@UserName varchar(16),
	@UserPwd varchar(32),
	@UserMobile varchar(15),
	@UserEmail varchar(50),
	@UserDesc nvarchar(300),
	@UserFieldOne int,
	@UserFieldTwo int,
	@UserFieldThree tinyint,
	@UserFieldFour tinyint,
	@UserFieldFive varchar(500),
	@UserFieldSix varchar(500)
AS
 SET NOCOUNT ON
 UPDATE [dawn_auth_user] SET
		[dpt_id] = @DptId,
		[user_time] = @UserTime,
		[user_status] = @UserStatus,
		[user_grade] = @UserGrade,
		[user_surname] = @UserSurname,
		[user_name] = @UserName,
		[user_pwd] = @UserPwd,
		[user_mobile] = @UserMobile,
		[user_email] = @UserEmail,
		[user_desc] = @UserDesc,
		[user_field_one] = @UserFieldOne,
		[user_field_two] = @UserFieldTwo,
		[user_field_three] = @UserFieldThree,
		[user_field_four] = @UserFieldFour,
		[user_field_five] = @UserFieldFive,
		[user_field_six] = @UserFieldSix
 WHERE
		[user_id] = @UserId
    return @@error
GO

/********************数据表【DawnAuthUser】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@UserId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserDelete]
	@UserId int
AS
	SET NOCOUNT ON
	delete from [dawn_auth_user] where  [user_id] = @UserId
	return @@error
GO

/********************数据表【DawnAuthUser】条件删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserDeleteWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserDeleteWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 删除条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserDeleteWhere]
	@where varchar(8000) = ' 1<>1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'delete from [dbo].[dawn_auth_user] where '
    exec ( @filter + @where )
	return @@error
GO

/********************查询数据表【DawnAuthUser】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserSelectAll]
    @sortField varchar(100) = ' [user_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_user] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【DawnAuthUser】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@UserId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserSelect]
    @UserId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[dawn_auth_user]
		where [user_id] = @UserId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthUser】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserSelectByParams]
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [user_id] DESC '
AS
	SET NOCOUNT ON
    if @where is null or @where=''    ----没有设置查询条件
	begin
		SET @where = ' 1=1 '
	end
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_user]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthUser】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserCountByWhere]
    @where varchar(8000) = ' 1=1 ',
    @recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[dawn_auth_user] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【DawnAuthUser】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex 当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserSelectByPagerParams]
    @pageSize int = 10,
    @pageIndex int = 1,
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [user_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[dawn_auth_user]
		where [user_id] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [user_id] FROM [dbo].[dawn_auth_user]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【DawnAuthUser】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@UserId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserIsExist]
    @UserId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_user]
		where [user_id] = @UserId
	RETURN @@Error
GO

/********************通过指定条件查询数据表【DawnAuthUser】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserIsExistByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserIsExistByWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserIsExistByWhere]
    @where varchar(8000) = ' 1=1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'SELECT count(-1) FROM [dbo].[dawn_auth_user]	where '
    exec ( @filter + @where )
    RETURN @@Error
GO



