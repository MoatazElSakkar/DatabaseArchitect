using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DBA.GlaciaProtocol
{
    public enum ResponseType
    {
        ConnectSuccess,
        ServerInformation,
        IdentityVerified,
        FalseCredentials,
        QueryResponse,
        ServerSettings,
        OperationFeedback
    }

    public enum RequestType
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
    public class GlaciaProtocol
    {
        public Socket Transit = new Socket(SocketType.Stream, ProtocolType.Tcp);

        public void send(object Message)
        {
            if (!Transit.Connected) { throw new Exception("Socket not connected"); }
            var stream = new MemoryStream();
            byte[] transmissionHeader = new byte[4];
            //1->2 Transmission Size
            (new BinaryFormatter()).Serialize(stream, Message);
            transmissionHeader = BitConverter.GetBytes(stream.ToArray().Length);
            Transit.Send(transmissionHeader);
            Transit.Send(stream.ToArray());
        }

        public object recieve()
        {
            if (!Transit.Connected) { throw new Exception("Socket not connected"); }
            byte[] transmissionHeader = new byte[4];
            //1->2 Transmission Size
            Transit.Receive(transmissionHeader);
            int TransmissionSize = BitConverter.ToInt32(transmissionHeader, 0);
            byte[] inboundTransmission = new byte[TransmissionSize];
            Transit.Receive(inboundTransmission);
            MemoryStream Stream = new MemoryStream(inboundTransmission);
            return (new BinaryFormatter()).Deserialize(Stream);
        }
    }
}