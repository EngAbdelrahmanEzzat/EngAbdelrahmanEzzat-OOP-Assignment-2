using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.LoanDesk
{
    public sealed class LoanDecisionLetter
    {
        public string DecisionLetter(string applicantName,bool iseligible, decimal requestedAmount, decimal riskscore, IReadOnlyList<string> documents)
        {
            // Legal/comms wording ≠ underwriting math.
            if(iseligible)
            {
                return $"Dear {applicantName},\nYour request for {requestedAmount:C} is pre-approved (risk {riskscore:0}).\n" +
                       $"Please upload: {string.Join("; ", documents)}.\n";
            }

            return $"Dear {applicantName},\nWe are unable to approve {requestedAmount:C} at this time.\n" +
                   $"Reference risk={riskscore:0}. You may reapply after improving documentation.\n";
        }

    }
}
