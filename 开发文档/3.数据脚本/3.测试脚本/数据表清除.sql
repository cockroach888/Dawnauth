use [DawnAuthority]
go

truncate table [dbo].[dawn_auth_error]
truncate table [dbo].[dawn_auth_logs]
truncate table [dbo].[dawn_auth_module]
truncate table [dbo].[dawn_auth_function]
truncate table [dbo].[dawn_auth_role]
truncate table [dbo].[dawn_auth_status]
truncate table [dbo].[dawn_auth_department]
truncate table [dbo].[dawn_auth_user]
truncate table [dbo].[dawn_auth_user_login]
truncate table [dbo].[dawn_auth_user_pic]
truncate table [dbo].[dawn_auth_user_role]
truncate table [dbo].[dawn_auth_user_status]
truncate table [dbo].[dawn_auth_user_power]


/*

update [dbo].[dawn_auth_role] set [role_authority] = null

select * from [dbo].[dawn_auth_module] where mdl_father = -1

select * from [dbo].[dawn_auth_module] where charindex('0,3,',mdl_path)>0

select * from [dbo].[dawn_auth_module] where charindex('0,4,',mdl_path)>0

select * from [dbo].[dawn_auth_module] where charindex('0,5,',mdl_path)>0

select * from [dbo].[dawn_auth_module] where charindex('0,6,',mdl_path)>0

*/


--独立模块功能专用
--本模块仅供添加独立的模块功能时使用


