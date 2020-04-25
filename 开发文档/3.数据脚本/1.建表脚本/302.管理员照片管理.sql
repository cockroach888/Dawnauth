USE [DawnAuthority]
GO

/****** Object:  Table [dbo].[dawn_auth_user_pic]    Script Date: 2013-02-10 23:04:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[dawn_auth_user_pic](
	[pic_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[pic_time] [datetime] NOT NULL,
	[pic_photo] [image] NOT NULL,
 CONSTRAINT [PK_dawn_auth_user_pic] PRIMARY KEY CLUSTERED 
(
	[pic_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[dawn_auth_user_pic] ADD  CONSTRAINT [DF_dawn_auth_user_pic_pic_time]  DEFAULT (getdate()) FOR [pic_time]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_pic', @level2type=N'COLUMN',@level2name=N'pic_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_pic', @level2type=N'COLUMN',@level2name=N'user_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_pic', @level2type=N'COLUMN',@level2name=N'pic_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户照片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_pic', @level2type=N'COLUMN',@level2name=N'pic_photo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员照片管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dawn_auth_user_pic'
GO

