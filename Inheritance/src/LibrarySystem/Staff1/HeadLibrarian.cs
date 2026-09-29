using LibrarySystem.LibraryItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Staff
{
    public class HeadLibrarian : Staff
    {
        public const int ResponsibilityAllowance = 400;

        public double MonthlyPay
        {
            get
            {
                return MonthlySalary + ResponsibilityAllowance;
            }
        }
        public HeadLibrarian(int id, string fullName, string phone, DateOnly hireDate, double monthlySalary) : base(id, fullName, phone, hireDate, monthlySalary)
        {
        }


        public void WithdrawItem(LibraryItem l)
        {
            l.Withdraw();
        }
        public void Restore(LibraryItem l)
        {
            l.Restore();
        }
    }
}
