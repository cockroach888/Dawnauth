USE [DawnAuthority]
GO

/******************************【状态映射管理表】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2013年02月28日 13:21:00】----
----------------------------------------------------------------------------------------------

/********************数据表【DawnAuthUserStatus】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserStatusInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserStatusInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MapId  系统编号
@UserId  用户编号 
@StatId  状态编号 
@MapTime  添加时间 
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserStatusInsert]
	@MapId int output,
	@UserId int,
	@StatId int,
	@MapTime datetime
AS
	SET NOCOUNT ON
	insert into dawn_auth_user_status
	(
		[user_id],
		[stat_id],
		[map_time]
	) 
	values
	(
		@UserId,
		@StatId,
		@MapTime
	)
	set @MapId=scope_identity()
	return @@error
GO

/********************数据表【DawnAuthUserStatus】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserStatusUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserStatusUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MapId  系统编号
@UserId  用户编号 
@StatId  状态编号 
@MapTime  添加时间 
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserStatusUpdate]
	@MapId int,
	@UserId int,
	@StatId int,
	@MapTime datetime
AS
 SET NOCOUNT ON
 UPDATE [dawn_auth_user_status] SET
		[user_id] = @UserId,
		[stat_id] = @StatId,
		[map_time] = @MapTime
 WHERE
		[map_id] = @MapId
    return @@error
GO

/********************数据表【DawnAuthUserStatus】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserStatusDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserStatusDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MapId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserStatusDelete]
	@MapId int
AS
	SET NOCOUNT ON
	delete from [dawn_auth_user_status] where  [map_id] = @MapId
	return @@error
GO

/********************数据表【DawnAuthUserStatus】条件删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserStatusDeleteWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserStatusDeleteWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 删除条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserStatusDeleteWhere]
	@where varchar(8000) = ' 1<>1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'delete from [dbo].[dawn_auth_user_status] where '
    exec ( @filter + @where )
	return @@error
GO

/********************查询数据表【DawnAuthUserStatus】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserStatusSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserStatusSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserStatusSelectAll]
    @sortField varchar(100) = ' [map_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_user_status] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【DawnAuthUserStatus】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserStatusSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserStatusSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MapId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserStatusSelect]
    @MapId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[dawn_auth_user_status]
		where [map_id] = @MapId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthUserStatus】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserStatusSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserStatusSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserStatusSelectByParams]
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [map_id] DESC '
AS
	SET NOCOUNT ON
    if @where is null or @where=''    ----没有设置查询条件
	begin
		SET @where = ' 1=1 '
	end
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_user_status]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthUserStatus】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserStatusCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserStatusCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserStatusCountByWhere]
    @where varchar(8000) = ' 1=1 ',
    @recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[dawn_auth_user_status] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【DawnAuthUserStatus】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserStatusSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserStatusSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ǰ当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserStatusSelectByPagerParams]
    @pageSize int = 10,
    @pageIndex int = 1,
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [map_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[dawn_auth_user_status]
		where [map_id] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [map_id] FROM [dbo].[dawn_auth_user_status]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【DawnAuthUserStatus】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserStatusIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserStatusIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MapId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserStatusIsExist]
    @MapId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_user_status]
		where [map_id] = @MapId
	RETURN @@Error
GO

/********************通过指定条件查询数据表【DawnAuthUserStatus】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserStatusIsExistByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserStatusIsExistByWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserStatusIsExistByWhere]
    @where varchar(8000) = ' 1=1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'SELECT count(-1) FROM [dbo].[dawn_auth_user_status]	where '
    exec ( @filter + @where )
    RETURN @@Error
GO



