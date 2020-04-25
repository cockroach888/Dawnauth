USE [DawnAuthority]
GO

/****** Object:  Table [dbo].[dawn_auth_extent]    Script Date: 2013-11-22 19:20:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dawn_auth_extent](
	[exte_id] [int] IDENTITY(1,1) NOT NULL,
	[exte_time] [datetime] NOT NULL,
	[exte_status] [tinyint] NOT NULL,
	[exte_code] [varchar](100) NOT NULL,
	[exte_code_name] [nvarchar](200) NOT NULL,
	[exte_mark] [varchar](100) NOT NULL,
	[exte_mark_name] [nvarchar](200) NOT NULL,
	[exte_memo] [nvarchar](500) NULL,
	[exte_field_one] [int] NULL,
	[exte_field_two] [tinyint] NULL,
	[exte_field_three] [varchar](2000) NULL,
 CONSTRAINT [PK_dawn_auth_extent] PRIMARY KEY CLUSTERED 
(
	[exte_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[dawn_auth_extent] ADD  CONSTRAINT [DF_dawn_auth_extent_exte_time]  DEFAULT (getdate()) FOR [exte_time]
GO

ALTER TABLE [dbo].[dawn_auth_extent] ADD  CONSTRAINT [DF_dawn_auth_extent_exte_status]  DEFAULT ((1)) FOR [exte_status]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限扩展管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_extent'
GO


