using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBA.Structure;

namespace DBA_Server_Test
{
    static class Server
    {
        public static string ServerName {get;set;}
        public static string Password { get; private set; }
        public static string ServerFile { get; set; }
        public static int DatabaseCount { get; set; }

        static bool Verified = false;

        public static List<Database> Databases = new List<Database>();

        public static bool Verify(string Entry)
        {
            if (Entry == Password)
            {
                Verified = true;
                return true;
            }
            else
            {
                Verified = false;
                return false;
            }
        }

        public static void ChangePassword(string newPassword)
        {
            if (Verified)
                Password = newPassword;
        }

        public static string GetInfo()
        {
            return "Name=" + ServerName + " DatabasesCount=" + Databases.ToString();
        }
    }
}
