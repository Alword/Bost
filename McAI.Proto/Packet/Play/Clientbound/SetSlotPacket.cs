﻿using McAI.Proto.Model;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class SetSlotPacket : BasePacket
    {
        public override int PacketId => 0x17;

        public sbyte WindowID;
        public short Slot;
        public Slot SlotData;

        public override void Read(byte[] array)
        {
            McByte.TryParse(ref array, out WindowID);
            McShort.TryParse(ref array, out Slot);
            SlotData = new Slot();
            SlotData.Parse(ref array);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[SetSlot] WindowID:{WindowID} Slot:{Slot} SlotData:{SlotData}";
        }
    }
}
