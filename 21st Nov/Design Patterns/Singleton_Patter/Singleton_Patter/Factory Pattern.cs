using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Patter
{
    internal class Factory_Pattern
    {
        interface Mydb
        {
            string[] ShowData();
        }
        internal class Sqldata : Mydb
        {
            public string[] ShowData()
            {
                string[] data = { "india", "canada", "uk" };
                return data;
            }
        }

        internal class oracledata : Mydb
        {

            public string[] ShowData()
            {
                string[] data = { "CKS", "RCB", "SRH" };
                return data;
            }
        }


        internal class mysqldata : Mydb
        {
            public string[] ShowData()
            {
                string[] data = { "red", "blue", "green" };
                return data;
            }
        }


        class factory
        {
            // return the instance based upon the input

            public static Mydb GetInstance(int i)
            {
                //if user pass 1 , return sql data
                // 2 return oracle data

                if (i == 1)
                {
                    return new Sqldata();
                }
                if (i == 2)
                {

                    return new oracledata();
                }
                else
                {
                    return new mysqldata();
                }


            }

        }
        static void Main(string[] args)
        {
            var ob = factory.GetInstance(3);
            var result = ob.ShowData();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
