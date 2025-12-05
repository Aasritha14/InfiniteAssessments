using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public interface IDatabase
    {
        void Save();
    }
    internal class UsingDIP
    {
        public class SqlDatabase: IDatabase
        {
            public void Save()
            {
                Console.WriteLine("Saving Sql server to Database");
            }
        }


        public class OrderProcessor
        {
            private readonly IDatabase _database;

            public OrderProcessor(IDatabase database)
            {
                _database = database;
            }

            public void Process()
            {
                Console.WriteLine("Processing Order...");
                _database.Save();
            }
        }


        public class Program
        {
            public static void Main()
            {
                IDatabase database = new SqlDatabase();
                OrderProcessor processor = new OrderProcessor(database);
                processor.Process();
            }
        }

    }
}
