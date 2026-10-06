using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.CheckoutBasket
{
    // CheckoutBasket.cs

    public sealed class CheckoutBasket1
    {
        private readonly List<(string Sku, decimal Price, int Qty)> _lines = new();
        private string? _couponRaw;
        private bool _giftWrap;

        public void AddLine(string sku, decimal price, int qty)
        {
            if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
            _lines.Add((sku, price, qty));
        }

        public void ApplyCouponText(string? couponText) => _couponRaw = couponText;

        public void EnableGiftWrap() => _giftWrap = true;

        public IReadOnlyList<(string Sku, decimal Price, int Qty)> Lines => _lines;
        public string? CouponRaw => _couponRaw;
        public bool GiftWrap => _giftWrap;
    }
}
