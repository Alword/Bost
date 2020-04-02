using McAI.Proto.StreamReader.Abstractions;
using McAI.Proto.StreamReader.Enum;
using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace McAI.Proto
{
    public class ConnectionListner
    {
        private readonly McConnection read;
        private readonly McConnection write;
        private readonly PacketEventHub packetEventHub;
        public ConnectionListner()
        {
            packetEventHub = new PacketEventHub();
            read = new McConnection(new McConnectionContext(packetEventHub)
            {
                ConnectionState = ConnectionStates.Login,
                BoundTo = Bounds.Client
            });

            write = new McConnection(new McConnectionContext(packetEventHub)
            {
                ConnectionState = ConnectionStates.Handshaking,
                BoundTo = Bounds.Server
            });
        }

        public void SendListner(object sender, byte[] array) => write.Listen(sender, array);
        public void ReciveListner(object sender, byte[] array) => read.Listen(sender, array);
        public void Subscribe(PacketKey t, IPacketEventHandler packetEventHandler) => packetEventHub.Subscribe(t, packetEventHandler);
    }
}
