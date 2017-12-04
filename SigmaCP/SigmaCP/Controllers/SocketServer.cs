using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace SigmaCP.Controllers
{
    public class SocketServer
    {
        const string DEFAULT_SERVER = "192.168.88.219";
        const int DEFAULT_PORT = 804;


        System.Net.Sockets.UdpClient udpServer;

        IPEndPoint serverEndPoint;
        public void Startup()
        {
             // The chat server always starts up on the localhost, using the default port 
            IPHostEntry hostInfo = Dns.GetHostByName(DEFAULT_SERVER);
            IPAddress serverAddr = hostInfo.AddressList[0];
            serverEndPoint = new IPEndPoint(serverAddr, DEFAULT_PORT);
            udpServer = new System.Net.Sockets.UdpClient();

        }
        public void sendData()
        {
            udpServer.Send(System.Text.Encoding.ASCII.GetBytes("dasfsfds"),"dasfsfds".Length, serverEndPoint);
        }
    }
}
