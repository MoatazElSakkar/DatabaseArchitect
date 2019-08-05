using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBA.GlaciaProtocol;

namespace DB_Architect
{
    public class Client
    {
        public delegate void AfterConnect(Client C, EventArgs E);
        public event AfterConnect Connected;

        public Home.statusChange UpdateHost;

        public Client(Home.statusChange _updateHost)
        {
            UpdateHost = _updateHost;
        }
        public static Request CreateRequest(RequestType Rt, object attachment)
        {
            Request Ri = new Request();
            Ri.Header = Rt;
            Ri.Attachment = attachment;
            return Ri;
        }

        public ClientSocket CliSocket=new ClientSocket();

        public bool verified = false;

        public Response VerifyCredentials(string Password)
        {
            if (!CliSocket.Intialized)
                throw new Exception("Please enter server name or IP Address");
            CliSocket.send(CreateRequest(RequestType.VerifyIdentity,Password));
            Response R = CliSocket.recieve() as Response;
            if (R.Header != ResponseType.FalseCredentials)
            {
                verified = true;
                Connected(this, new EventArgs());
            }
            return R;
        }

        public Response QueryServer(string Query)
        {
            if (!CliSocket.Intialized)
                throw new Exception("Connection Invalid");
            CliSocket.send(CreateRequest(RequestType.Query,Query));
            return CliSocket.recieve() as Response;
        }

        public Response GetServerInformation()
        {
            if (!CliSocket.Intialized)
                throw new Exception("Connection Invalid");
            CliSocket.send(CreateRequest(RequestType.RetrieveServerInfo, null));
            return CliSocket.recieve() as Response;
        }

        public Response Disconnect()
        {
            if (!CliSocket.Intialized)
                throw new Exception("Connection Invalid");
            CliSocket.send(CreateRequest(RequestType.Disconnect, null));
            return CliSocket.recieve() as Response;
        }
    }
}
