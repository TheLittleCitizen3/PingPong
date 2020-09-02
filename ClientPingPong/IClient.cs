using System;
using System.Collections.Generic;
using System.Text;

namespace ClientPingPong
{
    interface IClient
    {
        void Connect();
        void ReadDataFromServer();
        void PrintData(string data);
        void SendDataToServer(string Data);
        void Run();
    }
}
