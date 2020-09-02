using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace PingPong
{
    public interface IServer
    {
        void Listen();
        string ReadDataFromClient(Socket newSocket);
        void PrintData(string data);
        void SendDataToClient(Socket newSocket, string data);
        void Run();
    }
}
