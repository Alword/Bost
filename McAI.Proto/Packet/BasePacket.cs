namespace McAI.Proto.Packet
{
    public abstract class BasePacket
    {
        public BasePacket()
        {
        }
        public abstract int PacketId { get; }
        public abstract void Read(byte[] array);
        public abstract byte[] Write();

        public override string ToString()
        {
            return $"0x{PacketId:X02}";
        }
    }
}
