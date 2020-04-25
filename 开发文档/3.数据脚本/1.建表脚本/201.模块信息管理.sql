USE [DawnAuthority]
GO

/****** Object:  Table [dbo].[dawn_auth_module]    Script Date: 2013-04-05 23:37:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dawn_auth_module](
	[mdl_id] [int] NOT NULL,
	[mdl_name] [nvarchar](50) NOT NULL,
	[mdl_father] [int] NOT NULL,
	[mdl_path] [varchar](max) NOT NULL,
	[mdl_code] [varchar](50) NULL,
	[mdl_ident] [int] NULL,
	[mdl_rank] [int] NULL,
	[mdl_click] [int] NULL,
	[mdl_counts] [int] NULL,
	[mdl_desc] [nvarchar](300) NULL,
	[mdl_time] [datetime] NOT NULL,
 CONSTRAINT [PK_dawn_auth_module] PRIMARY KEY CLUSTERED 
(
	[mdl_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[dawn_auth_module] ADD  CONSTRAINT [DF_dawn_auth_module_mdl_rank]  DEFAULT ((255)) FOR [mdl_rank]
GO

ALTER TABLE [dbo].[dawn_auth_module] ADD  CONSTRAINT [DF_dawn_auth_module_mdl_click]  DEFAULT ((0)) FOR [mdl_click]
GO

ALTER TABLE [dbo].[dawn_auth_module] ADD  CONSTRAINT [DF_dawn_auth_module_mdl_counts]  DEFAULT ((0)) FOR [mdl_counts]
GO

ALTER TABLE [dbo].[dawn_auth_module] ADD  CONSTRAINT [DF_dawn_auth_module_mdl_time]  DEFAULT (getdate()) FOR [mdl_time]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_module', @level2type=N'COLUMN',@level2name=N'mdl_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_module', @level2type=N'COLUMN',@level2name=N'mdl_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_module', @level2type=N'COLUMN',@level2name=N'mdl_father'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_module', @level2type=N'COLUMN',@level2name=N'mdl_path'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_module', @level2type=N'COLUMN',@level2name=N'mdl_code'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块识别码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_module', @level2type=N'COLUMN',@level2name=N'mdl_ident'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块序列' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_module', @level2type=N'COLUMN',@level2name=N'mdl_rank'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块点击' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_module', @level2type=N'COLUMN',@level2name=N'mdl_click'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块统计' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_module', @level2type=N'COLUMN',@level2name=N'mdl_counts'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_module', @level2type=N'COLUMN',@level2name=N'mdl_desc'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_module', @level2type=N'COLUMN',@level2name=N'mdl_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块信息管理表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_module'
GO

