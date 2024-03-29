USE [SFDynamia]
GO
/****** Object:  StoredProcedure [dbo].[spr_UpdateBillingDataFailed]    Script Date: 28/07/2014 11:34:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Juan Daniel Horta
-- Create date: 18-06-2014
-- Description:	Actualizacion marca de facturacion en dato de facturacion
-- =============================================
create PROCEDURE [dbo].[spr_UpdateBillingDataFailed]
	@id as varchar(12),
	@failureCheck as int,
	@failureMessage as varchar(200),
	@failureDate as datetime

AS

	DECLARE @oId as varchar(12) = @id
	DECLARE @oFailureCheck as int = @failureCheck
	DECLARE @ofailureMessage as varchar(200) = @failureMessage
	DECLARE @ofailureDate as datetime = @failureDate

BEGIN
	
	INSERT INTO [dbo].[Z_BillingDataFailed]
           ([id]
           ,[failureCheck]
           ,[failureMessage]
           ,[failureDate])
     VALUES
           (@oId
           ,@oFailureCheck
           ,@ofailureMessage
           ,@failureDate)

END


