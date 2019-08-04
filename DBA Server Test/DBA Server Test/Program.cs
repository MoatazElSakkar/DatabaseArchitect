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
            Thread Thread = new Thread(() => { PrimaryLoop(); });
            Thread.Start();
        }

        /// <summary>
        /// Looping sockets dispatcher.
        /// </summary>
        static void PrimaryLoop()
        {
            string s=Server.Password;
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
                    switch ((buffer as Request).Header)
                    {
                        case RequestType.Connect:
                            break;
                        case RequestType.Disconnect:
                            break;
                        case RequestType.Feedback:
                            break;
                        case RequestType.ModifyServerSettings:
                            break;
                        case RequestType.Query:
                            break;
                        case RequestType.ReadServerSettings:
                            break;
                        case RequestType.RetrieveServerInfo:
                            if (!PrimarySocket.elevated)
                                PrimarySocket.send(CreateResponse(ResponseType.OperationFailed, "Session not verified"));
                            else
                                PrimarySocket.send(CreateResponse(ResponseType.ServerInformation, Server.GetDatabaseSkeleton()));
                            break;
                        case RequestType.VerifyIdentity:
                            if (Verify(buffer as Request))
                            {
                                PrimarySocket.send(CreateResponse(ResponseType.IdentityVerified, "Session verified successfully"));
                                PrimarySocket.elevated = true;
                            }
                            else
                            {
                                //Log Access attempt;
                                PrimarySocket.send(CreateResponse(ResponseType.FalseCredentials, "False Credentials"));
                            }
                            break;
                    }

            
            }
        }

        static Response CreateResponse(ResponseType Type, object Attache)
        {
            Response R = new Response();
            R.Header = Type;
            R.Attachment = Attache;
            return R;
        }

        static bool Verify(Request Rq)
        {
            RequestType s = Rq.Header;
            if (Rq.Attachment is string)
            {
                string InputPassword = (string)Rq.Attachment;
                if (InputPassword == Server.Password)
                    return true;
            }
            return false;
        }

        

        static void ProcessQuery(Query Q)
        {
            string s = Q.Literal;
        }
    }
}
