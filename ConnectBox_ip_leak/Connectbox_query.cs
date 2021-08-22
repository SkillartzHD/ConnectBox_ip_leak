using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectBox_ip_leak
{
    class Connectbox_query
    {
        private static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }
        public static void QueryRouter_ConnectBox(string address)
        {
            string result_connectbox = null;
            string ip_web = null;

            try
            {
                using (var http_req = new HttpRequest())
                {
                    http_req.AddHeader("Host", address);
                    http_req.AddHeader("Upgrade-Insecure-http_requests", "1");
                    http_req.AddHeader("SOAPACTION", "urn:schemas-upnp-org:service:WANIPConnection:1#GetExternalIPAddress");

                    var jsonContent = new StringContent("test")
                    {
                        ContentType = "text/xml; charset=\"utf-8\""
                    };
                    result_connectbox = http_req.Post("http://" + address + "/control/WANIPConnection_s", jsonContent).ToString();

                    result_connectbox = getBetween(result_connectbox, "NewExternalIPAddress>", "</NewExternalIPAddress>");

                    ip_web = http_req.Get("https://api.ipify.org/").ToString();


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You are : " + ip_web + "\n\n");

                    if (result_connectbox != ip_web)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Why you lying? you ar23 : " + result_connectbox);
                    }
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                if (e is HttpException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.ToString());
                    Console.ResetColor();

                }
            }
        }
    }

}
