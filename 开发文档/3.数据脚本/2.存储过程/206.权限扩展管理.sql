USE [DawnAuthority]
GO

/******************************【权限扩展管理】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2013年11月22日 19:20:58】----
----------------------------------------------------------------------------------------------

/********************数据表【DawnAuthExtent】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthExtentInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthExtentInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@ExteId  
@ExteTime   
@ExteStatus   
@ExteCode   
@ExteCodeName   
@ExteMark   
@ExteMarkName   
@ExteMemo   
@ExteFieldOne   
@ExteFieldTwo   
@ExteFieldThree   
*/	
CREATE PROCEDURE [dbo].[DawnAuthExtentInsert]
	@ExteId int output,
	@ExteTime datetime,
	@ExteStatus tinyint,
	@ExteCode varchar(100),
	@ExteCodeName nvarchar(200),
	@ExteMark varchar(100),
	@ExteMarkName nvarchar(200),
	@ExteMemo nvarchar(500),
	@ExteFieldOne int,
	@ExteFieldTwo tinyint,
	@ExteFieldThree varchar(2000)
AS
	SET NOCOUNT ON
	insert into dawn_auth_extent
	(
		[exte_time],
		[exte_status],
		[exte_code],
		[exte_code_name],
		[exte_mark],
		[exte_mark_name],
		[exte_memo],
		[exte_field_one],
		[exte_field_two],
		[exte_field_three]
	) 
	values
	(
		@ExteTime,
		@ExteStatus,
		@ExteCode,
		@ExteCodeName,
		@ExteMark,
		@ExteMarkName,
		@ExteMemo,
		@ExteFieldOne,
		@ExteFieldTwo,
		@ExteFieldThree
	)
	set @ExteId=scope_identity()
	return @@error
GO

/********************数据表【DawnAuthExtent】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthExtentUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthExtentUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@ExteId  
@ExteTime   
@ExteStatus   
@ExteCode   
@ExteCodeName   
@ExteMark   
@ExteMarkName   
@ExteMemo   
@ExteFieldOne   
@ExteFieldTwo   
@ExteFieldThree   
*/	
CREATE PROCEDURE [dbo].[DawnAuthExtentUpdate]
	@ExteId int,
	@ExteTime datetime,
	@ExteStatus tinyint,
	@ExteCode varchar(100),
	@ExteCodeName nvarchar(200),
	@ExteMark varchar(100),
	@ExteMarkName nvarchar(200),
	@ExteMemo nvarchar(500),
	@ExteFieldOne int,
	@ExteFieldTwo tinyint,
	@ExteFieldThree varchar(2000)
AS
 SET NOCOUNT ON
 UPDATE [dawn_auth_extent] SET
		[exte_time] = @ExteTime,
		[exte_status] = @ExteStatus,
		[exte_code] = @ExteCode,
		[exte_code_name] = @ExteCodeName,
		[exte_mark] = @ExteMark,
		[exte_mark_name] = @ExteMarkName,
		[exte_memo] = @ExteMemo,
		[exte_field_one] = @ExteFieldOne,
		[exte_field_two] = @ExteFieldTwo,
		[exte_field_three] = @ExteFieldThree
 WHERE
		[exte_id] = @ExteId
    return @@error
GO

/********************数据表【DawnAuthExtent】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthExtentDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthExtentDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@ExteId  
*/	
CREATE PROCEDURE [dbo].[DawnAuthExtentDelete]
	@ExteId int
AS
	SET NOCOUNT ON
	delete from [dawn_auth_extent] where  [exte_id] = @ExteId
	return @@error
GO

/********************数据表【DawnAuthExtent】条件删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthExtentDeleteWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthExtentDeleteWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 删除条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthExtentDeleteWhere]
	@where varchar(8000) = ' 1<>1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'delete from [dbo].[dawn_auth_extent] where '
    exec ( @filter + @where )
	return @@error
GO

/********************查询数据表【DawnAuthExtent】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthExtentSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthExtentSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthExtentSelectAll]
    @sortField varchar(100) = ' [exte_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_extent] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【DawnAuthExtent】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthExtentSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthExtentSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@ExteId  
*/	
CREATE PROCEDURE [dbo].[DawnAuthExtentSelect]
    @ExteId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[dawn_auth_extent]
		where [exte_id] = @ExteId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthExtent】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthExtentSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthExtentSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthExtentSelectByParams]
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [exte_id] DESC '
AS
	SET NOCOUNT ON
    if @where is null or @where=''    ----没有设置查询条件
	begin
		SET @where = ' 1=1 '
	end
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_extent]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthExtent】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthExtentCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthExtentCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[DawnAuthExtentCountByWhere]
    @where varchar(8000) = ' 1=1 ',
    @recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[dawn_auth_extent] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【DawnAuthExtent】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthExtentSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthExtentSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex 当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthExtentSelectByPagerParams]
    @pageSize int = 10,
    @pageIndex int = 1,
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [exte_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[dawn_auth_extent]
		where [exte_id] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [exte_id] FROM [dbo].[dawn_auth_extent]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【DawnAuthExtent】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthExtentIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthExtentIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@ExteId  
*/	
CREATE PROCEDURE [dbo].[DawnAuthExtentIsExist]
    @ExteId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_extent]
		where [exte_id] = @ExteId
	RETURN @@Error
GO

/********************通过指定条件查询数据表【DawnAuthExtent】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthExtentIsExistByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthExtentIsExistByWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthExtentIsExistByWhere]
    @where varchar(8000) = ' 1=1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'SELECT count(-1) FROM [dbo].[dawn_auth_extent]	where '
    exec ( @filter + @where )
    RETURN @@Error
GO



