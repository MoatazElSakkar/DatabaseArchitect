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
        public Response Header
        {
            get;
            set;
        }
        public object Attachment;
    }
    public class ServerSocket:GlaciaProtocol
    {
        public Socket Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public delegate void CallBackFunction(ServerSocket PrimarySocket);

        public ServerSocket(CallBackFunction AfterConnect)
        {
            Listener.Bind(new IPEndPoint(IPAddress.Any, 2271));
            Listener.Listen(120);
            Transit = Listener.Accept();
            AfterConnect(this);
        }

    }
}
