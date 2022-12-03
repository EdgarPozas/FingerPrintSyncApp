using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FingerPrintSyncApp.Lib
{
    public class Config
    {
        private static Config config;
        public string FilePath { get { return $"./files/config.txt"; } }
        public Dictionary<string, string> Content;

        private Config() { }

        public static Config GetInstance()
        {
            if (config == null)
            {
                config = new Config();
            }
            return config;
        }

        public bool ExistsFile()
        {
            return File.Exists(FilePath);
        }

        public void CreateFile(string[] defaultLines = null)
        {
            string[] lines = 
            {
                "url_http=http://example.com:3000",
                "network_base=192.168.3.0",
                "hosts=25",
                "timeout=120"
            };
            if (defaultLines != null)
                lines = defaultLines;
            File.WriteAllLines(FilePath, lines, Encoding.UTF8);
        }

        public void DeleteFile()
        {
            File.Delete(FilePath);
        }

        public void ParseFile()
        {
            string[] lines = File.ReadAllLines(FilePath, Encoding.UTF8);
            Content = new Dictionary<string, string>();
            foreach (string line in lines)
            {
                string[] values = line.Split('=');
                if (values.Length != 2) 
                    throw new Error(ERRORS.CONFIG_FILE_STRUCTURE);
                Content.Add(FilterValue(values[0]), FilterValue(values[1]));
            }
        }

        private string FilterValue(string value)
        {
            return value.Replace(" ", "");
        }
    }
}
