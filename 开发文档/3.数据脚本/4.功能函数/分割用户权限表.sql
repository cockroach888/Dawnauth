USE [DawnAuthority]
GO

/******************************【分割用户权限字符串二】******************************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FunSplitAuthorityMany]') AND OBJECTPROPERTY(id, N'IsTableFunction') = 1)
DROP FUNCTION [dbo].[FunSplitAuthorityMany]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create FUNCTION [dbo].[FunSplitAuthorityMany] 
(
	@authString varchar(3000)
)
returns @t table
(
	module_code varchar(50)
	,function_mark int identity(1,1)
	,function_auth tinyint
)
as
begin
	declare @moduleCode varchar(50)
	declare @authStr varchar(3000)
	declare @ml int
	declare @tl int
	declare @al int
	declare @l int
	set @tl = len(@authString)
	set @ml = charindex('|', @authString)
	set @al = @tl - @ml
	set @moduleCode = substring(@authString, 0, @ml)
	set @authStr = substring(@authString, @ml+1, @al)

	set @l = @al
	while @l > 0
	begin
		insert into @t
		(
			module_code
			,function_auth
		) values
		(
			@moduleCode
			,substring(@authStr, @al-@l+1, 1)
		)
		set @l = @l - 1
	end

	return
end

GO
