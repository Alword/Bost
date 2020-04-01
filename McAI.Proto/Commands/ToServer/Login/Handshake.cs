using McAI.Proto.Packet.Handshaking.Serverbound;

namespace McAI.Proto.Commands.ToServer.Login
{
    public class Handshake : Command
    {
        private readonly HandshakePacket handshake;
        public Handshake(bool isLogging = false) : base(isLogging)
        {
            handshake = new HandshakePacket();
        }

        public override void Execute(byte[] array)
        {
            handshake.Read(array);
            Debug($"[Handshake] PV:{handshake.ProtocolVersion} {handshake.Address}:{handshake.Port} {handshake.LoginState}");
        }
    }
}
