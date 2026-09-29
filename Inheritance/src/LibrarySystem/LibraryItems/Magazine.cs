using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.LibraryItems
{
    public class Magazine : LibraryItem
    {
        public double DailyLateFee
        {
            get
            {
                return BaseLateFee * 0.5;
            }
        }

        public Magazine(
            int catalogNumber,
            string title,
            double baseLateFee)
            : base(catalogNumber, title, 3, baseLateFee)
        {
        }
    }
}
