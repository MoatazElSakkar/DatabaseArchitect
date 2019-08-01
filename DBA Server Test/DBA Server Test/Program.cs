using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using DBA.GlaciaProtocol;
using DBA.QueryEngine;

namespace DBA_Server_Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Server.ServerFile = "File.xml"; //Should add a setting to adjust it later
            Thread Thread = new Thread(() => { PrimaryLoop(); });
            Thread.Start();
        }

        /// <summary>
        /// Looping sockets dispatcher.
        /// </summary>
        static void PrimaryLoop()
        {
            while (true)
            {
                ServerSocket S = new ServerSocket(Standby);
            }
        }

        /// <summary>
        /// Server side connected mode interfacing function.
        /// </summary>
        public static void Standby(ServerSocket PrimarySocket)
        {
            while (PrimarySocket.Transit.Connected)
            {
                object buffer = PrimarySocket.recieve();
                if (buffer is Request)
                    ProcessRequest(buffer as Request);

            
            }
        }

        static void ProcessRequest(Request Rq)
        {
            string s=Rq.Header.ToString();
            if (Rq.Attachment is string)
            {
                string ix = (string)Rq.Attachment;
            }
        }

        static void ProcessQuery(Query Q)
        {
            string s = Q.Literal;
        }
    }
}
