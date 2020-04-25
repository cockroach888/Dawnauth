USE [DawnAuthority]
GO

/****** Object:  Table [dbo].[dawn_auth_error]    Script Date: 2013-02-10 22:46:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dawn_auth_error](
	[err_id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[err_time] [datetime] NOT NULL,
	[err_address] [varchar](2000) NOT NULL,
	[err_message] [varchar](4000) NOT NULL,
	[err_target] [varchar](max) NOT NULL,
	[err_trace] [nvarchar](max) NOT NULL,
	[err_source] [nvarchar](max) NOT NULL,
	[err_ip] [varchar](200) NOT NULL,
	[err_uid] [int] NOT NULL,
	[err_uname] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_dawn_auth_error] PRIMARY KEY CLUSTERED 
(
	[err_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[dawn_auth_error] ADD  CONSTRAINT [DF_dawn_auth_error_err_id]  DEFAULT (newid()) FOR [err_id]
GO

ALTER TABLE [dbo].[dawn_auth_error] ADD  CONSTRAINT [DF_dawn_auth_error_err_time]  DEFAULT (getdate()) FOR [err_time]
GO

ALTER TABLE [dbo].[dawn_auth_error] ADD  CONSTRAINT [DF_dawn_auth_error_err_ip]  DEFAULT ('127.0.0.1') FOR [err_ip]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_error', @level2type=N'COLUMN',@level2name=N'err_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_error', @level2type=N'COLUMN',@level2name=N'err_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_error', @level2type=N'COLUMN',@level2name=N'err_address'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误消息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_error', @level2type=N'COLUMN',@level2name=N'err_message'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误目标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_error', @level2type=N'COLUMN',@level2name=N'err_target'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误跟踪' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_error', @level2type=N'COLUMN',@level2name=N'err_trace'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_error', @level2type=N'COLUMN',@level2name=N'err_source'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户IP码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_error', @level2type=N'COLUMN',@level2name=N'err_ip'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_error', @level2type=N'COLUMN',@level2name=N'err_uid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_error', @level2type=N'COLUMN',@level2name=N'err_uname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误信息管理表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_error'
GO

