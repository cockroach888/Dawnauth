USE [DawnAuthority]
GO

/****** Object:  Table [dbo].[dawn_auth_user_extent]    Script Date: 2013-11-22 19:00:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dawn_auth_user_extent](
	[ext_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[ext_time] [datetime] NOT NULL,
	[ext_code] [varchar](100) NOT NULL,
	[ext_mark] [varchar](100) NOT NULL,
 CONSTRAINT [PK_dawn_auth_user_extent] PRIMARY KEY CLUSTERED 
(
	[ext_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[dawn_auth_user_extent] ADD  CONSTRAINT [DF_dawn_auth_user_extent_ext_time]  DEFAULT (getdate()) FOR [ext_time]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_extent', @level2type=N'COLUMN',@level2name=N'ext_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_extent', @level2type=N'COLUMN',@level2name=N'user_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_extent', @level2type=N'COLUMN',@level2name=N'ext_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扩展编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_extent', @level2type=N'COLUMN',@level2name=N'ext_code'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扩展标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_extent', @level2type=N'COLUMN',@level2name=N'ext_mark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扩展映射管理表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_extent'
GO


