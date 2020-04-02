﻿using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Serverbound
{
    public class KeepAlivePacket : BasePacket
    {
        public override int PacketId => 0x0F;
        public long KeepAliveID;

        public override void Read(byte[] array)
        {
            McLong.TryParse(ref array, out KeepAliveID);
        }

        public override byte[] Write()
        {
            return McLong.ToBytes(KeepAliveID);
        }

        public override string ToString()
        {
            return $"KeepAlive KeepAliveID: {KeepAliveID}";
        }
    }
}
