using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.ToServer.Play
{
    public class ClientSettingsPacket : BasePacket
    {
        public override int PacketId => 0x05;
        public string Locale; //string (16)
        public byte ViewDistance;
        public int ChatMode; //Varint Enum
        public bool ChatColors;
        public byte DisplayedSkinParts; //Unsigned Byte
        public int MainHand; //Varint Enum

        public override void Read(byte[] array)
        {
            McString.TryParse(ref array, out Locale);
            McUnsignedByte.TryParse(ref array, out ViewDistance);
            McInt.TryParse(ref array, out ChatMode);
            McBoolean.TryParse(ref array, out ChatColors);
            McUnsignedByte.TryParse(ref array, out DisplayedSkinParts);
            McInt.TryParse(ref array, out MainHand);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $">[ClientSettings{base.ToString()}] Locale:{Locale} ViewDistance:{ViewDistance} ChatMode:{ChatMode} ChatColors:{ChatColors} DisplayedSkinParts:{DisplayedSkinParts} MainHand:{MainHand}";
        }
    }
}
