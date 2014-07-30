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
    public class DAOBilling
    {

        
        private SqlConnection connect = null;
        private SqlCommand cmd = null;
        private SqlDataReader reader = null;

        public List<BOBilling> GetBillingInformation(string limitDay)
        {
            List<BOBilling> BillingdataList = new List<BOBilling>();
            try
            {
                connect = new SqlConnection(ConfigurationManager.ConnectionStrings["SFDynamiaConnection"].ConnectionString);

                using (cmd = new SqlCommand("spr_GetSAPIdBillingDataInformation", connect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LimitDate", SqlDbType.VarChar).Value = limitDay;

                    connect.Open();
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        BOBilling billingData = new BOBilling();
                        billingData.firstQuoteDate = reader["FactFirstQuote"].ToString();
                        billingData.salesDocumentType = reader["DOC_TYPE"].ToString();
                        billingData.distributionChannel = reader["DISTR_CHAN"].ToString();
                        billingData.division = reader["DIVISION"].ToString();
                        billingData.salesOrganization = reader["SALES_ORG"].ToString();
                        billingData.salesCityCode = reader["SALES_DIST1"].ToString();
                        billingData.totalNumberQuotes = reader["PO_SUPPLEM"].ToString();
                        billingData.accountCode = reader["REF_1"].ToString();
                        billingData.orderReason = reader["ORD_REASON"].ToString();
                        billingData.crmContractNumber = reader["PURCH_NO_C1"].ToString();
                        billingData.editionNumber = reader["purch_no_s_"].ToString();
                        billingData.currency = reader["CURRENCY1"].ToString();

                        billingData.uniqueClientCode = reader["partner"].ToString();
                        billingData.salesAgentCode = reader["PARTN_NUMB3"].ToString();
                        billingData.clientPartnerRole = reader["PARTN_ROLE1"].ToString();
                        billingData.billReceiverPartnetRole = reader["PARTN_ROLE2"].ToString();
                        billingData.salesAgentPartnerRole = reader["PARTN_ROLE3"].ToString();
                        billingData.billingChannelPartnerRole = reader["PARTN_ROLE4"].ToString();
                        billingData.billingChannel = reader["PARTN_NUMB4"].ToString();

                        billingData.cityName = reader["CITY"].ToString();
                        billingData.cityCode = reader["POSTL_COD1"].ToString();
                        billingData.street = (reader["FactDir"].ToString()).Truncate(40);
                        billingData.phoneNumber = reader["FactTel"].ToString();
                        billingData.countryCode = reader["COUNTRY"].ToString();
                        billingData.languageCode = reader["LANGU"].ToString();
                        billingData.region = reader["REGION"].ToString();
                        billingData.eMailAddress = reader["FactEmail"].ToString();
                        billingData.billingDataId = reader["id"].ToString();
                        billingData.nie = reader["NIE"].ToString();

                        BillingdataList.Add(billingData);
                    }
                    connect.Close();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return BillingdataList;
        }


        public List<BOBilling> GetAnnulationBillingInformation(string limitDay)
        {
            List<BOBilling> BillingdataList = new List<BOBilling>();
            try
            {
                connect = new SqlConnection(ConfigurationManager.ConnectionStrings["SFDynamiaConnection"].ConnectionString);

                using (cmd = new SqlCommand("spr_GetSAPIdBillingDataAnnulationInfo", connect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LimitDate", SqlDbType.VarChar).Value = limitDay;

                    connect.Open();
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        BOBilling billingData = new BOBilling();
                        billingData.firstQuoteDate = reader["FactFirstQuote"].ToString();
                        billingData.salesDocumentType = reader["DOC_TYPE"].ToString();
                        billingData.distributionChannel = reader["DISTR_CHAN"].ToString();
                        billingData.division = reader["DIVISION"].ToString();
                        billingData.salesOrganization = reader["SALES_ORG"].ToString();
                        billingData.salesCityCode = reader["SALES_DIST1"].ToString();
                        billingData.totalNumberQuotes = reader["PO_SUPPLEM"].ToString();
                        billingData.accountCode = reader["REF_1"].ToString();
                        billingData.orderReason = reader["ORD_REASON"].ToString();
                        billingData.crmContractNumber = reader["PURCH_NO_C1"].ToString();
                        billingData.editionNumber = reader["purch_no_s_"].ToString();
                        billingData.currency = reader["CURRENCY1"].ToString();

                        billingData.uniqueClientCode = reader["partner"].ToString();
                        billingData.salesAgentCode = reader["PARTN_NUMB3"].ToString();
                        billingData.clientPartnerRole = reader["PARTN_ROLE1"].ToString();
                        billingData.billReceiverPartnetRole = reader["PARTN_ROLE2"].ToString();
                        billingData.salesAgentPartnerRole = reader["PARTN_ROLE3"].ToString();
                        billingData.billingChannelPartnerRole = reader["PARTN_ROLE4"].ToString();
                        billingData.billingChannel = reader["PARTN_NUMB4"].ToString();

                        billingData.cityName = reader["CITY"].ToString();
                        billingData.cityCode = reader["POSTL_COD1"].ToString();
                        billingData.street = (reader["FactDir"].ToString()).Truncate(40);
                        billingData.phoneNumber = reader["FactTel"].ToString();
                        billingData.countryCode = reader["COUNTRY"].ToString();
                        billingData.languageCode = reader["LANGU"].ToString();
                        billingData.region = reader["REGION"].ToString();
                        billingData.eMailAddress = reader["FactEmail"].ToString();
                        billingData.billingDataId = reader["id"].ToString();

                        billingData.SAPContract = reader["contratoSAP"].ToString();
                        billingData.modificationItemNumber = reader["ITM_NUMBER"].ToString();
                        billingData.modificationUpdateFlag = reader["updateflag"].ToString();
                        billingData.opportunityId = reader["idOportunidad"].ToString();
                        billingData.accountId = reader["idCuenta"].ToString();
                        billingData.idCotizacion = reader["idCotizacion"].ToString();
                        billingData.nie = reader["NIE"].ToString();

                        BillingdataList.Add(billingData);
                    }
                    connect.Close();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return BillingdataList;
        }


        public void UpdateBillingData(BOBilling billingData, BOAsset asset, BOQuote quote)
        {
            string quoteID = quote.id;
            string assetId = asset.id;
            string billingDataId = billingData.billingDataId;
            string SAPContract = billingData.SAPContract;
            int billingCheck = billingData.billingCheck;
            int failureCheck = billingData.billingFailure;
            DateTime billingDate = billingData.billingDate;
            //DateTime failureDate = billingData.
            DateTime firstQuoteDate = billingData.finalFirstQuoteDate;
            string quoteStatus = quote.status;
            string failuremessage = billingData.billingFailureMessage;

            try
            {
                connect = new SqlConnection(ConfigurationManager.ConnectionStrings["SFDynamiaConnection"].ConnectionString);
                if (billingCheck == 1)
                {
                   using (cmd = new SqlCommand("spr_UpdateBillingData", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@quoteId", SqlDbType.VarChar).Value = quoteID;
                        cmd.Parameters.Add("@assetId", SqlDbType.VarChar).Value = assetId;
                        cmd.Parameters.Add("@billingDataId", SqlDbType.VarChar).Value = billingDataId;
                        cmd.Parameters.Add("@quoteStatus", SqlDbType.VarChar).Value = quoteStatus;
                        cmd.Parameters.Add("@SAPContract", SqlDbType.VarChar).Value = SAPContract;
                        cmd.Parameters.Add("@billingCheck", SqlDbType.Int).Value = billingCheck;
                        cmd.Parameters.Add("@billingDate", SqlDbType.DateTime).Value = billingDate;
                        cmd.Parameters.Add("@finalFirstQuoteDate", SqlDbType.DateTime).Value = firstQuoteDate;
                        
                        connect.Open();
                        cmd.ExecuteNonQuery();
                        connect.Close();
                    }
                }
                else if (failureCheck == 1)
                {
                    using (cmd = new SqlCommand("spr_UpdateBillingDataFailed", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = billingDataId;
                        cmd.Parameters.Add("@failureCheck", SqlDbType.Int).Value = failureCheck;
                        cmd.Parameters.Add("@failureMessage", SqlDbType.VarChar).Value = failuremessage;
                        cmd.Parameters.Add("@failureDate", SqlDbType.DateTime).Value = System.DateTime.Today;

                        connect.Open();
                        cmd.ExecuteNonQuery();
                        connect.Close();
                    }
                }
                cmd.Dispose();
                connect.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void AnnulateQuote(BOBilling billingData, BOQuote quote)
        {
            string quoteID = quote.id;
            string billingDataId = billingData.billingDataId;
            string SAPContract = billingData.SAPContract;
            DateTime annulationDate = System.DateTime.Today;
            //DateTime failureDate = billingData.
            string quoteStatus = quote.status;
            
            try
            {
                connect = new SqlConnection(ConfigurationManager.ConnectionStrings["SFDynamiaConnection"].ConnectionString);

                using (cmd = new SqlCommand("spr_AnnulateBillingData", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@quoteId", SqlDbType.VarChar).Value = quoteID;
                        cmd.Parameters.Add("@billingDataId", SqlDbType.VarChar).Value = billingDataId;
                        cmd.Parameters.Add("@quoteStatus", SqlDbType.VarChar).Value = quoteStatus;
                        cmd.Parameters.Add("@SAPContract", SqlDbType.VarChar).Value = SAPContract;
                        cmd.Parameters.Add("@annulationDate", SqlDbType.DateTime).Value = annulationDate;

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

        public void truncateBillingTable(string table)
        {
            try
            {
                connect = new SqlConnection(ConfigurationManager.ConnectionStrings["SFDynamiaConnection"].ConnectionString);

                {
                    using (cmd = new SqlCommand("spr_TruncateTables", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@table", SqlDbType.VarChar).Value = table;

                        connect.Open();
                        cmd.ExecuteNonQuery();
                        connect.Close();
                    }


                    cmd.Dispose();
                    connect.Dispose();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
       
    }
}
