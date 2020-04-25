USE [DawnAuthority]
GO

/******************************【管理员照片管理】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2013年02月11日 11:26:21】----
----------------------------------------------------------------------------------------------

/********************数据表【DawnAuthUserPic】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPicInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPicInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@PicId  系统编号
@UserId  用户编号 
@PicTime  添加时间 
@PicPhoto  用户照片 
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPicInsert]
	@PicId int output,
	@UserId int,
	@PicTime datetime,
	@PicPhoto image
AS
	SET NOCOUNT ON
	insert into dawn_auth_user_pic
	(
		[user_id],
		[pic_time],
		[pic_photo]
	) 
	values
	(
		@UserId,
		@PicTime,
		@PicPhoto
	)
	set @PicId=scope_identity()
	return @@error
GO

/********************数据表【DawnAuthUserPic】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPicUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPicUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@PicId  系统编号
@UserId  用户编号 
@PicTime  添加时间 
@PicPhoto  用户照片 
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPicUpdate]
	@PicId int,
	@UserId int,
	@PicTime datetime,
	@PicPhoto image
AS
 SET NOCOUNT ON
 UPDATE [dawn_auth_user_pic] SET
		[user_id] = @UserId,
		[pic_time] = @PicTime,
		[pic_photo] = @PicPhoto
 WHERE
		[pic_id] = @PicId
    return @@error
GO

/********************数据表【DawnAuthUserPic】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPicDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPicDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@PicId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPicDelete]
	@PicId int
AS
	SET NOCOUNT ON
	delete from [dawn_auth_user_pic] where  [pic_id] = @PicId
	return @@error
GO

/********************数据表【DawnAuthUserPic】条件删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPicDeleteWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPicDeleteWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 删除条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPicDeleteWhere]
	@where varchar(8000) = ' 1<>1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'delete from [dbo].[dawn_auth_user_pic] where '
    exec ( @filter + @where )
	return @@error
GO

/********************查询数据表【DawnAuthUserPic】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPicSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPicSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPicSelectAll]
    @sortField varchar(100) = ' [pic_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_user_pic] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【DawnAuthUserPic】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPicSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPicSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@PicId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPicSelect]
    @PicId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[dawn_auth_user_pic]
		where [pic_id] = @PicId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthUserPic】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPicSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPicSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPicSelectByParams]
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [pic_id] DESC '
AS
	SET NOCOUNT ON
    if @where is null or @where=''    ----没有设置查询条件
	begin
		SET @where = ' 1=1 '
	end
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[dawn_auth_user_pic]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【DawnAuthUserPic】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPicCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPicCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPicCountByWhere]
    @where varchar(8000) = ' 1=1 ',
    @recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[dawn_auth_user_pic] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【DawnAuthUserPic】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPicSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPicSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ǰ当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPicSelectByPagerParams]
    @pageSize int = 10,
    @pageIndex int = 1,
    @where varchar(8000) = ' 1=1 ',
    @sortField varchar(100) = ' [pic_id] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[dawn_auth_user_pic]
		where [pic_id] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [pic_id] FROM [dbo].[dawn_auth_user_pic]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【DawnAuthUserPic】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPicIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPicIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@PicId  系统编号
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPicIsExist]
    @PicId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[dawn_auth_user_pic]
		where [pic_id] = @PicId
	RETURN @@Error
GO

/********************通过指定条件查询数据表【DawnAuthUserPic】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[DawnAuthUserPicIsExistByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[DawnAuthUserPicIsExistByWhere]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
*/	
CREATE PROCEDURE [dbo].[DawnAuthUserPicIsExistByWhere]
    @where varchar(8000) = ' 1=1 '
AS
	SET NOCOUNT ON
    declare @filter varchar(8000)
    set @filter = 'SELECT count(-1) FROM [dbo].[dawn_auth_user_pic]	where '
    exec ( @filter + @where )
    RETURN @@Error
GO



