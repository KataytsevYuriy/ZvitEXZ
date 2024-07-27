using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Methods
{
    internal class Reg
    {
        public bool WriteData(string userName, string userPassword)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
                key.CreateSubKey("ZvitEXZ");
                key = key.OpenSubKey("ZvitEXZ", true);
                if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(userPassword))
                {
                    if (key.GetValueNames().Contains("userName"))
                        key.DeleteValue("userName");
                    if (key.GetValueNames().Contains("userPass"))
                        key.DeleteValue("userPass");
                }
                else
                {
                    key.SetValue("userName", userName);
                    key.SetValue("userPass", userPassword);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool ReadData(out string userName, out string userPassword)
        {
            userName = "";
            userPassword = "";
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\ZvitEXZ", false);
                if (key != null)
                {
                    object name = key.GetValue("userName");
                    object pass = key.GetValue("userPass");
                    if (name != null && pass != null)
                    {
                        userName = name as String;
                        userPassword = pass as String;
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
