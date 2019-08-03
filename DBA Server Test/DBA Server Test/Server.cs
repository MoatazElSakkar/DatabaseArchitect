using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBA.Structure;
using System.IO;
using DBA.Refrences;

namespace DBA_Server_Test
{
    static class Server
    {
        public static string ServerName {get;set;}
        public static string Password { get; private set; }
        public static string ServerFile { get; set; }

        public static string DatabaseDir { get; set; }

        static bool Verified = false;

        public static Database Database;

        static Server()
        {
            if (!File.Exists(ServerFile))
            {
                //Register Inconsistency
                return;
            }
            FileStream Reader = new FileStream(ServerFile, FileMode.Open);
            while (Reader.Position < Reader.Length)
            {
                string bufferStr = ServerReaders.ReadRecord(Reader);
                string[] bufferSplit = bufferStr.Split(new char[] { ':', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                switch (bufferSplit[0])
                {
                    case "SRVNAME":
                        ServerName = bufferSplit[1];
                        break;
                    case "PASS-WD":
                        Password = bufferSplit[1];
                        break;
                    case "DB-DIR":
                        DatabaseDir = bufferSplit[1];
                        break;
                }
            }

            string DBDir =  DatabaseDir + "\\"+ "Database" + Extensions.DatabaseExtension + ".txt";
            if (!File.Exists(DBDir))
                DBDir = DatabaseDir + "\\" + "Database" + Extensions.DatabaseExtension.ToUpper() + ".txt";
            if (!File.Exists(DBDir))
                throw new Exception("Database not found");
            Database = new Database(DBDir);
            Database.Read();
            Reader.Close();
        }

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
            return "Name=";
        }
    }
}
