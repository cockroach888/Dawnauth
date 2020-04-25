USE [DawnAuthority]
GO

/******************************【取得用户角色模块数据集合】******************************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FunUserModule]') AND OBJECTPROPERTY(id, N'IsTableFunction') = 1)
DROP FUNCTION [dbo].[FunUserModule]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create function [dbo].[FunUserModule] 
(
	@userId int
)
returns @t table
(
	module_code varchar(50)
	,function_mark int
	,function_auth tinyint
)
as
begin
	declare @authString varchar(3000)
	declare @tmp table (auth_string varchar(3000))
	--根据用户角色获取所有单模块的权限字符串
	declare cur cursor for
		select role_authority from dawn_auth_role
		where role_id in (select role_id from dawn_auth_user_role where [user_id] = @userId)
	open cur
		fetch next from cur into @authString
		while @@fetch_status = 0
		begin
			insert into @tmp select * from dbo.FunSplitAuthoritySingle(@authString)
			fetch next from cur into @authString
		end
	close cur
	deallocate cur

	--根据单模块的权限字符串获取模块权限表
	declare cur cursor for
		select auth_string from @tmp
	open cur
		fetch next from cur into @authString
		while @@fetch_status = 0
		begin
			insert into @t select * from dbo.FunSplitAuthorityMany(@authString)
			fetch next from cur into @authString
		end
	close cur
	deallocate cur

	return
end






GO