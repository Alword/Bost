using McAI.Proto.Model.Packet.ToServer;
using McAI.Proto.Packet.ToClient.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.ToClient.Login
{
    public class SetCompression : Command
    {
        private readonly SetCompressionPacket compressionPacket;
        public SetCompression(bool isLogging = false) : base(isLogging)
        {
            compressionPacket = new SetCompressionPacket();
        }

        public override void Execute(byte[] array)
        {
            compressionPacket.Read(array);
            //Debug($"[SetCompression] PV:{handshake.ProtocolVersion} {handshake.Address}:{handshake.Port} {handshake.LoginState}");
        }
    }
}
