USE [DawnAuthority]
GO

/******************************【单位部门管理】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2013年11月22日 18:52:23】----
----------------------------------------------------------------------------------------------

/********************数据表【DawnAuthDepartment】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptId  系统编号
@DptName  部门名称
@DptFather  部门标识
@DptCode  部门编码
@DptIdent  部门识别码
@DptRank  部门序列
@DptClick  部门点击
@DptCounts  部门统计
@DptDesc  部门描述
@DptTime  添加时间
@addFlag  添加标记
*/	
CREATE PROCEDURE [dbo].[DawnAuthDepartmentInsert]
	@DptId int output,
	@DptName nvarchar(50),
	@DptFather int,
	@DptCode varchar(50),
	@DptIdent int,
	@DptRank int,
	@DptClick int,
	@DptCounts int,
	@DptDesc nvarchar(300),
	@DptTime datetime,
	@addFlag bit
AS
	SET NOCOUNT ON	
	--系统编号
    set @DptId = (select case when max(dpt_id) is null then 1 else max(dpt_id)+1 end from dawn_auth_department)
	--类别路径
	DECLARE @DptPath varchar(max)
	BEGIN
		if @addFlag=1
			set @DptPath=((select dpt_path from dawn_auth_department where dpt_id=@DptFather)+CONVERT(varchar(max),@DptId)+',')
		else
			set @DptPath=('0,'+CONVERT(varchar(max),@DptId)+',')
	END
	--开始执行
	insert into dawn_auth_department
	(
		[dpt_id],
		[dpt_name],
		[dpt_father],
		[dpt_path],
		[dpt_code],
		[dpt_ident],
		[dpt_rank],
		[dpt_click],
		[dpt_counts],
		[dpt_desc],
		[dpt_time]
	) 
	values
	(
		@DptId,
		@DptName,
		@DptFather,
		@DptPath,
		@DptCode,
		@DptIdent,
		@DptRank,
		@DptClick,
		@DptCounts,
		@DptDesc,
		@DptTime
	)
	return @@error
GO

/********************数据表【DawnAuthDepartment】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptId  系统编号
@DptName  部门名称
@DptCode  部门编码
@DptIdent  部门识别码
@DptRank  部门序列
@DptClick  部门点击
@DptCounts  部门统计
@DptDesc  部门描述
*/	
CREATE PROCEDURE [dbo].[DawnAuthDepartmentUpdate]
	@DptId int,
	@DptName nvarchar(50),
	@DptCode varchar(50),
	@DptIdent int,
	@DptRank int,
	@DptClick int,
	@DptCounts int,
	@DptDesc nvarchar(300)
AS
	SET NOCOUNT ON
	UPDATE [dawn_auth_department] SET
		[dpt_name] = @DptName,
		[dpt_code] = @DptCode,
		[dpt_ident] = @DptIdent,
		[dpt_rank] = @DptRank,
		[dpt_click] = @DptClick,
		[dpt_counts] = @DptCounts,
		[dpt_desc] = @DptDesc
	WHERE
		[dpt_id] = @DptId
	return @@error
GO

/********************更新数据表【DawnAuthDepartment】点击率********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentClick]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentClick]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthDepartmentClick]
	@DptId int
AS
	SET NOCOUNT ON
	UPDATE [dawn_auth_department] SET
		[dpt_click] = [dpt_click]+1
	WHERE
		[dpt_id] = @DptId
	return @@error
GO

/********************更新数据表【DawnAuthDepartment】数据统计********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentCounts]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentCounts]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptId  系统编号
@countFlag  统计标记
*/	
CREATE PROCEDURE [dbo].[DawnAuthDepartmentCounts]
	@DptId int,
	@countFlag tinyint
