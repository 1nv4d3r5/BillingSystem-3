using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamia.BillingSystem.BusinessManager
{
    public class BOQuote
    {
        //CONTRACT_CONDITIONS_IN
        public string valueConditionType { get; set; } //Tipo de condicion para el valos de la cuota
        public string IVAConditionType { get; set; } //tipo de condicion para el iva de la cuota
        public string quoteConditionValue { get; set; } //Valor correspondiente a la cuota de facturacion
        public string IVAConditionValue { get; set; } //Valor correspondiente al IVA de la cuota facturacion
        public string IVAconditionRate { get; set; } //Valor correspondiente a la tasa del IVA

        //CONTRACT_DATA_IN
        public string contractStartDate { get; set; } //Fecha de inicio del contrato. (YYYY-MM-DD)
        public string contractEndDate { get; set; } //Fecha de fin del contrato. (YYYY-MM-DD)

        //CONTRACT_ITEM_IN
        public string materialNumber { get; set; } //Código de material, producto, para la posición principal será el producto. 
        public string billingDate { get; set; } //Fecha de la factura de venta
        public string salesDistrict { get; set; } //Ciudad del teléfono de facturación codificada
        public string termsOfPaymentKey {get; set;} //Condicion de pago
        public string paymentMethod {get; set;} //Medio de pago
        public string salesUnit { get; set; } //Unidad de medida, ej, UN, KG, etc...
        public string quoteName { get; set; } //Nombre de la cuota
        public string quoteNumber {get; set;} //Numero de la cuota
        public string financialContactPhoneNumber {get; set;} //NUmero de contacto financiero
        public string contractNumber {get; set;} //Numero de contrato SF
        public string quantity { get; set; } //cantidad
        public string quantityUoM { get; set; } //unidad de medida de la cantidad
        public string priceList { get; set; } //lista de precios
        public string producttoPorCotizacion { get; set; }
        
        //public string assetId { get; set; }
        public string status { get; set; }
        public string id { get; set; }
    }
}
