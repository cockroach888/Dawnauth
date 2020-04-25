
use [DawnAuthority]
go

 insert into dawn_auth_department
(
	dpt_id, dpt_name, dpt_father, dpt_path, dpt_code, dpt_ident, dpt_rank, dpt_click, dpt_counts, dpt_desc, dpt_time
)
values
(
	(select case when max(dpt_id) is null then 0 else max(dpt_id) end from dawn_auth_department)+1, '系统默认', -1, '0,1,', 'Default', 3389, 1, 0, 0, '系统默认部门', getdate()
)
