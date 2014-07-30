using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using Dynamia.BillingSystem.BusinessManager;

namespace Dynamia.BillingSystem.SQLDAO
{
    public class DAOLogs
    {

        private SqlConnection connect = null;
        private SqlCommand cmd = null;
        private SqlDataReader reader = null;

        public void UpdateLog(BOBilling billingData, BOAsset assetData, BOQuote quoteData)
        {
          
            try
            {
                connect = new SqlConnection(ConfigurationManager.ConnectionStrings["localTestConnection"].ConnectionString);
                using (cmd = new SqlCommand("spr_updateBillingLog", connect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@partner", SqlDbType.VarChar).Value = billingData.uniqueClientCode;
                    cmd.Parameters.Add("@DOC_TYPE", SqlDbType.VarChar).Value = billingData.salesDocumentType;
                    cmd.Parameters.Add("@SALES_ORG", SqlDbType.VarChar).Value = billingData.salesOrganization;
                    cmd.Parameters.Add("@DISTR_CHAN", SqlDbType.VarChar).Value = billingData.distributionChannel;
                    cmd.Parameters.Add("@DIVISION", SqlDbType.VarChar).Value = billingData.division;
                    cmd.Parameters.Add("@PO_SUPPLEM", SqlDbType.VarChar).Value = billingData.totalNumberQuotes;
                    cmd.Parameters.Add("@REF_1", SqlDbType.NVarChar).Value = billingData.accountCode;
                    cmd.Parameters.Add("@SALES_DIST1", SqlDbType.VarChar).Value = billingData.salesCityCode;
                    cmd.Parameters.Add("@ORD_REASON", SqlDbType.VarChar).Value = billingData.orderReason;
                    cmd.Parameters.Add("@PURCH_NO_C1", SqlDbType.NVarChar).Value = billingData.crmContractNumber;
                    cmd.Parameters.Add("@purch_no_s_", SqlDbType.VarChar).Value = billingData.editionNumber;
                    cmd.Parameters.Add("@CURRENCY1", SqlDbType.VarChar).Value = billingData.currency;
                    cmd.Parameters.Add("@pmnttrms", SqlDbType.VarChar).Value = quoteData.termsOfPaymentKey;
                    cmd.Parameters.Add("@COND_TYPE1", SqlDbType.VarChar).Value = quoteData.valueConditionType;
                    cmd.Parameters.Add("@COND_VALUE1", SqlDbType.VarChar).Value = quoteData.quoteConditionValue;
                    cmd.Parameters.Add("@CURRENCY2", SqlDbType.VarChar).Value = billingData.currency;
                    cmd.Parameters.Add("@CONDVALUE1", SqlDbType.VarChar).Value = quoteData.quoteConditionValue;
                    cmd.Parameters.Add("@COND_TYPE2", SqlDbType.VarChar).Value = quoteData.IVAConditionType;
                    cmd.Parameters.Add("@CONDVALUE2", SqlDbType.VarChar).Value = quoteData.IVAconditionRate;
                    cmd.Parameters.Add("@COND_VALUE2", SqlDbType.VarChar).Value = quoteData.IVAConditionValue;
                    cmd.Parameters.Add("@con_st_dat", SqlDbType.DateTime).Value = quoteData.contractStartDate;
                    cmd.Parameters.Add("@con_en_dat", SqlDbType.DateTime).Value = quoteData.contractEndDate;
                    cmd.Parameters.Add("@MATERIAL", SqlDbType.NVarChar).Value = quoteData.materialNumber;
                    cmd.Parameters.Add("@BILL_DATE", SqlDbType.DateTime).Value = quoteData.billingDate;
                    cmd.Parameters.Add("@TARGET_QTY", SqlDbType.VarChar).Value = quoteData.quantity;
                    cmd.Parameters.Add("@TARGET_QU", SqlDbType.VarChar).Value = quoteData.quantityUoM;
                    cmd.Parameters.Add("@PRC_GROUP4", SqlDbType.VarChar).Value = quoteData.quoteNumber;
                    cmd.Parameters.Add("@PURCH_NO_C2", SqlDbType.NVarChar).Value = quoteData.financialContactPhoneNumber;
                    cmd.Parameters.Add("@SALES_DIST2", SqlDbType.VarChar).Value = quoteData.salesDistrict;
                    cmd.Parameters.Add("@PRICE_LIST", SqlDbType.VarChar).Value = quoteData.priceList;
                    cmd.Parameters.Add("@PYMT_METH", SqlDbType.VarChar).Value = quoteData.paymentMethod;
                    cmd.Parameters.Add("@SALES_UNIT", SqlDbType.VarChar).Value = quoteData.salesUnit;
                    cmd.Parameters.Add("@PARTN_ROLE1", SqlDbType.VarChar).Value = billingData.clientPartnerRole;
                    cmd.Parameters.Add("@PARTN_NUMB1", SqlDbType.VarChar).Value = billingData.uniqueClientCode;
                    cmd.Parameters.Add("@ADDR_LINK1", SqlDbType.VarChar).Value = billingData.uniqueClientCode;
                    cmd.Parameters.Add("@PARTN_ROLE2", SqlDbType.VarChar).Value = billingData.billReceiverPartnetRole;
                    cmd.Parameters.Add("@PARTN_NUMB2", SqlDbType.VarChar).Value = billingData.uniqueClientCode;
                    cmd.Parameters.Add("@ADDR_LINK2", SqlDbType.VarChar).Value = billingData.uniqueClientCode;
                    cmd.Parameters.Add("@PARTN_ROLE3", SqlDbType.VarChar).Value = billingData.salesAgentPartnerRole;
                    cmd.Parameters.Add("@PARTN_NUMB3", SqlDbType.NVarChar).Value = billingData.salesAgentCode;
                    cmd.Parameters.Add("@PARTN_ROLE4", SqlDbType.VarChar).Value = billingData.billingChannelPartnerRole;
                    cmd.Parameters.Add("@PARTN_NUMB4", SqlDbType.VarChar).Value = billingData.billingChannel;
                    cmd.Parameters.Add("ADDR_NO", SqlDbType.VarChar).Value = billingData.uniqueClientCode;
                    cmd.Parameters.Add("@CITY", SqlDbType.VarChar).Value = billingData.cityName;
                    cmd.Parameters.Add("@POSTL_COD1", SqlDbType.VarChar).Value = billingData.cityCode;
                    cmd.Parameters.Add("@STREET", SqlDbType.NVarChar).Value = billingData.street;
                    cmd.Parameters.Add("@COUNTRY", SqlDbType.VarChar).Value = billingData.countryCode;
                    cmd.Parameters.Add("@LANGU", SqlDbType.VarChar).Value = billingData.languageCode;
                    cmd.Parameters.Add("@REGION", SqlDbType.VarChar).Value = billingData.region;
                    cmd.Parameters.Add("@NIE__C", SqlDbType.VarChar).Value = billingData.nie;
                    cmd.Parameters.Add("@idOportunidad", SqlDbType.NVarChar).Value = billingData.opportunityId;
                    cmd.Parameters.Add("@idCuenta", SqlDbType.NVarChar).Value = billingData.accountId;
                    cmd.Parameters.Add("@idActivo", SqlDbType.NVarChar).Value = assetData.id;
                    cmd.Parameters.Add("@idProductoCotizacion", SqlDbType.NVarChar).Value = quoteData.producttoPorCotizacion;
                    cmd.Parameters.Add("@idCotizacion", SqlDbType.NVarChar).Value = billingData.idCotizacion;
                    cmd.Parameters.Add("@FACTURADO__C", SqlDbType.VarChar).Value = billingData.billingCheck;
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = billingData.billingDataId;
                    cmd.Parameters.Add("@cuotaname", SqlDbType.NVarChar).Value = quoteData.quoteName;
                    cmd.Parameters.Add("@FactEmail", SqlDbType.NVarChar).Value = billingData.eMailAddress;
                    cmd.Parameters.Add("@FactTel", SqlDbType.NVarChar).Value = billingData.phoneNumber;
                    cmd.Parameters.Add("@FactDir", SqlDbType.NVarChar).Value = billingData.street;
                    cmd.Parameters.Add("@FactFirstQuote", SqlDbType.DateTime).Value = billingData.finalFirstQuoteDate;
                    cmd.Parameters.Add("@idCuotaFacturacion", SqlDbType.NVarChar).Value = quoteData.id;
                    cmd.Parameters.Add("@contratoSAP", SqlDbType.VarChar).Value = billingData.SAPContract;
                    cmd.Parameters.Add("@fechaEnvioFacturacion", SqlDbType.DateTime).Value = System.DateTime.Today;
                    cmd.Parameters.Add("@fechaCorteFacturacion", SqlDbType.DateTime).Value = billingData.billingDate;
                    cmd.Parameters.Add("@quoteStatus", SqlDbType.VarChar).Value = quoteData.status;
                    connect.Open();
                    cmd.ExecuteNonQuery();
                    connect.Close();
                }
                cmd.Dispose();
                connect.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InsertErrorLog(string message)
        {
            try
            {
                connect = new SqlConnection(ConfigurationManager.ConnectionStrings["localTestConnection"].ConnectionString);
                using (cmd = new SqlCommand("spr_InsertErrorLog", connect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = System.DateTime.Today;
                    cmd.Parameters.Add("@message", SqlDbType.VarChar).Value = message;
                }
                cmd.Dispose();
                connect.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
