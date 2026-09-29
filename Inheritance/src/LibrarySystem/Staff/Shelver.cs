using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Staff
{
    public class Shelver : Staff
    {
        public Shelver(int id, string fullName, string phone, DateOnly hireDate, double monthlySalary, string section) : base(id, fullName, phone, hireDate, monthlySalary)
        {
            if (string.IsNullOrWhiteSpace(section))
                throw new ArgumentNullException(nameof(section), "Section must have value");
            Section = section;
        }

        public string Section { get; private set; }

        public void Reassign(string section)
        {
            if (string.IsNullOrWhiteSpace(section))
                throw new ArgumentNullException(nameof(section), "Section must have value");
            Section = section;
        }
    }
}
