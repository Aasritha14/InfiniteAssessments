using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class UsingOCP
    {
        public interface IDiscountStrategy
        {
            decimal GetDiscount();
        }

        public class DiscountService
        {
            private readonly Dictionary<string, IDiscountStrategy> _strategies;

            public DiscountService()
            {
                _strategies = new Dictionary<string, IDiscountStrategy>
        {
            { "VIP", new VipDiscount() },
            { "Employee", new EmployeeDiscount() }
        };
            }

            public decimal ApplyDiscount(string customerType)
            {
                return _strategies.ContainsKey(customerType) ? _strategies[customerType].GetDiscount() : 0m;
            }
        }

        public class VipDiscount : IDiscountStrategy
        {
            public decimal GetDiscount() => 0.8m;
        }

        public class EmployeeDiscount : IDiscountStrategy
        {
            public decimal GetDiscount() => 0.5m;
        }

        // Usage
        public class Program
        {
            public static void Main()
            {
                var service = new DiscountService();
                Console.WriteLine(service.ApplyDiscount("VIP"));       // 0.8
                Console.WriteLine(service.ApplyDiscount("Employee"));  // 0.5
                Console.WriteLine(service.ApplyDiscount("Normal"));    // 0
            }
        }

    }
}
