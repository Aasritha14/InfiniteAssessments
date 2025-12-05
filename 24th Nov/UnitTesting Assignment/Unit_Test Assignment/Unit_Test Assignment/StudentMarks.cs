using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_Assignment
{
    internal class StudentMarks
    {
        public class MarksProvider
        {
            public static IEnumerable<int> GetStudentMarks()
            {
                return new[] { 45, 78, 98, 41, 90 };
            }
        }
    }
}
