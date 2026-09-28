using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.KitchenTicket
{
   
    

    public sealed class EstimationReadyMinutes
    {
        public int Calculate( IReadOnlyList<(string Item, List<string> Ingredients, int PrepMinutes)> items,int openStations, int allergenCount)
        {
            if (openStations <= 0) openStations = 1;
            var sequential = items.Sum(i => i.PrepMinutes);
            var parallel = (int)Math.Ceiling(sequential / (double)openStations);
            if (allergenCount > 0) parallel += 3; // allergy protocol delay mixed in
            var longest = items.Count == 0 ? 0 : items.Max(i => i.PrepMinutes);
            return Math.Max(parallel, longest);

        }
}
}
