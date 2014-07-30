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
    public class DAOQuote
    {
        private SqlConnection connect = null;
        private SqlCommand cmd = null;
        private SqlDataReader reader = null;

        public void UpdateQuote(BOQuote quote)
        {
            string id = quote.id;
            string status = quote.status;
            //DateTime annulationDate = quote.annulationDate;
            try
            {
                connect = new SqlConnection(ConfigurationManager.ConnectionStrings["localTestConnection"].ConnectionString);
                using (cmd = new SqlCommand("spr_UpdateBillingQuoteStatus", connect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                    cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
                    
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
