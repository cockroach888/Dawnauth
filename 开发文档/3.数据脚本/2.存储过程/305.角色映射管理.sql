USE [DawnAuthority]
GO

/******************************【角色映射管理】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2013年02月28日 13:20:14】----
----------------------------------------------------------------------------------------------

/********************数据表【DawnAuthUserRole】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserRoleInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserRoleInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MapId  系统编号
@UserId  用户编号 
@RoleId  角色编号 
@MapTime  添加时间 
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserRoleInsert]
	@MapId int output,
	@UserId int,
	@RoleId int,
	@MapTime datetime
AS
	SET NOCOUNT ON
	insert into dawn_auth_user_role
	(
		[user_id],
		[role_id],
		[map_time]
	) 
	values
	(
		@UserId,
		@RoleId,
		@MapTime
	)
	set @MapId=scope_identity()
	return @@error
GO

/********************数据表【DawnAuthUserRole】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserRoleUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserRoleUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MapId  系统编号
@UserId  用户编号 
@RoleId  角色编号 
@MapTime  添加时间 
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserRoleUpdate]
	@MapId int,
	@UserId int,
	@RoleId int,
	@MapTime datetime
AS
 SET NOCOUNT ON
 UPDATE [dawn_auth_user_role] SET
		[user_id] = @UserId,
		[role_id] = @RoleId,
		[map_time] = @MapTime
 WHERE
		[map_id] = @MapId
    return @@error
GO

/********************数据表【DawnAuthUserRole】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserRoleDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserRoleDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MapId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserRoleDelete]
	@MapId int
AS
	SET NOCOUNT ON
	delete from [dawn_auth_user_role] where  [map_id] = @MapId
	return @@error
GO

/********************数据表【DawnAuthUserRole】条件删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserRoleDeleteWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserRoleDeleteWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 删除条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserRoleDeleteWhere]
	@where varchar(8000) = ' 1<>1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'delete from [dbo].[dawn_auth_user_role] where '
    exec ( @filter + @where )
	return @@error
GO

/********************查询数据表【DawnAuthUserRole】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserRoleSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserRoleSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserRoleSelectAll]
    @sortField varchar(100) = ' [map_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_user_role] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【DawnAuthUserRole】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserRoleSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserRoleSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MapId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserRoleSelect]
    @MapId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[dawn_auth_user_role]
		where [map_id] = @MapId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthUserRole】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserRoleSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserRoleSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserRoleSelectByParams]
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [map_id] DESC '
AS
	SET NOCOUNT ON
    if @where is null or @where=''    ----没有设置查询条件
	begin
		SET @where = ' 1=1 '
	end
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_user_role]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthUserRole】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserRoleCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserRoleCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserRoleCountByWhere]
    @where varchar(8000) = ' 1=1 ',
    @recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[dawn_auth_user_role] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【DawnAuthUserRole】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserRoleSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserRoleSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ?当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserRoleSelectByPagerParams]
    @pageSize int = 10,
    @pageIndex int = 1,
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [map_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[dawn_auth_user_role]
		where [map_id] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [map_id] FROM [dbo].[dawn_auth_user_role]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【DawnAuthUserRole】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserRoleIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserRoleIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MapId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserRoleIsExist]
    @MapId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_user_role]
		where [map_id] = @MapId
	RETURN @@Error
GO

/********************通过指定条件查询数据表【DawnAuthUserRole】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserRoleIsExistByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserRoleIsExistByWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserRoleIsExistByWhere]
    @where varchar(8000) = ' 1=1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'SELECT count(-1) FROM [dbo].[dawn_auth_user_role]	where '
    exec ( @filter + @where )
    RETURN @@Error
GO



