using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.SubscriptionBilling
{
    public sealed class SubscriptionBilling
    {
       
        public string CustomerId { get; }
        public decimal MonthlyPrice { get; }
        public DateOnly PeriodStart { get; }
        public DateOnly PeriodEnd { get; }
        public int FailedPayments { get; private set; }

        public SubscriptionBilling(string customerId, decimal monthlyPrice, DateOnly periodStart, DateOnly periodEnd)
        {
            CustomerId = customerId;
            MonthlyPrice = monthlyPrice;
            PeriodStart = periodStart;
            PeriodEnd = periodEnd;
        }

        public void RegisterFailedPayment() => FailedPayments++;

    }

}
