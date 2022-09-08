using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Watersharp
{
    /// <summary>
    /// Basic Ethernet features
    /// </summary>
    public class Ethernet
    {

        public static bool NetworkAvillable()
        {
            IPStatus status;

            try
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send("ya.ru");
                status = pingReply.Status;
            }
            catch { status = IPStatus.Unknown; }

            return status == IPStatus.Success ? true : false;
        }

        public static string GetUserIP()
        {
            if (NetworkAvillable())
            {
                WebClient client = new WebClient();
                Stream data = client.OpenRead("https://api.ipify.org?format=json");
                StreamReader reader = new StreamReader(data);

                Regex rx = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
                return rx.Match(reader.ReadToEnd()).Value;
            }
            else
                return "0.0.0.0";
        }

        public static string GetSiteIP(string url)
        {
            if (NetworkAvillable())
            {
                return Dns.GetHostEntry(url).AddressList[0].ToString();
            }
            else
                return "0.0.0.0";
        }

        public static long GetPing(string adress)
        {
            if (NetworkAvillable())
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(adress);
                return pingReply.RoundtripTime;
            }
            else
                return 999;
        }

    }
}
