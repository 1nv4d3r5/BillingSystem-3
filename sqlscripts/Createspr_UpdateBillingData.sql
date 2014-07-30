USE [SFDynamia]
GO

/****** Object:  StoredProcedure [dbo].[spr_UpdateBillingData]    Script Date: 16/07/2014 02:18:24 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Juan Daniel Horta
-- Create date: 18-06-2014
-- Description:	Actualizacion marca de facturacion en dato de facturacion
-- =============================================
CREATE PROCEDURE [dbo].[spr_UpdateBillingData]
	@quoteId as varchar(20),
	@assetId as varchar(20),
	@billingDataId as varchar(20),
	@quoteStatus as varchar(2),
	@billingDate as datetime,
	@billingCheck as int,
	@SAPContract as varchar(20),
	@finalFirstQuoteDate as datetime	

AS

	DECLARE @oquoteId varchar(20) = @quoteId
	DECLARE @oassetId varchar(20) = @assetId
	DECLARE @obillingDataId varchar(20) = @billingDataId
	DECLARE @oquoteStatus varchar(2) = @quoteStatus
	DECLARE @obillingDate datetime = @billingDate
	DECLARE @obillingCheck int = @billingCheck
	DECLARE @oSAPContract varchar(20) = @SAPContract
	DECLARE @ofinalFirstQuoteDate datetime = @finalFirstQuoteDate
	
BEGIN
	
	INSERT INTO [dbo].[Z_BillingDataUpdateInfo]
           ([quoteId]
           ,[assetId]
           ,[billingDataId]
           ,[quoteStatus]
           ,[billingDate]
           ,[billingCheck]
           ,[SAPContract]
           ,[finalFirstQuoteDate])
     VALUES
           (@oquoteId
           ,@oassetId
           ,@obillingDataId
           ,@oquoteStatus
           ,@obillingDate
           ,@obillingCheck
           ,@oSAPContract
           ,@ofinalFirstQuoteDate
		   )

END




GO


