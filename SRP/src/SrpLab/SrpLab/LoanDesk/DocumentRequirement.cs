using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.LoanDesk
{
    public sealed class DocumentRequirement
    {
        public IReadOnlyList<string> RequiredDocuments(LoanDesk1 loan,bool isEligible)
        {
            // Compliance checklist changes with regulation, independently of risk formula.
            var docs = new List<string> { "National ID", "Proof of income (3 months)" };
            if (loan.RequestedAmount > 40_000m) docs.Add("Bank statements (6 months)");
            if (loan.HasCollateral) docs.Add("Collateral ownership deed");
            if (loan.EmploymentMonths < 12) docs.Add("Employer letter");
            if (!isEligible) docs.Add("Manual underwriter referral form");
            return docs;
        }
    }
}
