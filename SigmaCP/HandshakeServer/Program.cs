using System;
using System.Net;
using System.Net.WebSockets;
namespace HandshakeServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var testc = new TCPGutClient();
            var textd = new UDPMyServer();
            var z= textd.listen();
            testc.Send(z);
        }
    }
    
}
