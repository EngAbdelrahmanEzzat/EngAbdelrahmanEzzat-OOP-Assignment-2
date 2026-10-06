using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.WareHousePickList
{
   

    public sealed class WarehousePickList1
    {
        private readonly List<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> _lines = new();

        public void AddNeed(string sku, string aisle, int bin, int qtyNeeded, int qtyOnHand)
        {
            _lines.Add((sku, aisle, bin, qtyNeeded, qtyOnHand));
        }

        public IReadOnlyList<(string Sku, int Allocated)> Allocate()
        {
            var result = new List<(string, int)>();

            foreach (var line in _lines)
            {
                var alloc = Math.Min(line.QtyNeeded, line.QtyOnHand);
                result.Add((line.Sku, alloc));
            }

            return result;
        }

     
    }
}
