USE [SFDynamia]
GO

/****** Object:  StoredProcedure [dbo].[spr_AnnulateBillingData]    Script Date: 16/07/2014 02:12:29 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Juan Daniel Horta
-- Create date: 18-06-2014
-- Description:	Actualizacion marca de facturacion en dato de facturacion
-- =============================================
CREATE PROCEDURE [dbo].[spr_AnnulateBillingData]
	@quoteId as varchar(20),
	@billingDataId as varchar(20),
	@quoteStatus as varchar(2),
	@annulationDate as datetime,
	@SAPContract as varchar(20)

AS

	DECLARE @oquoteId varchar(20) = @quoteId
	DECLARE @obillingDataId varchar(20) = @billingDataId
	DECLARE @oquoteStatus varchar(2) = @quoteStatus
	DECLARE @oannulationDate datetime = @annulationDate
	DECLARE @oSAPContract varchar(20) = @SAPContract
		
BEGIN
	
	INSERT INTO [dbo].[Z_QuoteAnnulationData]
           ([quoteId]
           ,[billingDataId]
           ,[quoteStatus]
           ,[annulationDate]
           ,[SAPContract]
		   )           
     VALUES
           (@oquoteId
           ,@obillingDataId
           ,@oquoteStatus
           ,@oannulationDate
           ,@oSAPContract
           )

END




GO


