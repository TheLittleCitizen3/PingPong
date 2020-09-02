using System;
using System.Net;

namespace PingPong
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            Console.WriteLine("Enter port to listen");
            int port = int.Parse(Console.ReadLine());
            IServer server = new Server(ip, port, 5);
            server.Run();
        }
    }
}
