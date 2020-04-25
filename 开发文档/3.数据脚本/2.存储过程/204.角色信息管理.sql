USE [DawnAuthority]
GO

/******************************【角色信息管理】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2013年02月11日 11:25:35】----
----------------------------------------------------------------------------------------------

/********************数据表【DawnAuthRole】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthRoleInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthRoleInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@RoleId  系统编号
@RoleTime  添加时间 
@RoleName  角色名称 
@RoleCode  角色编码 
@RoleAuthority  角色权限 
@RoleDesc  角色描述 
@RoleFieldOne  备用字段一 
@RoleFieldTwo  备用字段二 
@RoleFieldThree  备用字段三 
*/	
CREATE PROCEDURE [dbo].[DawnAuthRoleInsert]
	@RoleId int output,
	@RoleTime datetime,
	@RoleName nvarchar(50),
	@RoleCode varchar(50),
	@RoleAuthority varchar(max),
	@RoleDesc nvarchar(300),
	@RoleFieldOne int,
	@RoleFieldTwo tinyint,
	@RoleFieldThree varchar(50)
AS
	SET NOCOUNT ON
	insert into dawn_auth_role
	(
		[role_time],
		[role_name],
		[role_code],
		[role_authority],
		[role_desc],
		[role_field_one],
		[role_field_two],
		[role_field_three]
	) 
	values
	(
		@RoleTime,
		@RoleName,
		@RoleCode,
		@RoleAuthority,
		@RoleDesc,
		@RoleFieldOne,
		@RoleFieldTwo,
		@RoleFieldThree
	)
	set @RoleId=scope_identity()
	return @@error
GO

/********************数据表【DawnAuthRole】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthRoleUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthRoleUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@RoleId  系统编号
@RoleTime  添加时间 
@RoleName  角色名称 
@RoleCode  角色编码 
@RoleAuthority  角色权限 
@RoleDesc  角色描述 
@RoleFieldOne  备用字段一 
@RoleFieldTwo  备用字段二 
@RoleFieldThree  备用字段三 
*/	
CREATE PROCEDURE [dbo].[DawnAuthRoleUpdate]
	@RoleId int,
	@RoleTime datetime,
	@RoleName nvarchar(50),
	@RoleCode varchar(50),
	@RoleAuthority varchar(max),
	@RoleDesc nvarchar(300),
	@RoleFieldOne int,
	@RoleFieldTwo tinyint,
	@RoleFieldThree varchar(50)
AS
 SET NOCOUNT ON
 UPDATE [dawn_auth_role] SET
		[role_time] = @RoleTime,
		[role_name] = @RoleName,
		[role_code] = @RoleCode,
		[role_authority] = @RoleAuthority,
		[role_desc] = @RoleDesc,
		[role_field_one] = @RoleFieldOne,
		[role_field_two] = @RoleFieldTwo,
		[role_field_three] = @RoleFieldThree
 WHERE
		[role_id] = @RoleId
    return @@error
GO

/********************数据表【DawnAuthRole】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthRoleDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthRoleDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@RoleId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthRoleDelete]
	@RoleId int
AS
	SET NOCOUNT ON
	delete from [dawn_auth_role] where  [role_id] = @RoleId
	return @@error
GO

/********************数据表【DawnAuthRole】条件删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthRoleDeleteWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthRoleDeleteWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 删除条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthRoleDeleteWhere]
	@where varchar(8000) = ' 1<>1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'delete from [dbo].[dawn_auth_role] where '
    exec ( @filter + @where )
	return @@error
GO

/********************查询数据表【DawnAuthRole】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthRoleSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthRoleSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthRoleSelectAll]
    @sortField varchar(100) = ' [role_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_role] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【DawnAuthRole】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthRoleSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthRoleSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@RoleId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthRoleSelect]
    @RoleId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[dawn_auth_role]
		where [role_id] = @RoleId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthRole】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthRoleSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthRoleSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthRoleSelectByParams]
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [role_id] DESC '
AS
	SET NOCOUNT ON
    if @where is null or @where=''    ----没有设置查询条件
	begin
		SET @where = ' 1=1 '
	end
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_role]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthRole】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthRoleCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthRoleCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[DawnAuthRoleCountByWhere]
    @where varchar(8000) = ' 1=1 ',
    @recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[dawn_auth_role] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【DawnAuthRole】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthRoleSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthRoleSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ǰ当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthRoleSelectByPagerParams]
    @pageSize int = 10,
    @pageIndex int = 1,
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [role_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[dawn_auth_role]
		where [role_id] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [role_id] FROM [dbo].[dawn_auth_role]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【DawnAuthRole】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthRoleIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthRoleIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@RoleId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthRoleIsExist]
    @RoleId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_role]
		where [role_id] = @RoleId
	RETURN @@Error
GO

/********************通过指定条件查询数据表【DawnAuthRole】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthRoleIsExistByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthRoleIsExistByWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthRoleIsExistByWhere]
    @where varchar(8000) = ' 1=1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'SELECT count(-1) FROM [dbo].[dawn_auth_role]	where '
    exec ( @filter + @where )
    RETURN @@Error
GO



