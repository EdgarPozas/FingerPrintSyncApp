using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FingerPrintSyncApp.Lib
{
    public class Log
    {
        private static Log log;
        public string FilePath { get { return $"./files/log.txt"; } }
        private Log() { }

        public static Log GetInstance()
        {
            if (log == null)
            {
                log = new Log();
            }
            return log;
        }

        public void WriteFile(string msg)
        {
            string line = $"{DateTime.Now},{msg}";
            File.AppendAllText(FilePath, line);
        }
    }
}
