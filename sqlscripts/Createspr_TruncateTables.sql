USE [SFDynamia]
GO

/****** Object:  StoredProcedure [dbo].[spr_TruncateTables]    Script Date: 16/07/2014 02:17:00 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Juan Daniel Horta
-- Create date: 07-07-2014
-- Description:	truncate billingdataupdate table
-- =============================================
CREATE PROCEDURE [dbo].[spr_TruncateTables] 
	
	@table as varchar(50)

AS

	DECLARE @otable varchar(50) = @table

BEGIN
	if @otable = 'UDB'
	TRUNCATE TABLE [dbo].[Z_BillingDataUpdateInfo]
	else if @otable = 'AQ'
	TRUNCATE TABLE [dbo].[Z_QuoteAnnulationData]
END

GO


