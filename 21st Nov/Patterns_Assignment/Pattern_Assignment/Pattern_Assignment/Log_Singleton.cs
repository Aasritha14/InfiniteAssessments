using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Pattern_Assignment
{
    // 1) Logger class with private constructor
    internal class Logger
    {
        private static readonly Logger _instance = new Logger(); // Eager initialization
        private readonly string _logFilePath;
        // Private constructor ensures no external instantiation
        private Logger()
        {
            _logFilePath = "application.log"; // Log file name
        }
        // 2) Static Instance property
        public static Logger Instance
        {
            get { return _instance; }
        }
        // 3) WriteLog method
        public void WriteLog(string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
            Console.WriteLine($"Log written: {logEntry}");
        }
    }
    // Entry point
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Logger Demo ===");
            // Get the single instance of Logger
            Logger logger = Logger.Instance;
            // Ask user for log message
            Console.Write("Enter a log message: ");
            string message = Console.ReadLine();
            // Write log
            logger.WriteLog(message);
            Console.WriteLine("✅ Log saved to application.log");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

