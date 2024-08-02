using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ZvitEXZ.Models;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Globalization;

namespace ZvitEXZ.Methods
{
    internal class IsAllowed
    {
        public static async Task<bool> Check()
        {
            DateTime errorDate = new DateTime(2025, 1, 5);//год, месяц, день
            DateTime now;

            //byte[] ntpData = new byte[48];
            //ntpData[0] = 0x1B;
            //string ntpServer = "time.windows.com";
            try
            {
                //now = await GetNetworkTimeAsync(ntpServer);
                //var intPart = (ulong)ntpData[40] << 24 | (ulong)ntpData[41] << 16 | (ulong)ntpData[42] << 8 | ntpData[43];
                //var fractPart = (ulong)ntpData[44] << 24 | (ulong)ntpData[45] << 16 | (ulong)ntpData[46] << 8 | ntpData[47];
                //var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
                //var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);
                //now = networkDateTime.ToLocalTime();
                now =await GetNistTime();

            }
            catch (Exception ex)
            {
                Logs.AddAlarm(ex.Message);
                Logs.AddAlarm("Нет соединения с интернетом!");
                return false;
                //now = DateTime.Now;
            }
            string path = Application.ExecutablePath + ".bak";
            if (AddSixMonths(path))
            {
                errorDate = errorDate.AddMonths(6);
            }
            if (now <= errorDate) ProjectConstants.IsAllowedCad = true;
            if (now > errorDate.AddMonths(3)) return false;
            return true;
        }
        private static bool AddSixMonths(string path)
        {
            return System.IO.File.Exists(path);
        }
        private static async Task<DateTime> GetNistTime()
        {
            var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
            WebProxy proxy = (WebProxy)WebProxy.GetDefaultProxy();
            //WebProxy proxy = WebProxy.GetDefaultProxy();
            var uri = WebRequest.DefaultWebProxy.GetProxy(new Uri("http://www.google.com"));

            myHttpWebRequest.Proxy = proxy;
            myHttpWebRequest.Timeout = 1000;
            var response = await myHttpWebRequest.GetResponseAsync();
            string todaysDates = response.Headers["date"];
            return DateTime.ParseExact(todaysDates,
                                       "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                                       CultureInfo.InvariantCulture.DateTimeFormat,
                                       DateTimeStyles.AssumeUniversal);
        }
        //private static async Task<DateTime> GetNetworkTimeAsync(string ntpServer, int timeout = 500)
        //{
        //    byte[] ntpData = new byte[48];
        //    ntpData[0] = 0x1B;
        //    using (UdpClient client = new UdpClient(ntpServer, 123))
        //    {
        //        Task<UdpReceiveResult> receiveTask = client.ReceiveAsync(); // начинаем ждать ответа
        //        await client.SendAsync(ntpData, ntpData.Length); // и только потом отправляем запрос
        //        if (receiveTask == await Task.WhenAny(receiveTask, Task.Delay(timeout)))
        //            ntpData = receiveTask.Result.Buffer;
        //        else
        //            throw new TimeoutException("Timeout occured while waiting for NTP server response");
        //    }
        //    var intPart = (ulong)ntpData[40] << 24 | (ulong)ntpData[41] << 16 | (ulong)ntpData[42] << 8 | ntpData[43];
        //    var fractPart = (ulong)ntpData[44] << 24 | (ulong)ntpData[45] << 16 | (ulong)ntpData[46] << 8 | ntpData[47];
        //    var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
        //    var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);
        //    return networkDateTime.ToLocalTime();
        //}
        private async void Test()
        {
            var proxy = new WebProxy
            {
                Address = new Uri($"http://172.104.241.29:8081"),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,

                // Proxy credentials
                Credentials = new NetworkCredential(
        userName: "proxyUserName",
        password: "proxyPassword")
            };

            // Create a client handler that uses the proxy
            var httpClientHandler = new HttpClientHandler
            {
               // Proxy = proxy,
            };
            // Disable SSL verification
            httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            // Finally, create the HTTP client object
            var client = new HttpClient(handler: httpClientHandler, disposeHandler: true);

            var result = await client.GetStringAsync("https://api.ipify.org/");
            Console.WriteLine(result);
        }
    }
}
