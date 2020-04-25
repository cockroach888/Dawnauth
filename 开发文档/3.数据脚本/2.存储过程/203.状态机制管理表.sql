USE [DawnAuthority]
GO

/******************************【状态机制管理表】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2013年04月05日 23:39:24】----
----------------------------------------------------------------------------------------------

/********************数据表【DawnAuthStatus】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthStatusInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthStatusInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@StatId  系统编号
@MdlId  模块信息编号 
@StatTime  添加时间 
@StatName  状态名称 
@StatCode  状态编码 
@StatMark  状态标识 
@StatDesc  状态描述 
@StatFieldOne  备用字段一 
@StatFieldTwo  备用字段二 
@StatFieldThree  备用字段三 
*/	
CREATE PROCEDURE [dbo].[DawnAuthStatusInsert]
	@StatId int output,
	@MdlId int,
	@StatTime datetime,
	@StatName nvarchar(50),
	@StatCode varchar(50),
	@StatMark int,
	@StatDesc nvarchar(300),
	@StatFieldOne int,
	@StatFieldTwo tinyint,
	@StatFieldThree varchar(50)
AS
	SET NOCOUNT ON
	insert into dawn_auth_status
	(
		[mdl_id],
		[stat_time],
		[stat_name],
		[stat_code],
		[stat_mark],
		[stat_desc],
		[stat_field_one],
		[stat_field_two],
		[stat_field_three]
	) 
	values
	(
		@MdlId,
		@StatTime,
		@StatName,
		@StatCode,
		@StatMark,
		@StatDesc,
		@StatFieldOne,
		@StatFieldTwo,
		@StatFieldThree
	)
	set @StatId=scope_identity()
	return @@error
GO

/********************数据表【DawnAuthStatus】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthStatusUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthStatusUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@StatId  系统编号
@MdlId  模块信息编号 
@StatTime  添加时间 
@StatName  状态名称 
@StatCode  状态编码 
@StatMark  状态标识 
@StatDesc  状态描述 
@StatFieldOne  备用字段一 
@StatFieldTwo  备用字段二 
@StatFieldThree  备用字段三 
*/	
CREATE PROCEDURE [dbo].[DawnAuthStatusUpdate]
	@StatId int,
	@MdlId int,
	@StatTime datetime,
	@StatName nvarchar(50),
	@StatCode varchar(50),
	@StatMark int,
	@StatDesc nvarchar(300),
	@StatFieldOne int,
	@StatFieldTwo tinyint,
	@StatFieldThree varchar(50)
AS
 SET NOCOUNT ON
 UPDATE [dawn_auth_status] SET
		[mdl_id] = @MdlId,
		[stat_time] = @StatTime,
		[stat_name] = @StatName,
		[stat_code] = @StatCode,
		[stat_mark] = @StatMark,
		[stat_desc] = @StatDesc,
		[stat_field_one] = @StatFieldOne,
		[stat_field_two] = @StatFieldTwo,
		[stat_field_three] = @StatFieldThree
 WHERE
		[stat_id] = @StatId
    return @@error
GO

/********************数据表【DawnAuthStatus】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthStatusDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthStatusDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@StatId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthStatusDelete]
	@StatId int
AS
	SET NOCOUNT ON
	delete from [dawn_auth_status] where  [stat_id] = @StatId
	return @@error
GO

/********************数据表【DawnAuthStatus】条件删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthStatusDeleteWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthStatusDeleteWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 删除条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthStatusDeleteWhere]
	@where varchar(8000) = ' 1<>1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'delete from [dbo].[dawn_auth_status] where '
    exec ( @filter + @where )
	return @@error
GO

/********************查询数据表【DawnAuthStatus】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthStatusSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthStatusSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthStatusSelectAll]
    @sortField varchar(100) = ' [stat_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_status] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【DawnAuthStatus】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthStatusSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthStatusSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@StatId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthStatusSelect]
    @StatId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[dawn_auth_status]
		where [stat_id] = @StatId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthStatus】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthStatusSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthStatusSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthStatusSelectByParams]
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [stat_id] DESC '
AS
	SET NOCOUNT ON
    if @where is null or @where=''    ----没有设置查询条件
	begin
		SET @where = ' 1=1 '
	end
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_status]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthStatus】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthStatusCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthStatusCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[DawnAuthStatusCountByWhere]
    @where varchar(8000) = ' 1=1 ',
    @recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[dawn_auth_status] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【DawnAuthStatus】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthStatusSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthStatusSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ǰ当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthStatusSelectByPagerParams]
    @pageSize int = 10,
    @pageIndex int = 1,
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [stat_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[dawn_auth_status]
		where [stat_id] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [stat_id] FROM [dbo].[dawn_auth_status]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【DawnAuthStatus】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthStatusIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthStatusIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@StatId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthStatusIsExist]
    @StatId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_status]
		where [stat_id] = @StatId
	RETURN @@Error
GO

/********************通过指定条件查询数据表【DawnAuthStatus】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthStatusIsExistByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthStatusIsExistByWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthStatusIsExistByWhere]
    @where varchar(8000) = ' 1=1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'SELECT count(-1) FROM [dbo].[dawn_auth_status]	where '
    exec ( @filter + @where )
    RETURN @@Error
GO



