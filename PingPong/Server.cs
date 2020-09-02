using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong
{
    public class Server : IServer
    {
        public Socket SocketConnection { get; set; }
        private int MaxConnectionNumber;
        
        public Server(IPAddress ip, int port, int MaxConnections)
        {
            SocketConnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EndPoint endPoint = new IPEndPoint(ip, port);
            SocketConnection.Bind(endPoint);
            MaxConnectionNumber = MaxConnections;
        }
        public void Listen()
        {
            SocketConnection.Listen(MaxConnectionNumber);
        }
        public string ReadDataFromClient(Socket newSocket)
        {

            byte[] buffer = new byte[1024];
            int readBytes = newSocket.Receive(buffer);
            string data = Encoding.ASCII.GetString(buffer, 0, readBytes);
            return data;
        }
        public void PrintData(string data)
        {
            Console.WriteLine(data);
        }
        public void SendDataToClient(Socket newSocket, string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(data);
            newSocket.Send(bytes);
        }

        public void Run()
        {
            
            while (true)
            {
                Listen();
                Console.WriteLine("Waiting for connections...");

                Socket newSocket = SocketConnection.Accept();
                Console.WriteLine($"new connection....");
                Task.Run(() =>
                {
                    try
                    {
                        while (true)
                        {

                            SendDataToClient(newSocket, ReadDataFromClient(newSocket));
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Erorr With Connection...");
                    }

                });
                
            }
        }
    }
}
