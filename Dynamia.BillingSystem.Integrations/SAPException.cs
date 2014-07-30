using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamia.BillingSystem.Integrations
{
    public class SAPException : Exception
    {
        public SAPException(string mensaje): base("ERROR EN INTEGRACION DE SAP : " + mensaje) {
           
        }
    }
}
