USE [DawnAuthority]
GO

/******************************【日志信息管理】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2013年02月11日 11:16:27】----
----------------------------------------------------------------------------------------------

/********************数据表【DawnAuthLogs】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthLogsInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthLogsInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@LogId  系统编号
@LogTime  记录时间 
@LogRating  记录级别 
@LogTable  记录表名 
@LogAction  记录动作 
@LogMemo  记录备注 
@LogUid  用户编号 
@LogUname  用户名称 
*/	
CREATE PROCEDURE [dbo].[DawnAuthLogsInsert]
	@LogId uniqueidentifier output,
    @LogTime datetime,
    @LogRating tinyint,
    @LogTable varchar(200),
    @LogAction nvarchar(max),
    @LogMemo nvarchar(max),
    @LogUid int,
    @LogUname nvarchar(20)
AS
	SET NOCOUNT ON
    set @LogId=NEWID()
	insert into dawn_auth_logs
	(
        [log_id],
		[log_time],
		[log_rating],
		[log_table],
		[log_action],
		[log_memo],
		[log_uid],
		[log_uname]
	) 
	values
	(
        @LogId,
		@LogTime,
		@LogRating,
		@LogTable,
		@LogAction,
		@LogMemo,
		@LogUid,
		@LogUname
	)	
	return @@error
GO

/********************数据表【DawnAuthLogs】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthLogsDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthLogsDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@LogId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthLogsDelete]
	@LogId uniqueidentifier
AS
	SET NOCOUNT ON
	delete from [dawn_auth_logs] where  [log_id] = @LogId
	return @@error
GO

/********************数据表【DawnAuthLogs】条件删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthLogsDeleteWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthLogsDeleteWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 删除条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthLogsDeleteWhere]
	@where varchar(8000) = ' 1<>1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'delete from [dbo].[dawn_auth_logs] where '
    exec ( @filter + @where )
	return @@error
GO

/********************数据表【DawnAuthLogs】删除所有数据存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthLogsDeleteAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthLogsDeleteAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@LogId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthLogsDeleteAll]
	
AS
	SET NOCOUNT ON
	delete from [dawn_auth_logs]
	return @@error
GO

/********************查询数据表【DawnAuthLogs】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthLogsSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthLogsSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthLogsSelectAll]
@sortField varchar(100) = ' [log_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_logs] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【DawnAuthLogs】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthLogsSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthLogsSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@LogId 
*/	
CREATE PROCEDURE [dbo].[DawnAuthLogsSelect]
@LogId uniqueidentifier
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[dawn_auth_logs]
		where [log_id] = @LogId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthLogs】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthLogsSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthLogsSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthLogsSelectByParams]
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [log_id] DESC '
AS
	SET NOCOUNT ON
    if @where is null or @where=''    ----没有设置查询条件
	begin
		SET @where = ' 1=1 '
	end
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_logs]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthLogs】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthLogsCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthLogsCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[DawnAuthLogsCountByWhere]
@where varchar(8000) = ' 1=1 ',
@recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[dawn_auth_logs] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【DawnAuthLogs】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthLogsSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthLogsSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ǰ当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthLogsSelectByPagerParams]
@pageSize int = 10,
@pageIndex int = 1,
@where varchar(8000) = ' 1=1 ',
@sortField varchar(100) = ' [log_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[dawn_auth_logs]
		where [log_id] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [log_id] FROM [dbo].[dawn_auth_logs]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【DawnAuthLogs】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthLogsIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthLogsIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@LogId 
*/	
CREATE PROCEDURE [dbo].[DawnAuthLogsIsExist]
@LogId uniqueidentifier
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_logs]
		where [log_id] = @LogId
	RETURN @@Error
GO

/********************通过指定条件查询数据表【DawnAuthLogs】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthLogsIsExistByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthLogsIsExistByWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthLogsIsExistByWhere]
@where varchar(8000) = ' 1=1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'SELECT count(-1) FROM [dbo].[dawn_auth_logs]	where '
    exec ( @filter + @where )
    RETURN @@Error
GO



