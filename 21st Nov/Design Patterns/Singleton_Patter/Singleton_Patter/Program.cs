using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Singleton_Patter.AdapterPattern;
using static Singleton_Patter.ObserverPattern;

namespace Singleton_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ob = Singleton.GetInstance;
            ob.Method();

            IPrinter p = new ModernPrinter();
            p.Print("hello world");

            LegacyPrinter o = new LegacyPrinter();
            IPrinter p2 = new LegacyPrinterAdapter(o);
            p2.Print("good afternoon");// calls the older printer

            NotificationService notificationService = new NotificationService();

            User user1 = new User("Apporv");
            User user2 = new User("Prince");
            User user3 = new User("Rathan");
            User user4 = new User("Satish");

            notificationService.Subscribe(user1);
            notificationService.Subscribe(user2);
            notificationService.Subscribe(user3);
            notificationService.Subscribe(user4);

            notificationService.NotifyObservers("Hello Students Happy Week end!");


            Console.WriteLine("=================");
            notificationService.Unsubscribe(user4);

            notificationService.NotifyObservers("Have a Great Day!!!");

            // first
            //login ob = new login();
            //product p = new product();
            //makepayment m = new makepayment();
            //sendmail s = new sendmail();

            //// second time
            //facedpattern ob1 = new facedpattern();
            //ob1.buyproduct();

            books obj = new onlinedelivary();
            obj.ProcessData();
            Console.WriteLine("==================");
            obj = new physicaldevlivary();
            obj.ProcessData();

        }
    }
}
