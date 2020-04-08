using McAI.Proto.Model;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class MultiBlockChangePacket : BasePacket
    {
        public override int PacketId => 0x10;

        public int ChunkX;
        public int ChunkZ;
        public int RecordCount; //Varint
        public Record[] Records;

        public override void Read(byte[] array)
        {
            McInt.TryParse(ref array, out ChunkX);
            McInt.TryParse(ref array, out ChunkZ);
            McVarint.TryParse(ref array, out RecordCount);

            Records = new Record[RecordCount];
            for (int i = 0; i < RecordCount; i++)
            {
                Records[i] = new Record();
                Records[i].Read(ref array);
            }
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Record record in Records)
            {
                stringBuilder.AppendLine(record.ToString());
            }
            return $"[PlayerInfo] ChunkX:{ChunkX} ChunkZ:{ChunkZ} RecordCount:{RecordCount} " +
                $"Records:{stringBuilder}";
        }
    }
}