AS
	SET NOCOUNT ON
	BEGIN
		IF @countFlag=0
			UPDATE [dawn_auth_department] SET
				[dpt_counts] = [dpt_counts]+1
			WHERE
				[dpt_id] = @DptId
		ELSE IF @countFlag=1
			UPDATE [dawn_auth_department] SET
				[dpt_counts] = [dpt_counts]-1
			WHERE
				[dpt_id] = @DptId
	END	
	return @@error
GO

/********************数据表【DawnAuthDepartment】变更存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentChange]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentChange]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptId  系统编号
@DptFather  部门标识 
*/	
CREATE PROCEDURE [dbo].[DawnAuthDepartmentChange]
	@DptId int,
	@DptFather int
AS
	SET NOCOUNT ON
 	--类别路径
	DECLARE @DptPath varchar(max)
	BEGIN
		if @DptFather<>-1
			set @DptPath=((select dpt_path from dawn_auth_department where dpt_id=@DptFather)+CONVERT(varchar(max),@DptId)+',')
		else
			set @DptPath=('0,'+CONVERT(varchar(max),@DptId)+',')
	END
	--开始执行
	UPDATE [dawn_auth_department] SET
		[dpt_father] = @DptFather,
		[dpt_path] = @DptPath
	WHERE
		[dpt_id] = @DptId
	return @@error
GO

/********************数据表【DawnAuthDepartment】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptId  系统编号
@delFlag		删除标记
*/	
CREATE PROCEDURE [dbo].[DawnAuthDepartmentDelete]
	@DptId int,
	@delFlag bit
AS
	SET NOCOUNT ON
	BEGIN
		IF @delFlag=1			
			DELETE FROM [dawn_auth_department] WHERE charindex(','+CONVERT(varchar(max),@DptId)+',',dpt_path)>0
		ELSE
			DELETE FROM [dawn_auth_department] WHERE [dpt_id] = @DptId
	END
	return @@error
GO

/********************数据表【DawnAuthDepartment】条件删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentDeleteWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentDeleteWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 删除条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthDepartmentDeleteWhere]
	@where varchar(8000) = ' 1<>1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'delete from [dbo].[dawn_auth_department] where '
    exec ( @filter + @where )
	return @@error
GO

/********************查询数据表【DawnAuthDepartment】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthDepartmentSelectAll]
    @sortField varchar(100) = ' [dpt_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_department] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【DawnAuthDepartment】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptId 
*/	
CREATE PROCEDURE [dbo].[DawnAuthDepartmentSelect]
    @DptId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[dawn_auth_department] where [dpt_id] = @DptId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthDepartment】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthDepartmentSelectByParams]
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [dpt_id] DESC '
AS
	SET NOCOUNT ON
	if @where is null or @where=''    ----没有设置查询条件
	begin
		SET @where = ' 1=1 '
	end
    declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_department]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthDepartment】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[DawnAuthDepartmentCountByWhere]
    @where varchar(8000) = ' 1=1 ',
    @recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[dawn_auth_department] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【DawnAuthDepartment】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex 当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthDepartmentSelectByPagerParams]
    @pageSize int = 10,
    @pageIndex int = 1,
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [dpt_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[dawn_auth_department]
		where [dpt_id] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [dpt_id] FROM [dbo].[dawn_auth_department]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过编号查询数据表【DawnAuthDepartment】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentIsExistById]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentIsExistById]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptId 系统编号
*/
CREATE PROCEDURE [dbo].[DawnAuthDepartmentIsExistById]
    @DptId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_department]
		where [dpt_id] = @DptId
	RETURN @@Error
GO

/********************通过名称查询数据表【DawnAuthDepartment】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentIsExistByName]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentIsExistByName]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptName  部门名称
*/
CREATE PROCEDURE [dbo].[DawnAuthDepartmentIsExistByName]
    @DptName nvarchar(50)
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_department]
		where [dpt_name] = @DptName
	RETURN @@Error
GO

