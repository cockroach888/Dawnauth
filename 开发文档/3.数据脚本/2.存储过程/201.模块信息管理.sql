USE [DawnAuthority]
GO

/******************************【模块信息管理表】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2013年04月05日 21:32:51】----
----------------------------------------------------------------------------------------------

/********************数据表【DawnAuthModule】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlId  模块编号
@MdlName  模块名称
@MdlFather  模块标识
@MdlCode  模块编码
@MdlIdent  模块识别码
@MdlRank  模块序列
@MdlClick  模块点击
@MdlCounts  模块统计
@MdlDesc  模块描述
@MdlTime  添加时间
@addFlag  添加标记
*/	
CREATE PROCEDURE [dbo].[DawnAuthModuleInsert]
	@MdlId int output,
	@MdlName nvarchar(50),
	@MdlFather int,
	@MdlCode varchar(50),
	@MdlIdent int,
	@MdlRank int,
	@MdlClick int,
	@MdlCounts int,
	@MdlDesc nvarchar(300),
	@MdlTime datetime,
	@addFlag bit
AS
	SET NOCOUNT ON	
	--系统编号
    set @MdlId = (select case when max(mdl_id) is null then 1 else max(mdl_id)+1 end from dawn_auth_module)
	--类别路径
	DECLARE @MdlPath varchar(max)
	BEGIN
		if @addFlag=1
			set @MdlPath=((select mdl_path from dawn_auth_module where mdl_id=@MdlFather)+CONVERT(varchar(max),@MdlId)+',')
		else
			set @MdlPath=('0,'+CONVERT(varchar(max),@MdlId)+',')
	END
	--开始执行
	insert into dawn_auth_module
	(
		[mdl_id],
		[mdl_name],
		[mdl_father],
		[mdl_path],
		[mdl_code],
		[mdl_ident],
		[mdl_rank],
		[mdl_click],
		[mdl_counts],
		[mdl_desc],
		[mdl_time]
	) 
	values
	(
		@MdlId,
		@MdlName,
		@MdlFather,
		@MdlPath,
		@MdlCode,
		@MdlIdent,
		@MdlRank,
		@MdlClick,
		@MdlCounts,
		@MdlDesc,
		@MdlTime
	)
	return @@error
GO

/********************数据表【DawnAuthModule】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlId  模块编号
@MdlName  模块名称
@MdlCode  模块编码
@MdlIdent  模块识别码
@MdlRank  模块序列
@MdlClick  模块点击
@MdlCounts  模块统计
@MdlDesc  模块描述
*/	
CREATE PROCEDURE [dbo].[DawnAuthModuleUpdate]
	@MdlId int,
	@MdlName nvarchar(50),
	@MdlCode varchar(50),
	@MdlIdent int,
	@MdlRank int,
	@MdlClick int,
	@MdlCounts int,
	@MdlDesc nvarchar(300)
AS
	SET NOCOUNT ON
	UPDATE [dawn_auth_module] SET
		[mdl_name] = @MdlName,
		[mdl_code] = @MdlCode,
		[mdl_ident] = @MdlIdent,
		[mdl_rank] = @MdlRank,
		[mdl_click] = @MdlClick,
		[mdl_counts] = @MdlCounts,
		[mdl_desc] = @MdlDesc
	WHERE
		[mdl_id] = @MdlId
	return @@error
GO

/********************更新数据表【DawnAuthModule】点击率********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleClick]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleClick]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlId  模块编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthModuleClick]
	@MdlId int
AS
	SET NOCOUNT ON
	UPDATE [dawn_auth_module] SET
		[mdl_click] = [mdl_click]+1
	WHERE
		[mdl_id] = @MdlId
	return @@error
GO

/********************更新数据表【DawnAuthModule】数据统计********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleCounts]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleCounts]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlId  模块编号
@countFlag  统计标记
*/	
CREATE PROCEDURE [dbo].[DawnAuthModuleCounts]
	@MdlId int,
	@countFlag tinyint
