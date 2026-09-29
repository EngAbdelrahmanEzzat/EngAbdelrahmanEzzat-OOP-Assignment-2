using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.WareHousePickList
{
    

    public sealed class WarehousePath
    {
        public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> GetWalkingOrder(
            IReadOnlyList<(string Sku, string Aisle, int Bin, int Qty)> lines)
        {
            return lines
                .OrderBy(l => l.Aisle)
                .ThenBy(l => l.Bin)
                .Select(l => (l.Aisle, l.Bin, l.Sku, l.Qty))
                .ToList();
        }
    }
}
