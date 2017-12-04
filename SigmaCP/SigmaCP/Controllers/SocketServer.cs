using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace SigmaCP.Controllers
{
    public static class SocketServer
    {
        const string DEFAULT_SERVER = "192.168.88.1";
        const int DEFAULT_PORT = 804;


        static System.Net.Sockets.UdpClient udpServer=null;
        static IPEndPoint serverEndPoint=null;

        private static void Startup()
        {
             // The chat server always starts up on the localhost, using the default port 
            IPHostEntry hostInfo = Dns.GetHostByName(DEFAULT_SERVER);
            IPAddress serverAddr = hostInfo.AddressList[0];
            serverEndPoint = new IPEndPoint(serverAddr, DEFAULT_PORT);
            udpServer = new System.Net.Sockets.UdpClient();

        }
        public static int sendData(string data)
        {
            Startup();
            udpServer.Send(System.Text.Encoding.ASCII.GetBytes(data),data.Length, serverEndPoint);
            return 1;
        }
    }
}
