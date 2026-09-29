using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Members
{
    public class Member : Person
    {
        public int MaxLoans { get; }

        public double DicountPrecentage { get; }

        private readonly List<Loan> _loans = new();

        public IReadOnlyList<Loan> Loans => _loans;

        protected Member(int id, string fullName, string phone, int maxLoans, double discontPercentage)
        : base(id, fullName, phone)
        {
            if (maxLoans <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxLoans), "MaxLoans Must be greater than 0");
            if (discontPercentage < 0)
                throw new ArgumentOutOfRangeException(nameof(discontPercentage), "Discount must be greater than or equal 0");
            MaxLoans = maxLoans;
            DicountPrecentage = discontPercentage;
        }



        public void Borrow(Loan loan)
        {
            if (_loans.Count >= MaxLoans)
                throw new InvalidOperationException("Maximum loan limit reached.");

            _loans.Add(loan);
        }
    }
}
