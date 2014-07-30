using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamia.BillingSystem.BusinessManager
{
    public class BOBillingDataCheck
    {
        
        public string billingDataId {get; set;}
        public string assetId { get; set; }
        public string SAPContract { get; set;}
        public int billingCheck {get; set;}
        public DateTime billingDate { get; set; }
        public DateTime firstQuoteDate { get; set; }
        public string emessage { get; set; }
         
    }
}
