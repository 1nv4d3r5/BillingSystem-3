USE [SFDynamia]
GO

/****** Object:  StoredProcedure [dbo].[spr_InsertErrorLog]    Script Date: 16/07/2014 02:15:34 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Juan Daniel Horta
-- Create date: 01-07-2014
-- Description:	insercion de errores de facturacion en log de eroores
-- =============================================
CREATE PROCEDURE [dbo].[spr_InsertErrorLog]
	@date as datetime,
	@message as varchar(300)
AS
	DECLARE @oDate as datetime = @date
	DECLARE @oMessage as varchar(300) = @message
BEGIN
	insert into [dbo].[Z_ErrorLog] values (@oDate, @oMessage)
END

GO


