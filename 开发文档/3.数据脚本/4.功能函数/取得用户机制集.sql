USE [DawnAuthority]
GO

/******************************【取得用户状态机制集成字符串】******************************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FunUserStatus]') AND OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
DROP FUNCTION [dbo].[FunUserStatus]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create function [dbo].[FunUserStatus] 
(
	@userId int
)
returns varchar(max)
as
begin
	declare @mdlId int
	declare @mdlCode varchar(50)
	declare @result varchar(max)
	declare curModule cursor for
	select distinct mdl_id,mdl_code from dawn_auth_module
	where mdl_id in (select mdl_id from dawn_auth_status where stat_id in (
	select stat_id from dawn_auth_user_status where [user_id] = @userId))
	open curModule
		fetch next from curModule into @mdlId,@mdlCode
		set @result = ''
		while @@fetch_status = 0
		begin
			set @result = @result + ';' + @mdlCode + '|,'
			select @result = @result + cast(das.stat_mark as varchar(50)) + ',' from dawn_auth_status das
			inner join dawn_auth_user_status daus
			on das.stat_id = daus.stat_id
			where das.mdl_id = @mdlId
			and daus.user_id = @userId
			order by das.stat_mark
			fetch next from curModule into @mdlId,@mdlCode
		end
	close curModule
	deallocate curModule
	return @result
end


GO