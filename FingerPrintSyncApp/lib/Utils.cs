using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FingerPrintSyncApp.Lib
{
    public class Utils
    {
        public static async Task<List<IPAddress>> ScanNetwork(string addrString, int hosts, int timeout)
        {
            List<IPAddress> posibleAddress = new List<IPAddress>();
            
            IPAddress.TryParse(addrString, out IPAddress ipAddress);

            if (ipAddress == null)
                return posibleAddress;

            var bytes = ipAddress.GetAddressBytes();
            int i = 0;
            do
            {
                var ip = new IPAddress(bytes);
                if (await PingTheDevice(ip, timeout))
                    posibleAddress.Add(ip);
                if (bytes[1] == 255)
                    bytes[0] += 1;
                else if (bytes[2] == 255)
                    bytes[1] += 1;
                else if (bytes[3] == 255)
                    bytes[2] += 1;
                bytes[3] += 1;
                i++;
            } while (i < hosts);
            return posibleAddress;
        }

        public static bool ValidateIP(string addrString)
        {
            return IPAddress.TryParse(addrString, out _);
        }

        public static async Task<bool> PingTheDevice(IPAddress ipAddress, int timeout)
        {
            try
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions
                {
                    DontFragment = true
                };

                string data = "a";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                PingReply reply = await pingSender.SendPingAsync(ipAddress,timeout, buffer, options);

                return reply.Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }
    }
}
