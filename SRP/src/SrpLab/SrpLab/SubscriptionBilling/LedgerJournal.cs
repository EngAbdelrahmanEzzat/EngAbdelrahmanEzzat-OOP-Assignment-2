using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.SubscriptionBilling
{
    

    public sealed class LedgerJournal
    {
        public string Build(string customerId,string invoiceNumber,decimal amount)
        {
            return $"{customerId},{invoiceNumber},{amount:0.00},AR-SUB";
        }
    }
}
