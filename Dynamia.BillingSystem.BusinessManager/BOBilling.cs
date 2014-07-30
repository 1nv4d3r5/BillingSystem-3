 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamia.BillingSystem.BusinessManager
{
    public class BOBilling
    {
        //CONTRACT_HEADER_IN

        //Clase de documento de ventas, este tipo de documento determina el proceso subsiguiente de facturación. Valor Fijo= 'Z1CP' (Cto.         Publicación), ZNCR (Para Notas de Creadito) 
        public string salesDocumentType { get; set; }

        

        //Codigo del pais 
        public string salesOrganization { get; set; }

        //Medio a través del cual los bienes o servicios se venden al cliente
        public string distributionChannel { get; set; }

        //Clasificación general de los productos: directorios, internet, B2B, etc. Para el contrato será Valor fijo = '00' (Sector Común). 

        public string division { get; set; }
        
        //Oficina de venta del contrato.
        public string salesGroup { get; set; }

        //Regional de venta del contrato. 

        public string salesOffice { get; set; }

        //Código de la Ciudad de Venta. 
        public string salesCityCode { get; set; }

        //Número de cuotas

        public string totalNumberQuotes { get; set; }

        //Número de cuenta del contrato SF

        public string accountCode { get; set; }

        //Tipo de transaccion

        public string orderReason { get; set; }

        //Número de contrato de SalesForce

        public string crmContractNumber { get; set; }

        //Edicion de la campaña 
        public string editionNumber { get; set; }

        //Moneda del contrato
        public string currency { get; set; }

        //CONTRACT_PARTNERS

        //Codigo Cliente Unico Master Data

        public string uniqueClientCode { get; set; }

        //Código de nomina del asesor comercial

        public string salesAgentCode { get; set; }

        //Rol de cliente

        public string clientPartnerRole { get; set; }

        //Rol del receptor de la factura

        public string billReceiverPartnetRole { get; set; }

        //Rol del vendedor

        public string salesAgentPartnerRole { get; set; }

        //Rol del canal de facturacion

        public string billingChannelPartnerRole { get; set; }

        //Canal de facturacion

        public string billingChannel { get; set; }

        //PARTNERADDRESSES

        //Codigo ciudad de la direccion de facturaccion
        public string cityName { get; set; }

        //Codigo Ciudad de la dirección de facturación
        public string cityCode { get; set; }

        //Direccion de facturacion

        public string street { get; set; }

        //Telefono de facturacion 
        public string phoneNumber { get; set; }

        //Codigo de pais de facturacion
        public string countryCode { get; set; }

        //Codigo Idioma de facturacion
        public string languageCode { get; set; }

        //Codigo region de facturacion
        public string region { get; set; }

        //Email de facturacion   
        public string eMailAddress { get; set; }

        //Código del token de pago en linea
        public string tokenNumber { get; set; }

        //Codigo Salesforce del datop de facturacion
        public string billingDataId { get; set; }

        //lista de datos de las cuotas de facturaccion
        public List<BOAsset> billingAssets {get; set;}

        public string firstQuoteDate { get; set; }

        public string SAPContract { get; set; }

        public int billingCheck { get; set; }

        public DateTime billingDate { get; set; }

        public DateTime finalFirstQuoteDate { get; set; }

        public string billingFailureMessage { get; set; }

        public int billingFailure { get; set; }

        public string modificationItemNumber { get; set; }

        public string modificationUpdateFlag { get; set; }

        public string opportunityId { get; set; }

        public string accountId { get; set; }

        public string idCotizacion { get; set; }

        public int getTotalQuotes() { 
           int totalQuotes = 0;
           foreach(BOAsset asset in billingAssets ){
               totalQuotes += asset.quoteList.Count;
           }
           return totalQuotes;
        }

        public string nie { get; set; }

        public BOBilling()
        {
            accountCode = string.Empty;
            billingAssets = new List<BOAsset>();
            billingChannel = string.Empty;
            billingChannelPartnerRole = string.Empty;
            billingCheck = 0;
            billingDataId = string.Empty;
            billingDate = new DateTime();
            billingFailure = 0;
            billingFailureMessage = String.Empty;
            billReceiverPartnetRole = String.Empty;
            cityCode = string.Empty;
            cityName = string.Empty;
            clientPartnerRole = string.Empty;
            countryCode = string.Empty;
            crmContractNumber = string.Empty;
            currency = string.Empty;
            distributionChannel = string.Empty;
            division = string.Empty;
            editionNumber = string.Empty;
            eMailAddress = string.Empty;
            finalFirstQuoteDate = new DateTime();
            firstQuoteDate = string.Empty;
            languageCode = string.Empty;
            
            orderReason = string.Empty;
            phoneNumber = string.Empty;
            region = string.Empty;
            salesAgentCode = string.Empty;
            salesAgentPartnerRole = string.Empty;
            salesCityCode = string.Empty;
            salesDocumentType = string.Empty;
            salesGroup = string.Empty;
            salesOffice = string.Empty;
            salesOrganization = string.Empty;
            SAPContract = string.Empty;
            street = string.Empty;
            tokenNumber = string.Empty;
            totalNumberQuotes = string.Empty;
            uniqueClientCode = string.Empty;
            modificationItemNumber = string.Empty;
            modificationUpdateFlag = string.Empty;
            opportunityId = string.Empty;
            accountId = string.Empty;
            idCotizacion = string.Empty;
            nie = string.Empty;
        }

    }
}
