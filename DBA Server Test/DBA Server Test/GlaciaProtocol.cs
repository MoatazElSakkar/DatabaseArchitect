using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DBA_Server_Test
{
    public class GlaciaProtocol
    {
        public enum Response
        {
            ConnectSuccess,
            ServerInformation,
            IdentityVerified,
            FalseCredentials,
            QueryResponse,
            ServerSettings,
            OperationFeedback
        }

        public enum Request
        {
            Connect,
            RetrieveServerInfo,
            VerifyIdentity,
            Query,
            ModifyServerSettings,
            ReadServerSettings,
            Disconnect,
            Feedback
        }
        public Socket Transit;

        public void send(object Message)
        {
            if (Transit==null) { throw new Exception("Socket not connected"); }
            var stream = new MemoryStream();
            byte[] transmissionHeader = new byte[2];
            //1->2 Transmission Size
            (new BinaryFormatter()).Serialize(stream, Message);
            Transit.Send(transmissionHeader);
            Transit.Send(stream.ToArray());
        }

        public object recieve()
        {
            if (Transit == null) { throw new Exception("Socket not connected"); }
            byte[] transmissionHeader = new byte[2];
            //1->2 Transmission Size
            Transit.Receive(transmissionHeader);
            byte[] inboundTransmission = new byte[BitConverter.ToInt32(transmissionHeader, 0)];
            Transit.Receive(inboundTransmission);
            MemoryStream Stream = new MemoryStream(inboundTransmission);
            return (new BinaryFormatter()).Deserialize(Stream);
        }
    }
}