USE [DawnAuthority]
GO

/******************************【登录日志管理】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2013年02月11日 11:26:03】----
----------------------------------------------------------------------------------------------

/********************数据表【DawnAuthUserLogin】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserLoginInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserLoginInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@LogId  系统编号
@UserId  用户编号 
@LogTime  登录时间 
@LogIp  IP地址 
@LogMac  MAC地址 
@LogComputer  计算机名称 
@LogAttach  附加信息 
@LogCount  登录次数 
@LogFieldOne  备用字段一 
@LogFieldTwo  备用字段二 
@LogFieldThree  备用字段三 
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserLoginInsert]
	@LogId int output,
	@UserId int,
	@LogTime datetime,
	@LogIp varchar(200),
	@LogMac varchar(100),
	@LogComputer varchar(100),
	@LogAttach nvarchar(max),
	@LogCount int,
	@LogFieldOne int,
	@LogFieldTwo tinyint,
	@LogFieldThree varchar(max)
AS
	SET NOCOUNT ON
	insert into dawn_auth_user_login
	(
		[user_id],
		[log_time],
		[log_ip],
		[log_mac],
		[log_computer],
		[log_attach],
		[log_count],
		[log_field_one],
		[log_field_two],
		[log_field_three]
	) 
	values
	(
		@UserId,
		@LogTime,
		@LogIp,
		@LogMac,
		@LogComputer,
		@LogAttach,
		@LogCount,
		@LogFieldOne,
		@LogFieldTwo,
		@LogFieldThree
	)
	set @LogId=scope_identity()
	return @@error
GO

/********************数据表【DawnAuthUserLogin】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserLoginUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserLoginUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@LogId  系统编号
@UserId  用户编号 
@LogTime  登录时间 
@LogIp  IP地址 
@LogMac  MAC地址 
@LogComputer  计算机名称 
@LogAttach  附加信息 
@LogCount  登录次数 
@LogFieldOne  备用字段一 
@LogFieldTwo  备用字段二 
@LogFieldThree  备用字段三 
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserLoginUpdate]
	@LogId int,
	@UserId int,
	@LogTime datetime,
	@LogIp varchar(200),
	@LogMac varchar(100),
	@LogComputer varchar(100),
	@LogAttach nvarchar(max),
	@LogCount int,
	@LogFieldOne int,
	@LogFieldTwo tinyint,
	@LogFieldThree varchar(max)
AS
 SET NOCOUNT ON
 UPDATE [dawn_auth_user_login] SET
		[user_id] = @UserId,
		[log_time] = @LogTime,
		[log_ip] = @LogIp,
		[log_mac] = @LogMac,
		[log_computer] = @LogComputer,
		[log_attach] = @LogAttach,
		[log_count] = @LogCount,
		[log_field_one] = @LogFieldOne,
		[log_field_two] = @LogFieldTwo,
		[log_field_three] = @LogFieldThree
 WHERE
		[log_id] = @LogId
    return @@error
GO

/********************数据表【DawnAuthUserLogin】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserLoginDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserLoginDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@LogId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserLoginDelete]
	@LogId int
AS
	SET NOCOUNT ON
	delete from [dawn_auth_user_login] where  [log_id] = @LogId
	return @@error
GO

/********************数据表【DawnAuthUserLogin】条件删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserLoginDeleteWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserLoginDeleteWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 删除条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserLoginDeleteWhere]
	@where varchar(8000) = ' 1<>1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'delete from [dbo].[dawn_auth_user_login] where '
    exec ( @filter + @where )
	return @@error
GO

/********************查询数据表【DawnAuthUserLogin】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserLoginSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserLoginSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserLoginSelectAll]
    @sortField varchar(100) = ' [log_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_user_login] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【DawnAuthUserLogin】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserLoginSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserLoginSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@LogId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserLoginSelect]
    @LogId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[dawn_auth_user_login]
		where [log_id] = @LogId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthUserLogin】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserLoginSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserLoginSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserLoginSelectByParams]
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [log_id] DESC '
AS
	SET NOCOUNT ON
    if @where is null or @where=''    ----没有设置查询条件
	begin
		SET @where = ' 1=1 '
	end
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_user_login]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthUserLogin】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserLoginCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserLoginCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserLoginCountByWhere]
    @where varchar(8000) = ' 1=1 ',
    @recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[dawn_auth_user_login] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【DawnAuthUserLogin】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserLoginSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserLoginSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ǰ当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserLoginSelectByPagerParams]
    @pageSize int = 10,
    @pageIndex int = 1,
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [log_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[dawn_auth_user_login]
		where [log_id] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [log_id] FROM [dbo].[dawn_auth_user_login]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【DawnAuthUserLogin】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserLoginIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserLoginIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@LogId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserLoginIsExist]
    @LogId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_user_login]
		where [log_id] = @LogId
	RETURN @@Error
GO

/********************通过指定条件查询数据表【DawnAuthUserLogin】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserLoginIsExistByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserLoginIsExistByWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserLoginIsExistByWhere]
    @where varchar(8000) = ' 1=1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'SELECT count(-1) FROM [dbo].[dawn_auth_user_login]	where '
    exec ( @filter + @where )
    RETURN @@Error
GO



