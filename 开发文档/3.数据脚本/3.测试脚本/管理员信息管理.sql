USE [DawnAuthority]
GO

/*----- 管理员信息管理表
--------------------------------------------------*/
-- truncate table dawn_auth_user
-- select * from dawn_auth_user
-- 52CB4D6B43FA16991CFBF704ADC22809
-- dawn123456

insert into dawn_auth_user
(
	dpt_id, user_status, user_grade, user_surname, user_name, user_pwd, user_mobile, user_email, user_desc
)
values
--(
--	1, 1, 1, '业务管理员', 'dzsyewu', '52CB4D6B43FA16991CFBF704ADC22809', '13800000000', 'dzsyewu@dzs.org.cn' , '业务管理系统专业人员[勿删除]'
--),
--(
--	1, 1, 2, '系统管理员', 'dzssystem', '52CB4D6B43FA16991CFBF704ADC22809', '13800000000', 'dzssystem@dzs.org.cn' , '权限管理系统专业人员[勿删除]'
--),
(
	1, 1, 3, '晨曦小竹', 'dawnxz', '52CB4D6B43FA16991CFBF704ADC22809', '13811011045', 'roach888@126.com' , '开发人员留备专用账号[勿删除] '
)
