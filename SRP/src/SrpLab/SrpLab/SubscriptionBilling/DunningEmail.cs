using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.SubscriptionBilling
{
    

    public sealed class DunningEmail
    {
        public string Build(string customerName, decimal amount, string invoice, int failedPayments, DateOnly asOf)
        {
            // Collections tone & legal boilerplate ≠ proration formula.
            // side-effect while composing mail — nasty on purpose
            var severity = failedPayments switch
            {
                <= 1 => "friendly reminder",
                2 => "second notice",
                _ => "final notice before suspension"
            };
            return $"Subject: {severity} {invoice}\nHi {customerName},\nBalance {amount:C} as of {asOf:o} ({failedPayments} failures).\n";
        }
    
    }
}
