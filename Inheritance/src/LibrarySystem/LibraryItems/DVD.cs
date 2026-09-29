using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.LibraryItems
{
    public class DVD : LibraryItem
    {
        public double DailyLateFee
        {
            get
            {
                return BaseLateFee * 2;
            }
        }

        public DVD(
            int catalogNumber,
            string title,
            double baseLateFee)
            : base(catalogNumber, title, 7, baseLateFee)
        {
        }
    }
}
