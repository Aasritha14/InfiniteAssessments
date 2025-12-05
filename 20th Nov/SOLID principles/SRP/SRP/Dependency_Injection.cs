using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Dependency_Injection
{
    // service class

    interface Iservice
    {
        void Add(int x, int y);
    }
    class service : Iservice
    {

        public void Add(int x, int y)
        {
            Console.WriteLine($"the sum is {x + y}");
        }
    }

    internal class Mathcls
    {


        // constructor , properties , methods

        // Iservice ob;// null
        //public Mathcls(Iservice s)// null
        //{
        //    ob = s;
        //}

        public Iservice GetInstance { get; set; }
        public void show(Iservice s)
        {
            //  ob.Add(10, 20);
            // GetInstance.Add(10, 20);
            s.Add(10, 20);
        }
        static void Main(string[] args)
        {
            // injector code

            //Mathcls ob = new Mathcls(new service());// constructor injection

            Mathcls ob = new Mathcls();
            //ob.GetInstance = new service();// property injection
            ob.show(new service());// method injection
            IUnityContainer u = new UnityContainer();

            //in my applicaiton when even/where ever  i use iservice interface please send the instance of service class
            u.RegisterType<Iservice, service>();

            var res = u.Resolve<Mathcls>();// object of math class is created
            res.show();


        }
    }
}