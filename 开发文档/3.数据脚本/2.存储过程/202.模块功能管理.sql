USE [DawnAuthority]
GO

/******************************【模块功能管理】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2013年04月05日 22:59:03】----
----------------------------------------------------------------------------------------------

/********************数据表【DawnAuthFunction】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthFunctionInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthFunctionInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@FunId  系统编号
@MdlId  模块信息编号 
@FunTime  添加时间 
@FunName  功能名称 
@FunCode  功能编码 
@FunIdent  功能识别码 
@FunMark  功能标识 
@FunParentMark  内部标识 
@FunDesc  功能描述 
*/	
CREATE PROCEDURE [dbo].[DawnAuthFunctionInsert]
	@FunId int output,
	@MdlId int,
	@FunTime datetime,
	@FunName nvarchar(50),
	@FunCode varchar(50),
	@FunIdent int,
	@FunMark int,
	@FunParentMark int,
	@FunDesc nvarchar(300)
AS
	SET NOCOUNT ON
	insert into dawn_auth_function
	(
		[mdl_id],
		[fun_time],
		[fun_name],
		[fun_code],
		[fun_ident],
		[fun_mark],
		[fun_parent_mark],
		[fun_desc]
	) 
	values
	(
		@MdlId,
		@FunTime,
		@FunName,
		@FunCode,
		@FunIdent,
		@FunMark,
		@FunParentMark,
		@FunDesc
	)
	set @FunId=scope_identity()
	return @@error
GO

/********************数据表【DawnAuthFunction】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthFunctionUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthFunctionUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@FunId  系统编号
@MdlId  模块信息编号 
@FunTime  添加时间 
@FunName  功能名称 
@FunCode  功能编码 
@FunIdent  功能识别码 
@FunMark  功能标识 
@FunParentMark  内部标识 
@FunDesc  功能描述 
*/	
CREATE PROCEDURE [dbo].[DawnAuthFunctionUpdate]
	@FunId int,
	@MdlId int,
	@FunTime datetime,
	@FunName nvarchar(50),
	@FunCode varchar(50),
	@FunIdent int,
	@FunMark int,
	@FunParentMark int,
	@FunDesc nvarchar(300)
AS
 SET NOCOUNT ON
 UPDATE [dawn_auth_function] SET
		[mdl_id] = @MdlId,
		[fun_time] = @FunTime,
		[fun_name] = @FunName,
		[fun_code] = @FunCode,
		[fun_ident] = @FunIdent,
		[fun_mark] = @FunMark,
		[fun_parent_mark] = @FunParentMark,
		[fun_desc] = @FunDesc
 WHERE
		[fun_id] = @FunId
    return @@error
GO

/********************数据表【DawnAuthFunction】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthFunctionDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthFunctionDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@FunId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthFunctionDelete]
	@FunId int
AS
	SET NOCOUNT ON
	delete from [dawn_auth_function] where  [fun_id] = @FunId
	return @@error
GO

/********************数据表【DawnAuthFunction】条件删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthFunctionDeleteWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthFunctionDeleteWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 删除条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthFunctionDeleteWhere]
	@where varchar(8000) = ' 1<>1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'delete from [dbo].[dawn_auth_function] where '
    exec ( @filter + @where )
	return @@error
GO

/********************查询数据表【DawnAuthFunction】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthFunctionSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthFunctionSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthFunctionSelectAll]
    @sortField varchar(100) = ' [fun_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_function] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【DawnAuthFunction】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthFunctionSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthFunctionSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@FunId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthFunctionSelect]
    @FunId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[dawn_auth_function]
		where [fun_id] = @FunId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthFunction】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthFunctionSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthFunctionSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthFunctionSelectByParams]
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [fun_id] DESC '
AS
	SET NOCOUNT ON
    if @where is null or @where=''    ----没有设置查询条件
	begin
		SET @where = ' 1=1 '
	end
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_function]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthFunction】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthFunctionCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthFunctionCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[DawnAuthFunctionCountByWhere]
    @where varchar(8000) = ' 1=1 ',
    @recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[dawn_auth_function] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【DawnAuthFunction】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthFunctionSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthFunctionSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ǰ当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthFunctionSelectByPagerParams]
    @pageSize int = 10,
    @pageIndex int = 1,
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [fun_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[dawn_auth_function]
		where [fun_id] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [fun_id] FROM [dbo].[dawn_auth_function]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【DawnAuthFunction】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthFunctionIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthFunctionIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@FunId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthFunctionIsExist]
    @FunId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_function]
		where [fun_id] = @FunId
	RETURN @@Error
GO

/********************通过指定条件查询数据表【DawnAuthFunction】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthFunctionIsExistByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthFunctionIsExistByWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthFunctionIsExistByWhere]
    @where varchar(8000) = ' 1=1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'SELECT count(-1) FROM [dbo].[dawn_auth_function]	where '
    exec ( @filter + @where )
    RETURN @@Error
GO



