using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Patter
{
    
    internal class Class1
    {

        public int p1 { get; set; }
        public int p2 { get; set; }

        public object Clone()
        {//copies all data to second object
            return this.MemberwiseClone(); // Shallow copy
        }
    static void Main(string[] args)
        {
            // user -1
            Class1 ob = new Class1();
            ob.p1 = 100;
            ob.p2 = 200;
            Console.WriteLine(ob.p1);
            Console.WriteLine(ob.p2);
            Console.WriteLine("====================");

            // user-2
            //Class1 ob2 = ob; // single object
            Class1 ob2 = (Class1)ob.Clone(); //2 objects
            ob2.p2 = 500;
            Console.WriteLine(ob2.p1);
            Console.WriteLine(ob2.p2);

            Console.WriteLine("==================");
            Console.WriteLine(ob.p1);// 100
            Console.WriteLine(ob.p2);//500
            // why user1 data is getting updated?

        }
    }
}
