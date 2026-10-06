using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.CheckoutBasket
{
    public sealed class GiftMessageCard
    {
        private readonly CheckoutBasket1 _basket;
        private readonly CheckoutTotal _total;

        public GiftMessageCard(
            CheckoutBasket1 basket,
            CheckoutTotal total)
        {
            _basket = basket;
            _total = total;
        }

        public string GiftCard(string fromName)
        {
            var items = string.Join(", ", _basket.Lines.Select(l => l.Sku));
            return $"Dear friend,\nA gift from {fromName} awaits ({items}).\nTotal surprise value: {_total.GrandTotal():C}\n";
        }
    }
}
