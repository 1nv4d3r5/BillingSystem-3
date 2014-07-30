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
    public class DAOAsset
    {
        private SqlConnection connect = null;
        private SqlCommand cmd = null;
        private SqlDataReader reader = null;

        public List<BOAsset> GetAssetsInformation(string limitDay, string billingDataId)
        {
            List<BOAsset> assetsList = new List<BOAsset>();

            string prevAssetId = string.Empty;

            List<BOQuote> QuotedataList = new List<BOQuote>();

            try
            {
                connect = new SqlConnection(ConfigurationManager.ConnectionStrings["localTestConnection"].ConnectionString);

                using (cmd = new SqlCommand("spr_GetSAPBillingQuotesInformation", connect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LimitDate", SqlDbType.VarChar).Value = limitDay;
                    cmd.Parameters.Add("@IdBilling", SqlDbType.VarChar).Value = billingDataId;

                    connect.Open();
                    reader = cmd.ExecuteReader();

                    BOAsset actualAsset = null;

                    int flag = 0;
                    
                    while (reader.Read())
                    {

                        BOQuote quoteData = new BOQuote();

                        quoteData.valueConditionType = reader["COND_TYPE1"].ToString();
                        quoteData.IVAConditionType = reader["COND_TYPE2"].ToString();
                        quoteData.quoteConditionValue = reader["COND_VALUE1"].ToString();
                        quoteData.IVAConditionValue = reader["COND_VALUE2"].ToString();
                        quoteData.IVAconditionRate = reader["CONDVALUE2"].ToString();

                        quoteData.contractStartDate = reader["con_st_dat"].ToString();
                        quoteData.contractEndDate = reader["con_en_dat"].ToString();

                        quoteData.materialNumber = reader["MATERIAL"].ToString();
                        quoteData.billingDate = reader["BILL_DATE"].ToString();
                        quoteData.salesDistrict = reader["SALES_DIST2"].ToString();
                        quoteData.termsOfPaymentKey = reader["pmnttrms"].ToString();
                        quoteData.paymentMethod = reader["PYMT_METH"].ToString();
                        quoteData.salesUnit = reader["SALES_UNIT"].ToString();
                        quoteData.quoteName = reader["cuotaname"].ToString();
                        quoteData.quoteNumber = reader["PRC_GROUP4"].ToString();
                        quoteData.financialContactPhoneNumber = reader["PURCH_NO_C2"].ToString();
                        quoteData.quantity = reader["TARGET_QTY"].ToString();
                        quoteData.quantityUoM = reader["TARGET_QU"].ToString();
                        quoteData.priceList = reader["PRICE_LIST"].ToString();

                        quoteData.status = reader["quoteStatus"].ToString();
                        quoteData.id = reader["quoteId"].ToString();
                        quoteData.producttoPorCotizacion = reader["idProductoCotizacion"].ToString();

                        if (reader["idActivo"].ToString() != prevAssetId)
                        {
                            if (prevAssetId != string.Empty)
                            {
                                assetsList.Add(actualAsset);
                            }
                            prevAssetId = reader["idActivo"].ToString();
                            actualAsset = new BOAsset();
                            actualAsset.id = reader["idActivo"].ToString();
                            actualAsset.billingDate = DateTime.Today;
                            flag = 1;
                        }
                        else
                        {
                            flag = 0;
                        }

                        actualAsset.quoteList.Add(quoteData);

                        
                    }

                    if (flag == 0)
                    {
                        assetsList.Add(actualAsset);
                    }

                    connect.Close();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return assetsList;
        }


        public List<BOAsset> GetAssetsAnulationInformation(string limitDay, string billingDataId)
        {
            List<BOAsset> assetsList = new List<BOAsset>();

            string prevAssetId = string.Empty;

            List<BOQuote> QuotedataList = new List<BOQuote>();

            try
            {
                connect = new SqlConnection(ConfigurationManager.ConnectionStrings["localTestConnection"].ConnectionString);

                using (cmd = new SqlCommand("spr_GetSAPBillingQuotesAnnulationInfo", connect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LimitDate", SqlDbType.VarChar).Value = limitDay;
                    cmd.Parameters.Add("@IdBilling", SqlDbType.VarChar).Value = billingDataId;

                    connect.Open();
                    reader = cmd.ExecuteReader();

                    BOAsset actualAsset = null;

                    int flag = 0;

                    while (reader.Read())
                    {

                        BOQuote quoteData = new BOQuote();

                        quoteData.valueConditionType = reader["COND_TYPE1"].ToString();
                        quoteData.IVAConditionType = reader["COND_TYPE2"].ToString();
                        quoteData.quoteConditionValue = reader["COND_VALUE1"].ToString();
                        quoteData.IVAConditionValue = reader["COND_VALUE2"].ToString();
                        quoteData.IVAconditionRate = reader["CONDVALUE2"].ToString();

                        quoteData.contractStartDate = reader["con_st_dat"].ToString();
                        quoteData.contractEndDate = reader["con_en_dat"].ToString();

                        quoteData.materialNumber = reader["MATERIAL"].ToString();
                        quoteData.billingDate = reader["BILL_DATE"].ToString();
                        quoteData.salesDistrict = reader["SALES_DIST2"].ToString();
                        quoteData.termsOfPaymentKey = reader["pmnttrms"].ToString();
                        quoteData.paymentMethod = reader["PYMT_METH"].ToString();
                        quoteData.salesUnit = reader["SALES_UNIT"].ToString();
                        quoteData.quoteName = reader["cuotaname"].ToString();
                        quoteData.quoteNumber = reader["PRC_GROUP4"].ToString();
                        quoteData.financialContactPhoneNumber = reader["PURCH_NO_C2"].ToString();
                        quoteData.quantity = reader["TARGET_QTY"].ToString();
                        quoteData.quantityUoM = reader["TARGET_QU"].ToString();
                        quoteData.priceList = reader["PRICE_LIST"].ToString();

                        quoteData.status = reader["quoteStatus"].ToString();
                        quoteData.id = reader["quoteId"].ToString();
                        quoteData.producttoPorCotizacion = reader["idProductoCotizacion"].ToString();

                        if (reader["idActivo"].ToString() != prevAssetId)
                        {
                            if (prevAssetId != string.Empty)
                            {
                                assetsList.Add(actualAsset);
                            }
                            prevAssetId = reader["idActivo"].ToString();
                            actualAsset = new BOAsset();
                            actualAsset.id = reader["idActivo"].ToString();
                            actualAsset.billingDate = DateTime.Today;
                            flag = 1;
                        }
                        else
                        {
                            flag = 0;
                        }

                        actualAsset.quoteList.Add(quoteData);


                    }

                    if (flag == 0)
                    {
                        assetsList.Add(actualAsset);
                    }

                    connect.Close();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return assetsList;
        }


        public void UpdateAsset(BOAsset asset)
        {
            string id = asset.id;
            int billingCheck = asset.billingCheck;
            DateTime billingDate = asset.billingDate;

            try
            {
                connect = new SqlConnection(ConfigurationManager.ConnectionStrings["localTestConnection"].ConnectionString);
                using (cmd = new SqlCommand("spr_UpdateAssetBillingData", connect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                    cmd.Parameters.Add("@billingCheck", SqlDbType.Int).Value = billingCheck;
                    cmd.Parameters.Add("@billingDate", SqlDbType.Date).Value = billingDate;


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
    }
}
