using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Assignment
{
    public interface INotification
    {
        void send(string receiver, string message);
    }
    public class EmailNotification : INotification
    {
        public void send(string receiver, string message)
        {
            Console.WriteLine($"Email : sent to {receiver} , msg : {message}");
        }
    }
    public class SmsNotification : INotification
    {
        public void send(string receiver, string message)
        {
            Console.WriteLine($"SMS : sent to {receiver} , msg : {message}");

        }
    }
    public class PushNotification : INotification
    {
        public void send(string receiver, string message)
        {
            Console.WriteLine($"Push to : {receiver} , msg : {message}");

        }
    }
    public static class Notification
    {
        public static INotification GetNotification(string nameoftype)
        {
            switch (nameoftype)
            {
                case "Email":
                    return new EmailNotification();
                case "SMS":
                    return new SmsNotification();
                case "Push":
                    return new PushNotification();
                default:
                    Console.WriteLine("Invalid case choose 1: for email , 2: for sms,3:push notification");
                    return null;

            }

        }
    }

    internal class Factory
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sending  notification\n");
            Console.WriteLine("Email notification type Email/Sms/push\n");
            string nameoftype = Console.ReadLine();

            Console.WriteLine("Enter Reciever name :");
            string receiver = Console.ReadLine();
            Console.WriteLine("Enter MSG");
            string message = Console.ReadLine();

            INotification notification = Notification.GetNotification(nameoftype);
            if (notification != null)
            {
                notification.send(receiver, message);
                Console.WriteLine("Notification sent to reciever successfully");

            }

            else
            {
                Console.WriteLine("Notification could not be sent due to invalid type.");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();



        }
    }
}
