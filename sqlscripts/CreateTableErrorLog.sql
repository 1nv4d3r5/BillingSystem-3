USE [SFDynamia]
GO

/****** Object:  Table [dbo].[Z_ErrorLog]    Script Date: 16/07/2014 02:10:33 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Z_ErrorLog](
	[date] [datetime] NULL,
	[message] [varchar](300) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


