USE [DawnAuthority]
GO

/****** Object:  Table [dbo].[dawn_auth_user_power]    Script Date: 2013-04-05 23:37:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dawn_auth_user_power](
	[map_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[map_time] [datetime] NOT NULL,
	[map_module] [int] NOT NULL,
	[map_function] [varchar](max) NOT NULL,
 CONSTRAINT [PK_dawn_auth_user_power] PRIMARY KEY CLUSTERED 
(
	[map_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[dawn_auth_user_power] ADD  CONSTRAINT [DF_dawn_auth_user_power_map_time]  DEFAULT (getdate()) FOR [map_time]
GO

ALTER TABLE [dbo].[dawn_auth_user_power] ADD  CONSTRAINT [DF_dawn_auth_user_power_map_function]  DEFAULT ('0,') FOR [map_function]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_power', @level2type=N'COLUMN',@level2name=N'map_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_power', @level2type=N'COLUMN',@level2name=N'user_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_power', @level2type=N'COLUMN',@level2name=N'map_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块识别码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_power', @level2type=N'COLUMN',@level2name=N'map_module'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能识别码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_power', @level2type=N'COLUMN',@level2name=N'map_function'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限映射管理表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_power'
GO

