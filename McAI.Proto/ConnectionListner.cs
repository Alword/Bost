using McAI.Proto.Packet;
using McAI.Proto.StreamReader.Abstractions;
using McAI.Proto.StreamReader.Enum;
using McAI.Proto.StreamReader.Model;

namespace McAI.Proto
{
    public class ConnectionListner
    {
        private readonly McConnection read;
        private readonly McConnection write;
        private readonly PacketEventHub packetEventHub;
        private readonly GenericEventHub genericEventHub;
        public ConnectionListner()
        {
            packetEventHub = new PacketEventHub();
            genericEventHub = new GenericEventHub();
            read = new McConnection(new McConnectionContext(packetEventHub, genericEventHub)
            {
                ConnectionState = ConnectionStates.Login,
                BoundTo = Bounds.Client
            });

            write = new McConnection(new McConnectionContext(packetEventHub, genericEventHub)
            {
                ConnectionState = ConnectionStates.Handshaking,
                BoundTo = Bounds.Server
            });
        }

        public void SendListner(object sender, byte[] array) => write.Listen(sender, array);
        public void ReciveListner(object sender, byte[] array) => read.Listen(sender, array);
        public void Subscribe(PacketKey t, IPacketEventHandler packetEventHandler) => packetEventHub.Subscribe(t, packetEventHandler);
        public void Subscribe<T>(PacketEventHandler<T> packeteventHandeler)
            where T : BasePacket => genericEventHub.Subscribe(packeteventHandeler);


    }
}
