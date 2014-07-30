USE [SFDynamia]
GO

/****** Object:  Table [dbo].[Z_BillingDataUpdateInfo]    Script Date: 16/07/2014 02:09:39 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Z_BillingDataUpdateInfo](
	[quoteId] [varchar](20) NOT NULL,
	[assetId] [varchar](20) NULL,
	[billingDataId] [varchar](20) NULL,
	[quoteStatus] [varchar](2) NULL,
	[billingDate] [datetime] NULL,
	[billingCheck] [int] NULL,
	[SAPContract] [varchar](20) NULL,
	[finalFirstQuoteDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[quoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


