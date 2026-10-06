using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.CheckoutBasket
{

    public sealed class CheckoutPricing
    {
        private readonly CheckoutBasket1 _basket;

        public CheckoutPricing(CheckoutBasket1 basket)
        {
            _basket = basket;
        }

        public decimal SubTotal() => _basket.Lines.Sum(l => l.Price * l.Qty);

        public decimal DiscountAmount()
        {
            // Parsing marketing strings is a different reason to change than pricing math.
            if (string.IsNullOrWhiteSpace(_basket.CouponRaw)) return 0m;

            var t = _basket.CouponRaw.Trim().ToUpperInvariant();

            if (t.StartsWith("SAVE") &&
                int.TryParse(t[4..], out var pct) &&
                pct is > 0 and <= 50)
                return Math.Round(SubTotal() * pct / 100m, 2);

            if (t.Contains("FREESHIP")) return 0m;

            if (t == "WELCOME10") return Math.Min(10m, SubTotal());

            return 0m;
        }
    }
}
