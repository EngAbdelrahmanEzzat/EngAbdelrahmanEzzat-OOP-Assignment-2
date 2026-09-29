using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.LoanDesk
{
    public sealed class UnderwriterCsvExporter
    {
        public string UnderwriterCsvRow(string applicationId, LoanDesk1 l, decimal riskScore,  bool isEligible)
        {
            // Analytics export schema is yet another reason to change.
            return $"{applicationId},{l.CreditScore},{l.EmploymentMonths},{(l.HasCollateral ? 1 : 0)},{riskScore:0.00},{(isEligible ? "Y" : "N")}";
        }
    }
}
