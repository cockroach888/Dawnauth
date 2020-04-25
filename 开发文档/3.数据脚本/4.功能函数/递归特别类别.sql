USE [DawnAuthority]
GO



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_recursion_catalog]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_recursion_catalog]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_recursion_catalog_name]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_recursion_catalog_name]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_recursion_catalog_first]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_recursion_catalog_first]
GO





USE [DawnAuthority]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/* 递归某类别所有的父项 */
create function [dbo].[fn_recursion_catalog](@catId int)
returns @tb
table(id int)
as
begin 
	insert into @tb select @catId select @catId = mdl_father
	from dawn_auth_module where mdl_id = @catId and mdl_id is not null
	while @@ROWCOUNT > 0
	begin
		IF @catId <> -1
		BEGIN
			insert into @tb select @catId select @catId = mdl_father
			from dawn_auth_module where mdl_id = @catId and mdl_id is not null
		END		
	end
  return
end
GO


/* 递归某类别所有的父项编号和名称 */
create function [dbo].[fn_recursion_catalog_name](@catId INT)
returns @tb
table(c_id INT,c_name VARCHAR(200))
as
BEGIN
	insert into @tb SELECT id,(SELECT mdl_name FROM dawn_auth_module WHERE mdl_id=id) AS cname FROM fn_recursion_catalog(@catId)	
	return
end
GO


/* 查找某类别根类别名称 */
create function [dbo].[fn_recursion_catalog_first](@catId INT)
returns nvarchar(50)
as
begin
	return (select ltrim(rtrim(mdl_name)) from dawn_auth_module where mdl_id = (select min(c_id) from dbo.fn_recursion_catalog_name(@catId)))
end
go