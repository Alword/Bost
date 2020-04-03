using McAI.Proto.Model;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
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
            for (int i=0; i<Count; i++)
            {
                Statistics[i].Parse(ref array);
            }
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }
    }
}
