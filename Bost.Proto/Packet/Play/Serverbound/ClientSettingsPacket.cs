using Bost.Proto.Enum;
using Bost.Proto.Extentions;
using Bost.Proto.Types;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bost.Proto.Packet.Play.Serverbound
{
    public class ClientSettingsPacket : BasePacket
    {
        public override int PacketId => 0x05;
        [MaxLength(16)]public string Locale; //string (16)
        public byte ViewDistance;
        public ChatModes ChatMode; //Varint Enum
        public bool ChatColors;
        public byte DisplayedSkinParts; //Unsigned Byte
        public MainHands MainHand; //Varint Enum

        public override void Read(byte[] array)
        {
            McString.TryParse(ref array, out Locale);
            McUnsignedByte.TryParse(ref array, out ViewDistance);
            McVarint.TryParse(ref array, out int chatMode);
            ChatMode = (ChatModes)chatMode;
            McBoolean.TryParse(ref array, out ChatColors);
            McUnsignedByte.TryParse(ref array, out DisplayedSkinParts);
            McVarint.TryParse(ref array, out int mainHand);
            MainHand = (MainHands)mainHand;

        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"ClientSettings Locale:{Locale} ViewDistance:{ViewDistance} ChatMode:{ChatMode} " +
                $"ChatColors:{ChatColors} DisplayedSkinParts:{SkinParts()} MainHand:{MainHand}";
        }

        private string SkinParts()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"[{Enable(0)}] Cape");
            stringBuilder.AppendLine($"[{Enable(1)}] Jacket");
            stringBuilder.AppendLine($"[{Enable(2)}] Left Sleeve");
            stringBuilder.AppendLine($"[{Enable(3)}] Right Sleeve");
            stringBuilder.AppendLine($"[{Enable(4)}] Left Pants Leg");
            stringBuilder.AppendLine($"[{Enable(5)}] Right Pants Leg");
            stringBuilder.AppendLine($"[{Enable(6)}] Hat");

            return stringBuilder.ToString();
        }

        private string Enable(int number)
        {
            return DisplayedSkinParts.IsChecked(number) ? "x" : " ";
        }
    }
}
