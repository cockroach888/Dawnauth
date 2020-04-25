USE [DawnAuthority]
GO

/****** Object:  Table [dbo].[dawn_auth_user_status]    Script Date: 2013-02-28 13:12:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[dawn_auth_user_status](
	[map_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[stat_id] [int] NOT NULL,
	[map_time] [datetime] NOT NULL,
 CONSTRAINT [PK_dawn_auth_user_status] PRIMARY KEY CLUSTERED 
(
	[map_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[dawn_auth_user_status] ADD  CONSTRAINT [DF_dawn_auth_user_status_map_time]  DEFAULT (getdate()) FOR [map_time]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_status', @level2type=N'COLUMN',@level2name=N'map_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_status', @level2type=N'COLUMN',@level2name=N'user_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_status', @level2type=N'COLUMN',@level2name=N'stat_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_status', @level2type=N'COLUMN',@level2name=N'map_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态映射管理表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_status'
GO

