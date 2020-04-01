using McAI.Proto.Enum;
using McAI.Proto.Packet.Login.Clientbound;

namespace McAI.Proto.Commands.ToClient.Login
{
    public class SetCompression : Command
    {
        private readonly SetCompressionPacket compressionPacket;
        public SetCompression(GameState gameState, bool isLogging = false) : base(isLogging)
        {
            this.gameState = gameState;
            compressionPacket = new SetCompressionPacket();
        }

        public override void Execute(byte[] array)
        {
            compressionPacket.Read(array);
            Debug($"[SetCompression] Threshold: {compressionPacket.Threshold}");
            gameState.ServerState = GameStates.Game;
        }
    }
}
