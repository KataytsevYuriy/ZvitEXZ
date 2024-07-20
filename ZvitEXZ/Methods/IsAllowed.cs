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

namespace ZvitEXZ.Methods
{
    internal class IsAllowed
    {
        public static async Task<bool> Check()
        {
            DateTime errorDate = new DateTime(2025, 1, 5);//год, месяц, день
            DateTime now;
            try
            {
                //now = await GetServerTimeAsync();
                now=DateTime.Now;
            }
            catch
            {
                Logs.AddAlarm("Нет соединения с интернетом!");
                return false;
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
        public static async Task<DateTime> GetServerTimeAsync()
        {
            string TimeApiUrl = "http://worldtimeapi.org/api/timezone/Etc/UTC";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(TimeApiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(responseBody);
                string dateTimeString = json["utc_datetime"].ToString();

                return DateTime.Parse(dateTimeString);
            }
        }
        private static bool AddSixMonths(string path)
        {
            return System.IO.File.Exists(path);
        }
    }
}
