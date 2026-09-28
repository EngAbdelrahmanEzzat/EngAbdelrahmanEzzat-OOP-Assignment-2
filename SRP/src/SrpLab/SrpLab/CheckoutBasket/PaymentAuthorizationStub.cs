using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.CheckoutBasket
{

    public sealed class PaymentAuthorizationStub
    {
        private readonly CheckoutBasket1 _basket;
        private readonly CheckoutTotal _total;

        public PaymentAuthorizationStub(
            CheckoutBasket1 basket,
            CheckoutTotal total)
        {
            _basket = basket;
            _total = total;
        }

        public string AuthorizePaymentStub(string cardLast4)
        {
            var payload = $"{_total.GrandTotal():0.00}|{cardLast4}|{_basket.Lines.Count}";
            var hash = payload.GetHashCode();
            return $"AUTH-{Math.Abs(hash):X8}";
        }
    }
}
