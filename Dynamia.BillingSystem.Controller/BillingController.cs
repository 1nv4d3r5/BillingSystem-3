using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamia.BillingSystem.BusinessManager;
using Dynamia.BillingSystem.SQLDAO;
using Dynamia.BillingSystem.Integrations;

namespace Dynamia.BillingSystem.Controller
{
    public class BillingController
    {

        //Facturacion standar de Dynamia
        public void CreateDynamiaBilling()
        {
            DBCheckController checkController = new DBCheckController();
            DateTime billingDate = SAPFinancialRulesWS.GetBillingDate();
            var lastMonthDay = DateTime.DaysInMonth(billingDate.Year, billingDate.Month);
            var limitDay = System.Convert.ToString(billingDate.Year) + '-' + System.Convert.ToString(billingDate.Month) + '-' + System.Convert.ToString(lastMonthDay);
            DAOFacade daoFacade = new DAOFacade();
            daoFacade.TruncateBillingTable("UDB");
            List<BOBilling> BOBillingList = daoFacade.GetBillingInformation(limitDay);

            foreach (BOBilling billingData in BOBillingList)
            {
                try
                {
                    BOBilling actualBillingData = billingData;
                    List<BOAsset> assets = daoFacade.GetAssetInformation(limitDay, billingData.billingDataId);
                    billingData.billingAssets = assets;

                    SAPCreateContractWS.CreateContractService(ref actualBillingData, billingDate);
                    //daoFacade.UpdateBillingInformation(actualBillingData);
                    foreach (BOAsset asset in actualBillingData.billingAssets)
                    {
                        //daoFacade.UpdateAsset(asset);
                        foreach (BOQuote quote in asset.quoteList)
                        {
                            daoFacade.UpdateBillingData(billingData, asset, quote);
                            daoFacade.updateLog(billingData, asset, quote);
                        }
                    }


                }
                catch (SAPException e)
                {
                    string message = "se presento un error en el proceso de facturacion: " + e.Message;
                    daoFacade.InsertErrorLog(message);
                }

            }
        
        }

        public void AnnulateBilling()
        {
            DBCheckController checkController = new DBCheckController();
            DateTime billingDate = SAPFinancialRulesWS.GetBillingDate();
            var lastMonthDay = DateTime.DaysInMonth(billingDate.Year, billingDate.Month);
            var limitDay = System.Convert.ToString(billingDate.Year) + '-' + System.Convert.ToString(billingDate.Month) + '-' + System.Convert.ToString(lastMonthDay);
            DAOFacade daoFacade = new DAOFacade();
            daoFacade.TruncateBillingTable("AQ");
            List<BOBilling> BOBillingList = daoFacade.GetAnnulationBillingInformation(limitDay);
            
            foreach (BOBilling billingData in BOBillingList)
            {
                if (billingData.billingDataId != "a0N4000000XPZe7EAH")
                {
                    try
                    {
                        BOBilling actualBillingData = billingData;
                        List<BOAsset> assets = daoFacade.GetAssetsAnulationInformation(limitDay, billingData.billingDataId);
                        billingData.billingAssets = assets;
                        SAPModifyContractWS.ModifyContractService(ref actualBillingData, billingDate);
                        foreach (BOAsset asset in actualBillingData.billingAssets)
                        {

                            foreach (BOQuote quote in asset.quoteList)
                            {
                                daoFacade.annulateQuote(billingData, quote);
                            }
                        }


                    }
                    catch (SAPException e)
                    {
                        string message = "se presento un error en el proceso de facturacion: " + e.Message;
                        daoFacade.InsertErrorLog(message);
                    }
                }

            }

        }

    }
}
