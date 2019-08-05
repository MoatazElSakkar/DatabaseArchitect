using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace DBA.GlaciaProtocol
{
    [SerializableAttribute()]
    public class Request
    {
        public RequestType Header
        {
            get;
            set;
        }
        public object Attachment;
    }

    public class ClientSocket:GlaciaProtocol
    {
        public bool Intialized = false;

        public ClientSocket(string ServerName)
        {
            ClienSocketName = ServerName;
        }

        public ClientSocket()
        {
        }

        public string ClienSocketName
        {
            set
            {
                IPAddress ServerIP;
                bool RawIP = true;
                foreach (char c in value)
                    if (c < '0' && c > '9' || c != '.')
                        RawIP = false;
                if (RawIP)
                    ServerIP = IPAddress.Parse(value);
                else
                    ServerIP = Dns.GetHostAddresses(value).First(x => x.ToString().Contains('.'));
                Transit.Connect(ServerIP, 2271);
                Intialized = true;
            }
        }
    }
}
