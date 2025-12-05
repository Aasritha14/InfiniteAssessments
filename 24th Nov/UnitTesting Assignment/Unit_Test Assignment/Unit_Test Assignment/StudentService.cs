using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_Assignment
{
    internal class StudentService
    {
            public void ValidateAge(int age)
            {
                if (age < 0) throw new ArgumentException("Invalid Age");
            }
        
    }
}
