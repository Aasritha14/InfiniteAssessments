using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Disconnected_Architecture ob = new Disconnected_Architecture();
            ob.PrintAllTheRecords();
            ob.PrintAllDepartment();
            ob.EmployeeTable();
            ob.ShowTotal();
            ob.copydata();
        }
    }
}
