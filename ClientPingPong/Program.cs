using System;
using System.Net;

namespace ClientPingPong
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter ip server to connect");
            string ipString = Console.ReadLine();
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            Console.WriteLine("Enter port to connect");
            int port = int.Parse(Console.ReadLine());
            IClient client = new Client(ip, port);
            client.Run();

        }
    }
}
