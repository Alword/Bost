using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class UpdateHealthPacket : BasePacket
    {
        public override int PacketId => 0x49;

        public float Health; // 0 or less = dead, 20 = full HP 
        public int Food; // 0–20  varint
        public float FoodSaturation; // Seems to vary from 0.0 to 5.0 in integer increments 

        public override void Read(byte[] array)
        {
            McFloat.TryParse(ref array, out Health);
            McVarint.TryParse(ref array, out Food);
            McFloat.TryParse(ref array, out FoodSaturation);
        }

        public override string ToString()
        {
            return $"[UpdateHealthPacket] Health:{Health:0.00} Food:{Food} FoodSaturation:{FoodSaturation:0.00}";
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }
    }
}
