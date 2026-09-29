using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Staff
{
    public class Staff : Person
    {

        public DateOnly HireDate { get; }
        public double MonthlySalary { get; private set; }
        protected Staff(int id, string fullName, string phone, DateOnly hireDate, double monthlySalary) : base(id, fullName, phone)
        {
            if (monthlySalary <= 0)
                throw new ArgumentOutOfRangeException(nameof(monthlySalary), "The value must be greater than zero");
            HireDate = hireDate;
            MonthlySalary = monthlySalary;
        }
        public void GiveRaise(double percent)
        {
            if (percent <= 0)
                throw new ArgumentOutOfRangeException(nameof(percent));
            double raise = MonthlySalary * (percent / 100);
            MonthlySalary += raise;
        }
    }
}
