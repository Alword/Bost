using McAI.Proto.Packet.Play.Serverbound;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.ToServer.Play
{
    public class ClientSettings : Command
    {
        public ClientSettings(bool isLogging) : base(isLogging)
        {
        }

        public override void Execute(byte[] array)
        {
            ClientSettingsPacket packet = new ClientSettingsPacket();
            packet.Read(array);
            Debug(packet.ToString());
        }
    }
}
