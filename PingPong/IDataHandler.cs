using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PingPong
{
    public interface IDataHandler
    {
        public string ConvertDataToString(int readBytes);
    }
}
