using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.SubscriptionBilling
{
    

    public sealed class InvoiceNumber
    {
        private static int _invoiceSeq = 1000;

        public string Generate(DateOnly periodStart)
        {
            var n = ++_invoiceSeq;
            return $"INV-{periodStart:yyyyMM}-{n:D5}";
        }
    }
}
