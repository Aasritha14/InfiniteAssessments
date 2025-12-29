using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Patter
{
    internal class ObserverPattern
    {
        public interface IObserver
        {
            void Update(string message);
        }

        // Step 2: Implement Concrete Observers
        public class User : IObserver
        {
            private string _name;

            public User(string name)
            {
                _name = name;
            }

            public void Update(string message)
            {
                Console.WriteLine($"{_name} received update: {message}");
            }
        }

        // Step 3: Define the Subject (Observable)
        public class NotificationService
        {
            // u are storing user details in the list
            private List<IObserver> _observers = new List<IObserver>();

            public void Subscribe(IObserver observer)
            {
                _observers.Add(observer);
            }

            public void Unsubscribe(IObserver observer)
            {
                _observers.Remove(observer);//remove the user to the list
            }

            public void NotifyObservers(string message)
            {
                foreach (var observer in _observers)
                {
                    observer.Update(message);
                }
            }
        }
    }
}
