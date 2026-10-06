using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.CheckoutBasket
{
    
    public sealed class CheckoutTotal
    {
        private readonly CheckoutBasket1 _basket;
        private readonly CheckoutPricing _pricing;

        public CheckoutTotal(
            CheckoutBasket1 basket,
            CheckoutPricing pricing)
        {
            _basket = basket;
            _pricing = pricing;
        }

        public decimal GrandTotal()
        {
            var total = _pricing.SubTotal() - _pricing.DiscountAmount();

            if (_basket.GiftWrap) total += 4.99m;

            return Math.Max(0m, total);
        }
    }
}
