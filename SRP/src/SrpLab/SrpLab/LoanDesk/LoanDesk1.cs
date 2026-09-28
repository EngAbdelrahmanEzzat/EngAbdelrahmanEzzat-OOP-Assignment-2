using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.LoanDesk
{
    public sealed class LoanDesk1
    {
        public decimal RequestedAmount { get; }
        public int CreditScore { get; }
        public int EmploymentMonths { get; }
        public bool HasCollateral { get; }

        public LoanDesk1(decimal requestedAmount, int creditScore, int employmentMonths, bool hasCollateral)
        {
            RequestedAmount = requestedAmount;
            CreditScore = creditScore;
            EmploymentMonths = employmentMonths;
            HasCollateral = hasCollateral;
        }
    }
}