/********************通过点击查询数据表【DawnAuthDepartment】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentIsExistByClick]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentIsExistByClick]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptClick  部门点击
*/
CREATE PROCEDURE [dbo].[DawnAuthDepartmentIsExistByClick]
    @DptClick int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_department]
		where [dpt_click] = @DptClick
	RETURN @@Error
GO

/********************通过父标识查询数据表【DawnAuthDepartment】是否存在隶属记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentIsExistByChild]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentIsExistByChild]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptFather  部门标识
*/
CREATE PROCEDURE [dbo].[DawnAuthDepartmentIsExistByChild]
    @DptFather int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_department]
		where [dpt_father] = @DptFather
	RETURN @@Error
GO

/********************通过名称和父标识查询数据表【DawnAuthDepartment】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentIsExistByFather]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentIsExistByFather]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptName  部门名称
@DptFather  部门标识
*/
CREATE PROCEDURE [dbo].[DawnAuthDepartmentIsExistByFather]
    @DptName nvarchar(50),
    @DptFather int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_department]
		where [dpt_name] = @DptName and [dpt_father] = @DptFather
	RETURN @@Error
GO

/********************通过编码查询数据表【DawnAuthDepartment】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentIsExistByCode]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentIsExistByCode]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptCode  部门编码
*/
CREATE PROCEDURE [dbo].[DawnAuthDepartmentIsExistByCode]
    @DptCode varchar(50)
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_department]
		where [dpt_code] = @DptCode
	RETURN @@Error
GO

/********************通过识别码查询数据表【DawnAuthDepartment】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentIsExistByIdent]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentIsExistByIdent]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptIdent  部门识别码
*/
CREATE PROCEDURE [dbo].[DawnAuthDepartmentIsExistByIdent]
    @DptIdent int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_department]
		where [dpt_ident] = @DptIdent
	RETURN @@Error
GO

/********************通过编码和识别码查询数据表【DawnAuthDepartment】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentIsExistByCodeIdent]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentIsExistByCodeIdent]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptCode  部门编码
@DptIdent  部门识别码
*/
CREATE PROCEDURE [dbo].[DawnAuthDepartmentIsExistByCodeIdent]
    @DptCode varchar(50),
    @DptIdent int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_department]
		where [dpt_code] = @DptCode
        and [dpt_ident] = @DptIdent
	RETURN @@Error
GO

/********************通过名称和父标识及编码查询数据表【DawnAuthDepartment】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentIsExistByStrict]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentIsExistByStrict]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptName  部门名称
@DptFather  部门标识
@DptCode  部门编码
*/
CREATE PROCEDURE [dbo].[DawnAuthDepartmentIsExistByStrict]
    @DptName nvarchar(50),
    @DptFather int,
    @DptCode varchar(50)
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_department]
		where [dpt_name] = @DptName
        and [dpt_father] = @DptFather
        and [dpt_code] = @DptCode
	RETURN @@Error
GO

/********************通过名称和父标识、编码、识别码查询数据表【DawnAuthDepartment】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentIsExistByForbid]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentIsExistByForbid]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@DptName  部门名称
@DptFather  部门标识
@DptCode  部门编码
@DptIdent  部门识别码
*/
CREATE PROCEDURE [dbo].[DawnAuthDepartmentIsExistByForbid]
    @DptName nvarchar(50),
    @DptFather int,
    @DptCode varchar(50),
    @DptIdent int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_department]
		where [dpt_name] = @DptName
        and [dpt_father] = @DptFather
        and [dpt_code] = @DptCode
        and [dpt_ident] = @DptIdent
	RETURN @@Error
GO

/********************通过指定条件查询数据表【DawnAuthDepartment】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthDepartmentIsExistByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthDepartmentIsExistByWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthDepartmentIsExistByWhere]
    @where varchar(8000) = ' 1=1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'SELECT count(-1) FROM [dbo].[dawn_auth_department] where '
    exec ( @filter + @where )
    RETURN @@Error
GO


