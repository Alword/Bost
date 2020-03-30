using McAI.Proto.Model.Packet.ToServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.Client
{
    public class SetCompression : Command
    {
        private readonly HandshakePacket handshake;
        public SetCompression(bool isLogging = false) : base(isLogging)
        {
            handshake = new HandshakePacket();
        }

        public override void Execute(byte[] array)
        {
            handshake.Read(array);
            Debug($"[SetCompression] PV:{handshake.ProtocolVersion} {handshake.Address}:{handshake.Port} {handshake.LoginState}");
        }
    }
}