AS
	SET NOCOUNT ON
	BEGIN
		IF @countFlag=0
			UPDATE [dawn_auth_module] SET
				[mdl_counts] = [mdl_counts]+1
			WHERE
				[mdl_id] = @MdlId
		ELSE IF @countFlag=1
			UPDATE [dawn_auth_module] SET
				[mdl_counts] = [mdl_counts]-1
			WHERE
				[mdl_id] = @MdlId
	END	
	return @@error
GO

/********************数据表【DawnAuthModule】变更存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleChange]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleChange]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlId  模块编号
@MdlFather  模块标识 
*/	
CREATE PROCEDURE [dbo].[DawnAuthModuleChange]
	@MdlId int,
	@MdlFather int
AS
	SET NOCOUNT ON
 	--类别路径
	DECLARE @MdlPath varchar(max)
	BEGIN
		if @MdlFather<>-1
			set @MdlPath=((select mdl_path from dawn_auth_module where mdl_id=@MdlFather)+CONVERT(varchar(max),@MdlId)+',')
		else
			set @MdlPath=('0,'+CONVERT(varchar(max),@MdlId)+',')
	END
	--开始执行
	UPDATE [dawn_auth_module] SET
		[mdl_father] = @MdlFather,
		[mdl_path] = @MdlPath
	WHERE
		[mdl_id] = @MdlId
	return @@error
GO

/********************数据表【DawnAuthModule】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlId  模块编号
@delFlag		删除标记
*/	
CREATE PROCEDURE [dbo].[DawnAuthModuleDelete]
	@MdlId int,
	@delFlag bit
AS
	SET NOCOUNT ON
	BEGIN
		IF @delFlag=1			
			DELETE FROM [dawn_auth_module] WHERE charindex(','+CONVERT(varchar(max),@MdlId)+',',mdl_path)>0
		ELSE
			DELETE FROM [dawn_auth_module] WHERE [mdl_id] = @MdlId
	END
	return @@error
GO

/********************数据表【DawnAuthModule】条件删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleDeleteWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleDeleteWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 删除条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthModuleDeleteWhere]
	@where varchar(8000) = ' 1<>1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'delete from [dbo].[dawn_auth_module] where '
    exec ( @filter + @where )
	return @@error
GO

/********************查询数据表【DawnAuthModule】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthModuleSelectAll]
    @sortField varchar(100) = ' [mdl_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_module] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【DawnAuthModule】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlId 
*/	
CREATE PROCEDURE [dbo].[DawnAuthModuleSelect]
    @MdlId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[dawn_auth_module] where [mdl_id] = @MdlId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthModule】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthModuleSelectByParams]
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [mdl_id] DESC '
AS
	SET NOCOUNT ON
	if @where is null or @where=''    ----没有设置查询条件
	begin
		SET @where = ' 1=1 '
	end
    declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_module]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthModule】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[DawnAuthModuleCountByWhere]
    @where varchar(8000) = ' 1=1 ',
    @recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[dawn_auth_module] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【DawnAuthModule】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ǰ当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthModuleSelectByPagerParams]
    @pageSize int = 10,
    @pageIndex int = 1,
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [mdl_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[dawn_auth_module]
		where [mdl_id] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [mdl_id] FROM [dbo].[dawn_auth_module]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过编号查询数据表【DawnAuthModule】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleIsExistById]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleIsExistById]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlId 模块编号
*/
CREATE PROCEDURE [dbo].[DawnAuthModuleIsExistById]
    @MdlId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_module]
		where [mdl_id] = @MdlId
	RETURN @@Error
GO

/********************通过名称查询数据表【DawnAuthModule】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleIsExistByName]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleIsExistByName]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlName  模块名称
*/
CREATE PROCEDURE [dbo].[DawnAuthModuleIsExistByName]
    @MdlName nvarchar(50)
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_module]
		where [mdl_name] = @MdlName
	RETURN @@Error
GO

