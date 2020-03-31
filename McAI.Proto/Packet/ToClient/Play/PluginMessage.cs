using McAI.Proto.Extentions;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace McAI.Proto.Packet.ToClient.Game
{
    public class PluginMessagePackage : BasePacket
    {
        public override int PacketId => 0x19;
        public string Channel;
        public byte[] Data;

        public override void Read(byte[] array)
        {
            McString.TryParse(ref array, out Channel);
            Data = array;
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[PluginMessage{base.ToString()}] Channel: {Channel} Data:{Data.ToHexString()}";
        }
    }
}
