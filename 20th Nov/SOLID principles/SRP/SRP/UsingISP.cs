using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public interface IWorker
    {
        void Work();
    }

    public interface IEatable
    {
        void Eat();
    }

    public interface IManageTeam
    {
        void ManagesTeam();
    }

    internal class UsingISP
    {
        public class Worker : IWorker, IEatable
        {
            public void Work()
            {
                Console.WriteLine("Worker is working");
            }
            public void Eat()
            {
                Console.WriteLine("Worker is Eating");
            }
        }

        public class Manager : IWorker, IEatable, IManageTeam
        {
            public void Work()
            {
                Console.WriteLine("Manager Works");
            }
            public void Eat()
            {
                Console.WriteLine("Manager eats");
            }
            public void ManagesTeam()
            {
                Console.WriteLine("Manager manages his Team");
            }

            public static void Main(string[] args)
            {
                var worker = new Worker();
                worker.Work();
                worker.Eat();

                var Manager = new Manager();
                Manager.Work();
                Manager.Eat();
                Manager.ManagesTeam();
            }
        }
    }
}
