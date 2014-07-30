using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamia.BillingSystem.BusinessManager;

namespace Dynamia.BillingSystem.Integrations
{
    public class SAPModifyContractWS
    {
        /// <summary>
        /// Metodo que crea el contrato en SAP
        /// </summary>
        /// <param name="billingData"></param> Informacion de el dato de facturacion de Salesforce
        /// <param name="billDate"></param> Fecha de corte de facturación
        /// <returns name="SAPContract"> </returns> Numero de contrato SAP
        public static void ModifyContractService(ref BOBilling billingData, DateTime billDate)
        {

            List<BOBillingDataCheck> SAPBillingDataCheck = new List<BOBillingDataCheck>();

            SAPCreateContractService.ZCUSTOMERCONTRACT_CHANGE newContract = new SAPCreateContractService.ZCUSTOMERCONTRACT_CHANGE();

            //Objeto CONTRACT_HEADER_IN: cabecera del servicio SAP de creacion de contratos
            newContract.CONTRACT_HEADER_IN = new SAPCreateContractService.BAPISDH1();
            //newContract.CONTRACT_HEADER_IN.DOC_TYPE = billingData.salesDocumentType;
            newContract.CONTRACT_HEADER_IN.SALES_ORG = billingData.salesOrganization;
            newContract.CONTRACT_HEADER_IN.DISTR_CHAN = billingData.distributionChannel;
            newContract.CONTRACT_HEADER_IN.DIVISION = billingData.division;
            newContract.CONTRACT_HEADER_IN.PO_SUPPLEM = billingData.totalNumberQuotes;
            newContract.CONTRACT_HEADER_IN.REF_1 = billingData.accountCode;
            newContract.CONTRACT_HEADER_IN.SALES_DIST = billingData.salesCityCode;
            newContract.CONTRACT_HEADER_IN.ORD_REASON = billingData.orderReason;
            newContract.CONTRACT_HEADER_IN.PURCH_NO_C = billingData.crmContractNumber;
            newContract.CONTRACT_HEADER_IN.PURCH_NO_S = billingData.editionNumber;
            newContract.CONTRACT_HEADER_IN.CURRENCY = billingData.currency;
            if (billingData.nie != string.Empty)
            {
                newContract.CONTRACT_HEADER_IN.COLLECT_NO = billingData.nie;
            }

            
            //Objeto PARTNERADDRESSES: informacion de ubicacion y contacto del cliente del servicio SAP de creacion de contratos
            newContract.PARTNERADDRESSES = new SAPCreateContractService.BAPIADDR1[1];
            newContract.PARTNERADDRESSES[0] = new SAPCreateContractService.BAPIADDR1();
            newContract.PARTNERADDRESSES[0].ADDR_NO = billingData.uniqueClientCode;
            newContract.PARTNERADDRESSES[0].CITY = billingData.cityName;
            newContract.PARTNERADDRESSES[0].POSTL_COD1 = billingData.cityCode;
            newContract.PARTNERADDRESSES[0].STREET = billingData.street;
            newContract.PARTNERADDRESSES[0].COUNTRY = billingData.countryCode;
            newContract.PARTNERADDRESSES[0].LANGU = billingData.languageCode;
            newContract.PARTNERADDRESSES[0].REGION = billingData.region;
            newContract.PARTNERADDRESSES[0].E_MAIL = billingData.eMailAddress;
            newContract.PARTNERADDRESSES[0].TEL1_NUMBR = billingData.phoneNumber;

            newContract.PARTNERCHANGES = new SAPCreateContractService.BAPIPARNRC[1];
            newContract.PARTNERCHANGES[0] = new SAPCreateContractService.BAPIPARNRC();
            newContract.PARTNERCHANGES[0].ITM_NUMBER = billingData.modificationItemNumber;
            newContract.PARTNERCHANGES[0].DOCUMENT = billingData.SAPContract;
            newContract.PARTNERCHANGES[0].UPDATEFLAG = billingData.modificationUpdateFlag;
            newContract.PARTNERCHANGES[0].PARTN_ROLE = billingData.clientPartnerRole;
            newContract.PARTNERCHANGES[0].P_NUMB_OLD = billingData.uniqueClientCode;
            newContract.PARTNERCHANGES[0].P_NUMB_NEW = billingData.uniqueClientCode;
            newContract.PARTNERCHANGES[0].ADDR_LINK = billingData.uniqueClientCode;

            newContract.SALESDOCUMENT = billingData.SAPContract;


            var quotes = billingData.getTotalQuotes();

            //Objeto CONTRACT_DATA_IN: datos del contrato del servicio SAP de creacion de contratos
            newContract.CONTRACT_DATA_IN = new SAPCreateContractService.BAPICTR[quotes];
            //Objeto CONTRACT_CONDITIONS_IN: datos de valor del contrato e IVA del servicio SAP de creacion de contratos
            newContract.CONTRACT_CONDITIONS_IN = new SAPCreateContractService.BAPICOND[quotes * 2];
            //Objeto CONTRACT_ITEMS_IN: datos del producto y fecha de facturacion del servicio SAP de creacion de contratos
            newContract.CONTRACT_ITEM_IN = new SAPCreateContractService.BAPISDITM[quotes];

            int index = 0;
            DateTime firstBillingDate = System.Convert.ToDateTime(billingData.firstQuoteDate);
            foreach (BOAsset actualAsset in billingData.billingAssets)
            {
                foreach (BOQuote quoteData in actualAsset.quoteList)
                {

                    int conditionsIndex = index * 2;

                    //CONTRACT_DATA_IN
                    newContract.CONTRACT_DATA_IN[index] = new SAPCreateContractService.BAPICTR();
                    newContract.CONTRACT_DATA_IN[index].ITM_NUMBER = System.Convert.ToString(index + 1);
                    newContract.CONTRACT_DATA_IN[index].CON_ST_DAT = System.Convert.ToDateTime(quoteData.contractStartDate).ToString("yyyy-MM-dd");
                    newContract.CONTRACT_DATA_IN[index].CON_EN_DAT = System.Convert.ToDateTime(quoteData.contractEndDate).ToString("yyyy-MM-dd");

                    //CONTRACT_CONDITIONS_IN: valor de la couta
                    newContract.CONTRACT_CONDITIONS_IN[conditionsIndex] = new SAPCreateContractService.BAPICOND();
                    newContract.CONTRACT_CONDITIONS_IN[conditionsIndex].ITM_NUMBER = System.Convert.ToString(index + 1);
                    newContract.CONTRACT_CONDITIONS_IN[conditionsIndex].COND_TYPE = quoteData.valueConditionType;
                    newContract.CONTRACT_CONDITIONS_IN[conditionsIndex].COND_VALUESpecified = true;
                    newContract.CONTRACT_CONDITIONS_IN[conditionsIndex].COND_VALUE = System.Convert.ToDecimal(quoteData.quoteConditionValue);
                    newContract.CONTRACT_CONDITIONS_IN[conditionsIndex].CURRENCY = billingData.currency;
                    newContract.CONTRACT_CONDITIONS_IN[conditionsIndex].CONDVALUESpecified = true;
                    newContract.CONTRACT_CONDITIONS_IN[conditionsIndex].CONDVALUE = System.Convert.ToDecimal(quoteData.quoteConditionValue);

                    //CONTRACT_CONDITIONS_IN: IVA de la contrato
                    newContract.CONTRACT_CONDITIONS_IN[conditionsIndex + 1] = new SAPCreateContractService.BAPICOND();
                    newContract.CONTRACT_CONDITIONS_IN[conditionsIndex + 1].ITM_NUMBER = System.Convert.ToString(index + 1);
                    newContract.CONTRACT_CONDITIONS_IN[conditionsIndex + 1].COND_VALUESpecified = true;
                    newContract.CONTRACT_CONDITIONS_IN[conditionsIndex + 1].COND_TYPE = quoteData.IVAConditionType;
                    newContract.CONTRACT_CONDITIONS_IN[conditionsIndex + 1].COND_VALUE = System.Convert.ToDecimal(quoteData.IVAconditionRate);
                    newContract.CONTRACT_CONDITIONS_IN[conditionsIndex + 1].CURRENCY = billingData.currency;
                    newContract.CONTRACT_CONDITIONS_IN[conditionsIndex + 1].CONDVALUESpecified = true;
                    newContract.CONTRACT_CONDITIONS_IN[conditionsIndex + 1].CONDVALUE =  System.Convert.ToDecimal(quoteData.IVAConditionValue);

                    //CONTARCT_ITEMS_IN:
                    newContract.CONTRACT_ITEM_IN[index] = new SAPCreateContractService.BAPISDITM();
                    newContract.CONTRACT_ITEM_IN[index].ITM_NUMBER = System.Convert.ToString(index + 1);
                    newContract.CONTRACT_ITEM_IN[index].MATERIAL = quoteData.materialNumber;
                    if (firstBillingDate < billDate)
                    {
                        newContract.CONTRACT_ITEM_IN[index].BILL_DATE = ((System.Convert.ToDateTime(billDate)).AddMonths(System.Convert.ToInt16(quoteData.quoteNumber) - 1)).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        newContract.CONTRACT_ITEM_IN[index].BILL_DATE = ((System.Convert.ToDateTime(quoteData.billingDate))).ToString("yyyy-MM-dd");
                    }
                    newContract.CONTRACT_ITEM_IN[index].TARGET_QTY = System.Convert.ToDecimal(quoteData.quantity);
                    newContract.CONTRACT_ITEM_IN[index].TARGET_QU = quoteData.quantityUoM;
                    newContract.CONTRACT_ITEM_IN[index].PRC_GROUP4 = quoteData.quoteNumber;
                    newContract.CONTRACT_ITEM_IN[index].PURCH_NO_C = quoteData.financialContactPhoneNumber;
                    newContract.CONTRACT_ITEM_IN[index].PURCH_NO_S = quoteData.quoteName;
                    newContract.CONTRACT_ITEM_IN[index].SALES_DIST = quoteData.salesDistrict;
                    newContract.CONTRACT_ITEM_IN[index].PRICE_LIST = quoteData.priceList;
                    newContract.CONTRACT_ITEM_IN[index].PYMT_METH = quoteData.paymentMethod;
                    newContract.CONTRACT_ITEM_IN[index].SALES_UNIT = quoteData.salesUnit;
                    newContract.CONTRACT_ITEM_IN[index].PMNTTRMS = quoteData.termsOfPaymentKey;

                    index++;


                }
            }

            SAPCreateContractService.svc_Financial_SAP_10_BasicHttp_SI_ContratoCRMEXT_OutClient client = new SAPCreateContractService.svc_Financial_SAP_10_BasicHttp_SI_ContratoCRMEXT_OutClient();
            var response = client.OP_ModificarContratoCRMEXT_Out(newContract);
            client.Close();

            var responseLenght = response.RETURN.Length;
            var responseChecked = 0;
            var x = 0;
            var billfailed = 0;
            string emessage = "";
            for (x = 0; x < responseLenght; x++)
            {
                if (response.RETURN[x].MESSAGE == "Cto Publicación: R1 " + response.RETURN[x].MESSAGE_V2 + " se ha grabado")
                {
                    responseChecked++;
                }
                if (response.RETURN[x].MESSAGE == "ORDER_HEADER_IN procesado con éxito")
                {
                    responseChecked++;
                }
                if (response.RETURN[x].MESSAGE == "ITEM_IN procesado con éxito")
                {
                    responseChecked++;
                }
                if (response.RETURN[x].MESSAGE == "KONVKOM procesado con éxito")
                {
                    responseChecked++;
                }
                if (responseChecked != x + 1 && x != 0)
                {
                    emessage = emessage + ' ' + response.RETURN[x].MESSAGE;


                    billfailed = 1;
                    responseChecked++;
                }
            }




            if (billfailed == 1)
            {

                billingData.billingFailureMessage = "Hubo errores en la creación de la factura del contrato \n" + "Errores: " + emessage;
                billingData.billingFailure = 1;

            }
            else
            {
              
                foreach (BOAsset actualAsset in billingData.billingAssets)
                {
                   
                    foreach (BOQuote quote in actualAsset.quoteList)
                    {
                        quote.status = "AE";
                    }

                }
            }


            //return billingData;
        }
    }
}
