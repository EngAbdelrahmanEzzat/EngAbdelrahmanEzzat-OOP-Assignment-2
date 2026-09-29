using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.WareHousePickList
{

    public sealed class Warehousepicker
    {
        public string Build(
            IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> walkingOrder,
            IReadOnlyList<(string Sku, int Allocated)> allocations,
            IReadOnlyList<(string Sku, string Aisle, int Bin, int Qty)> originalLines)
        {
            var steps = walkingOrder
                .Select((s, i) =>
                    $"{i + 1}. Go aisle {s.Aisle} bin {s.Bin}: pick {s.Qty} × {s.Sku}");

            var shortfalls = allocations.Where(a =>
            {
                var need = originalLines.First(l => l.Sku == a.Sku).Qty;
                return a.Allocated < need;
            });

            var warn = shortfalls.Any()
                ? "SHORTAGES: " + string.Join(", ", shortfalls.Select(s => s.Sku))
                : "SHORTAGES: none";

            return string.Join('\n', steps) + "\n" + warn;
        }
    }
}
