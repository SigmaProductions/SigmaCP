using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;


namespace HandshakeServer
{
    class TCPGutClient
    {
        // tu jest ip na ktorym sluchasz (twoje ip)
        IPAddress localAddr = IPAddress.Parse("192.168.88.248");
        const int DEFAULT_PORT = 804;
        TcpListener server;
        public TCPGutClient()
        {
            server = new TcpListener(localAddr, DEFAULT_PORT);
            //var server = new TcpListener(DEFAULT_SERVER, DEFAULT_PORT);

        }

        public void Send(string data)
        {
            Console.WriteLine("waiting for handshake.");
            server.Start();
            TcpClient client = server.AcceptTcpClient();

            var tcpStream = client.GetStream();
            Byte[] receiveByte=new byte[1024];
            tcpStream.Read(receiveByte, 0, 1024);
            string packageFromGut= Encoding.ASCII.GetString(receiveByte);

            Byte[] packageToGut = killmeHandshake(data, packageFromGut);
            tcpStream.Write(packageToGut, 0,packageToGut.Length);

            Byte[] frame = EncodeOutgoingMessage(data, false);
            tcpStream.Write(frame, 0, frame.Length);

            tcpStream.Close();
        }


        private Byte[] killmeHandshake(string dataToSend, string fromGut)
        {
            Byte[] response = Encoding.UTF8.GetBytes("HTTP/1.1 101 Switching Protocols" + Environment.NewLine
        + "Connection: Upgrade" + Environment.NewLine
        + "Upgrade: websocket" + Environment.NewLine
        + "Sec-WebSocket-Accept: " + Convert.ToBase64String(
            SHA1.Create().ComputeHash(
                Encoding.UTF8.GetBytes(
                    new Regex("Sec-WebSocket-Key: (.*)").Match(fromGut).Groups[1].Value.Trim() + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"
                )
            )
        ) + Environment.NewLine
        + Environment.NewLine);

            
            return response;
        }

        private byte[] EncodeOutgoingMessage(string text, bool masked = false)
        {

            byte[] header = new byte[] { 0x81, (byte)((masked ? 0x1 << 7 : 0x0) + text.Length) };

            byte[] maskKey = new byte[4];
            if (masked)
            {

                Random rd = new Random();
                rd.NextBytes(maskKey);
            }

            byte[] payload = Encoding.UTF8.GetBytes(text);

            byte[] frame = new byte[header.Length + (masked ? maskKey.Length : 0) + payload.Length];

            Array.Copy(header, frame, header.Length);

            if (maskKey.Length > 0)
            {
                Array.Copy(maskKey, 0, frame, header.Length, maskKey.Length);
                for (int i = 0; i < payload.Length; i++)
                {
                    payload[i] = (byte)(payload[i] ^ maskKey[i % maskKey.Length]);
                }
            }

            Array.Copy(payload, 0, frame, header.Length + (masked ? maskKey.Length : 0), payload.Length);
            return frame;
        }
    }
}
