USE [DawnAuthority]
GO

/*----- 错误信息管理表
--------------------------------------------------*/
-- truncate table dawn_auth_error
-- select * from dawn_auth_error order by err_time desc

declare @start int
declare @recordCount int
declare @rating int
set @start = 0
set @recordCount = 1000
while (@start < @recordCount)
begin
	insert into dawn_auth_error
	(
		err_time, err_address,
		err_message,
		err_target,
		err_trace,
		err_source,
		err_ip, err_uid, err_uname
	)
	values
	(
		getdate(), '/Auth/Desktop',
		'就 AAA 是测试测试测试测试测试动作用用吗！',
		'就 BBB 是测试测试测试测试测试动作用用吗！',
		'就 CCC 是测试测试测试测试测试动作用用吗！',
		'就 DDD 是测试测试测试测试测试动作用用吗！',
		'127.0.0.1',1, 'test01'
	)
	set @start = @start + 1
end
