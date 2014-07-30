using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamia.BillingSystem.BusinessManager;
using Dynamia.BillingSystem.SQLDAO;

namespace Dynamia.BillingSystem.SQLDAO
{
    public class DAOFacade
    {
        private DAOBilling daoSalesForce;
        private DAOAsset daoAsset;
        private DAOQuote daoQuote;
        private DAOLogs daoLog;

        public List<BOBilling> GetBillingInformation(string limitDay)
        {
            daoSalesForce = new DAOBilling();
            return daoSalesForce.GetBillingInformation(limitDay);
        }

        public List<BOBilling> GetAnnulationBillingInformation(string limitDay)
        {
            daoSalesForce = new DAOBilling();
            return daoSalesForce.GetAnnulationBillingInformation(limitDay);
        }
                
        public List<BOAsset> GetAssetInformation(string limitDay, string billingDataId)
        {
            daoAsset = new DAOAsset();
            return daoAsset.GetAssetsInformation(limitDay, billingDataId);
        }

        public List<BOAsset> GetAssetsAnulationInformation(string limitDay, string billingDataId)
        {
            daoAsset = new DAOAsset();
            return daoAsset.GetAssetsAnulationInformation(limitDay, billingDataId);
        }

        public void TruncateBillingTable(string table)
        {
            daoSalesForce = new DAOBilling();
            daoSalesForce.truncateBillingTable(table);
        }

        public void UpdateBillingData(BOBilling billingData, BOAsset asset, BOQuote quote)
        {
            daoSalesForce = new DAOBilling();
            daoSalesForce.UpdateBillingData(billingData, asset, quote);
        }

        public void annulateQuote(BOBilling billingData, BOQuote quote)
        {
            daoSalesForce = new DAOBilling();
            daoSalesForce.AnnulateQuote(billingData, quote);
        }

        public void UpdateAsset(BOAsset asset)
        {
            daoAsset = new DAOAsset();
            daoAsset.UpdateAsset(asset);
        }

        public void UpdateQuote(BOQuote quote)
        {
            daoQuote = new DAOQuote();
            daoQuote.UpdateQuote(quote);
        }

        public void updateLog(BOBilling billingData, BOAsset assetData, BOQuote quoteData)
        {
            daoLog = new DAOLogs();
            daoLog.UpdateLog(billingData, assetData, quoteData);
        }

        public void InsertErrorLog(string message)
        {
            daoLog = new DAOLogs();
            daoLog.InsertErrorLog(message);
        }
    }
}
