using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Staff
{
    public class Librarian : Staff
    {
        public Librarian(int id, string fullName, string phone, DateOnly hireDate, double monthlySalary)
            : base(id, fullName, phone, hireDate, monthlySalary)
        {
        }

        public void ProcessReturn(Loan loan, DateOnly returnDate)
        {
            loan.Return(returnDate);
        }

        public void MarkAsLost(Loan loan)
        {
            loan.MarkAsLost();
        }
    }
}
