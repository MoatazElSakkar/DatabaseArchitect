using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace DBA.GlaciaProtocol
{
    [SerializableAttribute()]
    public class Response
    {
        public ResponseType Header
        {
            get;
            set;
        }
        public object Attachment;
    }
    public class ServerSocket:GlaciaProtocol
    {
        public delegate void CallBackFunction(ServerSocket PrimarySocket);

        public bool elevated = false;

        public ServerSocket(Socket Incoming,CallBackFunction AfterConnect)
        {
            Transit = Incoming;
            try
            {
                AfterConnect(this);
            }
            catch
            {

            }
        }

    }
}
