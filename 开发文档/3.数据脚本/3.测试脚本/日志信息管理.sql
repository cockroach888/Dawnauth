USE [DawnAuthority]
GO

/*----- 系统日志信息表
--------------------------------------------------*/
-- truncate table dawn_auth_logs
-- select * from dawn_auth_logs order by log_rating desc

declare @start int
declare @recordCount int
declare @rating int
set @start = 0
set @recordCount = 1000
set @rating = 1
while (@start < @recordCount)
begin
	insert into dawn_auth_logs
	(
		log_time, log_rating, log_table, log_action, log_memo, log_uid, log_uname
	)
	values
	(
		getdate(), @rating, 'dawn_auth_user', '就 AAA 是测试测试测试测试测试动作用用吗！', '管理员信息管理', 1, 'dzssystem'
	),
	(
		getdate(), @rating, 'dawn_auth_user', '就 AAA 是测试测试测试测试测试动作用用吗！', '管理员信息管理', 2, 'dzsyewu'
	),
	(
		getdate(), @rating, 'dawn_auth_user', '就 AAA 是测试测试测试测试测试动作用用吗！', '管理员信息管理', 3, 'dawnxz'
	),
	(
		getdate(), @rating, 'dawn_auth_user_pic', '就 BBB 是测试测试测试测试测试动作用用吗！', '管理员照片管理', 1, 'dzssystem'
	),
	(
		getdate(), @rating, 'dawn_auth_user_pic', '就 BBB 是测试测试测试测试测试动作用用吗！', '管理员照片管理', 2, 'dzsyewu'
	),
	(
		getdate(), @rating, 'dawn_auth_user_pic', '就 BBB 是测试测试测试测试测试动作用用吗！', '管理员照片管理', 3, 'dawnxz'
	),
	(
		getdate(), @rating, 'dawn_auth_user_login', '就 CCC 是测试测试测试测试测试动作用用吗！', '登录日志管理', 1, 'dzssystem'
	),
	(
		getdate(), @rating, 'dawn_auth_user_login', '就 CCC 是测试测试测试测试测试动作用用吗！', '登录日志管理', 2, 'dzsyewu'
	),
	(
		getdate(), @rating, 'dawn_auth_user_login', '就 CCC 是测试测试测试测试测试动作用用吗！', '登录日志管理', 3, 'dawnxz'
	)
	set @start = @start + 1
	set @rating = @rating + 1
	if @rating > 255 set @rating = 1
end
