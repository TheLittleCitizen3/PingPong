using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientPingPong
{
    class Client : IClient
    {
        Socket SocketConnection;
        IPAddress ServerIP { get; set; }
        int ServerPort { get; set; }

        public Client(IPAddress serverIp, int serverPort)
        {
            SocketConnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ServerIP = serverIp;
            ServerPort = serverPort;
        }
        public void Connect()
        {
            Console.WriteLine();
            try
            {
                SocketConnection.Connect(ServerIP, ServerPort);
            }
            catch (Exception ex)
            {
                Console.WriteLine("could not connect server with error:" + ex.Message);
                throw;
            }
            
        }

        public void PrintData(string data)
        {
            Console.WriteLine(data);
        }

        public void ReadDataFromServer()
        {

            byte[] buffer = new byte[1024 * 4];
            int readBytes = SocketConnection.Receive(buffer);
            string data = Encoding.ASCII.GetString(buffer, 0, readBytes);
            PrintData(data);
        }

        public void Run()
        {
            Connect();
            try
            {
                while (true)
                {
                    Console.WriteLine("Enter Text To Send: ");
                    string data = Console.ReadLine();
                    SendDataToServer(data);
                    ReadDataFromServer();
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Prolblem With Server..");
                SocketConnection.Close();
            }
            
        }

        public void SendDataToServer(string Data)
        {
            byte[] databytes = Encoding.ASCII.GetBytes(Data);
            SocketConnection.Send(databytes);
        }

    }
}
