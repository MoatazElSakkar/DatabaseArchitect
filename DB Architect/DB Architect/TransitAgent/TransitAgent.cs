using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace DBA
{
    class TransitAgent
    {
        Socket S=new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
        IPEndPoint IPE;
        byte[] buffer;

        public TransitAgent(string ServerName)
        {
            IPAddress[] AdressSet = Dns.GetHostAddresses(ServerName);
            IPAddress IPX;
            foreach (IPAddress IP in AdressSet)
            {
                if (IP.ToString().Contains('.'))
                {
                    IPX = IP;
                    IPE = new IPEndPoint(IPX, DB_Architect.Program.Port);
                }
            }
            S.Connect(IPE);
        }

        public bool Verified (string Password)
        {
            buffer = Encoding.Default.GetBytes("Verify"+Password);
            S.Send(buffer, SocketFlags.None);
            buffer = new byte[8192];
            S.Receive(buffer);
            string recieved = Encoding.Default.GetString(buffer).Replace("\0", "");
            if (recieved == "Verified")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Terminate()
        {
            try
            {
                buffer = Encoding.Default.GetBytes("Terminate");
                S.Send(buffer, SocketFlags.None);
            }
            catch
            {
            }
        }


        public List<string> Survey(string Parent,string ParentType)
        {
            buffer=null;
            buffer = Encoding.Default.GetBytes("Survey "+ParentType+" "+Parent);
            S.Send(buffer, SocketFlags.None);
            buffer = new byte[8192];
            S.Receive(buffer);
            int N = BitConverter.ToInt32(buffer,0);
            List<string> Recieved = new List<string>();
            buffer = new byte[N];
            S.Receive(buffer, SocketFlags.None);
            string Response = Encoding.Default.GetString(buffer);
            string[] Responsses = Response.Split(new char[] {'~'},StringSplitOptions.RemoveEmptyEntries);
            Recieved = Responsses.ToList<string>();
            return Recieved;
        }

        public DB_Architect.Table Query(string QueryScript,string DatabaseName)
        {
            Exception ImproperQueryException = new Exception("Query Inconsistant with Database Contents");

            buffer=null;
            DB_Architect.Table T = new DB_Architect.Table();
            buffer = Encoding.Default.GetBytes("PassiveQuery" + "~" + QueryScript + "~" + DatabaseName);
            S.Send(buffer, SocketFlags.None);
            buffer=new byte[8192];
            S.Receive(buffer,SocketFlags.None);
            if (Encoding.Default.GetString(buffer).Replace("\0","") == "Error")
            {
                throw ImproperQueryException;
            }
            int Len = BitConverter.ToInt32(buffer, 0);
            buffer = new byte[Len];
            S.Receive(buffer);
            string Response = Encoding.Default.GetString(buffer);
            string[] ParseResponse = Response.Split('~');
            DB_Architect.Key CurrentKey = new DB_Architect.Key();
            foreach (string Str in ParseResponse)
            {

                if (Str.Contains("%K%"))
                {
                    CurrentKey.Name = Str.Replace("%K%", "").Replace("%20%", " ");
                }
                else if (Str.Contains("%R%"))
                {
                    CurrentKey.Records.Add(Str.Replace("%R%","").Replace("%20%"," "));
                }
                else if (Str == "%EOK%")
                {
                    T.Keys.Add(CurrentKey);
                    CurrentKey = new DB_Architect.Key();
                }
                else if (Str == "%EOT%")
                {
                    break;
                }
            }

            return T;
        }

        public string ExecuteNonQueryScript(string QueryScript, string DatabaseName)
        {
            Exception ImproperQueryException = new Exception("Query Inconsistant with Database Contents");

            buffer = Encoding.Default.GetBytes("ActiveScript" + "~" + QueryScript + "~" + DatabaseName);
            S.Send(buffer, SocketFlags.None);
            buffer = null;
            buffer = new byte[8192];
            S.Receive(buffer, SocketFlags.None);
            string Response = Encoding.Default.GetString(buffer);
            if (Response.Replace("\0","") == "Activescript Execution Completed")
            {
                return Response;
            }
            else
            {
                throw ImproperQueryException;
            }
        }

        public void ExecuteServerScript(string QueryScript)
        {
            Exception ImproperQueryException = new Exception("Query Inconsistant with Database Contents");

            buffer = Encoding.Default.GetBytes("ServerScript" + "~" + QueryScript);
            S.Send(buffer, SocketFlags.None);
            buffer = null;
            buffer = new byte[8192];
        }

        public string AssumeProperties(string Script)
        {
            buffer = Encoding.Default.GetBytes("Properties" + " " + Script);
            S.Send(buffer, SocketFlags.None);
            buffer = null;
            buffer = new byte[8192];
            S.Receive(buffer, SocketFlags.None);
            string Temp = Encoding.Default.GetString(buffer);
            return Temp;
        }
    }
}
