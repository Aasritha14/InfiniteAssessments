using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel(8080);
            ChannelServices.RegisterChannel(channel, false);

            // Register the concrete class, not the interface
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(StudentService),
                "StudentService",
                WellKnownObjectMode.Singleton);

            Console.WriteLine("Server started on TCP port 8080...");
            Console.ReadLine();
        }
    }
}
