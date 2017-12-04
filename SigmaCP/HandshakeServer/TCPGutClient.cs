using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace HandshakeServer
{
    class TCPGutClient
    {
        const string DEFAULT_SERVER = "192.168.88.219";
        const int DEFAULT_PORT = 804;
        TcpClient client;
        public TCPGutClient()
        {
            client = new TcpClient();

        }

        public void Send(string data)
        {
            while (true)
            {
                try
                {
                    client.Connect(DEFAULT_SERVER, DEFAULT_PORT);
                    break;
                }
                catch (Exception) { }
            }

            var tcpStream = client.GetStream();
            tcpStream.Write(System.Text.Encoding.ASCII.GetBytes(data), 0,data.Length);
            tcpStream.Close();
        }
    }
}
