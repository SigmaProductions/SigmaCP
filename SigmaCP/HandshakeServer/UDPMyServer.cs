using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HandshakeServer
{
    class UDPMyServer
    {
        const string DEFAULT_SERVER = "192.168.88.219";
        const int DEFAULT_PORT = 804;
        UdpClient client;
        IPEndPoint RemoteIpEndPoint;
        public UDPMyServer()
        {
            client = new UdpClient();
            RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 804);
        }
        public string listen()
        {
            Console.WriteLine("listening...");
            //client.Connect("192.168.88.1", 804);
            client.Client.Bind(RemoteIpEndPoint);
            Byte[] receiveByte=client.Receive(ref RemoteIpEndPoint);
            return Encoding.ASCII.GetString(receiveByte);
        }
    }
}
