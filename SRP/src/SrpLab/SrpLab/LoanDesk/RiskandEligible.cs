using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.LoanDesk
{
    public sealed class RiskandEligible
    {
        public decimal RiskScore(LoanDesk1 l)
        {
            // Risk model will change with risk committee — not with letter templates.
            decimal score = 100m;
            score -= Math.Max(0, 700 - l.CreditScore) * 0.15m;
            if (l.EmploymentMonths < 6) score -= 20m;
            if (l.RequestedAmount > 50_000m && !l.HasCollateral) score -= 25m;
            if (l.RequestedAmount > 150_000m) score -= 10m;
            return Math.Clamp(score, 0m, 100m);
        }

        public bool IsEligible(LoanDesk1 loan)
        {
            return RiskScore(loan) >= 55m &&
                   loan.CreditScore >= 580;
        }

    }
}
