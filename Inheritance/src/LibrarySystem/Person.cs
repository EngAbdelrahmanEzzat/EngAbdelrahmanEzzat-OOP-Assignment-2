using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem
{
    public class Person
    {


        public int Id { get; }
        public string FullName { get; }

        public string Phone { get; }
        protected Person(int id, string fullName, string phone)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "The id must be greater than zero");
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentNullException(nameof(fullName), "The Name must have a value");
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentNullException(nameof(phone), "the phone must hane value");
            Id = id;
            FullName = fullName;
            Phone = phone;
        }


    }
}
