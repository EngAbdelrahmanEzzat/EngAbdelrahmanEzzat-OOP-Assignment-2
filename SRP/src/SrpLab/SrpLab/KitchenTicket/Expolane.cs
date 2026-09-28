using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.KitchenTicket
{
   
    public sealed class ExpoLane
    {
        public string Decide(
            int allergenCount,
            int EstimatedReadyMinutes)
        {
            if (allergenCount > 0)
                return "LANE-ALLERGY";

            if (EstimatedReadyMinutes > 20)
                return "LANE-SLOW";

            return "LANE-FAST";
        }
    }
}
