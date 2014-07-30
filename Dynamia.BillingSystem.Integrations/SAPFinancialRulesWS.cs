using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamia.BillingSystem.Integrations
{
    public class SAPFinancialRulesWS
    {
        public static DateTime GetBillingDate()
        {
            SAPFinancialRulesService.ZSD_VAL_FI_WEBSERVICE financialRules = new SAPFinancialRulesService.ZSD_VAL_FI_WEBSERVICE();
            financialRules.I_CANAL_FAC = "171";
            financialRules.I_ID_USUARIO = "1";
            financialRules.I_MONEDA = "COP";
            financialRules.I_ORG_VENTAS = "0004";

            financialRules.IT_CUOTAS = new SAPFinancialRulesService.ZSD_CUOTAS3[1];
            financialRules.IT_CUOTAS[0] = new SAPFinancialRulesService.ZSD_CUOTAS3();
            financialRules.IT_CUOTAS[0].MATNR = "5029800000000000";
            financialRules.IT_CUOTAS[0].Z_ID_CUOT = "1";
            financialRules.IT_CUOTAS[0].ZFECCT = System.DateTime.Today.ToString("yyyy-MM-dd");
            financialRules.IT_CUOTAS[0].ZVALCTSpecified = true;
            financialRules.IT_CUOTAS[0].ZVALCT = 1000000;

            SAPFinancialRulesService.svc_SI_ReglasSAPFI_OutClient RespfinancialRules = new SAPFinancialRulesService.svc_SI_ReglasSAPFI_OutClient();
            
            var RulesResponse = RespfinancialRules.OP_ReglasSAPFI_Out(financialRules);

            RespfinancialRules.Close();

            var billDate = System.Convert.ToDateTime(RulesResponse.ET_FEC_CANT[0].FECVL);
            var lastMonthDay = DateTime.DaysInMonth(billDate.Year, billDate.Month);
            var LimitDay = System.Convert.ToDateTime(System.Convert.ToString(billDate.Year) + '-' + System.Convert.ToString(billDate.Month) + '-' + System.Convert.ToString(lastMonthDay));

            return billDate;
        }

        public static DateTime GetLimitDay(DateTime billingDate)
        {
            var lastMonthDay = DateTime.DaysInMonth(billingDate.Year, billingDate.Month);
            var LimitDay = System.Convert.ToDateTime(System.Convert.ToString(billingDate.Year) + '-' + System.Convert.ToString(billingDate.Month) + '-' + System.Convert.ToString(lastMonthDay));
            return LimitDay;
        }
                
    }
}
