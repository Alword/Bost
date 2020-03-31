using McAI.Proto.Packet.ToClient.Game;
namespace McAI.Proto.Commands.ToClient.Game
{
    class HeldItemChange : Command
    {
        private readonly HeldItemChangePacket packet;
        public HeldItemChange(bool isLogging) : base(isLogging)
        {
            packet = new HeldItemChangePacket();
        }

        public override void Execute(byte[] array)
        {
            packet.Read(array);
            Debug(packet.ToString());
        }
    }
}
