using McAI.Proto.Types;

namespace McAI.Proto.Packet.ToClient.Login
{
    public class SetCompressionPacket : BasePacket
    {
        public override int PacketId => 0x03;
        public int Threshold { get; set; }
        public override void Read(byte[] array)
        {
            Varint.TryParse(ref array, out int result);
            Threshold = result;
        }

        public override byte[] Write()
        {
            return Varint.ToBytes(Threshold);
        }
    }
}
