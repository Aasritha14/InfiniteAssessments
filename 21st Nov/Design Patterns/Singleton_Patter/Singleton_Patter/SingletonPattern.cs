using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Pattern
{
    internal sealed class Singleton
    {

        private Singleton() { }

        static Singleton s = null;

        // return the instance
        public static Singleton GetInstance
        {


            get
            {
                if (s == null)// first request(object created)
                {
                    s = new Singleton();
                    return s;
                }
                else
                {
                    return s; // second request(object reused)
                }
            }

        }

        public void Method()
        {
            //  Singleton ob = new Singleton();// run time error
            // code to interact with database
            Console.WriteLine("database code triiggered");
        }
    }
}
