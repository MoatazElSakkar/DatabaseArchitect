using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using DBA.GlaciaProtocol;
using DBA.QueryEngine;
using DBA.Structure;
using System.Net.Sockets;
using System.Net;

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
            Socket Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Listener.Bind(new IPEndPoint(IPAddress.Any, 2271));
            Listener.Listen(120);

            while (true)
            {
                Socket MidSocket = Listener.Accept();
                new Thread(() =>
                { ServerSocket S = new ServerSocket(MidSocket, Standby); }).Start();
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
                            PrimarySocket.send(CreateResponse(ResponseType.disconnected, "Disconnected"));
                            PrimarySocket.Transit.Close();
                            return;
                        case RequestType.Feedback:
                            break;
                        case RequestType.ModifyServerSettings:
                            break;
                        case RequestType.Query:
                            if (!PrimarySocket.elevated)
                                PrimarySocket.send(CreateResponse(ResponseType.OperationFailed, "Session not verified"));
                            else
                                PrimarySocket.send(CreateResponse(ResponseType.QueryResponse, ProcessQuery(buffer as Request)));
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
                                PrimarySocket.Transit.Close();
                                return;
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

        static object ProcessQuery(Request Qr)
        {
            if (!(Qr.Attachment is string))
                return "Invalid Query";
            string Qs = Qr.Attachment as string;
            Query Q = new Query(Qs);
            try
            {
                QueryScanner QS = new QueryScanner(Q);
                Q = QS.Scan();

                QueryParser QP = new QueryParser(Q);
                QueryTree Qt = QP.Reorder();

                QueryExecutioner Qexec = new QueryExecutioner(Qt, Server.Database, ServerReaders.ReadRecords);
                
                Table Ti = Qexec.ExecuteQuery();
                if (Qexec.AfterEffect[0])
                    Server.Database.Write();
                if (Qexec.AfterEffect[1])
                    Qexec.Tables.Last().Write();
                if (Qexec.AfterEffect[2])
                    Qexec.Tables.Last().WriteRecords();

                if (Ti == null)
                    return Qexec.Result;
                return Ti;
            }
            catch(Exception Ex)
            {
                return Ex.Message;
            }
        }
    }
}
