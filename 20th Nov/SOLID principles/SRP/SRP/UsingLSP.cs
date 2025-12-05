using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public abstract class EmployeeBase
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpDept { get; set; }
    }


    public interface IBonusEligible
    {
        decimal GetBonus(decimal salary);
    }


    public class PermanentEmployee : EmployeeBase, IBonusEligible
    {
        public decimal GetBonus(decimal salary) => salary * 0.20m;
    }


    public class ContractEmployee : EmployeeBase
    {

    }

    internal class UsingLSP
    {
        
        public class Program
        {
            public static void Main()
            {
                IBonusEligible emp = new PermanentEmployee();
                Console.WriteLine($"Bonus: {emp.GetBonus(50000)}");

               
                ContractEmployee contractEmp = new ContractEmployee();
                Console.WriteLine($"Contract Employee: No bonus applicable");
            }
        }
    }
}
