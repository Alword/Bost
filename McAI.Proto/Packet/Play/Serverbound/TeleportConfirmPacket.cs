using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Serverbound
{
    public class TeleportConfirmPacket : BasePacket
    {
        public override int PacketId => 0x00;
        public int TeleportID; //Varint

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out TeleportID);
        }

        public override byte[] Write()
        {
            return McVarint.ToBytes(TeleportID);
        }

        public override string ToString()
        {
            return $"TeleportConfirm TeleportID:{TeleportID}";
        }
    }
}
