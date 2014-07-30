using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamia.BillingSystem.BusinessManager;

namespace Dynamia.BillingSystem.Controller
{
    public class DBCheckController
    {
        public BOBillingDataCheckFalied BillingDataCheckFailed(BOBilling billingData, string message)
        {
            BOBillingDataCheckFalied billingDataCheckFailed = new BOBillingDataCheckFalied();

            billingDataCheckFailed.billingDataId = billingData.billingDataId;
            billingDataCheckFailed.FailureCheck = 1;
            billingDataCheckFailed.failureDate = DateTime.Today;
            billingDataCheckFailed.emessage = message;
            return billingDataCheckFailed;
        }

    
    }
}

