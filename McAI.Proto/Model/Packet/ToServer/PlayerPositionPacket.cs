﻿using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Model.Packet.ToServer
{
    public class PlayerPositionPacket : BasePacket
    {
        public override int PacketId => throw new NotImplementedException();

        public override void Read(byte[] array)
        {
            throw new NotImplementedException();
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }
    }
}
