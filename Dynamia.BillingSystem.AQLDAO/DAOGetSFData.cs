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

namespace Dynamia.BillingSystem.AQLDAO
{
    public class DAOGetSFData
    {
        private SqlConnection connect = null;
        private SqlCommand cmd = null;
        private SqlDataReader reader = null;

        public BOBilling GetBillingInformation(DateTime limitDay)
        {
            BOBilling Billingdata = null;
            connect = new SqlConnection(ConfigurationManager.ConnectionStrings["SFDynamiaConnection"].ConnectionString);

            using (cmd = new SqlCommand("spr_GetSAPIdBillingDataInformation", connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LimitDay", SqlDbType.Date).Value = limitDay;

                connect.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Billingdata = new BOBilling();

                    Billingdata.salesDocumentType = reader["DOC_TYPE"].ToString();
                    Billingdata.distributionChannel = reader["DISTR_CHAN"].ToString();
                    Billingdata.division = reader["DIVISION"].ToString();
                    Billingdata.salesOrganization = reader["SALES_ORG"].ToString();
                    Billingdata.salesCityCode = reader["SALES_DIST1"].ToString();
                    Billingdata.totalNumberQuotes = reader["PO_SUPPLEM"].ToString();
                    Billingdata.accountCode = reader["REF_1"].ToString();
                    Billingdata.orderReason = reader["ORD_REASON"].ToString();
                    Billingdata.crmContractNumber = reader["PURCH_NO_C1"].ToString();
                    Billingdata.currency = reader["CURRENCY1"].ToString();

                    Billingdata.uniqueClientCode = reader["partner"].ToString();
                    Billingdata.salesAgentCode = reader["PARTN_NUMB3"].ToString();

                    Billingdata.cityName = reader["CITY"].ToString();
                    Billingdata.cityCode = reader["POSTL_COD1"].ToString();
                    Billingdata.street = reader["FactDir"].ToString();
                    Billingdata.phoneNumber = reader["FactTel"].ToString();
                    Billingdata.countryCode = reader["COUNTRY"].ToString();
                    Billingdata.languageCode = reader["LANGU"].ToString();
                    Billingdata.region = reader["REGION"].ToString();
                    Billingdata.eMailAddress = reader["FactEmail"].ToString();
                }
            }
            return null;
        }
    }
}
