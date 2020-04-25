USE [DawnAuthority]
GO

/******************************【权限映射管理表】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2013年04月05日 23:29:10】----
----------------------------------------------------------------------------------------------

/********************数据表【DawnAuthUserPower】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPowerInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPowerInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MapId  系统编号
@UserId  用户编号 
@MapTime  添加时间 
@MapModule  模块识别码 
@MapFunction  功能识别码 
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPowerInsert]
	@MapId int output,
	@UserId int,
	@MapTime datetime,
	@MapModule int,
	@MapFunction varchar(max)
AS
	SET NOCOUNT ON
	insert into dawn_auth_user_power
	(
		[user_id],
		[map_time],
		[map_module],
		[map_function]
	) 
	values
	(
		@UserId,
		@MapTime,
		@MapModule,
		@MapFunction
	)
	set @MapId=scope_identity()
	return @@error
GO

/********************数据表【DawnAuthUserPower】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPowerUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPowerUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MapId  系统编号
@UserId  用户编号 
@MapTime  添加时间 
@MapModule  模块识别码 
@MapFunction  功能识别码 
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPowerUpdate]
	@MapId int,
	@UserId int,
	@MapTime datetime,
	@MapModule int,
	@MapFunction varchar(max)
AS
 SET NOCOUNT ON
 UPDATE [dawn_auth_user_power] SET
		[user_id] = @UserId,
		[map_time] = @MapTime,
		[map_module] = @MapModule,
		[map_function] = @MapFunction
 WHERE
		[map_id] = @MapId
    return @@error
GO

/********************数据表【DawnAuthUserPower】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPowerDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPowerDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MapId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPowerDelete]
	@MapId int
AS
	SET NOCOUNT ON
	delete from [dawn_auth_user_power] where  [map_id] = @MapId
	return @@error
GO

/********************数据表【DawnAuthUserPower】条件删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPowerDeleteWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPowerDeleteWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 删除条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPowerDeleteWhere]
	@where varchar(8000) = ' 1<>1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'delete from [dbo].[dawn_auth_user_power] where '
    exec ( @filter + @where )
	return @@error
GO

/********************查询数据表【DawnAuthUserPower】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPowerSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPowerSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPowerSelectAll]
    @sortField varchar(100) = ' [map_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_user_power] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【DawnAuthUserPower】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPowerSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPowerSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MapId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPowerSelect]
    @MapId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[dawn_auth_user_power]
		where [map_id] = @MapId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthUserPower】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPowerSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPowerSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPowerSelectByParams]
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [map_id] DESC '
AS
	SET NOCOUNT ON
    if @where is null or @where=''    ----没有设置查询条件
	begin
		SET @where = ' 1=1 '
	end
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_user_power]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthUserPower】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPowerCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPowerCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPowerCountByWhere]
    @where varchar(8000) = ' 1=1 ',
    @recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[dawn_auth_user_power] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【DawnAuthUserPower】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPowerSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPowerSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ǰ当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPowerSelectByPagerParams]
    @pageSize int = 10,
    @pageIndex int = 1,
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [map_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[dawn_auth_user_power]
		where [map_id] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [map_id] FROM [dbo].[dawn_auth_user_power]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【DawnAuthUserPower】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPowerIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPowerIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MapId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPowerIsExist]
    @MapId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_user_power]
		where [map_id] = @MapId
	RETURN @@Error
GO

/********************通过指定条件查询数据表【DawnAuthUserPower】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPowerIsExistByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPowerIsExistByWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPowerIsExistByWhere]
    @where varchar(8000) = ' 1=1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'SELECT count(-1) FROM [dbo].[dawn_auth_user_power]	where '
    exec ( @filter + @where )
    RETURN @@Error
GO



