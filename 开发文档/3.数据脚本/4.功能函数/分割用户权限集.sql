USE [DawnAuthority]
GO

/******************************【分割用户权限字符串一】******************************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FunSplitAuthoritySingle]') AND OBJECTPROPERTY(id, N'IsTableFunction') = 1)
DROP FUNCTION [dbo].[FunSplitAuthoritySingle]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create FUNCTION [dbo].[FunSplitAuthoritySingle] 
(
	@authString varchar(3000)
)
returns @t table
(
	auth_string varchar(3000)
)
as
begin
	declare @tempAuthString varchar(200)
	declare @length int
	declare @spIndex int
	
	set @length = len(@authString)
	set @spIndex = charindex(';', @authString)
	
	while @spIndex > 0
	begin
		set @tempAuthString = substring(@authString, 1, @spIndex - 1)
		insert into @t(auth_string) values(@tempAuthString)
		set @authString = substring(@authString, @spIndex + 1, @length - @spIndex - 1)
		set @spIndex = charindex(';', @authString)
	end
	insert into @t(auth_string) values(@authString)

	return
end

GO