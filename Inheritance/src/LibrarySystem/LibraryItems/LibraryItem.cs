using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.LibraryItems
{
    public class LibraryItem
    {
        public int CatalogNumber { get; }
        public string Title { get; }

        public int LoanPeriod { get; }
        public double BaseLateFee { get; private set; }

        public bool IsWithdrawn { get; private set; }
        public bool IsOnLoan { get; private set; }

        protected LibraryItem(
            int catalogNumber,
            string title,
            int loanPeriod,
            double baseLateFee)
        {
            if (catalogNumber <= 0)
                throw new ArgumentOutOfRangeException(nameof(catalogNumber), "Catalog number must be greater than zero");

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title), "Title must have a value");

            if (loanPeriod <= 0)
                throw new ArgumentOutOfRangeException(nameof(loanPeriod), "Loan period must be greater than zero");

            if (baseLateFee <= 0)
                throw new ArgumentOutOfRangeException(nameof(baseLateFee), "Base late fee must be greater than zero");

            CatalogNumber = catalogNumber;
            Title = title;
            LoanPeriod = loanPeriod;
            BaseLateFee = baseLateFee;
        }

        public void Withdraw()
        {
            IsWithdrawn = true;
        }

        public void Restore()
        {
            IsWithdrawn = false;
        }

        public void ChangePricing(double baseLateFee)
        {
            if (baseLateFee <= 0)
                throw new ArgumentOutOfRangeException(nameof(baseLateFee));

            BaseLateFee = baseLateFee;
        }
        public void MarkAsReturned()
        {
            IsOnLoan = false;
        }
        public void EndLoan()
        {
            IsOnLoan = false;
        }
    }
}
