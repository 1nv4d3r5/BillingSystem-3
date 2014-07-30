USE [SFDynamia]
GO

/****** Object:  Table [dbo].[Z_BillingDataFailed]    Script Date: 16/07/2014 02:08:00 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Z_BillingDataFailed](
	[id] [varchar](20) NOT NULL,
	[failureCheck] [int] NULL,
	[failureMessage] [varchar](300) NULL,
	[failureDate] [date] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


