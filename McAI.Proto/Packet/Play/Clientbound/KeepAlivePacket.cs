﻿using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class KeepAlivePacket : BasePacket
    {
        public override int PacketId => 0x21;
        public long KeepAliveID;

        public override void Read(byte[] array)
        {
            McLong.TryParse(ref array, out KeepAliveID);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"<[KeepAlive|{base.ToString()}] KeepAliveID: {KeepAliveID}";
        }
    }
}
