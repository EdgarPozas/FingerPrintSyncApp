using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintSyncApp.Lib
{
    public class Storage
    {
        private static Storage storage;
        public bool isSensorActive;
        public bool isOnline;

        private Storage() {}

        public static Storage GetInstance()
        {
            if (storage == null)
            {
                storage = new Storage();
            }
            return storage;
        }
    }
}
