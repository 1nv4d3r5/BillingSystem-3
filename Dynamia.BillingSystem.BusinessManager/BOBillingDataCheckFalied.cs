using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamia.BillingSystem.BusinessManager
{
    public class BOBillingDataCheckFalied
    {
        public string billingDataId { get; set; }
        
       
        public int FailureCheck { get; set; }
        public DateTime failureDate { get; set; }
        public string emessage { get; set; }
    }
}
