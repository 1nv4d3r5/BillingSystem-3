USE [SFDynamia]
GO

/****** Object:  Table [dbo].[Z_logFactSFSAPsoldig]    Script Date: 16/07/2014 02:11:00 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Z_logFactSFSAPsoldig](
	[partner] [varchar](10) NULL,
	[DOC_TYPE] [varchar](4) NULL,
	[SALES_ORG] [varchar](4) NULL,
	[DISTR_CHAN] [varchar](2) NULL,
	[DIVISION] [varchar](2) NULL,
	[PO_SUPPLEM] [varchar](5) NULL,
	[REF_1] [nvarchar](30) NULL,
	[SALES_DIST1] [varchar](5) NULL,
	[ORD_REASON] [varchar](3) NULL,
	[PURCH_NO_C1] [nvarchar](30) NULL,
	[purch_no_s_] [varchar](4) NULL,
	[CURRENCY1] [varchar](3) NULL,
	[pmnttrms] [varchar](4) NULL,
	[COND_TYPE1] [varchar](4) NULL,
	[COND_VALUE1] [varchar](10) NULL,
	[CURRENCY2] [varchar](3) NULL,
	[CONDVALUE1] [varchar](10) NULL,
	[COND_TYPE2] [varchar](4) NULL,
	[CONDVALUE2] [varchar](2) NULL,
	[COND_VALUE2] [varchar](10) NULL,
	[con_st_dat] [datetime] NULL,
	[con_en_dat] [datetime] NULL,
	[MATERIAL] [nvarchar](16) NULL,
	[BILL_DATE] [datetime] NULL,
	[TARGET_QTY] [varchar](1) NULL,
	[TARGET_QU] [varchar](2) NULL,
	[PRC_GROUP4] [varchar](10) NULL,
	[PURCH_NO_C2] [nvarchar](40) NULL,
	[SALES_DIST2] [varchar](80) NULL,
	[PRICE_LIST] [varchar](2) NULL,
	[PYMT_METH] [varchar](1) NULL,
	[SALES_UNIT] [varchar](2) NULL,
	[PARTN_ROLE1] [varchar](2) NULL,
	[PARTN_NUMB1] [varchar](10) NULL,
	[ADDR_LINK1] [varchar](10) NULL,
	[PARTN_ROLE2] [varchar](2) NULL,
	[PARTN_NUMB2] [varchar](10) NULL,
	[ADDR_LINK2] [varchar](10) NULL,
	[PARTN_ROLE3] [varchar](2) NULL,
	[PARTN_NUMB3] [nvarchar](255) NULL,
	[PARTN_ROLE4] [varchar](2) NULL,
	[PARTN_NUMB4] [varchar](3) NULL,
	[ADDR_NO] [varchar](10) NULL,
	[CITY] [varchar](6) NULL,
	[POSTL_COD1] [varchar](5) NULL,
	[STREET] [nvarchar](255) NULL,
	[COUNTRY] [varchar](2) NULL,
	[LANGU] [varchar](1) NULL,
	[REGION] [varchar](2) NULL,
	[NIE__C] [varchar](20) NULL,
	[idOportunidad] [nvarchar](18) NULL,
	[idCuenta] [nvarchar](18) NULL,
	[idActivo] [nvarchar](18) NULL,
	[idProductoCotizacion] [nvarchar](18) NULL,
	[idCotizacion] [nvarchar](18) NULL,
	[FACTURADO__C] [varchar](10) NULL,
	[id] [nvarchar](18) NULL,
	[cuotaname] [nvarchar](80) NULL,
	[FactEmail] [nvarchar](80) NULL,
	[FactTel] [nvarchar](40) NULL,
	[FactDir] [nvarchar](255) NULL,
	[FactFirstQuote] [datetime] NULL,
	[idCuotaFacturacion] [nvarchar](18) NULL,
	[contratoSAP] [varchar](18) NULL,
	[fechaEnvioFacturacion] [datetime] NULL,
	[fechaCorteFacturacion] [datetime] NULL,
	[quoteStatus] [varchar](5) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


