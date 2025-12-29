using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels.Tcp;

namespace ClientApp
{
    class Program
{
    static void Main(string[] args)
    {
        // Register TCP channel
        TcpChannel channel = new TcpChannel();
        ChannelServices.RegisterChannel(channel, false);

        // Get remote object from server
        IStudentService service = (IStudentService)Activator.GetObject(
            typeof(IStudentService),
            "tcp://localhost:8080/StudentService");

        // Show all students on client console
        var allStudents = service.GetAllStudents();
        Console.WriteLine("All Students:");
        foreach (var s in allStudents)
        {
            Console.WriteLine(s);
        }

        Console.WriteLine("\nEnter Student ID to fetch details:");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nGet Student by ID:");
        try
        {
            var student = service.GetStudent(id);
            Console.WriteLine(student);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.ReadLine();
    }
}
}
