using System;
using static ConnectBox_ip_leak.Connectbox_query;

namespace ConnectBox_ip_leak
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryRouter_ConnectBox("192.168.0.1:5000");
        }
    }
}
