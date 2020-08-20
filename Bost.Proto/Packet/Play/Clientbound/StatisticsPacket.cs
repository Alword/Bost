using Bost.Proto.Model;
using Bost.Proto.Types;
using System;
using System.Text;

namespace Bost.Proto.Packet.Play.Clientbound
{
    public class StatisticsPacket : BasePacket
    {
        public override int PacketId => 0x07;

        public int Count; //Varint
        public int Value; //Varint
        public Statistic[] Statistics;


        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out Count);
            McVarint.TryParse(ref array, out Value);
            Statistics = new Statistic[Count];
            for (int i = 0; i < Count; i++)
            {
                Statistics[i].Parse(ref array);
            }
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"[StatisticsPacket] Count:{Count} Value:{Value}");
            foreach (Statistic statistic in Statistics)
            {
                stringBuilder.Append($"{statistic} ");
            }
            return stringBuilder.ToString();
        }
    }
}
