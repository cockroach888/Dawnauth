USE [DawnAuthority]
GO

/****** Object:  Table [dbo].[dawn_auth_user_login]    Script Date: 2013-02-10 23:08:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dawn_auth_user_login](
	[log_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[log_time] [datetime] NOT NULL,
	[log_ip] [varchar](200) NOT NULL,
	[log_mac] [varchar](100) NULL,
	[log_computer] [varchar](100) NULL,
	[log_attach] [nvarchar](max) NULL,
	[log_count] [int] NOT NULL,
	[log_field_one] [int] NULL,
	[log_field_two] [tinyint] NULL,
	[log_field_three] [varchar](max) NULL,
 CONSTRAINT [PK_dawn_auth_user_login] PRIMARY KEY CLUSTERED 
(
	[log_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[dawn_auth_user_login] ADD  CONSTRAINT [DF_dawn_auth_user_login_log_time]  DEFAULT (getdate()) FOR [log_time]
GO

ALTER TABLE [dbo].[dawn_auth_user_login] ADD  CONSTRAINT [DF_dawn_auth_user_login_log_ip]  DEFAULT ('127.0.0.1') FOR [log_ip]
GO

ALTER TABLE [dbo].[dawn_auth_user_login] ADD  CONSTRAINT [DF_dawn_auth_user_login_log_count]  DEFAULT ((0)) FOR [log_count]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_login', @level2type=N'COLUMN',@level2name=N'log_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_login', @level2type=N'COLUMN',@level2name=N'user_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_login', @level2type=N'COLUMN',@level2name=N'log_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_login', @level2type=N'COLUMN',@level2name=N'log_ip'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MAC地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_login', @level2type=N'COLUMN',@level2name=N'log_mac'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计算机名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_login', @level2type=N'COLUMN',@level2name=N'log_computer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附加信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_login', @level2type=N'COLUMN',@level2name=N'log_attach'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_login', @level2type=N'COLUMN',@level2name=N'log_count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段一' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_login', @level2type=N'COLUMN',@level2name=N'log_field_one'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段二' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_login', @level2type=N'COLUMN',@level2name=N'log_field_two'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备用字段三' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_login', @level2type=N'COLUMN',@level2name=N'log_field_three'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录日志管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_login'
GO

