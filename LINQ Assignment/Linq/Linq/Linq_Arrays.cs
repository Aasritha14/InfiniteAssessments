using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Linq_Arrays
    {
        List<int> listA = new List<int> { 10, 20, 30, 40, 50, 20, 30 };
        List<int> listB = new List<int> { 30, 40, 50, 60, 70, 40 };

        List<string> names1 = new List<string> { "Akshay", "Aasritha", "Deepa", "Kiran","Kiran" };
        List<string> names2 = new List<string> { "Kiran", "Manikanta", "Deepa", "Naveen"
        };

        List<Products> li = new List<Products>()
            {
               new Products() { pid = 100, pname = "book", price = 1000, qty = 5 },
                new Products() { pid = 200, pname = "cd", price = 2000, qty = 6 },
                new Products() { pid = 300, pname = "toys", price = 3000, qty = 5 },
                  new Products() { pid = 400, pname = "mobile", price = 8000, qty = 6 },
                new Products() { pid = 600, pname = "pen", price = 200, qty = 7 },
                new Products() { pid = 700, pname = "tv", price = 30000, qty = 7 },
             };

        //Q1. Write a LINQ query to fetch unique values from listA. 
        // Expected Output: 10, 20, 30, 40, 50

        public void FecthUniqueValues()
        {
            var uniquevalues = listA.Distinct();

            Console.WriteLine("Unique values in listA : ");

            foreach (var value in uniquevalues) 
            { 
                Console.WriteLine(value);
            }
        }

        //Q2. Combine values from listA and listB without duplicates. 
        public void CombineValues()
        {
            var Combinevalue = listA.Union(listB);

            Console.WriteLine("Combine unique values : ");
            foreach (var value in Combinevalue)
            {
                Console.WriteLine(value);
            }
        }

        //Q3. Find items common in listA and listB.

        public void Commonitems()
        {
            var combined = listA.Concat(listB);
            var Commonitems = combined.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key);

            Console.WriteLine("Common items : ");
            foreach (var item in Commonitems)
            {
                Console.WriteLine(item);
            }
        }

        //Q4. Find names present in names1 but not in names2.

        public void NamesPresent()
        {
            var res = names1.Where(name => !names2.Contains(name));

            Console.WriteLine("Names present in names1 but not in names2 : ");
            foreach (var names in res)
            {
                Console.WriteLine(names);
            }
        }

        //Q5. Find sum of price of all products.
        public void SumOfPrice()
        {
            int totalPrice = li.Sum(p => p.price);

            Console.WriteLine("Total price of all products : " + totalPrice);

        }

        //Q6. Find count of products where price > 5000. 

        public void CountOfProducts()
        {
            int[] prices = { 1000, 2000, 1500, 8000, 200, 30000 };
            int count = prices.Count(p => p > 5000);
            Console.WriteLine("Number of products with price > 5000 : " + count);
        }

        //Q7. Find the highest value in listA.

        public void HighestValueInListA()
        {
            int maxvalue = listA.Max();

            Console.WriteLine("Highest value in ListA : " + maxvalue);
        }

        //Q8. Write a LINQ query to find numbers divisible by 3 
        //int[] numbers = { 1, 4, 9, 16, 25, 36 };

        public void NumbersDivisibleBy3()
        {
            int[] numbers = { 1, 4, 9, 16, 25, 36 };

            var divisible = from i in numbers
                            where i % 3 == 0
                            select i;

            Console.WriteLine("Numbers divisible by 3 : ");
            foreach (var num in divisible)
            {
                Console.WriteLine(num);
            }
        }

        // Q9. Write a Linq to query to sort based on string Length 
        //string[] st = { "India", "Srilanka", "canada", "Singapore" };

        public void Sort()
        {
            string[] st = { "India", "Srilanka", "canada", "Singapore" };

            var sortbylength = from s in st
                               orderby s.Length
                               select s;

            Console.WriteLine("strings sorted by length : ");
            foreach (var s in sortbylength)
            {
                Console.WriteLine(s);
            }
        }
    }
}
