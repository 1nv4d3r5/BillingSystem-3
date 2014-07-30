USE [SFDynamia]
GO

/****** Object:  StoredProcedure [dbo].[spr_updateBillingLog]    Script Date: 16/07/2014 02:19:07 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Juan Daniel Horta
-- Create date: 27-06-2014
-- Description:	Procedimiento para ingresar datos al log de facturacion
-- =============================================
CREATE PROCEDURE [dbo].[spr_updateBillingLog]

		@partner varchar(10),
		@DOC_TYPE varchar(4),
		@SALES_ORG varchar(4),
		@DISTR_CHAN varchar(2),
		@DIVISION varchar(2),
		@PO_SUPPLEM varchar(3),
		@REF_1 nvarchar(30),
		@SALES_DIST1 varchar(5),
		@ORD_REASON varchar(3),
		@PURCH_NO_C1 nvarchar(30),
		@purch_no_s_ varchar(4),
		@CURRENCY1 varchar(3),
		@pmnttrms varchar(4),
		@COND_TYPE1 varchar(4),
		@COND_VALUE1 varchar(10),
		@CURRENCY2 varchar(3),
		@CONDVALUE1 varchar(10),
		@COND_TYPE2 varchar(4),
		@CONDVALUE2 varchar(2),
		@COND_VALUE2 varchar(10),
		@con_st_dat datetime,
		@con_en_dat datetime,
		@MATERIAL nvarchar(16),
		@BILL_DATE datetime,
		@TARGET_QTY varchar(1),
		@TARGET_QU varchar(2),
		@PRC_GROUP4 varchar(2),
		@PURCH_NO_C2 nvarchar(40),
		@SALES_DIST2 varchar(8000),
		@PRICE_LIST varchar(2),
		@PYMT_METH varchar(1),
		@SALES_UNIT varchar(2),
		@PARTN_ROLE1 varchar(2),
		@PARTN_NUMB1 varchar(10),
		@ADDR_LINK1 varchar(10),
		@PARTN_ROLE2 varchar(2),
		@PARTN_NUMB2 varchar(10),
		@ADDR_LINK2 varchar(10),
		@PARTN_ROLE3 varchar(2),
		@PARTN_NUMB3 nvarchar(255),
		@PARTN_ROLE4 varchar(2),
		@PARTN_NUMB4 varchar(3),
		@ADDR_NO varchar(10),
		@CITY varchar(6),
		@POSTL_COD1 varchar(5),
		@STREET nvarchar(255),
		@COUNTRY varchar(2),
		@LANGU varchar(1),
		@REGION varchar(2),
		@NIE__C varchar(18),
		@idOportunidad nvarchar(18),
		@idCuenta nvarchar(18),
		@idActivo nvarchar(18),
		@idProductoCotizacion nvarchar(18),
		@idCotizacion nvarchar(18),
		@FACTURADO__C varchar(1),
		@id nvarchar(18),
		@cuotaname nvarchar(80),
		@FactEmail nvarchar(80),
		@FactTel nvarchar(40),
		@FactDir nvarchar(255),
		@FactFirstQuote datetime,
		@idCuotaFacturacion nvarchar(18),
		@contratoSAP varchar(18),
		@fechaEnvioFacturacion datetime,
		@fechaCorteFacturacion datetime,
		@quoteStatus varchar(5)

AS
	
	
		DECLARE @opartner varchar(10) = @partner
		DECLARE @oDOC_TYPE varchar(4) = @DOC_TYPE
		DECLARE @oSALES_ORG varchar(4) = @SALES_ORG
		DECLARE @oDISTR_CHAN varchar(2) = @DISTR_CHAN
		DECLARE @oDIVISION varchar(2) = @DIVISION
		DECLARE @oPO_SUPPLEM varchar(3) = @PO_SUPPLEM
		DECLARE @oREF_1 nvarchar(30) = @REF_1
		DECLARE @oSALES_DIST1 varchar(5) = @SALES_DIST1
		DECLARE @oORD_REASON varchar(3) = @ORD_REASON
		DECLARE @oPURCH_NO_C1 nvarchar(30) = @PURCH_NO_C1
		DECLARE @opurch_no_s_ varchar(4) = @purch_no_s_
		DECLARE @oCURRENCY1 varchar(3) = @CURRENCY1
		DECLARE @opmnttrms varchar(4) = @pmnttrms
		DECLARE @oCOND_TYPE1 varchar(4) = @COND_TYPE1 
		DECLARE @oCOND_VALUE1 varchar(10) = @COND_VALUE1
		DECLARE @oCURRENCY2 varchar(3) = @CURRENCY2
		DECLARE @oCONDVALUE1 varchar(10) = @CONDVALUE1
		DECLARE @oCOND_TYPE2 varchar(4) = @COND_TYPE2
		DECLARE @oCONDVALUE2 varchar(2) = @CONDVALUE2
		DECLARE @oCOND_VALUE2 varchar(10) = @COND_VALUE2
		DECLARE @ocon_st_dat datetime = @con_st_dat
		DECLARE @ocon_en_dat datetime = @con_en_dat
		DECLARE @oMATERIAL nvarchar(16) = @MATERIAL
		DECLARE @oBILL_DATE datetime = @BILL_DATE
		DECLARE @oTARGET_QTY varchar(1) = @TARGET_QTY
		DECLARE @oTARGET_QU varchar(2) = @TARGET_QU
		DECLARE @oPRC_GROUP4 varchar(2) = @PRC_GROUP4
		DECLARE @oPURCH_NO_C2 nvarchar(40) = @PURCH_NO_C2
		DECLARE @oSALES_DIST2 varchar(8000) = @SALES_DIST2
		DECLARE @oPRICE_LIST varchar(2) = @PRICE_LIST
		DECLARE @oPYMT_METH varchar(1) = @PYMT_METH
		DECLARE @oSALES_UNIT varchar(2) = @SALES_UNIT
		DECLARE @oPARTN_ROLE1 varchar(2) = @PARTN_ROLE1
		DECLARE @oPARTN_NUMB1 varchar(10) = @PARTN_NUMB1
		DECLARE @oADDR_LINK1 varchar(10) = @ADDR_LINK1
		DECLARE @oPARTN_ROLE2 varchar(2) = @PARTN_ROLE2
		DECLARE @oPARTN_NUMB2 varchar(10) = @PARTN_NUMB2
		DECLARE @oADDR_LINK2 varchar(10) = @ADDR_LINK2
		DECLARE @oPARTN_ROLE3 varchar(2) = @PARTN_ROLE3
		DECLARE @oPARTN_NUMB3 nvarchar(255) = @PARTN_NUMB3
		DECLARE @oPARTN_ROLE4 varchar(2) = @PARTN_ROLE4
		DECLARE @oPARTN_NUMB4 varchar(3) = @PARTN_NUMB4
		DECLARE @oADDR_NO varchar(10) = @ADDR_NO
		DECLARE @oCITY varchar(6) = @CITY
		DECLARE @oPOSTL_COD1 varchar(5) = @POSTL_COD1
		DECLARE @oSTREET nvarchar(255) = @STREET
		DECLARE @oCOUNTRY varchar(2) = @COUNTRY
		DECLARE @oLANGU varchar(1) = @LANGU
		DECLARE @oREGION varchar(2) = @REGION
		DECLARE @oNIE__C varchar(18) = @NIE__C
		DECLARE @oidOportunidad nvarchar(18) = @idOportunidad
		DECLARE @oidCuenta nvarchar(18) = @idCuenta
		DECLARE @oidActivo nvarchar(18) = @idActivo
		DECLARE @oidProductoCotizacion nvarchar(18) = @idProductoCotizacion
		DECLARE @oidCotizacion nvarchar(18) = @idCotizacion
		DECLARE @oFACTURADO__C varchar(1) = @FACTURADO__C
		DECLARE @oid nvarchar(18) = @id
		DECLARE @ocuotaname nvarchar(80) = @cuotaname
		DECLARE @oFactEmail nvarchar(80) = @FactEmail
		DECLARE @oFactTel nvarchar(40) = @FactTel
		DECLARE @oFactDir nvarchar(255) = @FactDir
		DECLARE @oFactFirstQuote datetime = @FactFirstQuote
		DECLARE @oidCuotaFacturacion nvarchar(18) = @idCuotaFacturacion
		DECLARE @ocontratoSAP varchar(18) = @contratoSAP
		DECLARE @ofechaEnvioFacturacion datetime = @fechaEnvioFacturacion
		DECLARE @ofechaCorteFacturacion datetime = @fechaCorteFacturacion
		DECLARE @oquoteStatus varchar(5) = @quoteStatus

BEGIN
	
	INSERT INTO [dbo].[Z_logFactSFSAPsoldig] VALUES(
	@opartner,
	@oDOC_TYPE,
	@oSALES_ORG,
	@oDISTR_CHAN,
	@oDIVISION,
	@oPO_SUPPLEM,
	@oREF_1,
	@oSALES_DIST1,
	@oORD_REASON,
	@oPURCH_NO_C1,
	@opurch_no_s_,
	@oCURRENCY1,
	@opmnttrms,
	@oCOND_TYPE1,
	@oCOND_VALUE1,
	@oCURRENCY2,
	@oCONDVALUE1,
	@oCOND_TYPE2,
	@oCONDVALUE2,
	@oCOND_VALUE2,
	@ocon_st_dat,
	@ocon_en_dat,
	@oMATERIAL,
	@oBILL_DATE,
	@oTARGET_QTY,
	@oTARGET_QU,
	@oPRC_GROUP4,
	@oPURCH_NO_C2,
	@oSALES_DIST2,
	@oPRICE_LIST,
	@oPYMT_METH,
	@oSALES_UNIT,
	@oPARTN_ROLE1,
	@oPARTN_NUMB1,
	@oADDR_LINK1,
	@oPARTN_ROLE2,
	@oPARTN_NUMB2,
	@oADDR_LINK2,
	@oPARTN_ROLE3,
	@oPARTN_NUMB3,
	@oPARTN_ROLE4,
	@oPARTN_NUMB4,
	@oADDR_NO,
	@oCITY,
	@oPOSTL_COD1,
	@oSTREET,
	@oCOUNTRY,
	@oLANGU,
	@oREGION,
	@oNIE__C,
	@oidOportunidad,
	@oidCuenta,
	@oidActivo,
	@oidProductoCotizacion,
	@oidCotizacion,
	@oFACTURADO__C,
	@oid,
	@ocuotaname,
	@oFactEmail,
	@oFactTel,
	@oFactDir,
	@oFactFirstQuote,
	@oidCuotaFacturacion,
	@ocontratoSAP,
	@ofechaEnvioFacturacion,
	@ofechaCorteFacturacion,
	@oquoteStatus
	)
	
END
GO


