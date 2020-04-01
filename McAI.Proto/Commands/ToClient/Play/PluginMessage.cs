using McAI.Proto.Packet.Play.Clientbound;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.ToClient.Game
{
    public class PluginMessage : Command
    {
        private readonly PluginMessagePackage package;
        public PluginMessage(bool isLogging) : base(isLogging)
        {
            package = new PluginMessagePackage();
        }

        public override void Execute(byte[] array)
        {
            package.Read(array);
            Debug(package.ToString());
        }
    }
}
