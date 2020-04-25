USE [DawnAuthority]
GO

/****** Object:  Table [dbo].[dawn_auth_logs]    Script Date: 2013-02-10 22:49:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dawn_auth_logs](
	[log_id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[log_time] [datetime] NOT NULL,
	[log_rating] [tinyint] NOT NULL,
	[log_table] [varchar](200) NOT NULL,
	[log_action] [nvarchar](max) NOT NULL,
	[log_memo] [nvarchar](max) NULL,
	[log_uid] [int] NOT NULL,
	[log_uname] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_dawn_auth_logs] PRIMARY KEY CLUSTERED 
(
	[log_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[dawn_auth_logs] ADD  CONSTRAINT [DF_dawn_auth_logs_log_id]  DEFAULT (newid()) FOR [log_id]
GO

ALTER TABLE [dbo].[dawn_auth_logs] ADD  CONSTRAINT [DF_dawn_auth_logs_log_time]  DEFAULT (getdate()) FOR [log_time]
GO

ALTER TABLE [dbo].[dawn_auth_logs] ADD  CONSTRAINT [DF_dawn_auth_logs_log_rating]  DEFAULT ((1)) FOR [log_rating]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_logs', @level2type=N'COLUMN',@level2name=N'log_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_logs', @level2type=N'COLUMN',@level2name=N'log_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录级别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_logs', @level2type=N'COLUMN',@level2name=N'log_rating'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录表名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_logs', @level2type=N'COLUMN',@level2name=N'log_table'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录动作' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_logs', @level2type=N'COLUMN',@level2name=N'log_action'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_logs', @level2type=N'COLUMN',@level2name=N'log_memo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_logs', @level2type=N'COLUMN',@level2name=N'log_uid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_logs', @level2type=N'COLUMN',@level2name=N'log_uname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志信息管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_logs'
GO

