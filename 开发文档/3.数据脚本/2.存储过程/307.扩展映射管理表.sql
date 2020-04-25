USE [DawnAuthority]
GO

/******************************【扩展映射管理表】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2013年11月22日 19:01:01】----
----------------------------------------------------------------------------------------------

/********************数据表【DawnAuthUserExtent】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserExtentInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserExtentInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@ExtId  系统编号
@UserId  用户编号 
@ExtTime  添加时间 
@ExtCode  扩展编码 
@ExtMark  扩展标识 
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserExtentInsert]
	@ExtId int output,
	@UserId int,
	@ExtTime datetime,
	@ExtCode varchar(100),
	@ExtMark varchar(100)
AS
	SET NOCOUNT ON
	insert into dawn_auth_user_extent
	(
		[user_id],
		[ext_time],
		[ext_code],
		[ext_mark]
	) 
	values
	(
		@UserId,
		@ExtTime,
		@ExtCode,
		@ExtMark
	)
	set @ExtId=scope_identity()
	return @@error
GO

/********************数据表【DawnAuthUserExtent】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserExtentUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserExtentUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@ExtId  系统编号
@UserId  用户编号 
@ExtTime  添加时间 
@ExtCode  扩展编码 
@ExtMark  扩展标识 
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserExtentUpdate]
	@ExtId int,
	@UserId int,
	@ExtTime datetime,
	@ExtCode varchar(100),
	@ExtMark varchar(100)
AS
 SET NOCOUNT ON
 UPDATE [dawn_auth_user_extent] SET
		[user_id] = @UserId,
		[ext_time] = @ExtTime,
		[ext_code] = @ExtCode,
		[ext_mark] = @ExtMark
 WHERE
		[ext_id] = @ExtId
    return @@error
GO

/********************数据表【DawnAuthUserExtent】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserExtentDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserExtentDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@ExtId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserExtentDelete]
	@ExtId int
AS
	SET NOCOUNT ON
	delete from [dawn_auth_user_extent] where  [ext_id] = @ExtId
	return @@error
GO

/********************数据表【DawnAuthUserExtent】条件删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserExtentDeleteWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserExtentDeleteWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 删除条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserExtentDeleteWhere]
	@where varchar(8000) = ' 1<>1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'delete from [dbo].[dawn_auth_user_extent] where '
    exec ( @filter + @where )
	return @@error
GO

/********************查询数据表【DawnAuthUserExtent】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserExtentSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserExtentSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserExtentSelectAll]
    @sortField varchar(100) = ' [ext_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_user_extent] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【DawnAuthUserExtent】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserExtentSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserExtentSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@ExtId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserExtentSelect]
    @ExtId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[dawn_auth_user_extent]
		where [ext_id] = @ExtId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthUserExtent】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserExtentSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserExtentSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserExtentSelectByParams]
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [ext_id] DESC '
AS
	SET NOCOUNT ON
    if @where is null or @where=''    ----没有设置查询条件
	begin
		SET @where = ' 1=1 '
	end
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_user_extent]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthUserExtent】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserExtentCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserExtentCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserExtentCountByWhere]
    @where varchar(8000) = ' 1=1 ',
    @recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[dawn_auth_user_extent] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【DawnAuthUserExtent】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserExtentSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserExtentSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex 当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserExtentSelectByPagerParams]
    @pageSize int = 10,
    @pageIndex int = 1,
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [ext_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[dawn_auth_user_extent]
		where [ext_id] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [ext_id] FROM [dbo].[dawn_auth_user_extent]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【DawnAuthUserExtent】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserExtentIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserExtentIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@ExtId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserExtentIsExist]
    @ExtId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_user_extent]
		where [ext_id] = @ExtId
	RETURN @@Error
GO

/********************通过指定条件查询数据表【DawnAuthUserExtent】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserExtentIsExistByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserExtentIsExistByWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserExtentIsExistByWhere]
    @where varchar(8000) = ' 1=1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'SELECT count(-1) FROM [dbo].[dawn_auth_user_extent]	where '
    exec ( @filter + @where )
    RETURN @@Error
GO



