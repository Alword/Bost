﻿using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class EntityMovementPacket : BasePacket
    {
        public override int PacketId => 0x2C;
        public int EntityID; //Varint

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out EntityID);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[EntityMovement] EntityID:{EntityID}";
        }
    }
}