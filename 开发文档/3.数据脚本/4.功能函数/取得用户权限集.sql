USE [DawnAuthority]
GO

/******************************【取得用户角色权限集成字符串】******************************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FunUserAuthority]') AND OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
DROP FUNCTION [dbo].[FunUserAuthority]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create function [dbo].[FunUserAuthority] 
(
	@userId int
)
returns varchar(3000)
as
begin
	declare @t varchar(3000)
	declare @moduleCode varchar(50)
	set @t = ''
	declare cur cursor for
		select module_code from dbo.FunUserModule(@userId)
		group by module_code
	open cur
		fetch next from cur into @moduleCode
		while @@fetch_status = 0
		begin
			set @t = @t + ';' + @moduleCode + '|';
			select @t = @t + cast(auth as varchar)
			from 
			(
				select function_mark,max(function_auth) as auth
				from dbo.FunUserModule(@userId)
				where module_code = @moduleCode
				group by function_mark
			) t
			order by function_mark
			fetch next from cur into @moduleCode
		end
	close cur
	deallocate cur

	return @t
end


GO