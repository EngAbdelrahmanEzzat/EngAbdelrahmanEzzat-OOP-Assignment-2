using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Members
{
    public class PremiumMember : Member
    {
        public PremiumMember(int id, string fullName, string phone, double discontPercentage) : base(id, fullName, phone, 10, discontPercentage)
        {
        }

        public int ReadingPoints { get; private set; }
        public void AddReadingPoints()
        {
            ReadingPoints += 5;
        }
    }
}
