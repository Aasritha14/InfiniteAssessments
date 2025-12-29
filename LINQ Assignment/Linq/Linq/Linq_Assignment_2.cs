using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
     public class Products
    {
        public int pid { get; set; }
        public string pname { get; set; }
        public int price { get; set; }
        public int qty { get; set; }
    }
    internal class Linq_Assignment_2
    {
        List<Products> li = new List<Products>()
            {
               new Products() { pid = 100, pname = "book", price = 1000, qty = 5 },
                new Products() { pid = 200, pname = "cd", price = 2000, qty = 6 },
                new Products() { pid = 300, pname = "toys", price = 3000, qty = 5 },
                  new Products() { pid = 400, pname = "mobile", price = 8000, qty = 6 },
                new Products() { pid = 600, pname = "pen", price = 200, qty = 7 },
                new Products() { pid = 700, pname = "tv", price = 30000, qty = 7 },
             };

        //1. find second highest price
        public void SecondHighest()
        {
            var SecondHighest = li
                .Select(p => p.price).Distinct().OrderByDescending(p => 0).Skip(1).First();

            Console.WriteLine("SecondHighest Price = " + SecondHighest);
        }

        //2. display top 3 highest price 
        public void TopHighestprice()
        {
            var TopHighest = li
                .Select(p=>p.price).OrderByDescending(p =>p).Take(3).ToList();

            foreach (var price in TopHighest)
            {
                Console.WriteLine(price);
            }
        }

        //3. find the sum of price where product names contains letter 'O' 
        public void ProductName()
        {
            var sum = li.Where(p => p.pname.ToLower().Contains("O")).Sum(p => p.price);

            Console.WriteLine("Sum = " + sum);
        }

        //4.  find the product name ends with e and display only pid and pname (filter by 
        //column name) 

        public void FilterByCoulmnName()
        {
            var res = li.Where(p => p.pname.EndsWith("e")).Select(p => new {p.pid, p.pname}).ToList();

            foreach (var item in res)
            {
                Console.WriteLine($"PID: {item.pid},Name: {item.pname}");
            }
        }

        //5. group all records by qty find max of price
        public void MaxOfPrice()
        {
            var res = li.GroupBy( p => p.qty).Select(g => new { QTY = g.Key, MaxOfPrice = g.Count() }).ToList();

            foreach (var item in res)
            {
                Console.WriteLine($"QTY : {item.QTY}, MaxOfPrice : {item.MaxOfPrice}");
            }
            
        }
    }
}
