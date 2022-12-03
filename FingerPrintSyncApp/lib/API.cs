using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FingerPrintSyncApp.Lib
{
    public class ConfigResponse
    {
        public int code;
        public string msg;
        public Content data;

        public class Content
        {
            public string time;
            public string time_zone;
            public List<Sensor> sensors;
        }

        public class Sensor
        {
            public int id;
            public string name;
            public string serial_number;
            public string admin_password;
        }
    }

    public class EmployeesResponse
    {
        public string msg;
        public List<Employee> data;

        public class Employee
        {
            public int employee_number;
            public string name;
            public string pin_code;
            public string card_code;
            public List<FingerPrint> finger_prints;
        }

        public class FingerPrint
        {
            public int finger_index;
            public string template;
        }
    }

    public class ZKTecoUserRequest : ZKTecoUser
    {
        public string SerialNumber;

        public ZKTecoUserRequest(ZKTecoUser user)
        {
            MachineNumber = user.MachineNumber;
            EnrollNumber = user.EnrollNumber;
            Name = user.Name;
            Password = user.Password;
            Privelage = user.Privelage;
            Enabled = user.Enabled;
            Flag = user.Flag;
            Fingers = user.Fingers;
            CardCode = user.CardCode;
        }
    }

    public class ZKTecoLogRequest : ZKTecoLog
    {
        public string SerialNumber;

        public ZKTecoLogRequest(ZKTecoLog log)
        {
            MachineNumber = log.MachineNumber;
            EnrollNumber = log.EnrollNumber;
            InOutMode = log.InOutMode;
            InOutMode = log.InOutMode;
            VerifyMode = log.VerifyMode;
            CheckTime = log.CheckTime;
            WorkCode = log.WorkCode;
        }
    }

    public class SincronizeRequest
    {
        public List<ZKTecoUserRequest> Users;
        public List<ZKTecoLogRequest> Logs;
    }

    public class API
    {
        private readonly HttpClient HttpClient;

        public API()
        {
            HttpClient = new HttpClient
            {
                Timeout = Timeout.InfiniteTimeSpan
            };
            HttpClient.DefaultRequestHeaders.Add("User-Agent", "Other");
        }

        public async Task<bool> isOnline()
        {
            return await SendRequestConnection();
        }

        private async Task<bool> SendRequestConnection()
        {
            string path = "/online";
            var response = await HttpClient.GetAsync($"{UrlHttp()}{path}");
            bool isOnline = response.StatusCode == HttpStatusCode.OK;
            UpdateOnline(isOnline);
            return isOnline;
        }

        public async Task<ConfigResponse> DownloadConfig()
        {
            string path = "/configurate";
            var response = await HttpClient.GetAsync($"{UrlHttp()}{path}");
            if (response.StatusCode != HttpStatusCode.OK)
            {
                UpdateOnline(false);
                return null;
            }
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ConfigResponse>(content);
        }

        public async Task<EmployeesResponse> DownloadEmployees()
        {
            string path = "/list_employees";
            var response = await HttpClient.GetAsync($"{UrlHttp()}{path}");
            if (response.StatusCode != HttpStatusCode.OK)
            {
                UpdateOnline(false);
                return null;
            }
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EmployeesResponse>(content);
        }

        public async Task<bool> SendRequestSynchronize(string serial, List<ZKTecoUserRequest> users, List<ZKTecoLogRequest> logs)
        {
            string path = "/synchronize";

            var payload = new SincronizeRequest()
            {
                Users = users,
                Logs = logs
            };

            var stringPayload = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync($"{UrlHttp()}{path}?SN={serial}", httpContent);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                UpdateOnline(false);
                return false;
            }
            return true;
        }

        private void UpdateOnline(bool isOnline)
        {
            Storage.GetInstance().isOnline = isOnline;
        }

        private string UrlHttp()
        {
            return $"{Config.GetInstance().Content["url_http"]}/finger_print_sensors/";
        }
    }
}
