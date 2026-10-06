using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.LibraryItems
{
    public class Book : LibraryItem
    {
        public double DailyLateFee
        {
            get
            {
                return BaseLateFee * 1;
            }
        }

        public Book(
            int catalogNumber,
            string title,
            double baseLateFee)
            : base(catalogNumber, title, 21, baseLateFee)
        {
        }
    }
}

