using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Pattern
{
    internal abstract class books
    {

        public void ProcessData()
        {
            selectbook();
            makepayment();
            deliver();
        }

        public abstract void selectbook();
        public abstract void makepayment();
        public abstract void deliver();

    }

    class onlinedelivary : books
    {

        public override void selectbook()
        {
            Console.WriteLine("selecting book");
        }
        public override void makepayment()
        {
            Console.WriteLine("making payment via internet bank");
        }

        public override void deliver()
        {
            Console.WriteLine("send a book link to user");
        }

    }

    class physicaldevlivary : books
    {
        public override void selectbook()
        {
            Console.WriteLine("selecting book");
        }
        public override void makepayment()
        {
            Console.WriteLine("making payment via UPI");
        }

        public override void deliver()
        {
            Console.WriteLine("send a physical book to actual address");
        }
    }
}
