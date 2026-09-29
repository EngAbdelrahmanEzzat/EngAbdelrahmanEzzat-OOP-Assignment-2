using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Members
{
    public class StudentMember : Member
    {

        public StudentMember(int id, string fullName, string phone) : base(id, fullName, phone, 3, 0)
        {
        }
    }
}
