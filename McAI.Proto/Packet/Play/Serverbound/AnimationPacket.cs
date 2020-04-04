﻿using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Serverbound
{
    public class AnimationPacket : BasePacket
    {
        public override int PacketId => 0x2A;
        public int Hand; //Varint

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out Hand);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[Animation] Hand:{Hand}";
        }
    }
}