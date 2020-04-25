USE [DawnAuthority]
GO

/******************************【错误信息管理表】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2013年02月11日 11:16:17】----
----------------------------------------------------------------------------------------------

/********************数据表【DawnAuthError】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthErrorInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthErrorInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@ErrId  系统编号
@ErrTime  记录时间 
@ErrAddress  错误地址 
@ErrMessage  错误消息 
@ErrTarget  错误目标 
@ErrTrace  错误跟踪 
@ErrSource  错误来源 
@ErrIp  用户IP码 
@ErrUid  用户编号 
@ErrUname  用户名称 
*/	
CREATE PROCEDURE [dbo].[DawnAuthErrorInsert]
	@ErrId uniqueidentifier output,
    @ErrTime datetime,
    @ErrAddress varchar(2000),
    @ErrMessage varchar(4000),
    @ErrTarget varchar(max),
    @ErrTrace nvarchar(max),
    @ErrSource nvarchar(max),
    @ErrIp varchar(200),
    @ErrUid int,
    @ErrUname nvarchar(20)
AS
	SET NOCOUNT ON
    set @ErrId=NEWID()
	insert into dawn_auth_error
	(
        [err_id],
		[err_time],
		[err_address],
		[err_message],
		[err_target],
		[err_trace],
		[err_source],
		[err_ip],
		[err_uid],
		[err_uname]
	) 
	values
	(
        @ErrId,
		@ErrTime,
		@ErrAddress,
		@ErrMessage,
		@ErrTarget,
		@ErrTrace,
		@ErrSource,
		@ErrIp,
		@ErrUid,
		@ErrUname
	)	
	return @@error
GO

/********************数据表【DawnAuthError】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthErrorDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthErrorDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@ErrId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthErrorDelete]
	@ErrId uniqueidentifier
AS
	SET NOCOUNT ON
	delete from [dawn_auth_error] where  [err_id] = @ErrId
	return @@error
GO

/********************数据表【DawnAuthError】条件删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthErrorDeleteWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthErrorDeleteWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 删除条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthErrorDeleteWhere]
	@where varchar(8000) = ' 1<>1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'delete from [dbo].[dawn_auth_error] where '
    exec ( @filter + @where )
	return @@error
GO

/********************数据表【DawnAuthError】删除所有数据存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthErrorDeleteAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthErrorDeleteAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@ErrId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthErrorDeleteAll]
	
AS
	SET NOCOUNT ON
	delete from [dawn_auth_error]
	return @@error
GO

/********************查询数据表【DawnAuthError】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthErrorSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthErrorSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthErrorSelectAll]
@sortField varchar(100) = ' [err_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_error] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【DawnAuthError】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthErrorSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthErrorSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@ErrId 
*/	
CREATE PROCEDURE [dbo].[DawnAuthErrorSelect]
@ErrId uniqueidentifier
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[dawn_auth_error]
		where [err_id] = @ErrId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthError】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthErrorSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthErrorSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthErrorSelectByParams]
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [err_id] DESC '
AS
	SET NOCOUNT ON
    if @where is null or @where=''    ----没有设置查询条件
	begin
		SET @where = ' 1=1 '
	end
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_error]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthError】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthErrorCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthErrorCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[DawnAuthErrorCountByWhere]
@where varchar(8000) = ' 1=1 ',
@recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[dawn_auth_error] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【DawnAuthError】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthErrorSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthErrorSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ǰ当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthErrorSelectByPagerParams]
@pageSize int = 10,
@pageIndex int = 1,
@where varchar(8000) = ' 1=1 ',
@sortField varchar(100) = ' [err_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[dawn_auth_error]
		where [err_id] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [err_id] FROM [dbo].[dawn_auth_error]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【DawnAuthError】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthErrorIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthErrorIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@ErrId 
*/	
CREATE PROCEDURE [dbo].[DawnAuthErrorIsExist]
@ErrId uniqueidentifier
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_error]
		where [err_id] = @ErrId
	RETURN @@Error
GO

/********************通过指定条件查询数据表【DawnAuthError】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthErrorIsExistByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthErrorIsExistByWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthErrorIsExistByWhere]
@where varchar(8000) = ' 1=1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'SELECT count(-1) FROM [dbo].[dawn_auth_error]	where '
    exec ( @filter + @where )
    RETURN @@Error
GO