/********************通过点击查询数据表【DawnAuthModule】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleIsExistByClick]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleIsExistByClick]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlClick  模块点击
*/
CREATE PROCEDURE [dbo].[DawnAuthModuleIsExistByClick]
    @MdlClick int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_module]
		where [mdl_click] = @MdlClick
	RETURN @@Error
GO

/********************通过父标识查询数据表【DawnAuthModule】是否存在隶属记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleIsExistByChild]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleIsExistByChild]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlFather  模块标识
*/
CREATE PROCEDURE [dbo].[DawnAuthModuleIsExistByChild]
    @MdlFather int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_module]
		where [mdl_father] = @MdlFather
	RETURN @@Error
GO

/********************通过名称和父标识查询数据表【DawnAuthModule】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleIsExistByFather]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleIsExistByFather]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlName  模块名称
@MdlFather  模块标识
*/
CREATE PROCEDURE [dbo].[DawnAuthModuleIsExistByFather]
    @MdlName nvarchar(50),
    @MdlFather int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_module]
		where [mdl_name] = @MdlName and [mdl_father] = @MdlFather
	RETURN @@Error
GO

/********************通过编码查询数据表【DawnAuthModule】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleIsExistByCode]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleIsExistByCode]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlCode  模块编码
*/
CREATE PROCEDURE [dbo].[DawnAuthModuleIsExistByCode]
    @MdlCode varchar(50)
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_module]
		where [mdl_code] = @MdlCode
	RETURN @@Error
GO

/********************通过识别码查询数据表【DawnAuthModule】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleIsExistByIdent]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleIsExistByIdent]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlIdent  模块识别码
*/
CREATE PROCEDURE [dbo].[DawnAuthModuleIsExistByIdent]
    @MdlIdent int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_module]
		where [mdl_ident] = @MdlIdent
	RETURN @@Error
GO

/********************通过编码和识别码查询数据表【DawnAuthModule】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleIsExistByCodeIdent]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleIsExistByCodeIdent]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlCode  模块编码
@MdlIdent  模块识别码
*/
CREATE PROCEDURE [dbo].[DawnAuthModuleIsExistByCodeIdent]
    @MdlCode varchar(50),
    @MdlIdent int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_module]
		where [mdl_code] = @MdlCode
        and [mdl_ident] = @MdlIdent
	RETURN @@Error
GO

/********************通过名称和父标识及编码查询数据表【DawnAuthModule】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleIsExistByStrict]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleIsExistByStrict]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlName  模块名称
@MdlFather  模块标识
@MdlCode  模块编码
*/
CREATE PROCEDURE [dbo].[DawnAuthModuleIsExistByStrict]
    @MdlName nvarchar(50),
    @MdlFather int,
    @MdlCode varchar(50)
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_module]
		where [mdl_name] = @MdlName
        and [mdl_father] = @MdlFather
        and [mdl_code] = @MdlCode
	RETURN @@Error
GO

/********************通过名称和父标识、编码、识别码查询数据表【DawnAuthModule】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleIsExistByForbid]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleIsExistByForbid]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@MdlName  模块名称
@MdlFather  模块标识
@MdlCode  模块编码
@MdlIdent  模块识别码
*/
CREATE PROCEDURE [dbo].[DawnAuthModuleIsExistByForbid]
    @MdlName nvarchar(50),
    @MdlFather int,
    @MdlCode varchar(50),
    @MdlIdent int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_module]
		where [mdl_name] = @MdlName
        and [mdl_father] = @MdlFather
        and [mdl_code] = @MdlCode
        and [mdl_ident] = @MdlIdent
	RETURN @@Error
GO

/********************通过指定条件查询数据表【DawnAuthModule】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthModuleIsExistByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthModuleIsExistByWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthModuleIsExistByWhere]
    @where varchar(8000) = ' 1=1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'SELECT count(-1) FROM [dbo].[dawn_auth_module] where '
    exec ( @filter + @where )
    RETURN @@Error
GO


