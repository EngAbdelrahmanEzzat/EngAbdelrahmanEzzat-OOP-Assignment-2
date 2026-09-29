using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.KitchenTicket
{
   

    public sealed class ThermalTicketBuilder
    {
        public string Build(
            int orderNumber,
            IReadOnlyList<(string Item, List<string> Ingredients, int PrepMinutes)> items,
            int EstimatedReadyMinutes,
            IReadOnlyList<string> allergens)
        {
            // Hardware/formatting concerns — width, separators — change with printer vendor.
            var width = 32;
            var line = new string('=', width);
           var body = string.Join('\n', items.Select(i => $"* {i.Item.ToUpperInvariant()} ({i.PrepMinutes}m)"));        
            var allergyLine = allergens.Count == 0 ? "ALLERGENS: none" : "ALLERGENS: " + string.Join(",", allergens);
            return $"{line}\nORDER #{orderNumber}\nETA {EstimatedReadyMinutes} MIN\n{body}\n{allergyLine}\n{line}\n";
        }
    }
}
