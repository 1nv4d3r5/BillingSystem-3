using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamia.BillingSystem.BusinessManager
{
    public class BOAsset
    {
        public string id { get; set; }
        public int billingCheck { get; set; }
        public DateTime billingDate { get; set; }
        public List<BOQuote> quoteList { get; set; }

        public BOAsset() {
            id = string.Empty;
            billingCheck = 0;
            billingDate = new DateTime();
            quoteList = new List<BOQuote>();
        }
    }
}
