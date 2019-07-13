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
        public static string Password { get; set; }
        public static string ServerFile { get; set; }
        public static int Databases { get; set; }

        public static List<Database> DBS
        {
            get;
            set;
        }

        public static bool Charted
        {
            get;
            set;
        }

        public static bool Verify(string Entry)
        {
            if (Entry == Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetInfo()
        {
            return "Name=" + ServerName + " DatabasesCount=" + Databases.ToString();
        }
    }
}
