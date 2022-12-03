using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using zkemkeeper;

namespace FingerPrintSyncApp.Lib
{
    public class ZKTecoUser
    {
        public int MachineNumber;
        public string EnrollNumber;
        public string Name;
        public string Password;
        public int Privelage;
        public bool Enabled;
        public string Flag;
        public string CardCode;
        public List<ZKTecoFinger> Fingers = new List<ZKTecoFinger>();
    }

    public class ZKTecoFinger
    {
        public int FingerIndex;
        public string Template;
        public int Flag;
        public int TemplateLength;
    }

    public class ZKTecoLog
    {
        public int MachineNumber;
        public string EnrollNumber;
        public int InOutMode;
        public int VerifyMode;
        public DateTime CheckTime;
        public int WorkCode;
    }

    public class ZKTecoDevice
    {
        private readonly CZKEM objZkeeper;
        private string ip;
        private int port;
        private int machineNumber;

        public string SerialNumber;

        public ZKTecoDevice()
        {
            objZkeeper = new CZKEM();
        }

        public Task<bool> Connect(string ip, int port = 4370, int machineNumber = 1)
        {
            this.ip = ip;
            this.port = port;
            this.machineNumber = machineNumber;
            return Task.Run(() => objZkeeper.Connect_Net(ip, port));
        }

        public void Disconnect()
        {
            objZkeeper.Disconnect();
        }

        public Task<string> GetDeviceInfo(bool resumed = true)
        {
            return Task.Run(() =>
            {
                StringBuilder sb = new StringBuilder();

                string returnValue = string.Empty;

                objZkeeper.GetFirmwareVersion(machineNumber, ref returnValue);
                if (returnValue.Trim() != string.Empty && !resumed)
                {
                    sb.Append("Firmware V: ");
                    sb.Append(returnValue);
                    sb.Append(",");
                }

                returnValue = string.Empty;
                objZkeeper.GetVendor(ref returnValue);
                if (returnValue.Trim() != string.Empty && !resumed)
                {
                    sb.Append("Vendor: ");
                    sb.Append(returnValue);
                    sb.Append(",");
                }

                string sWiegandFmt = string.Empty;
                objZkeeper.GetWiegandFmt(machineNumber, ref sWiegandFmt);

                returnValue = string.Empty;
                objZkeeper.GetSDKVersion(ref returnValue);
                if (returnValue.Trim() != string.Empty && !resumed)
                {
                    sb.Append("SDK V: ");
                    sb.Append(returnValue);
                    sb.Append(",");
                }

                returnValue = string.Empty;
                objZkeeper.GetSerialNumber(machineNumber, out returnValue);
                if (returnValue.Trim() != string.Empty)
                {
                    sb.Append("Serial No: ");
                    sb.Append(returnValue);
                    sb.Append(",");
                    SerialNumber = returnValue;
                }

                returnValue = string.Empty;
                objZkeeper.GetDeviceMAC(machineNumber, ref returnValue);
                if (returnValue.Trim() != string.Empty && !resumed)
                {
                    sb.Append("Device MAC: ");
                    sb.Append(returnValue);
                }

                return sb.ToString();
            });
        }

        public DateTime GetDeviceTime()
        {
            int dwYear = 0;
            int dwMonth = 0;
            int dwDay = 0;
            int dwHour = 0;
            int dwMinute = 0;
            int dwSecond = 0;

            if (!objZkeeper.GetDeviceTime(machineNumber, ref dwYear, ref dwMonth, ref dwDay, ref dwHour, ref dwMinute, ref dwSecond))
                return new DateTime(0);

            return new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond);
        }

        public bool SetDeviceTime(DateTime dateTime)
        {
            return objZkeeper.SetDeviceTime2(machineNumber, dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
        }

        public List<ZKTecoUser> GetAllUsers()
        {   
            List<ZKTecoUser> users = new List<ZKTecoUser>();

            objZkeeper.ReadAllUserID(machineNumber);
            objZkeeper.ReadAllTemplate(machineNumber);

            while (objZkeeper.SSR_GetAllUserInfo(machineNumber, out string sdwEnrollNumber, out string sName, out string sPassword, out int iPrivilege, out bool bEnabled))
            {
                objZkeeper.GetStrCardNumber(out string CardCode);

                ZKTecoUser tmpUser = new ZKTecoUser
                {
                    MachineNumber = machineNumber,
                    EnrollNumber = sdwEnrollNumber,
                    Name = sName,
                    Password = sPassword,
                    Privelage = iPrivilege,
                    Enabled = bEnabled,
                    CardCode = CardCode
                };
                for (int idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                {
                    if (!objZkeeper.GetUserTmpExStr(machineNumber, sdwEnrollNumber, idwFingerIndex, out int iFlag, out string sTmpData, out int iTmpLength))
                        continue;
                    ZKTecoFinger finger = new ZKTecoFinger
                    {
                        FingerIndex = idwFingerIndex,
                        Template = sTmpData,
                        Flag = iFlag,
                        TemplateLength = iTmpLength
                    };
                    tmpUser.Fingers.Add(finger);
                }
                users.Add(tmpUser);
            }
            return users;
        }

        public List<ZKTecoLog> GetAllLogs()
        {
            List<ZKTecoLog> logs = new List<ZKTecoLog>();
            int dwWorkCode = 0;

            objZkeeper.ReadAllGLogData(machineNumber);

            while (objZkeeper.SSR_GetGeneralLogData(machineNumber, out string dwEnrollNumber, out int dwVerifyMode, out int dwInOutMode, out int dwYear, out int dwMonth, out int dwDay, out int dwHour, out int dwMinute, out int dwSecond, ref dwWorkCode))
            {
                var inputDate = new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond);

                ZKTecoLog log = new ZKTecoLog
                {
                    MachineNumber = machineNumber,
                    EnrollNumber = dwEnrollNumber,
                    VerifyMode = dwVerifyMode,
                    InOutMode = dwInOutMode,
                    WorkCode = dwWorkCode,
                    CheckTime = inputDate
                };
                logs.Add(log);
            }
            return logs;
        }

        public bool DeleteLogs()
        {
            return objZkeeper.ClearGLog(machineNumber);
        }

        public bool DeleteUsers()
        {
            return objZkeeper.ClearData(machineNumber, 2) && objZkeeper.ClearData(machineNumber, 5);
        }

        public bool CreateUser(ZKTecoUser user)
        {
            objZkeeper.SetStrCardNumber(user.CardCode);
            objZkeeper.SSR_SetUserInfo(machineNumber, user.EnrollNumber, user.Name, user.Password, user.Privelage, user.Enabled);
            return true;
        }

        public bool UpdateTemplates(ZKTecoUser user)
        {
            user.Fingers.ForEach(finger =>
            {
                bool correct = objZkeeper.SetUserTmpExStr(machineNumber, user.EnrollNumber, finger.FingerIndex, finger.Flag, finger.Template);
            });
            return true;
        }
        
        public int GetLastErrorCode()
        {
            int code = 0;
            objZkeeper.GetLastError(ref code);
            return code;
        }
    }
}
