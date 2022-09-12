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
using System.Security.Policy;
using System.ComponentModel;

namespace Watersharp
{
    /// <summary>
    /// Basic Ethernet features
    /// </summary>
    public class Internet
    {

        /// <summary>
        /// Check availability of Internet connection
        /// </summary>
        /// <returns>
        /// <b>True</b> if the connection is available and <b>False</b> if not
        /// </returns>
        public static bool IsNetworkAvilable()
        {
            IPStatus status;

            try
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send("google.com");
                status = pingReply.Status;
            }
            catch { status = IPStatus.Unknown; }

            return status == IPStatus.Success ? true : false;
        }

        /// <summary>
        /// Try to get WAN IP of current machine
        /// </summary>
        /// <returns>
        /// IP adress
        /// </returns>
        public static string GetUserIP()
        {
            if (IsNetworkAvilable())
            {
                try
                {
                    WebClient client = new WebClient();
                    Stream data = client.OpenRead("https://api.ipify.org?format=json");
                    StreamReader reader = new StreamReader(data);

                    Regex rx = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
                    return rx.Match(reader.ReadToEnd()).Value;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("No internet connection avilable");
        }

        /// <summary>
        /// Try to get IP adress of specified site
        /// </summary>
        /// <param name="url">Site adress (like http://...)</param>
        /// <returns>
        /// IP adress
        /// </returns>
        public static string GetSiteIP(string url)
        {
            if (IsNetworkAvilable())
            {
                if (!url.Contains("http://") || !url.Contains("https://"))
                    url = "http://" + url;

                try
                {
                    return Dns.GetHostEntry(url).AddressList[0].ToString();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("No internet connection avilable");
        }

        /// <summary>
        /// Try to get Ping value from this machine to specified adress
        /// </summary>
        /// <param name="adress">Web adress to recieve ping (like 0.0.0.0 or http://...)</param>
        /// <returns>
        /// Ping
        /// </returns>
        public static long GetPing(string adress)
        {
            if (IsNetworkAvilable())
            {
                if (!adress.Contains("http://") || !adress.Contains("https://"))
                    adress = "http://" + adress;

                try
                {
                    Ping ping = new Ping();
                    PingReply pingReply = ping.Send(adress);
                    return pingReply.RoundtripTime;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("No internet connection avilable");
        }

        /// <summary>
        /// Try to read data from specified web file
        /// </summary>
        /// <param name="url">Web file adress-path</param>
        /// <returns>
        /// File data
        /// </returns>
        public static string ReadWebFile(string url)
        {
            if (IsNetworkAvilable())
            {
                if (!url.Contains("http://") || !url.Contains("https://"))
                    url = "http://" + url;

                string data;
                try
                {
                    WebClient wc = new WebClient();
                    data = wc.DownloadString(url);
                    wc.Dispose();
                    return data;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("No internet connection avilable");
        }

        /// <summary>
        /// Try to download a file to the program directory
        /// </summary>
        /// <param name="url">Web file adress-path</param>
        /// <returns>
        /// Downloaded file
        /// </returns>
        public static void DownloadFile(string url)
        {
            if (IsNetworkAvilable())
            {
                if (!url.Contains("http://") || !url.Contains("https://"))
                    url = "http://" + url;

                try
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFile(url, url.Split('/').Last());
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("No internet connection avilable");
        }

        /// <summary>
        /// Try to download a file to the specified directory
        /// </summary>
        /// <param name="url">Web file adress-path</param>
        /// <param name="path">Download file path (like C:\Downloads)</param>>
        /// <returns>
        /// Downloaded file
        /// </returns>
        public static void DownloadFile(string url, string path)
        {
            if (IsNetworkAvilable())
            {
                if (!url.Contains("http://") || !url.Contains("https://"))
                    url = "http://" + url;

                try
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFile(url, path + "/" + url.Split('/').Last());
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("No internet connection avilable");
        }

        /// <summary>
        /// Try to download a file to the specified directory with event handlers
        /// </summary>
        /// <param name="url">Web file adress-path</param>
        /// <param name="path">Download file path (like C:\Downloads)</param>
        /// <param name="onProgressChanged">Call when download progress changed</param>
        /// <param name="onDownloadCompleted">Call when download colpleted</param>
        /// <returns>
        /// Downloaded file
        /// </returns>
        public static void DownloadFileAdvanced(string url, string path,
            DownloadProgressChangedEventHandler onProgressChanged,
            AsyncCompletedEventHandler onDownloadCompleted)
        {
            if (IsNetworkAvilable())
            {
                if (!url.Contains("http://") || !url.Contains("https://"))
                    url = "http://" + url;

                try
                {
                    WebClient wc = new WebClient();
                    wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(onProgressChanged);
                    wc.DownloadFileCompleted += new AsyncCompletedEventHandler(onDownloadCompleted);
                    wc.DownloadFileAsync(new Uri(url), path + "/" + url.Split('/').Last());
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
                throw new Exception("No internet connection avilable");
        }

    }
}
