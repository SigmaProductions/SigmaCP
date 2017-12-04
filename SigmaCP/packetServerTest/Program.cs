using System;
using SigmaCP.Controllers;
namespace packetServerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var testc = new SocketServer();
            testc.Startup();
            Console.WriteLine("Hello World!");
            testc.sendData("test123");
        }
    }
}
