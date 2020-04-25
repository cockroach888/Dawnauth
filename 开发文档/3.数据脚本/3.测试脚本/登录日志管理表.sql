USE [DawnAuthority]
GO

/*----- 登录日志管理表
--------------------------------------------------*/
-- truncate table dawn_auth_user_login
-- select * from dawn_auth_user_login

declare @start int
declare @recordCount int
declare @rating int
set @start = 0
set @recordCount = 1000
set @rating = 1
while (@start < @recordCount)
begin
	insert into dawn_auth_user_login
	(
		user_id, log_time, log_ip, log_mac, log_computer, log_attach, log_count
	)
	values
	(
		1, getdate(), '127.0.0.1', 'unknown', 'unknown', '就 AAA 是测试测试测试测试测试动作用用吗！', @start
	),
	(
		2, getdate(), '127.0.0.1', 'unknown', 'unknown', '就 AAA 是测试测试测试测试测试动作用用吗！', @start
	),
	(
		3, getdate(), '127.0.0.1', 'unknown', 'unknown', '就 AAA 是测试测试测试测试测试动作用用吗！', @start
	)
	set @start = @start + 1
end
