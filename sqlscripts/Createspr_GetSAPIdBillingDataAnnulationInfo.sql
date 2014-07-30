USE [SFDynamia]
GO

/****** Object:  StoredProcedure [dbo].[spr_GetSAPIdBillingDataAnnulationInfo]    Script Date: 16/07/2014 02:14:16 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Juan Daniel Horta
-- Create date: 2014-11-06
-- Description:	Store Procedure para obetner los id de datos de factiracion que se van a enviar a sap
-- =============================================
CREATE PROCEDURE [dbo].[spr_GetSAPIdBillingDataAnnulationInfo]
	@LimitDate varchar(12)
AS

	DECLARE @oLimitDate varchar(12) = @LimitDate 
BEGIN
	select distinct datosFacturacion.id,
	  '000000' as ITM_NUMBER,
	  'U' as updateflag,
	  1 As consecutivo,
      datosFacturacion.CODIGO_CLIENTE_UNICO__C as partner,
      'ZCP1' as DOC_TYPE,
       ''    as   collect_no,
       '0004' as SALES_ORG,
       '01' as DISTR_CHAN,
       '00' as DIVISION,
       '' as sales_grp,
       '' as sales_off,
       datosFacturacion.NUMERO_CUOTAS__C as PO_SUPPLEM,
       cuenta.CODIGO_CUENTA__C as REF_1,
       (replicate ('0',(5 - len(CASE WHEN ciudades.CODIGO_CIUDAD__C IS NULL THEN ciudadesOportunidades.CODIGO_CIUDAD__C  ELSE ciudades.CODIGO_CIUDAD__C END))) + convert(varchar,CASE WHEN ciudades.CODIGO_CIUDAD__C IS NULL THEN ciudadesOportunidades.CODIGO_CIUDAD__C  ELSE ciudades.CODIGO_CIUDAD__C END)) as SALES_DIST1,
       '003' as ORD_REASON,
       op.NUMERO_CONTRATO__C as PURCH_NO_C1,
       '2014'  as purch_no_s_,
       'COP' as CURRENCY1,
       'Z030' as pmnttrms	,
       1 as ITM_NUMBER,
       --'ZPRM' as  COND_TYPE1,
       --CONVERT(int,ROUND(cuotasFacturacion.VALOR_CUOTA__C,0)) as COND_VALUE1,
       --'COP' as CURRENCY2,
       --CONVERT(int,ROUND(cuotasFacturacion.VALOR_CUOTA__C,0))  as CONDVALUE1,
       --'ZIVA' as COND_TYPE2,
       --'16' as CONDVALUE2,
       --CONVERT(int,ROUND((cuotasFacturacion.VALOR_CUOTA__C*0.16),0))  as COND_VALUE2,
       '' as id_procuo_ctr,
       '' as itm_number_ctr,
       '' as val_per,
       '' as val_per_un,
       '' as val_per_ca,
       '' as accept_dat,
       --activos.INSTALLDATE as con_st_dat,--inicio vigencia yyyymmdd
       '' as con_si_dat,
       --activos.USAGEENDDATE as con_en_dat,--fin vigencia yyyymmdd
       '' as canc_r_dat,
       '' as canc_party,
       '' as cancreason,
       --productos.PRODUCTO_FINANCIERO__C as MATERIAL,
       --cuotasFacturacion.FECHA_CUOTA__C  as BILL_DATE,
       '1' as TARGET_QTY,
       'ST' as TARGET_QU,
       --cuotasFacturacion.NO_CUOTA__C as  PRC_GROUP4,
       datosFActuracion.TELEFONO_CONTACTO_FINANCIERO__C as PURCH_NO_C2,
       op.NUMERO_CONTRATO__C PURCH_NO_S,
         (replicate ('0',(5 - len(CASE WHEN ciudades.CODIGO_CIUDAD__C IS NULL THEN ciudadesOportunidades.CODIGO_CIUDAD__C  ELSE ciudades.CODIGO_CIUDAD__C END))) + convert(varchar,CASE WHEN ciudades.CODIGO_CIUDAD__C IS NULL THEN ciudadesOportunidades.CODIGO_CIUDAD__C  ELSE ciudades.CODIGO_CIUDAD__C END)) as SALES_DIST2,
        'CI' as PRICE_LIST,
        case when datosFacturacion.NIE__C is null then 'F' 
			else 'O' 
		end as PYMT_METH,
        'ST' as SALES_UNIT,
        'AG' as PARTN_ROLE1,
        datosFacturacion.CODIGO_CLIENTE_UNICO__C  as PARTN_NUMB1,
        datosFacturacion.CODIGO_CLIENTE_UNICO__C  as ADDR_LINK1,
       'RE' as PARTN_ROLE2,
        datosFacturacion.CODIGO_CLIENTE_UNICO__C  as PARTN_NUMB2,
        datosFacturacion.CODIGO_CLIENTE_UNICO__C  as ADDR_LINK2,
       'VE' as PARTN_ROLE3,
      usuario.ID_NOMINA__C as PARTN_NUMB3,
       'ZC' as PARTN_ROLE4,
       '171' as PARTN_NUMB4,
       datosFacturacion.CODIGO_CLIENTE_UNICO__C as ADDR_NO,
	      ciudadesFacturacion.name as CITY,
         replicate ('0',(5 - len(ciudadesFacturacion.CODIGO_CIUDAD__C)))   + convert(varchar,ciudadesFacturacion.CODIGO_CIUDAD__C) as POSTL_COD1,         
       datosFacturacion.DIRECCION_FACTURACION__C as STREET,
       'CO' as COUNTRY,
       'S' as LANGU,
      SUBSTRING(replicate ('0',(5 - len(ciudadesFacturacion.CODIGO_CIUDAD__C)))   + convert(varchar,ciudadesFacturacion.CODIGO_CIUDAD__C),1,2)as REGION,
	  datosFacturacion.NIE__C,
      usuario.name,
      usuario.userroleid,
      op.id COLLATE Latin1_General_CS_AS as idOportunidad,
      cuenta.id COLLATE Latin1_General_CS_AS as idCuenta,
      --activos.id COLLATE Latin1_General_CS_AS as idActivo,
      --productosCotizacion.id COLLATE Latin1_General_CS_AS  as idProductoCotizacion,
      op.CIUDAD_VENTA__C as idciudadCotizacion,
      cotizacion.id as idCotizacion,
      --activos.FACTURADO__C,
      --cuotasFacturacion.NAME as cuotaname,
	  datosFacturacion.[CORREO_FACTURACION__C] as FactEmail,
	  datosFacturacion.[CIUDAD_FACTURACION__C] as FactCiudad,
	  datosFacturacion.[TELEFONO_CONTACTO_FINANCIERO__C] as FactTel,
	  datosFacturacion.[DIRECCION_FACTURACION__C] as FactDir,
	  datosFacturacion.[FECHA_PRIMERA_CUOTA__C] as FactFirstQuote,
	  datosFacturacion.[CONTRATO_SAP__C] as contratoSAP,
	  datosFacturacion.NIE__C as NIE
	from  dbo.OPPORTUNITY op WITH(NOLOCK)
   inner join dbo.ACCOUNT cuenta  WITH(NOLOCK) on cuenta.ID = op.ACCOUNTID
   inner join dbo.FACTURA_POR_OPORTUNIDAD__C facturas  WITH(NOLOCK) on facturas.OPORTUNIDAD__C = op.id
   inner join dbo.DATO_FACTURACION__C datosFacturacion  WITH(NOLOCK) on datosFacturacion.ID = facturas.DATO_FACTURACION__C
   inner join dbo.CUOTA_FACTURACION__C cuotasFacturacion  WITH(NOLOCK) on cuotasFacturacion.DATO_FACTURACION__C = datosFacturacion.ID
   inner join dbo.QUOTELINEITEM productosCotizacion  WITH(NOLOCK) on productosCotizacion.id = cuotasFacturacion.PARTIDA_DE_PRESUPUESTO__C
   inner join dbo.QUOTE cotizacion  WITH(NOLOCK) on cotizacion.ID = productosCotizacion.QUOTEID
   inner join dbo.PRICEBOOKENTRY listaPrecios  WITH(NOLOCK) on listaPrecios.Id = productosCotizacion.PRICEBOOKENTRYID
   inner join dbo.PRODUCT2 productos  WITH(NOLOCK) on productos.ID = listaPrecios.PRODUCT2ID
   inner join dbo.ASSET activos  WITH(NOLOCK) on activos.ID = productosCotizacion.ACTIVO_PRODUCIDO__C
   LEFT join dbo.CIUDAD__C ciudades  WITH(NOLOCK) on ciudades.id = cotizacion.CIUDAD_VENTA__C
   LEFT join dbo.CIUDAD__C ciudadesFacturacion  WITH(NOLOCK) on ciudadesFacturacion.id = datosFacturacion.CIUDAD_FACTURACION__C
   LEFT join dbo.CIUDAD__C ciudadestelefonofacturacion  WITH(NOLOCK) on ciudadestelefonofacturacion.id = datosFacturacion.CIUDAD_TELEFONO_FACTURACION__C
   LEFT join dbo.CIUDAD__C ciudadesOportunidades  WITH(NOLOCK) on ciudadesOportunidades.id = op.CIUDAD_VENTA__C
   inner join ( SELECT case when productosCompradoOp.productosComprados = activosOportunidad.activosActivos then productosCompradoOp.ID end COLLATE Latin1_General_CS_AS as ID from
					  (select  count(productosCotizacion.ID) as productosComprados, op.ID  COLLATE Latin1_General_CS_AS AS ID
					   from dbo.OPPORTUNITY op  WITH(NOLOCK)
					    inner join dbo.QUOTELINEITEM productosCotizacion  WITH(NOLOCK) on productosCotizacion.QUOTEID = op.SYNCEDQUOTEID
					 
                        
					   group by  op.ID
					   ) as productosCompradoOp
					inner join
					  ( select count(activos.ID) as activosActivos, op.ID  COLLATE Latin1_General_CS_AS AS ID
					   from dbo.OPPORTUNITY op  WITH(NOLOCK)
					   inner join dbo.QUOTELINEITEM productosCotizacion  WITH(NOLOCK) on productosCotizacion.QUOTEID = op.SYNCEDQUOTEID
					   inner join dbo.ASSET activos  WITH(NOLOCK) on activos.ID = productosCotizacion.ACTIVO_PRODUCIDO__C
					   where activos.[status] in ('06. Anulado') and activos.INSTALLDATE > '2014-01-01'
					   group by op.ID ) as activosOportunidad
		          on productosCompradoOp.ID = activosOportunidad.ID 
		          --and productosCompradoOp.productosComprados = activosOportunidad.activosActivos
		           ) as oportunidadesActivas
		 on oportunidadesActivas.id = op.id           
	inner join 	 dbo.RECORDTYPE tipoRegistro  WITH(NOLOCK) on tipoRegistro.ID = op.RECORDTYPEID    
	inner join   dbo.[USER] usuario  WITH(NOLOCK) on usuario.id = op.OWNERID    
	left join (select distinct PARTY_ID  from [Dynamia].[dbo].[ColombiaBillingParty] WITH(NOLOCK)) datosMasterData 
	           on CONVERT(decimal(10,0),datosMasterData.PARTY_ID) = datosFacturacion.CODIGO_CLIENTE_UNICO__C
	--left join [Dynamia].[dbo].[ColombiaBillingParty] MasterData WITH(NOLOCK) on  datosFacturacion.CODIGO_CLIENTE_UNICO__C = MasterData.PARTY_ID
    --left join  [Facturacion].dbo.OportunidadesFacturadas facturadas on  facturadas.IDOPORTUNIDAD = op.id
   where StageName = '09 Cerrada ganada'
	  and op.[ANULADO__C] = 1 
      and cotizacion.ISSYNCING = 1 
      --and usuario.userroleid not IN ('00E400000012om2EAA','00E400000012olsEAA')--No Soluciones transaccionales, Ni Agencia Digital
	  and op.Unidad_de_Negocio__c in ('Soluciones digitales')
      --and  datosFacturacion.NIE__C IS NULL 
      and op.TOKEN_VENTA_EN_LINEA__C is null
     -- and facturadas.IDOPORTUNIDAD is null
      and op.AMOUNT > 0 
	  and productosCotizacion.TOTALPRICE > 0
      and usuario.ID_NOMINA__C is not null
      and cuenta.CODIGO_CLIENTE_UNICO__C is not null
      and activos.FACTURADO__C = 1
      and datosMasterData.PARTY_ID is not null 
      --and cuenta.NUMERO_IDENTIFICACION__C = datosFacturacion.NUMERO_IDENTIFICACION__C
      and datosFacturacion.CODIGO_CLIENTE_UNICO__C is not null
	  --and datosFacturacion.CODIGO_CLIENTE_UNICO__C = 19935
     --and datosFActuracion.TELEFONO_CONTACTO_FINANCIERO__C !='NULL' 
	 and datosFActuracion.TELEFONO_CONTACTO_FINANCIERO__C is not null 
	  and datosFacturacion.DIRECCION_FACTURACION__C is not  null
	  and datosFacturacion.[REQUIERE_MASTERDATA__C] = 0
	  --and datosFacturacion.[STATUS_MASTERDATA__C] != 'ENVIADO'
	  and activos.INSTALLDATE is not NULL
	  and datosFacturacion.[CORREO_FACTURACION__C] is not null
	  and datosFacturacion.[CIUDAD_FACTURACION__C] is not null
	  and datosFacturacion.[TELEFONO_CONTACTO_FINANCIERO__C] is not null
	  and datosFacturacion.[DIRECCION_FACTURACION__C] is not null
	  and datosFacturacion.[REQUIERE_MASTERDATA__C] = 0
	  and  datosFacturacion.FECHA_PRIMERA_CUOTA__C <= @oLimitDate
	  --and op.[NUMERO_CONTRATO__C] = 'UD00007372'
	  and cuotasFacturacion.[ESTADO__C]  = 'A'
	  and datosFacturacion.[FACTURADO__C] = 1
   --order by  cuenta.CODIGO_CLIENTE_UNICO__C,facturas.id, productosCotizacion.id,  cuotasFacturacion.NO_CUOTA__C
END

GO


