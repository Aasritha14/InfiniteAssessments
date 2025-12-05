using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_Assignment
{
    internal class Asynchronous_Method
    {
       public class MarksService
        {
            public async Task<int> GetMarksAsync()
            {
                await Task.Delay(100);
                return 90;
            }
        }
        
        
    }
}
